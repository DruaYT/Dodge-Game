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
        public int terminalVel = 15;
        public int health, speed, Xvel, Yvel;

        public Enemy(PointF _pos, RectangleF _body, string _type) 
        {
            body = _body;

            type = _type;


            switch (type)
            {
                case "normal":
                    body.Width = 40;
                    body.Height = 40;
                    health = 1;
                    speed = 1;
                    color = Color.Green;

                    break;

                case "armored":
                    body.Width = 60;
                    body.Height = 60;
                    health = 5;
                    speed = 1;
                    color = Color.LightGray;

                    break;

                case "gatlinggunner":
                    body.Width = 70;
                    body.Height = 70;
                    health = 10;
                    speed = 1;
                    color = Color.Purple;

                    break;

                case "lazer":
                    body.Width = 40;
                    body.Height = 40;
                    health = 3;
                    speed = 2;
                    color = Color.Orange;

                    break;

                case "gunner":
                    body.Width = 35;
                    body.Height = 35;
                    health = 2;
                    speed = 2;
                    color = Color.Cyan;

                    break;

                case "buckshot":
                    speed = 1;

                    body.Width = 35;
                    body.Height = 35;
                    health = 3;
                    color = Color.SandyBrown;

                    break;

                case "deflector":
                    speed = 2;

                    body.Width = 45;
                    body.Height = 45;
                    health = 5;
                    color = Color.Yellow;

                    break;

                default:
                    speed = 1;
                    body.Width = 40;
                    body.Height = 40;
                    health = 1;
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

            if (player.X + diff.X / 2 > body.X && Math.Abs(Xvel + speed) <= terminalVel)
            {
                Xvel += speed;
            }
            else if(player.X + diff.X / 2 < body.X && Math.Abs(Xvel - speed) <= terminalVel)
            {

                Xvel -= speed;

            }

            if (player.Y + diff.Y / 2 > body.Y + speed && Math.Abs(Yvel + speed) <= terminalVel)
            {
                Yvel += speed;
            }
            else if (player.Y + diff.Y / 2 < body.Y - speed && Math.Abs(Yvel - speed) <= terminalVel)
            {
                
                Yvel -= speed;

            }

            if (player.IntersectsWith(body))
            {

                health--;

                if (type != "armored" && type != "gatlinggunner")
                {
                   if (health <= 0)
                    {
                        return 1;
                    }
                    
                }
                else
                {
                    if (health <= 0)
                    {
                        if (type == "lazer" || type == "gunner")
                        {
                            return 2;
                        }
                        else
                        {
                            return 1;
                        }

                    }
                    else
                    {
                        return -1;
                    }
                }

            }

            return 0;
        }
    }
}
