using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Press_Fit_Pro
{
    public static class AppConfig
    {
        public static DataTable AppConfigDataTable = null;

        static ManageBiz ms = new ManageBiz();

        private static void DisposeAppConfigDT()
        {
            if (AppConfigDataTable != null)
            {
                AppConfigDataTable.Dispose();
                AppConfigDataTable = null;
            }
        }

        public static void Load()
        {
            try
            {
                DisposeAppConfigDT();
                AppConfigDataTable = ms.GetAppConfig();
                if (AppConfigDataTable.Rows.Count > 0)
                {
                    Log.AppendText("Load application configuration completed.");
                }
                else
                {
                    string sError = "Load application configuration failed.";
                    Log.AppendText(sError);
                    throw new Exception(sError);
                }
            }
            catch (Exception ex)
            {
                Log.AppendText(ex.Message);
                DisposeAppConfigDT();
                throw new Exception(ex.Message);
            }
        }

        public static string SecurityKey
        {
            get
            {
                if (AppConfigDataTable == null) Load();
                return AppConfigDataTable.Rows[0]["SecurityKey"].ToString();
            }
        }

        public static string IndicatorPortName
        {
            get
            {
                if (AppConfigDataTable == null) Load();
                return AppConfigDataTable.Rows[0]["IndicatorPortName"].ToString();
            }
        }

        public static string ServoPortName
        {
            get
            {
                if (AppConfigDataTable == null) Load();
                return AppConfigDataTable.Rows[0]["ServoPortName"].ToString();
            }
        }

        public static void Save()
        {
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();

            //dt.Columns.Add("SecurityKey");

            //DataRow row = dt.NewRow();

            //row["SecurityKey"] = _SecurityKey;
        }
    }
}
