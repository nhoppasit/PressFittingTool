using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;

namespace Press_Fit_Pro
{
    public struct BoardInfo
    {
        #region Members

        public string BoardName;
        public string Description;
        public float BoardThickness;
        public float FixtureThickness;
        public SizeF PhysicalSize;
        public string ImageFile;
        public List<ConnectorInfo> ConnectorList;

        #endregion

        #region Constructor

        public BoardInfo(string boardName)
        {
            this.BoardName = boardName;
            this.Description = "";
            this.BoardThickness = 0;
            this.FixtureThickness = 0;
            this.PhysicalSize = new SizeF(100, 100);
            this.ImageFile = "";

            ConnectorList = new List<ConnectorInfo>();

            ManageBiz ms = new ManageBiz();
            DataTable dt;
            dt = ms.GetBoardBy(boardName);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    float boardWidth = float.Parse(dt.Rows[0]["BoardWidth"].ToString());
                    float boardLength = float.Parse(dt.Rows[0]["BoardLength"].ToString());
                    this.PhysicalSize = new SizeF(boardWidth, boardLength);

                    this.Description = dt.Rows[0]["DESC"].ToString(); ;
                    this.BoardThickness = float.Parse(dt.Rows[0]["BoardThickness"].ToString());
                    this.FixtureThickness = float.Parse(dt.Rows[0]["FixtureThickness"].ToString());
                    this.ImageFile = dt.Rows[0]["ImageFile"].ToString(); ;

                    if (ConnectorList == null) ConnectorList = new List<ConnectorInfo>();

                    // Detail
                    DataTable dtDetail = ms.GetBoardDetailBy(boardName);
                    if (dtDetail != null)
                    {
                        if (dtDetail.Rows.Count > 0)
                        {
                            float x, y, angle;
                            string connectorType, comments;
                            foreach (DataRow r in dtDetail.Rows)
                            {
                                x = float.Parse(r["X"].ToString());
                                y = float.Parse(r["Y"].ToString());
                                angle = float.Parse(r["Angle"].ToString());
                                connectorType = r["ConnectorType"].ToString();
                                comments = r["Comments"].ToString();
                                this.ConnectorList.Add(new ConnectorInfo(connectorType, x, y, angle, comments, FixtureThickness, BoardThickness));
                            }
                        }
                    }
                }
            }
        }

        #endregion

        public override string ToString()
        {
            return BoardName + " | " + PhysicalSize.ToString() + " | " + this.Description;
        }

    }
}
