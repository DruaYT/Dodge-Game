using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dodge_Game
{
    internal class PowerUp
    {
        public RectangleF body;

        public PointF pos;

        public String type;

        public Color color;

        public PowerUp(PointF _pos, String _type)
        {
            pos = _pos;

            type = _type;

            body = new RectangleF();

            body.Location = pos;
            body.Size = new Size(20, 20);

            switch (type)
            {
                case "heal":
                    color = Color.Green;

                    break;

                case "shotgun":
                    color = Color.Brown;

                    break;

                case "lazer":
                    color = Color.OrangeRed;

                    break;

                case "gunner":
                    color = Color.Teal;

                    break;
            }
        }

        public Boolean CheckForGathered(RectangleF player)
        {
            if (body.IntersectsWith(player))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
