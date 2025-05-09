using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge_Game
{
    internal class Particle
    {
        public RectangleF body;

        public float velX, velY, drag, size;

        public Color color;

        public Particle(float _velX, float _velY, float _drag, float x, float y, float _trans, float _size, Color _color)
        {
            this.velX = _velX;
            this.velY = _velY;
            this.size = _size;
            this.drag = _drag;
            this.color = Color.FromArgb((int)_trans, _color);

            this.body = new RectangleF(new PointF(x, y), new SizeF(size, size));
        }

        public void Render()
        {
            color = Color.FromArgb(color.A - 15, color.R, color.G, color.B);

            body.X += velX;
            body.Y += velY;

            velX = velX / drag;
            velY = velY / drag;

        }
    }
}
