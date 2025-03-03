using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodge_Game
{

    internal class Enemy
    {
        public static int Xvel, Yvel, Xacc, Yacc;
        public static RectangleF body;
        public static PointF lookVector;
        public Enemy(Point pos, int sz) 
        {
            body = new RectangleF();
            body.Location = pos;
            body.Width = sz;
            body.Height = sz;
        }
    }
}
