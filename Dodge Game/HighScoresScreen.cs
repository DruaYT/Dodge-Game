using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Dodge_Game
{
    public partial class HighScoresScreen : UserControl
    {
        public HighScoresScreen()
        {
            InitializeComponent();
        }

        private void ToMenu()
        {
            MenuScreen menu = new MenuScreen();

            menu.Size = this.FindForm().Size;
            this.FindForm().Controls.Add(menu);
            this.FindForm().Controls.Remove(this);
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            ToMenu();
        }

        private void HighScoresScreen_Load(object sender, EventArgs e)
        {

            Form f = this.FindForm();

            this.Width = f.Width;
            this.Height = f.Height;

            labelTitle.Location = new Point((f.Width / 2) - (labelTitle.Width / 2), 10);
            labelScoreEasy.Location = new Point((f.Width / 2) - (labelScoreEasy.Width / 2), f.Height / 3);
            labelScoreNormal.Location = new Point((f.Width / 2) - (labelScoreEasy.Width / 2), labelScoreEasy.Location.Y + (int)(labelScoreEasy.Height * 1.2));
            labelScoreHard.Location = new Point((f.Width / 2) - (labelScoreEasy.Width / 2), labelScoreNormal.Location.Y + (int)(labelScoreNormal.Height * 1.2));
            labelScoreInsane.Location = new Point((f.Width / 2) - (labelScoreEasy.Width / 2), labelScoreHard.Location.Y + (int)(labelScoreHard.Height * 1.2));
            buttonMenu.Location = new Point( (f.Width / 2) - (buttonMenu.Width / 2), f.Height - (f.Height / 3));
            buttonDataErase.Location = new Point(buttonMenu.Location.X, (int)(buttonMenu.Location.Y - (buttonMenu.Height * 1.1)));

            labelScoreEasy.Text = $"EASY HIGH SCORE - {Form1.highScoreEasy}";
            labelScoreNormal.Text = $"NORMAL HIGH SCORE - {Form1.highScoreNormal}";
            labelScoreHard.Text = $"HARD HIGH SCORE - {Form1.highScoreHard}";
            labelScoreInsane.Text = $"INSANE HIGH SCORE - {Form1.highScoreInsane}";


        }

        private void buttonDataErase_Click(object sender, EventArgs e)
        {
            Form1.highScoreEasy = 0;
            Form1.highScoreNormal = 0;
            Form1.highScoreHard = 0;
            Form1.highScoreInsane = 0;

            ToMenu();
        }
    }
}
