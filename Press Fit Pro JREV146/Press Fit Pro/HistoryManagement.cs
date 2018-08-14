using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Press_Fit_Pro
{
    public class HistoryManagement
    {
        public string AddNewHistory(string boardName, string byWho, out string resCode, out string resDesc) // Return file name of board history
        {
            try
            {
                Log.AppendText("กำลังเปิดการบันทึก Run history. {" + boardName + "} by " + byWho);
                ManageBiz ms = new ManageBiz();
                int runIndex = ms.GetNextRunHistoryBy(boardName);
                Log.AppendText("รหัสสำหรับ " + boardName + " คือ " + runIndex.ToString());
                string historyFile = ms.AddNewRunHistory(boardName, byWho);
                resCode = "00";
                resDesc = "";
                return historyFile;
            }
            catch (Exception ex)
            {
                resCode = "EX";
                resDesc = ex.Message;
                Log.AppendText(ex.Message);
                return "";
            }
        }


    }
}
