using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricalGraphicEngine
{
    [Serializable]
    class Point2D : Drawable
    {

        public static int Height = 1920;
        public static int Wdith = 1080;
        public bool isPixelValue { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public Point2D(float x = 0, float y = 0)
        {
            isPixelValue = true;
            this.X = x;
            this.Y = y;
        }
        public Point2D(Point2D toCopy)
        {
            isPixelValue = toCopy.isPixelValue;
            X = toCopy.X;
            Y = toCopy.Y;
        }
        public void AbsoluteToPixels()
        {
            if (isPixelValue == true)
                return;
            X = Wdith/2 + X*50;
            Y = Height/2 - Y*50;
            isPixelValue = true;
        }

        public void PixelsToAbsolute()
        {

            if (isPixelValue == false)
                return;
            X = (X - Wdith / 2) / 50;
            Y = (-1) * (Y - Height / 2) / 50;
            isPixelValue = false;
        }

        public override string ToString()
        {
            return "(" + X.ToString() + "," + Y.ToString() + ")"; 
        }
        public override void Draw(Graphics graphics)
        {
            Brush brush = new System.Drawing.SolidBrush(Color.Red);
            graphics.FillRectangle(brush, X, Y, 3, 3);
        }
    }
}
