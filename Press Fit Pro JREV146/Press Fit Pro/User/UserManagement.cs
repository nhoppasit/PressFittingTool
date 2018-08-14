using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Press_Fit_Pro
{
    public class UserManagement
    {        
        public static string UserName = "";
        public static DateTime LoginTime;
                
        public bool Login(string UserName, string Password)
        {
            try
            {
                ManageBiz ms = new ManageBiz();

                string crptPassword = StringCipher.Encrypt(Password, true);
                DataTable dtUser;
                dtUser = ms.GetUserBy(UserName);
                bool ShowDenineMessage = false;
                if (dtUser != null)
                {
                    if (dtUser.Rows.Count == 1)
                    {
                        string dbPassword = dtUser.Rows[0]["Password"].ToString();
                        if (dbPassword == crptPassword)
                        {
                            return true;
                        }
                        else
                        {
                            ShowDenineMessage = true;
                        }
                    }
                    else
                    {
                        ShowDenineMessage = true;
                    }
                }
                else
                {
                    ShowDenineMessage = true;
                }
                if (ShowDenineMessage)
                {
                    MessageBox.Show("Access denine. Invalid user name or password.",
                        "Login",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk,
                        MessageBoxDefaultButton.Button1);
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.AppendText(ex.Message);
                MessageBox.Show("Login Error : " + ex.Message);
                return false;
            }
        }

        public void ShowUserList(ref ListBox lb)
        {
            try
            {
                Log.AppendText("กำลังเรียกข้อมูลรายชื่อผู้ใช้ระบบ...");
                ManageBiz ms = new ManageBiz();
                DataTable dtUser;
                dtUser = ms.GetUserList();
                lb.Items.Clear();
                for (int i = 0; i < dtUser.Rows.Count; i++)
                {
                    if (dtUser.Rows[i]["AccountType"].ToString().Equals("A"))
                    {
                        lb.Items.Add(dtUser.Rows[i]["UserName"].ToString() + ", " +
                            dtUser.Rows[i]["FirstName"].ToString() + ", " +
                            dtUser.Rows[i]["LastName"].ToString() + ", " +
                            "Administrator");
                    }
                    else if (dtUser.Rows[i]["AccountType"].ToString().Equals("U"))
                    {
                        lb.Items.Add(dtUser.Rows[i]["UserName"].ToString() + ", " +
                            dtUser.Rows[i]["FirstName"].ToString() + ", " +
                            dtUser.Rows[i]["LastName"].ToString() + ", " +
                            "User");
                    }
                }
                Log.AppendText("เรียกข้อมูลรายชื่อผู้ใช้ระบบ เรียบร้อย");
            }
            catch (Exception ex)
            {
                Log.AppendText(ex.Message);
                lb.Items.Clear();
            }
        }

        public void AddNewUser(string userName, string firstName, string lastName, string accountType, string cript_password, string byWho, out string resCode, out string resDesc)
        {
            try
            {
                Log.AppendText("กำลังส่งข้อมูลเพิ่มรายชื่อผู้ใช้ระบบใหม่ {" + userName + ", " + firstName + ", " + lastName + ", " + accountType + "} by " + byWho);
                ManageBiz ms = new ManageBiz();
                DataTable dtUser;
                dtUser = ms.GetUserBy(userName);
                if (dtUser.Rows.Count == 0)
                {
                    Log.AppendText("ตรวจสอบ ชื่อผู้ใช้ เรียบร้อย");
                    ms.AddNewUser(userName, firstName, lastName, accountType, cript_password);
                    resCode = "00";
                    resDesc = "";
                }
                else
                {
                    Log.AppendText("WARNING! : ชื่อผู้ใช้ซ้ำ");
                    resCode = "01";
                    resDesc = "ชื่อผู้ใช้ซ้ำ!";
                }
            }
            catch (Exception ex)
            {
                resCode = "EX";
                resDesc = ex.Message;
                Log.AppendText(ex.Message);
            }
        }

        public void DeleteUser(string userName, string byWho, out string resCode, out string resDesc)
        {
            try
            {
                Log.AppendText("กำลังส่งข้อมูลการลบรายชื่อ {" + userName + "} by " + byWho);
                ManageBiz ms = new ManageBiz();

                ms.DeleteUser(userName);
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
    }
}
