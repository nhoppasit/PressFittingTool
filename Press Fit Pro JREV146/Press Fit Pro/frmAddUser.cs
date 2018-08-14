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
    public partial class frmAddUser : Form
    {
        public string UserID { get { return txtUserID.Text; } }
        public string FirstName { get { return txtFirstName.Text; } }
        public string LastName { get { return txtLastName.Text; } }
        public string Password { get { return txtPassword.Text; } }
        public string Repassword { get { return txtRepassword.Text; } }
        public string UserType { get { if (rbAdmin.Checked) return "A"; else if (rbUser.Checked) return "U"; else return "C"; } }

        public frmAddUser()
        {
            InitializeComponent();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            /* --------------------------------------------------------------
             * Validation
             * --------------------------------------------------------------*/
            if (txtUserID.Text.Equals("")) { MessageBox.Show("Please fill user id.", "Validation"); txtUserID.Focus(); return; }
            if (txtFirstName.Text.Equals("")) { MessageBox.Show("Please fill user first name.", "Validation"); txtFirstName.Focus(); return; }
            if (txtLastName.Text.Equals("")) { MessageBox.Show("Please fill user last name.", "Validation"); txtLastName.Focus(); return; }
            if (txtPassword.Text.Equals("")) { MessageBox.Show("Please fill password.", "Validation"); txtPassword.Focus(); return; }
            if (txtRepassword.Text.Equals("")) { MessageBox.Show("Please fill re-password.", "Validation"); txtRepassword.Focus(); return; }
            if (!txtPassword.Text.Equals(txtRepassword.Text))
            { MessageBox.Show("Re - passwords do not match!.", "Validation"); txtRepassword.Focus(); txtRepassword.SelectAll(); return; }

            /* --------------------------------------------------------------
             * Getout
             * --------------------------------------------------------------*/
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmAddUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.None) e.Cancel = true;
            Console.WriteLine(e.CloseReason);
        }
    }
}
