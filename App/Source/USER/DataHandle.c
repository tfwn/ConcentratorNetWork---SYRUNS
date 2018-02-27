/************************************************************************************************
*                                   SRWF-6009
*    (c) Copyright 2015, Software Department, Sunray Technology Co.Ltd
*                               All Rights Reserved
*
* FileName     : DataHandle.c
* Description  :
* Version      :
* Function List:
*------------------------------Revision History--------------------------------------------------
* No.   Version     Date            Revised By      Item            Description
* 1     V1.1        08/12/2015      Zhangxp         SRWF-6009       Original Version
************************************************************************************************/

#define DATAHANDLE_GLOBALS

/************************************************************************************************
*                             Include File Section
************************************************************************************************/
#include "Stm32f10x_conf.h"
#include "ucos_ii.h"
#include "Bsp.h"
#include "Main.h"
#include "Rtc.h"
#include "Timer.h"
#include "SerialPort.h"
#include "Gprs.h"
#include "Flash.h"
#include "Eeprom.h"
#include "DataHandle.h"
#include "Database.h"
#include <string.h>

/************************************************************************************************
*                        Global Variable Declare Section
************************************************************************************************/
uint8 PkgNo;
PORT_NO MonitorPort = Usart_Debug;                      // 监控端口
uint8 SubNodesSaveDelayTimer = 0;                       // 档案延时保存时间
uint16 ModifyScanChannel = 0;                          // 修改2E28扫描信道定时器
uint16 RTCTimingTimer = 60;                             // RTC校时任务启动定时器
uint16 GprsDelayDataUpTimer = 60;						// Gprs 缓存数据延时上传定时器
TASK_STATUS_STRUCT TaskRunStatus;                       // 任务运行状态
DATA_HANDLE_TASK DataHandle_TaskArry[MAX_DATA_HANDLE_TASK_NUM];
const uint8 Uart_RfTx_Filter[] = {SYNCWORD1, SYNCWORD2};
const uint8 DayMaskTab[] = {0xF0, 0xE0, 0xC0, 0x80};
const uint8 ModifyScanChannel_KEY[] = {0x5A, 0x5B, 0x5C, 0x5D, 0x5E, 0x5F, 0x60};

extern void Gprs_OutputDebugMsg(bool NeedTime, uint8 *StrPtr);

void DebugOutputLength(uint8 *StrPtr, uint8 SrcLength)
{
    uint16 len;
    uint8 *bufPtr;

    if ((void *)0 == (bufPtr = OSMemGetOpt(LargeMemoryPtr, 20, TIME_DELAY_MS(50)))) {
        return;
    }
    len = BcdToAscii( StrPtr, (uint8 *)bufPtr, SrcLength, 3);
    DataHandle_OutputMonitorMsg(Gprs_Connect_Msg, bufPtr, len);
    OSMemPut(LargeMemoryPtr, bufPtr);
    return;
}

/************************************************************************************************
*                           Prototype Declare Section
************************************************************************************************/
//void BigDataDebug(uint8 *BufPtr);

/************************************************************************************************
*                           Function Declare Section
************************************************************************************************/

/************************************************************************************************
* Function Name: DataHandle_GetEmptyTaskPtr
* Decription   : 在任务队列中搜索空的任务指针
* Input        : 无
* Output       : 任务的指针
* Others       : 无
************************************************************************************************/
DATA_HANDLE_TASK *DataHandle_GetEmptyTaskPtr(void)
{
    uint8 i;

    // 搜索未被占用的空间,创建数据上传任务
    for (i = 0; i < MAX_DATA_HANDLE_TASK_NUM; i++) {
        if ((void *)0 == DataHandle_TaskArry[i].StkPtr) {
            return (&DataHandle_TaskArry[i]);
        }
    }

    // 任务队列全部使用返回空队列
    return ((void *)0);
}

/************************************************************************************************
* Function Name: DataHandle_SetPkgProperty
* Decription   : 设置包属性值
* Input        : PkgXor-报文与运营商编码不异或标志: 0-不异或 1-异或
*                NeedAck-是否需要回执 0-不需回执 1-需要回执
*                PkgType-帧类型 0-命令帧 1-应答帧
*                Dir-上下行标识 0-下行 1-上行
* Output       : 属性值
* Others       : 无
************************************************************************************************/
PKG_PROPERTY DataHandle_SetPkgProperty(bool PkgXor, bool NeedAck, bool PkgType, bool Dir)
{
    PKG_PROPERTY pkgProp;

    pkgProp.Content = 0;
    pkgProp.PkgXor = PkgXor;//不在判断异或标志，将此bit变换为 crc8 和 crc16 的判断标志位。
    pkgProp.NeedAck = NeedAck;
    pkgProp.Encrypt = 0;//Concentrator.Param.DataEncryptCtrl;
    pkgProp.PkgType = PkgType;
    pkgProp.Direction = Dir;
    return pkgProp;
}

/************************************************************************************************
* Function Name: DataHandle_SetPkgPath
* Decription   : 设置数据包的路径
* Input        : DataFrmPtr-数据指针
*                ReversePath-是否需要翻转路径
* Output       : 无
* Others       : 无
************************************************************************************************/
void DataHandle_SetPkgPath(DATA_FRAME_STRUCT *DataFrmPtr, bool ReversePath)
{
    uint8 i, tmpBuf[LONG_ADDR_SIZE];

    if (0 == memcmp(BroadcastAddrIn, DataFrmPtr->Route[DataFrmPtr->RouteInfo.CurPos], LONG_ADDR_SIZE)) {
        memcpy(DataFrmPtr->Route[DataFrmPtr->RouteInfo.CurPos], Concentrator.LongAddr, LONG_ADDR_SIZE);
    }
    // 路径是否翻转处理
    if (REVERSED == ReversePath) {
        DataFrmPtr->RouteInfo.CurPos = DataFrmPtr->RouteInfo.Level - 1 - DataFrmPtr->RouteInfo.CurPos;
        for (i = 0; i < DataFrmPtr->RouteInfo.Level / 2; i++) {
            memcpy(tmpBuf, DataFrmPtr->Route[i], LONG_ADDR_SIZE);
            memcpy(DataFrmPtr->Route[i], DataFrmPtr->Route[DataFrmPtr->RouteInfo.Level - 1 - i], LONG_ADDR_SIZE);
            memcpy(DataFrmPtr->Route[DataFrmPtr->RouteInfo.Level - 1 - i], tmpBuf, LONG_ADDR_SIZE);
        }
    }
}

/************************************************************************************************
* Function Name: DataHandle_ExtractData
* Decription   : 按协议提取出数据并检验数据的正确性
* Input        : BufPtr-原数据指针
* Output       : 成功或错误说明
* Others       : 注意-成功调用此函数后BufPtr指向提取数据后的内存
************************************************************************************************/
EXTRACT_DATA_RESULT DataHandle_ExtractData(uint8 *BufPtr)
{
    uint8 i, *msg;
    uint16 tmp;
    PORT_BUF_FORMAT *portBufPtr;
    DATA_FRAME_STRUCT *dataFrmPtr;

    // 按协议格式提取相应的数据
    portBufPtr = (PORT_BUF_FORMAT *)BufPtr;
    if (FALSE == portBufPtr->Property.FilterDone) {
        return Error_Data;
    }
    // 申请一个内存用于存放提取后的数据
    if ((void *)0 == (msg = OSMemGetOpt(LargeMemoryPtr, 10, TIME_DELAY_MS(50)))) {
        return Error_GetMem;
    }
    dataFrmPtr = (DATA_FRAME_STRUCT *)msg;
    dataFrmPtr->PortNo = portBufPtr->Property.PortNo;
    dataFrmPtr->PkgLength = ((uint16 *)portBufPtr->Buffer)[0] & 0x03FF;
    dataFrmPtr->PkgProp.Content = portBufPtr->Buffer[2];
    dataFrmPtr->PkgSn = portBufPtr->Buffer[3];
    dataFrmPtr->Command = (COMMAND_TYPE)(portBufPtr->Buffer[4]);
    dataFrmPtr->DeviceType = portBufPtr->Buffer[5];
    dataFrmPtr->Life_Ack.Content = portBufPtr->Buffer[6];
    dataFrmPtr->RouteInfo.Content = portBufPtr->Buffer[7];
	memset(dataFrmPtr->Route[0], 0, (MAX_ROUTER_NUM+1)*LONG_ADDR_SIZE);
    for (i = 0; i < dataFrmPtr->RouteInfo.Level && i < MAX_ROUTER_NUM; i++) {
        memcpy(dataFrmPtr->Route[i], &portBufPtr->Buffer[8 + LONG_ADDR_SIZE * i], LONG_ADDR_SIZE);
    }

	if( XOR_CRC16 == dataFrmPtr->PkgProp.PkgXor){
		// crc16,低字节在前
		dataFrmPtr->DownRssi = *(portBufPtr->Buffer + dataFrmPtr->PkgLength- 5);
		dataFrmPtr->UpRssi = *(portBufPtr->Buffer + dataFrmPtr->PkgLength - 4);
		dataFrmPtr->Crc16 = ((portBufPtr->Buffer[dataFrmPtr->PkgLength - 2] << 8)&0xff00)|(portBufPtr->Buffer[dataFrmPtr->PkgLength - 3]&0xFF);
		tmp = LONG_ADDR_SIZE * dataFrmPtr->RouteInfo.Level + DATA_FIXED_AREA_LENGTH_CRC16;

		if (dataFrmPtr->PkgLength < tmp || dataFrmPtr->PkgLength > MEM_LARGE_BLOCK_LEN - 1) {
			OSMemPut(LargeMemoryPtr, msg);
			return Error_DataLength;
		}
		dataFrmPtr->DataLen = dataFrmPtr->PkgLength - tmp;
		if (dataFrmPtr->DataLen < MEM_LARGE_BLOCK_LEN - sizeof(DATA_FRAME_STRUCT)) {
			memcpy(dataFrmPtr->DataBuf, portBufPtr->Buffer + 8 + LONG_ADDR_SIZE * dataFrmPtr->RouteInfo.Level, dataFrmPtr->DataLen);
		} else {
			OSMemPut(LargeMemoryPtr, msg);
			return Error_DataOverFlow;
		}

		// 检查Crc16是否正确
		if (dataFrmPtr->Crc16 != CalCrc16(portBufPtr->Buffer, dataFrmPtr->PkgLength - 3) || portBufPtr->Length < dataFrmPtr->PkgLength) {
			OSMemPut(LargeMemoryPtr, msg);
			return Error_DataCrcCheck;
		}
	} else {
		// crc8
		dataFrmPtr->DownRssi = *(portBufPtr->Buffer + dataFrmPtr->PkgLength- 4);
		dataFrmPtr->UpRssi = *(portBufPtr->Buffer + dataFrmPtr->PkgLength - 3);
		dataFrmPtr->Crc8 = *(portBufPtr->Buffer + dataFrmPtr->PkgLength - 2);
		tmp = LONG_ADDR_SIZE * dataFrmPtr->RouteInfo.Level + DATA_FIXED_AREA_LENGTH_CRC8;
		if (dataFrmPtr->PkgLength < tmp || dataFrmPtr->PkgLength > MEM_LARGE_BLOCK_LEN - 1) {
			OSMemPut(LargeMemoryPtr, msg);
			return Error_DataLength;
		}
		dataFrmPtr->DataLen = dataFrmPtr->PkgLength - tmp;
		if (dataFrmPtr->DataLen < MEM_LARGE_BLOCK_LEN - sizeof(DATA_FRAME_STRUCT)) {
			memcpy(dataFrmPtr->DataBuf, portBufPtr->Buffer + 8 + LONG_ADDR_SIZE * dataFrmPtr->RouteInfo.Level, dataFrmPtr->DataLen);
		} else {
			OSMemPut(LargeMemoryPtr, msg);
			return Error_DataOverFlow;
		}

		// 检查Crc8是否正确
		if (dataFrmPtr->Crc8 != CalCrc8(portBufPtr->Buffer, dataFrmPtr->PkgLength - 2) || portBufPtr->Length < dataFrmPtr->PkgLength) {
			OSMemPut(LargeMemoryPtr, msg);
			return Error_DataCrcCheck;
		}
	}

    // 检查结束符是否是 0x16
    if ( 0x16 != *(portBufPtr->Buffer + dataFrmPtr->PkgLength - 1)) {
        OSMemPut(LargeMemoryPtr, msg);
        return Error_Data;
    }

    // 检查是否为广播地址或本机地址
    dataFrmPtr->RouteInfo.CurPos += 1;
    if ((0 == memcmp(Concentrator.LongAddr, dataFrmPtr->Route[dataFrmPtr->RouteInfo.CurPos], LONG_ADDR_SIZE) ||
        0 == memcmp(BroadcastAddrIn, dataFrmPtr->Route[dataFrmPtr->RouteInfo.CurPos], LONG_ADDR_SIZE)) &&
        dataFrmPtr->RouteInfo.CurPos < dataFrmPtr->RouteInfo.Level) {
        memcpy(BufPtr, msg, MEM_LARGE_BLOCK_LEN);
        OSMemPut(LargeMemoryPtr, msg);
        return Ok_Data;
    }

    // 要进行后续处理,所以此处将提取出的数据返回
    memcpy(BufPtr, msg, MEM_LARGE_BLOCK_LEN);
    OSMemPut(LargeMemoryPtr, msg);
    return Error_DstAddress;
}


/************************************************************************************************
* Function Name: Test_DataHandle_CreateTxData
* Decription   : 创建发送数据包
* Input        : DataFrmPtr-待发送的数据
* Output       : 成功或错误
* Others       : 该函数执行完毕后会释放DataBufPtr指向的存储区,还会将路由区的地址排列翻转
************************************************************************************************/
ErrorStatus Test_DataHandle_CreateTxData(DATA_FRAME_STRUCT *DataFrmPtr, uint8 version)
{
    uint8 err;
    uint16 tmp, nodeId;
    PORT_BUF_FORMAT *txPortBufPtr;
    uint8 ackChannel = 0;

    // 先申请一个内存用于中间数据处理
    if ((void *)0 == (txPortBufPtr = OSMemGetOpt(LargeMemoryPtr, 10, TIME_DELAY_MS(50)))) {
        OSMemPut(LargeMemoryPtr, DataFrmPtr);
        return ERROR;
    }
    txPortBufPtr->Property.PortNo = DataFrmPtr->PortNo;
    txPortBufPtr->Property.FilterDone = 1;
    memcpy(txPortBufPtr->Buffer, Uart_RfTx_Filter, sizeof(Uart_RfTx_Filter));
    txPortBufPtr->Length = sizeof(Uart_RfTx_Filter);

    tmp = txPortBufPtr->Length;
	if( XOR_CRC16 == DataFrmPtr->PkgProp.PkgXor){
    	DataFrmPtr->PkgLength = DataFrmPtr->DataLen + DataFrmPtr->RouteInfo.Level * LONG_ADDR_SIZE + DATA_FIXED_AREA_LENGTH_CRC16;
	}else{
    	DataFrmPtr->PkgLength = DataFrmPtr->DataLen + DataFrmPtr->RouteInfo.Level * LONG_ADDR_SIZE + DATA_FIXED_AREA_LENGTH_CRC8;
	}
	((uint16 *)(&txPortBufPtr->Buffer[txPortBufPtr->Length]))[0] = DataFrmPtr->PkgLength;
    txPortBufPtr->Length += 2;
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = DataFrmPtr->PkgProp.Content;         // 报文标识
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = DataFrmPtr->PkgSn;                   // 任务号
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = DataFrmPtr->Command;                 // 命令字
    // 为了和已出货的第一批表兼容
    if (0 == DataFrmPtr->Life_Ack.AckChannel) {
        txPortBufPtr->Buffer[txPortBufPtr->Length++] = Dev_Server;                      // 设备类型
    } else {
        txPortBufPtr->Buffer[txPortBufPtr->Length++] = DataFrmPtr->DeviceType;          // 设备类型
    }
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = DataFrmPtr->Life_Ack.Content;        // 生命周期和应答信道
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = DataFrmPtr->RouteInfo.Content;       // 路径信息
    memcpy(&txPortBufPtr->Buffer[txPortBufPtr->Length], DataFrmPtr->Route[0], DataFrmPtr->RouteInfo.Level * LONG_ADDR_SIZE);
    txPortBufPtr->Length += DataFrmPtr->RouteInfo.Level * LONG_ADDR_SIZE;
    memcpy(txPortBufPtr->Buffer + txPortBufPtr->Length, DataFrmPtr->DataBuf, DataFrmPtr->DataLen);      // 数据域
    txPortBufPtr->Length += DataFrmPtr->DataLen;
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = 0x55;                                // 下行信号强度
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = 0xAA;                                // 上行信号强度
	if( XOR_CRC16 == DataFrmPtr->PkgProp.PkgXor){
		// crc16校验，低字节在前
	    uint16 crc16 = CalCrc16((uint8 *)(&txPortBufPtr->Buffer[tmp]), txPortBufPtr->Length-tmp);
	    txPortBufPtr->Buffer[txPortBufPtr->Length++] = (uint8)((crc16)&0xFF);
	    txPortBufPtr->Buffer[txPortBufPtr->Length++] = (uint8)((crc16 >> 8)&0xFF);
	} else {
		txPortBufPtr->Buffer[txPortBufPtr->Length] = CalCrc8((uint8 *)(&txPortBufPtr->Buffer[tmp]), txPortBufPtr->Length - tmp);	 // Crc8校验
		txPortBufPtr->Length += 1;
	}
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = TAILBYTE;

	nodeId = Data_FindNodeId(0, DataFrmPtr->Route[DataFrmPtr->RouteInfo.Level - 1]);

    txPortBufPtr->Buffer[txPortBufPtr->Length++] = 0x00;
    // 为了和已出货的第一批表兼容
    if (0 == DataFrmPtr->Life_Ack.AckChannel) {
        if ( DataFrmPtr->RouteInfo.Level > 0x2 && version > 0x3){
            // 多级路由情况下 , 且版本号高于 3.
            ackChannel = (DataFrmPtr->Route[DataFrmPtr->RouteInfo.CurPos+1][LONG_ADDR_SIZE-1] & 0x0F)/2 + 0x0B;
            txPortBufPtr->Buffer[txPortBufPtr->Length++] = ackChannel;
        } else {
            txPortBufPtr->Buffer[txPortBufPtr->Length++] = (DEFAULT_RX_CHANNEL + CHANNEL_OFFSET);
        }
		txPortBufPtr->Buffer[txPortBufPtr->Length++] = (DEFAULT_RX_CHANNEL + CHANNEL_OFFSET);
    } else {
        if ( DataFrmPtr->RouteInfo.Level > 0x2 && version > 0x3 && SubNodes[nodeId].AutoChannelSwitch == TRUE ){
            // 多级路由情况下 , 且版本号高于 3.
            ackChannel = (DataFrmPtr->Route[DataFrmPtr->RouteInfo.CurPos+1][LONG_ADDR_SIZE-1] & 0x0F)/2 + 0x0B;
            txPortBufPtr->Buffer[txPortBufPtr->Length++] = ackChannel;
			txPortBufPtr->Buffer[txPortBufPtr->Length++] = DataFrmPtr->Route[DataFrmPtr->RouteInfo.CurPos+1][LONG_ADDR_SIZE-1] & 0x0F;
        } else if( DataFrmPtr->RouteInfo.Level > 0x2 && version > 0x3 && SubNodes[nodeId].AutoChannelSwitch == FALSE ){
            ackChannel = (DataFrmPtr->Route[DataFrmPtr->RouteInfo.CurPos+1][LONG_ADDR_SIZE-1] & 0x0F)/2 + 0x0B;
            txPortBufPtr->Buffer[txPortBufPtr->Length++] = ackChannel;
			txPortBufPtr->Buffer[txPortBufPtr->Length++] = DEFAULT_TX_CHANNEL;
		} else {
            txPortBufPtr->Buffer[txPortBufPtr->Length++] = DataFrmPtr->Life_Ack.AckChannel;
			txPortBufPtr->Buffer[txPortBufPtr->Length++] = (DEFAULT_RX_CHANNEL + CHANNEL_OFFSET);
		}
    }

    OSMemPut(LargeMemoryPtr, DataFrmPtr);
    if (Uart_Gprs == txPortBufPtr->Property.PortNo) {
        if (FALSE == Gprs.Online ||
            OS_ERR_NONE != OSMboxPost(Gprs.MboxTx, txPortBufPtr)) {
            OSMemPut(LargeMemoryPtr, txPortBufPtr);
            return ERROR;
        } else {
            OSFlagPost(GlobalEventFlag, FLAG_GPRS_TX, OS_FLAG_SET, &err);
            return SUCCESS;
        }
    } else {
        if (txPortBufPtr->Property.PortNo < Port_Total &&
            OS_ERR_NONE != OSMboxPost(SerialPort.Port[txPortBufPtr->Property.PortNo].MboxTx, txPortBufPtr)) {
            OSMemPut(LargeMemoryPtr, txPortBufPtr);
            return ERROR;
        } else {
            OSFlagPost(GlobalEventFlag, (OS_FLAGS)(1 << txPortBufPtr->Property.PortNo + SERIALPORT_TX_FLAG_OFFSET), OS_FLAG_SET, &err);
            return SUCCESS;
        }
    }
}


/************************************************************************************************
* Function Name: DataHandle_CreateTxData
* Decription   : 创建发送数据包
* Input        : DataFrmPtr-待发送的数据
* Output       : 成功或错误
* Others       : 该函数执行完毕后会释放DataBufPtr指向的存储区,还会将路由区的地址排列翻转
************************************************************************************************/
ErrorStatus DataHandle_CreateTxData(DATA_FRAME_STRUCT *DataFrmPtr, uint8 version)
{
    uint8 err;
    uint16 tmp, nodeId;
    PORT_BUF_FORMAT *txPortBufPtr;
    uint8 ackChannel = 0;
	uint8 *gprsTxBufPtr;

    // 先申请一个内存用于中间数据处理
    if ((void *)0 == (txPortBufPtr = OSMemGetOpt(LargeMemoryPtr, 10, TIME_DELAY_MS(50)))) {
        OSMemPut(LargeMemoryPtr, DataFrmPtr);
        return ERROR;
    }
    txPortBufPtr->Property.PortNo = DataFrmPtr->PortNo;
    txPortBufPtr->Property.FilterDone = 1;
    memcpy(txPortBufPtr->Buffer, Uart_RfTx_Filter, sizeof(Uart_RfTx_Filter));
    txPortBufPtr->Length = sizeof(Uart_RfTx_Filter);

    tmp = txPortBufPtr->Length;
	if( XOR_CRC16 == DataFrmPtr->PkgProp.PkgXor){
    	DataFrmPtr->PkgLength = DataFrmPtr->DataLen + DataFrmPtr->RouteInfo.Level * LONG_ADDR_SIZE + DATA_FIXED_AREA_LENGTH_CRC16;
	}else{
    	DataFrmPtr->PkgLength = DataFrmPtr->DataLen + DataFrmPtr->RouteInfo.Level * LONG_ADDR_SIZE + DATA_FIXED_AREA_LENGTH_CRC8;
	}
    ((uint16 *)(&txPortBufPtr->Buffer[txPortBufPtr->Length]))[0] = DataFrmPtr->PkgLength;
    txPortBufPtr->Length += 2;
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = DataFrmPtr->PkgProp.Content;         // 报文标识
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = DataFrmPtr->PkgSn;                   // 任务号
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = DataFrmPtr->Command;                 // 命令字
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = DataFrmPtr->DeviceType;          	// 设备类型
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = DataFrmPtr->Life_Ack.Content;        // 生命周期和应答信道
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = DataFrmPtr->RouteInfo.Content;       // 路径信息
    memcpy(&txPortBufPtr->Buffer[txPortBufPtr->Length], DataFrmPtr->Route[0], DataFrmPtr->RouteInfo.Level * LONG_ADDR_SIZE);
    txPortBufPtr->Length += DataFrmPtr->RouteInfo.Level * LONG_ADDR_SIZE;
    memcpy(txPortBufPtr->Buffer + txPortBufPtr->Length, DataFrmPtr->DataBuf, DataFrmPtr->DataLen);      // 数据域
    txPortBufPtr->Length += DataFrmPtr->DataLen;
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = 0x55;                                // 下行信号强度
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = 0xAA;                                // 上行信号强度
	if( XOR_CRC16 == DataFrmPtr->PkgProp.PkgXor ){
		// crc16校验，低字节在前
	    uint16 crc16 = CalCrc16((uint8 *)(&txPortBufPtr->Buffer[tmp]), txPortBufPtr->Length-tmp);
	    txPortBufPtr->Buffer[txPortBufPtr->Length++] = (uint8)((crc16)&0xFF);
	    txPortBufPtr->Buffer[txPortBufPtr->Length++] = (uint8)((crc16 >> 8)&0xFF);
	} else {
		txPortBufPtr->Buffer[txPortBufPtr->Length] = CalCrc8((uint8 *)(&txPortBufPtr->Buffer[tmp]), txPortBufPtr->Length - tmp);	 // Crc8校验
		txPortBufPtr->Length += 1;
	}
    txPortBufPtr->Buffer[txPortBufPtr->Length++] = TAILBYTE;

	nodeId = Data_FindNodeId(0, DataFrmPtr->Route[DataFrmPtr->RouteInfo.Level - 1]);

    if (CMD_PKG == DataFrmPtr->PkgProp.PkgType) {
		// 表端不休眠，不需要唤醒导言
        //txPortBufPtr->Buffer[txPortBufPtr->Length++] = 0x1E;
        txPortBufPtr->Buffer[txPortBufPtr->Length++] = 0x00;
        if (DATA_CENTER_ID == nodeId || NULL_U16_ID == nodeId) {
            if ( version > 0x3 && SubNodes[nodeId].AutoChannelSwitch == TRUE ){
                // 多级路由情况下
                ackChannel = DataFrmPtr->Route[DataFrmPtr->RouteInfo.CurPos+1][LONG_ADDR_SIZE-1] & 0xF;
                txPortBufPtr->Buffer[txPortBufPtr->Length++] = ackChannel;
            }else{
                txPortBufPtr->Buffer[txPortBufPtr->Length++] = DEFAULT_TX_CHANNEL;
            }
        } else {
            if ( (version > 0x3 && SubNodes[nodeId].AutoChannelSwitch == TRUE) || version == 0x44 ){
                // 多级路由情况下
                ackChannel = DataFrmPtr->Route[DataFrmPtr->RouteInfo.CurPos+1][LONG_ADDR_SIZE-1] & 0xF;
                txPortBufPtr->Buffer[txPortBufPtr->Length++] = ackChannel;
            }else{
                txPortBufPtr->Buffer[txPortBufPtr->Length++] = SubNodes[nodeId].RxChannel;
            }
        }
        txPortBufPtr->Buffer[txPortBufPtr->Length++] = (DEFAULT_RX_CHANNEL + CHANNEL_OFFSET);
    } else {
        txPortBufPtr->Buffer[txPortBufPtr->Length++] = 0x00;
        // 为了和已出货的第一批表兼容
        if (0 == DataFrmPtr->Life_Ack.AckChannel) {
            if ( DataFrmPtr->RouteInfo.Level > 0x2 && version > 0x3){
                // 多级路由情况下 , 且版本号高于 3.
                ackChannel = (DataFrmPtr->Route[DataFrmPtr->RouteInfo.CurPos+1][LONG_ADDR_SIZE-1] & 0x0F)/2 + 0x0B;
                txPortBufPtr->Buffer[txPortBufPtr->Length++] = ackChannel;
            } else {
                txPortBufPtr->Buffer[txPortBufPtr->Length++] = (DEFAULT_RX_CHANNEL + CHANNEL_OFFSET);
            }
        } else {
            if ( DataFrmPtr->RouteInfo.Level > 0x2 && version > 0x3 && SubNodes[nodeId].AutoChannelSwitch == TRUE ){
                // 多级路由情况下 , 且版本号高于 3.
                ackChannel = (DataFrmPtr->Route[DataFrmPtr->RouteInfo.CurPos+1][LONG_ADDR_SIZE-1] & 0x0F)/2 + 0x0B;
                txPortBufPtr->Buffer[txPortBufPtr->Length++] = ackChannel;
            } else {
                txPortBufPtr->Buffer[txPortBufPtr->Length++] = DataFrmPtr->Life_Ack.AckChannel;
            }
        }
        txPortBufPtr->Buffer[txPortBufPtr->Length++] = (DEFAULT_RX_CHANNEL + CHANNEL_OFFSET);
    }

    OSMemPut(LargeMemoryPtr, DataFrmPtr);


    if (Uart_Gprs == txPortBufPtr->Property.PortNo) {
        if (FALSE == Gprs.Online || OS_ERR_NONE != OSMboxPost(Gprs.MboxTx, txPortBufPtr)) {
			if ((void *)0 == (gprsTxBufPtr = OSMemGetOpt(GprsMemoryPtr, 10, TIME_DELAY_MS(50)))) {
				OSMemPut(LargeMemoryPtr, txPortBufPtr);
				//Gprs_OutputDebugMsg(TRUE, "GprsMemoryPtr get error\n");
				return ERROR;
			}
			// 增加一个头作为校验，防止反复发送。
			gprsTxBufPtr[0] = GPRS_DELAY_UP_CRC0;
			gprsTxBufPtr[1] = GPRS_DELAY_UP_CRC1;
			gprsTxBufPtr[2] = GPRS_DELAY_UP_CRC2;
			gprsTxBufPtr[3] = GPRS_DELAY_UP_CRC3;

			// 将需要发送的数据放置到校验后
			memcpy(&gprsTxBufPtr[4], txPortBufPtr, MEM_GPRS_BLOCK_LEN - 4);
			// 延时发射时间, 单位秒(s)
			GprsDelayDataUpTimer = 10;

			OSMemPut(LargeMemoryPtr, txPortBufPtr);
            return ERROR;
        } else {
            OSFlagPost(GlobalEventFlag, FLAG_GPRS_TX, OS_FLAG_SET, &err);
            return SUCCESS;
        }
    } else {
        if (txPortBufPtr->Property.PortNo < Port_Total &&
            OS_ERR_NONE != OSMboxPost(SerialPort.Port[txPortBufPtr->Property.PortNo].MboxTx, txPortBufPtr)) {
            OSMemPut(LargeMemoryPtr, txPortBufPtr);
            return ERROR;
        } else {
            OSFlagPost(GlobalEventFlag, (OS_FLAGS)(1 << txPortBufPtr->Property.PortNo + SERIALPORT_TX_FLAG_OFFSET), OS_FLAG_SET, &err);
            return SUCCESS;
        }
    }
}

/************************************************************************************************
* Function Name: DataHandle_DataDelaySaveProc
* Decription   : 数据延时保存处理函数
* Input        : 无
* Output       : 无
* Others       : 当多组数据需要保存时启动一次延时保存,以延长Flash的寿命
************************************************************************************************/
void DataHandle_DataDelaySaveProc(void)
{
    SubNodesSaveDelayTimer = 0;
    Flash_SaveSubNodesInfo();
    Flash_SaveConcentratorInfo();
}

/************************************************************************************************
* Function Name: DataHandle_OutputMonitorMsg
* Decription   : 集中器主动输出监控信息
* Input        : MsgType-信息的类型,MsgPtr-输出信息指针,MsgLen-信息的长度
* Output       : 无
* Others       : 无
************************************************************************************************/
void DataHandle_OutputMonitorMsg(MONITOR_MSG_TYPE MsgType, uint8 *MsgPtr, uint16 MsgLen)
{
    DATA_FRAME_STRUCT *dataFrmPtr;

    if ((void *)0 == (dataFrmPtr = OSMemGetOpt(LargeMemoryPtr, 20, TIME_DELAY_MS(50)))) {
        return;
    }
    dataFrmPtr->PortNo = MonitorPort;
    dataFrmPtr->PkgProp = DataHandle_SetPkgProperty(XOR_CRC8, NONE_ACK, CMD_PKG, UP_DIR);
    dataFrmPtr->PkgSn = PkgNo++;
    dataFrmPtr->Command = Output_Monitior_Msg_Cmd;
    dataFrmPtr->DeviceType = Dev_Concentrator;
    dataFrmPtr->Life_Ack.Content = 0x0F;
    dataFrmPtr->RouteInfo.CurPos = 0;
    dataFrmPtr->RouteInfo.Level = 2;
    memcpy(dataFrmPtr->Route[0], Concentrator.LongAddr, LONG_ADDR_SIZE);
    memcpy(dataFrmPtr->Route[1], BroadcastAddrOut, LONG_ADDR_SIZE);
    dataFrmPtr->DataBuf[0] = MsgType;
    memcpy(&dataFrmPtr->DataBuf[1], MsgPtr, MsgLen);
    dataFrmPtr->DataLen = 1 + MsgLen;
    DataHandle_SetPkgPath(dataFrmPtr, UNREVERSED);
    DataHandle_CreateTxData(dataFrmPtr, NULL);
    return;
}

/************************************************************************************************
* Function Name: DataHandle_ReadMeterCmdLoadProc
* Decription   : 下发命令读取处理函数
* Input        : DataFrmPtr-指向数据帧的指针
* Output       : 无
* Others       : 下行:长地址(6)
*                上行:操作状态(1)+长地址(6)+下发命令数据(N)
************************************************************************************************/
void DataHandle_ReadMeterCmdLoadProc(DATA_FRAME_STRUCT *DataFrmPtr)
{
    uint8 i, dataLen, *dataBufPtr;
    uint16 nodeId;

    dataLen = 0;
    nodeId = Data_FindNodeId(0, DataFrmPtr->DataBuf);
    for (i = LONG_ADDR_SIZE; i > 0; i--) {
        DataFrmPtr->DataBuf[i] = DataFrmPtr->DataBuf[i - 1];
    }
    dataBufPtr = DataFrmPtr->DataBuf + 1 + LONG_ADDR_SIZE;

    // 没有此节点或请求的数据类型与集中器的工作模式不一致或申请内存失败等情况
    if (NULL_U16_ID == nodeId) {
        DataFrmPtr->DataBuf[0] = OP_ObjectNotExist;
    } else if ((SubNodes[nodeId].DevType & 0xF0) == 0xF0) {
        DataFrmPtr->DataBuf[0] = OP_ParameterError;
    } else {
    	DataFrmPtr->DataBuf[0] = OP_Succeed;
        dataBufPtr[0] = SubNodes[nodeId].CmdProp.Content;
        memcpy(&dataBufPtr[1], &SubNodes[nodeId].CmdData, sizeof(CMD_DATA));
        dataLen = 1 + sizeof(CMD_DATA); // 1 + 8
        dataBufPtr[dataLen++] = SubNodes[nodeId].AutoChannelSwitch;
		dataBufPtr[dataLen++] = SubNodes[nodeId].RxChannel;
		dataBufPtr[dataLen++] = SubNodes[nodeId].TxChannel;
		dataBufPtr[dataLen++] = SubNodes[nodeId].RxMeterVersion;
	}
    DataFrmPtr->DataLen = 1 + LONG_ADDR_SIZE + dataLen;
}

/************************************************************************************************
* Function Name: DataHandle_ReadMeterCmdBatchLoadProc
* Decription   : 下发命令批量读取处理函数
* Input        : DataFrmPtr-指向数据帧的指针
* Output       : 无
* Others       : 下行:起始节点序号(2)+读取的数量(1)
*                上行:节点总数量(2)+本次返回的数量N(1)+N*(操作状态(1)+长地址(6)+下发命令数据(M))
************************************************************************************************/
void DataHandle_ReadMeterCmdBatchLoadProc(DATA_FRAME_STRUCT *DataFrmPtr)
{
    uint8 readCount, ackCount, dataLen, blockLen, *dataBufPtr, *opStatusPtr;
    uint16 nodeId, startId, totalNodes;

	dataLen = 1 + sizeof(CMD_DATA); // 1 + 8

    startId = ((uint16 *)DataFrmPtr->DataBuf)[0];
    readCount = DataFrmPtr->DataBuf[2];
    ackCount = 0;
    totalNodes = 0;
    dataBufPtr = DataFrmPtr->DataBuf + 3;
    blockLen = dataLen + 1 + LONG_ADDR_SIZE;
    for (nodeId = 0; nodeId < Concentrator.MaxNodeId; nodeId++) {
        if (0 == memcmp(SubNodes[nodeId].LongAddr, NullAddress, LONG_ADDR_SIZE)) {
            continue;
        } else if ((SubNodes[nodeId].DevType & 0xF0) == 0xF0) {
            continue;
        } else {
            totalNodes++;
            if (totalNodes > startId && ackCount < readCount && dataBufPtr - DataFrmPtr->DataBuf + blockLen < GPRS_DATA_MAX_DATA) {
                ackCount++;
                opStatusPtr = dataBufPtr++;
                memcpy(dataBufPtr, SubNodes[nodeId].LongAddr, LONG_ADDR_SIZE);
                dataBufPtr += LONG_ADDR_SIZE;
                *opStatusPtr = OP_Succeed;
                memcpy(dataBufPtr, &SubNodes[nodeId].CmdProp.Content, dataLen);
                dataBufPtr += dataLen;
				*dataBufPtr++ = SubNodes[nodeId].AutoChannelSwitch;
				*dataBufPtr++ = SubNodes[nodeId].RxChannel;
				*dataBufPtr++ = SubNodes[nodeId].TxChannel;
				*dataBufPtr++ = SubNodes[nodeId].RxMeterVersion;
            }
        }
    }
    DataFrmPtr->DataBuf[0] = (uint8)totalNodes;
    DataFrmPtr->DataBuf[1] = (uint8)(totalNodes >> 8);
    DataFrmPtr->DataBuf[2] = ackCount;
    DataFrmPtr->DataLen = dataBufPtr - DataFrmPtr->DataBuf;
    return;
}


/************************************************************************************************
* Function Name: DataHandle_DataCommandResultTask
* Decription   : 命令下发结果处理任务
* Input        : p_arg-保存原来数据的指针
* Output       : 无
************************************************************************************************/
void DataHandle_DataCommandResultTask(void *p_arg)
{
    uint8 err;
    uint32 waitAckTime, startTime;
    DATA_HANDLE_TASK *taskPtr;
    DATA_FRAME_STRUCT *rxDataFrmPtr;
    uint8 meterDataLen, bufLen = 0;
    uint16 nodeId;
    METER_DATA_SAVE_FORMAT *meterBufPtr;

    taskPtr = (DATA_HANDLE_TASK *)p_arg;

    TaskRunStatus.DataForward = TRUE;
    startTime = Timer1ms;
    waitAckTime = (taskPtr->RouteLevel - 1) * DELAYTIME_ONE_LAYER * 2;
    while (waitAckTime > 0) {
        rxDataFrmPtr = OSMboxPend(taskPtr->Mbox, TIME_DELAY_MS(waitAckTime), &err);
        if ((void *)0 != rxDataFrmPtr) {
		// 数据域第二字节为操作结果
            if( 0xAA == rxDataFrmPtr->DataBuf[bufLen+1] ){
                nodeId = Data_FindNodeId(0, rxDataFrmPtr->Route[0]);
                if (NULL_U16_ID == nodeId ) {
                    OSMemPut(LargeMemoryPtr, rxDataFrmPtr);
                    waitAckTime = (Timer1ms > startTime) ? (Timer1ms - startTime) : 0;
                    continue;
                }
                // 再申请一个内存,用于读取Eeprom中的数据
                if ((void *)0 == (meterBufPtr = OSMemGetOpt(SmallMemoryPtr, 10, TIME_DELAY_MS(50)))) {
                    OSMemPut(LargeMemoryPtr, rxDataFrmPtr);
                    waitAckTime = (Timer1ms > startTime) ? (Timer1ms - startTime) : 0;
                    continue;
                }
                meterDataLen = sizeof(METER_DATA_SAVE_FORMAT);
                Eeprom_ReadWrite((uint8 *)meterBufPtr, nodeId * NODE_INFO_SIZE, meterDataLen, READ_ATTR);
                if (0 != memcmp(SubNodes[nodeId].LongAddr, meterBufPtr->Address, LONG_ADDR_SIZE)) {
                    Data_MeterDataInit(meterBufPtr, nodeId, meterDataLen);
                }
				meterBufPtr->RxMeterVersion = SubNodes[nodeId].RxMeterVersion;
				// 设置信道 : 操作命令(0x1) + 操作结果(0xAA或0xAB) + 信道号(低4位为表端主动上报信道，高4位为当前通信信道)
                if( Meter_ACK_Set_Channel == rxDataFrmPtr->DataBuf[bufLen] )
                {// 设置信道
                	if( (SubNodes[nodeId].CmdProp.SetChannel != 0) &&
						((SubNodes[nodeId].CmdData.SetChannel&0x7F) == (rxDataFrmPtr->DataBuf[bufLen+2]&0xF)))
                	{
                		Concentrator.SecondChannel = SubNodes[nodeId].CmdData.SetChannel&0x7F;
						// 当检测到表端自动信道已经打开，并且此时正在设置信道。则手动修改 Eprom 中保存的 RX/TX 内容
						if(SubNodes[nodeId].AutoChannelSwitch == TRUE )
						{
							meterDataLen = sizeof(METER_DATA_SAVE_FORMAT);
							Eeprom_ReadWrite((uint8 *)meterBufPtr, nodeId * NODE_INFO_SIZE, meterDataLen, READ_ATTR);
							SubNodes[nodeId].AutoChannelSwitch = TRUE;
							SubNodes[nodeId].RxChannel = SubNodes[nodeId].LongAddr[LONG_ADDR_SIZE-1] & 0xF;
							SubNodes[nodeId].TxChannel = Concentrator.SecondChannel;
							if(Concentrator.SaveSecondChannel != Concentrator.SecondChannel){
								ModifyScanChannel = 5;
						    }
							meterBufPtr->RxChannel = SubNodes[nodeId].RxChannel;
							meterBufPtr->TxChannel = SubNodes[nodeId].TxChannel;
						}
						SubNodes[nodeId].CmdProp.SetChannel = 0;
						SubNodes[nodeId].CmdData.SetChannel = 0;
						meterBufPtr->CmdProp.SetChannel = 0;
						meterBufPtr->CmdData.SetChannel = 0;
						Eeprom_ReadWrite((uint8 *)meterBufPtr, nodeId * NODE_INFO_SIZE, meterDataLen, WRITE_ATTR);
					}
                }
				// 打开自动信道 : 操作命令(0x2) + 操作结果(0xAA或0xAB) + 2字节表端状态(第二字节 bit0 为开关自动信道)
                else if( Meter_ACK_Open_Auto_Channel == rxDataFrmPtr->DataBuf[bufLen] )
                {// 打开自动信道设置
                	if( (SubNodes[nodeId].CmdProp.AutoChannel != 0) &&
						(((SubNodes[nodeId].CmdData.AutoChannel>>7)&0x1) == ((rxDataFrmPtr->DataBuf[bufLen+3]>>0)&0x1)))
					{
	                    if(SubNodes[nodeId].CmdData.AutoChannel == 0x80){
	                       // 当自动信道打开时，表端接收信道是表号尾号的最后一位。发射信道是已经设置好的信道，集中器暂不可知（或者集中器统一设置）。
	                       SubNodes[nodeId].AutoChannelSwitch = TRUE;
	                       SubNodes[nodeId].RxChannel = SubNodes[nodeId].LongAddr[LONG_ADDR_SIZE-1] & 0xF;
	                       SubNodes[nodeId].TxChannel = Concentrator.SecondChannel;
						   if(Concentrator.SaveSecondChannel != Concentrator.SecondChannel){
							   ModifyScanChannel = 5;
						   }
	                    }else{
	                       SubNodes[nodeId].AutoChannelSwitch = FALSE;
	                       SubNodes[nodeId].RxChannel = DEFAULT_TX_CHANNEL;
	                       SubNodes[nodeId].TxChannel = DEFAULT_TX_CHANNEL;
	                    }

	                    meterDataLen = sizeof(METER_DATA_SAVE_FORMAT);
	                    Eeprom_ReadWrite((uint8 *)meterBufPtr, nodeId * NODE_INFO_SIZE, meterDataLen, READ_ATTR);
						SubNodes[nodeId].CmdProp.AutoChannel = 0;
						SubNodes[nodeId].CmdData.AutoChannel = 0;
						meterBufPtr->CmdProp.AutoChannel = 0;
						meterBufPtr->CmdData.AutoChannel = 0;
						meterBufPtr->RxChannel = SubNodes[nodeId].RxChannel;
						meterBufPtr->TxChannel = SubNodes[nodeId].TxChannel;
						meterBufPtr->AutoChannelSwitch = SubNodes[nodeId].AutoChannelSwitch;
						Eeprom_ReadWrite((uint8 *)meterBufPtr, nodeId * NODE_INFO_SIZE, meterDataLen, WRITE_ATTR);
					}
                }
				// 阀控 : 操作命令(0x3) + 操作结果(0xAA或0xAB) + 阀状态(1开阀，2关阀)
                else if( Meter_ACK_Control_Valve == rxDataFrmPtr->DataBuf[bufLen] )
                {// 阀控   低四位：1开阀，2关阀
					if( (SubNodes[nodeId].CmdProp.ValveCtrl != 0) &&
						(SubNodes[nodeId].CmdData.ValveCtrl == rxDataFrmPtr->DataBuf[bufLen+2]))
					{
						SubNodes[nodeId].CmdProp.ValveCtrl = 0;
						SubNodes[nodeId].CmdData.ValveCtrl = 0;
						meterBufPtr->CmdProp.ValveCtrl = 0;
						meterBufPtr->CmdData.ValveCtrl = 0;
						Eeprom_ReadWrite((uint8 *)meterBufPtr, nodeId * NODE_INFO_SIZE, meterDataLen, WRITE_ATTR);
					}
                }
				// 结算价格 : 操作命令(0x4) + 操作结果(0xAA或0xAB) + 2字节结算价格(低位在前，高位在后)
                else if( Meter_ACK_Settlement_Price == rxDataFrmPtr->DataBuf[bufLen] )
                {// 结算价格
					if( (SubNodes[nodeId].CmdProp.SettlementPrice != 0) &&
						(SubNodes[nodeId].CmdData.SettlementPriceLow == rxDataFrmPtr->DataBuf[bufLen+2]) &&
						(SubNodes[nodeId].CmdData.SettlementPriceHigh == rxDataFrmPtr->DataBuf[bufLen+3]))
					{
						SubNodes[nodeId].CmdProp.SettlementPrice = 0;
						SubNodes[nodeId].CmdData.SettlementPriceLow = 0;
						SubNodes[nodeId].CmdData.SettlementPriceHigh = 0;
						meterBufPtr->CmdProp.SettlementPrice = 0;
						meterBufPtr->CmdData.SettlementPriceLow = 0;
						meterBufPtr->CmdData.SettlementPriceHigh = 0;
						Eeprom_ReadWrite((uint8 *)meterBufPtr, nodeId * NODE_INFO_SIZE, meterDataLen, WRITE_ATTR);
					}
                }
				// 开关实时抄表 : 操作命令(0x5) + 操作结果(0xAA或0xAB) + 2字节表端状态(第二字节 bit3 为开关自动信道)
				else if( Meter_ACK_Control_RwMeter == rxDataFrmPtr->DataBuf[bufLen] )
                {// 开关实时抄表
					if( (SubNodes[nodeId].CmdProp.RealTimeMeterReading != 0) &&
						(((SubNodes[nodeId].CmdData.RealTimeMeterReading>>7)&0x1) == ((rxDataFrmPtr->DataBuf[bufLen+3]>>3)&0x1)))
					{
						SubNodes[nodeId].CmdProp.RealTimeMeterReading = 0;
						SubNodes[nodeId].CmdData.RealTimeMeterReading = 0;
						meterBufPtr->CmdProp.RealTimeMeterReading = 0;
						meterBufPtr->CmdData.RealTimeMeterReading = 0;
						Eeprom_ReadWrite((uint8 *)meterBufPtr, nodeId * NODE_INFO_SIZE, meterDataLen, WRITE_ATTR);
					}
                }
                OSMemPut(SmallMemoryPtr, meterBufPtr);
            }
			else if( 0xAB == rxDataFrmPtr->DataBuf[bufLen+1] )
			{
				Gprs_OutputDebugMsg(0, "----->>  0xAB  <<------");
			}
            OSMemPut(LargeMemoryPtr, rxDataFrmPtr);
        }
        break;
    }

    // 销毁本任务,此处必须先禁止任务调度,否则无法释放本任务占用的内存空间
    OSMboxDel(taskPtr->Mbox, OS_DEL_ALWAYS, &err);
    OSSchedLock();
    OSTaskDel(OS_PRIO_SELF);
    OSMemPut(LargeMemoryPtr, taskPtr->StkPtr);
    taskPtr->StkPtr = (void *)0;
    TaskRunStatus.DataForward = FALSE;
    OSSchedUnlock();
}



/************************************************************************************************
* Function Name: DataHandle_Syruns_ActiveReportProc
* Decription   : 神源表具主动上报数据处理函数
* Input        : DataFrmPtr-接收到的数据指针
* Output       : 后续是否需要应答处理
* Others       : 用于处理主动上报定时定量数据,冻结数据.
************************************************************************************************/
bool DataHandle_Syruns_ActiveReportProc(DATA_FRAME_STRUCT *DataFrmPtr)
{
    uint8 length, version;
    uint16 nodeId;
    DATA_HANDLE_TASK *taskPtr;
    uint8 err;
	DATA_FRAME_STRUCT *GprsDataFrmPtr;

	length = DataFrmPtr->DataLen - 1;		// 减去数据格式编号字节
	version = DataFrmPtr->DataBuf[length];	// 表版本号
	nodeId = Data_FindNodeId(0, DataFrmPtr->Route[0]);
	if (NULL_U16_ID == nodeId) {
		OSMemPut(LargeMemoryPtr, DataFrmPtr);
		return NONE_ACK;
	}

	// 如果有新信息需要更新
	if( (version != SubNodes[nodeId].RxMeterVersion) ||
		(((DataFrmPtr->DataBuf[length-1]>>4)&0xF) != SubNodes[nodeId].RxChannel) ||
		((DataFrmPtr->DataBuf[length-1]&0xF) != SubNodes[nodeId].TxChannel)){

		uint8 meterDataLen;
		METER_DATA_SAVE_FORMAT *meterBufPtr;

		SubNodes[nodeId].RxMeterVersion = version;
		SubNodes[nodeId].RxChannel = (DataFrmPtr->DataBuf[length-1]>>4)&0xF;
		SubNodes[nodeId].TxChannel = DataFrmPtr->DataBuf[length-1]&0xF;

		// 再申请一个内存,用于读取Eeprom中的数据
		if ((void *)0 == (meterBufPtr = OSMemGetOpt(SmallMemoryPtr, 10, TIME_DELAY_MS(50)))) {
			OSMemPut(LargeMemoryPtr, DataFrmPtr);
			return NONE_ACK;
		}
		meterDataLen = sizeof(METER_DATA_SAVE_FORMAT);
		Eeprom_ReadWrite((uint8 *)meterBufPtr, nodeId * NODE_INFO_SIZE, meterDataLen, READ_ATTR);
		if (0 != memcmp(SubNodes[nodeId].LongAddr, meterBufPtr->Address, LONG_ADDR_SIZE)) {
			Data_MeterDataInit(meterBufPtr, nodeId, meterDataLen);
		}
		meterBufPtr->RxMeterVersion = SubNodes[nodeId].RxMeterVersion;
		meterBufPtr->RxChannel = SubNodes[nodeId].RxChannel;
		meterBufPtr->TxChannel = SubNodes[nodeId].TxChannel;
		Eeprom_ReadWrite((uint8 *)meterBufPtr, nodeId * NODE_INFO_SIZE, meterDataLen, WRITE_ATTR);
		OSMemPut(SmallMemoryPtr, meterBufPtr);
	}


/********************************************************************************
				先申请一个内存用于处理数据上报到 gprs
********************************************************************************/
    if ((void *)0 == (GprsDataFrmPtr = OSMemGetOpt(LargeMemoryPtr, 10, TIME_DELAY_MS(50)))) {
        return ERROR;
    }
	memcpy(GprsDataFrmPtr, DataFrmPtr, MEM_LARGE_BLOCK_LEN);

	GprsDataFrmPtr->PortNo = Uart_Gprs;
	if( XOR_CRC16 == GprsDataFrmPtr->PkgProp.PkgXor){
    	GprsDataFrmPtr->PkgLength = GprsDataFrmPtr->DataLen + GprsDataFrmPtr->RouteInfo.Level * LONG_ADDR_SIZE + DATA_FIXED_AREA_LENGTH_CRC16;
	}else{
    	GprsDataFrmPtr->PkgLength = GprsDataFrmPtr->DataLen + GprsDataFrmPtr->RouteInfo.Level * LONG_ADDR_SIZE + DATA_FIXED_AREA_LENGTH_CRC8;
	}
	GprsDataFrmPtr->PkgSn = PkgNo++;
	GprsDataFrmPtr->DeviceType = Dev_Concentrator;
	GprsDataFrmPtr->Life_Ack.Content = 0x0F;
	GprsDataFrmPtr->RouteInfo.CurPos = 0;
	GprsDataFrmPtr->RouteInfo.Level = 2;
	memcpy(GprsDataFrmPtr->Route[0], Concentrator.LongAddr, LONG_ADDR_SIZE);
	memcpy(GprsDataFrmPtr->Route[1], BroadcastAddrOut, LONG_ADDR_SIZE);
	GprsDataFrmPtr->PkgProp = DataHandle_SetPkgProperty(GprsDataFrmPtr->PkgProp.PkgXor, NONE_ACK, CMD_PKG, UP_DIR);
	DataHandle_SetPkgPath(GprsDataFrmPtr, UNREVERSED);
	DataHandle_CreateTxData(GprsDataFrmPtr, NULL);


/********************************************************************************
    			应答表端，如果有命令则一起下发
********************************************************************************/

    // 创建下行数据
    DataFrmPtr->DeviceType = Dev_Concentrator;
    DataFrmPtr->DataLen = 0;
    DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = 0xA0;	   // 特征字
    Rtc_Get((RTC_TIME *)(DataFrmPtr->DataBuf + DataFrmPtr->DataLen), Format_Bcd);
    DataFrmPtr->DataLen += 7;
    memset((uint8 *)(&DataFrmPtr->DataBuf[DataFrmPtr->DataLen]), 0, 12);
    DataFrmPtr->DataLen += 12;
    Data_GetTimeSlot(DataFrmPtr->Route[0], (uint8 *)(&DataFrmPtr->DataBuf[DataFrmPtr->DataLen]));
    DataFrmPtr->DataLen += 4;

    // 如果有下发命令，并且表版本号大于 3
    if( SubNodes[nodeId].CmdProp.Content != 0x0 && version > 0x3 ){
        DataFrmPtr->DataBuf[0] = 0xA1;	   // 特征字
        if( SubNodes[nodeId].CmdProp.SetChannel == 0x1 ){
            // 设置信道
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = Meter_ACK_Set_Channel; // 设置信道
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = 0x03;					// 数据长度
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = 0xDA;					// 两个字节的特征字 0xDA 0x26
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = 0x26;
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = SubNodes[nodeId].CmdData.SetChannel;	// 信道号，Bit7: 为1时设置信道，低7bit为信道号
        } else if ( SubNodes[nodeId].CmdProp.AutoChannel == 0x1 ){
            // 打开自动信道设置
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = Meter_ACK_Open_Auto_Channel; // 开关自动信道
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = 0x03;					// 数据长度
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = 0xDA;					// 两个字节的特征字 0xDA 0x26
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = 0x26;
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = SubNodes[nodeId].CmdData.AutoChannel;	// bit7：1开, 0关
        } else if ( SubNodes[nodeId].CmdProp.ValveCtrl == 0x1 ){
            // 阀控
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = Meter_ACK_Control_Valve; // 阀控
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = 0x03;					// 数据长度
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = 0xDA;					// 两个字节的特征字 0xDA 0x26
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = 0x26;
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = SubNodes[nodeId].CmdData.ValveCtrl;// 低四位：1开阀，2关阀
        } else if ( SubNodes[nodeId].CmdProp.RealTimeMeterReading == 0x1 ){
            // 开关实时抄表
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = Meter_ACK_Control_RwMeter; // 打开关闭实时抄表功能
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = 0x03;					// 数据长度
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = 0xDA;					// 两个字节的特征字 0xDA 0x26
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = 0x26;
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = SubNodes[nodeId].CmdData.RealTimeMeterReading;// bit7：1开, 0关
        } else if ( SubNodes[nodeId].CmdProp.SettlementPrice == 0x1 ){
            // 结算价格
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = Meter_ACK_Settlement_Price; // 结算价格
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = 0x04;					// 数据长度
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = 0xDA;					// 两个字节的特征字 0xDA 0x26
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = 0x26;
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = SubNodes[nodeId].CmdData.SettlementPriceLow;// 低位在前，高位在后
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = SubNodes[nodeId].CmdData.SettlementPriceHigh;// 低位在前，高位在后
        }

        // 如果需要处理应答消息,则创建应答处理任务
        if (NEED_ACK == DataFrmPtr->PkgProp.NeedAck) {
            if ((void *)0 == (taskPtr = DataHandle_GetEmptyTaskPtr())) {
                goto DATA_FORWARD_FAILED;
            }
            if ((void *)0 == (taskPtr->StkPtr = (OS_STK *)OSMemGetOpt(LargeMemoryPtr, 10, TIME_DELAY_MS(50)))) {
                goto DATA_FORWARD_FAILED;
            }
            taskPtr->Command = DataFrmPtr->Command;
            taskPtr->NodeId = nodeId;
            taskPtr->PkgSn = DataFrmPtr->PkgSn;
            taskPtr->RouteLevel = DataFrmPtr->RouteInfo.Level;
            taskPtr->PortNo = DataFrmPtr->PortNo;
            taskPtr->Mbox = OSMboxCreate((void *)0);
            //taskPtr->Msg = (uint8 *)rxDataFrmPtr;
            if (OS_ERR_NONE != OSTaskCreate(DataHandle_DataCommandResultTask, taskPtr, taskPtr->StkPtr + MEM_LARGE_BLOCK_LEN / sizeof(OS_STK) - 1, taskPtr->Prio)) {
                OSMemPut(LargeMemoryPtr, taskPtr->StkPtr);
                taskPtr->StkPtr = (void *)0;
                OSMboxDel(taskPtr->Mbox, OS_DEL_ALWAYS, &err);
                goto DATA_FORWARD_FAILED;
            }
        }

        DataFrmPtr->PkgProp = DataHandle_SetPkgProperty(DataFrmPtr->PkgProp.PkgXor, NEED_ACK, CMD_PKG, DOWN_DIR);
		DataHandle_SetPkgPath(DataFrmPtr, REVERSED);
		Test_DataHandle_CreateTxData(DataFrmPtr, version);
    }else{
        DataFrmPtr->PkgProp = DataHandle_SetPkgProperty(DataFrmPtr->PkgProp.PkgXor, NONE_ACK, ACK_PKG, DOWN_DIR);
		DataHandle_SetPkgPath(DataFrmPtr, REVERSED);
		DataHandle_CreateTxData(DataFrmPtr, version);
    }

    return NONE_ACK;

DATA_FORWARD_FAILED:
    if (NEED_ACK == DataFrmPtr->PkgProp.NeedAck) {
        DataFrmPtr->DataBuf[0] = OP_Failure;
        DataFrmPtr->DataLen = 1;
        return NEED_ACK;
    }

    return NONE_ACK;
}

/************************************************************************************************
* Function Name: DataHandle_RTCTimingTask
* Decription   : 实时时钟校时处理任务
* Input        : *p_arg-参数指针
* Output       : 无
* Others       : 无
************************************************************************************************/
void DataHandle_RTCTimingTask(void *p_arg)
{
    uint8 err;
    DATA_HANDLE_TASK *taskPtr;
    DATA_FRAME_STRUCT *txDataFrmPtr, *rxDataFrmPtr;
	uint8 version = 0;

    // 创建上行校时数据包
    TaskRunStatus.RTCTiming = TRUE;
    if ((void *)0 != (txDataFrmPtr = OSMemGetOpt(LargeMemoryPtr, 10, TIME_DELAY_MS(50)))) {
        txDataFrmPtr->PortNo = Uart_Gprs;
        txDataFrmPtr->PkgProp = DataHandle_SetPkgProperty(XOR_CRC16, NEED_ACK, CMD_PKG, UP_DIR);
		if( XOR_CRC16 == txDataFrmPtr->PkgProp.PkgXor){
			txDataFrmPtr->PkgLength = DATA_FIXED_AREA_LENGTH_CRC16;
		}else{
			txDataFrmPtr->PkgLength = DATA_FIXED_AREA_LENGTH_CRC8;
		}
        txDataFrmPtr->PkgSn = PkgNo++;
        txDataFrmPtr->Command = CONC_RTC_Timing;
        txDataFrmPtr->DeviceType = Dev_Concentrator;
        txDataFrmPtr->Life_Ack.Content = 0x0F;
        txDataFrmPtr->RouteInfo.CurPos = 0;
        txDataFrmPtr->RouteInfo.Level = 1;
        memcpy(txDataFrmPtr->Route[0], Concentrator.LongAddr, LONG_ADDR_SIZE);
        txDataFrmPtr->DataLen = 0;

        taskPtr = (DATA_HANDLE_TASK *)p_arg;
        taskPtr->Command = txDataFrmPtr->Command;
        taskPtr->NodeId = NULL_U16_ID;
        taskPtr->PkgSn = txDataFrmPtr->PkgSn;

        // 创建发送数据包
        DataHandle_SetPkgPath(txDataFrmPtr, UNREVERSED);
        DataHandle_CreateTxData(txDataFrmPtr, version);

        // 等待服务器的应答
        rxDataFrmPtr = OSMboxPend(taskPtr->Mbox, GPRS_WAIT_ACK_OVERTIME, &err);
        if ((void *)0 == rxDataFrmPtr) {
            RTCTimingTimer = 300;               // 如果超时则5分钟后重试
        } else {
            if (SUCCESS == Rtc_Set(*(RTC_TIME *)(rxDataFrmPtr->DataBuf), Format_Bcd)) {
                RTCTimingTimer = RTCTIMING_INTERVAL_TIME;
            } else {
                RTCTimingTimer = 5;             // 如果校时失败则5秒后重试
            }
            OSMemPut(LargeMemoryPtr, rxDataFrmPtr);
        }
    }

    // 销毁本任务,此处必须先禁止任务调度,否则无法释放本任务占用的内存空间
    OSMboxDel(taskPtr->Mbox, OS_DEL_ALWAYS, &err);
    OSSchedLock();
    OSTaskDel(OS_PRIO_SELF);
    OSMemPut(LargeMemoryPtr, taskPtr->StkPtr);
    taskPtr->StkPtr = (void *)0;
    TaskRunStatus.RTCTiming = FALSE;
    OSSchedUnlock();
}

/************************************************************************************************
* Function Name: DataHandle_RTCTimingProc
* Decription   : 集中器实时时钟主动校时处理函数
* Input        : 无
* Output       : 无
* Others       : 每隔一段时间就启动一次校时任务
************************************************************************************************/
void DataHandle_RTCTimingProc(void)
{
    uint8 err;
    DATA_HANDLE_TASK *taskPtr;

    // 检查Gprs是否在线或者任务是否正在运行中
    if (FALSE == Gprs.Online || TRUE == TaskRunStatus.RTCTiming || TRUE == TaskRunStatus.GprsDataUpload) {
        RTCTimingTimer = 60;
        return;
    }

    if ((void *)0 == (taskPtr = DataHandle_GetEmptyTaskPtr())) {
        return;
    }
    if ((void *)0 == (taskPtr->StkPtr = (OS_STK *)OSMemGetOpt(LargeMemoryPtr, 10, TIME_DELAY_MS(50)))) {
        return;
    }
    taskPtr->Mbox = OSMboxCreate((void *)0);
    taskPtr->Msg = (void *)0;
    if (OS_ERR_NONE != OSTaskCreate(DataHandle_RTCTimingTask, taskPtr,
        taskPtr->StkPtr + MEM_LARGE_BLOCK_LEN / sizeof(OS_STK) - 1, taskPtr->Prio)) {
        OSMemPut(LargeMemoryPtr, taskPtr->StkPtr);
        taskPtr->StkPtr = (void *)0;
        OSMboxDel(taskPtr->Mbox, OS_DEL_ALWAYS, &err);
    }
}

/************************************************************************************************
* Function Name: DataHandle_GprsDelayDataUploadTask
* Decription   : Gprs 数据上传处理任务
* Input        : *p_arg-参数指针
* Output       : 无
************************************************************************************************/
void DataHandle_GprsDelayDataUploadTask(void *p_arg)
{
    uint8 err, i;
    DATA_HANDLE_TASK *taskPtr;
	PORT_BUF_FORMAT *txPortBufPtr;
	uint8 *gprsTxBufPtr;

    taskPtr = (DATA_HANDLE_TASK *)p_arg;
    TaskRunStatus.GprsDataUpload = TRUE;

	// 循环查找 MemoryGprsBlock 空间，将需要上传的数据上传
	for(i = 0; i < TOTAL_GPRS_BLOCK; i++){
		// 校验是否为 GPRS 需要延时上传的数据包
		if(GPRS_DELAY_UP_CRC0 != MemoryGprsBlock[i][0] || GPRS_DELAY_UP_CRC1 != MemoryGprsBlock[i][1]
		|| GPRS_DELAY_UP_CRC2 != MemoryGprsBlock[i][2] || GPRS_DELAY_UP_CRC3 != MemoryGprsBlock[i][3]){
			continue;
		}

		if ((void *)0 == (txPortBufPtr = OSMemGetOpt(LargeMemoryPtr, 10, TIME_DELAY_MS(50)))) {
			goto GprsErrorTask;
		}

		// 复制需要上传的数据到长内存块
		memcpy(txPortBufPtr, &MemoryGprsBlock[i][4], MEM_GPRS_BLOCK_LEN-4);
		// 重置校验头，防止重复发送数据。
		MemoryGprsBlock[i][0] = GPRS_DELAY_UP_CRCX;
		MemoryGprsBlock[i][1] = GPRS_DELAY_UP_CRCX;
		MemoryGprsBlock[i][2] = GPRS_DELAY_UP_CRCX;
		MemoryGprsBlock[i][3] = GPRS_DELAY_UP_CRCX;
		// 释放此内存块
		OSMemPut(GprsMemoryPtr, &MemoryGprsBlock[i][0]);


		// 发送数据到gprs，如果失败则保存数据下次重发
		if (FALSE == Gprs.Online || OS_ERR_NONE != OSMboxPost(Gprs.MboxTx, txPortBufPtr)) {
			if ((void *)0 == (gprsTxBufPtr = OSMemGetOpt(GprsMemoryPtr, 10, TIME_DELAY_MS(50)))) {
				OSMemPut(LargeMemoryPtr, txPortBufPtr);
				Gprs_OutputDebugMsg(TRUE, "++GprsMemoryPtr get error\n");
				goto GprsErrorTask;
			}
			gprsTxBufPtr[0] = GPRS_DELAY_UP_CRC0;
			gprsTxBufPtr[1] = GPRS_DELAY_UP_CRC1;
			gprsTxBufPtr[2] = GPRS_DELAY_UP_CRC2;
			gprsTxBufPtr[3] = GPRS_DELAY_UP_CRC3;
			memcpy(&gprsTxBufPtr[4], txPortBufPtr, MEM_GPRS_BLOCK_LEN - 4);
			GprsDelayDataUpTimer = 10;
			OSMemPut(LargeMemoryPtr, txPortBufPtr);
			Gprs_OutputDebugMsg(TRUE, "++Gprs not online\n");
			goto GprsErrorTask;
		} else {
			OSFlagPost(GlobalEventFlag, FLAG_GPRS_TX, OS_FLAG_SET, &err);
		}

	}

GprsErrorTask:

    // 销毁本任务,此处必须先禁止任务调度,否则无法释放本任务占用的内存空间
    if ((void *)0 != txPortBufPtr) {
        //OSMemPut(LargeMemoryPtr, txPortBufPtr);
    }

    // 销毁本任务,此处必须先禁止任务调度,否则无法释放本任务占用的内存空间
    GprsDelayDataUpTimer = DATAUPLOAD_INTERVAL_TIME;
    OSMboxDel(taskPtr->Mbox, OS_DEL_ALWAYS, &err);
    OSSchedLock();
    OSTaskDel(OS_PRIO_SELF);
    OSMemPut(LargeMemoryPtr, taskPtr->StkPtr);
    taskPtr->StkPtr = (void *)0;
    TaskRunStatus.GprsDataUpload = FALSE;
    OSSchedUnlock();
}


/************************************************************************************************
* Function Name: DataHandle_GprsDelayDataUploadProc
* Decription   : Gprs 缓存数据延时上传服务器处理函数
* Input        : 无
* Output       : 无
* Others       : 判断是否有数据需要上传并启动上传任务
************************************************************************************************/
void DataHandle_GprsDelayDataUploadProc(void)
{
    uint8 err;
    DATA_HANDLE_TASK *taskPtr;

    GprsDelayDataUpTimer = 30;

    // Gprs必须在线,并且上传任务没有运行
    if (FALSE == Gprs.Online || TRUE == TaskRunStatus.GprsDataUpload || TRUE == TaskRunStatus.RTCTiming || TRUE == TaskRunStatus.DataForward) {
        return;
    }
    // 搜索未被占用的空间,创建数据上传任务
    if ((void *)0 == (taskPtr = DataHandle_GetEmptyTaskPtr())) {
        return;
    }
    if ((void *)0 == (taskPtr->StkPtr = (OS_STK *)OSMemGetOpt(LargeMemoryPtr, 10, TIME_DELAY_MS(50)))) {
        return;
    }
    taskPtr->Mbox = OSMboxCreate((void *)0);
    taskPtr->Msg = (void *)0;
    if (OS_ERR_NONE != OSTaskCreate(DataHandle_GprsDelayDataUploadTask, taskPtr,
        taskPtr->StkPtr + MEM_LARGE_BLOCK_LEN / sizeof(OS_STK) - 1, taskPtr->Prio)) {
        OSMemPut(LargeMemoryPtr, taskPtr->StkPtr);
        taskPtr->StkPtr = (void *)0;
        OSMboxDel(taskPtr->Mbox, OS_DEL_ALWAYS, &err);
    }
}



/************************************************************************************************
* Function Name: DataHandle_ModifyScanChannelTask
* Decription   : 修改信道处理任务
* Input        : *p_arg-参数指针
* Output       : 无
* Others       : 无
************************************************************************************************/
void DataHandle_ModifyScanChannelTask(void *p_arg)
{
    uint8 err;
    DATA_HANDLE_TASK *taskPtr;
    DATA_FRAME_STRUCT *txDataFrmPtr, *rxDataFrmPtr;
    uint8 version = 0;

    // 创建上行修改信道数据包
    TaskRunStatus.ModifyScanChannel = TRUE;
    if ((void *)0 != (txDataFrmPtr = OSMemGetOpt(LargeMemoryPtr, 10, TIME_DELAY_MS(50)))) {
        txDataFrmPtr->PortNo = Usart_Rf;
        txDataFrmPtr->PkgProp = DataHandle_SetPkgProperty(XOR_CRC16, NEED_ACK, CMD_PKG, UP_DIR);
		if( XOR_CRC16 == txDataFrmPtr->PkgProp.PkgXor){
			txDataFrmPtr->PkgLength = DATA_FIXED_AREA_LENGTH_CRC16;
		}else{
			txDataFrmPtr->PkgLength = DATA_FIXED_AREA_LENGTH_CRC8;
		}
        txDataFrmPtr->PkgSn = PkgNo++;
        txDataFrmPtr->Command = Modify_Scan_Channel;
        txDataFrmPtr->DeviceType = Dev_Concentrator;
        txDataFrmPtr->Life_Ack.Content = 0x0F;
        txDataFrmPtr->RouteInfo.CurPos = 0;
        txDataFrmPtr->RouteInfo.Level = 2;
        memcpy(txDataFrmPtr->Route[0], Concentrator.LongAddr, LONG_ADDR_SIZE);
        memcpy(txDataFrmPtr->Route[1], BroadcastAddrOut, LONG_ADDR_SIZE);
        txDataFrmPtr->DataLen = 0;
        // 数据域包含
        txDataFrmPtr->DataBuf[0] = 0x82;// 0x2 读信道， 0x82 设置信道
        memcpy( &txDataFrmPtr->DataBuf[1], ModifyScanChannel_KEY, sizeof(ModifyScanChannel_KEY));
        txDataFrmPtr->DataLen += sizeof(ModifyScanChannel_KEY) + 1;
        // 高4位固定为3信道，低4位为需要设置的信道号
        txDataFrmPtr->DataBuf[txDataFrmPtr->DataLen++] = ((0x3 << 4)&0xF0) | (Concentrator.SecondChannel & 0xF);

        taskPtr = (DATA_HANDLE_TASK *)p_arg;
        taskPtr->Command = txDataFrmPtr->Command;
        taskPtr->NodeId = NULL_U16_ID;
        taskPtr->PkgSn = txDataFrmPtr->PkgSn;

        // 创建发送数据包
        DataHandle_SetPkgPath(txDataFrmPtr, UNREVERSED);
        DataHandle_CreateTxData(txDataFrmPtr, version);

        // 等待服务器的应答
        rxDataFrmPtr = OSMboxPend(taskPtr->Mbox, GPRS_WAIT_ACK_OVERTIME, &err);
        if ((void *)0 == rxDataFrmPtr) {
            ModifyScanChannel = 60;               // 如果超时则1分钟后重试
        } else {
            if ( ( 0x02 == rxDataFrmPtr->DataBuf[0] ) &&
                ( OP_Succeed == rxDataFrmPtr->DataBuf[1] ) &&
                ( Concentrator.SecondChannel == (rxDataFrmPtr->DataBuf[2]&0x0F) ) &&
                ( 0x30 == (rxDataFrmPtr->DataBuf[2]&0xF0) ) ) {
                ModifyScanChannel = 0;
                Concentrator.SaveSecondChannel = rxDataFrmPtr->DataBuf[2]&0x0F;
                Flash_SaveConcentratorInfo();
            } else {
                ModifyScanChannel = 5;             // 如果校时失败则5秒后重试
            }
            OSMemPut(LargeMemoryPtr, rxDataFrmPtr);
        }
    }

    // 销毁本任务,此处必须先禁止任务调度,否则无法释放本任务占用的内存空间
    OSMboxDel(taskPtr->Mbox, OS_DEL_ALWAYS, &err);
    OSSchedLock();
    OSTaskDel(OS_PRIO_SELF);
    OSMemPut(LargeMemoryPtr, taskPtr->StkPtr);
    taskPtr->StkPtr = (void *)0;
    TaskRunStatus.ModifyScanChannel = FALSE;
    OSSchedUnlock();
}

/************************************************************************************************
* Function Name: DataHandle_ModifyScanChannelProc
* Decription   : 集中器发送修改2e28扫描信道处理函数
* Input        :
* Others       : 无
************************************************************************************************/
void DataHandle_ModifyScanChannelProc(void)
{
	uint8 err;
	DATA_HANDLE_TASK *taskPtr;

	// 检查是否有其他任务正在运行中
	if (TRUE == TaskRunStatus.GprsDataUpload || TRUE == TaskRunStatus.DataForward || TRUE == TaskRunStatus.ModifyScanChannel) {
		ModifyScanChannel = 60;
		return;
	}

	if ((void *)0 == (taskPtr = DataHandle_GetEmptyTaskPtr())) {
		return;
	}
	if ((void *)0 == (taskPtr->StkPtr = (OS_STK *)OSMemGetOpt(LargeMemoryPtr, 10, TIME_DELAY_MS(50)))) {
		return;
	}
	taskPtr->Mbox = OSMboxCreate((void *)0);
	taskPtr->Msg = (void *)0;
	if (OS_ERR_NONE != OSTaskCreate(DataHandle_ModifyScanChannelTask, taskPtr,
		taskPtr->StkPtr + MEM_LARGE_BLOCK_LEN / sizeof(OS_STK) - 1, taskPtr->Prio)) {
		OSMemPut(LargeMemoryPtr, taskPtr->StkPtr);
		taskPtr->StkPtr = (void *)0;
		OSMboxDel(taskPtr->Mbox, OS_DEL_ALWAYS, &err);
	}
}

/************************************************************************************************
* Function Name: DataHandle_DataForwardTask
* Decription   : 数据转发处理任务
* Input        : p_arg-保存原来数据的指针
* Output       : 无
* Others       : 该函数用处理PC,串口,手持机发送数据后的等待任务
************************************************************************************************/
void DataHandle_DataForwardTask(void *p_arg)
{
    uint8 err;
    uint32 waitAckTime, startTime;
    DATA_HANDLE_TASK *taskPtr;
    DATA_FRAME_STRUCT *txDataFrmPtr, *rxDataFrmPtr;
	uint8 version = 0;

    taskPtr = (DATA_HANDLE_TASK *)p_arg;
    txDataFrmPtr = (DATA_FRAME_STRUCT *)(taskPtr->Msg);

    TaskRunStatus.DataForward = TRUE;
    startTime = Timer1ms;
    waitAckTime = (taskPtr->RouteLevel - 1) * DELAYTIME_ONE_LAYER * 2;
    while (waitAckTime > 0) {
        rxDataFrmPtr = OSMboxPend(taskPtr->Mbox, TIME_DELAY_MS(waitAckTime), &err);
        if ((void *)0 == rxDataFrmPtr) {
            txDataFrmPtr->DataBuf[7] = OP_OvertimeError;
            txDataFrmPtr->DataLen = 8;
            if (NULL_U16_ID != taskPtr->NodeId) {
                SubNodes[taskPtr->NodeId].Property.CurRouteNo = (SubNodes[taskPtr->NodeId].Property.CurRouteNo + 1) % MAX_CUSTOM_ROUTES;
            }
        } else {
            // 根据msg构建应答数据

            if (NULL_U16_ID == taskPtr->NodeId && 0 != memcmp(rxDataFrmPtr->Route[0], &txDataFrmPtr->DataBuf[1], LONG_ADDR_SIZE)) {
                OSMemPut(LargeMemoryPtr, rxDataFrmPtr);
                waitAckTime = (Timer1ms > startTime) ? (Timer1ms - startTime) : 0;
                continue;
            }
            txDataFrmPtr->PkgLength -= txDataFrmPtr->DataLen;
            txDataFrmPtr->DataLen = 1 + LONG_ADDR_SIZE;
            //txDataFrmPtr->DataBuf[txDataFrmPtr->DataLen++] = OP_Succeed;
            memcpy(&txDataFrmPtr->DataBuf[txDataFrmPtr->DataLen], rxDataFrmPtr->DataBuf, rxDataFrmPtr->DataLen);
            txDataFrmPtr->DataLen += rxDataFrmPtr->DataLen;
            //txDataFrmPtr->DataBuf[txDataFrmPtr->DataLen++] = rxDataFrmPtr->DownRssi;
            //txDataFrmPtr->DataBuf[txDataFrmPtr->DataLen++] = rxDataFrmPtr->UpRssi;
            txDataFrmPtr->PkgLength += txDataFrmPtr->DataLen;
            OSMemPut(LargeMemoryPtr, rxDataFrmPtr);
        }
        break;
    }

    // 创建应答数据包
    txDataFrmPtr->PkgProp = DataHandle_SetPkgProperty(txDataFrmPtr->PkgProp.PkgXor, NONE_ACK, ACK_PKG, UP_DIR);
    DataHandle_SetPkgPath(txDataFrmPtr, REVERSED);
    DataHandle_CreateTxData(txDataFrmPtr, version);

    // 销毁本任务,此处必须先禁止任务调度,否则无法释放本任务占用的内存空间
    OSMboxDel(taskPtr->Mbox, OS_DEL_ALWAYS, &err);
    OSSchedLock();
    OSTaskDel(OS_PRIO_SELF);
    OSMemPut(LargeMemoryPtr, taskPtr->StkPtr);
    taskPtr->StkPtr = (void *)0;
    TaskRunStatus.DataForward = FALSE;
    OSSchedUnlock();
}

/************************************************************************************************
* Function Name: DataHandle_DataForwardProc
* Decription   : 数据转发处理任务,只处理接收事件
* Input        : DataFrmPtr-接收到的数据指针
* Output       : 是否需要后续处理
* Others       : 下行:命令字(1)+目标节点地址(6)+转发的数据(N) + 信道选择(1)
*                上行:命令字(1)+目标节点地址(6)+转发的结果(1)+转发的应答数据(N)
************************************************************************************************/
bool DataHandle_DataForwardProc(DATA_FRAME_STRUCT *DataFrmPtr)
{
    uint8 i, err;
    uint16 nodeId;
    DATA_HANDLE_TASK *taskPtr;
    DATA_FRAME_STRUCT *rxDataFrmPtr;
	uint8 version = 0;

    // 检查节点是否合法
    nodeId = Data_FindNodeId(0, &DataFrmPtr->DataBuf[1]);

    // 节点不存在集中器档案中或有任务在处理中
    if (TRUE == TaskRunStatus.DataForward) {
        if (NEED_ACK == DataFrmPtr->PkgProp.NeedAck) {
            DataFrmPtr->DataBuf[1 + LONG_ADDR_SIZE] = NULL_U16_ID == nodeId ? OP_ObjectNotExist : OP_Failure;
            DataFrmPtr->DataLen = 2 + LONG_ADDR_SIZE;
            return NEED_ACK;
        }
        OSMemPut(LargeMemoryPtr, DataFrmPtr);
        return NONE_ACK;
    }

    // 申请空间保存当前的数据
    if ((void *)0 == (rxDataFrmPtr = OSMemGetOpt(LargeMemoryPtr, 10, TIME_DELAY_MS(50)))) {
        if (NEED_ACK == DataFrmPtr->PkgProp.NeedAck) {
            DataFrmPtr->DataBuf[1 + LONG_ADDR_SIZE] = OP_Failure;
            DataFrmPtr->DataLen = 2 + LONG_ADDR_SIZE;
            return NEED_ACK;
        }
        OSMemPut(LargeMemoryPtr, DataFrmPtr);
        return NONE_ACK;
    }
    memcpy(rxDataFrmPtr, DataFrmPtr, MEM_LARGE_BLOCK_LEN);

    // 节点在集中器档案中则创建转发
    DataFrmPtr->PortNo = Usart_Rf;
    DataFrmPtr->Command = (COMMAND_TYPE)(rxDataFrmPtr->DataBuf[0]);
    //DataFrmPtr->DeviceType = rxDataFrmPtr->DeviceType;
	DataFrmPtr->DeviceType = Dev_Concentrator;
    DataFrmPtr->PkgSn = PkgNo++;
    DataFrmPtr->Life_Ack.LifeCycle = 0x0F;
    DataFrmPtr->Life_Ack.AckChannel = DEFAULT_RX_CHANNEL;
    if (NULL_U16_ID == nodeId) {
        DataFrmPtr->RouteInfo.Level = 2;
        memcpy(DataFrmPtr->Route[0], Concentrator.LongAddr, LONG_ADDR_SIZE);
        memcpy(DataFrmPtr->Route[1], &DataFrmPtr->DataBuf[1], LONG_ADDR_SIZE);
    } else {
        DataFrmPtr->RouteInfo.Level = 2;
		memcpy(DataFrmPtr->Route[0], Concentrator.LongAddr, LONG_ADDR_SIZE);
        memcpy(DataFrmPtr->Route[1], &DataFrmPtr->DataBuf[1], LONG_ADDR_SIZE);
    }
    DataFrmPtr->RouteInfo.CurPos = 0;
    for (i = 0; i < rxDataFrmPtr->DataLen - 1 - LONG_ADDR_SIZE; i++) {
        DataFrmPtr->DataBuf[i] = rxDataFrmPtr->DataBuf[i + 1 + LONG_ADDR_SIZE];
    }
    //if( DataFrmPtr->DataBuf[i-1] == 0x44 && DataFrmPtr->DataBuf[i-2] == 0x44 ){
    //   version = 0x44;
    //}
    //DataFrmPtr->DataLen = i-2;

    // 如果需要应答,则创建应答任务
    if (NEED_ACK == rxDataFrmPtr->PkgProp.NeedAck) {
        if ((void *)0 == (taskPtr = DataHandle_GetEmptyTaskPtr())) {
            goto DATA_FORWARD_FAILED;
        }
        if ((void *)0 == (taskPtr->StkPtr = (OS_STK *)OSMemGetOpt(LargeMemoryPtr, 10, TIME_DELAY_MS(50)))) {
            goto DATA_FORWARD_FAILED;
        }
        taskPtr->Command = DataFrmPtr->Command;
        taskPtr->NodeId = nodeId;
        taskPtr->PkgSn = DataFrmPtr->PkgSn;
        taskPtr->RouteLevel = DataFrmPtr->RouteInfo.Level;
        taskPtr->PortNo = DataFrmPtr->PortNo;
        taskPtr->Mbox = OSMboxCreate((void *)0);
        taskPtr->Msg = (uint8 *)rxDataFrmPtr;
        if (OS_ERR_NONE != OSTaskCreate(DataHandle_DataForwardTask, taskPtr, taskPtr->StkPtr + MEM_LARGE_BLOCK_LEN / sizeof(OS_STK) - 1, taskPtr->Prio)) {
            OSMemPut(LargeMemoryPtr, taskPtr->StkPtr);
            taskPtr->StkPtr = (void *)0;
            OSMboxDel(taskPtr->Mbox, OS_DEL_ALWAYS, &err);
            goto DATA_FORWARD_FAILED;
        }
    } else {
        OSMemPut(LargeMemoryPtr, rxDataFrmPtr);
    }
    DataFrmPtr->PkgProp = DataHandle_SetPkgProperty(DataFrmPtr->PkgProp.PkgXor, NEED_ACK, CMD_PKG, DOWN_DIR);
    DataHandle_SetPkgPath(DataFrmPtr, UNREVERSED);
    DataHandle_CreateTxData(DataFrmPtr, version);
    return NONE_ACK;

DATA_FORWARD_FAILED:
    if (NEED_ACK == rxDataFrmPtr->PkgProp.NeedAck) {
        memcpy(DataFrmPtr, rxDataFrmPtr, MEM_LARGE_BLOCK_LEN);
        OSMemPut(LargeMemoryPtr, rxDataFrmPtr);
        DataFrmPtr->DataBuf[1 + LONG_ADDR_SIZE] = OP_Failure;
        DataFrmPtr->DataLen = 2 + LONG_ADDR_SIZE;
        return NEED_ACK;
    }
    OSMemPut(LargeMemoryPtr, rxDataFrmPtr);
    return NONE_ACK;
}

/************************************************************************************************
* Function Name: DataHandle_ReadSecondChannelTask
* Decription   : 读取第二扫描信道处理任务
* Input        : p_arg-保存原来数据的指针
* Output       : 无
* Others       : 该函数用处理PC,串口,手持机发送数据后的等待任务
************************************************************************************************/
void DataHandle_ReadSecondChannelTask(void *p_arg)
{
    uint8 err;
    uint32 waitAckTime, startTime;
    DATA_HANDLE_TASK *taskPtr;
    DATA_FRAME_STRUCT *txDataFrmPtr, *rxDataFrmPtr;
	uint8 version = 0;

    taskPtr = (DATA_HANDLE_TASK *)p_arg;
    txDataFrmPtr = (DATA_FRAME_STRUCT *)(taskPtr->Msg);

    TaskRunStatus.DataForward = TRUE;
    startTime = Timer1ms;
    waitAckTime = (taskPtr->RouteLevel - 1) * DELAYTIME_ONE_LAYER * 2;
    while (waitAckTime > 0) {
        rxDataFrmPtr = OSMboxPend(taskPtr->Mbox, TIME_DELAY_MS(waitAckTime), &err);
        if ((void *)0 == rxDataFrmPtr) {
            txDataFrmPtr->DataBuf[7] = OP_OvertimeError;
            txDataFrmPtr->DataLen = 8;
            if (NULL_U16_ID != taskPtr->NodeId) {
                SubNodes[taskPtr->NodeId].Property.CurRouteNo = (SubNodes[taskPtr->NodeId].Property.CurRouteNo + 1) % MAX_CUSTOM_ROUTES;
            }
        } else {
			if ( 0x02 == rxDataFrmPtr->DataBuf[0] && 0xAA == rxDataFrmPtr->DataBuf[1] ){
				if( (Concentrator.SaveSecondChannel != (rxDataFrmPtr->DataBuf[2] & 0xF)) &&
					((rxDataFrmPtr->DataBuf[2] & 0xF) >= 0x0) && ((rxDataFrmPtr->DataBuf[2] & 0xF) <= 0xF)){
					Concentrator.SaveSecondChannel = rxDataFrmPtr->DataBuf[2] & 0xF;
				}
			}
            if (NULL_U16_ID == taskPtr->NodeId && 0 != memcmp(rxDataFrmPtr->Route[0], &txDataFrmPtr->DataBuf[1], LONG_ADDR_SIZE)) {
                OSMemPut(LargeMemoryPtr, rxDataFrmPtr);
                waitAckTime = (Timer1ms > startTime) ? (Timer1ms - startTime) : 0;
                continue;
            }
            txDataFrmPtr->PkgLength -= txDataFrmPtr->DataLen;
            txDataFrmPtr->DataLen = 1 + LONG_ADDR_SIZE;
            txDataFrmPtr->DataBuf[txDataFrmPtr->DataLen++] = OP_Succeed;
            memcpy(&txDataFrmPtr->DataBuf[txDataFrmPtr->DataLen], rxDataFrmPtr->DataBuf, rxDataFrmPtr->DataLen);
            txDataFrmPtr->DataLen += rxDataFrmPtr->DataLen;
            txDataFrmPtr->DataBuf[txDataFrmPtr->DataLen++] = rxDataFrmPtr->DownRssi;
            txDataFrmPtr->DataBuf[txDataFrmPtr->DataLen++] = rxDataFrmPtr->UpRssi;
            txDataFrmPtr->PkgLength += txDataFrmPtr->DataLen;
            OSMemPut(LargeMemoryPtr, rxDataFrmPtr);
        }
        break;
    }

    // 创建应答数据包
    txDataFrmPtr->PkgProp = DataHandle_SetPkgProperty(txDataFrmPtr->PkgProp.PkgXor, NONE_ACK, ACK_PKG, UP_DIR);
    DataHandle_SetPkgPath(txDataFrmPtr, REVERSED);
    DataHandle_CreateTxData(txDataFrmPtr, version);

    // 销毁本任务,此处必须先禁止任务调度,否则无法释放本任务占用的内存空间
    OSMboxDel(taskPtr->Mbox, OS_DEL_ALWAYS, &err);
    OSSchedLock();
    OSTaskDel(OS_PRIO_SELF);
    OSMemPut(LargeMemoryPtr, taskPtr->StkPtr);
    taskPtr->StkPtr = (void *)0;
    TaskRunStatus.DataForward = FALSE;
    OSSchedUnlock();
}


/************************************************************************************************
* Function Name: DataHandle_ReadSecondChannelProc
* Decription   : 读取第二扫描信道
* Input        : DataFrmPtr-接收到的数据指针
* Output       : 是否需要后续处理
* Others       : 下行:命令字(1)+目标节点地址(6)+转发的数据(N)
*                上行:命令字(1)+目标节点地址(6)+转发的结果(1)+转发的应答数据(N)
************************************************************************************************/
bool DataHandle_ReadSecondChannelProc(DATA_FRAME_STRUCT *DataFrmPtr)
{
    uint8 i, err;
    uint16 nodeId;
    DATA_HANDLE_TASK *taskPtr;
    DATA_FRAME_STRUCT *rxDataFrmPtr;
	uint8 version = 0;

    // 检查节点是否合法
    nodeId = Data_FindNodeId(0, &DataFrmPtr->DataBuf[1]);

    // 节点不存在集中器档案中或有任务在处理中
    if (TRUE == TaskRunStatus.DataForward) {
        if (NEED_ACK == DataFrmPtr->PkgProp.NeedAck) {
            DataFrmPtr->DataBuf[1 + LONG_ADDR_SIZE] = NULL_U16_ID == nodeId ? OP_ObjectNotExist : OP_Failure;
            DataFrmPtr->DataLen = 2 + LONG_ADDR_SIZE;
            return NEED_ACK;
        }
        OSMemPut(LargeMemoryPtr, DataFrmPtr);
        return NONE_ACK;
    }

    // 申请空间保存当前的数据
    if ((void *)0 == (rxDataFrmPtr = OSMemGetOpt(LargeMemoryPtr, 10, TIME_DELAY_MS(50)))) {
        if (NEED_ACK == DataFrmPtr->PkgProp.NeedAck) {
            DataFrmPtr->DataBuf[1 + LONG_ADDR_SIZE] = OP_Failure;
            DataFrmPtr->DataLen = 2 + LONG_ADDR_SIZE;
            return NEED_ACK;
        }
        OSMemPut(LargeMemoryPtr, DataFrmPtr);
        return NONE_ACK;
    }
    memcpy(rxDataFrmPtr, DataFrmPtr, MEM_LARGE_BLOCK_LEN);

    // 节点在集中器档案中则创建转发
    DataFrmPtr->PortNo = Usart_Rf;
    DataFrmPtr->Command = (COMMAND_TYPE)(rxDataFrmPtr->DataBuf[0]);
	DataFrmPtr->DeviceType = Dev_Concentrator;
    DataFrmPtr->PkgSn = PkgNo++;
    DataFrmPtr->Life_Ack.LifeCycle = 0x0F;
    DataFrmPtr->Life_Ack.AckChannel = DEFAULT_RX_CHANNEL;
    if (NULL_U16_ID == nodeId) {
        DataFrmPtr->RouteInfo.Level = 2;
        memcpy(DataFrmPtr->Route[0], Concentrator.LongAddr, LONG_ADDR_SIZE);
        memcpy(DataFrmPtr->Route[1], &DataFrmPtr->DataBuf[1], LONG_ADDR_SIZE);
    } else {
        DataFrmPtr->RouteInfo.Level = 2;// Data_GetRoute(nodeId, (uint8 *)(DataFrmPtr->Route)) & 0x0F;
    }
    DataFrmPtr->RouteInfo.CurPos = 0;
    for (i = 0; i < rxDataFrmPtr->DataLen - 1 - LONG_ADDR_SIZE; i++) {
        DataFrmPtr->DataBuf[i] = rxDataFrmPtr->DataBuf[i + 1 + LONG_ADDR_SIZE];
    }
    if( DataFrmPtr->DataBuf[i-1] == 0x44 && DataFrmPtr->DataBuf[i-2] == 0x44 ){
        version = 0x44;
    }

    // 如果需要应答,则创建应答任务
    if (NEED_ACK == rxDataFrmPtr->PkgProp.NeedAck) {
        if ((void *)0 == (taskPtr = DataHandle_GetEmptyTaskPtr())) {
            goto DATA_FORWARD_FAILED;
        }
        if ((void *)0 == (taskPtr->StkPtr = (OS_STK *)OSMemGetOpt(LargeMemoryPtr, 10, TIME_DELAY_MS(50)))) {
            goto DATA_FORWARD_FAILED;
        }
        taskPtr->Command = DataFrmPtr->Command;
        taskPtr->NodeId = nodeId;
        taskPtr->PkgSn = DataFrmPtr->PkgSn;
        taskPtr->RouteLevel = DataFrmPtr->RouteInfo.Level;
        taskPtr->PortNo = DataFrmPtr->PortNo;
        taskPtr->Mbox = OSMboxCreate((void *)0);
        taskPtr->Msg = (uint8 *)rxDataFrmPtr;
        if (OS_ERR_NONE != OSTaskCreate(DataHandle_ReadSecondChannelTask, taskPtr, taskPtr->StkPtr + MEM_LARGE_BLOCK_LEN / sizeof(OS_STK) - 1, taskPtr->Prio)) {
            OSMemPut(LargeMemoryPtr, taskPtr->StkPtr);
            taskPtr->StkPtr = (void *)0;
            OSMboxDel(taskPtr->Mbox, OS_DEL_ALWAYS, &err);
            goto DATA_FORWARD_FAILED;
        }
    } else {
        OSMemPut(LargeMemoryPtr, rxDataFrmPtr);
    }

    DataFrmPtr->PkgProp = DataHandle_SetPkgProperty(DataFrmPtr->PkgProp.PkgXor, NEED_ACK, CMD_PKG, DOWN_DIR);
    DataHandle_SetPkgPath(DataFrmPtr, UNREVERSED);
    DataHandle_CreateTxData(DataFrmPtr, version);
    return NONE_ACK;

DATA_FORWARD_FAILED:
    if (NEED_ACK == rxDataFrmPtr->PkgProp.NeedAck) {
        memcpy(DataFrmPtr, rxDataFrmPtr, MEM_LARGE_BLOCK_LEN);
        OSMemPut(LargeMemoryPtr, rxDataFrmPtr);
        DataFrmPtr->DataBuf[1 + LONG_ADDR_SIZE] = OP_Failure;
        DataFrmPtr->DataLen = 2 + LONG_ADDR_SIZE;
        return NEED_ACK;
    }
    OSMemPut(LargeMemoryPtr, rxDataFrmPtr);
    return NONE_ACK;
}


/************************************************************************************************
* Function Name: DataHandle_RxCmdProc
* Decription   : 数据处理任务,只处理接收到的命令事件
* Input        : DataFrmPtr-数据帧的指针
* Output       : 无
* Others       : 该函数处理来自表端或服务器或PC机或手持机发送过来的指令并根据指令来应答
************************************************************************************************/
void DataHandle_RxCmdProc(DATA_FRAME_STRUCT *DataFrmPtr)
{
    bool postHandle, reversePath;
    PKG_PROPERTY ackPkgProperty;
	uint8 version = 0;

    postHandle = DataFrmPtr->PkgProp.NeedAck;
    reversePath = REVERSED;
    ackPkgProperty = DataHandle_SetPkgProperty(DataFrmPtr->PkgProp.PkgXor, NONE_ACK, ACK_PKG, UP_DIR);
    switch (DataFrmPtr->Command) {
        // 表端主动上报定时定量或冻结数据 0x01
		case SYRUNS_ActiveReport_Data:
            postHandle = DataHandle_Syruns_ActiveReportProc(DataFrmPtr);
			break;

        // 读集中器版本信息 0x40
        case Read_CONC_Version:
            // 下行:空数据域
            // 上行:程序版本(2)+硬件版本(2)+协议版本(2)
            DataFrmPtr->DataLen = 0;
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = (uint8)(SW_VERSION >> 8);
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = (uint8)SW_VERSION;
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = (uint8)(HW_VERSION >> 8);
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = (uint8)HW_VERSION;
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = (uint8)(PT_VERSION >> 8);
            DataFrmPtr->DataBuf[DataFrmPtr->DataLen++] = (uint8)PT_VERSION;
            break;

        // 读集中器ID 0x41
        case Read_CONC_ID:
            // 下行:空数据域
            // 上行:集中器ID的BCD码(6)
            memcpy(DataFrmPtr->DataBuf, Concentrator.LongAddr, LONG_ADDR_SIZE);
            DataFrmPtr->DataLen = LONG_ADDR_SIZE;
            break;

        // 写集中器ID 0x42
        case Write_CONC_ID:
            Data_SetConcentratorAddr(DataFrmPtr);
            break;

        // 读集中器时钟 0x43
        case Read_CONC_RTC:
            // 下行:空数据域
            // 上行:集中器时钟(7)
            Rtc_Get((RTC_TIME *)DataFrmPtr->DataBuf, Format_Bcd);
            DataFrmPtr->DataLen = 7;
            break;

        // 写集中器时钟 0x44
        case Write_CONC_RTC:
            // 下行:集中器时钟(7)
            // 上行:操作状态(1)
            if (SUCCESS == Rtc_Set(*(RTC_TIME *)(DataFrmPtr->DataBuf), Format_Bcd)) {
                DataFrmPtr->DataBuf[0] = OP_Succeed;
				GprsDelayDataUpTimer = 10;
                RTCTimingTimer = RTCTIMING_INTERVAL_TIME;
            } else {
                DataFrmPtr->DataBuf[0] = OP_TimeAbnormal;
            }
            DataFrmPtr->DataLen = 1;
            break;

        // 读Gprs参数 0x45
        case Read_GPRS_Param:
            Data_GprsParameter(DataFrmPtr);
            break;

        // 写Gprs参数 0x46
        case Write_GPRS_Param:
            Data_GprsParameter(DataFrmPtr);
            break;

        // 读Gprs信号强度 0x47
        case Read_GPRS_RSSI:
            // 下行:无
            // 上行:信号强度
            DataFrmPtr->DataBuf[0] = Gprs_GetCSQ();
            DataFrmPtr->DataBuf[1] = Gprs.Online ? 0x01 : 0x00;
            DataFrmPtr->DataLen = 2;
            DataFrmPtr->DataLen += Gprs_GetIMSI(&DataFrmPtr->DataBuf[DataFrmPtr->DataLen]);
            DataFrmPtr->DataLen += Gprs_GetGMM(&DataFrmPtr->DataBuf[DataFrmPtr->DataLen]);
            break;

        // 集中器初始化 0x48
        case Initial_CONC_Cmd:
            // 下行:操作类别
            // 上行:操作类别+操作状态
            DataFrmPtr->DataBuf[1] = OP_Succeed;
            if (0 == DataFrmPtr->DataBuf[0]) {
                Data_ClearDatabase();
            } else if(1 == DataFrmPtr->DataBuf[0]) {
                Data_ClearMeterData();
            } else {
                DataFrmPtr->DataBuf[1] = OP_Failure;
            }
            DataFrmPtr->DataLen = 2;
            break;

        // 集中器重新启动 0x4C
        case Restart_CONC_Cmd:
            // 下行:无
            // 上行:操作状态
            DataFrmPtr->DataBuf[0] = OP_Succeed;
            DataFrmPtr->DataLen = 1;
            DevResetTimer = 5000;
            break;

        // 集中器数据转发指令 0x4D
        case Data_Forward_Cmd:
            postHandle = DataHandle_DataForwardProc(DataFrmPtr);
            break;

		// 设置集中器第二扫描信道 0x4E
		case Write_Second_Channel_Cmd:
			if( ((DataFrmPtr->DataBuf[0]&0xF) >= 0x0) && (DataFrmPtr->DataBuf[0] <= 0xF) ){
				Concentrator.SecondChannel = DataFrmPtr->DataBuf[0]&0xF;
				DataFrmPtr->DataBuf[0] = OP_Succeed;
				DataFrmPtr->DataLen = 1;
				ModifyScanChannel = 2;
			}else{
				DataFrmPtr->DataBuf[0] = OP_Failure;
				DataFrmPtr->DataLen = 1;
			}
			break;

		// 读集中器第二扫描信道 0x4F
		case Read_Second_Channel_Cmd:
            postHandle = DataHandle_ReadSecondChannelProc(DataFrmPtr);
			break;

        // 表具档案的总数量 0x50
        case Read_Meter_Total_Number:
            Data_ReadNodesCount(DataFrmPtr);
            break;

        // 读取表具档案信息 0x51
        case Read_Meters_Doc_Info:
            Data_ReadNodes(DataFrmPtr);
            break;

        // 写入表具档案信息 0x52
        case Write_Meters_Doc_Info:
            Data_WriteNodes(DataFrmPtr);
            break;

        // 删除表具档案信息 0x53
        case Delete_Meters_Doc_Info:
            Data_DeleteNodes(DataFrmPtr);
            break;

        // 修改表具档案信息 0x54
        case Modify_Meter_Doc_Info:
            Data_ModifyNodes(DataFrmPtr);
            break;

        // 读集中器下发命令数据指令 0x67
        case Read_CmdDown_Data:
            DataHandle_ReadMeterCmdLoadProc(DataFrmPtr);
            break;

        // 批量读集中器下发命令数据指令 0x68
        case Batch_Read_CmdDown_Data:
            DataHandle_ReadMeterCmdBatchLoadProc(DataFrmPtr);
            break;

        // 批量写集中器下发命令数据指令 0x69
        case Batch_Wtite_CmdDown_Data:
            Data_BatchWriteMeterCmdLoadProc(DataFrmPtr);
            break;


        // 集中器程序升级 0xF1
        case Software_Update_Cmd:
            Data_SwUpdate(DataFrmPtr);
            break;

        // Eeprom检查 0xF3
        case Eeprom_Check_Cmd:
            Data_EepromCheckProc(DataFrmPtr);
            break;

        // 其他指令不支持
        default:
        //Gprs_OutputDebugMsg(TRUE, "--该指令暂不支持--\n");
            postHandle = NONE_ACK;
            OSMemPut(LargeMemoryPtr, DataFrmPtr);
            break;
    }

    if (NEED_ACK == postHandle) {
        DataFrmPtr->PkgProp = ackPkgProperty;
        DataHandle_SetPkgPath(DataFrmPtr, reversePath);
        DataHandle_CreateTxData(DataFrmPtr, version);
    }
}

/************************************************************************************************
* Function Name: DataHandle_RxAckProc
* Decription   : 数据处理任务,只处理接收到的应答事件
* Input        : DataBufPtr-命令数据指针
* Output       : 无
* Others       : 该函数处理来自表端或服务器或PC机或手持机发送过来的应答
************************************************************************************************/
void DataHandle_RxAckProc(DATA_FRAME_STRUCT *DataFrmPtr)
{
    uint8 i;
    uint16 nodeId;
    DATA_HANDLE_TASK *taskPtr;

    // 查找应答节点是否在本档案中
    nodeId = Data_FindNodeId(0, DataFrmPtr->Route[0]);

    // 判断该应答帧应该传递给谁
    for (i = 0; i < MAX_DATA_HANDLE_TASK_NUM; i++) {
        taskPtr = &DataHandle_TaskArry[i];
        if ((void *)0 != taskPtr->StkPtr &&
            taskPtr->NodeId == nodeId &&
            taskPtr->Command == DataFrmPtr->Command &&
            taskPtr->PkgSn == DataFrmPtr->PkgSn) {
            if (OS_ERR_NONE != OSMboxPost(taskPtr->Mbox, DataFrmPtr)) {
                OSMemPut(LargeMemoryPtr, DataFrmPtr);
            }
            return;
        }
    }
    OSMemPut(LargeMemoryPtr, DataFrmPtr);
}

/************************************************************************************************
* Function Name: DataHandle_PassProc
* Decription   : 透传处理任务
* Input        : DataFrmPtr-接收到的数据指针
* Output       : TRUE-已经处理,FALSE-没有处理
* Others       : 目标地址不是自己时,传递到下一个节点
************************************************************************************************/
bool DataHandle_PassProc(DATA_FRAME_STRUCT *DataFrmPtr)
{
    static uint8 lastInPort = End_Port;
	uint8 version = 0;
	uint16 nodeId = 0;
	// 如果是目标节点则跳至下一步处理
	if (DataFrmPtr->RouteInfo.CurPos == DataFrmPtr->RouteInfo.Level - 1) {
		return FALSE;
	}
	// 如果是上行且是倒数第二级则按照设备类型选择通讯端口,其他情况都用RF端口
	if (UP_DIR == DataFrmPtr->PkgProp.Direction &&
		DataFrmPtr->RouteInfo.CurPos == DataFrmPtr->RouteInfo.Level - 2) {
		DataFrmPtr->PortNo = lastInPort;
		DataFrmPtr->Life_Ack.AckChannel = DEFAULT_TX_CHANNEL;
	} else {
		lastInPort = DataFrmPtr->PortNo;
		DataFrmPtr->Life_Ack.AckChannel = DEFAULT_RX_CHANNEL;
		DataFrmPtr->PortNo = Usart_Rf;

		nodeId = Data_FindNodeId(0, DataFrmPtr->Route[DataFrmPtr->RouteInfo.Level - 1]);
		if( TRUE == SubNodes[nodeId].AutoChannelSwitch ){
			version = 0x44;
		}
	}

    DataHandle_CreateTxData(DataFrmPtr, version);
    return TRUE;
}


/************************************************************************************************
* Function Name: DataHandle_Task
* Decription   : 数据处理任务,只处理接收事件
* Input        : *p_arg-参数指针
* Output       : 无
* Others       : 无
************************************************************************************************/
void DataHandle_Task(void *p_arg)
{
    uint8 i, err, *dat;
    OS_FLAGS eventFlag;
    DATA_FRAME_STRUCT *dataFrmPtr;
    EXTRACT_DATA_RESULT ret;

    // 初始化参数
    (void)p_arg;
    PkgNo = CalCrc8(Concentrator.LongAddr, LONG_ADDR_SIZE);
    for (i = 0; i < MAX_DATA_HANDLE_TASK_NUM; i++) {
        DataHandle_TaskArry[i].Prio = TASK_DATAHANDLE_DATA_PRIO + i;
        DataHandle_TaskArry[i].StkPtr = (void *)0;
    }
    TaskRunStatus.DataForward = FALSE;
    TaskRunStatus.GprsDataUpload = FALSE;
    TaskRunStatus.RTCTiming = FALSE;
    TaskRunStatus.ModifyScanChannel = FALSE;

    // 数据初始化
    Data_Init();

    while (TRUE) {
        // 获取发生的事件数据
        eventFlag = OSFlagPend(GlobalEventFlag, (OS_FLAGS)DATAHANDLE_EVENT_FILTER, (OS_FLAG_WAIT_SET_ANY | OS_FLAG_CONSUME), TIME_DELAY_MS(5000), &err);

        // 处理这些数据
        while (eventFlag != (OS_FLAGS)0) {
            dat = (void *)0;
            if (eventFlag & FLAG_USART_RF_RX) {
                // Rf模块收到了数据
                dat = OSMboxAccept(SerialPort.Port[Usart_Rf].MboxRx);
                eventFlag &= ~FLAG_USART_RF_RX;
            } else if (eventFlag & FLAG_GPRS_RX) {
                // Gprs模块收到了数据
                dat = OSMboxAccept(Gprs.MboxRx);
                eventFlag &= ~FLAG_GPRS_RX;
            } else if (eventFlag & FLAG_USB_RX) {
                // Usb端口收到了数据
                dat = OSMboxAccept(SerialPort.Port[Usb_Port].MboxRx);
                eventFlag &= ~FLAG_USB_RX;
            } else if (eventFlag & FLAG_USART_DEBUG_RX) {
                // Debug端口收到了数据
                dat = OSMboxAccept(SerialPort.Port[Usart_Debug].MboxRx);
                eventFlag &= ~FLAG_USART_DEBUG_RX;
            } else if (eventFlag & FLAG_UART_RS485_RX) {
                // 485端口收到了数据
                dat = OSMboxAccept(SerialPort.Port[Uart_Rs485].MboxRx);
                eventFlag &= ~FLAG_UART_RS485_RX;
            } else if (eventFlag & FLAG_USART_IR_RX) {
                // Ir端口收到了数据
                dat = OSMboxAccept(SerialPort.Port[Usart_Ir].MboxRx);
                eventFlag &= ~FLAG_USART_IR_RX;
            } else if (eventFlag & FLAG_DELAY_SAVE_TIMER) {
                // 数据延时保存
                eventFlag &= ~FLAG_DELAY_SAVE_TIMER;
                DataHandle_DataDelaySaveProc();
            } else if (eventFlag & FLAG_RTC_TIMING_TIMER) {
                // 时钟主动校时处理
                eventFlag &= ~FLAG_RTC_TIMING_TIMER;
                DataHandle_RTCTimingProc();
            } else if (eventFlag & FLAG_MODIFY_SCAN_CHANNEL) {
                // 修改表端主动上报信道号，通知 2E28 修改扫描信道
                eventFlag &= ~FLAG_MODIFY_SCAN_CHANNEL;
                DataHandle_ModifyScanChannelProc();
            } else if (eventFlag & FLAG_GPRS_DELAY_UPLOAD) {
				// GPRS 缓存数据延时上传处理
				eventFlag &= ~FLAG_GPRS_DELAY_UPLOAD;
				DataHandle_GprsDelayDataUploadProc();
			}

            if ((void *)0 == dat) {
                continue;
            }

            // 从原数据中提取数据
            if (Ok_Data != (ret = DataHandle_ExtractData(dat))) {
                if (Error_DstAddress == ret) {
                    // 如果不是给自己的数据可以监听其他节点并将其加入对应的邻居表中
                }
				//else{
                    OSMemPut(LargeMemoryPtr, dat);
                    continue;
                //}
            }

            dataFrmPtr = (DATA_FRAME_STRUCT *)dat;
            // 确定监控信息上传的通道
            if (Usart_Debug == dataFrmPtr->PortNo || Usb_Port == dataFrmPtr->PortNo) {
                MonitorPort = (PORT_NO)(dataFrmPtr->PortNo);
            }

            // 如果目标地址不是自己则转发
            if (TRUE == DataHandle_PassProc(dataFrmPtr)) {
                continue;
            }

            // 分别处理命令帧和应答帧指令
            if (CMD_PKG == dataFrmPtr->PkgProp.PkgType) {
                // 如果是命令帧
                DataHandle_RxCmdProc(dataFrmPtr);
            } else {
                // 如果是应答帧
                DataHandle_RxAckProc(dataFrmPtr);
            }
        }

        OSTimeDlyHMSM(0, 0, 0, 50);
    }
}

/***************************************End of file*********************************************/


