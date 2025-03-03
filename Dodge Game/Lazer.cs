using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace Dodge_Game
{
    internal class Lazer
    {
        public PointF point0, point1;
        public int lwidth, duration, warnTime;
        public bool IsWarning;
        public GraphicsPath body;
        Line line;

        public Lazer(PointF _point0, PointF _point1, int _width, int _duration, int _warntime) 
        {
            point0 = _point0;
            point1 = _point1;
            lwidth = _width;
            duration = _duration;
            warnTime = _warntime;
            body = new GraphicsPath();
            body.AddLine(point0.X, point0.Y, point1.X, point1.Y);
            
        }

        public int Update(RectangleF player, Form f)
        {
            if (warnTime > 0)
            {
                warnTime--;
                IsWarning = true;
            }
            else
            {
                duration--;
                IsWarning = false;
            }
            if(duration <= 0)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
