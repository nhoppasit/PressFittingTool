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
    public partial class frmMessage : Form
    {
        Timer timer;

        public frmMessage(string text, string topic, int inteval)
        {
            InitializeComponent();

            lblTopic.Text = topic;
            lblMessage.Text = text;

            if (inteval > 0)
            {
                timer = new Timer();
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = inteval;
                timer.Enabled = true;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            timer.Dispose();
            Close();
        }
    }
}
