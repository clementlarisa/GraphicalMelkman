using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeometricalGraphicEngine
{
    class Melkman
    {
        List<Point2D> Points;
      
        public Melkman(List<Point2D>points)
        {
            Points = new List<Point2D>(points);
        }
        public float isLeft(Point2D P0, Point2D P1, Point2D P2)
        {
            return (P1.X - P0.X) * (P2.Y - P0.Y) - (P2.X - P0.X) * (P1.Y - P0.Y);
        }
        public List<Point2D> ConvexHull()
        {
            List<Point2D> Dequeue = new List<Point2D>();
            if (Points.Count < 3) return new List<Point2D>(Points);
            if (isLeft(Points[0], Points[1], Points[2]) > 0)
            {
                //this means right
                Dequeue.Add(Points[0]);
                Dequeue.Add(Points[1]);
            }
            else
            {
                //left
                Dequeue.Add(Points[1]);
                Dequeue.Add(Points[0]);
            }
            Dequeue.Add(Points[2]);
            Dequeue.Insert(0, Points[2]);
            if (Points.Count == 3) return new List<Point2D>(Points);
            for(int i = 3; i< Points.Count; i++)
            {
                int s = Dequeue.Count;
                while (isLeft(Points[i], Dequeue[0], Dequeue[1]) > 0 && isLeft(Dequeue[s - 2], Dequeue[s - 1], Points[i]) > 0)
                {
                    i++;
                    if (i > Points.Count - 1) return Dequeue;
                }
                while (isLeft(Dequeue[s - 2], Dequeue[s - 1], Points[i]) <= 0)
                {
                    Dequeue.RemoveAt(Dequeue.Count - 1);
                    s = Dequeue.Count;
                }
                Dequeue.Add(Points[i]);
                while (isLeft(Points[i], Dequeue[0], Dequeue[1]) <= 0)
                {
                    Dequeue.RemoveAt(0);
                }
                Dequeue.Insert(0, Points[i]);
            }
            return Dequeue;
        }
    }
}
