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

            if (player.X + diff.X / 2 > body.X && Xvel + 1 < terminalVel)
            {
                Xvel++;
            }
            else
            {
                if (player.X + diff.X / 2 < body.X && Xvel - 1 > -terminalVel)
                {
                    Xvel--;
                }
            }

            if (player.Y + diff.Y / 2 > body.Y && Yvel + 1 < terminalVel)
            {
                Yvel++;
            }
            else
            {
                if (player.Y + diff.Y / 2 < body.Y && Yvel - 1 > -terminalVel)
                {
                    Yvel--;
                }
            }

            if (player.IntersectsWith(body))
            {
                return 1;
            }

            return 0;
        }
    }
}
