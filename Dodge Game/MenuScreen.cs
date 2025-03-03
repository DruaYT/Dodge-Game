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

        private void MenuScreen_Load(object sender, EventArgs e)
        {
            f = this.FindForm();
            labelTitle.Location = new Point((f.Width / 2) - (labelTitle.Width/2),0 +(f.Height/8));
            buttonEasy.Location = new Point((f.Width / 2) - (buttonEasy.Width / 2), (f.Height / 4));
            buttonNormal.Location = new Point(buttonEasy.Location.X, buttonEasy.Location.Y + (int)(buttonEasy.Height * 1.2));
            buttonHard.Location = new Point(buttonNormal.Location.X, buttonNormal.Location.Y + (int)(buttonNormal.Height * 1.2));
            buttonInsane.Location = new Point(buttonHard.Location.X, buttonHard.Location.Y + (int)(buttonHard.Height * 1.2));
            buttonExit.Location = new Point(f.Width - buttonExit.Width - 10, f.Height - buttonExit.Height - 10);
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
    }
}
