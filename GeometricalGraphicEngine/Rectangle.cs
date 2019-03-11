using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricalGraphicEngine
{
    [Serializable]
    class Rectangle : Drawable
    {
        public Point2D UpperLeftPoint { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }

        public Rectangle(Point2D bottomLeftPoint, Color color, float height, float width)
        {

            this.UpperLeftPoint = new Point2D(bottomLeftPoint);
            this.UpperLeftPoint.AbsoluteToPixels();
            this.Color = color;
            this.Height = height;
            this.Width = width;
        }
        public override void Draw(Graphics graphics)
        {
            Brush brush = new System.Drawing.SolidBrush(this.Color);
            Pen pen = new Pen(brush, 5);
            graphics.DrawRectangle(pen, UpperLeftPoint.X, UpperLeftPoint.Y, Width, Height);
        }
    }
}
