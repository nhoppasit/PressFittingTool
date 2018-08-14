using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace Press_Fit_Pro
{
    public class ToolManagement
    {
        public void ShowToolList(ref ComboBox cbo)
        {
            try
            {
                Log.AppendText("กำลังเรียกข้อมูล Tools...");
                ManageBiz ms = new ManageBiz();
                DataTable dtUser;
                dtUser = ms.GetToolList();
                cbo.DataSource = null;
                if (dtUser.Rows.Count > 0)
                {
                    cbo.DataSource = dtUser;
                    cbo.DisplayMember = "ToolType";
                    cbo.ValueMember = "ToolType";
                    Log.AppendText("เรียกข้อมูล Tools เรียบร้อย");
                }
                else
                {
                    Log.AppendText("ไม่พบข้อมูล Tools");
                }
            }
            catch (Exception ex)
            {
                Log.AppendText(ex.Message);
                MessageBox.Show(ex.Message);
                cbo.DataSource = null;
            }
        }

        public void SaveToolData(string toolType, string Barcode, float clearance, float height, float width, float length, string comments, string byWho, out string resCode, out string resDesc)
        {
            try
            {
                Log.AppendText("กำลังบันทึกข้อมูล Tool {" + toolType + ", " + Barcode + ", " + clearance.ToString() + ", " + height.ToString() + ", " + width.ToString() + ", " + length.ToString() + "} by " + byWho);
                ManageBiz ms = new ManageBiz();
                DataTable dtUser;
                dtUser = ms.GetToolBy(toolType);
                if (dtUser.Rows.Count == 0)
                {
                    Log.AppendText("ตรวจสอบ ToolType เรียบร้อย");
                    ms.AddNewTool(toolType, Barcode, clearance, height, width, length, comments);
                    resCode = "00";
                    resDesc = "";                    
                }
                else
                {
                    Log.AppendText("WARNING! : ToolType ซ้ำ");
                    Log.AppendText("เริ่มต้น Update Tool...");
                    ms.UpdateToolData(toolType, Barcode, clearance, height, width, length, comments);
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

        public void DeleteTool(string toolType, string byWho, out string resCode, out string resDesc)
        {
            try
            {
                Log.AppendText("กำลังส่งข้อมูลการลบ Tool {" + toolType + "} by " + byWho);
                ManageBiz ms = new ManageBiz();

                ms.DeleteTool(toolType);
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

        public void LoadToolData(string toolType, ref TextBox _clearance, ref TextBox _height, ref TextBox _width, ref TextBox _length, ref TextBox _barcode, ref TextBox _comments)
        {
            try
            {
                Log.AppendText("กำลังเรียกข้อมูล Tools {" + toolType + "}");
                
                _clearance.Text = "";
                _height.Text = "";
                _width.Text = "";
                _length.Text = "";
                _barcode.Text = "";
                _comments.Text = "";

                ManageBiz ms = new ManageBiz();
                DataTable dtUser;
                dtUser = ms.GetToolBy(toolType);
                if (dtUser.Rows.Count > 0)
                {
                    _clearance.Text = dtUser.Rows[0]["Clearance"].ToString();
                    _height.Text = dtUser.Rows[0]["Height"].ToString();
                    _width.Text = dtUser.Rows[0]["Width"].ToString();
                    _length.Text = dtUser.Rows[0]["Length"].ToString();
                    _barcode.Text = dtUser.Rows[0]["Barcode"].ToString();
                    _comments.Text = dtUser.Rows[0]["Comments"].ToString();
                   
                    Log.AppendText("เรียกข้อมูล Tools เรียบร้อย");
                }
                else
                {
                    Log.AppendText("ไม่พบข้อมูล Tools");
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
