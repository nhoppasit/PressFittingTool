using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Press_Fit_Pro
{
    public class ProfileManagement
    {
        public void ShowProfileList(ref ComboBox cbo)
        {
            try
            {
                Log.AppendText("กำลังเรียกข้อมูล Profiles...");
                ManageBiz ms = new ManageBiz();
                DataTable dtUser;
                dtUser = ms.GetProfileList();
                cbo.DataSource = null;
                if (dtUser.Rows.Count > 0)
                {
                    cbo.DataSource = dtUser;
                    cbo.DisplayMember = "ProfileName";
                    cbo.ValueMember = "ProfileName";
                    Log.AppendText("เรียกข้อมูล Profiles เรียบร้อย");
                }
                else
                {
                    Log.AppendText("ไม่พบข้อมูล Profiles");
                }
            }
            catch (Exception ex)
            {
                Log.AppendText(ex.Message);
                MessageBox.Show(ex.Message);
                cbo.DataSource = null;
            }
        }

        public void SaveProfileData(string profileName, float sampleStart, float sampleDistance,
            string Error1, string Error2, string Error3, string Error4, string Error5,
            float H1Par, float H2Par, float H3Par, float H4Par, float H5Par, float H6Par, float H7Par,
            string HAC1, string HAC2, string HAC3, string HAC4, string HAC5, string HAC6, string HAC7,
            float F1Par, float F2Par, float F3Par, float F4Par, float F5Par, float F6Par, float F7Par,
            string FAC1, string FAC2, string FAC3, string FAC4, string FAC5, string FAC6, string FAC7,
            float SP1, float SP2, float SP3, float SP4, float SP5, float SP6, float SP7,
            string byWho, out string resCode, out string resDesc)
        {
            try
            {
                Log.AppendText("กำลังบันทึกข้อมูล Profile {" + profileName + ", " + sampleStart.ToString() + ", " + sampleDistance.ToString() + ", " +
                    Error1 + ", " + Error2 + ", " + Error3 + ", " + Error4 + ", " + Error5 + ", " +
                    H1Par.ToString() + ", " + H2Par.ToString() + ", " + H3Par.ToString() + ", " + H4Par.ToString() + ", " + H5Par.ToString() + ", " + H6Par.ToString() + ", " + H7Par.ToString() + ", " +
                    HAC1 + ", " + HAC2 + ", " + HAC3 + ", " + HAC4 + ", " + HAC5 + ", " + HAC6 + ", " + HAC7 + ", " +
                    F1Par.ToString() + ", " + F2Par.ToString() + ", " + F3Par.ToString() + ", " + F4Par.ToString() + ", " + F5Par.ToString() + ", " + F6Par.ToString() + ", " + F7Par.ToString() + ", " +
                    FAC1 + ", " + FAC2 + ", " + FAC3 + ", " + FAC4 + ", " + FAC5 + ", " + FAC6 + ", " + FAC7 + ", " +
                    SP1.ToString() + ", " + SP2.ToString() + ", " + SP3.ToString() + ", " + SP4.ToString() + ", " + SP5.ToString() + ", " + SP6.ToString() + ", " + SP7.ToString()  +
                     "} by " + byWho);

                ManageBiz ms = new ManageBiz();
                DataTable dtUser;
                dtUser = ms.GetProfileBy(profileName);
                if (dtUser.Rows.Count == 0)
                {
                    Log.AppendText("ตรวจสอบ ProfileName เรียบร้อย");
                    ms.AddNewProfile(profileName, sampleStart, sampleDistance, 
                        Error1, Error2, Error3, Error4, Error5,
                        H1Par, H2Par, H3Par, H4Par, H5Par, H6Par, H7Par, 
                        HAC1, HAC2, HAC3, HAC4, HAC5, HAC6, HAC7,
                        F1Par, F2Par, F3Par, F4Par, F5Par, F6Par, F7Par, 
                        FAC1, FAC2, FAC3, FAC4, FAC5, FAC6, FAC7, 
                        SP1, SP2, SP3, SP4, SP5, SP6, SP7);
                    resCode = "00";
                    resDesc = "";
                }
                else
                {
                    Log.AppendText("WARNING! : ProfileName ซ้ำ");
                    Log.AppendText("เริ่มต้น Update Profile...");
                    ms.UpdateProfileData(profileName, sampleStart, sampleDistance,
                        Error1, Error2, Error3, Error4, Error5,
                        H1Par, H2Par, H3Par, H4Par, H5Par, H6Par, H7Par,
                        HAC1, HAC2, HAC3, HAC4, HAC5, HAC6, HAC7,
                        F1Par, F2Par, F3Par, F4Par, F5Par, F6Par, F7Par,
                        FAC1, FAC2, FAC3, FAC4, FAC5, FAC6, FAC7,
                        SP1, SP2, SP3, SP4, SP5, SP6, SP7);
                    resCode = "01";
                    resDesc = "";
                }
            }
            catch (Exception ex)
            {
                resCode = "EX";
                resDesc = ex.Message;
                Log.AppendText(ex.Message);
            }
        }

        public void DeleteProfile(string profileName, string byWho, out string resCode, out string resDesc)
        {
            try
            {
                Log.AppendText("กำลังส่งข้อมูลการลบ Profile {" + profileName + "} by " + byWho);
                ManageBiz ms = new ManageBiz();

                ms.DeleteProfile(profileName);
                resCode = "00";
                resDesc = "";

            }
            catch (Exception ex)
            {
                resCode = "EX";
                resDesc = ex.Message;
                Log.AppendText(ex.Message);
            }

        }

        public void LoadProfileData(string profileName, ref TextBox _Start, ref TextBox _Distance, ref TextBox _E1, ref TextBox _E2, ref TextBox _E3, ref TextBox _E4, ref TextBox _E5, ref ListView lv)
        {
            try
            {
                Log.AppendText("กำลังเรียกข้อมูล Profile data {" + profileName + "}");

                _Start.Text = "";
                _Distance.Text = "";
                _E1.Text = "";
                _E2.Text = "";
                _E3.Text = "";
                _E4.Text = "";
                _E5.Text = "";

                ManageBiz ms = new ManageBiz();
                DataTable dtUser;
                dtUser = ms.GetProfileBy(profileName);
                if (dtUser.Rows.Count > 0)
                {
                    _Start.Text = dtUser.Rows[0]["StartHeight"].ToString();
                    _Distance.Text = dtUser.Rows[0]["Distance"].ToString();

                    _E1.Text = dtUser.Rows[0]["Error1"].ToString();
                    _E2.Text = dtUser.Rows[0]["Error2"].ToString();
                    _E3.Text = dtUser.Rows[0]["Error3"].ToString();
                    _E4.Text = dtUser.Rows[0]["Error4"].ToString();
                    _E5.Text = dtUser.Rows[0]["Error5"].ToString();

                    lv.Items[0].SubItems[2].Text = dtUser.Rows[0]["H1Par"].ToString();
                    lv.Items[0].SubItems[3].Text = dtUser.Rows[0]["HAC1"].ToString();
                    lv.Items[0].SubItems[5].Text = dtUser.Rows[0]["F1Par"].ToString();
                    lv.Items[0].SubItems[6].Text = dtUser.Rows[0]["FAC1"].ToString();
                    lv.Items[0].SubItems[7].Text = dtUser.Rows[0]["SP1"].ToString();

                    lv.Items[1].SubItems[2].Text = dtUser.Rows[0]["H2Par"].ToString();
                    lv.Items[1].SubItems[3].Text = dtUser.Rows[0]["HAC2"].ToString();
                    lv.Items[1].SubItems[5].Text = dtUser.Rows[0]["F2Par"].ToString();
                    lv.Items[1].SubItems[6].Text = dtUser.Rows[0]["FAC2"].ToString();
                    lv.Items[1].SubItems[7].Text = dtUser.Rows[0]["SP2"].ToString();

                    lv.Items[2].SubItems[2].Text = dtUser.Rows[0]["H3Par"].ToString();
                    lv.Items[2].SubItems[3].Text = dtUser.Rows[0]["HAC3"].ToString();
                    lv.Items[2].SubItems[5].Text = dtUser.Rows[0]["F3Par"].ToString();
                    lv.Items[2].SubItems[6].Text = dtUser.Rows[0]["FAC3"].ToString();
                    lv.Items[2].SubItems[7].Text = dtUser.Rows[0]["SP3"].ToString();

                    lv.Items[3].SubItems[2].Text = dtUser.Rows[0]["H4Par"].ToString();
                    lv.Items[3].SubItems[3].Text = dtUser.Rows[0]["HAC4"].ToString();
                    lv.Items[3].SubItems[5].Text = dtUser.Rows[0]["F4Par"].ToString();
                    lv.Items[3].SubItems[6].Text = dtUser.Rows[0]["FAC4"].ToString();
                    lv.Items[3].SubItems[7].Text = dtUser.Rows[0]["SP4"].ToString();

                    lv.Items[4].SubItems[2].Text = dtUser.Rows[0]["H5Par"].ToString();
                    lv.Items[4].SubItems[3].Text = dtUser.Rows[0]["HAC5"].ToString();
                    lv.Items[4].SubItems[5].Text = dtUser.Rows[0]["F5Par"].ToString();
                    lv.Items[4].SubItems[6].Text = dtUser.Rows[0]["FAC5"].ToString();
                    lv.Items[4].SubItems[7].Text = dtUser.Rows[0]["SP5"].ToString();

                    lv.Items[5].SubItems[2].Text = dtUser.Rows[0]["H6Par"].ToString();
                    lv.Items[5].SubItems[3].Text = dtUser.Rows[0]["HAC6"].ToString();
                    lv.Items[5].SubItems[5].Text = dtUser.Rows[0]["F6Par"].ToString();
                    lv.Items[5].SubItems[6].Text = dtUser.Rows[0]["FAC6"].ToString();
                    lv.Items[5].SubItems[7].Text = dtUser.Rows[0]["SP6"].ToString();

                    lv.Items[6].SubItems[2].Text = dtUser.Rows[0]["H7Par"].ToString();
                    lv.Items[6].SubItems[3].Text = dtUser.Rows[0]["HAC7"].ToString();
                    lv.Items[6].SubItems[5].Text = dtUser.Rows[0]["F7Par"].ToString();
                    lv.Items[6].SubItems[6].Text = dtUser.Rows[0]["FAC7"].ToString();
                    lv.Items[6].SubItems[7].Text = dtUser.Rows[0]["SP7"].ToString();

                    Log.AppendText("เรียกข้อมูล Profile เรียบร้อย");
                }
                else
                {
                    Log.AppendText("ไม่พบข้อมูล Profile");
                }
            }
            catch (Exception ex)
            {
                Log.AppendText(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

    }
}
