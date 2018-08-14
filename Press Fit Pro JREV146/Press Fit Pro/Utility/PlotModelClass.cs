using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.ComponentModel;

namespace Press_Fit_Pro
{
    public class PlotModelClass
    {
        #region Dispose

        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                //
                DoDisposed();
            }

            // Free any unmanaged objects here. 
            //
            disposed = true;
        }

        private void DoDisposed()
        {
            RemovePaintEventHandle();
            _TextBrush.Dispose();
            _LinePen.Dispose();
            _AxesPen.Dispose();
        }

        #endregion

        #region Members

        private PictureBox Canvas;

        public BoardInfo Info;

        private int _ConnectorIndex=0;
        public int ConnectorIndex { get { return _ConnectorIndex; } set { _ConnectorIndex = value; ComputeAxesDimension(); } }

        PointF _PhysicalOffset = new PointF(0, 0);
        RectangleF _PhysicalRect;
        Size _DrawingSize = new Size(100, 100);

        //Real data
        public List<double> Stain = new List<double>();
        public List<double> Compressions = new List<double>();

        //Plot data
        public List<Point> CurveData = new List<Point>();

        Font drawFont = new Font("Arial", 10, FontStyle.Regular);

        private Color _AxesBackgroundColor = Color.White;
        Brush _AxesBackgroundBrush = new SolidBrush(Color.White);

        private Color _TextColor = Color.Black;
        Brush _TextBrush = new SolidBrush(Color.Black);

        private Color _AxesColor = Color.Black;
        private float _AxesLineWidth = 2.0f;
        Pen _AxesPen = new Pen(Color.Black, 2.0f);

        private Color _LineColor = Color.Blue;
        private float _LineWidth = 1.0f;
        Pen _LinePen = new Pen(Color.Blue, 1.0f);

        private Color _LimitLineColor = Color.Red;
        private float _LimitLineWidth = 1.0f;
        Pen _ForceLimitLinePen = new Pen(Color.Green, 1.0f);
        Pen _HeightLimitLinePen = new Pen(Color.Red, 1.0f);

        private string _XLabel = "Height above board, mm";
        private string _YLabel = "Force/Pin, kg";

        #endregion

        #region Properties

        public Color AxesBackground { get { return _AxesBackgroundColor; } set { _AxesBackgroundColor = value; _AxesBackgroundBrush = new SolidBrush(_AxesBackgroundColor); } }

        public Color TextColor { get { return _TextColor; } set { _TextColor = value; _TextBrush = new SolidBrush(_TextColor); } }

        public Color AxesColor { get { return _AxesColor; } set { _AxesColor = value; _AxesPen = new Pen(_AxesColor, _AxesLineWidth); } }
        public float AxesLineWidth { get { return _AxesLineWidth; } set { _AxesLineWidth = value; _AxesPen = new Pen(_AxesColor, _AxesLineWidth); } }

        public Color LineColor { get { return _LineColor; } set { _LineColor = value; _LinePen = new Pen(_LineColor, _LineWidth); } }
        public float LineWidth { get { return _LineWidth; } set { _LineWidth = value; _LinePen = new Pen(_LineColor, _LineWidth); } }

        public Color LimitLineColor { get { return _LimitLineColor; } set { _LimitLineColor = value; _ForceLimitLinePen = new Pen(_LimitLineColor, _LimitLineWidth); } }
        public float LimitLineWidth { get { return _LimitLineWidth; } set { _LimitLineWidth = value; _ForceLimitLinePen = new Pen(_LimitLineColor, _LimitLineWidth); } }

        #endregion

        #region Constructor / Deconstructor

        public PlotModelClass(ref PictureBox canvas, BoardInfo info)
        {
            this.Canvas = canvas;

            // ทดสอบด้วยระบบ วาดด้วย image buffer เพื่อเพิ่มความเร็ว
            //this.Canvas.Paint += new PaintEventHandler(Canvas_Paint);

            this.Info = info;

            //Define plotter graphic model from board info
            ComputeAxesDimension();

        }

        ~PlotModelClass()
        {
            Dispose();
        }

        #endregion

        #region Methods

        public void RemovePaintEventHandle()
        {
            RemovePaintEvent(this.Canvas);
        }

        private void RemovePaintEvent(PictureBox b)
        {
            FieldInfo f1 = typeof(Control).GetField("EventPaint",
                BindingFlags.Static | BindingFlags.NonPublic);
            object obj = f1.GetValue(b);
            PropertyInfo pi = b.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
            list.RemoveHandler(obj, list[obj]);
        }

        public void Clear()
        {
            this.Stain.Clear();
            this.Compressions.Clear();
            this.CurveData.Clear();
            ConnectorIndex = 0;
            DrawNow();
        }

        #endregion

        #region Drawing

        public void AddData(ElectronicsHeightStructure h, double w)
        {
            Stain.Add(h.Position_mm);
            Compressions.Add(w);
        }

        public void AddData(double h, double w)
        {
            Stain.Add(h);
            Compressions.Add(w / Info.ConnectorList[_ConnectorIndex].NumberOfPins);
        }

        int lastIndex = 0;
        PointF realPoint;
        public void Update()
        {
            ////--------------------------------------------------------
            ////***Real data
            //public List<ElectronicsPositionStructure> Stain = new List<ElectronicsPositionStructure>();
            //public List<double> Compressions = new List<double>();
            //
            ////***Plot data
            //public List<Point> CurveData = new List<Point>();
            ////--------------------------------------------------------
            //
            //For the last input, Convert real data to curve data
            lastIndex = Stain.Count - 1;
            realPoint = new PointF((float)Stain[lastIndex], (float)Compressions[lastIndex]);
            CurveData.Add(realPoint.ToCanvas(_PhysicalOffset, _PhysicalRect, _DrawingSize, this.Canvas.ClientRectangle.Size));
            //
            //Paint
            UpdateOnlyCurve();
        }
        //
        public void RedrawAxes()
        {
            Graphics g = this.Canvas.CreateGraphics();
            DrawAxes(g);
        }
        //
        //Offset of pixel error
        int _XOffset = 1;
        int _YOffset = 1;
        //
        //Default axes layout
        int LeftMargin = 60;
        int RightMargin = 20;
        int TopMargin = 20;
        int BottomMargin = 20;
        //
        //Layout
        Rectangle rectYLabel;
        Rectangle rectXLabel;
        public Rectangle rectAxes;
        Rectangle rectCurve;
        Point[] lineAxes = new Point[3];
        //
        //Tick layout
        int XTickLength = 10;//Pixel
        int YTickLength = 10;//Pixel
        //
        int XTickCount = 10;
        int YTickCount = 10;
        //
        float TickDX, TickDY;
        float DX, DY;
        //
        int XTickTop, XTickBottom;
        int YTickLeft, YTickRight;
        //
        List<int> XTickList = new List<int>();
        List<int> YTickList = new List<int>();
        //
        List<string> XTickLabelList = new List<string>();
        List<string> YTickLabelList = new List<string>();
        //
        List<RectangleF> XTickLabelLayoutList = new List<RectangleF>();
        List<RectangleF> YTickLabelLayoutList = new List<RectangleF>();
        //
        string XTickLabelFormat = "F2";
        string YTickLabelFormat = "F1";
        //
        //Limit line
        Point[] ForceLimitCurveData = new Point[2];
        Point[] HeightLimitCurveData = new Point[2];
        //
        public void ComputeAxesDimension()
        {
            //Graphic controller
            Graphics g = this.Canvas.CreateGraphics();
            //
            //Graph info 
            float XMIN = this.Info.ConnectorList[_ConnectorIndex].GraphHorizontalFrom;
            float XMAX = this.Info.ConnectorList[_ConnectorIndex].GraphHorizontalTo;
            float YMIN = this.Info.ConnectorList[_ConnectorIndex].GraphVerticalFrom;
            float YMAX = this.Info.ConnectorList[_ConnectorIndex].GraphVerticalTo;
            //
            //X label font dimension
            float _XLabelWidth = g.MeasureString(_XLabel, drawFont).Width + _XOffset;
            float _XLabelHeight = g.MeasureString(_XLabel, drawFont).Height + _YOffset;
            //
            //Y label font dimension
            float _YLabelWidth = g.MeasureString(_YLabel, drawFont).Width + _XOffset;
            float _YLabelHeight = g.MeasureString(_YLabel, drawFont).Height + _YOffset;
            System.Drawing.SizeF YMaxLabelSize = g.MeasureString(YMAX.ToString(YTickLabelFormat), drawFont);
            //
            //Refresh margin by labels
            LeftMargin = System.Math.Max((int)YMaxLabelSize.Width + YTickLength + 2, (int)_YLabelWidth / 2 + 2);
            TopMargin = (int)(_YLabelHeight + YMaxLabelSize.Height / 2 + 5);
            BottomMargin = (int)_XLabelHeight * 2 + XTickLength + 5;
            //
            //Axes layout
            rectAxes = new Rectangle(LeftMargin,
                                     TopMargin,
                                     Canvas.ClientRectangle.Width - LeftMargin - RightMargin + _XOffset,
                                     Canvas.ClientRectangle.Height - TopMargin - BottomMargin + _YOffset);
            rectCurve = new Rectangle(LeftMargin + _XOffset,
                                     0,
                                     Canvas.ClientRectangle.Width - LeftMargin ,
                                     Canvas.ClientRectangle.Height - BottomMargin );
            //
            rectXLabel = new Rectangle(LeftMargin + (rectAxes.Width - (int)_XLabelWidth) / 2,
                                       TopMargin + rectAxes.Height + XTickLength + (int)_XLabelHeight,
                                       (int)_XLabelWidth,
                                       (int)_XLabelHeight);
            //
            rectYLabel = new Rectangle(LeftMargin - (int)_YLabelWidth / 2,
                                       2,
                                       (int)_YLabelWidth,
                                       (int)_YLabelHeight);
            //
            //Tick layout
            TickDX = ((float)rectAxes.Width + (float)_XOffset / 2.0f) / (float)XTickCount;
            TickDY = ((float)rectAxes.Height) / (float)YTickCount;
            //
            DX = (XMAX - XMIN) / XTickCount;
            DY = (YMAX - YMIN) / YTickCount;
            //
            XTickTop = rectAxes.Top + rectAxes.Height + _YOffset;
            XTickBottom = XTickTop + XTickLength;
            //
            YTickLeft = rectAxes.Left - YTickLength - _YOffset;
            YTickRight = rectAxes.Left - _YOffset;
            //
            XTickList.Clear();
            XTickLabelList.Clear();
            XTickLabelLayoutList.Clear();
            System.Drawing.SizeF LabelSize;
            float TickPosition;
            string str;
            for (int i = 0; i <= XTickCount; i++)
            {
                TickPosition = rectAxes.Left + i * TickDX;
                XTickList.Add((int)TickPosition);
                str = (i * DX + XMIN).ToString(XTickLabelFormat);
                XTickLabelList.Add(str);
                LabelSize = g.MeasureString(str, drawFont);
                XTickLabelLayoutList.Add(new RectangleF(TickPosition - LabelSize.Width / 2, XTickBottom, LabelSize.Width, LabelSize.Height));
            }
            //
            YTickList.Clear();
            YTickLabelList.Clear();
            YTickLabelLayoutList.Clear();
            for (int i = 0; i <= YTickCount; i++)
            {
                TickPosition = rectAxes.Top + rectAxes.Height - i * TickDY;
                YTickList.Add((int)TickPosition);
                str = (i * DY + YMIN).ToString(YTickLabelFormat);
                YTickLabelList.Add(str);
                LabelSize = g.MeasureString(str, drawFont);
                YTickLabelLayoutList.Add(new RectangleF(YTickLeft - LabelSize.Width, TickPosition - LabelSize.Height / 2, LabelSize.Width, LabelSize.Height));
            }
            //
            //Curve conversion properties
            _PhysicalRect = new RectangleF(XMIN, YMIN, XMAX - XMIN, YMAX - YMIN);
            _DrawingSize = rectAxes.Size;
            SizeF ratio = new SizeF((float)_PhysicalRect.Width / _DrawingSize.Width, (float)_PhysicalRect.Height / _DrawingSize.Height);
            _PhysicalOffset = new PointF((float)LeftMargin * ratio.Width, (float)BottomMargin * ratio.Height);
            //
            //Force limit line 
            realPoint = new PointF(XMIN, this.Info.ConnectorList[_ConnectorIndex].GraphForceLimit);
            ForceLimitCurveData[0] = realPoint.ToCanvas(_PhysicalOffset, _PhysicalRect, _DrawingSize, this.Canvas.ClientRectangle.Size);
            realPoint = new PointF(XMAX, this.Info.ConnectorList[_ConnectorIndex].GraphForceLimit);
            ForceLimitCurveData[1] = realPoint.ToCanvas(_PhysicalOffset, _PhysicalRect, _DrawingSize, this.Canvas.ClientRectangle.Size);
            //
            //Height limit line 
            realPoint = new PointF(this.Info.ConnectorList[_ConnectorIndex].GraphHeightLimit, YMIN);
            HeightLimitCurveData[0] = realPoint.ToCanvas(_PhysicalOffset, _PhysicalRect, _DrawingSize, this.Canvas.ClientRectangle.Size);
            realPoint = new PointF(this.Info.ConnectorList[_ConnectorIndex].GraphHeightLimit, YMAX);
            HeightLimitCurveData[1] = realPoint.ToCanvas(_PhysicalOffset, _PhysicalRect, _DrawingSize, this.Canvas.ClientRectangle.Size);           
            //
            // Axes line
            lineAxes[0].X = rectAxes.X;
            lineAxes[0].Y = rectAxes.Y;
            //
            lineAxes[1].X = rectAxes.X;
            lineAxes[1].Y = rectAxes.Y + rectAxes.Height;
            //
            lineAxes[2].X = rectAxes.X + rectAxes.Width;
            lineAxes[2].Y = rectAxes.Y + rectAxes.Height;
        }
        //
        private void DrawAxes(Graphics g)
        {
            try
            {
                //X label
                g.DrawString(_XLabel, drawFont, _TextBrush, rectXLabel);
                g.DrawRectangle(_AxesPen, rectXLabel);
                //
                //Y label
                g.DrawString(_YLabel, drawFont, _TextBrush, rectYLabel);
                g.DrawRectangle(_AxesPen, rectYLabel);
                //
                //X tick layout
                for (int i = 0; i < XTickList.Count; i++)
                {
                    g.DrawLine(_AxesPen, XTickList[i], XTickTop, XTickList[i], XTickBottom);
                    g.DrawString(XTickLabelList[i], drawFont, _TextBrush, XTickLabelLayoutList[i]);
                }
                //
                //Y tick layout
                for (int i = 0; i < YTickList.Count; i++)
                {
                    g.DrawLine(_AxesPen, YTickLeft, YTickList[i], YTickRight, YTickList[i]);
                    g.DrawString(YTickLabelList[i], drawFont, _TextBrush, YTickLabelLayoutList[i]);
                }
            }
            catch
            {
                throw;
            }
        }
        //
        public void DrawNow()
        {
            try
            {
                if (this.Canvas.Image == null)
                {
                    Bitmap bmp = new Bitmap(this.Canvas.Width, this.Canvas.Height);
                    this.Canvas.Image = bmp;
                }
                lock (this.Canvas.Image)
                {
                    using (Graphics g = Graphics.FromImage(this.Canvas.Image))
                    {
                        g.Clear(Color.White);// Clear
                        if (CurveData.Count > 1)
                            g.DrawLines(_LinePen, CurveData.ToArray()); // Curve                        
                        g.DrawLines(_ForceLimitLinePen, ForceLimitCurveData); // Force limit line
                        g.DrawLines(_HeightLimitLinePen, HeightLimitCurveData); // Height limit line
                        DrawAxes(g); // Axes                        
                        g.DrawLines(_AxesPen, lineAxes); // Axes layout
                    }
                    this.Canvas.Invalidate(); // Paint all
                }
            }
            catch (Exception ex) { Log.AppendText(ex.Message); }
        }
        //
        public void ClearCanvas()
        {
            try
            {
                if (this.Canvas.Image == null)
                {
                    Bitmap bmp = new Bitmap(this.Canvas.Width, this.Canvas.Height);
                    this.Canvas.Image = bmp;
                }
                lock (this.Canvas.Image)
                {
                    using (Graphics g = Graphics.FromImage(this.Canvas.Image))
                    {
                        g.Clear(Color.White); // Clear
                    }
                    this.Canvas.Invalidate();
                }
            }
            catch (Exception ex) { Log.AppendText(ex.Message); }
        }

        public void UpdateOnlyCurve()
        {
            try
            {
                if (this.Canvas.Image == null)
                {
                    Bitmap bmp = new Bitmap(this.Canvas.Width, this.Canvas.Height);
                    this.Canvas.Image = bmp;
                }
                lock (this.Canvas.Image)
                {
                    using (Graphics g = Graphics.FromImage(this.Canvas.Image))
                    {
                        g.Clear(Color.White); // Clear
                        if (CurveData.Count > 1)
                            g.DrawLines(_LinePen, CurveData.ToArray()); // Curve                                                
                        g.DrawLines(_ForceLimitLinePen, ForceLimitCurveData); // Force limit line
                        g.DrawLines(_HeightLimitLinePen, HeightLimitCurveData); // Height limit line                        
                        g.DrawString(_YLabel, drawFont, _TextBrush, rectYLabel); // Y label                        
                        g.DrawRectangle(_AxesPen, rectYLabel); // Y label layout                       
                    }
                    this.Canvas.Invalidate(rectCurve); // Paint only curve
                }
            }
            catch (Exception ex) { Log.AppendText(ex.Message); }
        }

        #endregion
    }
}
