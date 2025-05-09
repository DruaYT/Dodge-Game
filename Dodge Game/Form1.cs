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
    public partial class Form1 : Form
    {
        public static int difficulty;

        public Form1()
        {
            InitializeComponent();

            MenuScreen menu = new MenuScreen();
            menu.Size = this.Size;
            this.Controls.Add(menu);
        }

    }
}
