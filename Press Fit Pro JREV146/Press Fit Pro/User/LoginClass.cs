using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Press_Fit_Pro
{
    public class LoginClass
    {
        private Label lblLoginUserName;
        private Label lblLoginTime;
        public LoginClass(ref Label userLabel,ref Label timeLabel)
        {
            this.lblLoginUserName = userLabel;
            this.lblLoginTime = timeLabel;

            lblLoginUserName.Text = "";
            lblLoginTime.Text = "";
        }

        public void Logoff()
        {
            lblLoginUserName.Text = "";
            lblLoginTime.Text = "";
        }

        public void ShowDialog()
        {
            frmLogin dlg = new frmLogin();
            dlg.WindowState = FormWindowState.Maximized;
            dlg.ShowDialog();
            lblLoginUserName.Text = UserManagement.UserName;
            lblLoginTime.Text = UserManagement.LoginTime.ToString("yyyy/MM/dd, HH:mm:ss");
        }
    }
}
