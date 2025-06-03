using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge_Game
{
    internal class Rocket
    {
        public RectangleF body;

        public float velX, velY;

        public bool isHit = false, IsFriendly;

        public Rocket(float _velX, float _velY, RectangleF _body, bool _IsFriendly)
        {
            velX = _velX / 50;
            velY = _velY / 50;
            body = _body;
            IsFriendly = _IsFriendly;
        }

        private bool CheckForHit()
        {
            if (isHit == false)
            {
                isHit = true;
            }
            else
            {
                isHit = false;
                return true;
            }

            return false;
        }

        public bool Update(RectangleF player, Form f)
        {
            bool h = false;
            if (body.X > f.Width - body.Width)
            {
                h = CheckForHit();

                body.X = f.Width - 10;
                velX = -velX;
            }

            if (body.X < 0)
            {
                h = CheckForHit();

                body.X = 0;
                velX = -velX;
            }

            if (body.Y > f.Height - body.Height)
            {
                h = CheckForHit();

                body.Y = f.Height - 10;
                velY = -velY;
            }

            if (body.Y < 0)
            {
                h = CheckForHit();

                body.Y = 0;
                velY = -velY;
            }

            body.Y += velY;
            body.X += velX;

            if (player.IntersectsWith(body) && IsFriendly == false)
            {
                return true;
            }

            return CheckForHit();
        }

    }
}
