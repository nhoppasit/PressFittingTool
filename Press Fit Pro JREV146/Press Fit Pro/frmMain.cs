using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Press_Fit_Pro
{
    public partial class frmMain : Form
    {
        #region UI delegate

        private delegate void VoidDelegate();

        public void PostLog(string msg, int err)
        {
            string s = "T(" + System.Environment.TickCount.ToString() + ") : " + msg;
            if (err != 0) s += " - Err : 0x" + Convert.ToString(err, 16);

            if (rtbRunStatus.InvokeRequired)
            {
                rtbRunStatus.Invoke(new VoidDelegate(delegate()
                {
                    rtbRunStatus.Text = s + Environment.NewLine + rtbRunStatus.Text;
                }));
            }
            else
            {
                rtbRunStatus.Text = s + Environment.NewLine + rtbRunStatus.Text;
            }
        }

        public void PostEnable(bool e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new VoidDelegate(delegate()
                {
                    this.Enabled = e;
                }));
            }
            else
            {
                this.Enabled = e;
            }
        }

        public void PostMessage(string text)
        {
            if (lbMessage.InvokeRequired)
            {
                lbMessage.Invoke(new VoidDelegate(delegate()
                {
                    if (text == "")
                    {
                        lbMessage.Visible = false;
                    }
                    else
                    {
                        lbMessage.Text = text;
                        lbMessage.Visible = true;
                        lbMessage.BringToFront();
                    }
                }));
            }
            else
            {
                if (text == "")
                {
                    lbMessage.Visible = false;
                }
                else
                {
                    lbMessage.Text = text;
                    lbMessage.Visible = true;
                    lbMessage.BringToFront();
                }
            }
        }

        public void PostConnectorInfo(int index, int count, ConnectorInfo connector)
        {
            if (lbRunConnectorIndex.InvokeRequired)
            {
                lbRunConnectorIndex.Invoke(new VoidDelegate(delegate()
                {
                    lbRunConnectorIndex.Text = index.ToString();
                    lbRunConnectorCount.Text = count.ToString();
                    lbRunPins.Text = connector.NumberOfPins.ToString();
                    lbRunConnectorX.Text = connector.Location.X.ToString("0.000");
                    lbRunConnectorY.Text = connector.Location.Y.ToString("0.000");
                    lbRunConnectorAngle.Text = connector.Angle.ToString("0.0");
                    lbRunToolType.Text = connector.ToolType;
                    lbRunConnectorType.Text = connector.ConnectorType;
                    lbRunProfileName.Text = connector.ProfileName;
                }));
            }
            else
            {
                lbRunConnectorIndex.Text = index.ToString();
                lbRunConnectorCount.Text = count.ToString();
                lbRunPins.Text = connector.NumberOfPins.ToString();
                lbRunConnectorX.Text = connector.Location.X.ToString("0.000");
                lbRunConnectorY.Text = connector.Location.Y.ToString("0.000");
                lbRunConnectorAngle.Text = connector.Angle.ToString("0.0");
                lbRunToolType.Text = connector.ToolType;
                lbRunConnectorType.Text = connector.ConnectorType;
                lbRunProfileName.Text = connector.ProfileName;
            }
        }

        #endregion

        #region Properties

        private string _LoginUserName;
        public string LoginUserName
        {
            get { return _LoginUserName; }
            set
            {
                _LoginUserName = value;
                lblLoginUserName.Text = "User : " + _LoginUserName;
            }
        }

        private string _LoginTime;
        public string LoginTime
        {
            get { return _LoginTime; }
            set
            {
                _LoginTime = value;
                lblLoginTime.Text = "Time : " + _LoginTime;
            }
        }

        #endregion

        #region Constructor / Deconstructor

        public frmMain()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region Login / Logout / Form load

        private void frmMain_Load(object sender, EventArgs e)
        {
            UI.InitUI(this);

            /* --------------------------------------------------------------------------------
             * Load ข้อมูลจากฐานข้อมูล
             * --------------------------------------------------------------------------------*/
            UserManagement um = new UserManagement();
            ToolManagement tm = new ToolManagement();
            ProfileManagement pm = new ProfileManagement();
            ConnectorSpecManagement cm = new ConnectorSpecManagement();
            BoardSpecManagement bm = new BoardSpecManagement();

            um.ShowUserList(ref lbUserList);

            tm.ShowToolList(ref cbToolType);
            ClearToolEditor();

            pm.ShowProfileList(ref cbProfileName);
            DefaultProfileEditor();

            cm.ShowConnectorList(ref cbConnectorType);
            tm.ShowToolList(ref cbConnectorToolType);
            pm.ShowProfileList(ref cbConnectorProfileName);
            ClearConnectorSpecEditor();
            //
            // Board editor page
            bm.ShowBoardList(ref cbBoardName);
            ClearBoardSpecEditor();
            //
            // Run page
            lbRunConnectorIndex.Text = "";
            lbRunConnectorCount.Text = "";
            lbRunPins.Text = "";
            lbRunConnectorX.Text = "";
            lbRunConnectorY.Text = "";
            lbRunConnectorAngle.Text = "";
            lbRunToolType.Text = "";
            lbRunConnectorType.Text = "";
            lbRunProfileName.Text = "";
            //
            /* --------------------------------------------------------------------------------
             * เปิดหน้าเข้าระบบ
             * --------------------------------------------------------------------------------*/
            LoginClass login = new LoginClass(ref lblLoginUserName, ref lblLoginTime);
            login.ShowDialog();
            tabMain.SelectTab(tabRun.Name);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Do you want to logout?", "Logout",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question,
                                               MessageBoxDefaultButton.Button2);
            if (ret == DialogResult.Yes)
            {
                LoginClass login = new LoginClass(ref lblLoginUserName, ref lblLoginTime);
                login.ShowDialog();
            }
        }

        #endregion

        #region Run

        RunPressFitClass run;

        private void btnSelectBoard_Click(object sender, EventArgs e)
        {
            if (run != null)
            {
                DialogResult ret;                
                ret = MessageBox.Show("Do you want to change the BOARD?",
                                                  "Select board",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question,
                                                  MessageBoxDefaultButton.Button2);
                if (ret == DialogResult.Yes)
                {
                    if (run != null)
                    {
                        run.Dispose();
                        run = null;
                    }
                }
                else
                {
                    return;
                }
            }

            //Do select board
            SelectBoardClass sb = new SelectBoardClass();
            sb.ShowDialog();
            if (sb.IsSelected)
            {
                if (run != null)
                {
                    run.Dispose();
                    run = null;
                }
                var me = this;
                run = new RunPressFitClass(ref me, ref picBoardOnRun, ref picGraph, sb.SelectedBoard);
                RunPressFitClass.Board.ConnectorEntities[0].Select = true;
                RunPressFitClass.Board.DrawNow();
                RunPressFitClass.Plotter.Clear();
                UI.UpdateConnectorInfo(1, sb.SelectedBoard.ConnectorList.Count, sb.SelectedBoard.ConnectorList[0]);
                rtbRunStatus.Text = "";
                UI.Log("New board>>", 0);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (run != null)
            {
                /* -----------------------------------------------------
                 * Define run history here .
                 * Then run
                 * -----------------------------------------------------*/
                HistoryManagement hm = new HistoryManagement();
                string resCode, resDesc;
                string hisFile = hm.AddNewHistory(run.Info.BoardName, UserManagement.UserName, out resCode, out resDesc);
                if (resCode.Equals("00") & !hisFile.Equals(""))
                {
                    run.Start(hisFile);
                }
                else if (resCode.Equals("00") & hisFile.Equals(""))
                {
                    Log.AppendText("ไม่มีชื่อไฟล์สำหรับบันทึก ฐานข้อมูลผิดพลาด");
                    UI.Log("History file name empty! Database error.", 0);
                    UI.ShowMessage("History file name empty! Database error.");
                    System.Threading.Thread.Sleep(4000);
                    UI.ShowMessage("");
                }
                else
                {
                    Log.AppendText(resDesc);
                    UI.Log(resDesc, 0);
                    UI.ShowMessage(resDesc);
                    System.Threading.Thread.Sleep(4000);
                    UI.ShowMessage("");
                }
            }
        }

        #endregion

        #region User editor

        private void btnReload_Click(object sender, EventArgs e)
        {
            UserManagement um = new UserManagement();
            um.ShowUserList(ref lbUserList);
        }

        void UpdateUserInfo()
        {
            try
            {
                string str = lbUserList.SelectedItem.ToString();
                string[] astr = str.Split(',');
                txtUserName.Text = astr[0].Trim();
                txtFirstName.Text = astr[1].Trim();
                txtLastName.Text = astr[2].Trim();
                if (astr[3].Trim().Equals("Administrator")) rtbAdminType.Checked = true;
                if (astr[3].Trim().Equals("User")) rtbUserType.Checked = true;
            }
            catch (Exception ex) { Log.AppendText(ex.Message); }
        }

        private void lbUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUserInfo();
        }

        private void lbUserList_Click(object sender, EventArgs e)
        {
            UpdateUserInfo();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                Log.AppendText("กำลังเรียกหน้าต่างเพิ่ม User...");
                frmAddUser dlg = new frmAddUser();
                dlg.ShowDialog();
                UserManagement um = new UserManagement();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    Log.AppendText("เริ่มต้นการเพิ่ม User...");
                    string resCode;
                    string resDesc;
                    string crptPassword = StringCipher.Encrypt(dlg.Password, true);
                    um.AddNewUser(dlg.UserID, dlg.FirstName, dlg.LastName, dlg.UserType, crptPassword, UserManagement.UserName, out resCode, out resDesc);
                    if (resCode.Equals("00"))
                    {
                        Log.AppendText("เพิ่มข้อมูลผู้ใช้ระบบใหม่เรียบร้อย");
                        MessageBox.Show("เพิ่มข้อมูลผู้ใช้ระบบใหม่เรียบร้อย");
                    }
                    else
                    {
                        Log.AppendText("ERROR! : " + resDesc);
                        MessageBox.Show("ผิดพลาด! เพิ่มข้อมูลผู้ใช้ระบบใหม่ไม่สำเร็จ  | " + resDesc);
                    }
                }
                else
                {
                    Log.AppendText("ยกเลิกหน้าต่างเพิ่ม User เรียบร้อย");
                }
                dlg.Dispose();
                um.ShowUserList(ref lbUserList);
            }
            catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                Log.AppendText("ตรวจสอบชื่อผู้ใช้จากรายการ...");
                string userID;
                try
                {
                    string str = lbUserList.SelectedItem.ToString();
                    string[] astr = str.Split(',');
                    userID = astr[0].Trim();
                    Log.AppendText("ชื่อผู้ใช้ คือ " + userID);
                }
                catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show("ไม่สามารถระบุ ผู้ใช้ ได้กรุณาตรวจสอบการเลือก"); return; }

                Log.AppendText("กำลังเรียกหน้าต่าง Delete user...");
                DialogResult dre;
                dre = MessageBox.Show("คุณต้องการลบผู้ใช้ " + userID + " ใช่หรือไม่?", "Delete user", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                UserManagement um = new UserManagement();
                if (dre == DialogResult.Yes)
                {
                    Log.AppendText("เริ่มต้นการลบ User...");
                    string resCode;
                    string resDesc;

                    um.DeleteUser(userID, UserManagement.UserName, out resCode, out resDesc);

                    if (resCode.Equals("00"))
                    {
                        Log.AppendText("ลบผู้ใช้ระบบเรียบร้อย");
                        MessageBox.Show("ลบผู้ใช้ระบบเรียบร้อย");
                    }
                    else
                    {
                        Log.AppendText("ERROR! : " + resDesc);
                        MessageBox.Show("ERROR! ลบผู้ใช้ระบบไม่สำเร็จ  | " + resDesc);
                    }
                }
                else
                {
                    Log.AppendText("ยกเลิกการลบ User");
                }
                um.ShowUserList(ref lbUserList);
            }
            catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); }
        }

        #endregion

        #region Tool editor

        private void btnSaveToolEditor_Click(object sender, EventArgs e)
        {
            try
            {
                Log.AppendText("เริ่มต้นการบันทึก Tool...");
                ToolManagement tm = new ToolManagement();
                string resCode;
                string resDesc;

                Log.AppendText("ตรวจสอบข้อมูลขนาด Tool...");
                float t_clearance = 0, t_height = 0, t_width = 0, t_length = 0;
                try { t_clearance = float.Parse(txtToolClearance.Text); }
                catch { MessageBox.Show("Invalid tool clearance!"); txtToolClearance.Focus(); return; }
                try { t_height = float.Parse(txtToolHeight.Text); }
                catch { MessageBox.Show("Invalid tool height!"); txtToolHeight.Focus(); return; }
                try { t_width = float.Parse(txtToolWidth.Text); }
                catch { MessageBox.Show("Invalid tool width!"); txtToolWidth.Focus(); return; }
                try { t_length = float.Parse(txtToolLength.Text); }
                catch { MessageBox.Show("Invalid tool length!"); txtToolLength.Focus(); return; }
                Log.AppendText("ตรวจสอบข้อมูลขนาด Tool เรียบร้อย");

                string toolType = cbToolType.Text;
                tm.SaveToolData(cbToolType.Text, txtToolBarcode.Text, t_clearance, t_height, t_width, t_length, txtToolComments.Text, UserManagement.UserName, out resCode, out resDesc);
                if (resCode.Equals("00"))
                {
                    tm.ShowToolList(ref cbToolType);
                    cbToolType.Text = toolType;
                    Log.AppendText("เพิ่มข้อมูล  Tool ใหม่เรียบร้อย");
                    MessageBox.Show("เพิ่มข้อมูล Tool ใหม่เรียบร้อย");
                }
                else if (resCode.Equals("01"))
                {
                    Log.AppendText("บันทึกข้อมูล  Tool เรียบร้อย");
                    MessageBox.Show("บันทึกข้อมูล Tool เรียบร้อย");
                }
                else
                {
                    Log.AppendText("ERROR! : " + resDesc);
                    MessageBox.Show("ผิดพลาด! บันทึกข้อมูล Tool ไม่สำเร็จ  | " + resDesc);
                }
            }
            catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); }
        }

        private void btnDeleteTool_Click(object sender, EventArgs e)
        {
            try
            {
                string toolType = cbToolType.Text;
                Log.AppendText("กำลังยืนยัน Delete tool...");
                DialogResult dre;
                dre = MessageBox.Show("คุณต้องการลบ Tool " + toolType + " ใช่หรือไม่?", "Delete tool", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                ToolManagement tm = new ToolManagement();
                if (dre == DialogResult.Yes)
                {
                    Log.AppendText("เริ่มต้นการลบ Tool...");
                    string resCode;
                    string resDesc;

                    tm.DeleteTool(toolType, UserManagement.UserName, out resCode, out resDesc);

                    if (resCode.Equals("00"))
                    {
                        Log.AppendText("ลบ Tool เรียบร้อย");
                        MessageBox.Show("ลบ Tool เรียบร้อย");
                    }
                    else
                    {
                        Log.AppendText("ERROR! : " + resDesc);
                        MessageBox.Show("ERROR! : " + resDesc);
                    }
                }
                else
                {
                    Log.AppendText("ยกเลิกการลบ...");
                }
                tm.ShowToolList(ref cbToolType);
            }
            catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); }
        }

        private void btnClearToolEditor_Click(object sender, EventArgs e)
        {
            ClearToolEditor();
        }

        private void cbToolType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string toolType = cbToolType.Text;
                ToolManagement tm = new ToolManagement();
                tm.LoadToolData(toolType, ref txtToolClearance, ref txtToolHeight, ref txtToolWidth, ref txtToolLength, ref txtToolBarcode, ref txtToolComments);
            }
            catch { }
        }

        void ClearToolEditor()
        {
            cbToolType.Text = "";
            txtToolClearance.Text = "";
            txtToolHeight.Text = "";
            txtToolWidth.Text = "";
            txtToolLength.Text = "";
            txtToolBarcode.Text = "";
            txtToolComments.Text = "";
        }

        #endregion

        #region Profile

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            try
            {
                Log.AppendText("เริ่มต้นการบันทึก Profile...");
                ProfileManagement pm = new ProfileManagement();
                string resCode;
                string resDesc;

                string profileName = "";
                float sampleStart = 0, sampleDistance = 0;
                string Error1 = "", Error2 = "", Error3 = "", Error4 = "", Error5 = "";
                float H1Par = 0, H2Par = 0, H3Par = 0, H4Par = 0, H5Par = 0, H6Par = 0, H7Par = 0;
                string HAC1 = "", HAC2 = "", HAC3 = "", HAC4 = "", HAC5 = "", HAC6 = "", HAC7 = "";
                float F1Par = 0, F2Par = 0, F3Par = 0, F4Par = 0, F5Par = 0, F6Par = 0, F7Par = 0;
                string FAC1 = "", FAC2 = "", FAC3 = "", FAC4 = "", FAC5 = "", FAC6 = "", FAC7 = "";
                float SP1 = 0, SP2 = 0, SP3 = 0, SP4 = 0, SP5 = 0, SP6 = 0, SP7 = 0;

                /* --------------------------------------------------------------------------------------
                 * Validation
                 * --------------------------------------------------------------------------------------*/
                profileName = cbProfileName.Text;
                if (profileName.Equals("")) { MessageBox.Show("Please fill profile name."); cbProfileName.Focus(); return; }

                try { sampleStart = float.Parse(txtProfileSampleStart.Text); }
                catch { MessageBox.Show("Please verify sample start height."); txtProfileSampleStart.Focus(); return; }
                try { sampleDistance = float.Parse(txtProfileSampleDistance.Text); }
                catch { MessageBox.Show("Please verify sample distance."); txtProfileSampleDistance.Focus(); return; }

                Error1 = txtProfileError1.Text;
                Error2 = txtProfileError2.Text;
                Error3 = txtProfileError3.Text;
                Error4 = txtProfileError4.Text;
                Error5 = txtProfileError5.Text;

                try { H1Par = float.Parse(lvProfile.Items[0].SubItems[2].Text); }
                catch { MessageBox.Show("Please verify row 1 height parameter."); return; }
                try { H2Par = float.Parse(lvProfile.Items[1].SubItems[2].Text); }
                catch { MessageBox.Show("Please verify row 2 height parameter."); return; }
                try { H3Par = float.Parse(lvProfile.Items[2].SubItems[2].Text); }
                catch { MessageBox.Show("Please verify row 3 height parameter."); return; }
                try { H4Par = float.Parse(lvProfile.Items[3].SubItems[2].Text); }
                catch { MessageBox.Show("Please verify row 4 height parameter."); return; }
                try { H5Par = float.Parse(lvProfile.Items[4].SubItems[2].Text); }
                catch { MessageBox.Show("Please verify row 5 height parameter."); return; }
                try { H6Par = float.Parse(lvProfile.Items[5].SubItems[2].Text); }
                catch { MessageBox.Show("Please verify row 6 height parameter."); return; }
                try { H7Par = float.Parse(lvProfile.Items[6].SubItems[2].Text); }
                catch { MessageBox.Show("Please verify row 7 height parameter."); return; }

                try { HAC1 = lvProfile.Items[0].SubItems[3].Text; }
                catch { MessageBox.Show("Please verify row 1 height action."); return; }
                try { HAC2 = lvProfile.Items[1].SubItems[3].Text; }
                catch { MessageBox.Show("Please verify row 2 height action."); return; }
                try { HAC3 = lvProfile.Items[2].SubItems[3].Text; }
                catch { MessageBox.Show("Please verify row 3 height action."); return; }
                try { HAC4 = lvProfile.Items[3].SubItems[3].Text; }
                catch { MessageBox.Show("Please verify row 4 height action."); return; }
                try { HAC5 = lvProfile.Items[4].SubItems[3].Text; }
                catch { MessageBox.Show("Please verify row 5 height action."); return; }
                try { HAC6 = lvProfile.Items[5].SubItems[3].Text; }
                catch { MessageBox.Show("Please verify row 6 height action."); return; }
                try { HAC7 = lvProfile.Items[6].SubItems[3].Text; }
                catch { MessageBox.Show("Please verify row 7 height action."); return; }

                try { F1Par = float.Parse(lvProfile.Items[0].SubItems[5].Text); }
                catch { MessageBox.Show("Please verify row 1 force parameter."); return; }
                try { F2Par = float.Parse(lvProfile.Items[1].SubItems[5].Text); }
                catch { MessageBox.Show("Please verify row 2 force parameter."); return; }
                try { F3Par = float.Parse(lvProfile.Items[2].SubItems[5].Text); }
                catch { MessageBox.Show("Please verify row 3 force parameter."); return; }
                try { F4Par = float.Parse(lvProfile.Items[3].SubItems[5].Text); }
                catch { MessageBox.Show("Please verify row 4 force parameter."); return; }
                try { F5Par = float.Parse(lvProfile.Items[4].SubItems[5].Text); }
                catch { MessageBox.Show("Please verify row 5 force parameter."); return; }
                try { F6Par = float.Parse(lvProfile.Items[5].SubItems[5].Text); }
                catch { MessageBox.Show("Please verify row 6 force parameter."); return; }
                try { F7Par = float.Parse(lvProfile.Items[6].SubItems[5].Text); }
                catch { MessageBox.Show("Please verify row 7 force parameter."); return; }

                try { FAC1 = lvProfile.Items[0].SubItems[6].Text; }
                catch { MessageBox.Show("Please verify row 1 force action."); return; }
                try { FAC2 = lvProfile.Items[1].SubItems[6].Text; }
                catch { MessageBox.Show("Please verify row 2 force action."); return; }
                try { FAC3 = lvProfile.Items[2].SubItems[6].Text; }
                catch { MessageBox.Show("Please verify row 3 force action."); return; }
                try { FAC4 = lvProfile.Items[3].SubItems[6].Text; }
                catch { MessageBox.Show("Please verify row 4 force action."); return; }
                try { FAC5 = lvProfile.Items[4].SubItems[6].Text; }
                catch { MessageBox.Show("Please verify row 5 force action."); return; }
                try { FAC6 = lvProfile.Items[5].SubItems[6].Text; }
                catch { MessageBox.Show("Please verify row 6 force action."); return; }
                try { FAC7 = lvProfile.Items[6].SubItems[6].Text; }
                catch { MessageBox.Show("Please verify row 7 force action."); return; }

                try { SP1 = float.Parse(lvProfile.Items[0].SubItems[7].Text); }
                catch { MessageBox.Show("Please verify row 1 speed."); return; }
                try { SP2 = float.Parse(lvProfile.Items[1].SubItems[7].Text); }
                catch { MessageBox.Show("Please verify row 2 speed."); return; }
                try { SP3 = float.Parse(lvProfile.Items[2].SubItems[7].Text); }
                catch { MessageBox.Show("Please verify row 3 speed."); return; }
                try { SP4 = float.Parse(lvProfile.Items[3].SubItems[7].Text); }
                catch { MessageBox.Show("Please verify row 4 speed."); return; }
                try { SP5 = float.Parse(lvProfile.Items[4].SubItems[7].Text); }
                catch { MessageBox.Show("Please verify row 5 speed."); return; }
                try { SP6 = float.Parse(lvProfile.Items[5].SubItems[7].Text); }
                catch { MessageBox.Show("Please verify row 6 speed."); return; }
                try { SP7 = float.Parse(lvProfile.Items[6].SubItems[7].Text); }
                catch { MessageBox.Show("Please verify row 7 speed."); return; }

                /* --------------------------------------------------------------------------------------
                 * Do save data
                 * --------------------------------------------------------------------------------------*/
                pm.SaveProfileData(profileName, sampleStart, sampleDistance,
                        Error1, Error2, Error3, Error4, Error5,
                        H1Par, H2Par, H3Par, H4Par, H5Par, H6Par, H7Par,
                        HAC1, HAC2, HAC3, HAC4, HAC5, HAC6, HAC7,
                        F1Par, F2Par, F3Par, F4Par, F5Par, F6Par, F7Par,
                        FAC1, FAC2, FAC3, FAC4, FAC5, FAC6, FAC7,
                        SP1, SP2, SP3, SP4, SP5, SP6, SP7,
                        UserManagement.UserName, out resCode, out resDesc);
                if (resCode.Equals("00"))
                {
                    pm.ShowProfileList(ref cbProfileName);
                    cbProfileName.Text = profileName;
                    Log.AppendText("เพิ่มข้อมูล  Profile ใหม่เรียบร้อย");
                    MessageBox.Show("เพิ่มข้อมูล Profile ใหม่เรียบร้อย");
                }
                else if (resCode.Equals("01"))
                {
                    Log.AppendText("บันทึกข้อมูล  Profile เรียบร้อย");
                    MessageBox.Show("บันทึกข้อมูล Profile เรียบร้อย");
                }
                else
                {
                    Log.AppendText("ERROR! : " + resDesc);
                    MessageBox.Show("ผิดพลาด! บันทึกข้อมูล Profile ไม่สำเร็จ  | " + resDesc);
                }
            }
            catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); }
        }

        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            try
            {
                string profileName = cbProfileName.Text;
                Log.AppendText("กำลังยืนยัน Delete Profile...");
                DialogResult dre;
                dre = MessageBox.Show("คุณต้องการลบ Profile " + profileName + " ใช่หรือไม่?", "Delete Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                ProfileManagement pm = new ProfileManagement();
                if (dre == DialogResult.Yes)
                {
                    Log.AppendText("เริ่มต้นการลบ Profile...");
                    string resCode;
                    string resDesc;

                    pm.DeleteProfile(profileName, UserManagement.UserName, out resCode, out resDesc);

                    if (resCode.Equals("00"))
                    {
                        Log.AppendText("ลบ Profile เรียบร้อย");
                        MessageBox.Show("ลบ Profile เรียบร้อย");
                    }
                    else
                    {
                        Log.AppendText("ERROR! : " + resDesc);
                        MessageBox.Show("ERROR! : " + resDesc);
                    }
                }
                else
                {
                    Log.AppendText("ยกเลิกการลบ...");
                }
                pm.ShowProfileList(ref cbProfileName);
            }
            catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); }
        }

        private void lvProfile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lvProfile.SelectedItems.Count > 0)
                {
                    using (frmProfileParameterEdit dlg = new frmProfileParameterEdit())
                    {
                        dlg.HeightParameter = float.Parse(lvProfile.SelectedItems[0].SubItems[2].Text);
                        dlg.HeightAction = lvProfile.SelectedItems[0].SubItems[3].Text;
                        dlg.ForceParameter = float.Parse(lvProfile.SelectedItems[0].SubItems[5].Text);
                        dlg.ForceAction = lvProfile.SelectedItems[0].SubItems[6].Text;
                        dlg.Speed = float.Parse(lvProfile.SelectedItems[0].SubItems[7].Text);
                        dlg.ShowDialog();
                        if (dlg.DialogResult == DialogResult.OK)
                        {
                            lvProfile.SelectedItems[0].SubItems[2].Text = dlg.HeightParameter.ToString("#0.000");
                            lvProfile.SelectedItems[0].SubItems[3].Text = dlg.HeightAction;
                            lvProfile.SelectedItems[0].SubItems[5].Text = dlg.ForceParameter.ToString("#0.0");
                            lvProfile.SelectedItems[0].SubItems[6].Text = dlg.ForceAction;
                            lvProfile.SelectedItems[0].SubItems[7].Text = dlg.Speed.ToString("#0.000");
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cbProfileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string profileName = cbProfileName.Text;
                ProfileManagement pm = new ProfileManagement();

                pm.LoadProfileData(profileName, ref txtProfileSampleStart, ref txtProfileSampleDistance, ref txtProfileError1, ref txtProfileError2, ref txtProfileError3, ref txtProfileError4, ref txtProfileError5, ref lvProfile);
            }
            catch { }
        }

        void DefaultProfileEditor()
        {
            cbProfileName.Text = "";

            txtProfileSampleStart.Text = "0.005"; // in
            txtProfileSampleDistance.Text = "0.005";

            txtProfileError1.Text = "Premeasure contact detected.";
            txtProfileError2.Text = "Insufficient force.";
            txtProfileError3.Text = "Missing connector.";
            txtProfileError4.Text = "Excessive force.";
            txtProfileError5.Text = "";

            string[] astr1 = { "1", "Unseated Tool Top", "0.030", "Next Step", "", "100", "Error 1", "0.300", "Move to tool top" };
            string[] astr2 = { "2", "Seated Tool Top", "0.030", "Go To 5", "Min F/Pin * #Pins", "", "Next Step", "0.150", "Test missing or repress" };
            string[] astr3 = { "3", "Seated Tool Top", "0.010", "Next Step", "Max F/Pin * #Pins", "", "Error 4", "0.100", "Test within seated height" };
            string[] astr4 = { "4", "Seated Tool Top", "-0.010", "Error 2", "PARS - FPPL 25%", "", "Complete", "0.100", "Seat connector" };
            string[] astr5 = { "5", "Seated Tool Top", "", "Error 3", "", "100", "Next Step", "0.100", "Test missing" };
            string[] astr6 = { "6", "Seated Tool Top", "0.010", "Next Step", "Max F/Pin * #Pins", "", "Error 4", "0.100", "Test repress within seated height" };
            string[] astr7 = { "7", "Seated Tool Top", "-0.010", "Error 2", "Force Grad CDB", "", "Complete", "0.100", "Seat repress" };

            lvProfile.Items.Clear();
            lvProfile.Items.Add(new ListViewItem(astr1));
            lvProfile.Items.Add(new ListViewItem(astr2));
            lvProfile.Items.Add(new ListViewItem(astr3));
            lvProfile.Items.Add(new ListViewItem(astr4));
            lvProfile.Items.Add(new ListViewItem(astr5));
            lvProfile.Items.Add(new ListViewItem(astr6));
            lvProfile.Items.Add(new ListViewItem(astr7));
        }

        private void btnDefaultProfileData_Click(object sender, EventArgs e)
        {
            DefaultProfileEditor();
        }

        #endregion

        #region Connector

        private void btnSaveConnector_Click(object sender, EventArgs e)
        {
            try
            {
                Log.AppendText("เริ่มต้นการบันทึก Connector specifications...");
                ConnectorSpecManagement cm = new ConnectorSpecManagement();
                string resCode;
                string resDesc;

                Log.AppendText("ตรวจสอบข้อมูล Connector specifications...");

                string connectorType = cbConnectorType.Text;
                string toolType = cbConnectorToolType.Text;
                string profileName = cbConnectorProfileName.Text;

                int pins = 0;
                float baseThickness = 0, unseatedTop = 0, _height = 0, seatedHeight = 0,
                    graphFPerPin = 0, graphDistance = 0,
                    minFPerPin = 0, maxFPerPin = 0, userFPerPin = 0, otherForce = 0,
                    parsPercent = 0, parsStartHeight = 0, parsDistance = 0,
                    gradDegrees = 0;
                string comments = "";

                /* -------------------------------------------------------------------------------------------------------------------
                 * Connector specifications validation
                 * -------------------------------------------------------------------------------------------------------------------*/
                if (connectorType.Equals("")) { MessageBox.Show("Please fill connector type."); cbConnectorType.Focus(); return; }
                if (toolType.Equals("")) { MessageBox.Show("Please fill tool type."); cbConnectorToolType.Focus(); return; }
                if (profileName.Equals("")) { MessageBox.Show("Please fill profile name."); cbConnectorProfileName.Focus(); return; }
                // ....
                try { pins = int.Parse(txtConnectorPins.Text); }
                catch { MessageBox.Show("Invalid number of Pins!"); txtConnectorPins.Focus(); return; }
                if (pins <= 0) { MessageBox.Show("Invalid number of Pins!"); txtConnectorPins.Focus(); return; }
                // ....
                try { baseThickness = float.Parse(txtConnectorBaseThickness.Text); }
                catch { MessageBox.Show("Invalid base thickness!"); txtConnectorBaseThickness.Focus(); return; }
                if (baseThickness <= 0) { MessageBox.Show("Invalid base thickness!"); txtConnectorBaseThickness.Focus(); return; }
                //
                try { unseatedTop = float.Parse(txtConnectorUnseatedTop.Text); }
                catch { MessageBox.Show("Invalid unseated top!"); txtConnectorUnseatedTop.Focus(); return; }
                if (unseatedTop <= 0) { MessageBox.Show("Invalid unseated top!"); txtConnectorUnseatedTop.Focus(); return; }
                //
                try { _height = float.Parse(txtConnectorHeight.Text); }
                catch { MessageBox.Show("Invalid connector height!"); txtConnectorHeight.Focus(); return; }
                if (_height < baseThickness) { MessageBox.Show("Invalid connector height!"); txtConnectorHeight.Focus(); return; }
                //
                try { seatedHeight = float.Parse(txtConnectorSeatedHeight.Text); }
                catch { MessageBox.Show("Invalid seated height!"); txtConnectorSeatedHeight.Focus(); return; }
                // ....
                try { graphFPerPin = float.Parse(txtConnectorGraphFPerPin.Text); }
                catch { MessageBox.Show("Invalid graph force scale!"); txtConnectorGraphFPerPin.Focus(); return; }
                if (graphFPerPin <= 0) { MessageBox.Show("Invalid graph force scale!"); txtConnectorGraphFPerPin.Focus(); return; }
                //
                try { graphDistance = float.Parse(txtConnectorGraphDistance.Text); }
                catch { MessageBox.Show("Invalid graph distance scale!"); txtConnectorGraphDistance.Focus(); return; }
                if (graphDistance <= 0) { MessageBox.Show("Invalid graph distance scale!"); txtConnectorGraphDistance.Focus(); return; }
                // ....
                try { minFPerPin = float.Parse(txtConnectorMinFPerPin.Text); }
                catch { MessageBox.Show("Invalid Min force / pin!"); txtConnectorMinFPerPin.Focus(); return; }
                if (minFPerPin <= 0) { MessageBox.Show("Invalid Min force / pin!"); txtConnectorMinFPerPin.Focus(); return; }
                //
                try { maxFPerPin = float.Parse(txtConnectorMaxFPerPin.Text); }
                catch { MessageBox.Show("Invalid max force / pin!"); txtConnectorMaxFPerPin.Focus(); return; }
                if (maxFPerPin <= 0) { MessageBox.Show("Invalid max force / pin!"); txtConnectorMaxFPerPin.Focus(); return; }
                //
                try { userFPerPin = float.Parse(txtConnectorUserFPerPin.Text); }
                catch { MessageBox.Show("Invalid user force / pin!"); txtConnectorUserFPerPin.Focus(); return; }
                //
                try { otherForce = float.Parse(txtConnectorOtherForce.Text); }
                catch { MessageBox.Show("Invalid other force!"); txtConnectorOtherForce.Focus(); return; }
                //
                try { parsPercent = float.Parse(txtConnectorPARSPercent.Text); }
                catch { MessageBox.Show("Invalid PARS percent!"); txtConnectorPARSPercent.Focus(); return; }
                if (parsPercent <= 0) { MessageBox.Show("Invalid PARS percent!"); txtConnectorPARSPercent.Focus(); return; }
                //
                try { parsStartHeight = float.Parse(txtConnectorPARSStartHeight.Text); }
                catch { MessageBox.Show("Invalid PARS start height!"); txtConnectorPARSStartHeight.Focus(); return; }
                if (parsStartHeight <= 0) { MessageBox.Show("Invalid PARS start height!"); txtConnectorPARSStartHeight.Focus(); return; }
                //
                try { parsDistance = float.Parse(txtConnectorPARSDistance.Text); }
                catch { MessageBox.Show("Invalid PARS distance!"); txtConnectorPARSDistance.Focus(); return; }
                if (parsDistance <= 0) { MessageBox.Show("Invalid PARS distance!"); txtConnectorPARSDistance.Focus(); return; }
                //
                try { gradDegrees = float.Parse(txtConnectorFGradDegrees.Text); }
                catch { MessageBox.Show("Invalid force gradient degrees!"); txtConnectorFGradDegrees.Focus(); return; }
                if (gradDegrees <= 0) { MessageBox.Show("Invalid force gradient degrees!"); txtConnectorFGradDegrees.Focus(); return; }
                //
                comments = txtConnectorComments.Text;
                //
                Log.AppendText("ตรวจสอบข้อมูล Connector specifications เรียบร้อย");
                //
                /* -------------------------------------------------------------------------------------------------------------------
                 * Save connector specifications
                 * -------------------------------------------------------------------------------------------------------------------*/
                cm.SaveConnectorSpec(connectorType, toolType, profileName, pins,
                    baseThickness, unseatedTop, _height, seatedHeight,
                    graphFPerPin, graphDistance,
                    minFPerPin, maxFPerPin, userFPerPin, otherForce,
                    parsPercent, parsStartHeight, parsDistance,
                    gradDegrees, comments,
                    UserManagement.UserName, out resCode, out resDesc);
                if (resCode.Equals("00"))
                {
                    cm.ShowConnectorList(ref cbConnectorType);
                    cbConnectorType.Text = connectorType;
                    Log.AppendText("เพิ่มข้อมูล  Connector spec. ใหม่เรียบร้อย");
                    MessageBox.Show("เพิ่มข้อมูล Connector spec. ใหม่เรียบร้อย");
                }
                else if (resCode.Equals("01"))
                {
                    Log.AppendText("บันทึกข้อมูล  Connector spec. เรียบร้อย");
                    MessageBox.Show("บันทึกข้อมูล Connector spec. เรียบร้อย");
                }
                else
                {
                    Log.AppendText("ERROR! : " + resDesc);
                    MessageBox.Show("ผิดพลาด! บันทึกข้อมูล Connector spec. ไม่สำเร็จ  | " + resDesc);
                }
            }
            catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); }
        }

        private void btnClearConnectorSpecEditor_Click(object sender, EventArgs e)
        {
            ClearConnectorSpecEditor();
        }

        private void btnDeleteConnector_Click(object sender, EventArgs e)
        {
            try
            {
                string connectorType = cbConnectorType.Text;
                Log.AppendText("กำลังยืนยัน Delete connector specifications...");
                DialogResult dre;
                dre = MessageBox.Show("คุณต้องการลบ Connector specifications " + connectorType + " ใช่หรือไม่?", "Delete connector spec.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                ConnectorSpecManagement cm = new ConnectorSpecManagement();
                if (dre == DialogResult.Yes)
                {
                    Log.AppendText("เริ่มต้นการลบ Connector specifications...");
                    string resCode;
                    string resDesc;

                    cm.DeleteConnectorSpec(connectorType, UserManagement.UserName, out resCode, out resDesc);

                    if (resCode.Equals("00"))
                    {
                        Log.AppendText("ลบ Connector specifications เรียบร้อย");
                        MessageBox.Show("ลบ Connector specifications เรียบร้อย");
                    }
                    else
                    {
                        Log.AppendText("ERROR! : " + resDesc);
                        MessageBox.Show("ERROR! : " + resDesc);
                    }
                }
                else
                {
                    Log.AppendText("ยกเลิกการลบ...");
                }
                cm.ShowConnectorList(ref cbConnectorType);
            }
            catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); }
        }

        private void cbConnectorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string connectorType = cbConnectorType.Text;
                ConnectorSpecManagement cm = new ConnectorSpecManagement();
                cm.LoadConnectorSpec(connectorType, ref cbConnectorToolType, ref cbConnectorProfileName, ref txtConnectorPins,
                    ref txtConnectorBaseThickness, ref txtConnectorUnseatedTop, ref txtConnectorHeight, ref txtConnectorSeatedHeight,
                    ref txtConnectorGraphFPerPin, ref txtConnectorGraphDistance,
                    ref txtConnectorMinFPerPin, ref txtConnectorMaxFPerPin, ref txtConnectorUserFPerPin, ref txtConnectorOtherForce,
                    ref txtConnectorPARSPercent, ref txtConnectorPARSStartHeight, ref txtConnectorPARSDistance,
                    ref txtConnectorFGradDegrees, ref txtConnectorComments);
            }
            catch { }
        }

        void ClearConnectorSpecEditor()
        {
            cbConnectorType.Text = "";
            cbConnectorToolType.Text = "";
            cbConnectorProfileName.Text = "";

            txtConnectorPins.Text = "";
            txtConnectorBaseThickness.Text = "";
            txtConnectorUnseatedTop.Text = "";
            txtConnectorHeight.Text = "";
            txtConnectorSeatedHeight.Text = "";

            txtConnectorGraphFPerPin.Text = "";
            txtConnectorGraphDistance.Text = "";

            txtConnectorMinFPerPin.Text = "";
            txtConnectorMaxFPerPin.Text = "";
            txtConnectorUserFPerPin.Text = "";
            txtConnectorOtherForce.Text = "";

            txtConnectorPARSPercent.Text = "";
            txtConnectorPARSStartHeight.Text = "";
            txtConnectorPARSDistance.Text = "";

            txtConnectorFGradDegrees.Text = "";
        }

        #endregion

        #region Board

        private void btnAddConnectorOnBoard_Click(object sender, EventArgs e)
        {
            AddConnectorOnBoard();
        }

        private void btnDeleteConnectorOnBoard_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvConnectorOnBoardList.SelectedItems.Count > 0)
                {
                    DialogResult dre = MessageBox.Show(
                        "Do you want to delete connector - " + lvConnectorOnBoardList.SelectedItems[0].Text + " ?", "Delete connector...",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dre == DialogResult.Yes) lvConnectorOnBoardList.Items.Remove(lvConnectorOnBoardList.SelectedItems[0]);
                }
                for (int i = 0; i < lvConnectorOnBoardList.Items.Count; i++)
                    lvConnectorOnBoardList.Items[i].Text = (i + 1).ToString();
            }
            catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); }
        }

        private void btnClearConnectorListOnBoard_Click(object sender, EventArgs e)
        {
            DialogResult dre = MessageBox.Show("Do you want to clear connector list?", "Clear connectors...",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dre == DialogResult.Yes) lvConnectorOnBoardList.Items.Clear();
        }

        private void btnSaveBoardSpec_Click(object sender, EventArgs e)
        {
            SaveCurrentBoardSpecifications();
        }

        private void btnClearBoardSpecEditor_Click(object sender, EventArgs e)
        {
            ClearBoardSpecEditor();
        }

        private void btnBoardImageBrowse_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void picBoardImage_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void cbBoardName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBoardSpec();
        }

        private void btnDeleteBoardSpec_Click(object sender, EventArgs e)
        {
            try
            {
                string boardName = cbBoardName.Text;
                Log.AppendText("กำลังยืนยัน Delete board specifications...");
                DialogResult dre;
                dre = MessageBox.Show("คุณต้องการลบ board specifications " + boardName + " ใช่หรือไม่?", "Delete board spec.",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                BoardSpecManagement cm = new BoardSpecManagement();
                if (dre == DialogResult.Yes)
                {
                    Log.AppendText("เริ่มต้นการลบ board specifications...");
                    string resCode;
                    string resDesc;

                    cm.DeleteBoardSpec(boardName, UserManagement.UserName, out resCode, out resDesc);

                    if (resCode.Equals("00"))
                    {
                        Log.AppendText("ลบ board specifications เรียบร้อย");
                        MessageBox.Show("ลบ board specifications เรียบร้อย");
                    }
                    else
                    {
                        Log.AppendText("ERROR! : " + resDesc);
                        MessageBox.Show("ERROR! : " + resDesc);
                    }
                }
                else
                {
                    Log.AppendText("ยกเลิกการลบ...");
                }
                cm.ShowBoardList(ref cbBoardName);
            }
            catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); }
        }

        void SaveCurrentBoardSpecifications()
        {
            try
            {
                Log.AppendText("เริ่มต้นการบันทึก Board specifications...");
                BoardSpecManagement bm = new BoardSpecManagement();
                string resCode;
                string resDesc;

                string boardName = "", boardDescription = "", imageFile = "";
                float boardThickness = 0, boardWidth = 0, boardLength = 0;
                float fixtureThickness = 0;
                List<int> rowList = new List<int>();
                List<float> xList = new List<float>();
                List<float> yList = new List<float>();
                List<float> angleList = new List<float>();
                List<string> connectorTypeList = new List<string>();
                List<string> commentsList = new List<string>();

                /* --------------------------------------------------------------------------------------
                 * Validation : Board specifications
                 * --------------------------------------------------------------------------------------*/
                boardName = cbBoardName.Text;
                if (boardName.Equals("")) { MessageBox.Show("Please fill board name."); cbBoardName.Focus(); return; }
                boardDescription = txtBoardDESC.Text;
                try { boardThickness = float.Parse(txtBoardThickness.Text); }
                catch { MessageBox.Show("Please verify board thickness."); return; }
                try { boardWidth = float.Parse(txtBoardWidth.Text); }
                catch { MessageBox.Show("Please verify board width."); return; }
                try { boardLength = float.Parse(txtBoardLength.Text); }
                catch { MessageBox.Show("Please verify board length."); return; }
                try { fixtureThickness = float.Parse(txtFixtureThickness.Text); }
                catch { MessageBox.Show("Please verify fixture thickness."); return; }
                imageFile = txtBoardImageFile.Text;
                if (imageFile.Equals(""))
                {
                    MessageBox.Show("Invalid board image file path. Please verify the image file path.");
                    DialogResult dre = MessageBox.Show("Do you want to continue without board image?", "Board image",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dre != DialogResult.Yes) return;
                }

                try
                {
                    if (lvConnectorOnBoardList.Items != null)
                    {
                        if (lvConnectorOnBoardList.Items.Count > 0)
                        {
                            foreach (ListViewItem lvi in lvConnectorOnBoardList.Items)
                            {
                                rowList.Add(Convert.ToInt32(lvi.Text));
                                xList.Add(float.Parse(lvi.SubItems[1].Text));
                                yList.Add(float.Parse(lvi.SubItems[2].Text));
                                angleList.Add(float.Parse(lvi.SubItems[3].Text));
                                connectorTypeList.Add(lvi.SubItems[4].Text);
                                commentsList.Add(lvi.SubItems[5].Text);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please add connectors onto board.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please add connectors onto board.");
                        return;
                    }
                }
                catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); return; }

                /* --------------------------------------------------------------------------------------
                 * Do save data
                 * --------------------------------------------------------------------------------------*/
                bm.SaveBoardSpec(boardName, boardDescription, imageFile, boardThickness, boardWidth, boardLength, fixtureThickness,
                        rowList, xList, yList, angleList, connectorTypeList, commentsList,
                        UserManagement.UserName, out resCode, out resDesc);
                if (resCode.Equals("00"))
                {
                    bm.ShowBoardList(ref cbBoardName);
                    cbBoardName.Text = boardName;
                    Log.AppendText("เพิ่มข้อมูล  Board Spec ใหม่เรียบร้อย");
                    MessageBox.Show("เพิ่มข้อมูล Board Spec ใหม่เรียบร้อย");

                    LoadBoardSpec();
                }
                else if (resCode.Equals("01"))
                {
                    Log.AppendText("บันทึกข้อมูล  Board Spec เรียบร้อย");
                    MessageBox.Show("บันทึกข้อมูล Board Spec เรียบร้อย");

                    LoadBoardSpec();
                }
                else
                {
                    Log.AppendText("ERROR! : " + resDesc);
                    MessageBox.Show("ผิดพลาด! บันทึกข้อมูล Board Spec ไม่สำเร็จ  | " + resDesc);
                }
            }
            catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); }
        }

        void AddConnectorOnBoard()
        {
            try
            {
                DialogResult dre;
                using (frmConnectorOnBoardEdit dlg = new frmConnectorOnBoardEdit())
                {
                    dre = dlg.ShowDialog();
                    if (dre == DialogResult.OK)
                    {
                        string[] astr = { "-", dlg.X.ToString("0.000"), dlg.Y.ToString("0.000"), dlg.Angle.ToString("0.0"), dlg.ConnectorType, dlg.Comments };
                        lvConnectorOnBoardList.Items.Add(new ListViewItem(astr));
                        for (int i = 0; i < lvConnectorOnBoardList.Items.Count; i++)
                            lvConnectorOnBoardList.Items[i].Text = (i + 1).ToString();
                    }
                }
            }
            catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); }
        }

        void ClearBoardSpecEditor()
        {
            cbBoardName.Text = "";
            txtBoardDESC.Text = "";
            txtBoardThickness.Text = "";
            txtFixtureThickness.Text = "";
            txtBoardWidth.Text = "";
            txtBoardLength.Text = "";
            txtBoardImageFile.Text = "";
            lvConnectorOnBoardList.Items.Clear();
        }

        BoardModelClass bmcPreview;
        void LoadImage()
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "";
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                string sep = string.Empty;
                foreach (var c in codecs)
                {
                    string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                    dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
                    sep = "|";
                }
                dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "All Files", "*.*");
                DialogResult dre = dlg.ShowDialog();
                if (dre == DialogResult.OK)
                {
                    txtBoardImageFile.Text = dlg.FileName;
                    float boardWidth, boardLength;
                    try { boardWidth = float.Parse(txtBoardWidth.Text); }
                    catch { boardWidth = 100; }
                    try { boardLength = float.Parse(txtBoardLength.Text); }
                    catch { boardLength = 100; }
                    BoardInfo info = new BoardInfo();
                    info.PhysicalSize = new SizeF(boardWidth, boardLength);
                    info.ImageFile = txtBoardImageFile.Text;
                    if (bmcPreview == null) bmcPreview = new BoardModelClass(ref picBoardPreview, info);
                    else bmcPreview.UpdateBoardInfo(info);
                }
            }
            catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); }
        }

        void LoadBoardSpec()
        {
            try
            {
                string boardName = cbBoardName.Text;
                BoardSpecManagement bm = new BoardSpecManagement();
                bm.LoadBoardSpec(boardName, ref txtBoardDESC, ref txtBoardWidth, ref txtBoardLength, ref txtBoardThickness, ref txtFixtureThickness,
                    ref txtBoardImageFile, ref lvConnectorOnBoardList, ref bmcPreview, ref picBoardPreview);
                bmcPreview.DrawNow();
            }
            catch { }
        }

        private void lvConnectorOnBoardList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvConnectorOnBoardList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                DialogResult dre;
                using (frmConnectorOnBoardEdit dlg = new frmConnectorOnBoardEdit())
                {
                    ListViewItem lvi = lvConnectorOnBoardList.SelectedItems[0];
                    dlg.X = float.Parse(lvi.SubItems[1].Text);
                    dlg.Y = float.Parse(lvi.SubItems[2].Text);
                    dlg.Angle = float.Parse(lvi.SubItems[3].Text);
                    dlg.ConnectorType = lvi.SubItems[4].Text;
                    dlg.Comments = lvi.SubItems[5].Text;
                    dre = dlg.ShowDialog();
                    if (dre == DialogResult.OK)
                    {
                        string[] astr = { "-", dlg.X.ToString("0.000"), dlg.Y.ToString("0.000"), dlg.Angle.ToString("0.0"), dlg.ConnectorType, dlg.Comments };
                        lvConnectorOnBoardList.SelectedItems[0].SubItems[1].Text = dlg.X.ToString("0.000");
                        lvConnectorOnBoardList.SelectedItems[0].SubItems[2].Text = dlg.Y.ToString("0.000");
                        lvConnectorOnBoardList.SelectedItems[0].SubItems[3].Text = dlg.Angle.ToString("0.000");
                        lvConnectorOnBoardList.SelectedItems[0].SubItems[4].Text = dlg.ConnectorType.ToString();
                        lvConnectorOnBoardList.SelectedItems[0].SubItems[5].Text = dlg.Comments.ToString();
                        for (int i = 0; i < lvConnectorOnBoardList.Items.Count; i++)
                            lvConnectorOnBoardList.Items[i].Text = (i + 1).ToString();
                    }
                }
            }
            catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); }
        }

        #endregion

    }
}
