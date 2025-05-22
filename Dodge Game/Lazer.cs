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
        public int lwidth, defaultwidth, duration, totalduration, warnTime;
        public bool IsWarning, IsFriendly;
        public Line body;
        Line line;

        public List<RectangleF> hitboxes = new List<RectangleF>();

        public Lazer(PointF _point0, PointF _point1, int _width, int _duration, int _warntime, bool _friendly) 
        {
            point0 = _point0;
            point1 = _point1;
            lwidth = _width;
            defaultwidth = _width;
            duration = _duration;
            warnTime = _warntime;
            IsFriendly = _friendly;

            totalduration = duration;

            body = new Line();

            body.X1 = point0.X;
            body.Y1 = point0.Y;

            body.X2 = point1.X;
            body.Y2 = point1.Y;

            int segs = (int)Math.Sqrt(Math.Pow(point1.X - point0.X, 2) + Math.Pow(point1.Y - point0.Y, 2));

            for (int i = 0; i < (segs / (lwidth)); i++)
            {
                if (i % lwidth == 0)
                {
                    RectangleF hit = new RectangleF();

                    hit.Location = new PointF(point0.X + (point1.X / i), point0.Y + (point1.Y / i));

                    hit.Width = lwidth;
                    hit.Height = lwidth;

                    hitboxes.Add(hit);
                }


            }

        }

        public void Update()
        {
            lwidth = (int)(lwidth/1.2);
        }

    }
}
