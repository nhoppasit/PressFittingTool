namespace Press_Fit_Pro
{
    partial class frmMain
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "1",
            "Unseated Tool Top",
            "0.030",
            "Next Step",
            "",
            "100",
            "Error 1",
            "0.300",
            "Move to tool top"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "2",
            "Seated Height",
            "0.030",
            "Go To 5",
            "Min F/Pin * #Pins",
            "0",
            "Next Step",
            "0.150",
            "Test missing or repress"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "3",
            "Seated Height",
            "0.010",
            "Next Step",
            "Max F/Pin * #Pins",
            "0",
            "Error 4",
            "0.100",
            "Test within seated height"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "4",
            "Seated Height",
            "-0.010",
            "Error 2",
            "PARS - FPPL 25%",
            "0",
            "Complete",
            "0.100",
            "Seat connector"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "5",
            "Seated Height",
            "0",
            "Error 3",
            "",
            "100",
            "Next Step",
            "0.100",
            "Test missing"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "6",
            "Seated Height",
            "0.010",
            "Next Step",
            "Max F/Pin * #Pins",
            "0",
            "Error 4",
            "0.100",
            "Test repress within seated height"}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "7",
            "Seated Height",
            "-0.010",
            "Error 2",
            "Force Grad CDB",
            "0",
            "Complete",
            "0.100",
            "seat repress"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.gbAccountType = new System.Windows.Forms.GroupBox();
            this.rtbUserType = new System.Windows.Forms.RadioButton();
            this.rtbAdminType = new System.Windows.Forms.RadioButton();
            this.lbUserList = new System.Windows.Forms.ListBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox43 = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.tabEditor = new System.Windows.Forms.TabPage();
            this.tabAllEditor = new System.Windows.Forms.TabControl();
            this.tabTool = new System.Windows.Forms.TabPage();
            this.cbToolType = new System.Windows.Forms.ComboBox();
            this.txtToolBarcode = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.btnDeleteTool = new System.Windows.Forms.Button();
            this.btnClearToolEditor = new System.Windows.Forms.Button();
            this.btnSaveToolEditor = new System.Windows.Forms.Button();
            this.txtToolComments = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtToolLength = new System.Windows.Forms.TextBox();
            this.txtToolWidth = new System.Windows.Forms.TextBox();
            this.txtToolHeight = new System.Windows.Forms.TextBox();
            this.txtToolClearance = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.btnDeleteProfile = new System.Windows.Forms.Button();
            this.btnDefaultProfileData = new System.Windows.Forms.Button();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.lvProfile = new System.Windows.Forms.ListView();
            this.colProfileRow = new System.Windows.Forms.ColumnHeader();
            this.colProfileHeight = new System.Windows.Forms.ColumnHeader();
            this.colProfileHeightPar = new System.Windows.Forms.ColumnHeader();
            this.colProfileHeightAction = new System.Windows.Forms.ColumnHeader();
            this.colProfileForce = new System.Windows.Forms.ColumnHeader();
            this.colProfileForcePar = new System.Windows.Forms.ColumnHeader();
            this.colProfileForceAction = new System.Windows.Forms.ColumnHeader();
            this.colProfileSpeed = new System.Windows.Forms.ColumnHeader();
            this.colProfileComments = new System.Windows.Forms.ColumnHeader();
            this.txtProfileError5 = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.txtProfileError4 = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.txtProfileError3 = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.txtProfileError2 = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.txtProfileError1 = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.txtProfileSampleDistance = new System.Windows.Forms.TextBox();
            this.txtProfileSampleStart = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.cbProfileName = new System.Windows.Forms.ComboBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.tabConnector = new System.Windows.Forms.TabPage();
            this.cbConnectorProfileName = new System.Windows.Forms.ComboBox();
            this.label70 = new System.Windows.Forms.Label();
            this.btnDeleteConnector = new System.Windows.Forms.Button();
            this.btnClearConnectorSpecEditor = new System.Windows.Forms.Button();
            this.btnSaveConnector = new System.Windows.Forms.Button();
            this.txtConnectorFGradDegrees = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.txtConnectorPARSDistance = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtConnectorPARSStartHeight = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtConnectorPARSPercent = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtConnectorOtherForce = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtConnectorUserFPerPin = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtConnectorMaxFPerPin = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtConnectorMinFPerPin = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtConnectorGraphDistance = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtConnectorGraphFPerPin = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtConnectorComments = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtConnectorPins = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtConnectorSeatedHeight = new System.Windows.Forms.TextBox();
            this.txtConnectorHeight = new System.Windows.Forms.TextBox();
            this.txtConnectorUnseatedTop = new System.Windows.Forms.TextBox();
            this.txtConnectorBaseThickness = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbConnectorToolType = new System.Windows.Forms.ComboBox();
            this.cbConnectorType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabBoard = new System.Windows.Forms.TabPage();
            this.label40 = new System.Windows.Forms.Label();
            this.txtBoardImageFile = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.btnClearConnectorListOnBoard = new System.Windows.Forms.Button();
            this.btnDeleteConnectorOnBoard = new System.Windows.Forms.Button();
            this.btnAddConnectorOnBoard = new System.Windows.Forms.Button();
            this.lvConnectorOnBoardList = new System.Windows.Forms.ListView();
            this.colRow = new System.Windows.Forms.ColumnHeader();
            this.colX = new System.Windows.Forms.ColumnHeader();
            this.colY = new System.Windows.Forms.ColumnHeader();
            this.colAngle = new System.Windows.Forms.ColumnHeader();
            this.colConnector = new System.Windows.Forms.ColumnHeader();
            this.colComments = new System.Windows.Forms.ColumnHeader();
            this.btnBoardImageBrowse = new System.Windows.Forms.Button();
            this.picBoardPreview = new System.Windows.Forms.PictureBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtBoardLength = new System.Windows.Forms.TextBox();
            this.txtBoardWidth = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtFixtureThickness = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtBoardThickness = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.btnDeleteBoardSpec = new System.Windows.Forms.Button();
            this.cbBoardName = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtBoardDESC = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.btnClearBoardSpecEditor = new System.Windows.Forms.Button();
            this.btnSaveBoardSpec = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.tabRun = new System.Windows.Forms.TabPage();
            this.lbRunProfileName = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.lbRunConnectorType = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.lbRunToolType = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.lbRunConnectorAngle = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.lbRunConnectorY = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.lbRunConnectorX = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.lbRunPins = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.lbRunConnectorCount = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.lbRunConnectorIndex = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.rtbRunStatus = new System.Windows.Forms.RichTextBox();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.picBoardOnRun = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnSelectBoard = new System.Windows.Forms.Button();
            this.lblLoginUserName = new System.Windows.Forms.Label();
            this.lblLoginTime = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label60 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.gbAccountType.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabEditor.SuspendLayout();
            this.tabAllEditor.SuspendLayout();
            this.tabTool.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.tabConnector.SuspendLayout();
            this.tabBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoardPreview)).BeginInit();
            this.tabRun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoardOnRun)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabUser);
            this.tabMain.Controls.Add(this.tabLog);
            this.tabMain.Controls.Add(this.tabEditor);
            this.tabMain.Controls.Add(this.tabRun);
            this.tabMain.Location = new System.Drawing.Point(12, 64);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1157, 571);
            this.tabMain.TabIndex = 8;
            // 
            // tabUser
            // 
            this.tabUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tabUser.Controls.Add(this.gbAccountType);
            this.tabUser.Controls.Add(this.lbUserList);
            this.tabUser.Controls.Add(this.btnReload);
            this.tabUser.Controls.Add(this.btnDeleteUser);
            this.tabUser.Controls.Add(this.btnSaveUser);
            this.tabUser.Controls.Add(this.btnChangePassword);
            this.tabUser.Controls.Add(this.txtUserName);
            this.tabUser.Controls.Add(this.txtLastName);
            this.tabUser.Controls.Add(this.txtFirstName);
            this.tabUser.Controls.Add(this.label52);
            this.tabUser.Controls.Add(this.label53);
            this.tabUser.Controls.Add(this.label54);
            this.tabUser.Controls.Add(this.btnAddUser);
            this.tabUser.Controls.Add(this.label55);
            this.tabUser.Controls.Add(this.label56);
            this.tabUser.Location = new System.Drawing.Point(4, 40);
            this.tabUser.Name = "tabUser";
            this.tabUser.Size = new System.Drawing.Size(1149, 527);
            this.tabUser.TabIndex = 0;
            this.tabUser.Text = "User";
            // 
            // gbAccountType
            // 
            this.gbAccountType.Controls.Add(this.rtbUserType);
            this.gbAccountType.Controls.Add(this.rtbAdminType);
            this.gbAccountType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gbAccountType.Location = new System.Drawing.Point(585, 228);
            this.gbAccountType.Name = "gbAccountType";
            this.gbAccountType.Size = new System.Drawing.Size(300, 94);
            this.gbAccountType.TabIndex = 50;
            this.gbAccountType.TabStop = false;
            this.gbAccountType.Text = "Account type:";
            // 
            // rtbUserType
            // 
            this.rtbUserType.AutoSize = true;
            this.rtbUserType.Location = new System.Drawing.Point(194, 41);
            this.rtbUserType.Name = "rtbUserType";
            this.rtbUserType.Size = new System.Drawing.Size(67, 28);
            this.rtbUserType.TabIndex = 1;
            this.rtbUserType.TabStop = true;
            this.rtbUserType.Text = "User";
            this.rtbUserType.UseVisualStyleBackColor = true;
            // 
            // rtbAdminType
            // 
            this.rtbAdminType.AutoSize = true;
            this.rtbAdminType.Location = new System.Drawing.Point(28, 41);
            this.rtbAdminType.Name = "rtbAdminType";
            this.rtbAdminType.Size = new System.Drawing.Size(137, 28);
            this.rtbAdminType.TabIndex = 0;
            this.rtbAdminType.TabStop = true;
            this.rtbAdminType.Text = "Administrator";
            this.rtbAdminType.UseVisualStyleBackColor = true;
            // 
            // lbUserList
            // 
            this.lbUserList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbUserList.FormattingEnabled = true;
            this.lbUserList.ItemHeight = 24;
            this.lbUserList.Location = new System.Drawing.Point(21, 90);
            this.lbUserList.Name = "lbUserList";
            this.lbUserList.Size = new System.Drawing.Size(382, 316);
            this.lbUserList.TabIndex = 49;
            this.lbUserList.SelectedIndexChanged += new System.EventHandler(this.lbUserList_SelectedIndexChanged);
            this.lbUserList.Click += new System.EventHandler(this.lbUserList_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(282, 44);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(121, 40);
            this.btnReload.TabIndex = 48;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteUser.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnDeleteUser.Location = new System.Drawing.Point(195, 433);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(168, 45);
            this.btnDeleteUser.TabIndex = 40;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnSaveUser.Location = new System.Drawing.Point(585, 337);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(168, 45);
            this.btnSaveUser.TabIndex = 38;
            this.btnSaveUser.Text = "Save";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnChangePassword.Location = new System.Drawing.Point(759, 337);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(223, 45);
            this.btnChangePassword.TabIndex = 37;
            this.btnChangePassword.Text = "Change Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(585, 90);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(300, 40);
            this.txtUserName.TabIndex = 32;
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(585, 182);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(300, 40);
            this.txtLastName.TabIndex = 31;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(585, 136);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(300, 40);
            this.txtFirstName.TabIndex = 30;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Enabled = false;
            this.label52.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(450, 99);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(129, 25);
            this.label52.TabIndex = 43;
            this.label52.Text = "User Name :";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(455, 191);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(124, 25);
            this.label53.TabIndex = 44;
            this.label53.Text = "Last Name :";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(452, 145);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(127, 25);
            this.label54.TabIndex = 45;
            this.label54.Text = "First Name :";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddUser.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.btnAddUser.Location = new System.Drawing.Point(21, 433);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(168, 45);
            this.btnAddUser.TabIndex = 29;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(580, 51);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(152, 29);
            this.label55.TabIndex = 46;
            this.label55.Text = "User Profile";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.Location = new System.Drawing.Point(16, 51);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(67, 29);
            this.label56.TabIndex = 47;
            this.label56.Text = "User";
            // 
            // tabLog
            // 
            this.tabLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabLog.Controls.Add(this.panel1);
            this.tabLog.Controls.Add(this.label58);
            this.tabLog.Controls.Add(this.label59);
            this.tabLog.Controls.Add(this.button14);
            this.tabLog.Controls.Add(this.dataGrid1);
            this.tabLog.Location = new System.Drawing.Point(4, 40);
            this.tabLog.Name = "tabLog";
            this.tabLog.Size = new System.Drawing.Size(1149, 527);
            this.tabLog.TabIndex = 1;
            this.tabLog.Text = "Log";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.textBox43);
            this.panel1.Controls.Add(this.label57);
            this.panel1.Location = new System.Drawing.Point(13, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1121, 104);
            this.panel1.TabIndex = 0;
            // 
            // textBox43
            // 
            this.textBox43.Location = new System.Drawing.Point(188, 13);
            this.textBox43.Name = "textBox43";
            this.textBox43.Size = new System.Drawing.Size(215, 38);
            this.textBox43.TabIndex = 26;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(9, 16);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(173, 31);
            this.label57.TabIndex = 27;
            this.label57.Text = "User Name : ";
            // 
            // label58
            // 
            this.label58.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label58.Location = new System.Drawing.Point(13, 139);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(167, 20);
            this.label58.TabIndex = 1;
            this.label58.Text = "Machine Log Detail";
            // 
            // label59
            // 
            this.label59.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label59.Location = new System.Drawing.Point(13, 9);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(88, 20);
            this.label59.TabIndex = 2;
            this.label59.Text = "Setup Log";
            // 
            // button14
            // 
            this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button14.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.button14.Location = new System.Drawing.Point(888, 405);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(246, 46);
            this.button14.TabIndex = 24;
            this.button14.Text = "Show graph";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(13, 162);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(1121, 234);
            this.dataGrid1.TabIndex = 20;
            this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // tabEditor
            // 
            this.tabEditor.Controls.Add(this.tabAllEditor);
            this.tabEditor.Location = new System.Drawing.Point(4, 40);
            this.tabEditor.Name = "tabEditor";
            this.tabEditor.Size = new System.Drawing.Size(1149, 527);
            this.tabEditor.TabIndex = 2;
            this.tabEditor.Text = "Editor";
            // 
            // tabAllEditor
            // 
            this.tabAllEditor.Controls.Add(this.tabTool);
            this.tabAllEditor.Controls.Add(this.tabProfile);
            this.tabAllEditor.Controls.Add(this.tabConnector);
            this.tabAllEditor.Controls.Add(this.tabBoard);
            this.tabAllEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAllEditor.Location = new System.Drawing.Point(0, 0);
            this.tabAllEditor.Name = "tabAllEditor";
            this.tabAllEditor.SelectedIndex = 0;
            this.tabAllEditor.Size = new System.Drawing.Size(1149, 527);
            this.tabAllEditor.TabIndex = 1;
            // 
            // tabTool
            // 
            this.tabTool.Controls.Add(this.cbToolType);
            this.tabTool.Controls.Add(this.txtToolBarcode);
            this.tabTool.Controls.Add(this.label50);
            this.tabTool.Controls.Add(this.btnDeleteTool);
            this.tabTool.Controls.Add(this.btnClearToolEditor);
            this.tabTool.Controls.Add(this.btnSaveToolEditor);
            this.tabTool.Controls.Add(this.txtToolComments);
            this.tabTool.Controls.Add(this.label8);
            this.tabTool.Controls.Add(this.txtToolLength);
            this.tabTool.Controls.Add(this.txtToolWidth);
            this.tabTool.Controls.Add(this.txtToolHeight);
            this.tabTool.Controls.Add(this.txtToolClearance);
            this.tabTool.Controls.Add(this.label7);
            this.tabTool.Controls.Add(this.label6);
            this.tabTool.Controls.Add(this.label5);
            this.tabTool.Controls.Add(this.label4);
            this.tabTool.Controls.Add(this.label3);
            this.tabTool.Controls.Add(this.label2);
            this.tabTool.Controls.Add(this.label1);
            this.tabTool.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tabTool.Location = new System.Drawing.Point(4, 40);
            this.tabTool.Name = "tabTool";
            this.tabTool.Size = new System.Drawing.Size(1141, 483);
            this.tabTool.TabIndex = 0;
            this.tabTool.Text = "Tool";
            this.tabTool.UseVisualStyleBackColor = true;
            // 
            // cbToolType
            // 
            this.cbToolType.FormattingEnabled = true;
            this.cbToolType.Location = new System.Drawing.Point(209, 54);
            this.cbToolType.Name = "cbToolType";
            this.cbToolType.Size = new System.Drawing.Size(318, 24);
            this.cbToolType.TabIndex = 0;
            this.cbToolType.SelectedIndexChanged += new System.EventHandler(this.cbToolType_SelectedIndexChanged);
            // 
            // txtToolBarcode
            // 
            this.txtToolBarcode.Location = new System.Drawing.Point(492, 132);
            this.txtToolBarcode.Name = "txtToolBarcode";
            this.txtToolBarcode.Size = new System.Drawing.Size(226, 22);
            this.txtToolBarcode.TabIndex = 5;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(427, 135);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(59, 16);
            this.label50.TabIndex = 26;
            this.label50.Text = "Barcode:";
            this.label50.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnDeleteTool
            // 
            this.btnDeleteTool.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTool.Location = new System.Drawing.Point(565, 53);
            this.btnDeleteTool.Name = "btnDeleteTool";
            this.btnDeleteTool.Size = new System.Drawing.Size(211, 25);
            this.btnDeleteTool.TabIndex = 9;
            this.btnDeleteTool.Text = "Delete tool from database";
            this.btnDeleteTool.Click += new System.EventHandler(this.btnDeleteTool_Click);
            // 
            // btnClearToolEditor
            // 
            this.btnClearToolEditor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearToolEditor.Location = new System.Drawing.Point(592, 298);
            this.btnClearToolEditor.Name = "btnClearToolEditor";
            this.btnClearToolEditor.Size = new System.Drawing.Size(167, 40);
            this.btnClearToolEditor.TabIndex = 8;
            this.btnClearToolEditor.Text = "Clear tool editor";
            this.btnClearToolEditor.Click += new System.EventHandler(this.btnClearToolEditor_Click);
            // 
            // btnSaveToolEditor
            // 
            this.btnSaveToolEditor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveToolEditor.Location = new System.Drawing.Point(209, 298);
            this.btnSaveToolEditor.Name = "btnSaveToolEditor";
            this.btnSaveToolEditor.Size = new System.Drawing.Size(175, 40);
            this.btnSaveToolEditor.TabIndex = 7;
            this.btnSaveToolEditor.Text = "Save tool data";
            this.btnSaveToolEditor.Click += new System.EventHandler(this.btnSaveToolEditor_Click);
            // 
            // txtToolComments
            // 
            this.txtToolComments.Location = new System.Drawing.Point(209, 244);
            this.txtToolComments.Name = "txtToolComments";
            this.txtToolComments.Size = new System.Drawing.Size(550, 22);
            this.txtToolComments.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(121, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Comments :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtToolLength
            // 
            this.txtToolLength.Location = new System.Drawing.Point(209, 216);
            this.txtToolLength.Name = "txtToolLength";
            this.txtToolLength.Size = new System.Drawing.Size(144, 22);
            this.txtToolLength.TabIndex = 4;
            // 
            // txtToolWidth
            // 
            this.txtToolWidth.Location = new System.Drawing.Point(209, 188);
            this.txtToolWidth.Name = "txtToolWidth";
            this.txtToolWidth.Size = new System.Drawing.Size(144, 22);
            this.txtToolWidth.TabIndex = 3;
            // 
            // txtToolHeight
            // 
            this.txtToolHeight.Location = new System.Drawing.Point(209, 160);
            this.txtToolHeight.Name = "txtToolHeight";
            this.txtToolHeight.Size = new System.Drawing.Size(144, 22);
            this.txtToolHeight.TabIndex = 2;
            // 
            // txtToolClearance
            // 
            this.txtToolClearance.Location = new System.Drawing.Point(209, 132);
            this.txtToolClearance.Name = "txtToolClearance";
            this.txtToolClearance.Size = new System.Drawing.Size(144, 22);
            this.txtToolClearance.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(116, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Tool Length :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(121, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Tool Width :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(121, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Tool Height :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(100, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tool Clearance :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(44, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Dimensions (inches)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tool Type :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1141, 28);
            this.label1.TabIndex = 24;
            this.label1.Text = "TOOL   EDITOR";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.btnDeleteProfile);
            this.tabProfile.Controls.Add(this.btnDefaultProfileData);
            this.tabProfile.Controls.Add(this.btnSaveProfile);
            this.tabProfile.Controls.Add(this.lvProfile);
            this.tabProfile.Controls.Add(this.txtProfileError5);
            this.tabProfile.Controls.Add(this.label69);
            this.tabProfile.Controls.Add(this.txtProfileError4);
            this.tabProfile.Controls.Add(this.label68);
            this.tabProfile.Controls.Add(this.txtProfileError3);
            this.tabProfile.Controls.Add(this.label67);
            this.tabProfile.Controls.Add(this.txtProfileError2);
            this.tabProfile.Controls.Add(this.label66);
            this.tabProfile.Controls.Add(this.txtProfileError1);
            this.tabProfile.Controls.Add(this.label65);
            this.tabProfile.Controls.Add(this.txtProfileSampleDistance);
            this.tabProfile.Controls.Add(this.txtProfileSampleStart);
            this.tabProfile.Controls.Add(this.label64);
            this.tabProfile.Controls.Add(this.label63);
            this.tabProfile.Controls.Add(this.label62);
            this.tabProfile.Controls.Add(this.cbProfileName);
            this.tabProfile.Controls.Add(this.label61);
            this.tabProfile.Controls.Add(this.label51);
            this.tabProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tabProfile.Location = new System.Drawing.Point(4, 40);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Size = new System.Drawing.Size(1141, 483);
            this.tabProfile.TabIndex = 3;
            this.tabProfile.Text = "Profile";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // btnDeleteProfile
            // 
            this.btnDeleteProfile.Location = new System.Drawing.Point(622, 45);
            this.btnDeleteProfile.Name = "btnDeleteProfile";
            this.btnDeleteProfile.Size = new System.Drawing.Size(224, 34);
            this.btnDeleteProfile.TabIndex = 46;
            this.btnDeleteProfile.Text = "Delete profile from database";
            this.btnDeleteProfile.UseVisualStyleBackColor = true;
            this.btnDeleteProfile.Click += new System.EventHandler(this.btnDeleteProfile_Click);
            // 
            // btnDefaultProfileData
            // 
            this.btnDefaultProfileData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDefaultProfileData.Location = new System.Drawing.Point(237, 624);
            this.btnDefaultProfileData.Name = "btnDefaultProfileData";
            this.btnDefaultProfileData.Size = new System.Drawing.Size(152, 40);
            this.btnDefaultProfileData.TabIndex = 45;
            this.btnDefaultProfileData.Text = "Default profile data";
            this.btnDefaultProfileData.UseVisualStyleBackColor = true;
            this.btnDefaultProfileData.Click += new System.EventHandler(this.btnDefaultProfileData_Click);
            // 
            // btnSaveProfile
            // 
            this.btnSaveProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSaveProfile.Location = new System.Drawing.Point(16, 624);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(200, 40);
            this.btnSaveProfile.TabIndex = 44;
            this.btnSaveProfile.Text = "Save profile data";
            this.btnSaveProfile.UseVisualStyleBackColor = true;
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
            // 
            // lvProfile
            // 
            this.lvProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvProfile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProfileRow,
            this.colProfileHeight,
            this.colProfileHeightPar,
            this.colProfileHeightAction,
            this.colProfileForce,
            this.colProfileForcePar,
            this.colProfileForceAction,
            this.colProfileSpeed,
            this.colProfileComments});
            this.lvProfile.FullRowSelect = true;
            this.lvProfile.GridLines = true;
            this.lvProfile.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvProfile.HideSelection = false;
            this.lvProfile.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7});
            this.lvProfile.Location = new System.Drawing.Point(16, 262);
            this.lvProfile.MultiSelect = false;
            this.lvProfile.Name = "lvProfile";
            this.lvProfile.Size = new System.Drawing.Size(1101, 345);
            this.lvProfile.TabIndex = 43;
            this.lvProfile.UseCompatibleStateImageBehavior = false;
            this.lvProfile.View = System.Windows.Forms.View.Details;
            this.lvProfile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvProfile_MouseDoubleClick);
            // 
            // colProfileRow
            // 
            this.colProfileRow.Text = "Row";
            // 
            // colProfileHeight
            // 
            this.colProfileHeight.Text = "Height (in) above board";
            this.colProfileHeight.Width = 183;
            // 
            // colProfileHeightPar
            // 
            this.colProfileHeightPar.Text = "Height Parameter";
            this.colProfileHeightPar.Width = 123;
            // 
            // colProfileHeightAction
            // 
            this.colProfileHeightAction.Text = "Height Action";
            this.colProfileHeightAction.Width = 152;
            // 
            // colProfileForce
            // 
            this.colProfileForce.Text = "Force (kg)";
            this.colProfileForce.Width = 140;
            // 
            // colProfileForcePar
            // 
            this.colProfileForcePar.Text = "Force Parameter";
            this.colProfileForcePar.Width = 128;
            // 
            // colProfileForceAction
            // 
            this.colProfileForceAction.Text = "Force Action";
            this.colProfileForceAction.Width = 100;
            // 
            // colProfileSpeed
            // 
            this.colProfileSpeed.Text = "Speed";
            this.colProfileSpeed.Width = 100;
            // 
            // colProfileComments
            // 
            this.colProfileComments.Text = "Comments";
            this.colProfileComments.Width = 300;
            // 
            // txtProfileError5
            // 
            this.txtProfileError5.Location = new System.Drawing.Point(128, 222);
            this.txtProfileError5.Name = "txtProfileError5";
            this.txtProfileError5.Size = new System.Drawing.Size(731, 22);
            this.txtProfileError5.TabIndex = 42;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(72, 225);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(50, 16);
            this.label69.TabIndex = 41;
            this.label69.Text = "Error 5:";
            // 
            // txtProfileError4
            // 
            this.txtProfileError4.Location = new System.Drawing.Point(128, 194);
            this.txtProfileError4.Name = "txtProfileError4";
            this.txtProfileError4.Size = new System.Drawing.Size(731, 22);
            this.txtProfileError4.TabIndex = 40;
            this.txtProfileError4.Text = "Excessive force";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(72, 197);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(50, 16);
            this.label68.TabIndex = 39;
            this.label68.Text = "Error 4:";
            // 
            // txtProfileError3
            // 
            this.txtProfileError3.Location = new System.Drawing.Point(128, 166);
            this.txtProfileError3.Name = "txtProfileError3";
            this.txtProfileError3.Size = new System.Drawing.Size(731, 22);
            this.txtProfileError3.TabIndex = 38;
            this.txtProfileError3.Text = "Missing connector";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(72, 169);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(50, 16);
            this.label67.TabIndex = 37;
            this.label67.Text = "Error 3:";
            // 
            // txtProfileError2
            // 
            this.txtProfileError2.Location = new System.Drawing.Point(128, 138);
            this.txtProfileError2.Name = "txtProfileError2";
            this.txtProfileError2.Size = new System.Drawing.Size(731, 22);
            this.txtProfileError2.TabIndex = 36;
            this.txtProfileError2.Text = "Insufficient force";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(72, 141);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(50, 16);
            this.label66.TabIndex = 35;
            this.label66.Text = "Error 2:";
            // 
            // txtProfileError1
            // 
            this.txtProfileError1.Location = new System.Drawing.Point(128, 110);
            this.txtProfileError1.Name = "txtProfileError1";
            this.txtProfileError1.Size = new System.Drawing.Size(731, 22);
            this.txtProfileError1.TabIndex = 34;
            this.txtProfileError1.Text = "Premeasure contact detected";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(72, 113);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(50, 16);
            this.label65.TabIndex = 33;
            this.label65.Text = "Error 1:";
            // 
            // txtProfileSampleDistance
            // 
            this.txtProfileSampleDistance.Location = new System.Drawing.Point(405, 82);
            this.txtProfileSampleDistance.Name = "txtProfileSampleDistance";
            this.txtProfileSampleDistance.Size = new System.Drawing.Size(192, 22);
            this.txtProfileSampleDistance.TabIndex = 32;
            this.txtProfileSampleDistance.Text = "0.005";
            // 
            // txtProfileSampleStart
            // 
            this.txtProfileSampleStart.Location = new System.Drawing.Point(128, 82);
            this.txtProfileSampleStart.Name = "txtProfileSampleStart";
            this.txtProfileSampleStart.Size = new System.Drawing.Size(192, 22);
            this.txtProfileSampleStart.TabIndex = 31;
            this.txtProfileSampleStart.Text = "0.010";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label64.Location = new System.Drawing.Point(603, 85);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(117, 16);
            this.label64.TabIndex = 30;
            this.label64.Text = "(Sample range: in)";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(335, 85);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(64, 16);
            this.label63.TabIndex = 29;
            this.label63.Text = "Distance:";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(84, 85);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(38, 16);
            this.label62.TabIndex = 28;
            this.label62.Text = "Start:";
            // 
            // cbProfileName
            // 
            this.cbProfileName.FormattingEnabled = true;
            this.cbProfileName.Location = new System.Drawing.Point(128, 52);
            this.cbProfileName.Name = "cbProfileName";
            this.cbProfileName.Size = new System.Drawing.Size(469, 24);
            this.cbProfileName.TabIndex = 27;
            this.cbProfileName.SelectedIndexChanged += new System.EventHandler(this.cbProfileName_SelectedIndexChanged);
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(33, 55);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(89, 16);
            this.label61.TabIndex = 26;
            this.label61.Text = "Profile Name:";
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label51.Dock = System.Windows.Forms.DockStyle.Top;
            this.label51.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.label51.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label51.Location = new System.Drawing.Point(0, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(1141, 38);
            this.label51.TabIndex = 25;
            this.label51.Text = "PROFILE   EDITOR";
            this.label51.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabConnector
            // 
            this.tabConnector.Controls.Add(this.cbConnectorProfileName);
            this.tabConnector.Controls.Add(this.label70);
            this.tabConnector.Controls.Add(this.btnDeleteConnector);
            this.tabConnector.Controls.Add(this.btnClearConnectorSpecEditor);
            this.tabConnector.Controls.Add(this.btnSaveConnector);
            this.tabConnector.Controls.Add(this.txtConnectorFGradDegrees);
            this.tabConnector.Controls.Add(this.label32);
            this.tabConnector.Controls.Add(this.label31);
            this.tabConnector.Controls.Add(this.txtConnectorPARSDistance);
            this.tabConnector.Controls.Add(this.label30);
            this.tabConnector.Controls.Add(this.txtConnectorPARSStartHeight);
            this.tabConnector.Controls.Add(this.label29);
            this.tabConnector.Controls.Add(this.txtConnectorPARSPercent);
            this.tabConnector.Controls.Add(this.label28);
            this.tabConnector.Controls.Add(this.label27);
            this.tabConnector.Controls.Add(this.txtConnectorOtherForce);
            this.tabConnector.Controls.Add(this.label26);
            this.tabConnector.Controls.Add(this.txtConnectorUserFPerPin);
            this.tabConnector.Controls.Add(this.label25);
            this.tabConnector.Controls.Add(this.txtConnectorMaxFPerPin);
            this.tabConnector.Controls.Add(this.label24);
            this.tabConnector.Controls.Add(this.txtConnectorMinFPerPin);
            this.tabConnector.Controls.Add(this.label23);
            this.tabConnector.Controls.Add(this.label22);
            this.tabConnector.Controls.Add(this.txtConnectorGraphDistance);
            this.tabConnector.Controls.Add(this.label21);
            this.tabConnector.Controls.Add(this.txtConnectorGraphFPerPin);
            this.tabConnector.Controls.Add(this.label20);
            this.tabConnector.Controls.Add(this.label19);
            this.tabConnector.Controls.Add(this.txtConnectorComments);
            this.tabConnector.Controls.Add(this.label18);
            this.tabConnector.Controls.Add(this.txtConnectorPins);
            this.tabConnector.Controls.Add(this.label17);
            this.tabConnector.Controls.Add(this.txtConnectorSeatedHeight);
            this.tabConnector.Controls.Add(this.txtConnectorHeight);
            this.tabConnector.Controls.Add(this.txtConnectorUnseatedTop);
            this.tabConnector.Controls.Add(this.txtConnectorBaseThickness);
            this.tabConnector.Controls.Add(this.label16);
            this.tabConnector.Controls.Add(this.label15);
            this.tabConnector.Controls.Add(this.label14);
            this.tabConnector.Controls.Add(this.label13);
            this.tabConnector.Controls.Add(this.label12);
            this.tabConnector.Controls.Add(this.cbConnectorToolType);
            this.tabConnector.Controls.Add(this.cbConnectorType);
            this.tabConnector.Controls.Add(this.label11);
            this.tabConnector.Controls.Add(this.label10);
            this.tabConnector.Controls.Add(this.label9);
            this.tabConnector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tabConnector.Location = new System.Drawing.Point(4, 40);
            this.tabConnector.Name = "tabConnector";
            this.tabConnector.Size = new System.Drawing.Size(1141, 483);
            this.tabConnector.TabIndex = 1;
            this.tabConnector.Text = "Connector";
            this.tabConnector.UseVisualStyleBackColor = true;
            // 
            // cbConnectorProfileName
            // 
            this.cbConnectorProfileName.Location = new System.Drawing.Point(162, 103);
            this.cbConnectorProfileName.Name = "cbConnectorProfileName";
            this.cbConnectorProfileName.Size = new System.Drawing.Size(200, 24);
            this.cbConnectorProfileName.TabIndex = 87;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label70.Location = new System.Drawing.Point(52, 107);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(104, 17);
            this.label70.TabIndex = 88;
            this.label70.Text = "Profile Name :";
            this.label70.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnDeleteConnector
            // 
            this.btnDeleteConnector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteConnector.Location = new System.Drawing.Point(424, 43);
            this.btnDeleteConnector.Name = "btnDeleteConnector";
            this.btnDeleteConnector.Size = new System.Drawing.Size(271, 38);
            this.btnDeleteConnector.TabIndex = 59;
            this.btnDeleteConnector.Text = "Delete connector spec. from database";
            this.btnDeleteConnector.Click += new System.EventHandler(this.btnDeleteConnector_Click);
            // 
            // btnClearConnectorSpecEditor
            // 
            this.btnClearConnectorSpecEditor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearConnectorSpecEditor.Location = new System.Drawing.Point(329, 382);
            this.btnClearConnectorSpecEditor.Name = "btnClearConnectorSpecEditor";
            this.btnClearConnectorSpecEditor.Size = new System.Drawing.Size(212, 46);
            this.btnClearConnectorSpecEditor.TabIndex = 58;
            this.btnClearConnectorSpecEditor.Text = "Clear connector spec. editor";
            this.btnClearConnectorSpecEditor.Click += new System.EventHandler(this.btnClearConnectorSpecEditor_Click);
            // 
            // btnSaveConnector
            // 
            this.btnSaveConnector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveConnector.Location = new System.Drawing.Point(15, 382);
            this.btnSaveConnector.Name = "btnSaveConnector";
            this.btnSaveConnector.Size = new System.Drawing.Size(291, 46);
            this.btnSaveConnector.TabIndex = 57;
            this.btnSaveConnector.Text = "Save connector specifications";
            this.btnSaveConnector.Click += new System.EventHandler(this.btnSaveConnector_Click);
            // 
            // txtConnectorFGradDegrees
            // 
            this.txtConnectorFGradDegrees.Location = new System.Drawing.Point(783, 238);
            this.txtConnectorFGradDegrees.Name = "txtConnectorFGradDegrees";
            this.txtConnectorFGradDegrees.Size = new System.Drawing.Size(80, 22);
            this.txtConnectorFGradDegrees.TabIndex = 51;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(680, 241);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(100, 20);
            this.label32.TabIndex = 63;
            this.label32.Text = "Degrees :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label31.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label31.Location = new System.Drawing.Point(641, 219);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(136, 20);
            this.label31.TabIndex = 64;
            this.label31.Text = "Force Gradient";
            // 
            // txtConnectorPARSDistance
            // 
            this.txtConnectorPARSDistance.Location = new System.Drawing.Point(783, 191);
            this.txtConnectorPARSDistance.Name = "txtConnectorPARSDistance";
            this.txtConnectorPARSDistance.Size = new System.Drawing.Size(80, 22);
            this.txtConnectorPARSDistance.TabIndex = 48;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(680, 194);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(100, 20);
            this.label30.TabIndex = 65;
            this.label30.Text = "Distance :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtConnectorPARSStartHeight
            // 
            this.txtConnectorPARSStartHeight.Location = new System.Drawing.Point(783, 163);
            this.txtConnectorPARSStartHeight.Name = "txtConnectorPARSStartHeight";
            this.txtConnectorPARSStartHeight.Size = new System.Drawing.Size(80, 22);
            this.txtConnectorPARSStartHeight.TabIndex = 46;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(670, 166);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(110, 20);
            this.label29.TabIndex = 66;
            this.label29.Text = "Start Height :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtConnectorPARSPercent
            // 
            this.txtConnectorPARSPercent.Location = new System.Drawing.Point(783, 133);
            this.txtConnectorPARSPercent.Name = "txtConnectorPARSPercent";
            this.txtConnectorPARSPercent.Size = new System.Drawing.Size(80, 22);
            this.txtConnectorPARSPercent.TabIndex = 44;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(663, 136);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(117, 20);
            this.label28.TabIndex = 67;
            this.label28.Text = "Precent (%) :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label27.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label27.Location = new System.Drawing.Point(641, 116);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(120, 20);
            this.label27.TabIndex = 68;
            this.label27.Text = "PAPS (inches)";
            // 
            // txtConnectorOtherForce
            // 
            this.txtConnectorOtherForce.Location = new System.Drawing.Point(544, 292);
            this.txtConnectorOtherForce.Name = "txtConnectorOtherForce";
            this.txtConnectorOtherForce.Size = new System.Drawing.Size(80, 22);
            this.txtConnectorOtherForce.TabIndex = 41;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(413, 295);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(128, 20);
            this.label26.TabIndex = 69;
            this.label26.Text = "Other Force :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtConnectorUserFPerPin
            // 
            this.txtConnectorUserFPerPin.Location = new System.Drawing.Point(544, 263);
            this.txtConnectorUserFPerPin.Name = "txtConnectorUserFPerPin";
            this.txtConnectorUserFPerPin.Size = new System.Drawing.Size(80, 22);
            this.txtConnectorUserFPerPin.TabIndex = 39;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(417, 266);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(124, 20);
            this.label25.TabIndex = 70;
            this.label25.Text = "User Force /Pin :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtConnectorMaxFPerPin
            // 
            this.txtConnectorMaxFPerPin.Location = new System.Drawing.Point(544, 234);
            this.txtConnectorMaxFPerPin.Name = "txtConnectorMaxFPerPin";
            this.txtConnectorMaxFPerPin.Size = new System.Drawing.Size(80, 22);
            this.txtConnectorMaxFPerPin.TabIndex = 37;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(421, 237);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(120, 20);
            this.label24.TabIndex = 71;
            this.label24.Text = "Max Force /Pin :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtConnectorMinFPerPin
            // 
            this.txtConnectorMinFPerPin.Location = new System.Drawing.Point(544, 205);
            this.txtConnectorMinFPerPin.Name = "txtConnectorMinFPerPin";
            this.txtConnectorMinFPerPin.Size = new System.Drawing.Size(80, 22);
            this.txtConnectorMinFPerPin.TabIndex = 35;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(421, 208);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(120, 20);
            this.label23.TabIndex = 72;
            this.label23.Text = "Min Force /Pin :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label22.Location = new System.Drawing.Point(402, 188);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(100, 20);
            this.label22.TabIndex = 73;
            this.label22.Text = "Force (lbs)";
            // 
            // txtConnectorGraphDistance
            // 
            this.txtConnectorGraphDistance.Location = new System.Drawing.Point(544, 162);
            this.txtConnectorGraphDistance.Name = "txtConnectorGraphDistance";
            this.txtConnectorGraphDistance.Size = new System.Drawing.Size(80, 22);
            this.txtConnectorGraphDistance.TabIndex = 32;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(421, 165);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 20);
            this.label21.TabIndex = 74;
            this.label21.Text = "Distance (in) :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtConnectorGraphFPerPin
            // 
            this.txtConnectorGraphFPerPin.Location = new System.Drawing.Point(544, 133);
            this.txtConnectorGraphFPerPin.Name = "txtConnectorGraphFPerPin";
            this.txtConnectorGraphFPerPin.Size = new System.Drawing.Size(80, 22);
            this.txtConnectorGraphFPerPin.TabIndex = 30;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(421, 136);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(120, 20);
            this.label20.TabIndex = 75;
            this.label20.Text = "Force (lbs/pin) :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label19.Location = new System.Drawing.Point(402, 116);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 20);
            this.label19.TabIndex = 76;
            this.label19.Text = "Graph Scale";
            // 
            // txtConnectorComments
            // 
            this.txtConnectorComments.Location = new System.Drawing.Point(207, 338);
            this.txtConnectorComments.Name = "txtConnectorComments";
            this.txtConnectorComments.Size = new System.Drawing.Size(656, 22);
            this.txtConnectorComments.TabIndex = 18;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(87, 341);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(114, 20);
            this.label18.TabIndex = 77;
            this.label18.Text = "Comments :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtConnectorPins
            // 
            this.txtConnectorPins.Location = new System.Drawing.Point(262, 133);
            this.txtConnectorPins.Name = "txtConnectorPins";
            this.txtConnectorPins.Size = new System.Drawing.Size(100, 22);
            this.txtConnectorPins.TabIndex = 16;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(150, 136);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 20);
            this.label17.TabIndex = 78;
            this.label17.Text = "No. of Pins :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtConnectorSeatedHeight
            // 
            this.txtConnectorSeatedHeight.Location = new System.Drawing.Point(262, 287);
            this.txtConnectorSeatedHeight.Name = "txtConnectorSeatedHeight";
            this.txtConnectorSeatedHeight.Size = new System.Drawing.Size(100, 22);
            this.txtConnectorSeatedHeight.TabIndex = 14;
            // 
            // txtConnectorHeight
            // 
            this.txtConnectorHeight.Location = new System.Drawing.Point(262, 259);
            this.txtConnectorHeight.Name = "txtConnectorHeight";
            this.txtConnectorHeight.Size = new System.Drawing.Size(100, 22);
            this.txtConnectorHeight.TabIndex = 13;
            // 
            // txtConnectorUnseatedTop
            // 
            this.txtConnectorUnseatedTop.Location = new System.Drawing.Point(262, 231);
            this.txtConnectorUnseatedTop.Name = "txtConnectorUnseatedTop";
            this.txtConnectorUnseatedTop.Size = new System.Drawing.Size(100, 22);
            this.txtConnectorUnseatedTop.TabIndex = 12;
            // 
            // txtConnectorBaseThickness
            // 
            this.txtConnectorBaseThickness.Location = new System.Drawing.Point(262, 203);
            this.txtConnectorBaseThickness.Name = "txtConnectorBaseThickness";
            this.txtConnectorBaseThickness.Size = new System.Drawing.Size(100, 22);
            this.txtConnectorBaseThickness.TabIndex = 11;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(140, 290);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 20);
            this.label16.TabIndex = 79;
            this.label16.Text = "Seated Height :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(156, 262);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 20);
            this.label15.TabIndex = 80;
            this.label15.Text = "Height :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(143, 234);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 20);
            this.label14.TabIndex = 81;
            this.label14.Text = "Unseated Top :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(130, 206);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 20);
            this.label13.TabIndex = 82;
            this.label13.Text = "Base Thickness :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.Location = new System.Drawing.Point(99, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(148, 20);
            this.label12.TabIndex = 83;
            this.label12.Text = "Dimensions (inches)";
            // 
            // cbConnectorToolType
            // 
            this.cbConnectorToolType.Location = new System.Drawing.Point(162, 73);
            this.cbConnectorToolType.Name = "cbConnectorToolType";
            this.cbConnectorToolType.Size = new System.Drawing.Size(200, 24);
            this.cbConnectorToolType.TabIndex = 4;
            // 
            // cbConnectorType
            // 
            this.cbConnectorType.Location = new System.Drawing.Point(162, 43);
            this.cbConnectorType.Name = "cbConnectorType";
            this.cbConnectorType.Size = new System.Drawing.Size(200, 24);
            this.cbConnectorType.TabIndex = 3;
            this.cbConnectorType.SelectedIndexChanged += new System.EventHandler(this.cbConnectorType_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(46, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.TabIndex = 84;
            this.label11.Text = "Tool Type :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(22, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 20);
            this.label10.TabIndex = 85;
            this.label10.Text = "Connector Type :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Yellow;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1141, 34);
            this.label9.TabIndex = 86;
            this.label9.Text = "CONNECTOR   SPECIFICATIONS";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabBoard
            // 
            this.tabBoard.Controls.Add(this.label40);
            this.tabBoard.Controls.Add(this.txtBoardImageFile);
            this.tabBoard.Controls.Add(this.label38);
            this.tabBoard.Controls.Add(this.btnClearConnectorListOnBoard);
            this.tabBoard.Controls.Add(this.btnDeleteConnectorOnBoard);
            this.tabBoard.Controls.Add(this.btnAddConnectorOnBoard);
            this.tabBoard.Controls.Add(this.lvConnectorOnBoardList);
            this.tabBoard.Controls.Add(this.btnBoardImageBrowse);
            this.tabBoard.Controls.Add(this.picBoardPreview);
            this.tabBoard.Controls.Add(this.label39);
            this.tabBoard.Controls.Add(this.txtBoardLength);
            this.tabBoard.Controls.Add(this.txtBoardWidth);
            this.tabBoard.Controls.Add(this.label37);
            this.tabBoard.Controls.Add(this.txtFixtureThickness);
            this.tabBoard.Controls.Add(this.label35);
            this.tabBoard.Controls.Add(this.txtBoardThickness);
            this.tabBoard.Controls.Add(this.label34);
            this.tabBoard.Controls.Add(this.btnDeleteBoardSpec);
            this.tabBoard.Controls.Add(this.cbBoardName);
            this.tabBoard.Controls.Add(this.label33);
            this.tabBoard.Controls.Add(this.txtBoardDESC);
            this.tabBoard.Controls.Add(this.label45);
            this.tabBoard.Controls.Add(this.btnClearBoardSpecEditor);
            this.tabBoard.Controls.Add(this.btnSaveBoardSpec);
            this.tabBoard.Controls.Add(this.label36);
            this.tabBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tabBoard.Location = new System.Drawing.Point(4, 40);
            this.tabBoard.Name = "tabBoard";
            this.tabBoard.Size = new System.Drawing.Size(1141, 483);
            this.tabBoard.TabIndex = 2;
            this.tabBoard.Text = "Board";
            this.tabBoard.UseVisualStyleBackColor = true;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.ForeColor = System.Drawing.Color.Red;
            this.label40.Location = new System.Drawing.Point(613, 52);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(235, 16);
            this.label40.TabIndex = 107;
            this.label40.Text = "Preview need saving info to database.";
            // 
            // txtBoardImageFile
            // 
            this.txtBoardImageFile.Location = new System.Drawing.Point(100, 200);
            this.txtBoardImageFile.Name = "txtBoardImageFile";
            this.txtBoardImageFile.Size = new System.Drawing.Size(398, 22);
            this.txtBoardImageFile.TabIndex = 106;
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label38.Location = new System.Drawing.Point(25, 203);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(69, 20);
            this.label38.TabIndex = 105;
            this.label38.Text = "Image :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnClearConnectorListOnBoard
            // 
            this.btnClearConnectorListOnBoard.Location = new System.Drawing.Point(405, 237);
            this.btnClearConnectorListOnBoard.Name = "btnClearConnectorListOnBoard";
            this.btnClearConnectorListOnBoard.Size = new System.Drawing.Size(169, 29);
            this.btnClearConnectorListOnBoard.TabIndex = 104;
            this.btnClearConnectorListOnBoard.Text = "Clear Connectors List";
            this.btnClearConnectorListOnBoard.UseVisualStyleBackColor = true;
            this.btnClearConnectorListOnBoard.Click += new System.EventHandler(this.btnClearConnectorListOnBoard_Click);
            // 
            // btnDeleteConnectorOnBoard
            // 
            this.btnDeleteConnectorOnBoard.Location = new System.Drawing.Point(178, 237);
            this.btnDeleteConnectorOnBoard.Name = "btnDeleteConnectorOnBoard";
            this.btnDeleteConnectorOnBoard.Size = new System.Drawing.Size(141, 29);
            this.btnDeleteConnectorOnBoard.TabIndex = 103;
            this.btnDeleteConnectorOnBoard.Text = "Delete Connector";
            this.btnDeleteConnectorOnBoard.UseVisualStyleBackColor = true;
            this.btnDeleteConnectorOnBoard.Click += new System.EventHandler(this.btnDeleteConnectorOnBoard_Click);
            // 
            // btnAddConnectorOnBoard
            // 
            this.btnAddConnectorOnBoard.Location = new System.Drawing.Point(19, 237);
            this.btnAddConnectorOnBoard.Name = "btnAddConnectorOnBoard";
            this.btnAddConnectorOnBoard.Size = new System.Drawing.Size(141, 29);
            this.btnAddConnectorOnBoard.TabIndex = 102;
            this.btnAddConnectorOnBoard.Text = "Add Connector";
            this.btnAddConnectorOnBoard.UseVisualStyleBackColor = true;
            this.btnAddConnectorOnBoard.Click += new System.EventHandler(this.btnAddConnectorOnBoard_Click);
            // 
            // lvConnectorOnBoardList
            // 
            this.lvConnectorOnBoardList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvConnectorOnBoardList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRow,
            this.colX,
            this.colY,
            this.colAngle,
            this.colConnector,
            this.colComments});
            this.lvConnectorOnBoardList.FullRowSelect = true;
            this.lvConnectorOnBoardList.GridLines = true;
            this.lvConnectorOnBoardList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvConnectorOnBoardList.HideSelection = false;
            this.lvConnectorOnBoardList.Location = new System.Drawing.Point(19, 272);
            this.lvConnectorOnBoardList.MultiSelect = false;
            this.lvConnectorOnBoardList.Name = "lvConnectorOnBoardList";
            this.lvConnectorOnBoardList.Size = new System.Drawing.Size(1101, 207);
            this.lvConnectorOnBoardList.TabIndex = 101;
            this.lvConnectorOnBoardList.UseCompatibleStateImageBehavior = false;
            this.lvConnectorOnBoardList.View = System.Windows.Forms.View.Details;
            this.lvConnectorOnBoardList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvConnectorOnBoardList_MouseDoubleClick);
            this.lvConnectorOnBoardList.SelectedIndexChanged += new System.EventHandler(this.lvConnectorOnBoardList_SelectedIndexChanged);
            // 
            // colRow
            // 
            this.colRow.Text = "Row";
            this.colRow.Width = 50;
            // 
            // colX
            // 
            this.colX.Text = "X";
            this.colX.Width = 70;
            // 
            // colY
            // 
            this.colY.Text = "Y";
            this.colY.Width = 70;
            // 
            // colAngle
            // 
            this.colAngle.Text = "Angle";
            this.colAngle.Width = 70;
            // 
            // colConnector
            // 
            this.colConnector.Text = "Connector";
            this.colConnector.Width = 250;
            // 
            // colComments
            // 
            this.colComments.Text = "Comments";
            this.colComments.Width = 300;
            // 
            // btnBoardImageBrowse
            // 
            this.btnBoardImageBrowse.Location = new System.Drawing.Point(510, 192);
            this.btnBoardImageBrowse.Name = "btnBoardImageBrowse";
            this.btnBoardImageBrowse.Size = new System.Drawing.Size(64, 30);
            this.btnBoardImageBrowse.TabIndex = 99;
            this.btnBoardImageBrowse.Text = "Browse";
            this.btnBoardImageBrowse.UseVisualStyleBackColor = true;
            this.btnBoardImageBrowse.Click += new System.EventHandler(this.btnBoardImageBrowse_Click);
            // 
            // picBoardPreview
            // 
            this.picBoardPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBoardPreview.Location = new System.Drawing.Point(596, 45);
            this.picBoardPreview.Name = "picBoardPreview";
            this.picBoardPreview.Size = new System.Drawing.Size(443, 221);
            this.picBoardPreview.TabIndex = 98;
            this.picBoardPreview.TabStop = false;
            this.picBoardPreview.Click += new System.EventHandler(this.picBoardImage_Click);
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label39.Location = new System.Drawing.Point(319, 167);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(167, 20);
            this.label39.TabIndex = 97;
            this.label39.Text = "Board Length (Y Dir.) :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBoardLength
            // 
            this.txtBoardLength.Location = new System.Drawing.Point(492, 164);
            this.txtBoardLength.Name = "txtBoardLength";
            this.txtBoardLength.Size = new System.Drawing.Size(82, 22);
            this.txtBoardLength.TabIndex = 95;
            // 
            // txtBoardWidth
            // 
            this.txtBoardWidth.Location = new System.Drawing.Point(198, 164);
            this.txtBoardWidth.Name = "txtBoardWidth";
            this.txtBoardWidth.Size = new System.Drawing.Size(82, 22);
            this.txtBoardWidth.TabIndex = 93;
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label37.Location = new System.Drawing.Point(25, 167);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(167, 20);
            this.label37.TabIndex = 94;
            this.label37.Text = "Board Width (X Dir.) :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtFixtureThickness
            // 
            this.txtFixtureThickness.Location = new System.Drawing.Point(492, 136);
            this.txtFixtureThickness.Name = "txtFixtureThickness";
            this.txtFixtureThickness.Size = new System.Drawing.Size(82, 22);
            this.txtFixtureThickness.TabIndex = 91;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label35.Location = new System.Drawing.Point(350, 139);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(136, 20);
            this.label35.TabIndex = 92;
            this.label35.Text = "Fixture Thickness :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBoardThickness
            // 
            this.txtBoardThickness.Location = new System.Drawing.Point(198, 136);
            this.txtBoardThickness.Name = "txtBoardThickness";
            this.txtBoardThickness.Size = new System.Drawing.Size(82, 22);
            this.txtBoardThickness.TabIndex = 89;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label34.Location = new System.Drawing.Point(56, 139);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(136, 20);
            this.label34.TabIndex = 90;
            this.label34.Text = "Board Thickness :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnDeleteBoardSpec
            // 
            this.btnDeleteBoardSpec.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBoardSpec.Location = new System.Drawing.Point(353, 45);
            this.btnDeleteBoardSpec.Name = "btnDeleteBoardSpec";
            this.btnDeleteBoardSpec.Size = new System.Drawing.Size(221, 31);
            this.btnDeleteBoardSpec.TabIndex = 88;
            this.btnDeleteBoardSpec.Text = "Delete board from database";
            this.btnDeleteBoardSpec.Click += new System.EventHandler(this.btnDeleteBoardSpec_Click);
            // 
            // cbBoardName
            // 
            this.cbBoardName.Location = new System.Drawing.Point(131, 49);
            this.cbBoardName.Name = "cbBoardName";
            this.cbBoardName.Size = new System.Drawing.Size(204, 24);
            this.cbBoardName.TabIndex = 86;
            this.cbBoardName.SelectedIndexChanged += new System.EventHandler(this.cbBoardName_SelectedIndexChanged);
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label33.Location = new System.Drawing.Point(16, 52);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(109, 20);
            this.label33.TabIndex = 87;
            this.label33.Text = "Board Name :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBoardDESC
            // 
            this.txtBoardDESC.Location = new System.Drawing.Point(131, 95);
            this.txtBoardDESC.Name = "txtBoardDESC";
            this.txtBoardDESC.Size = new System.Drawing.Size(443, 22);
            this.txtBoardDESC.TabIndex = 37;
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label45.Location = new System.Drawing.Point(25, 98);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(100, 20);
            this.label45.TabIndex = 38;
            this.label45.Text = "Description :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnClearBoardSpecEditor
            // 
            this.btnClearBoardSpecEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearBoardSpecEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearBoardSpecEditor.Location = new System.Drawing.Point(329, 499);
            this.btnClearBoardSpecEditor.Name = "btnClearBoardSpecEditor";
            this.btnClearBoardSpecEditor.Size = new System.Drawing.Size(245, 41);
            this.btnClearBoardSpecEditor.TabIndex = 13;
            this.btnClearBoardSpecEditor.Text = "Clear board spec. editor";
            this.btnClearBoardSpecEditor.Click += new System.EventHandler(this.btnClearBoardSpecEditor_Click);
            // 
            // btnSaveBoardSpec
            // 
            this.btnSaveBoardSpec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveBoardSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBoardSpec.Location = new System.Drawing.Point(19, 499);
            this.btnSaveBoardSpec.Name = "btnSaveBoardSpec";
            this.btnSaveBoardSpec.Size = new System.Drawing.Size(289, 41);
            this.btnSaveBoardSpec.TabIndex = 12;
            this.btnSaveBoardSpec.Text = "Save board specifications";
            this.btnSaveBoardSpec.Click += new System.EventHandler(this.btnSaveBoardSpec_Click);
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.Teal;
            this.label36.Dock = System.Windows.Forms.DockStyle.Top;
            this.label36.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.White;
            this.label36.Location = new System.Drawing.Point(0, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(1141, 32);
            this.label36.TabIndex = 51;
            this.label36.Text = "BOARD   SPECIFICATIONS";
            this.label36.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabRun
            // 
            this.tabRun.Controls.Add(this.lbRunProfileName);
            this.tabRun.Controls.Add(this.label80);
            this.tabRun.Controls.Add(this.lbRunConnectorType);
            this.tabRun.Controls.Add(this.label78);
            this.tabRun.Controls.Add(this.lbRunToolType);
            this.tabRun.Controls.Add(this.label76);
            this.tabRun.Controls.Add(this.lbRunConnectorAngle);
            this.tabRun.Controls.Add(this.label74);
            this.tabRun.Controls.Add(this.lbRunConnectorY);
            this.tabRun.Controls.Add(this.label72);
            this.tabRun.Controls.Add(this.lbRunConnectorX);
            this.tabRun.Controls.Add(this.label49);
            this.tabRun.Controls.Add(this.lbRunPins);
            this.tabRun.Controls.Add(this.label47);
            this.tabRun.Controls.Add(this.lbRunConnectorCount);
            this.tabRun.Controls.Add(this.label44);
            this.tabRun.Controls.Add(this.lbRunConnectorIndex);
            this.tabRun.Controls.Add(this.label41);
            this.tabRun.Controls.Add(this.rtbRunStatus);
            this.tabRun.Controls.Add(this.picGraph);
            this.tabRun.Controls.Add(this.picBoardOnRun);
            this.tabRun.Controls.Add(this.panel4);
            this.tabRun.Location = new System.Drawing.Point(4, 40);
            this.tabRun.Name = "tabRun";
            this.tabRun.Size = new System.Drawing.Size(1149, 527);
            this.tabRun.TabIndex = 4;
            this.tabRun.Text = "Run";
            // 
            // lbRunProfileName
            // 
            this.lbRunProfileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRunProfileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbRunProfileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbRunProfileName.Location = new System.Drawing.Point(878, 403);
            this.lbRunProfileName.Name = "lbRunProfileName";
            this.lbRunProfileName.Size = new System.Drawing.Size(268, 26);
            this.lbRunProfileName.TabIndex = 21;
            this.lbRunProfileName.Text = "Profile name";
            // 
            // label80
            // 
            this.label80.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label80.Location = new System.Drawing.Point(805, 404);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(67, 24);
            this.label80.TabIndex = 20;
            this.label80.Text = "Profile:";
            // 
            // lbRunConnectorType
            // 
            this.lbRunConnectorType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRunConnectorType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbRunConnectorType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbRunConnectorType.Location = new System.Drawing.Point(490, 403);
            this.lbRunConnectorType.Name = "lbRunConnectorType";
            this.lbRunConnectorType.Size = new System.Drawing.Size(309, 26);
            this.lbRunConnectorType.TabIndex = 19;
            this.lbRunConnectorType.Text = "Connector type";
            // 
            // label78
            // 
            this.label78.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label78.AutoSize = true;
            this.label78.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label78.Location = new System.Drawing.Point(381, 404);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(103, 24);
            this.label78.TabIndex = 18;
            this.label78.Text = "Connector:";
            // 
            // lbRunToolType
            // 
            this.lbRunToolType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRunToolType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbRunToolType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbRunToolType.Location = new System.Drawing.Point(822, 439);
            this.lbRunToolType.Name = "lbRunToolType";
            this.lbRunToolType.Size = new System.Drawing.Size(324, 26);
            this.lbRunToolType.TabIndex = 17;
            this.lbRunToolType.Text = "Tool Type";
            // 
            // label76
            // 
            this.label76.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label76.Location = new System.Drawing.Point(763, 440);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(53, 24);
            this.label76.TabIndex = 16;
            this.label76.Text = "Tool:";
            // 
            // lbRunConnectorAngle
            // 
            this.lbRunConnectorAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRunConnectorAngle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbRunConnectorAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbRunConnectorAngle.Location = new System.Drawing.Point(705, 439);
            this.lbRunConnectorAngle.Name = "lbRunConnectorAngle";
            this.lbRunConnectorAngle.Size = new System.Drawing.Size(52, 26);
            this.lbRunConnectorAngle.TabIndex = 15;
            this.lbRunConnectorAngle.Text = "360";
            this.lbRunConnectorAngle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label74
            // 
            this.label74.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label74.AutoSize = true;
            this.label74.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label74.Location = new System.Drawing.Point(634, 440);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(65, 24);
            this.label74.TabIndex = 14;
            this.label74.Text = "Angle:";
            // 
            // lbRunConnectorY
            // 
            this.lbRunConnectorY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRunConnectorY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbRunConnectorY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbRunConnectorY.Location = new System.Drawing.Point(526, 439);
            this.lbRunConnectorY.Name = "lbRunConnectorY";
            this.lbRunConnectorY.Size = new System.Drawing.Size(102, 26);
            this.lbRunConnectorY.TabIndex = 13;
            this.lbRunConnectorY.Text = "88.888";
            this.lbRunConnectorY.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label72
            // 
            this.label72.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label72.Location = new System.Drawing.Point(493, 441);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(27, 24);
            this.label72.TabIndex = 12;
            this.label72.Text = "Y:";
            // 
            // lbRunConnectorX
            // 
            this.lbRunConnectorX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRunConnectorX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbRunConnectorX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbRunConnectorX.Location = new System.Drawing.Point(385, 439);
            this.lbRunConnectorX.Name = "lbRunConnectorX";
            this.lbRunConnectorX.Size = new System.Drawing.Size(102, 26);
            this.lbRunConnectorX.TabIndex = 11;
            this.lbRunConnectorX.Text = "88.888";
            this.lbRunConnectorX.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label49
            // 
            this.label49.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label49.Location = new System.Drawing.Point(354, 441);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(29, 24);
            this.label49.TabIndex = 10;
            this.label49.Text = "X:";
            // 
            // lbRunPins
            // 
            this.lbRunPins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRunPins.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbRunPins.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbRunPins.Location = new System.Drawing.Point(289, 441);
            this.lbRunPins.Name = "lbRunPins";
            this.lbRunPins.Size = new System.Drawing.Size(59, 26);
            this.lbRunPins.TabIndex = 9;
            this.lbRunPins.Text = "888";
            this.lbRunPins.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label47
            // 
            this.label47.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label47.Location = new System.Drawing.Point(227, 441);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(56, 24);
            this.label47.TabIndex = 8;
            this.label47.Text = "#Pins";
            // 
            // lbRunConnectorCount
            // 
            this.lbRunConnectorCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRunConnectorCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbRunConnectorCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbRunConnectorCount.Location = new System.Drawing.Point(180, 441);
            this.lbRunConnectorCount.Name = "lbRunConnectorCount";
            this.lbRunConnectorCount.Size = new System.Drawing.Size(41, 26);
            this.lbRunConnectorCount.TabIndex = 7;
            this.lbRunConnectorCount.Text = "99";
            this.lbRunConnectorCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label44
            // 
            this.label44.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label44.Location = new System.Drawing.Point(149, 441);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(25, 24);
            this.label44.TabIndex = 6;
            this.label44.Text = "of";
            // 
            // lbRunConnectorIndex
            // 
            this.lbRunConnectorIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRunConnectorIndex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbRunConnectorIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbRunConnectorIndex.Location = new System.Drawing.Point(106, 441);
            this.lbRunConnectorIndex.Name = "lbRunConnectorIndex";
            this.lbRunConnectorIndex.Size = new System.Drawing.Size(37, 25);
            this.lbRunConnectorIndex.TabIndex = 5;
            this.lbRunConnectorIndex.Text = "2";
            this.lbRunConnectorIndex.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label41
            // 
            this.label41.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label41.Location = new System.Drawing.Point(21, 441);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(79, 24);
            this.label41.TabIndex = 4;
            this.label41.Text = "Number";
            // 
            // rtbRunStatus
            // 
            this.rtbRunStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbRunStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rtbRunStatus.Location = new System.Drawing.Point(3, 372);
            this.rtbRunStatus.Name = "rtbRunStatus";
            this.rtbRunStatus.Size = new System.Drawing.Size(359, 66);
            this.rtbRunStatus.TabIndex = 3;
            this.rtbRunStatus.Text = "";
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGraph.Location = new System.Drawing.Point(368, 7);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(778, 392);
            this.picGraph.TabIndex = 2;
            this.picGraph.TabStop = false;
            // 
            // picBoardOnRun
            // 
            this.picBoardOnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoardOnRun.BackColor = System.Drawing.Color.LightSkyBlue;
            this.picBoardOnRun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoardOnRun.Location = new System.Drawing.Point(3, 7);
            this.picBoardOnRun.Name = "picBoardOnRun";
            this.picBoardOnRun.Size = new System.Drawing.Size(359, 359);
            this.picBoardOnRun.TabIndex = 1;
            this.picBoardOnRun.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Controls.Add(this.btnRun);
            this.panel4.Controls.Add(this.btnSelectBoard);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 475);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1149, 52);
            this.panel4.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRun.ForeColor = System.Drawing.Color.Black;
            this.btnRun.Location = new System.Drawing.Point(248, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(196, 46);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "RUN";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnSelectBoard
            // 
            this.btnSelectBoard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectBoard.BackColor = System.Drawing.Color.Navy;
            this.btnSelectBoard.ForeColor = System.Drawing.Color.White;
            this.btnSelectBoard.Location = new System.Drawing.Point(3, 3);
            this.btnSelectBoard.Name = "btnSelectBoard";
            this.btnSelectBoard.Size = new System.Drawing.Size(202, 46);
            this.btnSelectBoard.TabIndex = 0;
            this.btnSelectBoard.Text = "Select Board";
            this.btnSelectBoard.UseVisualStyleBackColor = false;
            this.btnSelectBoard.Click += new System.EventHandler(this.btnSelectBoard_Click);
            // 
            // lblLoginUserName
            // 
            this.lblLoginUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoginUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLoginUserName.Location = new System.Drawing.Point(512, 9);
            this.lblLoginUserName.Name = "lblLoginUserName";
            this.lblLoginUserName.Size = new System.Drawing.Size(219, 35);
            this.lblLoginUserName.TabIndex = 11;
            this.lblLoginUserName.Text = "Login : ";
            // 
            // lblLoginTime
            // 
            this.lblLoginTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoginTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLoginTime.Location = new System.Drawing.Point(737, 9);
            this.lblLoginTime.Name = "lblLoginTime";
            this.lblLoginTime.Size = new System.Drawing.Size(312, 35);
            this.lblLoginTime.TabIndex = 12;
            this.lblLoginTime.Text = "Time : ";
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1055, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(114, 40);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label60
            // 
            this.label60.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label60.BackColor = System.Drawing.Color.Maroon;
            this.label60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label60.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.Color.White;
            this.label60.Location = new System.Drawing.Point(0, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(488, 45);
            this.label60.TabIndex = 14;
            this.label60.Text = "PRESS FIT PRO";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Maroon;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbMessage.ForeColor = System.Drawing.Color.Blue;
            this.lbMessage.Location = new System.Drawing.Point(247, 203);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(654, 223);
            this.lbMessage.TabIndex = 16;
            this.lbMessage.Text = "********************************";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMessage.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 647);
            this.ControlBox = false;
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label60);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblLoginUserName);
            this.Controls.Add(this.lblLoginTime);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "frmMain";
            this.Text = "Press Fit Pro";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabMain.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            this.tabUser.PerformLayout();
            this.gbAccountType.ResumeLayout(false);
            this.gbAccountType.PerformLayout();
            this.tabLog.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabEditor.ResumeLayout(false);
            this.tabAllEditor.ResumeLayout(false);
            this.tabTool.ResumeLayout(false);
            this.tabTool.PerformLayout();
            this.tabProfile.ResumeLayout(false);
            this.tabProfile.PerformLayout();
            this.tabConnector.ResumeLayout(false);
            this.tabConnector.PerformLayout();
            this.tabBoard.ResumeLayout(false);
            this.tabBoard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoardPreview)).EndInit();
            this.tabRun.ResumeLayout(false);
            this.tabRun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoardOnRun)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox43;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.TabPage tabEditor;
        private System.Windows.Forms.TabControl tabAllEditor;
        private System.Windows.Forms.TabPage tabTool;
        private System.Windows.Forms.Button btnDeleteTool;
        private System.Windows.Forms.Button btnSaveToolEditor;
        private System.Windows.Forms.TextBox txtToolComments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtToolLength;
        private System.Windows.Forms.TextBox txtToolWidth;
        private System.Windows.Forms.TextBox txtToolHeight;
        private System.Windows.Forms.TextBox txtToolClearance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabConnector;
        private System.Windows.Forms.Button btnDeleteConnector;
        private System.Windows.Forms.Button btnClearConnectorSpecEditor;
        private System.Windows.Forms.Button btnSaveConnector;
        private System.Windows.Forms.TextBox txtConnectorFGradDegrees;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtConnectorPARSDistance;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtConnectorPARSStartHeight;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtConnectorPARSPercent;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtConnectorOtherForce;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtConnectorUserFPerPin;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtConnectorMaxFPerPin;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtConnectorMinFPerPin;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtConnectorGraphDistance;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtConnectorGraphFPerPin;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtConnectorComments;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtConnectorPins;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtConnectorSeatedHeight;
        private System.Windows.Forms.TextBox txtConnectorHeight;
        private System.Windows.Forms.TextBox txtConnectorUnseatedTop;
        private System.Windows.Forms.TextBox txtConnectorBaseThickness;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbConnectorToolType;
        private System.Windows.Forms.ComboBox cbConnectorType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabBoard;
        private System.Windows.Forms.TextBox txtBoardDESC;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button btnClearBoardSpecEditor;
        private System.Windows.Forms.Button btnSaveBoardSpec;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TabPage tabRun;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnSelectBoard;
        private System.Windows.Forms.Label lblLoginUserName;
        private System.Windows.Forms.Label lblLoginTime;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.PictureBox picBoardOnRun;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.ListBox lbUserList;
        private System.Windows.Forms.GroupBox gbAccountType;
        private System.Windows.Forms.RadioButton rtbUserType;
        private System.Windows.Forms.RadioButton rtbAdminType;
        private System.Windows.Forms.RichTextBox rtbRunStatus;
        private System.Windows.Forms.TextBox txtToolBarcode;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.ComboBox cbToolType;
        private System.Windows.Forms.Button btnClearToolEditor;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.ComboBox cbProfileName;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.TextBox txtProfileSampleDistance;
        private System.Windows.Forms.TextBox txtProfileSampleStart;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.TextBox txtProfileError5;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.TextBox txtProfileError4;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.TextBox txtProfileError3;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox txtProfileError2;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox txtProfileError1;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.ListView lvProfile;
        private System.Windows.Forms.ColumnHeader colProfileRow;
        private System.Windows.Forms.ColumnHeader colProfileHeight;
        private System.Windows.Forms.ColumnHeader colProfileHeightAction;
        private System.Windows.Forms.ColumnHeader colProfileForce;
        private System.Windows.Forms.ColumnHeader colProfileForceAction;
        private System.Windows.Forms.ColumnHeader colProfileSpeed;
        private System.Windows.Forms.ColumnHeader colProfileComments;
        private System.Windows.Forms.Button btnDefaultProfileData;
        private System.Windows.Forms.Button btnSaveProfile;
        private System.Windows.Forms.Button btnDeleteProfile;
        private System.Windows.Forms.ColumnHeader colProfileHeightPar;
        private System.Windows.Forms.ColumnHeader colProfileForcePar;
        private System.Windows.Forms.ComboBox cbConnectorProfileName;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Button btnDeleteBoardSpec;
        private System.Windows.Forms.ComboBox cbBoardName;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtBoardThickness;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtFixtureThickness;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtBoardLength;
        private System.Windows.Forms.TextBox txtBoardWidth;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button btnBoardImageBrowse;
        private System.Windows.Forms.PictureBox picBoardPreview;
        private System.Windows.Forms.ListView lvConnectorOnBoardList;
        private System.Windows.Forms.ColumnHeader colRow;
        private System.Windows.Forms.ColumnHeader colX;
        private System.Windows.Forms.ColumnHeader colY;
        private System.Windows.Forms.ColumnHeader colAngle;
        private System.Windows.Forms.ColumnHeader colConnector;
        private System.Windows.Forms.ColumnHeader colComments;
        private System.Windows.Forms.Button btnAddConnectorOnBoard;
        private System.Windows.Forms.Button btnClearConnectorListOnBoard;
        private System.Windows.Forms.Button btnDeleteConnectorOnBoard;
        private System.Windows.Forms.TextBox txtBoardImageFile;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Label lbRunConnectorIndex;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label lbRunConnectorCount;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label lbRunPins;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label lbRunConnectorX;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label lbRunConnectorAngle;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label lbRunConnectorY;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label lbRunToolType;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label lbRunProfileName;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label lbRunConnectorType;
        private System.Windows.Forms.Label label78;
    }
}

