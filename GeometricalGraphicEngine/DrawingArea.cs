using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Serialization;
using System.ComponentModel;

namespace GeometricalGraphicEngine
{
    class DrawingArea : Panel
    {
        //[XmlIgnoreAttribute]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Drawable> ShapesToDraw { get; set; }
        public List<Polygon> PolyToDraw { get; set; }
        
        public DrawingArea():base()
        {
            PolyToDraw = new List<Polygon>();
            ShapesToDraw = new List<Drawable>();
            this.Paint += new System.Windows.Forms.PaintEventHandler(PaintHandler);
            Point2D.Height = this.Height;
            Point2D.Wdith = this.Width;
        }


        public void Update()
        {
            this.Refresh();
        }

        private void PaintHandler(object sender, PaintEventArgs pe)
        {
            this.Paint -= new System.Windows.Forms.PaintEventHandler(PaintHandler);
            Graphics graphics = pe.Graphics;
            graphics.Clear(this.BackColor);
            DrawAxis(graphics);
           
            foreach (Drawable shape in ShapesToDraw)
            {
                shape.Draw(graphics);
            }

            this.Paint += new System.Windows.Forms.PaintEventHandler(PaintHandler);

        }

        public void DrawAxis(Graphics graphics)
        {
            Point2D.Height = Height;
            Point2D.Wdith = Width;
            Brush brush = new System.Drawing.SolidBrush(Color.Black);
            Pen pen = new Pen(brush, 2);
            Pen pen1 = new Pen(brush, 1);


            float yOrigin = this.Height / 2;
            float xOrigin = this.Width / 2;

            //OX
            graphics.DrawLine(pen, 0, yOrigin, Width, yOrigin);
            int count = 0;
            for(int i = (int)xOrigin; i < Width; i+=50)
            {
                graphics.DrawLine(pen1, i, yOrigin + 10, i, yOrigin - 10);

                if (i != xOrigin)
                    graphics.DrawString(count.ToString(), Font, brush, i, yOrigin - 12);
                count++;
            }

            count = 0;
            for (int i = (int)xOrigin; i > 0; i -= 50)
            {
                graphics.DrawLine(pen1, i, yOrigin + 10, i, yOrigin - 10);
                if (i != xOrigin)
                    graphics.DrawString((-1*count).ToString(), Font, brush, i, yOrigin - 12);
                count++;
            }

            //OY
            graphics.DrawLine(pen, xOrigin, 0, xOrigin, Height);
            count = 0;
            for (int i = (int)yOrigin; i < Height; i+=50)
            {
                graphics.DrawLine(pen1, xOrigin - 10, i, xOrigin + 10, i);

                if (i != yOrigin)
                    graphics.DrawString((-1*count).ToString(), Font, brush, xOrigin - 12, i);
                count++;
            }
            count = 0;
            for (int i = (int)yOrigin; i > 0; i -= 50)
            {
                graphics.DrawLine(pen1, xOrigin - 10, i, xOrigin + 10, i);
                if (i != yOrigin)
                    graphics.DrawString( count.ToString(), Font, brush, xOrigin - 12, i);
                count++;
            }
        }
    }
}
