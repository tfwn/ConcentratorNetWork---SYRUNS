namespace SR6009_Concentrator_Tools
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusMainStrip = new System.Windows.Forms.StatusStrip();
            this.tsComPortInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLocalAddress = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.prgBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbCurState = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbCurTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddToForwardList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddToCmdList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.tbConcAddr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btReadConcAddr = new System.Windows.Forms.Button();
            this.scon1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btPortCtrl = new System.Windows.Forms.Button();
            this.cmbComType = new System.Windows.Forms.ComboBox();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.scon2 = new System.Windows.Forms.SplitContainer();
            this.scon3 = new System.Windows.Forms.SplitContainer();
            this.tbPageDocument = new System.Windows.Forms.TabControl();
            this.tbPageDoc = new System.Windows.Forms.TabPage();
            this.dgvDoc = new System.Windows.Forms.DataGridView();
            this.tbDataFwdResult = new System.Windows.Forms.TabPage();
            this.tbPageRec = new System.Windows.Forms.TabPage();
            this.rtbCommMsg = new System.Windows.Forms.RichTextBox();
            this.cntMenuStripCommInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAutoScroll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAutoClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.tbPageRecord = new System.Windows.Forms.TabControl();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.usbHidPort = new UsbLibrary.UsbHidPort(this.components);
            this.tbRdMeter = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbCurAddr = new System.Windows.Forms.TextBox();
            this.btSaveDataToXml = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.btReadAllCmdData = new System.Windows.Forms.Button();
            this.secondChannelNum = new System.Windows.Forms.NumericUpDown();
            this.btReadCmdData = new System.Windows.Forms.Button();
            this.btWSecondChannel = new System.Windows.Forms.Button();
            this.btRSecondChannel = new System.Windows.Forms.Button();
            this.gpbDataFwd = new System.Windows.Forms.GroupBox();
            this.cmbOperateCmd = new System.Windows.Forms.ComboBox();
            this.lbNodeAddrList = new System.Windows.Forms.Label();
            this.gpbFunList = new System.Windows.Forms.GroupBox();
            this.btRunCmd = new System.Windows.Forms.Button();
            this.cbRunNodeAddr = new System.Windows.Forms.ComboBox();
            this.btClearNodeAddr = new System.Windows.Forms.Button();
            this.gpbOption = new System.Windows.Forms.GroupBox();
            this.lbCmdNodeAddrList = new System.Windows.Forms.Label();
            this.cbRunCmdNodeAddr = new System.Windows.Forms.ComboBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.rdbOpenAutoChannel0 = new System.Windows.Forms.RadioButton();
            this.rdbOpenAutoChannel1 = new System.Windows.Forms.RadioButton();
            this.label33 = new System.Windows.Forms.Label();
            this.rdbOpenAutoChannel2 = new System.Windows.Forms.RadioButton();
            this.btClearCmdNodeAddr = new System.Windows.Forms.Button();
            this.btBatchWriteMeterCmd = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.rdbValveCtrl0 = new System.Windows.Forms.RadioButton();
            this.rdbValveCtrl1 = new System.Windows.Forms.RadioButton();
            this.label35 = new System.Windows.Forms.Label();
            this.rdbValveCtrl2 = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.cbChannelNum = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.rdbSetChannel0 = new System.Windows.Forms.RadioButton();
            this.rdbSetChannel1 = new System.Windows.Forms.RadioButton();
            this.label32 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label36 = new System.Windows.Forms.Label();
            this.rdbAutoSetChannel = new System.Windows.Forms.RadioButton();
            this.rdbManualSetChannel = new System.Windows.Forms.RadioButton();
            this.panel12 = new System.Windows.Forms.Panel();
            this.rdbRealTimeMeterRead0 = new System.Windows.Forms.RadioButton();
            this.rdbRealTimeMeterRead1 = new System.Windows.Forms.RadioButton();
            this.label34 = new System.Windows.Forms.Label();
            this.rdbRealTimeMeterRead2 = new System.Windows.Forms.RadioButton();
            this.panel15 = new System.Windows.Forms.Panel();
            this.rdbSettlementPrice1 = new System.Windows.Forms.RadioButton();
            this.label37 = new System.Windows.Forms.Label();
            this.tbSettlementPrice = new System.Windows.Forms.TextBox();
            this.rdbSettlementPrice2 = new System.Windows.Forms.RadioButton();
            this.label38 = new System.Windows.Forms.Label();
            this.tbDocRoute = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btWriteDoc = new System.Windows.Forms.Button();
            this.btReadDoc = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btReadDocFromDev = new System.Windows.Forms.Button();
            this.btWriteDocToDev = new System.Windows.Forms.Button();
            this.btFormatData = new System.Windows.Forms.Button();
            this.btFormatDoc = new System.Windows.Forms.Button();
            this.gpbNodeEdit = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tbCurNodeAddr = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbNewNodeAddr = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbNodeType = new System.Windows.Forms.ComboBox();
            this.btModifyNode = new System.Windows.Forms.Button();
            this.btDelNode = new System.Windows.Forms.Button();
            this.btCreatNewNode = new System.Windows.Forms.Button();
            this.btReadDevNodeCount = new System.Windows.Forms.Button();
            this.cbSyncWithConc = new System.Windows.Forms.CheckBox();
            this.tbGprsParam = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lbDot0 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbApn = new System.Windows.Forms.Label();
            this.tbServerIp12 = new System.Windows.Forms.TextBox();
            this.lbUsername = new System.Windows.Forms.Label();
            this.tbServerIp11 = new System.Windows.Forms.TextBox();
            this.tbServerIp13 = new System.Windows.Forms.TextBox();
            this.lbDot1 = new System.Windows.Forms.Label();
            this.tbServerPort1 = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lbPort0 = new System.Windows.Forms.Label();
            this.tbServerIp10 = new System.Windows.Forms.TextBox();
            this.tbServerPort0 = new System.Windows.Forms.TextBox();
            this.lbPort1 = new System.Windows.Forms.Label();
            this.tbApn = new System.Windows.Forms.TextBox();
            this.lbServerIP1 = new System.Windows.Forms.Label();
            this.tbServerIp00 = new System.Windows.Forms.TextBox();
            this.lbHeatBeat = new System.Windows.Forms.Label();
            this.lbDot02 = new System.Windows.Forms.Label();
            this.lbUnit = new System.Windows.Forms.Label();
            this.lbServerIP0 = new System.Windows.Forms.Label();
            this.tbServerIp01 = new System.Windows.Forms.TextBox();
            this.tbServerIp03 = new System.Windows.Forms.TextBox();
            this.tbServerIp02 = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.nudHeatBeat = new System.Windows.Forms.NumericUpDown();
            this.gpbGprsInfo = new System.Windows.Forms.GroupBox();
            this.rtbGprsMsg = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbGprsModle = new System.Windows.Forms.Label();
            this.lbConnectStatus = new System.Windows.Forms.Label();
            this.lbIMSI = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pgbGrpsRssi = new System.Windows.Forms.ProgressBar();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btSetGprsParam = new System.Windows.Forms.Button();
            this.btReadGprsParam = new System.Windows.Forms.Button();
            this.btReadGprsInfo = new System.Windows.Forms.Button();
            this.tbDevParam = new System.Windows.Forms.TabPage();
            this.btSetConcAddr = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNewConcAddr = new System.Windows.Forms.TextBox();
            this.btRestartDev = new System.Windows.Forms.Button();
            this.btReadDevVerInfo = new System.Windows.Forms.Button();
            this.btReadRtc = new System.Windows.Forms.Button();
            this.btSetRtc = new System.Windows.Forms.Button();
            this.cmbTimeType = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.btMemCheck = new System.Windows.Forms.Button();
            this.lbVerInfo = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.statusMainStrip.SuspendLayout();
            this.cmsMenu.SuspendLayout();
            this.scon1.Panel1.SuspendLayout();
            this.scon1.Panel2.SuspendLayout();
            this.scon1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.scon2.Panel1.SuspendLayout();
            this.scon2.Panel2.SuspendLayout();
            this.scon2.SuspendLayout();
            this.scon3.Panel1.SuspendLayout();
            this.scon3.Panel2.SuspendLayout();
            this.scon3.SuspendLayout();
            this.tbPageDocument.SuspendLayout();
            this.tbPageDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoc)).BeginInit();
            this.tbPageRec.SuspendLayout();
            this.cntMenuStripCommInfo.SuspendLayout();
            this.tbRdMeter.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondChannelNum)).BeginInit();
            this.gpbDataFwd.SuspendLayout();
            this.gpbOption.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel13.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbChannelNum)).BeginInit();
            this.panel14.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel15.SuspendLayout();
            this.tbDocRoute.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.gpbNodeEdit.SuspendLayout();
            this.tbGprsParam.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeatBeat)).BeginInit();
            this.gpbGprsInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tbDevParam.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusMainStrip
            // 
            this.statusMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsComPortInfo,
            this.toolStripStatusLabel2,
            this.tsLocalAddress,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3,
            this.prgBar,
            this.toolStripStatusLabel4,
            this.lbCurState,
            this.lbCurTime});
            this.statusMainStrip.Location = new System.Drawing.Point(3, 744);
            this.statusMainStrip.Name = "statusMainStrip";
            this.statusMainStrip.Size = new System.Drawing.Size(1437, 23);
            this.statusMainStrip.TabIndex = 1;
            this.statusMainStrip.Text = "statusStrip1";
            // 
            // tsComPortInfo
            // 
            this.tsComPortInfo.AutoSize = false;
            this.tsComPortInfo.Name = "tsComPortInfo";
            this.tsComPortInfo.Size = new System.Drawing.Size(300, 18);
            this.tsComPortInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(11, 18);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // tsLocalAddress
            // 
            this.tsLocalAddress.AutoSize = false;
            this.tsLocalAddress.Name = "tsLocalAddress";
            this.tsLocalAddress.Size = new System.Drawing.Size(200, 18);
            this.tsLocalAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(11, 18);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(68, 18);
            this.toolStripStatusLabel3.Text = "执行进度：";
            // 
            // prgBar
            // 
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(250, 17);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(59, 18);
            this.toolStripStatusLabel4.Text = "            |";
            // 
            // lbCurState
            // 
            this.lbCurState.Name = "lbCurState";
            this.lbCurState.Size = new System.Drawing.Size(465, 18);
            this.lbCurState.Spring = true;
            this.lbCurState.Text = "设备状态：通信端口关闭";
            this.lbCurState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCurTime
            // 
            this.lbCurTime.Name = "lbCurTime";
            this.lbCurTime.Size = new System.Drawing.Size(56, 18);
            this.lbCurTime.Text = "当前时间";
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddToForwardList,
            this.tsmiAddToCmdList,
            this.tsmiClearDocument});
            this.cmsMenu.Name = "cmsAddTask";
            this.cmsMenu.Size = new System.Drawing.Size(185, 70);
            this.cmsMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMenu_Opening);
            // 
            // tsmiAddToForwardList
            // 
            this.tsmiAddToForwardList.Name = "tsmiAddToForwardList";
            this.tsmiAddToForwardList.Size = new System.Drawing.Size(184, 22);
            this.tsmiAddToForwardList.Text = "添加到数据转发队列";
            this.tsmiAddToForwardList.Click += new System.EventHandler(this.tsmiAddToForwardList_Click);
            // 
            // tsmiAddToCmdList
            // 
            this.tsmiAddToCmdList.Name = "tsmiAddToCmdList";
            this.tsmiAddToCmdList.Size = new System.Drawing.Size(184, 22);
            this.tsmiAddToCmdList.Text = "添加到命令下发队列";
            this.tsmiAddToCmdList.Click += new System.EventHandler(this.tsmiAddToCmdList_Click);
            // 
            // tsmiClearDocument
            // 
            this.tsmiClearDocument.Name = "tsmiClearDocument";
            this.tsmiClearDocument.Size = new System.Drawing.Size(184, 22);
            this.tsmiClearDocument.Text = "清空所有档案";
            this.tsmiClearDocument.Click += new System.EventHandler(this.tsmiClearDocument_Click);
            // 
            // tbConcAddr
            // 
            this.tbConcAddr.Location = new System.Drawing.Point(617, 10);
            this.tbConcAddr.Name = "tbConcAddr";
            this.tbConcAddr.Size = new System.Drawing.Size(89, 20);
            this.tbConcAddr.TabIndex = 4;
            this.tbConcAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbConcAddr, "集中器编号为12位数字，不足12位时左边自动补零。");
            this.tbConcAddr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbConcAddr_KeyPress);
            this.tbConcAddr.Leave += new System.EventHandler(this.tbConcAddr_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(550, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "集中器编号";
            // 
            // btReadConcAddr
            // 
            this.btReadConcAddr.BackColor = System.Drawing.Color.Snow;
            this.btReadConcAddr.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btReadConcAddr.Location = new System.Drawing.Point(720, 9);
            this.btReadConcAddr.Name = "btReadConcAddr";
            this.btReadConcAddr.Size = new System.Drawing.Size(123, 23);
            this.btReadConcAddr.TabIndex = 0;
            this.btReadConcAddr.Text = "读取集中器编号";
            this.tipInfo.SetToolTip(this.btReadConcAddr, "读取集中器编号，在无线通信类型时需要手动输入集中器编号。");
            this.btReadConcAddr.UseVisualStyleBackColor = true;
            this.btReadConcAddr.Click += new System.EventHandler(this.btReadConcAddr_Click);
            // 
            // scon1
            // 
            this.scon1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scon1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scon1.IsSplitterFixed = true;
            this.scon1.Location = new System.Drawing.Point(3, 3);
            this.scon1.Name = "scon1";
            this.scon1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scon1.Panel1
            // 
            this.scon1.Panel1.BackColor = System.Drawing.Color.Snow;
            this.scon1.Panel1.Controls.Add(this.pictureBox1);
            this.scon1.Panel1.Controls.Add(this.label20);
            this.scon1.Panel1.Controls.Add(this.btPortCtrl);
            this.scon1.Panel1.Controls.Add(this.cmbComType);
            this.scon1.Panel1.Controls.Add(this.cmbPort);
            this.scon1.Panel1.Controls.Add(this.label1);
            this.scon1.Panel1.Controls.Add(this.tbConcAddr);
            this.scon1.Panel1.Controls.Add(this.label2);
            this.scon1.Panel1.Controls.Add(this.btReadConcAddr);
            // 
            // scon1.Panel2
            // 
            this.scon1.Panel2.BackColor = System.Drawing.Color.Snow;
            this.scon1.Panel2.Controls.Add(this.scon2);
            this.scon1.Panel2.Enabled = false;
            this.scon1.Size = new System.Drawing.Size(1437, 741);
            this.scon1.SplitterDistance = 43;
            this.scon1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Snow;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1114, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(321, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(198, 14);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 13);
            this.label20.TabIndex = 4;
            this.label20.Text = "通讯类型";
            // 
            // btPortCtrl
            // 
            this.btPortCtrl.Location = new System.Drawing.Point(380, 9);
            this.btPortCtrl.Name = "btPortCtrl";
            this.btPortCtrl.Size = new System.Drawing.Size(114, 23);
            this.btPortCtrl.TabIndex = 3;
            this.btPortCtrl.Text = "打开端口";
            this.tipInfo.SetToolTip(this.btPortCtrl, "打开或关闭通信端口。");
            this.btPortCtrl.UseVisualStyleBackColor = true;
            this.btPortCtrl.Click += new System.EventHandler(this.btPortCtrl_Click);
            // 
            // cmbComType
            // 
            this.cmbComType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComType.FormattingEnabled = true;
            this.cmbComType.Items.AddRange(new object[] {
            "串口通信",
            "无线通信",
            "485通信",
            "USB通信"});
            this.cmbComType.Location = new System.Drawing.Point(261, 10);
            this.cmbComType.Name = "cmbComType";
            this.cmbComType.Size = new System.Drawing.Size(85, 21);
            this.cmbComType.TabIndex = 2;
            this.tipInfo.SetToolTip(this.cmbComType, "选择通信类型。");
            // 
            // cmbPort
            // 
            this.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(87, 10);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(85, 21);
            this.cmbPort.TabIndex = 1;
            this.tipInfo.SetToolTip(this.cmbPort, "选择通信接口");
            this.cmbPort.SelectedIndexChanged += new System.EventHandler(this.cmbPort_SelectedIndexChanged);
            this.cmbPort.Click += new System.EventHandler(this.cmbPort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口选择";
            // 
            // scon2
            // 
            this.scon2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scon2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scon2.Location = new System.Drawing.Point(0, 0);
            this.scon2.Name = "scon2";
            // 
            // scon2.Panel1
            // 
            this.scon2.Panel1.Controls.Add(this.scon3);
            this.scon2.Panel1MinSize = 0;
            // 
            // scon2.Panel2
            // 
            this.scon2.Panel2.Controls.Add(this.tbPageRecord);
            this.scon2.Panel2MinSize = 0;
            this.scon2.Size = new System.Drawing.Size(1435, 692);
            this.scon2.SplitterDistance = 1338;
            this.scon2.TabIndex = 3;
            this.scon2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scon2_splitterMoved);
            // 
            // scon3
            // 
            this.scon3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scon3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scon3.IsSplitterFixed = true;
            this.scon3.Location = new System.Drawing.Point(0, 0);
            this.scon3.Name = "scon3";
            // 
            // scon3.Panel1
            // 
            this.scon3.Panel1.Controls.Add(this.tabControl);
            // 
            // scon3.Panel2
            // 
            this.scon3.Panel2.Controls.Add(this.tbPageDocument);
            this.scon3.Size = new System.Drawing.Size(1338, 692);
            this.scon3.SplitterDistance = 384;
            this.scon3.TabIndex = 2;
            // 
            // tbPageDocument
            // 
            this.tbPageDocument.Controls.Add(this.tbPageDoc);
            this.tbPageDocument.Controls.Add(this.tbDataFwdResult);
            this.tbPageDocument.Controls.Add(this.tbPageRec);
            this.tbPageDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPageDocument.ItemSize = new System.Drawing.Size(72, 18);
            this.tbPageDocument.Location = new System.Drawing.Point(0, 0);
            this.tbPageDocument.Name = "tbPageDocument";
            this.tbPageDocument.SelectedIndex = 0;
            this.tbPageDocument.Size = new System.Drawing.Size(950, 692);
            this.tbPageDocument.TabIndex = 0;
            // 
            // tbPageDoc
            // 
            this.tbPageDoc.BackColor = System.Drawing.Color.Snow;
            this.tbPageDoc.Controls.Add(this.dgvDoc);
            this.tbPageDoc.Location = new System.Drawing.Point(4, 22);
            this.tbPageDoc.Name = "tbPageDoc";
            this.tbPageDoc.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageDoc.Size = new System.Drawing.Size(942, 666);
            this.tbPageDoc.TabIndex = 0;
            this.tbPageDoc.Text = " 表具档案和抄表数据 ";
            // 
            // dgvDoc
            // 
            this.dgvDoc.AllowUserToAddRows = false;
            this.dgvDoc.AllowUserToDeleteRows = false;
            this.dgvDoc.AllowUserToOrderColumns = true;
            this.dgvDoc.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow;
            this.dgvDoc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDoc.BackgroundColor = System.Drawing.Color.Snow;
            this.dgvDoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDoc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDoc.ContextMenuStrip = this.cmsMenu;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDoc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDoc.GridColor = System.Drawing.Color.DarkGreen;
            this.dgvDoc.Location = new System.Drawing.Point(3, 3);
            this.dgvDoc.Name = "dgvDoc";
            this.dgvDoc.ReadOnly = true;
            this.dgvDoc.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDoc.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDoc.RowHeadersVisible = false;
            this.dgvDoc.RowHeadersWidth = 45;
            this.dgvDoc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDoc.RowTemplate.Height = 23;
            this.dgvDoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoc.ShowCellErrors = false;
            this.dgvDoc.ShowEditingIcon = false;
            this.dgvDoc.ShowRowErrors = false;
            this.dgvDoc.Size = new System.Drawing.Size(936, 660);
            this.dgvDoc.TabIndex = 0;
            this.dgvDoc.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvDoc_ColumnDisplayIndexChanged);
            this.dgvDoc.SelectionChanged += new System.EventHandler(this.dgvDoc_SelectionChanged);
            // 
            // tbDataFwdResult
            // 
            this.tbDataFwdResult.BackColor = System.Drawing.Color.Snow;
            this.tbDataFwdResult.Location = new System.Drawing.Point(4, 22);
            this.tbDataFwdResult.Name = "tbDataFwdResult";
            this.tbDataFwdResult.Padding = new System.Windows.Forms.Padding(3);
            this.tbDataFwdResult.Size = new System.Drawing.Size(942, 666);
            this.tbDataFwdResult.TabIndex = 2;
            this.tbDataFwdResult.Text = " 数据转发结果 ";
            // 
            // tbPageRec
            // 
            this.tbPageRec.Controls.Add(this.rtbCommMsg);
            this.tbPageRec.Location = new System.Drawing.Point(4, 22);
            this.tbPageRec.Name = "tbPageRec";
            this.tbPageRec.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageRec.Size = new System.Drawing.Size(942, 666);
            this.tbPageRec.TabIndex = 1;
            this.tbPageRec.Text = " 通信日志 ";
            this.tbPageRec.UseVisualStyleBackColor = true;
            // 
            // rtbCommMsg
            // 
            this.rtbCommMsg.BackColor = System.Drawing.Color.Snow;
            this.rtbCommMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbCommMsg.ContextMenuStrip = this.cntMenuStripCommInfo;
            this.rtbCommMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbCommMsg.Location = new System.Drawing.Point(3, 3);
            this.rtbCommMsg.Name = "rtbCommMsg";
            this.rtbCommMsg.ReadOnly = true;
            this.rtbCommMsg.Size = new System.Drawing.Size(936, 660);
            this.rtbCommMsg.TabIndex = 0;
            this.rtbCommMsg.Text = "";
            this.tipInfo.SetToolTip(this.rtbCommMsg, "和集中器通信的监控记录，右键进行相关操作。");
            // 
            // cntMenuStripCommInfo
            // 
            this.cntMenuStripCommInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAutoScroll,
            this.tsmiAutoClear,
            this.tsmiClearAll,
            this.tsmiSaveRecord});
            this.cntMenuStripCommInfo.Name = "cntMenuStripCommInfo";
            this.cntMenuStripCommInfo.Size = new System.Drawing.Size(125, 92);
            this.cntMenuStripCommInfo.Opening += new System.ComponentModel.CancelEventHandler(this.cntMenuStripCommInfo_Opening);
            // 
            // tsmiAutoScroll
            // 
            this.tsmiAutoScroll.Checked = true;
            this.tsmiAutoScroll.CheckOnClick = true;
            this.tsmiAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiAutoScroll.Name = "tsmiAutoScroll";
            this.tsmiAutoScroll.Size = new System.Drawing.Size(124, 22);
            this.tsmiAutoScroll.Text = "自动滚动";
            this.tsmiAutoScroll.Click += new System.EventHandler(this.tsmiAutoScroll_Click);
            // 
            // tsmiAutoClear
            // 
            this.tsmiAutoClear.CheckOnClick = true;
            this.tsmiAutoClear.Name = "tsmiAutoClear";
            this.tsmiAutoClear.Size = new System.Drawing.Size(124, 22);
            this.tsmiAutoClear.Text = "自动清空";
            this.tsmiAutoClear.Click += new System.EventHandler(this.tsmiAutoClear_Click);
            // 
            // tsmiClearAll
            // 
            this.tsmiClearAll.Name = "tsmiClearAll";
            this.tsmiClearAll.Size = new System.Drawing.Size(124, 22);
            this.tsmiClearAll.Text = "清空全部";
            this.tsmiClearAll.Click += new System.EventHandler(this.tsmiClearAll_Click);
            // 
            // tsmiSaveRecord
            // 
            this.tsmiSaveRecord.Name = "tsmiSaveRecord";
            this.tsmiSaveRecord.Size = new System.Drawing.Size(124, 22);
            this.tsmiSaveRecord.Text = "保存记录";
            this.tsmiSaveRecord.Click += new System.EventHandler(this.tsmiSaveRecord_Click);
            // 
            // tbPageRecord
            // 
            this.tbPageRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPageRecord.Location = new System.Drawing.Point(0, 0);
            this.tbPageRecord.Name = "tbPageRecord";
            this.tbPageRecord.SelectedIndex = 0;
            this.tbPageRecord.Size = new System.Drawing.Size(93, 692);
            this.tbPageRecord.TabIndex = 0;
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115200;
            this.serialPort.Parity = System.IO.Ports.Parity.Even;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tipInfo
            // 
            this.tipInfo.AutoPopDelay = 8000;
            this.tipInfo.ForeColor = System.Drawing.Color.Navy;
            this.tipInfo.InitialDelay = 500;
            this.tipInfo.ReshowDelay = 100;
            this.tipInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tipInfo.ToolTipTitle = "6009集中器调试工具";
            // 
            // openFileDlg
            // 
            this.openFileDlg.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // usbHidPort
            // 
            this.usbHidPort.ProductId = 81;
            this.usbHidPort.VendorId = 1105;
            this.usbHidPort.OnSpecifiedDeviceArrived += new System.EventHandler(this.usbHidPort_OnSpecifiedDeviceArrived);
            this.usbHidPort.OnSpecifiedDeviceRemoved += new System.EventHandler(this.usbHidPort_OnSpecifiedDeviceRemoved);
            this.usbHidPort.OnDataRecieved += new UsbLibrary.DataRecievedEventHandler(this.usbHidPort_OnDataRecieved);
            // 
            // tbRdMeter
            // 
            this.tbRdMeter.BackColor = System.Drawing.Color.Snow;
            this.tbRdMeter.Controls.Add(this.gpbOption);
            this.tbRdMeter.Controls.Add(this.gpbDataFwd);
            this.tbRdMeter.Controls.Add(this.groupBox5);
            this.tbRdMeter.Location = new System.Drawing.Point(4, 22);
            this.tbRdMeter.Name = "tbRdMeter";
            this.tbRdMeter.Size = new System.Drawing.Size(376, 666);
            this.tbRdMeter.TabIndex = 7;
            this.tbRdMeter.Text = " 数据抄读 ";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btRSecondChannel);
            this.groupBox5.Controls.Add(this.btWSecondChannel);
            this.groupBox5.Controls.Add(this.btReadCmdData);
            this.groupBox5.Controls.Add(this.secondChannelNum);
            this.groupBox5.Controls.Add(this.btReadAllCmdData);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.btSaveDataToXml);
            this.groupBox5.Controls.Add(this.tbCurAddr);
            this.groupBox5.Location = new System.Drawing.Point(13, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(352, 123);
            this.groupBox5.TabIndex = 58;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "读取集中器中抄表数据";
            // 
            // tbCurAddr
            // 
            this.tbCurAddr.Location = new System.Drawing.Point(66, 60);
            this.tbCurAddr.Name = "tbCurAddr";
            this.tbCurAddr.Size = new System.Drawing.Size(98, 20);
            this.tbCurAddr.TabIndex = 59;
            this.tbCurAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbCurAddr, "当前操作的表具地址，可以在节点档案中选择，也可以手动输入。");
            this.tbCurAddr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCurAddr_KeyPress);
            this.tbCurAddr.Leave += new System.EventHandler(this.tbCurAddr_Leave);
            // 
            // btSaveDataToXml
            // 
            this.btSaveDataToXml.Location = new System.Drawing.Point(180, 57);
            this.btSaveDataToXml.Name = "btSaveDataToXml";
            this.btSaveDataToXml.Size = new System.Drawing.Size(157, 23);
            this.btSaveDataToXml.TabIndex = 52;
            this.btSaveDataToXml.Text = "保存所有数据到Excel";
            this.tipInfo.SetToolTip(this.btSaveDataToXml, "保存当前所有数据到Excel文件中。");
            this.btSaveDataToXml.UseVisualStyleBackColor = true;
            this.btSaveDataToXml.Click += new System.EventHandler(this.btSaveDataToXml_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 13);
            this.label19.TabIndex = 74;
            this.label19.Text = "当前表具";
            // 
            // btReadAllCmdData
            // 
            this.btReadAllCmdData.Location = new System.Drawing.Point(180, 28);
            this.btReadAllCmdData.Name = "btReadAllCmdData";
            this.btReadAllCmdData.Size = new System.Drawing.Size(157, 23);
            this.btReadAllCmdData.TabIndex = 76;
            this.btReadAllCmdData.Text = "读全部表具下发命令数据";
            this.tipInfo.SetToolTip(this.btReadAllCmdData, "读取全部表具的定时定量数据。");
            this.btReadAllCmdData.UseVisualStyleBackColor = true;
            this.btReadAllCmdData.Click += new System.EventHandler(this.btReadAllCmdData_Click);
            // 
            // secondChannelNum
            // 
            this.secondChannelNum.BackColor = System.Drawing.Color.White;
            this.secondChannelNum.Location = new System.Drawing.Point(268, 94);
            this.secondChannelNum.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.secondChannelNum.Name = "secondChannelNum";
            this.secondChannelNum.ReadOnly = true;
            this.secondChannelNum.Size = new System.Drawing.Size(48, 20);
            this.secondChannelNum.TabIndex = 82;
            this.secondChannelNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.secondChannelNum, "信道号一般为 0 --- 9，默认为3");
            this.secondChannelNum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // btReadCmdData
            // 
            this.btReadCmdData.Location = new System.Drawing.Point(6, 28);
            this.btReadCmdData.Name = "btReadCmdData";
            this.btReadCmdData.Size = new System.Drawing.Size(157, 23);
            this.btReadCmdData.TabIndex = 75;
            this.btReadCmdData.Text = "读单个表具下发命令数据";
            this.tipInfo.SetToolTip(this.btReadCmdData, "读取单个表具的定时定量数据。");
            this.btReadCmdData.UseVisualStyleBackColor = true;
            this.btReadCmdData.Click += new System.EventHandler(this.btReadCmdData_Click);
            // 
            // btWSecondChannel
            // 
            this.btWSecondChannel.Location = new System.Drawing.Point(9, 94);
            this.btWSecondChannel.Name = "btWSecondChannel";
            this.btWSecondChannel.Size = new System.Drawing.Size(115, 23);
            this.btWSecondChannel.TabIndex = 83;
            this.btWSecondChannel.Text = "设置第二扫描信道";
            this.btWSecondChannel.UseVisualStyleBackColor = true;
            this.btWSecondChannel.Click += new System.EventHandler(this.btWSecondChannel_Click);
            // 
            // btRSecondChannel
            // 
            this.btRSecondChannel.Location = new System.Drawing.Point(130, 94);
            this.btRSecondChannel.Name = "btRSecondChannel";
            this.btRSecondChannel.Size = new System.Drawing.Size(115, 23);
            this.btRSecondChannel.TabIndex = 84;
            this.btRSecondChannel.Text = "读取第二扫描信道";
            this.btRSecondChannel.UseVisualStyleBackColor = true;
            this.btRSecondChannel.Click += new System.EventHandler(this.btRSecondChannel_Click);
            // 
            // gpbDataFwd
            // 
            this.gpbDataFwd.Controls.Add(this.btClearNodeAddr);
            this.gpbDataFwd.Controls.Add(this.cbRunNodeAddr);
            this.gpbDataFwd.Controls.Add(this.btRunCmd);
            this.gpbDataFwd.Controls.Add(this.gpbFunList);
            this.gpbDataFwd.Controls.Add(this.lbNodeAddrList);
            this.gpbDataFwd.Controls.Add(this.cmbOperateCmd);
            this.gpbDataFwd.Location = new System.Drawing.Point(13, 432);
            this.gpbDataFwd.Name = "gpbDataFwd";
            this.gpbDataFwd.Size = new System.Drawing.Size(352, 193);
            this.gpbDataFwd.TabIndex = 59;
            this.gpbDataFwd.TabStop = false;
            this.gpbDataFwd.Text = "集中器数据转发功能";
            this.tipInfo.SetToolTip(this.gpbDataFwd, "数据转发功能");
            // 
            // cmbOperateCmd
            // 
            this.cmbOperateCmd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperateCmd.FormattingEnabled = true;
            this.cmbOperateCmd.Items.AddRange(new object[] {
            "选择要执行的命令",
            "读取表具计量信息",
            "开门"});
            this.cmbOperateCmd.Location = new System.Drawing.Point(9, 20);
            this.cmbOperateCmd.Name = "cmbOperateCmd";
            this.cmbOperateCmd.Size = new System.Drawing.Size(157, 21);
            this.cmbOperateCmd.TabIndex = 0;
            this.tipInfo.SetToolTip(this.cmbOperateCmd, "选取数据转发的项目。");
            this.cmbOperateCmd.SelectedIndexChanged += new System.EventHandler(this.cmbOperateCmd_SelectedIndexChanged);
            // 
            // lbNodeAddrList
            // 
            this.lbNodeAddrList.AutoSize = true;
            this.lbNodeAddrList.Location = new System.Drawing.Point(9, 53);
            this.lbNodeAddrList.Name = "lbNodeAddrList";
            this.lbNodeAddrList.Size = new System.Drawing.Size(91, 13);
            this.lbNodeAddrList.TabIndex = 69;
            this.lbNodeAddrList.Text = "表具地址列表[0]";
            // 
            // gpbFunList
            // 
            this.gpbFunList.Location = new System.Drawing.Point(11, 77);
            this.gpbFunList.Name = "gpbFunList";
            this.gpbFunList.Size = new System.Drawing.Size(329, 103);
            this.gpbFunList.TabIndex = 70;
            this.gpbFunList.TabStop = false;
            this.gpbFunList.Text = "命令参数";
            // 
            // btRunCmd
            // 
            this.btRunCmd.Location = new System.Drawing.Point(184, 18);
            this.btRunCmd.Name = "btRunCmd";
            this.btRunCmd.Size = new System.Drawing.Size(156, 23);
            this.btRunCmd.TabIndex = 71;
            this.btRunCmd.Text = "执行命令";
            this.tipInfo.SetToolTip(this.btRunCmd, "执行该项数据转发功能。");
            this.btRunCmd.UseVisualStyleBackColor = true;
            this.btRunCmd.Click += new System.EventHandler(this.btRunCmd_Click);
            // 
            // cbRunNodeAddr
            // 
            this.cbRunNodeAddr.ContextMenuStrip = this.cmsMenu;
            this.cbRunNodeAddr.FormattingEnabled = true;
            this.cbRunNodeAddr.Location = new System.Drawing.Point(123, 49);
            this.cbRunNodeAddr.MaxDropDownItems = 10;
            this.cbRunNodeAddr.Name = "cbRunNodeAddr";
            this.cbRunNodeAddr.Size = new System.Drawing.Size(111, 21);
            this.cbRunNodeAddr.TabIndex = 0;
            this.cbRunNodeAddr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbRunNodeAddr_KeyPress);
            this.cbRunNodeAddr.Leave += new System.EventHandler(this.cbRunNodeAddr_Leave);
            // 
            // btClearNodeAddr
            // 
            this.btClearNodeAddr.Location = new System.Drawing.Point(251, 48);
            this.btClearNodeAddr.Name = "btClearNodeAddr";
            this.btClearNodeAddr.Size = new System.Drawing.Size(89, 23);
            this.btClearNodeAddr.TabIndex = 72;
            this.btClearNodeAddr.Text = "清空列表";
            this.tipInfo.SetToolTip(this.btClearNodeAddr, "执行该项数据转发功能。");
            this.btClearNodeAddr.UseVisualStyleBackColor = true;
            this.btClearNodeAddr.Click += new System.EventHandler(this.btClearNodeAddr_Click);
            // 
            // gpbOption
            // 
            this.gpbOption.Controls.Add(this.panel15);
            this.gpbOption.Controls.Add(this.panel12);
            this.gpbOption.Controls.Add(this.groupBox6);
            this.gpbOption.Controls.Add(this.panel13);
            this.gpbOption.Controls.Add(this.btBatchWriteMeterCmd);
            this.gpbOption.Controls.Add(this.btClearCmdNodeAddr);
            this.gpbOption.Controls.Add(this.panel11);
            this.gpbOption.Controls.Add(this.cbRunCmdNodeAddr);
            this.gpbOption.Controls.Add(this.lbCmdNodeAddrList);
            this.gpbOption.Location = new System.Drawing.Point(13, 137);
            this.gpbOption.Name = "gpbOption";
            this.gpbOption.Size = new System.Drawing.Size(352, 289);
            this.gpbOption.TabIndex = 77;
            this.gpbOption.TabStop = false;
            // 
            // lbCmdNodeAddrList
            // 
            this.lbCmdNodeAddrList.AutoSize = true;
            this.lbCmdNodeAddrList.Location = new System.Drawing.Point(11, 44);
            this.lbCmdNodeAddrList.Name = "lbCmdNodeAddrList";
            this.lbCmdNodeAddrList.Size = new System.Drawing.Size(91, 13);
            this.lbCmdNodeAddrList.TabIndex = 74;
            this.lbCmdNodeAddrList.Text = "表具地址列表[0]";
            // 
            // cbRunCmdNodeAddr
            // 
            this.cbRunCmdNodeAddr.ContextMenuStrip = this.cmsMenu;
            this.cbRunCmdNodeAddr.FormattingEnabled = true;
            this.cbRunCmdNodeAddr.Location = new System.Drawing.Point(111, 44);
            this.cbRunCmdNodeAddr.MaxDropDownItems = 10;
            this.cbRunCmdNodeAddr.Name = "cbRunCmdNodeAddr";
            this.cbRunCmdNodeAddr.Size = new System.Drawing.Size(128, 21);
            this.cbRunCmdNodeAddr.TabIndex = 73;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Controls.Add(this.rdbOpenAutoChannel2);
            this.panel11.Controls.Add(this.label33);
            this.panel11.Controls.Add(this.rdbOpenAutoChannel1);
            this.panel11.Controls.Add(this.rdbOpenAutoChannel0);
            this.panel11.Location = new System.Drawing.Point(13, 170);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(315, 22);
            this.panel11.TabIndex = 49;
            // 
            // rdbOpenAutoChannel0
            // 
            this.rdbOpenAutoChannel0.AutoSize = true;
            this.rdbOpenAutoChannel0.Location = new System.Drawing.Point(155, 3);
            this.rdbOpenAutoChannel0.Name = "rdbOpenAutoChannel0";
            this.rdbOpenAutoChannel0.Size = new System.Drawing.Size(49, 17);
            this.rdbOpenAutoChannel0.TabIndex = 32;
            this.rdbOpenAutoChannel0.TabStop = true;
            this.rdbOpenAutoChannel0.Text = "关闭";
            this.tipInfo.SetToolTip(this.rdbOpenAutoChannel0, "和表端通信时是否使用数据加密，用于对主机模块的控制。");
            this.rdbOpenAutoChannel0.UseVisualStyleBackColor = true;
            // 
            // rdbOpenAutoChannel1
            // 
            this.rdbOpenAutoChannel1.AutoSize = true;
            this.rdbOpenAutoChannel1.Location = new System.Drawing.Point(105, 3);
            this.rdbOpenAutoChannel1.Name = "rdbOpenAutoChannel1";
            this.rdbOpenAutoChannel1.Size = new System.Drawing.Size(49, 17);
            this.rdbOpenAutoChannel1.TabIndex = 31;
            this.rdbOpenAutoChannel1.TabStop = true;
            this.rdbOpenAutoChannel1.Text = "开启";
            this.tipInfo.SetToolTip(this.rdbOpenAutoChannel1, "和表端通信时是否使用数据加密，用于对主机模块的控制。");
            this.rdbOpenAutoChannel1.UseVisualStyleBackColor = true;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(3, 5);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(79, 13);
            this.label33.TabIndex = 4;
            this.label33.Text = "打开自动信道";
            // 
            // rdbOpenAutoChannel2
            // 
            this.rdbOpenAutoChannel2.AutoSize = true;
            this.rdbOpenAutoChannel2.Checked = true;
            this.rdbOpenAutoChannel2.Location = new System.Drawing.Point(210, 3);
            this.rdbOpenAutoChannel2.Name = "rdbOpenAutoChannel2";
            this.rdbOpenAutoChannel2.Size = new System.Drawing.Size(61, 17);
            this.rdbOpenAutoChannel2.TabIndex = 33;
            this.rdbOpenAutoChannel2.TabStop = true;
            this.rdbOpenAutoChannel2.Text = "不处理";
            this.rdbOpenAutoChannel2.UseVisualStyleBackColor = true;
            // 
            // btClearCmdNodeAddr
            // 
            this.btClearCmdNodeAddr.Location = new System.Drawing.Point(251, 39);
            this.btClearCmdNodeAddr.Name = "btClearCmdNodeAddr";
            this.btClearCmdNodeAddr.Size = new System.Drawing.Size(89, 23);
            this.btClearCmdNodeAddr.TabIndex = 76;
            this.btClearCmdNodeAddr.Text = "清空列表";
            this.tipInfo.SetToolTip(this.btClearCmdNodeAddr, "执行该项数据转发功能。");
            this.btClearCmdNodeAddr.UseVisualStyleBackColor = true;
            this.btClearCmdNodeAddr.Click += new System.EventHandler(this.btClearCmdNodeAddr_Click);
            // 
            // btBatchWriteMeterCmd
            // 
            this.btBatchWriteMeterCmd.Location = new System.Drawing.Point(184, 12);
            this.btBatchWriteMeterCmd.Name = "btBatchWriteMeterCmd";
            this.btBatchWriteMeterCmd.Size = new System.Drawing.Size(157, 23);
            this.btBatchWriteMeterCmd.TabIndex = 77;
            this.btBatchWriteMeterCmd.Text = "下发命令";
            this.tipInfo.SetToolTip(this.btBatchWriteMeterCmd, "执行下发命令功能。");
            this.btBatchWriteMeterCmd.UseVisualStyleBackColor = true;
            this.btBatchWriteMeterCmd.Click += new System.EventHandler(this.btBatchWriteMeterCmd_Click);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Transparent;
            this.panel13.Controls.Add(this.rdbValveCtrl2);
            this.panel13.Controls.Add(this.label35);
            this.panel13.Controls.Add(this.rdbValveCtrl1);
            this.panel13.Controls.Add(this.rdbValveCtrl0);
            this.panel13.Location = new System.Drawing.Point(13, 190);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(315, 22);
            this.panel13.TabIndex = 50;
            // 
            // rdbValveCtrl0
            // 
            this.rdbValveCtrl0.AutoSize = true;
            this.rdbValveCtrl0.Location = new System.Drawing.Point(155, 3);
            this.rdbValveCtrl0.Name = "rdbValveCtrl0";
            this.rdbValveCtrl0.Size = new System.Drawing.Size(49, 17);
            this.rdbValveCtrl0.TabIndex = 32;
            this.rdbValveCtrl0.TabStop = true;
            this.rdbValveCtrl0.Text = "关阀";
            this.tipInfo.SetToolTip(this.rdbValveCtrl0, "和表端通信时是否使用数据加密，用于对主机模块的控制。");
            this.rdbValveCtrl0.UseVisualStyleBackColor = true;
            // 
            // rdbValveCtrl1
            // 
            this.rdbValveCtrl1.AutoSize = true;
            this.rdbValveCtrl1.Location = new System.Drawing.Point(105, 3);
            this.rdbValveCtrl1.Name = "rdbValveCtrl1";
            this.rdbValveCtrl1.Size = new System.Drawing.Size(49, 17);
            this.rdbValveCtrl1.TabIndex = 31;
            this.rdbValveCtrl1.TabStop = true;
            this.rdbValveCtrl1.Text = "开阀";
            this.tipInfo.SetToolTip(this.rdbValveCtrl1, "和表端通信时是否使用数据加密，用于对主机模块的控制。");
            this.rdbValveCtrl1.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(3, 5);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(31, 13);
            this.label35.TabIndex = 4;
            this.label35.Text = "阀控";
            // 
            // rdbValveCtrl2
            // 
            this.rdbValveCtrl2.AutoSize = true;
            this.rdbValveCtrl2.Checked = true;
            this.rdbValveCtrl2.Location = new System.Drawing.Point(210, 3);
            this.rdbValveCtrl2.Name = "rdbValveCtrl2";
            this.rdbValveCtrl2.Size = new System.Drawing.Size(61, 17);
            this.rdbValveCtrl2.TabIndex = 33;
            this.rdbValveCtrl2.TabStop = true;
            this.rdbValveCtrl2.Text = "不处理";
            this.rdbValveCtrl2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.panel14);
            this.groupBox6.Controls.Add(this.panel10);
            this.groupBox6.Location = new System.Drawing.Point(7, 67);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(333, 79);
            this.groupBox6.TabIndex = 79;
            this.groupBox6.TabStop = false;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.Controls.Add(this.label32);
            this.panel10.Controls.Add(this.rdbSetChannel1);
            this.panel10.Controls.Add(this.rdbSetChannel0);
            this.panel10.Controls.Add(this.label30);
            this.panel10.Controls.Add(this.cbChannelNum);
            this.panel10.Location = new System.Drawing.Point(6, 48);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(316, 22);
            this.panel10.TabIndex = 48;
            // 
            // cbChannelNum
            // 
            this.cbChannelNum.BackColor = System.Drawing.Color.White;
            this.cbChannelNum.Location = new System.Drawing.Point(265, 0);
            this.cbChannelNum.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.cbChannelNum.Name = "cbChannelNum";
            this.cbChannelNum.ReadOnly = true;
            this.cbChannelNum.Size = new System.Drawing.Size(48, 20);
            this.cbChannelNum.TabIndex = 47;
            this.cbChannelNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.cbChannelNum, "信道号一般为 0 --- 9，默认为3");
            this.cbChannelNum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(216, 5);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(43, 13);
            this.label30.TabIndex = 46;
            this.label30.Text = "信道号";
            // 
            // rdbSetChannel0
            // 
            this.rdbSetChannel0.AutoSize = true;
            this.rdbSetChannel0.Checked = true;
            this.rdbSetChannel0.Location = new System.Drawing.Point(156, 3);
            this.rdbSetChannel0.Name = "rdbSetChannel0";
            this.rdbSetChannel0.Size = new System.Drawing.Size(49, 17);
            this.rdbSetChannel0.TabIndex = 32;
            this.rdbSetChannel0.TabStop = true;
            this.rdbSetChannel0.Text = "关闭";
            this.tipInfo.SetToolTip(this.rdbSetChannel0, "和表端通信时是否使用数据加密，用于对主机模块的控制。");
            this.rdbSetChannel0.UseVisualStyleBackColor = true;
            // 
            // rdbSetChannel1
            // 
            this.rdbSetChannel1.AutoSize = true;
            this.rdbSetChannel1.Location = new System.Drawing.Point(106, 1);
            this.rdbSetChannel1.Name = "rdbSetChannel1";
            this.rdbSetChannel1.Size = new System.Drawing.Size(49, 17);
            this.rdbSetChannel1.TabIndex = 31;
            this.rdbSetChannel1.TabStop = true;
            this.rdbSetChannel1.Text = "开启";
            this.tipInfo.SetToolTip(this.rdbSetChannel1, "和表端通信时是否使用数据加密，用于对主机模块的控制。");
            this.rdbSetChannel1.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(3, 5);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(55, 13);
            this.label32.TabIndex = 4;
            this.label32.Text = "设置信道";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Transparent;
            this.panel14.Controls.Add(this.rdbManualSetChannel);
            this.panel14.Controls.Add(this.rdbAutoSetChannel);
            this.panel14.Controls.Add(this.label36);
            this.panel14.Location = new System.Drawing.Point(6, 19);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(316, 31);
            this.panel14.TabIndex = 51;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(3, 8);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(91, 13);
            this.label36.TabIndex = 41;
            this.label36.Text = "信道号设置方式";
            // 
            // rdbAutoSetChannel
            // 
            this.rdbAutoSetChannel.AutoSize = true;
            this.rdbAutoSetChannel.ForeColor = System.Drawing.Color.Black;
            this.rdbAutoSetChannel.Location = new System.Drawing.Point(198, 6);
            this.rdbAutoSetChannel.Name = "rdbAutoSetChannel";
            this.rdbAutoSetChannel.Size = new System.Drawing.Size(73, 17);
            this.rdbAutoSetChannel.TabIndex = 43;
            this.rdbAutoSetChannel.TabStop = true;
            this.rdbAutoSetChannel.Text = "自动设置";
            this.tipInfo.SetToolTip(this.rdbAutoSetChannel, "集中器地址的最后一位就是需要修改的信道号");
            this.rdbAutoSetChannel.UseVisualStyleBackColor = true;
            // 
            // rdbManualSetChannel
            // 
            this.rdbManualSetChannel.AutoSize = true;
            this.rdbManualSetChannel.Checked = true;
            this.rdbManualSetChannel.ForeColor = System.Drawing.Color.Black;
            this.rdbManualSetChannel.Location = new System.Drawing.Point(119, 6);
            this.rdbManualSetChannel.Name = "rdbManualSetChannel";
            this.rdbManualSetChannel.Size = new System.Drawing.Size(73, 17);
            this.rdbManualSetChannel.TabIndex = 42;
            this.rdbManualSetChannel.TabStop = true;
            this.rdbManualSetChannel.Text = "手动设置";
            this.tipInfo.SetToolTip(this.rdbManualSetChannel, "通过下方的信道号设置通知集中器要修改的信道号");
            this.rdbManualSetChannel.UseVisualStyleBackColor = true;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Transparent;
            this.panel12.Controls.Add(this.rdbRealTimeMeterRead2);
            this.panel12.Controls.Add(this.label34);
            this.panel12.Controls.Add(this.rdbRealTimeMeterRead1);
            this.panel12.Controls.Add(this.rdbRealTimeMeterRead0);
            this.panel12.Location = new System.Drawing.Point(13, 211);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(315, 22);
            this.panel12.TabIndex = 80;
            // 
            // rdbRealTimeMeterRead0
            // 
            this.rdbRealTimeMeterRead0.AutoSize = true;
            this.rdbRealTimeMeterRead0.Location = new System.Drawing.Point(155, 3);
            this.rdbRealTimeMeterRead0.Name = "rdbRealTimeMeterRead0";
            this.rdbRealTimeMeterRead0.Size = new System.Drawing.Size(37, 17);
            this.rdbRealTimeMeterRead0.TabIndex = 32;
            this.rdbRealTimeMeterRead0.TabStop = true;
            this.rdbRealTimeMeterRead0.Text = "关";
            this.tipInfo.SetToolTip(this.rdbRealTimeMeterRead0, "和表端通信时是否使用数据加密，用于对主机模块的控制。");
            this.rdbRealTimeMeterRead0.UseVisualStyleBackColor = true;
            // 
            // rdbRealTimeMeterRead1
            // 
            this.rdbRealTimeMeterRead1.AutoSize = true;
            this.rdbRealTimeMeterRead1.Location = new System.Drawing.Point(105, 3);
            this.rdbRealTimeMeterRead1.Name = "rdbRealTimeMeterRead1";
            this.rdbRealTimeMeterRead1.Size = new System.Drawing.Size(37, 17);
            this.rdbRealTimeMeterRead1.TabIndex = 31;
            this.rdbRealTimeMeterRead1.TabStop = true;
            this.rdbRealTimeMeterRead1.Text = "开";
            this.tipInfo.SetToolTip(this.rdbRealTimeMeterRead1, "和表端通信时是否使用数据加密，用于对主机模块的控制。");
            this.rdbRealTimeMeterRead1.UseVisualStyleBackColor = true;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(3, 5);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(79, 13);
            this.label34.TabIndex = 4;
            this.label34.Text = "开关实时抄表";
            // 
            // rdbRealTimeMeterRead2
            // 
            this.rdbRealTimeMeterRead2.AutoSize = true;
            this.rdbRealTimeMeterRead2.Checked = true;
            this.rdbRealTimeMeterRead2.Location = new System.Drawing.Point(210, 3);
            this.rdbRealTimeMeterRead2.Name = "rdbRealTimeMeterRead2";
            this.rdbRealTimeMeterRead2.Size = new System.Drawing.Size(61, 17);
            this.rdbRealTimeMeterRead2.TabIndex = 33;
            this.rdbRealTimeMeterRead2.TabStop = true;
            this.rdbRealTimeMeterRead2.Text = "不处理";
            this.rdbRealTimeMeterRead2.UseVisualStyleBackColor = true;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.Transparent;
            this.panel15.Controls.Add(this.label38);
            this.panel15.Controls.Add(this.rdbSettlementPrice2);
            this.panel15.Controls.Add(this.tbSettlementPrice);
            this.panel15.Controls.Add(this.label37);
            this.panel15.Controls.Add(this.rdbSettlementPrice1);
            this.panel15.Location = new System.Drawing.Point(13, 232);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(315, 22);
            this.panel15.TabIndex = 81;
            // 
            // rdbSettlementPrice1
            // 
            this.rdbSettlementPrice1.AutoSize = true;
            this.rdbSettlementPrice1.Location = new System.Drawing.Point(155, 3);
            this.rdbSettlementPrice1.Name = "rdbSettlementPrice1";
            this.rdbSettlementPrice1.Size = new System.Drawing.Size(49, 17);
            this.rdbSettlementPrice1.TabIndex = 32;
            this.rdbSettlementPrice1.TabStop = true;
            this.rdbSettlementPrice1.Text = "结算";
            this.tipInfo.SetToolTip(this.rdbSettlementPrice1, "和表端通信时是否使用数据加密，用于对主机模块的控制。");
            this.rdbSettlementPrice1.UseVisualStyleBackColor = true;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(3, 5);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(55, 13);
            this.label37.TabIndex = 4;
            this.label37.Text = "结算价格";
            // 
            // tbSettlementPrice
            // 
            this.tbSettlementPrice.Location = new System.Drawing.Point(64, 0);
            this.tbSettlementPrice.Name = "tbSettlementPrice";
            this.tbSettlementPrice.Size = new System.Drawing.Size(57, 20);
            this.tbSettlementPrice.TabIndex = 82;
            // 
            // rdbSettlementPrice2
            // 
            this.rdbSettlementPrice2.AutoSize = true;
            this.rdbSettlementPrice2.Checked = true;
            this.rdbSettlementPrice2.Location = new System.Drawing.Point(210, 3);
            this.rdbSettlementPrice2.Name = "rdbSettlementPrice2";
            this.rdbSettlementPrice2.Size = new System.Drawing.Size(61, 17);
            this.rdbSettlementPrice2.TabIndex = 33;
            this.rdbSettlementPrice2.TabStop = true;
            this.rdbSettlementPrice2.Text = "不处理";
            this.rdbSettlementPrice2.UseVisualStyleBackColor = true;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(123, 5);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(19, 13);
            this.label38.TabIndex = 83;
            this.label38.Text = "元";
            // 
            // tbDocRoute
            // 
            this.tbDocRoute.BackColor = System.Drawing.Color.Snow;
            this.tbDocRoute.Controls.Add(this.gpbNodeEdit);
            this.tbDocRoute.Controls.Add(this.groupBox7);
            this.tbDocRoute.Controls.Add(this.groupBox4);
            this.tbDocRoute.Location = new System.Drawing.Point(4, 22);
            this.tbDocRoute.Name = "tbDocRoute";
            this.tbDocRoute.Padding = new System.Windows.Forms.Padding(3);
            this.tbDocRoute.Size = new System.Drawing.Size(376, 666);
            this.tbDocRoute.TabIndex = 5;
            this.tbDocRoute.Text = " 档案和路由 ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btReadDoc);
            this.groupBox4.Controls.Add(this.btWriteDoc);
            this.groupBox4.Location = new System.Drawing.Point(13, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(352, 51);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "档案文件读写";
            // 
            // btWriteDoc
            // 
            this.btWriteDoc.Location = new System.Drawing.Point(183, 18);
            this.btWriteDoc.Name = "btWriteDoc";
            this.btWriteDoc.Size = new System.Drawing.Size(157, 23);
            this.btWriteDoc.TabIndex = 48;
            this.btWriteDoc.Text = "保存档案到文件";
            this.tipInfo.SetToolTip(this.btWriteDoc, "保存表具档案信息到文件中。");
            this.btWriteDoc.UseVisualStyleBackColor = true;
            this.btWriteDoc.Click += new System.EventHandler(this.btWriteDoc_Click);
            // 
            // btReadDoc
            // 
            this.btReadDoc.Location = new System.Drawing.Point(9, 18);
            this.btReadDoc.Name = "btReadDoc";
            this.btReadDoc.Size = new System.Drawing.Size(157, 23);
            this.btReadDoc.TabIndex = 47;
            this.btReadDoc.Text = "从文件中读取档案";
            this.tipInfo.SetToolTip(this.btReadDoc, "从文件中读取表具档案，如果表具档案没有类型信息，则默认为“冷水表”。");
            this.btReadDoc.UseVisualStyleBackColor = true;
            this.btReadDoc.Click += new System.EventHandler(this.btReadDoc_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btFormatDoc);
            this.groupBox7.Controls.Add(this.btFormatData);
            this.groupBox7.Controls.Add(this.btWriteDocToDev);
            this.groupBox7.Controls.Add(this.btReadDocFromDev);
            this.groupBox7.Location = new System.Drawing.Point(13, 65);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(352, 86);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "设备档案操作";
            // 
            // btReadDocFromDev
            // 
            this.btReadDocFromDev.Location = new System.Drawing.Point(9, 20);
            this.btReadDocFromDev.Name = "btReadDocFromDev";
            this.btReadDocFromDev.Size = new System.Drawing.Size(157, 23);
            this.btReadDocFromDev.TabIndex = 49;
            this.btReadDocFromDev.Text = "从设备中读取档案";
            this.tipInfo.SetToolTip(this.btReadDocFromDev, "从集中器中读取表具档案信息。");
            this.btReadDocFromDev.UseVisualStyleBackColor = true;
            this.btReadDocFromDev.Click += new System.EventHandler(this.btReadDocFromDev_Click);
            // 
            // btWriteDocToDev
            // 
            this.btWriteDocToDev.Location = new System.Drawing.Point(183, 20);
            this.btWriteDocToDev.Name = "btWriteDocToDev";
            this.btWriteDocToDev.Size = new System.Drawing.Size(157, 23);
            this.btWriteDocToDev.TabIndex = 50;
            this.btWriteDocToDev.Text = "保存档案到设备";
            this.tipInfo.SetToolTip(this.btWriteDocToDev, "保存当前档案信息到集中器中。");
            this.btWriteDocToDev.UseVisualStyleBackColor = true;
            this.btWriteDocToDev.Click += new System.EventHandler(this.btWriteDocToDev_Click);
            // 
            // btFormatData
            // 
            this.btFormatData.Location = new System.Drawing.Point(183, 49);
            this.btFormatData.Name = "btFormatData";
            this.btFormatData.Size = new System.Drawing.Size(157, 23);
            this.btFormatData.TabIndex = 52;
            this.btFormatData.Text = "数据初始化";
            this.tipInfo.SetToolTip(this.btFormatData, "删除全部表具抄表信息。");
            this.btFormatData.UseVisualStyleBackColor = true;
            this.btFormatData.Click += new System.EventHandler(this.btFormatData_Click);
            // 
            // btFormatDoc
            // 
            this.btFormatDoc.Location = new System.Drawing.Point(9, 49);
            this.btFormatDoc.Name = "btFormatDoc";
            this.btFormatDoc.Size = new System.Drawing.Size(157, 23);
            this.btFormatDoc.TabIndex = 51;
            this.btFormatDoc.Text = "档案初始化";
            this.tipInfo.SetToolTip(this.btFormatDoc, "删除全部档案和路由信息。");
            this.btFormatDoc.UseVisualStyleBackColor = true;
            this.btFormatDoc.Click += new System.EventHandler(this.btFormatDoc_Click);
            // 
            // gpbNodeEdit
            // 
            this.gpbNodeEdit.Controls.Add(this.cbSyncWithConc);
            this.gpbNodeEdit.Controls.Add(this.btReadDevNodeCount);
            this.gpbNodeEdit.Controls.Add(this.btCreatNewNode);
            this.gpbNodeEdit.Controls.Add(this.btDelNode);
            this.gpbNodeEdit.Controls.Add(this.btModifyNode);
            this.gpbNodeEdit.Controls.Add(this.cmbNodeType);
            this.gpbNodeEdit.Controls.Add(this.label22);
            this.gpbNodeEdit.Controls.Add(this.tbNewNodeAddr);
            this.gpbNodeEdit.Controls.Add(this.label23);
            this.gpbNodeEdit.Controls.Add(this.tbCurNodeAddr);
            this.gpbNodeEdit.Controls.Add(this.label24);
            this.gpbNodeEdit.Location = new System.Drawing.Point(13, 184);
            this.gpbNodeEdit.Name = "gpbNodeEdit";
            this.gpbNodeEdit.Size = new System.Drawing.Size(352, 451);
            this.gpbNodeEdit.TabIndex = 4;
            this.gpbNodeEdit.TabStop = false;
            this.gpbNodeEdit.Text = "当前表具编辑";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(196, 111);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(55, 13);
            this.label24.TabIndex = 71;
            this.label24.Text = "表具类型";
            // 
            // tbCurNodeAddr
            // 
            this.tbCurNodeAddr.Location = new System.Drawing.Point(251, 49);
            this.tbCurNodeAddr.Name = "tbCurNodeAddr";
            this.tbCurNodeAddr.Size = new System.Drawing.Size(89, 20);
            this.tbCurNodeAddr.TabIndex = 58;
            this.tbCurNodeAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbCurNodeAddr, "当前操作的表具地址，可以在节点档案中选择，也可以手动输入。");
            this.tbCurNodeAddr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCurNodeAddr_KeyPress);
            this.tbCurNodeAddr.Leave += new System.EventHandler(this.tbCurNodeAddr_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(184, 82);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(67, 13);
            this.label23.TabIndex = 69;
            this.label23.Text = "新表具地址";
            // 
            // tbNewNodeAddr
            // 
            this.tbNewNodeAddr.Location = new System.Drawing.Point(251, 78);
            this.tbNewNodeAddr.Name = "tbNewNodeAddr";
            this.tbNewNodeAddr.Size = new System.Drawing.Size(89, 20);
            this.tbNewNodeAddr.TabIndex = 68;
            this.tbNewNodeAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbNewNodeAddr, "新表具地址，用于修改当前的表具信息。");
            this.tbNewNodeAddr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNewNodeAddr_KeyPress);
            this.tbNewNodeAddr.Leave += new System.EventHandler(this.tbNewNodeAddr_Leave);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(172, 53);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 13);
            this.label22.TabIndex = 67;
            this.label22.Text = "当前表具地址";
            // 
            // cmbNodeType
            // 
            this.cmbNodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeType.FormattingEnabled = true;
            this.cmbNodeType.Location = new System.Drawing.Point(251, 107);
            this.cmbNodeType.Name = "cmbNodeType";
            this.cmbNodeType.Size = new System.Drawing.Size(89, 21);
            this.cmbNodeType.TabIndex = 70;
            this.tipInfo.SetToolTip(this.cmbNodeType, "表具类型信息。");
            // 
            // btModifyNode
            // 
            this.btModifyNode.Location = new System.Drawing.Point(9, 106);
            this.btModifyNode.Name = "btModifyNode";
            this.btModifyNode.Size = new System.Drawing.Size(157, 23);
            this.btModifyNode.TabIndex = 56;
            this.btModifyNode.Text = "修改档案";
            this.tipInfo.SetToolTip(this.btModifyNode, "修改当前表具档案。");
            this.btModifyNode.UseVisualStyleBackColor = true;
            this.btModifyNode.Click += new System.EventHandler(this.btModifyNode_Click);
            // 
            // btDelNode
            // 
            this.btDelNode.Location = new System.Drawing.Point(9, 77);
            this.btDelNode.Name = "btDelNode";
            this.btDelNode.Size = new System.Drawing.Size(157, 23);
            this.btDelNode.TabIndex = 55;
            this.btDelNode.Text = "删除档案";
            this.tipInfo.SetToolTip(this.btDelNode, "删除一个表具档案。");
            this.btDelNode.UseVisualStyleBackColor = true;
            this.btDelNode.Click += new System.EventHandler(this.btDelNode_Click);
            // 
            // btCreatNewNode
            // 
            this.btCreatNewNode.Location = new System.Drawing.Point(9, 48);
            this.btCreatNewNode.Name = "btCreatNewNode";
            this.btCreatNewNode.Size = new System.Drawing.Size(157, 23);
            this.btCreatNewNode.TabIndex = 54;
            this.btCreatNewNode.Text = "新建档案";
            this.tipInfo.SetToolTip(this.btCreatNewNode, "新建一个表具档案。");
            this.btCreatNewNode.UseVisualStyleBackColor = true;
            this.btCreatNewNode.Click += new System.EventHandler(this.btCreatNewNode_Click);
            // 
            // btReadDevNodeCount
            // 
            this.btReadDevNodeCount.Location = new System.Drawing.Point(9, 19);
            this.btReadDevNodeCount.Name = "btReadDevNodeCount";
            this.btReadDevNodeCount.Size = new System.Drawing.Size(157, 23);
            this.btReadDevNodeCount.TabIndex = 53;
            this.btReadDevNodeCount.Text = "读取设备中档案数量";
            this.tipInfo.SetToolTip(this.btReadDevNodeCount, "读取集中器中所有表具的数量。");
            this.btReadDevNodeCount.UseVisualStyleBackColor = true;
            this.btReadDevNodeCount.Click += new System.EventHandler(this.btReadDevNodeCount_Click);
            // 
            // cbSyncWithConc
            // 
            this.cbSyncWithConc.AutoSize = true;
            this.cbSyncWithConc.Location = new System.Drawing.Point(186, 22);
            this.cbSyncWithConc.Name = "cbSyncWithConc";
            this.cbSyncWithConc.Size = new System.Drawing.Size(146, 17);
            this.cbSyncWithConc.TabIndex = 72;
            this.cbSyncWithConc.Text = "档案变动和集中器同步";
            this.tipInfo.SetToolTip(this.cbSyncWithConc, "勾选后，新建档案、删除档案和修改档案将会同步到集中器中，否则只是在文档中编辑。\r\n该操作不影响集中器中的路由信息。");
            this.cbSyncWithConc.UseVisualStyleBackColor = true;
            // 
            // tbGprsParam
            // 
            this.tbGprsParam.BackColor = System.Drawing.Color.Snow;
            this.tbGprsParam.Controls.Add(this.btReadGprsInfo);
            this.tbGprsParam.Controls.Add(this.btReadGprsParam);
            this.tbGprsParam.Controls.Add(this.btSetGprsParam);
            this.tbGprsParam.Controls.Add(this.groupBox3);
            this.tbGprsParam.Controls.Add(this.gpbGprsInfo);
            this.tbGprsParam.Controls.Add(this.groupBox2);
            this.tbGprsParam.Location = new System.Drawing.Point(4, 22);
            this.tbGprsParam.Name = "tbGprsParam";
            this.tbGprsParam.Padding = new System.Windows.Forms.Padding(3);
            this.tbGprsParam.Size = new System.Drawing.Size(376, 666);
            this.tbGprsParam.TabIndex = 4;
            this.tbGprsParam.Text = " Gprs参数 ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudHeatBeat);
            this.groupBox2.Controls.Add(this.tbPassword);
            this.groupBox2.Controls.Add(this.lbPassword);
            this.groupBox2.Controls.Add(this.tbServerIp02);
            this.groupBox2.Controls.Add(this.tbServerIp03);
            this.groupBox2.Controls.Add(this.tbServerIp01);
            this.groupBox2.Controls.Add(this.lbServerIP0);
            this.groupBox2.Controls.Add(this.lbUnit);
            this.groupBox2.Controls.Add(this.lbDot02);
            this.groupBox2.Controls.Add(this.lbHeatBeat);
            this.groupBox2.Controls.Add(this.tbServerIp00);
            this.groupBox2.Controls.Add(this.lbServerIP1);
            this.groupBox2.Controls.Add(this.tbApn);
            this.groupBox2.Controls.Add(this.lbPort1);
            this.groupBox2.Controls.Add(this.tbServerPort0);
            this.groupBox2.Controls.Add(this.tbServerIp10);
            this.groupBox2.Controls.Add(this.lbPort0);
            this.groupBox2.Controls.Add(this.tbUsername);
            this.groupBox2.Controls.Add(this.tbServerPort1);
            this.groupBox2.Controls.Add(this.lbDot1);
            this.groupBox2.Controls.Add(this.tbServerIp13);
            this.groupBox2.Controls.Add(this.tbServerIp11);
            this.groupBox2.Controls.Add(this.lbUsername);
            this.groupBox2.Controls.Add(this.tbServerIp12);
            this.groupBox2.Controls.Add(this.lbApn);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lbDot0);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(13, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 186);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(126, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 14);
            this.label14.TabIndex = 62;
            this.label14.Text = ".";
            // 
            // lbDot0
            // 
            this.lbDot0.AutoSize = true;
            this.lbDot0.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDot0.Location = new System.Drawing.Point(126, 16);
            this.lbDot0.Name = "lbDot0";
            this.lbDot0.Size = new System.Drawing.Size(14, 14);
            this.lbDot0.TabIndex = 53;
            this.lbDot0.Text = ".";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(198, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 14);
            this.label13.TabIndex = 64;
            this.label13.Text = ".";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(162, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 14);
            this.label12.TabIndex = 63;
            this.label12.Text = ".";
            // 
            // lbApn
            // 
            this.lbApn.AutoSize = true;
            this.lbApn.Location = new System.Drawing.Point(6, 102);
            this.lbApn.Name = "lbApn";
            this.lbApn.Size = new System.Drawing.Size(53, 13);
            this.lbApn.TabIndex = 36;
            this.lbApn.Text = "APN接口";
            // 
            // tbServerIp12
            // 
            this.tbServerIp12.Location = new System.Drawing.Point(170, 41);
            this.tbServerIp12.Name = "tbServerIp12";
            this.tbServerIp12.Size = new System.Drawing.Size(30, 20);
            this.tbServerIp12.TabIndex = 45;
            this.tbServerIp12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbServerIp12, "备用服务器IP地址。");
            this.tbServerIp12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbServerIp_KeyPress);
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(6, 131);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(43, 13);
            this.lbUsername.TabIndex = 38;
            this.lbUsername.Text = "用户名";
            // 
            // tbServerIp11
            // 
            this.tbServerIp11.Location = new System.Drawing.Point(134, 41);
            this.tbServerIp11.Name = "tbServerIp11";
            this.tbServerIp11.Size = new System.Drawing.Size(30, 20);
            this.tbServerIp11.TabIndex = 44;
            this.tbServerIp11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbServerIp11, "备用服务器IP地址。");
            this.tbServerIp11.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbServerIp_KeyPress);
            // 
            // tbServerIp13
            // 
            this.tbServerIp13.Location = new System.Drawing.Point(206, 41);
            this.tbServerIp13.Name = "tbServerIp13";
            this.tbServerIp13.Size = new System.Drawing.Size(30, 20);
            this.tbServerIp13.TabIndex = 47;
            this.tbServerIp13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbServerIp13, "备用服务器IP地址。");
            this.tbServerIp13.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbServerIp_KeyPress);
            // 
            // lbDot1
            // 
            this.lbDot1.AutoSize = true;
            this.lbDot1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDot1.Location = new System.Drawing.Point(162, 16);
            this.lbDot1.Name = "lbDot1";
            this.lbDot1.Size = new System.Drawing.Size(14, 14);
            this.lbDot1.TabIndex = 55;
            this.lbDot1.Text = ".";
            // 
            // tbServerPort1
            // 
            this.tbServerPort1.Location = new System.Drawing.Point(283, 43);
            this.tbServerPort1.Name = "tbServerPort1";
            this.tbServerPort1.Size = new System.Drawing.Size(57, 20);
            this.tbServerPort1.TabIndex = 48;
            this.tbServerPort1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbServerPort1, "备用服务器连接端口。");
            this.tbServerPort1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbServerPort_KeyPress);
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(98, 127);
            this.tbUsername.MaxLength = 12;
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(177, 20);
            this.tbUsername.TabIndex = 52;
            this.tbUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbUsername, "连接运营商时使用的用户名。");
            this.tbUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbApnInfo_KeyPress);
            // 
            // lbPort0
            // 
            this.lbPort0.AutoSize = true;
            this.lbPort0.Location = new System.Drawing.Point(246, 17);
            this.lbPort0.Name = "lbPort0";
            this.lbPort0.Size = new System.Drawing.Size(31, 13);
            this.lbPort0.TabIndex = 35;
            this.lbPort0.Text = "端口";
            // 
            // tbServerIp10
            // 
            this.tbServerIp10.Location = new System.Drawing.Point(98, 41);
            this.tbServerIp10.Name = "tbServerIp10";
            this.tbServerIp10.Size = new System.Drawing.Size(30, 20);
            this.tbServerIp10.TabIndex = 43;
            this.tbServerIp10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbServerIp10, "备用服务器IP地址。");
            this.tbServerIp10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbServerIp_KeyPress);
            // 
            // tbServerPort0
            // 
            this.tbServerPort0.Location = new System.Drawing.Point(283, 13);
            this.tbServerPort0.Name = "tbServerPort0";
            this.tbServerPort0.Size = new System.Drawing.Size(57, 20);
            this.tbServerPort0.TabIndex = 42;
            this.tbServerPort0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbServerPort0, "首选服务器连接端口。");
            this.tbServerPort0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbServerPort_KeyPress);
            // 
            // lbPort1
            // 
            this.lbPort1.AutoSize = true;
            this.lbPort1.Location = new System.Drawing.Point(246, 50);
            this.lbPort1.Name = "lbPort1";
            this.lbPort1.Size = new System.Drawing.Size(31, 13);
            this.lbPort1.TabIndex = 61;
            this.lbPort1.Text = "端口";
            // 
            // tbApn
            // 
            this.tbApn.Location = new System.Drawing.Point(98, 98);
            this.tbApn.MaxLength = 12;
            this.tbApn.Name = "tbApn";
            this.tbApn.Size = new System.Drawing.Size(177, 20);
            this.tbApn.TabIndex = 51;
            this.tbApn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbApn, "连接运营商时使用的接口。");
            this.tbApn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbApnInfo_KeyPress);
            // 
            // lbServerIP1
            // 
            this.lbServerIP1.AutoSize = true;
            this.lbServerIP1.Location = new System.Drawing.Point(6, 45);
            this.lbServerIP1.Name = "lbServerIP1";
            this.lbServerIP1.Size = new System.Drawing.Size(91, 13);
            this.lbServerIP1.TabIndex = 60;
            this.lbServerIP1.Text = "备用服务器地址";
            // 
            // tbServerIp00
            // 
            this.tbServerIp00.Location = new System.Drawing.Point(98, 13);
            this.tbServerIp00.Name = "tbServerIp00";
            this.tbServerIp00.Size = new System.Drawing.Size(30, 20);
            this.tbServerIp00.TabIndex = 34;
            this.tbServerIp00.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbServerIp00, "首选服务器IP地址。");
            this.tbServerIp00.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbServerIp_KeyPress);
            // 
            // lbHeatBeat
            // 
            this.lbHeatBeat.AutoSize = true;
            this.lbHeatBeat.Location = new System.Drawing.Point(6, 73);
            this.lbHeatBeat.Name = "lbHeatBeat";
            this.lbHeatBeat.Size = new System.Drawing.Size(67, 13);
            this.lbHeatBeat.TabIndex = 65;
            this.lbHeatBeat.Text = "心跳包间隔";
            // 
            // lbDot02
            // 
            this.lbDot02.AutoSize = true;
            this.lbDot02.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDot02.Location = new System.Drawing.Point(198, 16);
            this.lbDot02.Name = "lbDot02";
            this.lbDot02.Size = new System.Drawing.Size(14, 14);
            this.lbDot02.TabIndex = 57;
            this.lbDot02.Text = ".";
            // 
            // lbUnit
            // 
            this.lbUnit.AutoSize = true;
            this.lbUnit.Location = new System.Drawing.Point(165, 73);
            this.lbUnit.Name = "lbUnit";
            this.lbUnit.Size = new System.Drawing.Size(19, 13);
            this.lbUnit.TabIndex = 66;
            this.lbUnit.Text = "秒";
            // 
            // lbServerIP0
            // 
            this.lbServerIP0.AutoSize = true;
            this.lbServerIP0.Location = new System.Drawing.Point(6, 17);
            this.lbServerIP0.Name = "lbServerIP0";
            this.lbServerIP0.Size = new System.Drawing.Size(91, 13);
            this.lbServerIP0.TabIndex = 33;
            this.lbServerIP0.Text = "首选服务器地址";
            this.tipInfo.SetToolTip(this.lbServerIP0, "首选服务器IP地址。");
            // 
            // tbServerIp01
            // 
            this.tbServerIp01.Location = new System.Drawing.Point(134, 13);
            this.tbServerIp01.Name = "tbServerIp01";
            this.tbServerIp01.Size = new System.Drawing.Size(30, 20);
            this.tbServerIp01.TabIndex = 37;
            this.tbServerIp01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbServerIp01, "首选服务器IP地址。");
            this.tbServerIp01.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbServerIp_KeyPress);
            // 
            // tbServerIp03
            // 
            this.tbServerIp03.Location = new System.Drawing.Point(206, 13);
            this.tbServerIp03.Name = "tbServerIp03";
            this.tbServerIp03.Size = new System.Drawing.Size(30, 20);
            this.tbServerIp03.TabIndex = 40;
            this.tbServerIp03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbServerIp03, "首选服务器IP地址。");
            this.tbServerIp03.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbServerIp_KeyPress);
            // 
            // tbServerIp02
            // 
            this.tbServerIp02.Location = new System.Drawing.Point(170, 13);
            this.tbServerIp02.Name = "tbServerIp02";
            this.tbServerIp02.Size = new System.Drawing.Size(30, 20);
            this.tbServerIp02.TabIndex = 39;
            this.tbServerIp02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbServerIp02, "首选服务器IP地址。");
            this.tbServerIp02.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbServerIp_KeyPress);
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(6, 161);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(37, 13);
            this.lbPassword.TabIndex = 67;
            this.lbPassword.Text = "密  码";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(98, 157);
            this.tbPassword.MaxLength = 12;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(177, 20);
            this.tbPassword.TabIndex = 68;
            this.tbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbPassword, "连接运营商时使用的密码。");
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbApnInfo_KeyPress);
            // 
            // nudHeatBeat
            // 
            this.nudHeatBeat.BackColor = System.Drawing.Color.White;
            this.nudHeatBeat.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudHeatBeat.Location = new System.Drawing.Point(98, 69);
            this.nudHeatBeat.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudHeatBeat.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudHeatBeat.Name = "nudHeatBeat";
            this.nudHeatBeat.ReadOnly = true;
            this.nudHeatBeat.Size = new System.Drawing.Size(65, 20);
            this.nudHeatBeat.TabIndex = 69;
            this.nudHeatBeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.nudHeatBeat, "集中器向服务器发送心跳包的时间间隔。");
            this.nudHeatBeat.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // gpbGprsInfo
            // 
            this.gpbGprsInfo.Controls.Add(this.rtbGprsMsg);
            this.gpbGprsInfo.Location = new System.Drawing.Point(13, 341);
            this.gpbGprsInfo.Name = "gpbGprsInfo";
            this.gpbGprsInfo.Size = new System.Drawing.Size(352, 279);
            this.gpbGprsInfo.TabIndex = 68;
            this.gpbGprsInfo.TabStop = false;
            this.gpbGprsInfo.Text = "Gprs连接信息（串口或USB端口有效）";
            this.tipInfo.SetToolTip(this.gpbGprsInfo, "Gprs连接的监控信息。");
            // 
            // rtbGprsMsg
            // 
            this.rtbGprsMsg.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.rtbGprsMsg.BackColor = System.Drawing.Color.Snow;
            this.rtbGprsMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbGprsMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbGprsMsg.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbGprsMsg.ForeColor = System.Drawing.Color.Navy;
            this.rtbGprsMsg.Location = new System.Drawing.Point(3, 16);
            this.rtbGprsMsg.Name = "rtbGprsMsg";
            this.rtbGprsMsg.ReadOnly = true;
            this.rtbGprsMsg.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtbGprsMsg.Size = new System.Drawing.Size(346, 260);
            this.rtbGprsMsg.TabIndex = 46;
            this.rtbGprsMsg.Text = "";
            this.tipInfo.SetToolTip(this.rtbGprsMsg, "GPRS模块的连接信息，只在串口连接和USB连接时有效。");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.pgbGrpsRssi);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.lbIMSI);
            this.groupBox3.Controls.Add(this.lbConnectStatus);
            this.groupBox3.Controls.Add(this.lbGprsModle);
            this.groupBox3.Location = new System.Drawing.Point(13, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(352, 83);
            this.groupBox3.TabIndex = 70;
            this.groupBox3.TabStop = false;
            // 
            // lbGprsModle
            // 
            this.lbGprsModle.AutoSize = true;
            this.lbGprsModle.Location = new System.Drawing.Point(6, 17);
            this.lbGprsModle.Name = "lbGprsModle";
            this.lbGprsModle.Size = new System.Drawing.Size(67, 13);
            this.lbGprsModle.TabIndex = 0;
            this.lbGprsModle.Text = "模块型号：";
            this.tipInfo.SetToolTip(this.lbGprsModle, "集中器使用的GPRS模块型号。");
            // 
            // lbConnectStatus
            // 
            this.lbConnectStatus.AutoSize = true;
            this.lbConnectStatus.Location = new System.Drawing.Point(221, 17);
            this.lbConnectStatus.Name = "lbConnectStatus";
            this.lbConnectStatus.Size = new System.Drawing.Size(91, 13);
            this.lbConnectStatus.TabIndex = 1;
            this.lbConnectStatus.Text = "联机状态：未知";
            this.tipInfo.SetToolTip(this.lbConnectStatus, "服务器当前联机状态。");
            // 
            // lbIMSI
            // 
            this.lbIMSI.AutoSize = true;
            this.lbIMSI.Location = new System.Drawing.Point(6, 39);
            this.lbIMSI.Name = "lbIMSI";
            this.lbIMSI.Size = new System.Drawing.Size(65, 13);
            this.lbIMSI.TabIndex = 2;
            this.lbIMSI.Text = "IMSI编码：";
            this.tipInfo.SetToolTip(this.lbIMSI, "GPRS模块中SIM卡的IMSI编码。");
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 61);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "信号强度：";
            this.tipInfo.SetToolTip(this.label18, "当前GPRS的信号强度。");
            // 
            // pgbGrpsRssi
            // 
            this.pgbGrpsRssi.Enabled = false;
            this.pgbGrpsRssi.Location = new System.Drawing.Point(98, 61);
            this.pgbGrpsRssi.MarqueeAnimationSpeed = 1000;
            this.pgbGrpsRssi.Maximum = 31;
            this.pgbGrpsRssi.Name = "pgbGrpsRssi";
            this.pgbGrpsRssi.Size = new System.Drawing.Size(150, 12);
            this.pgbGrpsRssi.Step = 3;
            this.pgbGrpsRssi.TabIndex = 4;
            this.tipInfo.SetToolTip(this.pgbGrpsRssi, "GPRS信号强度");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(81, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "弱";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(251, 61);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(19, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "强";
            // 
            // btSetGprsParam
            // 
            this.btSetGprsParam.Location = new System.Drawing.Point(196, 16);
            this.btSetGprsParam.Name = "btSetGprsParam";
            this.btSetGprsParam.Size = new System.Drawing.Size(157, 23);
            this.btSetGprsParam.TabIndex = 56;
            this.btSetGprsParam.Text = "设置GPRS参数";
            this.tipInfo.SetToolTip(this.btSetGprsParam, "设置集中器中连接服务器的参数。");
            this.btSetGprsParam.UseVisualStyleBackColor = true;
            this.btSetGprsParam.Click += new System.EventHandler(this.btSetGprsParam_Click);
            // 
            // btReadGprsParam
            // 
            this.btReadGprsParam.Location = new System.Drawing.Point(22, 16);
            this.btReadGprsParam.Name = "btReadGprsParam";
            this.btReadGprsParam.Size = new System.Drawing.Size(157, 23);
            this.btReadGprsParam.TabIndex = 46;
            this.btReadGprsParam.Text = "读取GPRS参数";
            this.tipInfo.SetToolTip(this.btReadGprsParam, "读取集中器中连接服务器的参数。");
            this.btReadGprsParam.UseVisualStyleBackColor = true;
            this.btReadGprsParam.Click += new System.EventHandler(this.btReadGprsParam_Click);
            // 
            // btReadGprsInfo
            // 
            this.btReadGprsInfo.Location = new System.Drawing.Point(22, 232);
            this.btReadGprsInfo.Name = "btReadGprsInfo";
            this.btReadGprsInfo.Size = new System.Drawing.Size(157, 23);
            this.btReadGprsInfo.TabIndex = 69;
            this.btReadGprsInfo.Text = "读取GPRS模块信息";
            this.tipInfo.SetToolTip(this.btReadGprsInfo, "读取GPRS模块的相关信息。");
            this.btReadGprsInfo.UseVisualStyleBackColor = true;
            this.btReadGprsInfo.Click += new System.EventHandler(this.btReadGprsInfo_Click);
            // 
            // tbDevParam
            // 
            this.tbDevParam.BackColor = System.Drawing.Color.Snow;
            this.tbDevParam.Controls.Add(this.lbVerInfo);
            this.tbDevParam.Controls.Add(this.btMemCheck);
            this.tbDevParam.Controls.Add(this.dtpTime);
            this.tbDevParam.Controls.Add(this.dtpDate);
            this.tbDevParam.Controls.Add(this.cmbTimeType);
            this.tbDevParam.Controls.Add(this.btSetRtc);
            this.tbDevParam.Controls.Add(this.btReadRtc);
            this.tbDevParam.Controls.Add(this.btReadDevVerInfo);
            this.tbDevParam.Controls.Add(this.btRestartDev);
            this.tbDevParam.Controls.Add(this.tbNewConcAddr);
            this.tbDevParam.Controls.Add(this.label3);
            this.tbDevParam.Controls.Add(this.btSetConcAddr);
            this.tbDevParam.Location = new System.Drawing.Point(4, 22);
            this.tbDevParam.Name = "tbDevParam";
            this.tbDevParam.Padding = new System.Windows.Forms.Padding(3);
            this.tbDevParam.Size = new System.Drawing.Size(376, 666);
            this.tbDevParam.TabIndex = 3;
            this.tbDevParam.Text = " 参数管理 ";
            // 
            // btSetConcAddr
            // 
            this.btSetConcAddr.ForeColor = System.Drawing.Color.Red;
            this.btSetConcAddr.Location = new System.Drawing.Point(22, 16);
            this.btSetConcAddr.Name = "btSetConcAddr";
            this.btSetConcAddr.Size = new System.Drawing.Size(157, 23);
            this.btSetConcAddr.TabIndex = 1;
            this.btSetConcAddr.Text = "设置集中器编号";
            this.tipInfo.SetToolTip(this.btSetConcAddr, "设置集中器编号必须在调试串口或USB端口连接时操作，并且会导致集中器重新启动。");
            this.btSetConcAddr.UseVisualStyleBackColor = true;
            this.btSetConcAddr.Click += new System.EventHandler(this.btSetConcAddr_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "新集中器编号";
            // 
            // tbNewConcAddr
            // 
            this.tbNewConcAddr.Location = new System.Drawing.Point(265, 17);
            this.tbNewConcAddr.Name = "tbNewConcAddr";
            this.tbNewConcAddr.Size = new System.Drawing.Size(89, 20);
            this.tbNewConcAddr.TabIndex = 5;
            this.tbNewConcAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipInfo.SetToolTip(this.tbNewConcAddr, "集中器编号为12位数字，不足12位时左边自动补零。");
            this.tbNewConcAddr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNewConcAddr_KeyPress);
            this.tbNewConcAddr.Leave += new System.EventHandler(this.tbNewConcAddr_Leave);
            // 
            // btRestartDev
            // 
            this.btRestartDev.Location = new System.Drawing.Point(22, 146);
            this.btRestartDev.Name = "btRestartDev";
            this.btRestartDev.Size = new System.Drawing.Size(157, 23);
            this.btRestartDev.TabIndex = 6;
            this.btRestartDev.Text = "重新启动集中器";
            this.tipInfo.SetToolTip(this.btRestartDev, "重新启动集中器会在10秒钟内进行。");
            this.btRestartDev.UseVisualStyleBackColor = true;
            this.btRestartDev.Click += new System.EventHandler(this.btRestartDev_Click);
            // 
            // btReadDevVerInfo
            // 
            this.btReadDevVerInfo.Location = new System.Drawing.Point(22, 113);
            this.btReadDevVerInfo.Name = "btReadDevVerInfo";
            this.btReadDevVerInfo.Size = new System.Drawing.Size(157, 23);
            this.btReadDevVerInfo.TabIndex = 7;
            this.btReadDevVerInfo.Text = "读取集中器版本信息";
            this.tipInfo.SetToolTip(this.btReadDevVerInfo, "读取集中器的版本信息。");
            this.btReadDevVerInfo.UseVisualStyleBackColor = true;
            this.btReadDevVerInfo.Click += new System.EventHandler(this.btReadDevVerInfo_Click);
            // 
            // btReadRtc
            // 
            this.btReadRtc.Location = new System.Drawing.Point(22, 50);
            this.btReadRtc.Name = "btReadRtc";
            this.btReadRtc.Size = new System.Drawing.Size(157, 23);
            this.btReadRtc.TabIndex = 8;
            this.btReadRtc.Text = "读取集中器时钟";
            this.tipInfo.SetToolTip(this.btReadRtc, "读取集中器时钟。");
            this.btReadRtc.UseVisualStyleBackColor = true;
            this.btReadRtc.Click += new System.EventHandler(this.btReadRtc_Click);
            // 
            // btSetRtc
            // 
            this.btSetRtc.Location = new System.Drawing.Point(22, 79);
            this.btSetRtc.Name = "btSetRtc";
            this.btSetRtc.Size = new System.Drawing.Size(157, 23);
            this.btSetRtc.TabIndex = 9;
            this.btSetRtc.Text = "设置集中器时钟";
            this.tipInfo.SetToolTip(this.btSetRtc, "设置集中器时钟，当集中器的时钟和设置时钟相差24小时以上时，需连续设置三次才能成功，设置成功后可能会启动主动上传和数据补抄进程。");
            this.btSetRtc.UseVisualStyleBackColor = true;
            this.btSetRtc.Click += new System.EventHandler(this.btSetRtc_Click);
            // 
            // cmbTimeType
            // 
            this.cmbTimeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeType.FormattingEnabled = true;
            this.cmbTimeType.Items.AddRange(new object[] {
            "系统当前时间",
            "自定义时间"});
            this.cmbTimeType.Location = new System.Drawing.Point(187, 80);
            this.cmbTimeType.Name = "cmbTimeType";
            this.cmbTimeType.Size = new System.Drawing.Size(97, 21);
            this.cmbTimeType.TabIndex = 16;
            this.tipInfo.SetToolTip(this.cmbTimeType, "系统当前时间即为本机的系统时间，也可以自定义时间。");
            this.cmbTimeType.SelectedIndexChanged += new System.EventHandler(this.cmbTimeType_SelectedIndexChanged);
            // 
            // dtpDate
            // 
            this.dtpDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(187, 51);
            this.dtpDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(86, 20);
            this.dtpDate.TabIndex = 17;
            this.tipInfo.SetToolTip(this.dtpDate, "读取或设置当前集中器的时间。");
            this.dtpDate.Value = new System.DateTime(2016, 9, 22, 0, 0, 0, 0);
            // 
            // dtpTime
            // 
            this.dtpTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtpTime.CustomFormat = " HH:mm:ss";
            this.dtpTime.Enabled = false;
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(279, 51);
            this.dtpTime.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpTime.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(75, 20);
            this.dtpTime.TabIndex = 18;
            this.tipInfo.SetToolTip(this.dtpTime, "读取或设置当前集中器的时间。");
            // 
            // btMemCheck
            // 
            this.btMemCheck.Location = new System.Drawing.Point(189, 146);
            this.btMemCheck.Name = "btMemCheck";
            this.btMemCheck.Size = new System.Drawing.Size(157, 23);
            this.btMemCheck.TabIndex = 53;
            this.btMemCheck.Text = "存储器检查";
            this.tipInfo.SetToolTip(this.btMemCheck, "存储器检查用于检测EEPROM是否有错误，本功能运行时间较长且中间不可以中断，否则会影响原EEPROM中的数据内容。");
            this.btMemCheck.UseVisualStyleBackColor = true;
            this.btMemCheck.Click += new System.EventHandler(this.btMemCheck_Click);
            // 
            // lbVerInfo
            // 
            this.lbVerInfo.AutoSize = true;
            this.lbVerInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbVerInfo.Location = new System.Drawing.Point(189, 114);
            this.lbVerInfo.Margin = new System.Windows.Forms.Padding(3);
            this.lbVerInfo.Name = "lbVerInfo";
            this.lbVerInfo.Padding = new System.Windows.Forms.Padding(3);
            this.lbVerInfo.Size = new System.Drawing.Size(99, 21);
            this.lbVerInfo.TabIndex = 54;
            this.lbVerInfo.Text = "版本信息未读出";
            this.tipInfo.SetToolTip(this.lbVerInfo, "集中器的版本信息。");
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tbDevParam);
            this.tabControl.Controls.Add(this.tbGprsParam);
            this.tabControl.Controls.Add(this.tbDocRoute);
            this.tabControl.Controls.Add(this.tbRdMeter);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(384, 692);
            this.tabControl.TabIndex = 1;
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1443, 770);
            this.Controls.Add(this.scon1);
            this.Controls.Add(this.statusMainStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1360, 768);
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "6009";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.SizeChanged += new System.EventHandler(this.FrmMain_SizeChanged);
            this.statusMainStrip.ResumeLayout(false);
            this.statusMainStrip.PerformLayout();
            this.cmsMenu.ResumeLayout(false);
            this.scon1.Panel1.ResumeLayout(false);
            this.scon1.Panel1.PerformLayout();
            this.scon1.Panel2.ResumeLayout(false);
            this.scon1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.scon2.Panel1.ResumeLayout(false);
            this.scon2.Panel2.ResumeLayout(false);
            this.scon2.ResumeLayout(false);
            this.scon3.Panel1.ResumeLayout(false);
            this.scon3.Panel2.ResumeLayout(false);
            this.scon3.ResumeLayout(false);
            this.tbPageDocument.ResumeLayout(false);
            this.tbPageDoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoc)).EndInit();
            this.tbPageRec.ResumeLayout(false);
            this.cntMenuStripCommInfo.ResumeLayout(false);
            this.tbRdMeter.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondChannelNum)).EndInit();
            this.gpbDataFwd.ResumeLayout(false);
            this.gpbDataFwd.PerformLayout();
            this.gpbOption.ResumeLayout(false);
            this.gpbOption.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbChannelNum)).EndInit();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.tbDocRoute.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.gpbNodeEdit.ResumeLayout(false);
            this.gpbNodeEdit.PerformLayout();
            this.tbGprsParam.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeatBeat)).EndInit();
            this.gpbGprsInfo.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tbDevParam.ResumeLayout(false);
            this.tbDevParam.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusMainStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsComPortInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsLocalAddress;
        private System.Windows.Forms.SplitContainer scon1;
        private System.Windows.Forms.SplitContainer scon3;
        private System.Windows.Forms.Button btPortCtrl;
        private System.Windows.Forms.ComboBox cmbComType;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbConcAddr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btReadConcAddr;
        private System.Windows.Forms.TabControl tbPageDocument;
        private System.Windows.Forms.TabPage tbPageDoc;
        private System.Windows.Forms.TabPage tbPageRec;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.RichTextBox rtbCommMsg;
        private System.Windows.Forms.ToolStripProgressBar prgBar;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ToolTip tipInfo;
        private System.Windows.Forms.SplitContainer scon2;
        private System.Windows.Forms.TabControl tbPageRecord;
        private System.Windows.Forms.DataGridView dgvDoc;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.SaveFileDialog saveFileDlg;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lbCurState;
        private UsbLibrary.UsbHidPort usbHidPort;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tbDataFwdResult;
        private System.Windows.Forms.ToolStripStatusLabel lbCurTime;
        private System.Windows.Forms.ContextMenuStrip cntMenuStripCommInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiAutoScroll;
        private System.Windows.Forms.ToolStripMenuItem tsmiAutoClear;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveRecord;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddToForwardList;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearDocument;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddToCmdList;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tbDevParam;
        private System.Windows.Forms.Label lbVerInfo;
        private System.Windows.Forms.Button btMemCheck;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbTimeType;
        private System.Windows.Forms.Button btSetRtc;
        private System.Windows.Forms.Button btReadRtc;
        private System.Windows.Forms.Button btReadDevVerInfo;
        private System.Windows.Forms.Button btRestartDev;
        private System.Windows.Forms.TextBox tbNewConcAddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btSetConcAddr;
        private System.Windows.Forms.TabPage tbGprsParam;
        private System.Windows.Forms.Button btReadGprsInfo;
        private System.Windows.Forms.Button btReadGprsParam;
        private System.Windows.Forms.Button btSetGprsParam;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ProgressBar pgbGrpsRssi;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbIMSI;
        private System.Windows.Forms.Label lbConnectStatus;
        private System.Windows.Forms.Label lbGprsModle;
        private System.Windows.Forms.GroupBox gpbGprsInfo;
        private System.Windows.Forms.RichTextBox rtbGprsMsg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudHeatBeat;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox tbServerIp02;
        private System.Windows.Forms.TextBox tbServerIp03;
        private System.Windows.Forms.TextBox tbServerIp01;
        private System.Windows.Forms.Label lbServerIP0;
        private System.Windows.Forms.Label lbUnit;
        private System.Windows.Forms.Label lbDot02;
        private System.Windows.Forms.Label lbHeatBeat;
        private System.Windows.Forms.TextBox tbServerIp00;
        private System.Windows.Forms.Label lbServerIP1;
        private System.Windows.Forms.TextBox tbApn;
        private System.Windows.Forms.Label lbPort1;
        private System.Windows.Forms.TextBox tbServerPort0;
        private System.Windows.Forms.TextBox tbServerIp10;
        private System.Windows.Forms.Label lbPort0;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbServerPort1;
        private System.Windows.Forms.Label lbDot1;
        private System.Windows.Forms.TextBox tbServerIp13;
        private System.Windows.Forms.TextBox tbServerIp11;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.TextBox tbServerIp12;
        private System.Windows.Forms.Label lbApn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbDot0;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tbDocRoute;
        private System.Windows.Forms.GroupBox gpbNodeEdit;
        private System.Windows.Forms.CheckBox cbSyncWithConc;
        private System.Windows.Forms.Button btReadDevNodeCount;
        private System.Windows.Forms.Button btCreatNewNode;
        private System.Windows.Forms.Button btDelNode;
        private System.Windows.Forms.Button btModifyNode;
        private System.Windows.Forms.ComboBox cmbNodeType;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbNewNodeAddr;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbCurNodeAddr;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btFormatDoc;
        private System.Windows.Forms.Button btFormatData;
        private System.Windows.Forms.Button btWriteDocToDev;
        private System.Windows.Forms.Button btReadDocFromDev;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btReadDoc;
        private System.Windows.Forms.Button btWriteDoc;
        private System.Windows.Forms.TabPage tbRdMeter;
        private System.Windows.Forms.GroupBox gpbOption;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.RadioButton rdbSettlementPrice2;
        private System.Windows.Forms.TextBox tbSettlementPrice;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.RadioButton rdbSettlementPrice1;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.RadioButton rdbRealTimeMeterRead2;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.RadioButton rdbRealTimeMeterRead1;
        private System.Windows.Forms.RadioButton rdbRealTimeMeterRead0;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.RadioButton rdbManualSetChannel;
        private System.Windows.Forms.RadioButton rdbAutoSetChannel;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.RadioButton rdbSetChannel1;
        private System.Windows.Forms.RadioButton rdbSetChannel0;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.NumericUpDown cbChannelNum;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.RadioButton rdbValveCtrl2;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.RadioButton rdbValveCtrl1;
        private System.Windows.Forms.RadioButton rdbValveCtrl0;
        private System.Windows.Forms.Button btBatchWriteMeterCmd;
        private System.Windows.Forms.Button btClearCmdNodeAddr;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.RadioButton rdbOpenAutoChannel2;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.RadioButton rdbOpenAutoChannel1;
        private System.Windows.Forms.RadioButton rdbOpenAutoChannel0;
        private System.Windows.Forms.ComboBox cbRunCmdNodeAddr;
        private System.Windows.Forms.Label lbCmdNodeAddrList;
        private System.Windows.Forms.GroupBox gpbDataFwd;
        private System.Windows.Forms.Button btClearNodeAddr;
        private System.Windows.Forms.ComboBox cbRunNodeAddr;
        private System.Windows.Forms.Button btRunCmd;
        private System.Windows.Forms.GroupBox gpbFunList;
        private System.Windows.Forms.Label lbNodeAddrList;
        private System.Windows.Forms.ComboBox cmbOperateCmd;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btRSecondChannel;
        private System.Windows.Forms.Button btWSecondChannel;
        private System.Windows.Forms.Button btReadCmdData;
        private System.Windows.Forms.NumericUpDown secondChannelNum;
        private System.Windows.Forms.Button btReadAllCmdData;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btSaveDataToXml;
        private System.Windows.Forms.TextBox tbCurAddr;
    }
}