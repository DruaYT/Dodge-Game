using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using System.Windows.Resources;
using System.Media;
using System.Resources;
using System.Reflection;
using System.Windows.Documents;

namespace Dodge_Game
{
    public partial class GameScreen : UserControl
    {
        List<Enemy> enemyList = new List<Enemy>();

        List<Ball> ballList = new List<Ball>();

        List<Lazer> lazers = new List<Lazer>();

        List<Particle> particles = new List<Particle>();

        RectangleF player;

        PointF mousePos;

        Random rand = new Random();
        

        bool heldUp, heldDown, heldLeft, heldRight, playerImmune, LeftMouseDown, CanPause, IsPaused;

        float playerVelX, playerVelY;

        int score, lives, currentCooldown, currentShootCooldown;
        int cooldownTickBase = 10, shootCooldownBase = 10*Form1.difficulty;

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            MenuScreen menu = new MenuScreen();

            menu.Size = this.FindForm().Size;
            ballList.Clear();
            enemyList.Clear();
            gameTimer.Stop();
            this.FindForm().Controls.Add(menu);
            this.FindForm().Controls.Remove(this);
        }

        private void buttonResume_Click(object sender, EventArgs e)
        {
            IsPaused = false;
            CanPause = true;

            buttonResume.Enabled = false;
            buttonResume.Visible = false;

            buttonMenu.Visible = false;
            buttonMenu.Enabled = false;

            return;
        }

        int playerTeminalVelocity = 10;

        public GameScreen()
        {
            InitializeComponent();
        }

        private void flashCheck()
        {

            if (this.BackColor.R != 0)
            {
                this.BackColor=Color.FromArgb(255, this.BackColor.R - 1, this.BackColor.G, this.BackColor.B);
            }

            if (this.BackColor.G != 0)
            {
                this.BackColor = Color.FromArgb(255, this.BackColor.R, this.BackColor.G - 1, this.BackColor.B);
            }

            if (this.BackColor.B != 0)
            {
                this.BackColor = Color.FromArgb(255, this.BackColor.R, this.BackColor.G, this.BackColor.B - 1);
            }
        }

        private void changeScore(int _change)
        {
            
            if (_change > 0)
            {
                score += _change;
                for (int i = 0; i < 1; i++)
                {
                    RectangleF r = new RectangleF();

                    r.X = rand.Next(20, this.Width - 20);
                    r.Y = rand.Next(20, this.Width - 20);
                    r.Width = 20;
                    r.Height = 20;
                    Enemy n = new Enemy(new PointF(r.X, r.Y), 20, r);
                    enemyList.Add(n);
                }

            }
            else
            {
                if(_change < 0)
                {
                    lives--;
                    this.BackColor = Color.Red;
                    SoundPlayer h = new SoundPlayer(Properties.Resources.sound_Hit);

                    h.PlaySync();
                    Refresh();
                }
            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            if (playerImmune == true)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), player);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), player);
            }

            PointF A = new PointF(player.X + (player.Width/2), player.Y + (player.Height/2));
            PointF B = new PointF(mousePos.X,mousePos.Y);

            e.Graphics.DrawLine(new Pen(Color.Blue, 1), A, B);

            foreach (Ball b in ballList)
            {
                if (b!= null)
                {
                    if(b.IsFriendly == true)
                    {
                        e.Graphics.FillEllipse(new SolidBrush(Color.Blue), b.body);
                    }
                    else
                    {
                        e.Graphics.FillEllipse(new SolidBrush(Color.Red), b.body);
                    }
                }
                
            }

            foreach (Enemy enemy in enemyList) 
            {
                if (enemy != null) 
                {
                    e.Graphics.FillEllipse(new SolidBrush(Color.Green), enemy.body);
                }  
            }

            foreach(Particle p in particles)
            {
                if(p != null && p.color.A <= 255)
                {
                    e.Graphics.FillEllipse(new SolidBrush(p.color), p.body);
                }
            }

            foreach (Lazer l in lazers)
            {
                if (l != null)
                {
                    if (l.IsWarning == true) 
                    {
                        e.Graphics.FillPath(new SolidBrush(Color.FromArgb(150, Color.Pink)), l.body);
                    }
                    else
                    {
                        e.Graphics.FillPath(new SolidBrush(Color.Red), l.body);
                    }
                }
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

                case Keys.Space:
                    if (currentCooldown <= 0 && IsPaused == false)
                    {
                        playerVelX *= 2;
                        playerVelY *= 2;
                        currentCooldown = cooldownTickBase;
                        SoundPlayer shoot = new SoundPlayer(Properties.Resources.sound_Dodge);
                        shoot.LoadTimeout = 1;
                        shoot.Play();
                    }
                    break;

                case Keys.P:
                    if (CanPause == true)
                    {
                        if (IsPaused == false) 
                        {
                            IsPaused = true;
                        }
                        else if (IsPaused == true)
                        {
                            IsPaused = false;
                        }
                        
                    }
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

                case Keys.Space:
                    currentCooldown--;
                break;

                case Keys.P:
                    CanPause = true;
                break;

            }

        }

        private void GameScreen_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    LeftMouseDown = true;
                    break;
            }

        }

        private void GameScreen_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    LeftMouseDown = false;
                    break;
            }

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (IsPaused == false)
            {
                flashCheck();
                mousePos.X = (Cursor.Position.X - this.FindForm().Location.X) * (this.FindForm().Width / this.FindForm().DesktopBounds.Width);
                mousePos.Y = (Cursor.Position.Y - this.FindForm().Location.Y) * (this.FindForm().Height / this.FindForm().DesktopBounds.Height);

                buttonMenu.Visible = false;

                buttonResume.Visible = false;

                pauseLabel.Visible = false;

                if (currentCooldown > 0)
                {
                    playerImmune = true;
                    currentCooldown--;
                    playerVelX--;
                    playerVelY--;
                    Particle p = new Particle(-playerVelX + rand.Next(-3, 3), -playerVelY + rand.Next(-3,3), (float)2, player.X + (player.Width / 2), player.Y + (player.Height / 2), 150, rand.Next(10, 20), Color.LightGray);
                    particles.Add(p);
                }
                else
                {
                    playerImmune = false;
                    currentCooldown = 0;
                }

                if (currentShootCooldown <= 0)
                {
                    if (LeftMouseDown == true)
                    {
                        this.BackColor = Color.FromArgb(255, 100, 50, 50);
                        SoundPlayer shoot = new SoundPlayer(Properties.Resources.sound_Shoot);

                        shoot.LoadTimeout = 1;
                        shoot.Play();

                        currentShootCooldown = shootCooldownBase;
                        RectangleF b = new RectangleF
                        {
                            Size = new SizeF(player.Width / Form1.difficulty, player.Height / Form1.difficulty),
                            Location = new PointF(player.X + player.Width / 2, player.Y + player.Height / 2)
                        };

                        playerVelX += ((player.X + (player.Width / 2)) - mousePos.X) / 10;
                        playerVelY += ((player.Y + (player.Height / 2)) - mousePos.Y) / 10;
                        Ball ball = new Ball(-(player.X + (player.Width / 2)) + mousePos.X, -(player.Y + (player.Height / 2)) + mousePos.Y, b, true);

                        ballList.Add(ball);
                    }
                }
                else
                {
                    currentShootCooldown--;
                }

                if (lives < 0)
                {
                    GameOverScreen menu = new GameOverScreen();

                    menu.Size = this.FindForm().Size;
                    ballList.Clear();
                    enemyList.Clear();
                    gameTimer.Stop();
                    menu.setScore(score);
                    this.FindForm().Controls.Add(menu);
                    this.FindForm().Controls.Remove(this);

                    Refresh();

                    return;
                }

                labelStats.Text = $"LIVES: {lives} - SCORE: {score}\n\r [SPACE] To Dodge / Parry!\n\r [LMB] To Shoot!";

                if (heldUp == true && playerVelY - 1 > -playerTeminalVelocity)
                {
                    playerVelY--;
                }

                if (heldDown == true && playerVelY + 1 < playerTeminalVelocity)
                {
                    playerVelY++;
                }

                if (heldLeft == true && playerVelX - 1 > -playerTeminalVelocity)
                {
                    playerVelX--;
                }

                if (heldRight == true && playerVelX + 1 < playerTeminalVelocity)
                {
                    playerVelX++;
                }

                player.Y += playerVelY;
                player.X += playerVelX;

                if (player.X > this.Width)
                {
                    player.X = this.Width - 5;
                    playerVelX = -playerVelX / 2;
                }

                if (player.X < 0)
                {
                    player.X = 0;
                    playerVelX = -playerVelX / 2;
                }

                if (player.Y > this.Height)
                {
                    player.Y = this.Height - 5;
                    playerVelY = -playerVelY / 2;
                }

                if (player.Y < 0)
                {
                    player.Y = 0;
                    playerVelY = -playerVelY / 2;
                }

                if (heldLeft != true && heldRight != true)
                {
                    playerVelX /= (float)1.5;
                }

                if (heldUp != true && heldDown != true)
                {
                    playerVelY /= (float)1.5;
                }

                foreach (Enemy en in enemyList)
                {
                    int change = en.Update(player, this.FindForm());
                    if (change != 0)
                    {
                        changeScore(change);
                        enemyList.Remove(en);
                        Refresh();
                        return;
                    }
                    else
                    {
                        foreach (Ball b in ballList)
                        {
                            if (b.IsFriendly == true && en.body.IntersectsWith(b.body))
                            {
                                changeScore(1);
                                ballList.Remove(b);
                                enemyList.Remove(en);
                                Refresh();
                                return;
                            }
                        }

                        if (rand.Next(0, 100) <= Form1.difficulty * 15 && rand.Next(0, 100) % 6 == 1)
                        {
                            float LaunchX = (player.X - en.body.X) * Form1.difficulty;
                            float LaunchY = (player.Y - en.body.Y) * Form1.difficulty;

                            if (Form1.difficulty > 2)
                            {
                                PointF p0 = new PointF(LaunchX * 100, LaunchY * 100);
                                PointF p1 = new PointF(-LaunchX * 100, -LaunchY * 100);

                                Lazer l = new Lazer(p0, p1, rand.Next(5, 30), 20 * Form1.difficulty, 25 / Form1.difficulty);
                                lazers.Add(l);
                            }

                            RectangleF b = new RectangleF
                            {
                                Size = new Size(5 * Form1.difficulty, 5 * Form1.difficulty),
                                Location = new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2)
                            };

                            Ball ball = new Ball(LaunchX, LaunchY, b, false);

                            ballList.Add(ball);
                        }

                    }
                }

                foreach (Ball b in ballList)
                {
                    int change = b.Update(player, this.FindForm());
                    if (change != 0)
                    {
                        if (change != 2 && playerImmune != true)
                        {
                            changeScore(change);

                            ballList.Remove(b);
                            Refresh();
                            return;
                        }
                        else
                        {
                            if (change != 2 && playerImmune == true)
                            {
                                this.BackColor = Color.FromArgb(255, 100, 100, 100);
                                SoundPlayer parry = new SoundPlayer(Properties.Resources.sound_Parry);
                                parry.Load();
                                parry.Play();
                                b.IsFriendly = true;
                                b.isHit = false;
                                b.velX = -b.velX;
                                b.velY = -b.velY;
                            }
                            else
                            {
                                ballList.Remove(b);
                                Refresh();
                                return;
                            }

                        }

                    }
                }

                foreach(Particle p in particles)
                {
                    p.Render();

                    if (p.color.A <= 0)
                    {
                        particles.Remove(p);
                        break;
                    }
                }

                Refresh();
            }
            else
            {
                buttonResume.Enabled = true;
                buttonResume.Visible = true;
                buttonResume.Width = this.Width / 5;
                buttonResume.Location = new Point((this.Width / 2) - (buttonResume.Width / 2), (this.Height / 2) - (buttonResume.Height / 2));

                buttonMenu.Enabled = true;
                buttonMenu.Visible = true;
                buttonMenu.Width = this.Width / 5;
                buttonMenu.Location = new Point(buttonResume.Location.X, buttonResume.Location.Y + (int)(buttonResume.Height * 1.1));

                pauseLabel.Visible = true;
                pauseLabel.Location = new Point(buttonResume.Location.X + (pauseLabel.Width/2), buttonResume.Location.Y - (int)(buttonResume.Height * 1.1));
            }
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            player = new RectangleF();

            CanPause = true;

            IsPaused = false;

            buttonResume.Enabled = false;
            buttonResume.Visible = false;

            buttonMenu.Enabled = false;
            buttonMenu.Visible = false;

            pauseLabel.Visible = false;

            player.Size = new Size(15,15);
            player.Location = new Point((this.Width/2) - 5, (this.Height/2) - 5);
            playerVelX = 0;
            playerVelY = 0;
            score = -1;
            lives = 3;
            labelStats.Location = new Point((this.Width / 2)-(labelStats.Width/2), labelStats.Height);

            gameTimer.Enabled = true;

            changeScore(1);
        }
    }
}
