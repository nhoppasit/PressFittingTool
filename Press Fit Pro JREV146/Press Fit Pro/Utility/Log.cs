using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Press_Fit_Pro
{
    public static class Log
    {
        public static string Path = Properties.Settings.Default.LogPath;

        public static string FullFileName()
        {
            return Path + @"\Log " + DateTime.Now.ToString("yyyyMMdd") + ".txt" ;
        }

        private static void CheckPath()
        {
            try
            {
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                if (!File.Exists(FullFileName()))
                {                   
                    File.Create(FullFileName()).Close();
                    int loop = 0;
                    while (!File.Exists(FullFileName()) & loop < 30) { loop++; }                 
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AppendText(string text)
        {
            try
            {
                CheckPath();
                using (StreamWriter w = new StreamWriter(FullFileName(), true))
                {
                    string str;
                    str = DateTime.Now.ToString("yyyy/MM/dd, HH:mm:ss") + " : " + text;
                    w.WriteLine(str);
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
