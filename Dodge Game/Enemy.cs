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

        public string type;

        public Color color;
        public int Xvel, Yvel;
        public int terminalVel = 15;

        public Enemy(PointF _pos, RectangleF _body, string _type) 
        {
            body = _body;

            type = _type;

            switch (type)
            {
                case "normal":
                    body.Width = 40;
                    body.Height = 40;
                    color = Color.Green;

                    break;

                case "armored":
                    body.Width = 30;
                    body.Height = 30;
                    color = Color.LightGray;

                    break;

                case "lazer":
                    body.Width = 40;
                    body.Height = 40;
                    color = Color.Orange;

                    break;

                case "gunner":
                    body.Width = 35;
                    body.Height = 35;
                    color = Color.Cyan;

                    break;

                default:
                    body.Width = 40;
                    body.Height = 40;
                    color = Color.Green;
                    break;
            }

            body.Location = _pos;
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
                if (type != "armored")
                {
                    return 1;
                }
                else
                {
                    return -1;
                }

            }

            return 0;
        }
    }
}
