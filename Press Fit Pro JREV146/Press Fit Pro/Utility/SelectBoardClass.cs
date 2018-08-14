using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace Press_Fit_Pro
{
    public class SelectBoardClass
    {
        public bool IsSelected { get; set; }

        public BoardInfo SelectedBoard { get; set; }

        public void ShowDialog()
        {
            IsSelected = false;

            frmSelectBoard f = new frmSelectBoard();

            List<string> boards = new List<string>();
            ManageBiz ms = new ManageBiz();
            DataTable dt;
            dt = ms.GetBoardList();            
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        boards.Add(r["BoardName"].ToString());
                    }
                }
            }
            f.BoardList = boards;

            DialogResult ret = f.ShowDialog();
            if (ret == DialogResult.OK)
                if (!f.SelectedBoard.BoardName.Equals(""))
                {
                    SelectedBoard = f.SelectedBoard;
                    IsSelected = true;
                }
                else
                {
                    SelectedBoard = new BoardInfo("");
                    IsSelected = false;
                }
        }
    }
}
