using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Press_Fit_Pro
{
    public class BoardSpecManagement
    {
        public void ShowBoardList(ref ComboBox cbo)
        {
            try
            {
                Log.AppendText("กำลังเรียกข้อมูล Board...");
                ManageBiz ms = new ManageBiz();
                DataTable dt;
                dt = ms.GetBoardList();
                cbo.DataSource = null;
                if (dt.Rows.Count > 0)
                {
                    cbo.DataSource = dt;
                    cbo.DisplayMember = "BoardName";
                    cbo.ValueMember = "BoardName";
                    Log.AppendText("เรียกข้อมูล Board เรียบร้อย");
                }
                else
                {
                    Log.AppendText("ไม่พบข้อมูล Board");
                }
            }
            catch (Exception ex)
            {
                Log.AppendText(ex.Message);
                MessageBox.Show(ex.Message);
                cbo.DataSource = null;
            }
        }

        public void SaveBoardSpec(string boardName, string DESC, string imageFile, float boardThickness, float boardWidth, float boardLength, float fixtureThickness,
            List<int> rowList, List<float> xList, List<float> yList, List<float> angleList, List<string> connectorList, List<string> commentsList,
            string byWho, out string resCode, out string resDesc)
        {
            try
            {
                Log.AppendText("กำลังบันทึกข้อมูล Board spec. {" +
                    boardName + ", " + DESC + ", " + boardThickness.ToString() + ", " +
                    boardWidth.ToString() + ", " + boardLength.ToString() + ", " +
                    fixtureThickness.ToString() + ", Connector count = " + rowList.Count.ToString() + "} by " + byWho);
                ManageBiz ms = new ManageBiz();
                DataTable dt;
                dt = ms.GetBoardBy(boardName);
                if (dt.Rows.Count == 0)
                {
                    Log.AppendText("ตรวจสอบ  Board spec. เรียบร้อย");
                    ms.AddNewBoardSpec(boardName, DESC, imageFile, boardWidth, boardLength, boardThickness, fixtureThickness,
                        rowList, xList, yList, angleList, connectorList, commentsList);
                    resCode = "00";
                    resDesc = "";
                }
                else
                {
                    Log.AppendText("WARNING! : Board spec. ซ้ำ");
                    Log.AppendText("เริ่มต้น Update  Board spec....");
                    ms.UpdateBoardSpec(boardName, DESC, imageFile, boardWidth, boardLength, boardThickness, fixtureThickness,
                        rowList, xList, yList, angleList, connectorList, commentsList);
                    resCode = "01";
                    resDesc = "";
                }
            }
            catch (Exception ex)
            {
                resCode = "EX";
                resDesc = ex.Message;
                Log.AppendText(ex.Message);
            }
        }

        public void DeleteBoardSpec(string boardName, string byWho, out string resCode, out string resDesc)
        {
            try
            {
                Log.AppendText("กำลังส่งข้อมูลการลบ Board spec. {" + boardName + "} by " + byWho);
                ManageBiz ms = new ManageBiz();

                ms.DeleteBoardSpec(boardName);
                resCode = "00";
                resDesc = "";

            }
            catch (Exception ex)
            {
                resCode = "EX";
                resDesc = ex.Message;
                Log.AppendText(ex.Message);
            }

        }

        public void LoadBoardSpec(string boardName, ref TextBox _Desc,
            ref TextBox _boardWidth, ref TextBox _boardLength, ref TextBox _boardThickness, ref TextBox _fixtureThickness,
            ref TextBox _imageFile, ref ListView lvDetail, ref BoardModelClass _bmcPreview, ref PictureBox _picPreview)
        {
            try
            {
                Log.AppendText("กำลังเรียกข้อมูล Board spec. {" + boardName + "}");

                _Desc.Text = "";
                _boardWidth.Text = "";
                _boardLength.Text = "";
                _boardThickness.Text = "";
                _fixtureThickness.Text = "";
                _imageFile.Text = "";
                lvDetail.Items.Clear();

                ManageBiz ms = new ManageBiz();
                DataTable dt;
                dt = ms.GetBoardBy(boardName);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string desc = dt.Rows[0]["DESC"].ToString();
                        float boardWidth = float.Parse(dt.Rows[0]["BoardWidth"].ToString());
                        float boardLength = float.Parse(dt.Rows[0]["BoardLength"].ToString());
                        float boardThickness = float.Parse(dt.Rows[0]["BoardThickness"].ToString());
                        float fixtureThickness = float.Parse(dt.Rows[0]["FixtureThickness"].ToString());
                        string imageFile = dt.Rows[0]["ImageFile"].ToString();

                        _Desc.Text = desc;
                        _boardWidth.Text = boardWidth.ToString();
                        _boardLength.Text = boardLength.ToString();
                        _boardThickness.Text = boardThickness.ToString();
                        _fixtureThickness.Text = fixtureThickness.ToString();
                        _imageFile.Text = imageFile;

                        // Detail
                        DataTable dtDetail = ms.GetBoardDetailBy(boardName);
                        if (dtDetail != null)
                        {
                            if (dtDetail.Rows.Count > 0)
                            {
                                foreach (DataRow r in dtDetail.Rows)
                                {
                                    float x = float.Parse(r["X"].ToString());
                                    float y = float.Parse(r["Y"].ToString());
                                    float angle = float.Parse(r["Angle"].ToString());
                                    string connectorType = r["ConnectorType"].ToString();
                                    string comments = r["Comments"].ToString();

                                    string[] astr = { r["RowNbr"].ToString(),x.ToString("0.000"), y.ToString("0.000"), angle.ToString("0.0"), 
                                                connectorType, comments};
                                    lvDetail.Items.Add(new ListViewItem(astr));
                                }
                            }
                        }

                        BoardInfo info = new BoardInfo(boardName);
                        if (_bmcPreview == null) _bmcPreview = new BoardModelClass(ref _picPreview, info);
                        else _bmcPreview.UpdateBoardInfo(info);

                        Log.AppendText("เรียกข้อมูล Board spec. เรียบร้อย");
                    }
                    else
                    {
                        Log.AppendText("ไม่พบข้อมูล Board spec.");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.AppendText(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }        
    }
}
