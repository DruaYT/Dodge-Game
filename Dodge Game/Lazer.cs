using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Shapes;
using System.Collections.Generic;
using System;

namespace Dodge_Game
{
    internal class Lazer
    {
        public PointF point0, point1;
        public int lwidth, duration, totalduration, warnTime;
        public bool IsWarning;
        public Line body;
        Line line;

        public List<RectangleF> hitboxes = new List<RectangleF>();

        public Lazer(PointF _point0, PointF _point1, int _width, int _duration, int _warntime) 
        {
            point0 = _point0;
            point1 = _point1;
            lwidth = _width;
            duration = _duration;
            warnTime = _warntime;

            totalduration = duration;

            body = new Line();

            body.X1 = point0.X;
            body.Y1 = point0.Y;

            body.X2 = point1.X;
            body.Y2 = point1.Y;

            int segs = (int)Math.Sqrt(Math.Pow(point1.X - point0.X, 2) + Math.Pow(point1.Y - point0.Y, 2));

            for (int i = 0; i < segs/_width; i++)
            {
                RectangleF hit = new RectangleF();

                hit.Location = new PointF(point0.X + (point1.X/(i*_width)), point0.Y + (point1.Y / (i * _width)));

                hit.Width = _width;
                hit.Height = _width;

                hitboxes.Add(hit);
                
            }

        }

    }
}
