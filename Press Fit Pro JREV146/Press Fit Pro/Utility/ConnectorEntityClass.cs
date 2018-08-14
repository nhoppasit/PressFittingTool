using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Press_Fit_Pro
{
    public class ConnectorEntityClass : IDisposable
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
            if (_SelectedBrush != null)
            {
                _SelectedBrush.Dispose();
                _SelectedBrush = null;
            }
            if (_Brush != null)
            {
                _Brush.Dispose();
                _Brush = null;
            }
            if (_ConnectorPen != null)
            {
                _ConnectorPen.Dispose();
                _ConnectorPen = null;
            }
            if (_TextBrush != null)
            {
                _TextBrush.Dispose();
                _TextBrush = null;
            }
        }

        #endregion

        #region Properties

        private RectangleF rectConnectorF;
        private Rectangle rectConnector;
        private float Angle = 0;

        private bool _Select = false;
        public bool Select
        {
            get { return _Select; }
            set
            {
                _Select = value;
            }
        }

        private string _Text = "ABC";
        public string Text
        {
            get { return _Text; }
            set
            {
                _Text = value;
            }
        }

        private Color _SelectedFillColor = Color.Red;
        public Color SelectedFillColor
        {
            get { return _SelectedFillColor; }
            set
            {
                _SelectedFillColor = value;
                if (_SelectedBrush != null)
                {
                    _SelectedBrush.Dispose();
                    _SelectedBrush = null;
                }
                _SelectedBrush = new SolidBrush(_SelectedFillColor);               
            }
        }

        private Color _FillColor = Color.DarkGray;
        public Color FillColor
        {
            get { return _FillColor; }
            set
            {
                _FillColor = value;
                if (_Brush != null)
                {
                    _Brush.Dispose();
                    _Brush = null;
                }
                _Brush = new SolidBrush(_FillColor);
            }
        }

        private Color _BorderColor = Color.Black;
        public Color BorderColor
        {
            get { return _BorderColor; }
            set
            {
                _BorderColor = value;
                if (_ConnectorPen != null)
                {
                    _ConnectorPen.Dispose();
                    _ConnectorPen = null;
                }
                _ConnectorPen = new Pen(_BorderColor);
            }
        }

        private Color _TextColor = Color.Black;
        public Color TextColor
        {
            get { return _TextColor; }
            set
            {
                _TextColor = value;
                if (_TextBrush != null)
                {
                    _TextBrush.Dispose();
                    _TextBrush = null;
                }
                _TextBrush = new SolidBrush(_TextColor);
            }
        }

        #endregion

        #region Members

        private PictureBox Canvas; //Reference

        private Brush _TextBrush;
        private Pen _ConnectorPen;
        private Brush _Brush;
        private Brush _SelectedBrush;

        Font drawFont = new Font("Arial", 10, FontStyle.Regular);

        #endregion

        #region Constructor / Deconstructor

        public ConnectorEntityClass(string text, PointF location, SizeF connectorSize, float angle, PointF physicalOffset, SizeF physicalSize, Size drawingSize, ref PictureBox canvas)
        {
            this._Text = text;

            this.Canvas = canvas;

            _TextBrush = new SolidBrush(_TextColor);
            _ConnectorPen = new Pen(_BorderColor);
            _Brush = new SolidBrush(_FillColor);
            _SelectedBrush = new SolidBrush(_SelectedFillColor);

            rectConnectorF = new RectangleF();
            rectConnectorF.X = location.X;
            rectConnectorF.Y = location.Y;
            rectConnectorF.Width = connectorSize.Width;
            rectConnectorF.Height = connectorSize.Height;

            Point drawLocation = location.ToCanvas(physicalOffset, physicalSize, drawingSize, this.Canvas.ClientRectangle.Size);
            Size drawSize = connectorSize.ToCanvas(physicalSize, drawingSize);

            rectConnector = new Rectangle();
            rectConnector.X = drawLocation.X;
            rectConnector.Y = drawLocation.Y - drawSize.Height;
            rectConnector.Width = drawSize.Width;
            rectConnector.Height = drawSize.Height;

            this.Angle = angle;
        }

        ~ConnectorEntityClass()
        {
            Dispose();
        }

        #endregion

        #region Draw

        public void Draw(Graphics g)
        {
            using (Matrix m = new Matrix())
            {
                //m.RotateAt(this.Angle, new System.Drawing.PointF( (float)rectConnector.Left + (float)(rectConnector.Width / 2), 
                //                                                  (float)rectConnector.Top + (float)(rectConnector.Height / 2)));
                m.RotateAt(-this.Angle, new System.Drawing.PointF((float)rectConnector.Left, (float)rectConnector.Top));
                g.Transform = m;
                if (_Select) g.FillRectangle(_SelectedBrush, rectConnector);
                else g.FillRectangle(_Brush, rectConnector);
                g.DrawRectangle(_ConnectorPen, rectConnector);
                g.DrawString(_Text, drawFont, _TextBrush, rectConnector);
                g.ResetTransform();
            }
        }

        #endregion
    }
}
