using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge_Game
{
    public partial class GameScreen : UserControl
    {
        List<Enemy> enemyList = new List<Enemy>();
        Rectangle player;
        bool heldUp, heldDown, heldLeft, heldRight;
        int score, lives, playerAccelX, playerAccelY, playerVelX, playerVelY;

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.White), player);
            foreach (Enemy enemy in enemyList) 
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.White),enemy.);
            }
        }

        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    heldUp = true;
                    break;
                case Keys.S:
                    heldDown = true;
                    break;
                case Keys.A:
                    heldLeft = true;
                    break;
                case Keys.D:
                    heldRight = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    heldUp = false;
                    break;
                case Keys.S:
                    heldDown = false;
                    break;
                case Keys.A:
                    heldLeft = false;
                    break;
                case Keys.D:
                    heldRight = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (heldUp == true)
            {
                playerAccelY--;
            }
            if (heldDown == true)
            {
                playerAccelY++;
            }
            if (heldLeft == true)
            {
                playerAccelX--;
            }
            if (heldRight == true)
            {
                playerAccelX++;
            }
            playerVelX += playerAccelX;
            playerVelY += playerAccelY;

            player.Y += playerVelY;
            player.X += playerVelX;

            if (player.X > this.Width)
            {
                player.X = this.Width - 5;
                playerVelX = -playerVelX/2;
                playerAccelX = 0;
            }
            if (player.X < 0)
            {
                player.X = 0;
                playerVelX = -playerVelX/2;
                playerAccelX = 0;
            }
            if (player.Y > this.Height)
            {
                player.Y = this.Height - 5;
                playerVelY = -playerVelY/2;
                playerAccelY = 0;
            }
            if (player.Y < 0)
            {
                player.Y = 0;
                playerVelY = -playerVelY/2;
                playerAccelY = 0;
            }

            playerVelX /= 2;
            playerVelY /= 2;
            if (heldRight != true && heldLeft != true && heldUp != true && heldDown != true)
            {
                playerAccelX /= 2;
                playerAccelY /= 2;
            }
            

            Refresh();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            player = new Rectangle();
            player.Size = new Size(5,5);
            player.Location = new Point((this.Width/2) - 5, (this.Height/2) - 5);
            playerAccelX = 0;
            playerVelX = 0;
            playerAccelY = 0;
            playerVelY = 0;
        }
    }
}
