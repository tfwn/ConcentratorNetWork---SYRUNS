using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SR6009_Concentrator_Tools.FunList
{
    public partial class ValveControl : UserControl, IGetParas
    {
        string strValveCtrl = "";
        public ValveControl()
        {
            InitializeComponent();
            strValveCtrl = Common.XmlHelper.GetNodeDefValue(FrmMain.strConfigFile, "/Config/Parameter/ValveCtrl", "0");
            string[] strTemp = strValveCtrl.Split(',');
            cmbValveCtrl.SelectedIndex = Convert.ToInt16(strTemp[0]);
        }
        public int GetDataBuf(byte[] DataBuf, int Start, int TableNumber, int TotalTableNumber)
        {
            int iLen = 0;
            DataBuf[Start + iLen++] = 0x15;
            DataBuf[Start + iLen++] = 0x00;
            DataBuf[Start + iLen++] = 0x03;
            DataBuf[Start + iLen++] = 0x00;

            if ("打开1号门" == cmbValveCtrl.Text)
            {
                DataBuf[Start + iLen++] = 0x20;
            }
            else if ("打开2号门" == cmbValveCtrl.Text)
            {
                DataBuf[Start + iLen++] = 0x40;
            }
            else if ("打开1号和2号门" == cmbValveCtrl.Text)
            {
                DataBuf[Start + iLen++] = 0x60;
            }

            string strNewValveCtrl = cmbValveCtrl.SelectedIndex.ToString("D");
            if (strNewValveCtrl != strValveCtrl)
            {
                Common.XmlHelper.SetNodeValue(FrmMain.strConfigFile, "/Config/Parameter", "ValveCtrl", strNewValveCtrl);
            }
            return iLen;
        }
        public string GetResultString(byte[] DataBuf)
        {
            // 命令字(1)+节点地址(6)+转发结果(1)+开关成功标志(1)+失败原因(2)+场强值(1)
            if (DataBuf[0] != 0x03)
            {
                return null;
            }
            if (DataBuf.Length <= FrmMain.AddrLength + 1 + 1 + 2)
            {
                return null;
            }
            int iPos = 1 + FrmMain.AddrLength + 1;
            string strInfo = cmbValveCtrl.Text;
            if (DataBuf[iPos] == 0xAA)
            {
                strInfo += "开门成功";
            }
            else if (DataBuf[iPos] == 0xAB)
            {
                strInfo += "开门失败";
            }
            return strInfo;
        }
    }
}
