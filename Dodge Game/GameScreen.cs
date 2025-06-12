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
using System.IO;
using System.Resources;
using System.Reflection;
using System.Windows.Documents;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Security.Policy;
using System.Net.Security;

namespace Dodge_Game
{
    public partial class GameScreen : UserControl
    {
        List<Enemy> enemyList = new List<Enemy>();

        List<Ball> ballList = new List<Ball>();

        List<Lazer> lazers = new List<Lazer>();

        List<Rocket> rockets = new List<Rocket>();

        List<Explosion> explosions = new List<Explosion>();

        List<Particle> particles = new List<Particle>();

        List<PowerUp> powerUps = new List<PowerUp>();

        List<object> dispose = new List<object>();

        RectangleF player;

        PointF mousePos;

        Random rand = new Random();

        readonly bool Debug = false;

        bool heldUp, heldDown, heldLeft, heldRight, playerImmune, LeftMouseDown, CanPause, IsPaused;

        float playerVelX, playerVelY, bulletSpeed;

        int score, lives, currentCooldown, currentShootCooldown, tick, powerUpTimer;

        int cooldownTickBase = 10, shootCooldownBase = 10*Form1.difficulty;

        string powerUp = "None";

        private void PlaySound(string fileName)
        {
            var sound = new System.Windows.Media.MediaPlayer();
            sound.Open(new Uri(Application.StartupPath + $"/Resources/{fileName}"));
            sound.Play();
        }

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

        public SizeF SizeRatio(float sizeX, float sizeY)
        {
            return new SizeF(this.Width*(sizeX/1920), this.Height*(sizeY/1080));
        }

        public PointF TranslateRatio(float moveX, float moveY)
        {
            return new PointF(this.Width * (moveX / 1920), this.Height * (moveY / 1080));
        }

        public GameScreen()
        {
            InitializeComponent();
        }

        private void flashCheck()
        {

            if (this.BackColor.R != 0)
            {
                this.BackColor=Color.FromArgb(255, (int)(this.BackColor.R / 1.2), this.BackColor.G, this.BackColor.B);
            }

            if (this.BackColor.G != 0)
            {
                this.BackColor = Color.FromArgb(255, this.BackColor.R, (int)(this.BackColor.G / 1.2), this.BackColor.B);
            }

            if (this.BackColor.B != 0)
            {
                this.BackColor = Color.FromArgb(255, this.BackColor.R, this.BackColor.G, (int)(this.BackColor.B / 1.2));
            }
        }

        private void AddEnemy()
        {
            RectangleF r = new RectangleF();

            if (rand.Next(1, 2) == 2)
            {
                r.X = player.X + rand.Next((int)(this.Width - player.X) / 10, (int)(this.Width - player.X) / 2);
                r.Y = player.Y + rand.Next((int)(this.Height - player.Y) / 10, (int)(this.Height - player.Y) / 2);
            }
            else
            {
                r.X = player.X + rand.Next((int)(player.X) / 10, (int)(player.X / 2));
                r.Y = player.Y + rand.Next((int)(player.Y) / 10, (int)(player.Y / 2));
            }

            
            //
            // Randomly selects enemy type
            //
            int nm = ((score) / (10 - Form1.difficulty));

            if (rand.Next(1, 100) <= 1 * nm)
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "incinerator");
                enemyList.Add(n);

                n.body.Size = SizeRatio(n.body.Width, n.body.Height);
            }
            else if (rand.Next(1, 100) <= 2 * nm)
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "gatlinggunner");
                enemyList.Add(n);

                n.body.Size = SizeRatio(n.body.Width, n.body.Height);
            }
            else if (rand.Next(1, 100) <= 5 * nm)
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "armored");
                enemyList.Add(n);

                n.body.Size = SizeRatio(n.body.Width, n.body.Height);
            }
            else if (rand.Next(1, 100) <= 7 * nm)
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "gunner");
                enemyList.Add(n);

                n.body.Size = SizeRatio(n.body.Width, n.body.Height);
            }
            else if (rand.Next(1, 100) <= 10 * nm)
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "rocketeer");
                enemyList.Add(n);

                n.body.Size = SizeRatio(n.body.Width, n.body.Height);
            }
            else if (rand.Next(1, 100) <= 12 * nm)
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "deflector");
                enemyList.Add(n);

                n.body.Size = SizeRatio(n.body.Width, n.body.Height);
            }
            else if (rand.Next(1, 100) <= 15 * nm)
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "buckshot");
                enemyList.Add(n);

                n.body.Size = SizeRatio(n.body.Width, n.body.Height);
            }
            else if (rand.Next(1, 100) <= 20 * nm)
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "lazer");
                enemyList.Add(n);

                n.body.Size = SizeRatio(n.body.Width, n.body.Height);
            }
            else if (rand.Next(1, 100) <= 25 * nm)
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "fragmenter");
                enemyList.Add(n);

                n.body.Size = SizeRatio(n.body.Width, n.body.Height);
            }
            else
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "normal");
                enemyList.Add(n);

                n.body.Size = SizeRatio(n.body.Width, n.body.Height);
            }

            
        }

        private void AddPowerUp()
        {

            float X = player.X + rand.Next((int)(this.Width - player.X) / 10, (int)(this.Width - player.X /1.5));
            float Y = player.Y + rand.Next((int)(this.Height - player.Y) / 10, (int)(this.Height - player.Y /1.5));

            if (rand.Next(1,100) <= 5/Form1.difficulty)
            {
                PowerUp p = new PowerUp(new PointF(X, Y), "lazer");
                powerUps.Add(p);

                p.body.Size = SizeRatio(p.body.Width, p.body.Height);
            }
            else if (rand.Next(1, 100) <= 15 / Form1.difficulty)
            {
                PowerUp p = new PowerUp(new PointF(X, Y), "shotgun");
                powerUps.Add(p);

                p.body.Size = SizeRatio(p.body.Width, p.body.Height);
            }
            else if (rand.Next(1, 100) <= 25 / Form1.difficulty)
            {
                PowerUp p = new PowerUp(new PointF(X, Y), "gunner");
                powerUps.Add(p);

                p.body.Size = SizeRatio(p.body.Width, p.body.Height);
            }
            else
            {
                PowerUp p = new PowerUp(new PointF(X, Y), "heal");
                powerUps.Add(p);

                p.body.Size = SizeRatio(p.body.Width, p.body.Height);
            }

        }


        private void changeScore(int _change, bool melee)
        {

            if (_change > 0)
            {
                score += _change;

                if (melee == true)
                {
                    lives++;
                }
            }
            else
            {
                if (_change < 0 && playerImmune == false)
                {
                    lives--;

                    Emmit(new PointF(player.X + player.Width / 2, player.Y + player.Height / 2), 5, 10, "blood", new PointF(0, 0));

                    //powerUp = "None";

                    this.BackColor = Color.Red;

                    PlaySound("sound_Hit.wav");

                    Thread.Sleep(100);

                    playerImmune = true;

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
                    e.Graphics.FillEllipse(new SolidBrush(enemy.color), enemy.body);
                }  

            }

            foreach (PowerUp u in powerUps)
            {

                if (u != null)
                {

                    e.Graphics.FillRectangle(new SolidBrush(u.color), u.body);

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
                    Color c;

                    if (l.IsFriendly == true)
                    {
                        c = Color.Blue;
                    }
                    else 
                    { 
                        c = Color.Red;
                    }

                    if (l.IsWarning == true)
                    {
                        e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(150, Color.Pink)), l.lwidth), l.point0.X, l.point0.Y, l.point1.X, l.point1.Y);
                    }
                    else
                    {
                        e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(255 / Math.Abs(1 + ((l.totalduration - l.duration) / l.totalduration)), c)), l.lwidth), l.point0.X, l.point0.Y, l.point1.X, l.point1.Y);
                        if (Debug == true)
                        {
                            foreach (RectangleF h in l.hitboxes)
                            {

                                if (h != null)
                                {
                                    e.Graphics.FillEllipse(new SolidBrush(Color.White), h);
                                }

                            }
                        }
                    }
                }
            }

            foreach (Rocket r in rockets)
            {
                if (r != null)
                {
                    if (r.IsFriendly == true)
                    {
                        e.Graphics.FillEllipse(new SolidBrush(Color.Pink), r.body);
                    }
                    else
                    {
                        e.Graphics.FillEllipse(new SolidBrush(Color.White), r.body);
                    }
                }
            }

            foreach (Explosion ex in explosions)
            {

                if (ex != null)
                {
                    e.Graphics.FillEllipse(new SolidBrush(Color.Firebrick), ex.body);
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
                        PlaySound("sound_Dodge.wav");
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

        private void FireAsset(string type, PointF pos, float size, float velX, float velY, bool IsFriendly, bool scatter)
        {
            switch (type)
            {
                case "bullet":
                    RectangleF b = new RectangleF
                    {
                        Size = SizeRatio(size, size),
                        Location = pos
                    };

                    //float hyp = (float)Math.Sqrt((Math.Pow(velX, 2) + Math.Pow(velY, 2)));

                    float _ang = (float)Math.Atan((velY / velX));

                    float rvelX, rvelY;

                    if (velY >= 0 && velX >= 0) // (+,+)
                    {
                        rvelY = (float)(bulletSpeed * Math.Sin(_ang));

                        rvelX = (float)(bulletSpeed * Math.Cos(_ang));
                    }
                    else if (velY >= 0 && velX < 0) // (-,+)
                    {
                        rvelY = (float)(bulletSpeed * -Math.Sin(_ang));

                        rvelX = (float)(bulletSpeed * -Math.Cos(_ang));
                    }
                    else if (velY < 0 && velX >= 0) // (+,-)
                    {
                        rvelY = (float)(bulletSpeed * Math.Sin(_ang));

                        rvelX = (float)(bulletSpeed * Math.Cos(_ang));
                    }
                    else //(-,-)
                    {
                        rvelY = (float)(bulletSpeed * -Math.Sin(_ang));

                        rvelX = (float)(bulletSpeed * -Math.Cos(_ang));
                    }

                    PointF velN = TranslateRatio(rvelX, rvelY);

                    Emmit(pos, rand.Next(3, 6), (int)size, "smoke", new PointF((velX + rand.Next(-180, 180)), (velY + rand.Next(-180, 180))));

                    PlaySound("sound_Shoot.wav");

                    Ball ball = new Ball(velN.X, velN.Y, b, IsFriendly, scatter);

                    ballList.Add(ball);

                    break;

                case "lazer":

                    PointF p0 = new PointF(pos.X, pos.Y);

                    PointF p1 = TranslateRatio(velX * (this.Width - pos.X)/size, velY * (this.Height - pos.Y)/size);

                    Lazer l;

                    if (IsFriendly == true)
                    {
                        l = new Lazer(p0, p1, (int)size, 10, 1, true);
                    }
                    else
                    {
                        l = new Lazer(p0, p1, (int)size, 5 * Form1.difficulty, 50 / Form1.difficulty, false);
                    }

                    l.IsWarning = true;

                    lazers.Add(l);

                    break;

                case "rocket":

                    RectangleF r = new RectangleF
                    {
                        Size = SizeRatio(size, size),
                        Location = pos
                    };

                    //float hyp = (float)Math.Sqrt((Math.Pow(velX, 2) + Math.Pow(velY, 2)));

                    float _angr = (float)Math.Atan((velY / velX));

                    float rrvelX, rrvelY;

                    if (velY >= 0 && velX >= 0) // (+,+)
                    {
                        rrvelY = (float)(bulletSpeed * Math.Sin(_angr));

                        rrvelX = (float)(bulletSpeed * Math.Cos(_angr));
                    }
                    else if (velY >= 0 && velX < 0) // (-,+)
                    {
                        rrvelY = (float)(bulletSpeed * -Math.Sin(_angr));

                        rrvelX = (float)(bulletSpeed * -Math.Cos(_angr));
                    }
                    else if (velY < 0 && velX >= 0) // (+,-)
                    {
                        rrvelY = (float)(bulletSpeed * Math.Sin(_angr));

                        rrvelX = (float)(bulletSpeed * Math.Cos(_angr));
                    }
                    else //(-,-)
                    {
                        rrvelY = (float)(bulletSpeed * -Math.Sin(_angr));

                        rrvelX = (float)(bulletSpeed * -Math.Cos(_angr));
                    }

                    PointF rvelN = TranslateRatio(rrvelX, rrvelY);

                    Emmit(pos, rand.Next(3, 6), (int)size, "smoke", new PointF((velX + rand.Next(-180, 180)), (velY + rand.Next(-180, 180))));


                    Rocket rocket = new Rocket(rvelN.X, rvelN.Y, r, IsFriendly);

                    rockets.Add(rocket);

                    break;


            }
        }

        private void Emmit(PointF pos, int ammount, int maxsize, String type, PointF vel)
        {

            switch (type)
            {
                case "blood":

                    for (int i = 1; i < ammount; i++)
                    {
                        int size = rand.Next(7, maxsize);

                        SizeF s = SizeRatio(size, size);

                        Particle p = new Particle(rand.Next(-360, 360) / s.Width, rand.Next(-360, 360) / s.Height, (float)size / (5), pos.X, pos.Y, 255, s.Width, Color.Red);

                        particles.Add(p);

                    }

                    break;

                case "parry":

                    for (int i = 1; i < ammount; i++)
                    {
                        int size = rand.Next(5, maxsize);

                        SizeF s = SizeRatio(size, size);

                        Particle p = new Particle(rand.Next(-360, 360) / s.Width, rand.Next(-360, 360) / s.Height, (float)size / (6), pos.X, pos.Y, 255, s.Width, Color.Gold);

                        particles.Add(p);

                    }

                    break;

                case "smoke":

                    for (int i = 1; i < ammount; i++)
                    {

                        int size = rand.Next(10, 12 + maxsize);

                        SizeF s = SizeRatio(size, size);

                        Particle p = new Particle(vel.X / s.Width, vel.Y / s.Height, (float)size / (7), pos.X, pos.Y, 255, s.Width, Color.LightGray);

                        particles.Add(p);

                    }

                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            shootCooldownBase = (int)(10 * (Form1.difficulty / Math.Ceiling(((1+score) * 0.01))));

            dispose.Clear();

            if (IsPaused == false)
            {
                tick++;

                if (score >= 50 && Form1.InfiniteMode == false)
                {
                    WinScreen win = new WinScreen();
                    win.Size = this.FindForm().Size;
                    this.FindForm().Controls.Add(win);
                    this.FindForm().Controls.Remove(this);
                }

                if (enemyList.Count == 0)
                {
                    AddEnemy();
                }

                if ((tick % Math.Ceiling((decimal)(10000/(1 + score))) == 0) && rand.Next(1, 100) <= Math.Pow(Form1.difficulty, 2))
                {
                    AddEnemy();
                }
                else if(tick % 100 == 0 && rand.Next(1,10) <= (50/Form1.difficulty)/(1 + powerUps.Count()))
                {
                    AddPowerUp();
                }

                flashCheck();
                try
                {
                    mousePos.X = (Cursor.Position.X - this.FindForm().Location.X) * (this.FindForm().Width / this.FindForm().DesktopBounds.Width);
                    mousePos.Y = (Cursor.Position.Y - this.FindForm().Location.Y) * (this.FindForm().Height / this.FindForm().DesktopBounds.Height);
                }
                catch
                {
                    mousePos.X = 0;
                    mousePos.Y = 0;
                }
                

                buttonMenu.Visible = false;

                buttonResume.Visible = false;

                pauseLabel.Visible = false;

                if (currentCooldown > 0)
                {
                    playerImmune = true;

                    currentCooldown--;

                    playerVelX--;

                    playerVelY--;

                    float siz = rand.Next(10, 20);

                    SizeF s = SizeRatio(siz, siz);

                    PointF v = TranslateRatio(-playerVelX + rand.Next(-3, 3), -playerVelY + rand.Next(-3, 3));

                    Particle p = new Particle(v.X, v.Y, (float)s.Width / (5), player.X + (player.Width / 2), player.Y + (player.Height / 2), 150, s.Width, Color.LightGray);
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

                        if (powerUp == "gunner")
                        {

                            currentShootCooldown = shootCooldownBase/5;
                            FireAsset("bullet", new PointF(player.X + player.Width / 2, player.Y + player.Height / 2), 14, 2 * (-(player.X + (player.Width / 2)) + mousePos.X), 2 * (-(player.Y + (player.Height / 2)) + mousePos.Y), true, false);
                        }
                        else
                        {
                            currentShootCooldown = shootCooldownBase;
                        }

                        if (powerUp == "None")
                        {

                            FireAsset("bullet", new PointF(player.X + player.Width / 2, player.Y + player.Height / 2), 14, 2 * (-(player.X + (player.Width / 2)) + mousePos.X), 2 * (-(player.Y + (player.Height / 2)) + mousePos.Y), true, false);
                        }
                        else if (powerUp == "shotgun")
                        {

                            FireAsset("bullet", new PointF(player.X + player.Width / 2, player.Y + player.Height / 2), 14, 2 * (-(player.X + (player.Width / 2)) + mousePos.X), 2 * (-(player.Y + (player.Height / 2)) + mousePos.Y), true, false);
                            FireAsset("bullet", new PointF(player.X + player.Width / 2, player.Y + player.Height / 2), 14, 2 * (-(player.X + (player.Width / 2)) + mousePos.X + 50), 2 * (-(player.Y + (player.Height / 2)) + mousePos.Y + 50), true, false);
                            FireAsset("bullet", new PointF(player.X + player.Width / 2, player.Y + player.Height / 2), 14, 2 * (-(player.X + (player.Width / 2)) + mousePos.X - 50), 2 * (-(player.Y + (player.Height / 2)) + mousePos.Y - 50), true, false);
                        }
                        else if(powerUp == "lazer")
                        {

                            FireAsset("lazer", new PointF(player.X + player.Width / 2, player.Y + player.Height / 2), (float)14, 2 * (-(player.X + (player.Width / 2)) + mousePos.X), 2 * (-(player.Y + (player.Height / 2)) + mousePos.Y), true, false);
                        }


                        playerVelX += ((player.X + (player.Width / 2)) - mousePos.X) / 100;
                        playerVelY += ((player.Y + (player.Height / 2)) - mousePos.Y) / 100;
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

                player.Y += TranslateRatio(playerVelX, playerVelY).Y;
                player.X += TranslateRatio(playerVelX, playerVelY).X;

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

                //
                // Enemy Update
                //
                foreach (Enemy en in enemyList)
                {
                    int change = en.Update(player, this.FindForm());

                    if (change != 0)
                    {
                        if (change < 0)
                        {

                            changeScore(change, false);
 
                        }
                        else
                        {

                            Emmit(new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), 10, 20, "blood", new PointF(0,0));

                            changeScore(change, false);
                            dispose.Add(en);

                            Refresh();

                            //return;
                        }
                    }
                    else
                    {
                        if (en.body.X > this.FindForm().Width - en.body.Width)
                        {
                            en.body.X = this.FindForm().Width - en.body.Width;
                            en.Xvel /= -2;
                        }

                        if (en.body.X < 0)
                        {
                            en.body.X = 0;
                            en.Xvel /= -2;
                        }

                        if (en.body.Y > this.FindForm().Height - en.body.Height)
                        {
                            en.body.Y = this.FindForm().Height - en.body.Height;
                            en.Yvel /= -2;
                        }

                        if (en.body.Y < 0)
                        {
                            en.body.Y = 0;
                            en.Yvel /= -2;
                        }

                        PointF mov = TranslateRatio(en.Xvel, en.Yvel);

                        en.body.X += mov.X;
                        en.body.Y += mov.Y;

                        foreach (Ball b in ballList)
                        {
                            if (b.IsFriendly == true && en.body.IntersectsWith(b.body))
                            {
                                en.health--;

                                if (en.type!="deflector" && en.type!= "armored" && en.type != "gatlinggunner" && en.type != "incinerator")
                                {

                                    if (en.health <= 0)
                                    {

                                        changeScore(1, false);

                                        dispose.Add(en);

                                        //Refresh();

                                    }

                                    Emmit(new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), 10, 20, "blood", new PointF(0, 0));

                                    dispose.Add(b);

                                    //return;
                                }
                                else
                                {
                                    if (en.health <= 0)
                                    {

                                        changeScore(1, false);

                                        dispose.Add(en);

                                        //Refresh();

                                    }

                                    b.IsFriendly = false;

                                    b.velX = -b.velX + en.Xvel;
                                    b.velY = -b.velY + en.Yvel;

                                    PlaySound("sound_Parry.wav");

                                    Emmit(new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), 10, 10, "parry", new PointF(0, 0));

                                }


                            }
                        }

                        foreach (Lazer l in lazers)
                        {
                            if (l.IsFriendly == true && l.IsWarning == false)
                            {
                                foreach (RectangleF h in l.hitboxes)
                                {
                                    if (h.IntersectsWith(en.body))
                                    {
                                        en.health--;

                                        l.hitboxes.Remove(h);

                                        return;
                                    }
                                }
                            }
                        }

                        foreach (Rocket r in rockets)
                        {
                            if (r.IsFriendly == true && r.body.IntersectsWith(en.body))
                            {
                                r.isHit = true;
                            }
                        }

                        float LaunchX = (player.X - en.body.X) * 2;
                        float LaunchY = (player.Y - en.body.Y) * 2;

                        if (rand.Next(0, 100) <= Form1.difficulty * 15 && tick % 20 == 1)
                        {
                            
                            if (en.type == "lazer")
                            {

                                FireAsset("lazer", new PointF(en.body.X + (en.body.Width / 2), en.body.Y + (en.body.Height / 2)), (float)(en.body.Height / 1.1), LaunchX * 3, LaunchY * 3, false, false);

                            }
                            else if(en.type == "normal")
                            {

                                FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (7 * Form1.difficulty), LaunchX, LaunchY, false, false);

                            }
                            else if (en.type == "fragmenter")
                            {

                                FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (7 * Form1.difficulty), LaunchX, LaunchY, false, true);

                            }
                            else if (en.type == "rocketeer")
                            {

                                FireAsset("rocket", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (7 * Form1.difficulty), LaunchX, LaunchY, false, false);

                            }
                            else if (en.type == "buckshot")
                            {

                                FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (7 * Form1.difficulty), LaunchX, LaunchY, false, false);
                                FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (7 * Form1.difficulty), LaunchX - 50, LaunchY - 50, false, false);
                                FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (7 * Form1.difficulty), LaunchX + 50, LaunchY + 50, false, false);

                            }
                            else if(en.type == "armored")
                            {
                                FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (10 * Form1.difficulty), LaunchX, LaunchY, false, false);
                            }


                        }
                        else if(en.type == "gunner" && tick % 10 == 0)
                        {

                            FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (5 * Form1.difficulty), LaunchX, LaunchY, false, false);

                        }
                        else if (en.type == "gatlinggunner" && tick % (50 / Form1.difficulty) == 0)
                        {

                            FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (12 * Form1.difficulty), LaunchX, LaunchY, false, false);
                            FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (12 * Form1.difficulty), LaunchX - 50, LaunchY - 50, false, false);
                            FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (12 * Form1.difficulty), LaunchX + 50, LaunchY + 50, false, false);

                        }
                        else if (en.type == "incinerator" && tick % (50 / Form1.difficulty) == 0)
                        {

                            FireAsset("lazer", new PointF(en.body.X + (en.body.Width / 2), en.body.Y + (en.body.Height / 2)), (float)(en.body.Height / 1.1), LaunchX * 10, LaunchY * 10, false, false);
                            FireAsset("lazer", new PointF(en.body.X + (en.body.Width / 2), en.body.Y + (en.body.Height / 2)), (float)(en.body.Height / 1.1), (LaunchX - 50) * 10, (LaunchY - 50) * 10, false, false);
                            FireAsset("lazer", new PointF(en.body.X + (en.body.Width / 2), en.body.Y + (en.body.Height / 2)), (float)(en.body.Height / 1.1), (LaunchX + 50) * 10, (LaunchY + 50) * 10, false, false);

                        }

                    }
                }

                //
                // Power Up Update
                //
                foreach (PowerUp p in powerUps)
                {
                    bool collected = p.CheckForGathered(player);

                    if (collected == true)
                    {
                        if (p.type == "heal")
                        {
                            lives += 2;
                        }
                        else
                        {
                            powerUp = p.type;
                        }

                        dispose.Add(p);
                    }
                    else
                    {
                        if (tick % 10 == 0)
                        {

                            int size = rand.Next(5, 10);

                            Particle n = new Particle( rand.Next(-180, 180) / size, rand.Next(-180, 180) / size, (float)size, p.body.X + p.body.Width / 2, p.body.Y + p.body.Height / 2, 255, size, p.color);

                            particles.Add(n);

                        }

                    }
                }

                //
                // Ball Update
                //
                foreach (Ball b in ballList)
                {
                    int change = b.Update(player, this.FindForm());
                    if (change != 0)
                    {
                        if (change != 2 && playerImmune != true)
                        {
                            changeScore(change, false);

                            dispose.Add(b);
                            //Refresh();

                            //return;
                        }
                        else
                        {
                            if (change != 2 && playerImmune == true)
                            {
                                this.BackColor = Color.FromArgb(255, 100, 100, 100);

                                PlaySound("sound_Parry.wav");

                                for (int i = 1; i < rand.Next(5, 10); i++)
                                {
                                    int size = rand.Next(5, 10);

                                    Particle p = new Particle(rand.Next(-360, 360) / size, rand.Next(-360, 360) / size, (float)size/4, player.X + player.Width / 2, player.Y + player.Height / 2, 255, size, Color.Gold);

                                    particles.Add(p);

                                }

                                b.IsFriendly = true;
                                b.isHit = false;
                                b.velX = playerVelX*2;
                                b.velY = playerVelY*2;
                            }
                            else
                            {

                                if (b.ScatterMode == true)
                                {
                                    for (int i = 0; i < 4*Form1.difficulty; i++)
                                    {
                                        float ang = (float)((i * Math.PI) / 4)*(float)(180/Math.PI);

                                        float velX = (float)(bulletSpeed*Math.Cos(ang));

                                        float velY = (float)(bulletSpeed * Math.Sin(ang));

                                        FireAsset("bullet", b.body.Location, b.body.Width,velX, velY, b.IsFriendly, false);
                                    }

                                    ballList.Remove(b);

                                    return;
                                }

                                dispose.Add(b);
                                //Refresh();
                                //return;
                            }

                        }

                    }
                }

                //
                // Particle Update
                //
                foreach(Particle p in particles)
                {
                    p.Render();

                    if (p.color.A <= 0)
                    {
                        dispose.Add(p);
                    }
                    else
                    {
                        PointF mov = TranslateRatio(p.velX, p.velY);

                        p.body.X += mov.X;
                        p.body.Y += mov.Y;

                    }
                }

                //
                // Lazer Update
                //
                foreach (Lazer l in lazers)
                {
                    if (l.warnTime <= 0 && l.IsWarning == true)
                    {
                        PlaySound("sound_Laser.wav");

                        l.IsWarning = false;
                    }
                    else
                    {
                        l.warnTime--;
                    }

                    if (l.duration > 0 && l.IsWarning == false)
                    {
                        l.duration--;

                        l.Update();

                      //  foreach (RectangleF h in l.hitboxes)
                      //  {
                      //      if (l.IsFriendly == false && h.IntersectsWith(player) && playerImmune == false)
                      //      {
                      //          playerImmune = true;
                      //
                      //          changeScore(-1, false);

                      //          l.hitboxes.Remove(h);

                      //          Refresh();

                      //          return;

                      //      }
                      //  }

                        RectangleF h = l.hitboxes.Find(x => x.IntersectsWith(player) == true);

                        if (h != null && h.IntersectsWith(player) && l.IsFriendly == false && playerImmune == false)
                        {
                            changeScore(-1, false);

                            currentCooldown = cooldownTickBase * 2;

                            l.hitboxes.Remove(h);

                        }

                    }
                    else
                    {
                        if (l.IsWarning == false)
                        {

                            dispose.Add(l);

                        }
                        
                    }
                }

                //
                // Rocket Update
                //
                foreach (Rocket r in rockets)
                {
                    if (r != null)
                    {
                        bool hit = r.Update(player, this.FindForm());

                        if (hit == true)
                        {
                            Explosion ex = new Explosion(new PointF(r.body.X + (r.body.Width / 2), r.body.Y + (r.body.Height / 2)), r.body.Width * (5 * Form1.difficulty));

                            explosions.Add(ex);

                            dispose.Add(r);
                        }
                        else
                        {
                            if (tick % 2 == 0)
                            {

                                float siz = rand.Next((int)(r.body.Width / 3), (int)r.body.Width);

                                SizeF s = SizeRatio(siz, siz);

                                PointF v = TranslateRatio(-r.velX + rand.Next(-3, 3), -r.velY + rand.Next(-3, 3));

                                Particle p = new Particle(v.X, v.Y, (float)s.Width / (5), r.body.X + (r.body.Width / 2), r.body.Y + (r.body.Height / 2), 150, s.Width, Color.LightGray);
                                particles.Add(p);
                            }
                        }
                    }
                }

                //
                // Explosion Update
                //
                foreach (Explosion ex in explosions)
                {
                    Form f = this.FindForm();

                    int hit = ex.Update(player, f);

                    if (hit == 1)
                    {
                        dispose.Add(ex);
                    }
                    else if(hit==-1)
                    {
                        playerVelX = 10*(ex.pos.X - player.X);
                        playerVelY = 10*(ex.pos.Y - player.Y);

                        player.X += ex.pos.X - player.X;
                        player.Y += ex.pos.Y - player.Y;

                        changeScore(-1, false);
                    }
                }

                //
                // Clean Particles
                //
                foreach (object i in dispose)
                {

                    if (lazers.Contains(i))
                    {
                        lazers.Remove((Lazer)i);
                    }
                    else if(particles.Contains(i))
                    {
                        particles.Remove((Particle)i);
                    }
                    else if(ballList.Contains(i))
                    {
                        ballList.Remove((Ball)i);
                    }
                    else if(enemyList.Contains(i))
                    {
                        enemyList.Remove((Enemy)i);
                    }
                    else if (powerUps.Contains(i))
                    {
                        powerUps.Remove((PowerUp)i);
                    }
                    else if (rockets.Contains(i))
                    {
                        rockets.Remove((Rocket)i);
                    }
                    else if (explosions.Contains(i))
                    {
                        explosions.Remove((Explosion)i);
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

                pauseLabel.Width = this.Width / 5;

                pauseLabel.Visible = true;
                pauseLabel.Location = new Point(buttonResume.Location.X, buttonResume.Location.Y - (int)(buttonResume.Height * 1.1));
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

            bulletSpeed = 200 * (float)Math.Pow(Form1.difficulty , 2);

            player.Size = SizeRatio(15, 15);
            player.Location = new Point((this.Width/2) - 5, (this.Height/2) - 5);
            playerVelX = 0;
            playerVelY = 0;
            score = -1;
            lives = 3;
            labelStats.Location = new Point((this.Width / 2)-(labelStats.Width/2), labelStats.Height);

            gameTimer.Enabled = true;

            changeScore(1, false);
        }
    }
}
