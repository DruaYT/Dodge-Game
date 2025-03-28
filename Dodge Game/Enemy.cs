using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge_Game
{

    internal class Enemy
    {
        public RectangleF body;

        public int Xvel, Yvel;
        public int terminalVel = 15;

        public Enemy(PointF _pos, int _sz, RectangleF _body) 
        {
            body = _body;
            body.Location = _pos;
            body.Width = _sz;
            body.Height = _sz;
        }

        public int Update(RectangleF player, Form f)
        {
            body.Y += Yvel;
            body.X += Xvel;
            PointF diff = new PointF(body.X - player.X, body.Y - player.Y);

            if (player.X + diff.X/2 > body.X && Xvel+1 < terminalVel)
            {
                Xvel++;
            }
            else
            {
                if (player.X + diff.X/2 < body.X && Xvel - 1 > -terminalVel)
                {
                    Xvel--;
                }
            }

            if (player.Y + diff.Y/2 > body.Y && Yvel + 1 < terminalVel)
            {
                Yvel++;
            }
            else
            {
                if (player.Y + diff.Y/2 < body.Y && Yvel - 1 > -terminalVel)
                {
                    Yvel--;
                }
            }

            if(body.X > f.Width - body.Width) 
            {
                body.X = f.Width - body.Width;
                Xvel /= -2;
            }

            if (body.X < 0)
            {
                body.X = 0;
                Xvel /= -2;
            }

            if (body.Y > f.Height - body.Height)
            {
                body.Y = f.Height - body.Height;
                Yvel /= -2;
            }

            if (body.Y < 0)
            {
                body.Y = 0;
                Yvel /= -2;
            }

            if (player.IntersectsWith(body))
        {
                return 1;
            }

            return 0;
        }
    }
}
