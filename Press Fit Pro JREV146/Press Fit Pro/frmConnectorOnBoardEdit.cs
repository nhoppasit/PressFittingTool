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
    public partial class frmConnectorOnBoardEdit : Form
    {
        public float X { get { return float.Parse(txtX.Text); } set { txtX.Text = value.ToString(); } }
        public float Y { get { return float.Parse(txtY.Text); } set { txtY.Text = value.ToString(); } }
        public float Angle { get { return float.Parse(txtAngle.Text); } set { txtAngle.Text = value.ToString(); } }
        string _connectorType = "";
        public string ConnectorType { get { this._connectorType = cbConnectorType.Text; return _connectorType; } set { _connectorType = value; } }
        public string Comments { get { return txtComments.Text; } set { txtComments.Text = value; } }

        public frmConnectorOnBoardEdit()
        {
            InitializeComponent();
        }

        public frmConnectorOnBoardEdit(float x, float y, float angle, string connectType, string comments)
        {
            InitializeComponent();

            this.X = x;
            this.Y = y;
            this.Angle = angle;
            this._connectorType = connectType;
            this.Comments = comments;
        }

        private void frmConnectorEdit_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectorSpecManagement cm = new ConnectorSpecManagement();
                cm.ShowConnectorList(ref cbConnectorType);
                cbConnectorType.Text = this._connectorType;
            }
            catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); }
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

        private void frmConnectorEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.None) e.Cancel = true;
        }

    }
}
