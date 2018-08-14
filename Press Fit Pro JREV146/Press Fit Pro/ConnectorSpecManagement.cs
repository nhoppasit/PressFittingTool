using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Press_Fit_Pro
{
    public class ConnectorSpecManagement
    {
        public void ShowConnectorList(ref ComboBox cbo)
        {
            try
            {
                Log.AppendText("กำลังเรียกข้อมูล Connector...");
                ManageBiz ms = new ManageBiz();
                DataTable dt;
                dt = ms.GetConnectorList();
                cbo.DataSource = null;
                if (dt.Rows.Count > 0)
                {
                    cbo.DataSource = dt;
                    cbo.DisplayMember = "ConnectorType";
                    cbo.ValueMember = "ConnectorType";
                    Log.AppendText("เรียกข้อมูล Connector เรียบร้อย");
                }
                else
                {
                    Log.AppendText("ไม่พบข้อมูล Connector");
                }
            }
            catch (Exception ex)
            {
                Log.AppendText(ex.Message);
                MessageBox.Show(ex.Message);
                cbo.DataSource = null;
            }
        }

        public void SaveConnectorSpec(string connectorType, string toolType, string profileName,
            int pins,
            float baseThickness, float unseatedTop, float height, float seatedHeight,
            float graphFPerPin, float graphDistance,
            float minFPerPin, float maxFPerPin, float userFPerPin, float otherForce,
            float parsPercent, float parsStartHeight, float parsDistance,
            float gradDegrees, string comments,
            string byWho, out string resCode, out string resDesc)
        {
            try
            {
                Log.AppendText("กำลังบันทึกข้อมูล Connector {" + connectorType + ", " + toolType + ", " + profileName + ", " + pins.ToString() + ", " +
                    baseThickness.ToString() + ", " + unseatedTop.ToString() + ", " + height.ToString() + ", " + seatedHeight.ToString() +
                    graphFPerPin.ToString() + ", " + graphDistance.ToString() +
                    minFPerPin.ToString() + ", " + maxFPerPin.ToString() + ", " + userFPerPin.ToString() + ", " + otherForce.ToString() +
                    parsPercent.ToString() + ", " + parsStartHeight.ToString() + ", " + parsDistance.ToString() + ", " +
                    gradDegrees.ToString() + ", " + comments +
                    "} by " + byWho);
                ManageBiz ms = new ManageBiz();
                DataTable dt;
                dt = ms.GetConnectorBy(connectorType);
                if (dt.Rows.Count == 0)
                {
                    Log.AppendText("ตรวจสอบ Connector Type เรียบร้อย");
                    ms.AddNewConnectorSpec(connectorType, toolType, profileName, pins,
                        baseThickness, unseatedTop, height, seatedHeight,
                        graphFPerPin, graphDistance,
                        minFPerPin, maxFPerPin, userFPerPin, otherForce,
                        parsPercent, parsStartHeight, parsDistance,
                        gradDegrees, comments);
                    resCode = "00";
                    resDesc = "";
                }
                else
                {
                    Log.AppendText("WARNING! : ToolType ซ้ำ");
                    Log.AppendText("เริ่มต้น Update Tool...");
                    ms.UpdateConnectorSpec(connectorType, toolType, profileName, pins,
                        baseThickness, unseatedTop, height, seatedHeight,
                        graphFPerPin, graphDistance,
                        minFPerPin, maxFPerPin, userFPerPin, otherForce,
                        parsPercent, parsStartHeight, parsDistance,
                        gradDegrees, comments);
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

        public void DeleteConnectorSpec(string connectorType, string byWho, out string resCode, out string resDesc)
        {
            try
            {
                Log.AppendText("กำลังส่งข้อมูลการลบ Connector spec {" + connectorType + "} by " + byWho);
                ManageBiz ms = new ManageBiz();

                ms.DeleteConnectorSpec(connectorType);
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

        public void LoadConnectorSpec(string connectorType, ref ComboBox _ToolType, ref ComboBox _ProfileName, ref TextBox _Pins,
            ref TextBox _baseThickness, ref TextBox _unseatedTop, ref TextBox _height, ref TextBox _seatedHeight,
            ref TextBox _graphFPerPin, ref TextBox _graphDistance,
            ref TextBox _minFPerPin, ref TextBox _maxFPerPin, ref TextBox _userFPerPin, ref TextBox _otherForce,
            ref TextBox _parsPercent, ref TextBox _parsStartHeight, ref TextBox _parsDistance,
            ref TextBox _gradDegrees, ref TextBox _comments)
        {
            try
            {
                Log.AppendText("กำลังเรียกข้อมูล Connector spec. {" + connectorType + "}");

                DataTable dtConnector = new DataTable();
                DataTable dtToolType = new DataTable();
                DataTable dtProfileName = new DataTable();
                ManageBiz ms = new ManageBiz();

                dtConnector = ms.GetConnectorBy(connectorType);
                dtToolType = ms.GetToolList();
                dtProfileName = ms.GetProfileList();

                if (dtConnector.Rows.Count > 0)
                {
                    _ToolType.DataSource = null;
                    _ToolType.DataSource = dtToolType;
                    _ToolType.DisplayMember = "ToolType";
                    _ToolType.ValueMember = "ToolType";
                    _ToolType.Text = dtConnector.Rows[0]["ToolType"].ToString();

                    _ProfileName.DataSource = null;
                    _ProfileName.DataSource = dtProfileName;
                    _ProfileName.DisplayMember = "ProfileName";
                    _ProfileName.ValueMember = "ProfileName";
                    _ProfileName.Text = dtConnector.Rows[0]["ProfileName"].ToString();

                    _Pins.Text = dtConnector.Rows[0]["NumberOfPins"].ToString();

                    _baseThickness.Text = dtConnector.Rows[0]["BaseThickness"].ToString();
                    _unseatedTop.Text = dtConnector.Rows[0]["UnseatedTop"].ToString();
                    _height.Text = dtConnector.Rows[0]["Height"].ToString();
                    _seatedHeight.Text = dtConnector.Rows[0]["SeatedHeight"].ToString();

                    _graphFPerPin.Text = dtConnector.Rows[0]["GraphFPerPin"].ToString();
                    _graphDistance.Text = dtConnector.Rows[0]["GraphDistance"].ToString();

                    _minFPerPin.Text = dtConnector.Rows[0]["MinFPerPin"].ToString();
                    _maxFPerPin.Text = dtConnector.Rows[0]["MaxFPerPin"].ToString();
                    _userFPerPin.Text = dtConnector.Rows[0]["UserFPerPin"].ToString();
                    _userFPerPin.Text = dtConnector.Rows[0]["OtherForce"].ToString();

                    _parsPercent.Text = dtConnector.Rows[0]["PARSPercent"].ToString();
                    _parsStartHeight.Text = dtConnector.Rows[0]["PARSStartHeight"].ToString();
                    _parsDistance.Text = dtConnector.Rows[0]["PARSDistance"].ToString();

                    _gradDegrees.Text = dtConnector.Rows[0]["FGradDegrees"].ToString();

                    _comments.Text = dtConnector.Rows[0]["Comments"].ToString();

                    Log.AppendText("เรียกข้อมูล Tools เรียบร้อย");
                }
                else
                {
                    Log.AppendText("ไม่พบข้อมูล Tools");
                }
            }
            catch (Exception ex) { Log.AppendText(ex.Message); MessageBox.Show(ex.Message); }
        }

    }
}
