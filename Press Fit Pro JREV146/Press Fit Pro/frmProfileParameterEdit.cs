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
    public partial class frmProfileParameterEdit : Form
    {
        public float HeightParameter { get { return float.Parse(txtHPar.Text); } set { txtHPar.Text = value.ToString(); } }
        public float ForceParameter { get { return float.Parse(txtFPar.Text); } set { txtFPar.Text = value.ToString(); } }
        public float Speed { get { return float.Parse(txtSpeed.Text); } set { txtSpeed.Text = value.ToString(); } }
        public string HeightAction { get { return txtHAction.Text; } set { txtHAction.Text = value; } }
        public string ForceAction { get { return txtFAction.Text; } set { txtFAction.Text = value; } }

        public frmProfileParameterEdit()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;            
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmProfileParameterEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.None) e.Cancel = true;
        }
    }
}
