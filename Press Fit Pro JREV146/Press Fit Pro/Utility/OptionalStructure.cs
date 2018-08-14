using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Press_Fit_Pro
{
    public struct PointF
    {
        public float X, Y;

        public PointF(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return (String.Format("({0},{1})", this.X, this.Y));
        }

        public static PointF operator +(PointF p1, PointF p2)
        {
            return new PointF(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static PointF operator -(PointF p1, PointF p2)
        {
            return new PointF(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static PointF operator *(float a, PointF p)
        {
            return new PointF(a * p.X, a * p.Y);
        }

        public static PointF operator *(PointF p, float a)
        {
            return new PointF(a * p.X, a * p.Y);
        }

        public static PointF operator /(PointF p, float a)
        {
            return new PointF(p.X / a, p.Y / a);
        }

        private static int XOffset = 0;
        private static int YOffset = 0;

        public Point ToCanvas(PointF physicalOffset, SizeF physicalSize, Size drawingSize, Size canvasSize)
        {
            return new Point((int)((this.X + physicalOffset.X) * drawingSize.Width / physicalSize.Width) + XOffset,
                             canvasSize.Height - (int)((this.Y + physicalOffset.Y) * drawingSize.Height / physicalSize.Height) + YOffset);
        }

        public Point ToCanvas(PointF physicalOffset, RectangleF physicalRect, Size drawingSize, Size canvasSize)
        {
            return new Point((int)((this.X - physicalRect.X + physicalOffset.X) * drawingSize.Width / physicalRect.Width) + XOffset,
                             canvasSize.Height - (int)((this.Y - physicalRect.Y + physicalOffset.Y) * drawingSize.Height / physicalRect.Height) + YOffset);
        }
    }

    public struct SizeF
    {
        public float Width, Height;

        public SizeF(float width, float height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override string ToString()
        {
            return (String.Format("{0},{1}", this.Width, this.Height));
        }

        public static SizeF operator *(float a, SizeF s)
        {
            return new SizeF(a * s.Width, a * s.Height);
        }

        public static SizeF operator *(SizeF s, float a)
        {
            return new SizeF(a * s.Width, a * s.Height);
        }

        public static SizeF operator /(SizeF s, float a)
        {
            return new SizeF(s.Width / a, s.Height / a);
        }

        public Size ToCanvas(SizeF physicalSize, Size canvasSize)
        {
            return new Size((int)(this.Width * canvasSize.Width / physicalSize.Width),
                (int)(this.Height * canvasSize.Height / physicalSize.Height));
        }

        public static Size ToCanvas(SizeF s, SizeF physicalSize, Size canvasSize)
        {
            return new Size((int)(s.Width * canvasSize.Width / physicalSize.Width),
                (int)(s.Height * canvasSize.Height / physicalSize.Height));
        }

    }
}
