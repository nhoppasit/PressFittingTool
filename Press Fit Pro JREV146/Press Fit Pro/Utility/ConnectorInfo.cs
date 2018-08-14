using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Press_Fit_Pro
{
    public struct ConnectorInfo
    {
        // Connector data on board
        public string ConnectorType;
        public PointF Location;
        private float X;
        private float Y;
        public float Angle;
        public string Comments;
        //
        // Connector type database
        public int NumberOfPins;
        public float CONBaseThickness, CONUnseatedTop, CONHeight, CONSeatedHeight;
        public float GraphFPerPin, GraphDistance;
        public float MinFPerPin, MaxFPerPin, UserFPerPin, OtherForce;
        public float PARSPercent, PARSStartHeight, PARSDistance;
        public float FGradDegrees;
        public string CONComments;
        //
        // Tool type database
        public string ToolType;
        public float ToolClearance, ToolHeight, ToolWidth, ToolLength;
        public string ToolBarcode, ToolComments;
        public SizeF ToolSize;
        //
        // Profile type database
        public string ProfileName;
        public float PARSSamplingStartHeight, PARSSamplingDistance;
        public string Error1, Error2, Error3, Error4, Error5;
        public float H1Par, H2Par, H3Par, H4Par, H5Par, H6Par, H7Par;
        public string HAC1, HAC2, HAC3, HAC4, HAC5, HAC6, HAC7;
        public float F1Par, F2Par, F3Par, F4Par, F5Par, F6Par, F7Par;
        public string FAC1, FAC2, FAC3, FAC4, FAC5, FAC6, FAC7;
        public float SP1, SP2, SP3, SP4, SP5, SP6, SP7;
        //
        // Board parameters
        public float FixtureThickness;
        public float BoardThickness;
        //       
        // ---------------------------------------------------------
        // Constructor
        // ---------------------------------------------------------
        public ConnectorInfo(string connectorType, float x, float y, float angle, string comments, float fixtureThickness, float boardThickness)
        {
            // Preseting
            ToolType = "";
            ProfileName = "";
            //
            NumberOfPins = 0;
            CONBaseThickness = 0; CONUnseatedTop = 0; CONHeight = 0; CONSeatedHeight = 0;
            //
            GraphFPerPin = 0; GraphDistance = 0;
            //
            MinFPerPin = 0; MaxFPerPin = 0; UserFPerPin = 0; OtherForce = 0;
            //
            PARSPercent = 0; PARSStartHeight = 0; PARSDistance = 0;
            //
            FGradDegrees = 0;
            CONComments = "";
            //
            ToolClearance = 0; ToolHeight = 0; ToolWidth = 0; ToolLength = 0;
            //
            ToolBarcode = ""; ToolComments = "";
            //
            PARSSamplingStartHeight = 0; PARSSamplingDistance = 0;
            //
            Error1 = ""; Error2 = ""; Error3 = ""; Error4 = ""; Error5 = "";
            //
            H1Par = 0; H2Par = 0; H3Par = 0; H4Par = 0; H5Par = 0; H6Par = 0; H7Par = 0;
            //
            HAC1 = ""; HAC2 = ""; HAC3 = ""; HAC4 = ""; HAC5 = ""; HAC6 = ""; HAC7 = "";
            //
            F1Par = 0; F2Par = 0; F3Par = 0; F4Par = 0; F5Par = 0; F6Par = 0; F7Par = 0;
            //
            FAC1 = ""; FAC2 = ""; FAC3 = ""; FAC4 = ""; FAC5 = ""; FAC6 = ""; FAC7 = "";
            //
            SP1 = 0; SP2 = 0; SP3 = 0; SP4 = 0; SP5 = 0; SP6 = 0; SP7 = 0;
            //
            // Assigning
            this.ConnectorType = connectorType;
            //
            this.X = x;
            this.Y = y;
            this.Angle = angle;
            this.Comments = comments;
            //
            this.FixtureThickness = fixtureThickness;
            this.BoardThickness = boardThickness;
            //
            this.Location = new PointF(x, y);
            //
            // Connector type database
            ManageBiz ms = new ManageBiz();
            DataTable dtCON;
            dtCON = ms.GetConnectorBy(connectorType);
            if (dtCON != null)
            {
                if (dtCON.Rows.Count > 0)
                {
                    ToolType = dtCON.Rows[0]["ToolType"].ToString();
                    ProfileName = dtCON.Rows[0]["ProfileName"].ToString();
                    //
                    NumberOfPins = int.Parse(dtCON.Rows[0]["NumberOfPins"].ToString());
                    CONBaseThickness = float.Parse(dtCON.Rows[0]["BaseThickness"].ToString());
                    CONUnseatedTop = float.Parse(dtCON.Rows[0]["UnseatedTop"].ToString());
                    CONHeight = float.Parse(dtCON.Rows[0]["Height"].ToString());
                    CONSeatedHeight = float.Parse(dtCON.Rows[0]["SeatedHeight"].ToString());
                    //
                    GraphFPerPin = float.Parse(dtCON.Rows[0]["GraphFPerPin"].ToString());
                    GraphDistance = float.Parse(dtCON.Rows[0]["GraphDistance"].ToString());
                    //
                    MinFPerPin = float.Parse(dtCON.Rows[0]["MinFPerPin"].ToString());
                    MaxFPerPin = float.Parse(dtCON.Rows[0]["MaxFPerPin"].ToString());
                    UserFPerPin = float.Parse(dtCON.Rows[0]["UserFPerPin"].ToString());
                    OtherForce = float.Parse(dtCON.Rows[0]["OtherForce"].ToString());
                    //
                    PARSPercent = float.Parse(dtCON.Rows[0]["PARSPercent"].ToString());
                    PARSStartHeight = float.Parse(dtCON.Rows[0]["PARSStartHeight"].ToString());
                    PARSDistance = float.Parse(dtCON.Rows[0]["PARSDistance"].ToString());
                    //
                    FGradDegrees = float.Parse(dtCON.Rows[0]["FGradDegrees"].ToString());
                    //
                    CONComments = dtCON.Rows[0]["Comments"].ToString();
                }
            }
            dtCON.Dispose();
            dtCON = null;
            //
            // Tool type database
            DataTable dtTOOL;
            dtTOOL = ms.GetToolBy(ToolType);
            if (dtTOOL != null)
            {
                if (dtTOOL.Rows.Count > 0)
                {
                    ToolClearance = float.Parse(dtTOOL.Rows[0]["Clearance"].ToString());
                    ToolHeight = float.Parse(dtTOOL.Rows[0]["Height"].ToString());
                    ToolWidth = float.Parse(dtTOOL.Rows[0]["Width"].ToString());
                    ToolLength = float.Parse(dtTOOL.Rows[0]["Length"].ToString());
                    //
                    ToolBarcode = dtTOOL.Rows[0]["Barcode"].ToString();
                    ToolComments = dtTOOL.Rows[0]["Comments"].ToString();
                }
            }
            dtTOOL.Dispose();
            dtTOOL = null;
            //
            // Profile database
            DataTable dtPF;
            dtPF = ms.GetProfileBy(ProfileName);
            if (dtPF != null)
            {
                if (dtPF.Rows.Count > 0)
                {
                    PARSSamplingStartHeight = float.Parse(dtPF.Rows[0]["StartHeight"].ToString());
                    PARSSamplingDistance = float.Parse(dtPF.Rows[0]["Distance"].ToString());
                    //
                    Error1 = dtPF.Rows[0]["Error1"].ToString();
                    Error2 = dtPF.Rows[0]["Error2"].ToString();
                    Error3 = dtPF.Rows[0]["Error3"].ToString();
                    Error4 = dtPF.Rows[0]["Error4"].ToString();
                    Error5 = dtPF.Rows[0]["Error5"].ToString();
                    //
                    H1Par = float.Parse(dtPF.Rows[0]["H1Par"].ToString());
                    H2Par = float.Parse(dtPF.Rows[0]["H2Par"].ToString());
                    H3Par = float.Parse(dtPF.Rows[0]["H3Par"].ToString());
                    H4Par = float.Parse(dtPF.Rows[0]["H4Par"].ToString());
                    H5Par = float.Parse(dtPF.Rows[0]["H5Par"].ToString());
                    H6Par = float.Parse(dtPF.Rows[0]["H6Par"].ToString());
                    H7Par = float.Parse(dtPF.Rows[0]["H7Par"].ToString());
                    //
                    HAC1 = dtPF.Rows[0]["HAC1"].ToString();
                    HAC2 = dtPF.Rows[0]["HAC2"].ToString();
                    HAC3 = dtPF.Rows[0]["HAC3"].ToString();
                    HAC4 = dtPF.Rows[0]["HAC4"].ToString();
                    HAC5 = dtPF.Rows[0]["HAC5"].ToString();
                    HAC6 = dtPF.Rows[0]["HAC6"].ToString();
                    HAC7 = dtPF.Rows[0]["HAC7"].ToString();
                    //
                    F1Par = float.Parse(dtPF.Rows[0]["F1Par"].ToString());
                    F2Par = float.Parse(dtPF.Rows[0]["F2Par"].ToString());
                    F3Par = float.Parse(dtPF.Rows[0]["F3Par"].ToString());
                    F4Par = float.Parse(dtPF.Rows[0]["F4Par"].ToString());
                    F5Par = float.Parse(dtPF.Rows[0]["F5Par"].ToString());
                    F6Par = float.Parse(dtPF.Rows[0]["F6Par"].ToString());
                    F7Par = float.Parse(dtPF.Rows[0]["F7Par"].ToString());
                    //
                    FAC1 = dtPF.Rows[0]["FAC1"].ToString();
                    FAC2 = dtPF.Rows[0]["FAC2"].ToString();
                    FAC3 = dtPF.Rows[0]["FAC3"].ToString();
                    FAC4 = dtPF.Rows[0]["FAC4"].ToString();
                    FAC5 = dtPF.Rows[0]["FAC5"].ToString();
                    FAC6 = dtPF.Rows[0]["FAC6"].ToString();
                    FAC7 = dtPF.Rows[0]["FAC7"].ToString();
                    //
                    SP1 = float.Parse(dtPF.Rows[0]["SP1"].ToString());
                    SP2 = float.Parse(dtPF.Rows[0]["SP2"].ToString());
                    SP3 = float.Parse(dtPF.Rows[0]["SP3"].ToString());
                    SP4 = float.Parse(dtPF.Rows[0]["SP4"].ToString());
                    SP5 = float.Parse(dtPF.Rows[0]["SP5"].ToString());
                    SP6 = float.Parse(dtPF.Rows[0]["SP6"].ToString());
                    SP7 = float.Parse(dtPF.Rows[0]["SP7"].ToString());
                }
            }
            dtPF.Dispose();
            dtPF = null;
            //
            // Compute tool parameters
            this.ToolSize = new SizeF(this.ToolWidth, this.ToolLength);
            if (this.ToolSize.Width <= 0) this.ToolSize.Width = 1;
            if (this.ToolSize.Height <= 0) this.ToolSize.Height = 1;
            //
            //
            /* -----------------------------------------------------------------------------------------
             * ชุดคำสั่ง ต่อไปนี้ ถูกออกแบบตามความต้องการ เข้าถึงข้อมูลจากฐานข้อมูล 
             * เช่น ระยะสั่งให้เลื่อนแท่นกด เป็นต้น        
             * ----------------------------------------------------------------------------------------*/
            /* ----------------------------------------------
             * Graph scaling
             * ----------------------------------------------*/
            GraphHorizontalFrom = CONUnseatedTop - CONHeight;
            GraphHorizontalTo = GraphHorizontalFrom - GraphDistance;
            //
            GraphVerticalFrom = 0;
            GraphVerticalTo = GraphFPerPin;
            //
            GraphForceLimit = MaxFPerPin / 2 + MinFPerPin / 2;
            GraphHeightLimit = 0;
            //
            /* ----------------------------------------------
             * Height parameters
             * ----------------------------------------------*/
            GotoZeroSpeed = Properties.Settings.Default.GotoZeroSpeed; // mm per sec
            ZeroClearance = Properties.Settings.Default.ZeroClearance; //mm
            ZeroHeight = Properties.Settings.Default.ZeroHeight; // mm
            //
            /* ----------------------------------------------
             * Distance parameters
             * ----------------------------------------------*/
            UnseatedToolTop = FixtureThickness + BoardThickness + CONUnseatedTop - CONHeight + CONBaseThickness + ToolHeight;
            Distance_UnseatedToolTop = ZeroHeight - UnseatedToolTop;
            AboveBoardBaseHeight = CONUnseatedTop - CONHeight;
            Distance_Seated = AboveBoardBaseHeight - CONSeatedHeight;
            //
            /* ----------------------------------------------
             * Profiled distance parameters
             * เครื่องหมาย (-) ให้กำหนดระยะ Jog แบบทิศขึ้นเป็น (-)
             * ----------------------------------------------*/
            PF_Row0_Distance = Distance_UnseatedToolTop - Properties.Settings.Default.OffsetTopDistance;
            PF_Row1_Distance = Properties.Settings.Default.OffsetTopDistance - H1Par;
            PF_Row2_Distance = Distance_Seated - H2Par + H1Par;
            PF_Row3_Distance = Distance_Seated - H3Par + H1Par;
            PF_Row4_Distance = Distance_Seated - H4Par + H1Par;
            PF_Row5_Distance = Distance_Seated - H5Par + H1Par;
            PF_Row6_Distance = Distance_Seated - H6Par + H1Par;
            PF_Row7_Distance = Distance_Seated - H7Par + H1Par;
            //
            /* ----------------------------------------------
             * Profiled distance parameters
             * ----------------------------------------------*/
            PF_Row1_Force = F1Par;
            PF_Row2_Force = MinFPerPin * NumberOfPins + F2Par;
            PF_Row3_Force = MaxFPerPin * NumberOfPins + F3Par;
            PF_Row4_PARS = F4Par;
            PF_Row5_Force = F5Par;
            PF_Row6_Force = MaxFPerPin * NumberOfPins + F6Par;
            PF_Row7_Grad = F7Par;
            //
        }

        // ---------------------------------------------------------
        // Secondary height parameters 
        // ---------------------------------------------------------
        public float GraphHorizontalFrom;
        public float GraphHorizontalTo;
        //
        public float GraphVerticalFrom;
        public float GraphVerticalTo;
        //
        public float GraphForceLimit;
        public float GraphHeightLimit;
        //
        public float ZeroClearance;
        public float ZeroHeight;
        public float GotoZeroSpeed;
        public float UnseatedToolTop;
        public float AboveBoardBaseHeight;
        //
        public float Distance_UnseatedToolTop;
        public float Distance_Seated;
        //
        public float PF_Row0_Distance;
        public float PF_Row1_Distance;
        public float PF_Row2_Distance;
        public float PF_Row3_Distance;
        public float PF_Row4_Distance;
        public float PF_Row5_Distance;
        public float PF_Row6_Distance;
        public float PF_Row7_Distance;
        //
        public float PF_Row1_Force;
        public float PF_Row2_Force;
        public float PF_Row3_Force;
        public float PF_Row4_PARS;
        public float PF_Row5_Force;
        public float PF_Row6_Force;
        public float PF_Row7_Grad;
        // ----------------------------------------------------------

        public override string ToString()
        {
            return ConnectorType + " X = " + this.X + " Y = " + this.Y + " Width = " + this.ToolWidth + " Length = " + this.ToolLength;
        }
    }
}
