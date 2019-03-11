using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeometricalGraphicEngine
{
    public partial class Form1 : Form
    {
        List<Point2D> userInputPoints;
        public Form1()
        {
            InitializeComponent();
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            userInputPoints = new List<Point2D>();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(drawingArea.PolyToDraw.Count > 0)
                drawingArea.PolyToDraw[drawingArea.PolyToDraw.Count - 1].isDrawbale = false;
            //At this point the userInputPoints list should be populated with absolute coordinates
            //all you have to do is call your method with this list, create a Polygon and draw it
            List<Point2D> resultedPoints = null;
            Melkman calculator = new Melkman(userInputPoints);
            resultedPoints = calculator.ConvexHull(); 
            Polygon poly = new Polygon(resultedPoints, Color.Blue); // you can change the collor here
            drawingArea.ShapesToDraw.Add(poly);
            drawingArea.PolyToDraw.Add(poly);
            drawingArea.Update();
        }

        private void drawingArea_Click(object sender, EventArgs e)
        {

            if (drawingArea.PolyToDraw.Count > 0)
                drawingArea.PolyToDraw[drawingArea.PolyToDraw.Count - 1].isDrawbale = false;
            Point point = drawingArea.PointToClient(Cursor.Position);
            drawingArea.ShapesToDraw.Add(new Point2D(point.X, point.Y));
            Point2D point2 = new Point2D(point.X,point.Y);
            point2.PixelsToAbsolute();
            userInputPoints.Add(point2);
            drawingArea.Update();
            ////userInpuPoints.Add(Point); Pixels to Absolute
            //drawingArea.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = "";
            foreach(Point2D point in userInputPoints)
            {
                text += " " + point.ToString();
            }
            MessageBox.Show(text);
        }
    }
}
