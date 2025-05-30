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

namespace Dodge_Game
{
    public partial class HighScoresScreen : UserControl
    {
        public HighScoresScreen()
        {
            InitializeComponent();
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            MenuScreen menu = new MenuScreen();

            menu.Size = this.FindForm().Size;
            this.FindForm().Controls.Add(menu);
            this.FindForm().Controls.Remove(this);
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

            XmlReader reader = XmlReader.Create("Resources/HighScoreData.xml");

            try
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        reader.ReadToFollowing("Easy");
                        labelScoreEasy.Text = $"EASY HIGH SCORE - {reader.ReadElementContentAsInt()}";

                        reader.ReadToFollowing("Normal");
                        labelScoreEasy.Text = $"NORMAL HIGH SCORE - {reader.ReadElementContentAsInt()}";

                        reader.ReadToFollowing("Hard");
                        labelScoreEasy.Text = $"HARD HIGH SCORE - {reader.ReadElementContentAsInt()}";

                        reader.ReadToFollowing("Insane");
                        labelScoreEasy.Text = $"INSANE HIGH SCORE - {reader.ReadElementContentAsInt()}";
                    }

                }
            }
            catch
            {

                reader.Close();

                XmlWriter writer = XmlWriter.Create("Resources/HighScoreData.xml", null);

                writer.WriteElementString("Easy", Convert.ToString(0));

                writer.WriteElementString("Normal", Convert.ToString(0));

                writer.WriteElementString("Hard", Convert.ToString(0));

                writer.WriteElementString("Insane", Convert.ToString(0));

                writer.Close();
            }


        }
    }
}
