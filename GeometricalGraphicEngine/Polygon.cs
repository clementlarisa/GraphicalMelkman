using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GeometricalGraphicEngine
{
    class Polygon:Drawable
    {
        public List<Point2D> points { get; set; }
        public bool isDrawbale = true;
        public Polygon()
        {
            points = new List<Point2D>();
        }
        public Polygon(List<Point2D> toCopy, Color color)
        {
            this.Color = color;
            points = new List<Point2D>();
            foreach (Point2D point in toCopy)
            {

                points.Add(new Point2D(point));
            }
        }
        
        public override void Draw(Graphics graphics)
        {
            if (isDrawbale == false)
                return;
            Brush brush = new System.Drawing.SolidBrush(this.Color);
            Pen pen = new Pen(brush, 5);

            List <Point> drawablePoints = new List<Point>();


            Point2D prev = points[0];
            foreach(Point2D point in points)
            {
                point.AbsoluteToPixels();
                drawablePoints.Add(new Point((int)point.X, (int)point.Y));
            }

            graphics.DrawPolygon(pen, drawablePoints.ToArray());
        }
    }
}
