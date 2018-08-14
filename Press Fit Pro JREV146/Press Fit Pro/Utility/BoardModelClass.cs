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
    public class BoardModelClass
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
            if (_Image != null)
            {
                _Image.Dispose();
                _Image = null;
            }
            ImageFile = "";
            RemovePaintEventHandle();
        }

        #endregion

        #region Properties

        public string ImageFile
        {
            get { return _ImageFile; }
            set
            {
                _ImageFile = value;
                if (System.IO.File.Exists(_ImageFile))
                {
                    if (_Image != null)
                    {
                        _Image.Dispose();
                        _Image = null;
                    }
                    _Image = new Bitmap(_ImageFile);
                    srcRect.X = 0; srcRect.Y = 0;
                    srcRect.Width = _Image.Width;
                    srcRect.Height = _Image.Height;

                    this.Info.ImageFile = _ImageFile;

                    //this.DrawNow();
                }
            }
        }

        public PointF PhysicalOffset
        {
            get { return _PhysicalOffset; }
            set
            {
                _PhysicalOffset = value;
                UpdateImageDimension();
                //this.DrawNow();
            }
        }

        public SizeF PhysicalSize
        {
            get { return _PhysicalSize; }
            set
            {
                _PhysicalSize = value;
                UpdateImageDimension();
                //this.DrawNow();
            }
        }

        public Size DrawingSize
        {
            get { return _DrawingSize; }
            set
            {
                _DrawingSize = value;
                UpdateImageDimension();
                //this.DrawNow();
            }
        }

        #endregion

        #region Members

        private PictureBox Canvas;

        public BoardInfo Info;

        string _ImageFile = "";
        private Image _Image;
        Rectangle destRect = new Rectangle(0, 0, 450, 150);
        Rectangle srcRect = new Rectangle(0, 0, 1024, 768);
        GraphicsUnit units = GraphicsUnit.Pixel;

        int margin = 20;

        PointF _PhysicalOffset = new PointF(0, 0);
        SizeF _PhysicalSize = new SizeF(100, 100);
        Size _DrawingSize = new Size(100, 100);

        public List<ConnectorEntityClass> ConnectorEntities = new List<ConnectorEntityClass>();

        #endregion

        public void UpdateBoardInfo(BoardInfo info)
        {
            this.Info = info;
            ImageFile = this.Info.ImageFile;

            //Define dimension
            PhysicalSize = this.Info.PhysicalSize;

            //After define dimension, define tool entities.
            Zoom(margin);
            UpdateConnectorEntities();
        }

        #region Constructor / Deconstructor

        public BoardModelClass(ref PictureBox canvas, BoardInfo info)
        {
            ConnectorEntities.Clear();

            this.Canvas = canvas;
            
            this.Info = info;
            ImageFile = this.Info.ImageFile;

            //Define dimension
            PhysicalSize = this.Info.PhysicalSize;

            //After define dimension, define tool entities.
            Zoom(margin);
            UpdateConnectorEntities();
        }

        ~BoardModelClass()
        {
            Dispose();
        }

        #endregion

        #region Remove paint event

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

        #endregion

        #region Drawing

        public void UpdateConnectorEntities()
        {
            ConnectorEntities.Clear();
            ConnectorEntityClass connector;
            if (this.Info.ConnectorList != null)
                if (this.Info.ConnectorList.Count > 0)
                    foreach (ConnectorInfo t in this.Info.ConnectorList)
                    {
                        connector = new ConnectorEntityClass(t.ConnectorType, t.Location, t.ToolSize, t.Angle,
                            _PhysicalOffset, _PhysicalSize, _DrawingSize, ref this.Canvas);
                        connector.Select = false;
                        ConnectorEntities.Add(connector);
                    }
        }

        public void Zoom(int margin)
        {
            if (_Image != null)
            {
                SizeF ratio = new SizeF((float)(this.Canvas.ClientRectangle.Size.Width - margin * 2) / (float)_Image.Size.Width,
                                        (float)(this.Canvas.ClientRectangle.Size.Height - margin * 2) / (float)_Image.Size.Height);
                if (ratio.Width < ratio.Height)
                    DoZoomByWidth(margin);
                else
                    DoZoomByHeight(margin);
            }
        }

        public void DoZoomByWidth(int margin)
        {
            //Zoom image in pixel by WIDTH
            destRect.X = margin;
            destRect.Width = this.Canvas.ClientRectangle.Size.Width - margin * 2;
            float ZoomRatio = (float)destRect.Width / (float)_Image.Size.Width;
            destRect.Height = (int)((float)_Image.Height * ZoomRatio);
            destRect.Y = (int)(((float)this.Canvas.ClientRectangle.Size.Height - (float)destRect.Height) / 2.0f);

            //Define physical dimension in mm per pixel for an example.
            _DrawingSize = new Size(destRect.Width, destRect.Height);
            SizeF UnitRatio = new SizeF(_PhysicalSize.Width / (float)_DrawingSize.Width,
                                        _PhysicalSize.Height / (float)_DrawingSize.Height);
            _PhysicalOffset.X = destRect.X * UnitRatio.Width;
            _PhysicalOffset.Y = destRect.Y * UnitRatio.Height;

            //this.DrawNow();
        }

        public void DoZoomByHeight(int margin)
        {
            //Zoom image in pixel by WIDTH
            destRect.Y = margin;
            destRect.Height = this.Canvas.ClientRectangle.Size.Height - margin * 2;
            float ZoomRatio = (float)destRect.Height / (float)_Image.Size.Height;
            destRect.Width = (int)((float)_Image.Width * ZoomRatio);
            destRect.X = (int)(((float)this.Canvas.ClientRectangle.Size.Width - (float)destRect.Width) / 2.0f);

            //Define physical dimension in mm per pixel for an example.
            _DrawingSize = new Size(destRect.Width, destRect.Height);
            SizeF UnitRatio = new SizeF(_PhysicalSize.Width / (float)_DrawingSize.Width,
                                        _PhysicalSize.Height / (float)_DrawingSize.Height);
            _PhysicalOffset.X = destRect.X * UnitRatio.Width;
            _PhysicalOffset.Y = destRect.Y * UnitRatio.Height;

            //this.DrawNow();
        }

        public void UpdateImageDimension()
        {
            //Define physical dimension in mm per pixel for an example.
            SizeF UnitRatio = new SizeF(_PhysicalSize.Width / (float)_DrawingSize.Width,
                                        _PhysicalSize.Height / (float)_DrawingSize.Height);
            destRect.Size = _DrawingSize;
            destRect.X = (int)(_PhysicalOffset.X / UnitRatio.Width);
            destRect.Y = this.Canvas.ClientRectangle.Height - destRect.Height - (int)(_PhysicalOffset.Y / UnitRatio.Height);

        }

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
                        g.Clear(Color.LightSkyBlue);
                        
                        //Image        
                        g.DrawImage(_Image, destRect, srcRect, units);

                        //Connectors
                        foreach (ConnectorEntityClass t in ConnectorEntities)
                        {
                            t.Draw(g);
                        }
                    }
                    this.Canvas.Invalidate();
                }
            }
            catch (Exception ex) { Log.AppendText(ex.Message); }
        }

        #endregion

    }
}
