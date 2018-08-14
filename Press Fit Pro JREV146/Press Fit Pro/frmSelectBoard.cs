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
    public partial class frmSelectBoard : Form
    {
        #region Properties

        private BoardInfo _SelectedBoard;
        public BoardInfo SelectedBoard
        {
            get { return _SelectedBoard; }
            set { _SelectedBoard = value; }
        }

        private List<string> _BoardList;
        public List<string> BoardList
        {
            get { return _BoardList; }
            set
            {
                _BoardList = value;
                UpdateBoardList();
            }
        }

        #endregion

        #region Constructor / Deconstructor

        public frmSelectBoard()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            int index = 1;
            Button btn;
            for (int j = 0; j < tlpTable.RowCount; j++)
            {
                for (int i = 0; i < tlpTable.ColumnCount; i++)
                {
                    btn = GetButton(index);
                    if (btn != null)
                    {
                        btn.Visible = false;
                        btn.Tag = "";
                        btn.Click += new EventHandler(Board_Click);
                    }
                    index++;
                }
            }
        }

        #endregion

        #region Board list

        private void UpdateBoardList()
        {
            int index = 1;
            Button btn;
            foreach (string board in _BoardList)
            {
                btn = GetButton(index);
                if (btn != null)
                {
                    btn.Tag = board;
                    btn.Text = board;
                    btn.Visible = true;
                }
                index++;
            }
        }

        private Button GetButton(int index)//One-based
        {
            switch (index)
            {
                case 1:
                    return button1;
                case 2:
                    return button2;
                case 3:
                    return button3;
                case 4:
                    return button4;
                case 5:
                    return button5;
                case 6:
                    return button6;
                case 7:
                    return button7;
                case 8:
                    return button8;
                case 9:
                    return button9;
                case 10:
                    return button10;
                case 11:
                    return button11;
                case 12:
                    return button12;
                default:
                    return null;
            }
        }

        #endregion

        #region Select board

        private void Board_Click(object sender, EventArgs e)
        {
            string Tag = ((Button)sender).Tag.ToString();
            _SelectedBoard = new BoardInfo(Tag);//***
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region Cancel

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _SelectedBoard.BoardName = "";
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}
