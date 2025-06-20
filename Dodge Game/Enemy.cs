﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Dodge_Game
{

    internal class Enemy
    {
        public RectangleF body;

        public string type;

        public Color color;
        public bool armored = false;
        public int terminalVel = 15;
        public int health, totalHealth, speed, Xvel, Yvel;

        public Enemy(PointF _pos, RectangleF _body, string _type) 
        {
            body = _body;

            type = _type;

            //
            // Set properties based on enemy type
            //
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
                    armored = true;

                    break;

                case "gatlinggunner":
                    body.Width = 70;
                    body.Height = 70;
                    health = 15;
                    speed = 1;
                    color = Color.Purple;
                    armored = true;

                    break;

                case "incinerator":
                    body.Width = 65;
                    body.Height = 65;
                    health = 15;
                    speed = 2;
                    color = Color.Purple;
                    armored = true;

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
                    armored = true;

                    break;

                case "rocketeer":
                    speed = 2;

                    body.Width = 50;
                    body.Height = 50;
                    health = 10;
                    color = Color.Lime;
                    break;

                case "fragmenter":
                    speed = 1;

                    body.Width = 50;
                    body.Height = 50;
                    health = 5;
                    color = Color.Pink;

                    break;

                case "gatlinglaser":
                    speed = 1;

                    body.Width = 70;
                    body.Height = 70;
                    health = 15;
                    color = Color.Purple;
                    armored = true;
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
            totalHealth = health;
        }

        public void Damage()
        {
            if (health > 0)
            {
                health -= 1;
            }
        }

        public int Update(RectangleF player, Form f, List<Explosion> explosions)
        {
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

            foreach (Explosion exp in explosions)
            {
                if (exp != null && body.IntersectsWith(exp.body))
                {

                    health -= 3;

                    Xvel = (int)(10 * (exp.pos.X - body.X));
                    Yvel = (int)(10 * (exp.pos.Y - body.Y));

                    body.X += exp.pos.X - body.X;
                    body.Y += exp.pos.Y - body.Y;

                    if (health <= 0)
                    {
                        return 1;
                    }

                }
            }

            if (player.IntersectsWith(body))
            {

                if (armored == false)
                {
                    health--;

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
