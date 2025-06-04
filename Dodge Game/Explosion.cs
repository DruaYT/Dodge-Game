using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge_Game
{
    internal class Explosion
    {
        public RectangleF body;

        public PointF pos;

        public float radius;

        public Explosion(PointF position,  float _radius)
        {
            radius = _radius;

            pos = position;

            body = new RectangleF();
            body.Width = radius;
            body.Height = radius;
            body.Location = new PointF(position.X - radius/2, position.Y - radius/2);

        }

        public int Update(RectangleF player, Form f)
        {

            if (radius <= 0)
            {
                return 1;
            }
            else
            {
                radius--;

                body.Width = radius;
                body.Height = radius;

                body.Location = new PointF(pos.X - radius / 2, pos.Y - radius / 2);

                if (body.IntersectsWith(player))
                {
                    return -1;
                }
                else
                {
                    return 0;
                }

            }
        }
    }
}
