using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Press_Fit_Pro
{
    public partial class frmLogin : Form
    {
        #region Constructor / Deconstructor

        public frmLogin()
        {
            InitializeComponent();

        }

        #endregion

        #region Size changed

        public void LocateInputPanel()
        {
            int W = this.ClientRectangle.Width;
            int H = this.ClientRectangle.Height;

            int iw = pnInput.Width;
            int ih = pnInput.Height;

            pnInput.Left = (int)(W - iw) / 2;
            pnInput.Top = (int)(H - ih) / 2;
        }

        private void frmLogin_SizeChanged(object sender, EventArgs e)
        {
            LocateInputPanel();
        }

        #endregion

        #region Login
                
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        private void DoLogin()
        {
            this.Enabled = false;
            UserManagement um = new UserManagement();
            if (um.Login(txtUser.Text, txtPass.Text))
            {
                UserManagement.UserName = txtUser.Text;
                UserManagement.LoginTime = DateTime.Now;
                Log.AppendText("Login by " + UserManagement.UserName + " at " + UserManagement.LoginTime.ToString("yyyy/MM/dd, HH:mm:ss"));
                Close();
            }
            this.Enabled = true;
        }

        #endregion

        #region Quit

        private void picQuit_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Do you want to exit application?", "Login", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) DoLogin();
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) DoLogin();
        }
    }
}
