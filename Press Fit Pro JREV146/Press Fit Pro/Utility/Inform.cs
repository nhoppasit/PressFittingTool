using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Press_Fit_Pro
{
    public static class Inform
    {
        public static void Show(string text, string topic, int inteval)
        {
            frmMessage f = new frmMessage(text, topic, inteval);
            f.ShowDialog();
            f.Dispose();
        }

        private static frmMessage dlgWait;
        public static void Wait(string text, string topic)
        {
            try
            {
                if (dlgWait == null)
                    dlgWait = new frmMessage(text, topic, 0);
            }
            catch
            {
                dlgWait = new frmMessage(text, topic, 0);
            }            
            dlgWait.TopMost = true;
            dlgWait.Show();
            dlgWait.Update();
        }

        public static void CloseWait()
        {
            try { dlgWait.Hide(); }
            catch { }
        }
    }
}
