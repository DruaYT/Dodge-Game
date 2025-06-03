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
    public partial class MenuScreen : UserControl
    {
        Form f;

        public MenuScreen()
        {
            InitializeComponent();
        }

        private void startGame()
        {
            GameScreen game = new GameScreen();

            game.Size = f.Size;
            f.Controls.Add(game);
            f.Controls.Remove(this);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void cropComponents()
        {
            f = this.FindForm();

            this.Width = f.Width;
            this.Height = f.Height;
            labelTitle.Location = new Point((f.Width / 2) - (labelTitle.Width / 2), 0 + (f.Height / 8));
            buttonEasy.Location = new Point((f.Width / 2) - (buttonEasy.Width / 2), (f.Height / 4));
            buttonNormal.Location = new Point(buttonEasy.Location.X, buttonEasy.Location.Y + (int)(buttonEasy.Height * 1.2));
            buttonHard.Location = new Point(buttonNormal.Location.X, buttonNormal.Location.Y + (int)(buttonNormal.Height * 1.2));
            buttonInsane.Location = new Point(buttonHard.Location.X, buttonHard.Location.Y + (int)(buttonHard.Height * 1.2));
            buttonExit.Location = new Point(f.Width - buttonExit.Width - 10, f.Height - buttonExit.Height - 10);
            buttonFullScreen.Location = new Point(buttonExit.Location.X, buttonExit.Location.Y - (int)(buttonFullScreen.Height * 1.2));
            buttonHighScores.Location = new Point(buttonFullScreen.Location.X, buttonFullScreen.Location.Y - (int)(buttonFullScreen.Height * 1.2));
            buttonInfiniteMode.Location = new Point(buttonFullScreen.Location.X, buttonHighScores.Location.Y - (int)(buttonInfiniteMode.Height * 1.2));

            if (Form1.InfiniteMode == false)
            {
                buttonInfiniteMode.ForeColor = Color.Green;
                buttonInfiniteMode.Text = "NORMAL";
            }
            else
            {
                buttonInfiniteMode.ForeColor = Color.IndianRed;
                buttonInfiniteMode.Text = "FREEPLAY";
            }
        }

        private void MenuScreen_Load(object sender, EventArgs e)
        {
            cropComponents();
        }

        private void buttonEasy_Click(object sender, EventArgs e)
        {
            Form1.difficulty = 1;
            startGame();
        }

        private void buttonNormal_Click(object sender, EventArgs e)
        {
            Form1.difficulty = 2;
            startGame();
        }

        private void buttonHard_Click(object sender, EventArgs e)
        {
            Form1.difficulty = 3;
            startGame();
        }

        private void buttonInsane_Click(object sender, EventArgs e)
        {
            Form1.difficulty = 4;
            startGame();
        }

        private void buttonFullScreen_Click(object sender, EventArgs e)
        {
            if (this.FindForm().WindowState == FormWindowState.Maximized)
            {
                this.FindForm().WindowState = FormWindowState.Normal;
                buttonFullScreen.Text = "FULLSCREEN";
            }
            else
            {
                this.FindForm().WindowState = FormWindowState.Maximized;
                buttonFullScreen.Text = "WINDOWED";
            }

            cropComponents();
            Refresh();
        }

        private void buttonHighScores_Click(object sender, EventArgs e)
        {
            HighScoresScreen h = new HighScoresScreen();
            h.Size = this.FindForm().Size;
            this.FindForm().Controls.Add(h);
            this.FindForm().Controls.Remove(this);
        }

        private void buttonInfiniteMode_Click(object sender, EventArgs e)
        {
            if (Form1.InfiniteMode == true)
            {
                buttonInfiniteMode.ForeColor = Color.Green;
                buttonInfiniteMode.Text = "NORMAL";
                Form1.InfiniteMode = false;
            }
            else
            {
                buttonInfiniteMode.ForeColor = Color.IndianRed;
                buttonInfiniteMode.Text = "FREEPLAY";
                Form1.InfiniteMode = true;
            }
        }
    }
}
