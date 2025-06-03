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
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
        }

        public void setScore(int score)
        {
            labelScore.Text = $"FINAL SCORE: {score}";
            if (score < 10)
            {
                labelTitle.Text = "SKILL ISSUE!";
            }
            else
            {
                labelTitle.Text = "GAME OVER";
            }

            switch (Form1.difficulty)
            {
                case 1:
                    if (score > Form1.highScoreEasy)
                    {
                        Form1.highScoreEasy = score;
                    }
                    break;

                case 2:
                    if (score > Form1.highScoreNormal)
                    {
                        Form1.highScoreNormal = score;
                    }
                    break;

                case 3:
                    if (score > Form1.highScoreHard)
                    {
                        Form1.highScoreHard = score;
                    }
                    break;

                case 4:
                    if (score > Form1.highScoreInsane)
                    {
                        Form1.highScoreInsane = score;
                    }
                    break;
            }

        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            MenuScreen menu = new MenuScreen();

            menu.Size = this.FindForm().Size;
            this.FindForm().Controls.Add(menu);
            this.FindForm().Controls.Remove(this);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            buttonMenu.Location = new Point((this.FindForm().Width / 2) - buttonMenu.Width / 2, (this.FindForm().Height / 2) - buttonMenu.Height / 2);
            buttonExit.Location = new Point(buttonMenu.Location.X, buttonMenu.Location.Y + (int)(buttonExit.Height * 1.2));
            labelTitle.Location = new Point((this.FindForm().Width / 2) - labelTitle.Width / 2, 40);
            labelScore.Location = new Point(labelTitle.Location.X, labelTitle.Location.Y + labelScore.Height + labelTitle.Height);
        }
    }
}
