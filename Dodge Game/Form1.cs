using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Dodge_Game
{
    public partial class Form1 : Form
    {
        public static int difficulty;

        public static int highScoreEasy;

        public static int highScoreNormal;

        public static int highScoreHard;

        public static int highScoreInsane;

        public static bool InfiniteMode = false;

        string pdXml = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/HighScoreData.xml");

        public Form1()
        {
            InitializeComponent();

            MenuScreen menu = new MenuScreen();
            menu.Size = this.Size;
            this.Controls.Add(menu);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            XDocument doc = XDocument.Load(pdXml);

            XmlReader reader = XmlReader.Create(pdXml);

            //reader.ReadStartElement();

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    reader.ReadToFollowing("easyscore");

                    highScoreEasy = Convert.ToInt16(reader.ReadElementContentAsInt());

                    reader.ReadToFollowing("normalscore");

                    highScoreNormal = Convert.ToInt16(reader.ReadElementContentAsInt());

                    reader.ReadToFollowing("hardscore");

                    highScoreHard = Convert.ToInt16(reader.ReadElementContentAsInt());

                    reader.ReadToFollowing("insanescore");

                    highScoreInsane = Convert.ToInt16(reader.ReadElementContentAsInt());
                }
            }

            reader.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            XDocument doc = XDocument.Load(pdXml);

            XElement scores = doc.Element("TopScores");

            scores.Element("easyscore").SetValue(highScoreEasy);

            scores.Element("normalscore").SetValue(highScoreNormal);

            scores.Element("hardscore").SetValue(highScoreHard);

            scores.Element("insanescore").SetValue(highScoreInsane);

            doc.Save(pdXml);

        }
    }
}
