﻿using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Dodge_Game
{
    public partial class GameScreen : UserControl
    {
        List<Enemy> enemyList = new List<Enemy>();

        List<Ball> ballList = new List<Ball>();

        List<Lazer> lazers = new List<Lazer>();

        List<Particle> particles = new List<Particle>();

        List<PowerUp> powerUps = new List<PowerUp>();

        List<object> dispose = new List<object>();

        RectangleF player;

        PointF mousePos;

        Random rand = new Random();

        bool Debug = false;

        bool heldUp, heldDown, heldLeft, heldRight, playerImmune, LeftMouseDown, CanPause, IsPaused;

        float playerVelX, playerVelY;

        int score, lives, currentCooldown, currentShootCooldown, tick, powerUpTimer;

        int cooldownTickBase = 10, shootCooldownBase = 10*Form1.difficulty;

        string powerUp = "None";

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

            

            int nm = ((score) / (10 - Form1.difficulty));

            if (rand.Next(1, 100) <= 1 * nm)
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "incinerator");
                enemyList.Add(n);
            }
            else if (rand.Next(1, 100) <= 2 * nm)
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "gatlinggunner");
                enemyList.Add(n);
            }
            else if (rand.Next(1, 100) <= 5 * nm)
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "armored");
                enemyList.Add(n);
            }
            else if (rand.Next(1, 100) <= 7 * nm)
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "gunner");
                enemyList.Add(n);
            }
            else if (rand.Next(1, 100) <= 12 * nm)
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "deflector");
                enemyList.Add(n);
            }
            else if (rand.Next(1, 100) <= 15 * nm)
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "buckshot");
                enemyList.Add(n);
            }
            else if (rand.Next(1, 100) <= 20 * nm)
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "lazer");
                enemyList.Add(n);
            }
            else
            {
                Enemy n = new Enemy(new PointF(r.X, r.Y), r, "normal");
                enemyList.Add(n);
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
            }
            else if (rand.Next(1, 100) <= 15 / Form1.difficulty)
            {
                PowerUp p = new PowerUp(new PointF(X, Y), "shotgun");
                powerUps.Add(p);
            }
            else if (rand.Next(1, 100) <= 25 / Form1.difficulty)
            {
                PowerUp p = new PowerUp(new PointF(X, Y), "gunner");
                powerUps.Add(p);
            }
            else
            {
                PowerUp p = new PowerUp(new PointF(X, Y), "heal");
                powerUps.Add(p);
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
                if (_change < 0)
                {
                    lives--;

                    Emmit(new PointF(player.X + player.Width / 2, player.Y + player.Height / 2), 5, 10, "blood");

                    powerUp = "None";

                    this.BackColor = Color.Red;
                    SoundPlayer h = new SoundPlayer(Properties.Resources.sound_Hit);

                    currentCooldown = cooldownTickBase * 3;

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

        private void FireAsset(string type, PointF pos, float size, float velX, float velY, bool IsFriendly)
        {
            switch (type)
            {
                case "bullet":
                    RectangleF b = new RectangleF
                    {
                        Size = new SizeF(size, size),
                        Location = pos
                    };

                    for (int i = 1; i < rand.Next(3, 6); i++)
                    {
                        if (IsFriendly == true)
                        {
                            Particle p = new Particle((velX + rand.Next(-180, 180)) / 10, (velY + rand.Next(-180, 180)) / 10, (float)rand.NextDouble() + 1, pos.X, pos.Y, 255, rand.Next((int)size/2, (int)size), Color.Blue);
                            particles.Add(p);
                        }
                        else
                        {
                            Particle p = new Particle((velX + rand.Next(-180, 180)) / 10, (velY + rand.Next(-180, 180)) / 10, (float)rand.NextDouble() + 1, pos.X, pos.Y, 255, rand.Next((int)size/2, (int)size), Color.Red);
                            particles.Add(p);
                        }

                    }

                    Ball ball = new Ball(velX, velY, b, IsFriendly);

                    ballList.Add(ball);

                    break;

                case "lazer":

                    PointF p0 = new PointF(pos.X, pos.Y);
                    PointF p1 = new PointF(velX * 100, velY * 100);

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


            }
        }

        private void Emmit(PointF pos, int ammount, int maxsize, String type)
        {

            switch (type)
            {
                case "blood":

                    for (int i = 1; i < ammount; i++)
                    {
                        int size = rand.Next(7, maxsize);

                        Particle p = new Particle(rand.Next(-360, 360) / size, rand.Next(-360, 360) / size, (float)size / 5, pos.X, pos.Y, 255, size, Color.Red);

                        particles.Add(p);

                    }

                    break;

                case "parry":

                    for (int i = 1; i < ammount; i++)
                    {
                        int size = rand.Next(5, maxsize);

                        Particle p = new Particle(rand.Next(-360, 360) / size, rand.Next(-360, 360) / size, (float)size / 6, pos.X, pos.Y, 255, size, Color.Gold);

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

                if (enemyList.Count == 0)
                {
                    AddEnemy();
                }

                if ((tick % Math.Ceiling((decimal)(1000/(1 + score))) == 0) && rand.Next(1, 100) <= Form1.difficulty)
                {
                    AddEnemy();
                }
                else if(tick % 100 == 0 && rand.Next(1,10) <= (50/Form1.difficulty)/(1 + powerUps.Count()))
                {
                    AddPowerUp();
                }

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

                        if (powerUp == "gunner")
                        {
                            currentShootCooldown = shootCooldownBase/5;
                            FireAsset("bullet", new PointF(player.X + player.Width / 2, player.Y + player.Height / 2), (float)(player.Height / 1.1), 2 * (-(player.X + (player.Width / 2)) + mousePos.X), 2 * (-(player.Y + (player.Height / 2)) + mousePos.Y), true);
                        }
                        else
                        {
                            currentShootCooldown = shootCooldownBase;
                        }

                        if (powerUp == "None")
                        {
                            FireAsset("bullet", new PointF(player.X + player.Width / 2, player.Y + player.Height / 2), (float)(player.Height / 1.1), 2 * (-(player.X + (player.Width / 2)) + mousePos.X), 2 * (-(player.Y + (player.Height / 2)) + mousePos.Y), true);
                        }
                        else if (powerUp == "shotgun")
                        {
                            FireAsset("bullet", new PointF(player.X + player.Width / 2, player.Y + player.Height / 2), (float)(player.Height / 1.1), 2 * (-(player.X + (player.Width / 2)) + mousePos.X), 2 * (-(player.Y + (player.Height / 2)) + mousePos.Y), true);
                            FireAsset("bullet", new PointF(player.X + player.Width / 2, player.Y + player.Height / 2), (float)(player.Height / 1.1), 2 * (-(player.X + (player.Width / 2)) + mousePos.X + 50), 2 * (-(player.Y + (player.Height / 2)) + mousePos.Y + 50), true);
                            FireAsset("bullet", new PointF(player.X + player.Width / 2, player.Y + player.Height / 2), (float)(player.Height / 1.1), 2 * (-(player.X + (player.Width / 2)) + mousePos.X - 50), 2 * (-(player.Y + (player.Height / 2)) + mousePos.Y - 50), true);
                        }
                        else if(powerUp == "lazer")
                        {
                            FireAsset("lazer", new PointF(player.X + player.Width / 2, player.Y + player.Height / 2), (float)(player.Height), 2 * (-(player.X + (player.Width / 2)) + mousePos.X), 2 * (-(player.Y + (player.Height / 2)) + mousePos.Y), true);
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

                            Emmit(new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), 10, 20, "blood");

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

                                    Emmit(new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), 10, 20, "blood");

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

                                    Emmit(new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), 10, 10, "parry");

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

                        float LaunchX = (player.X - en.body.X) * 2;
                        float LaunchY = (player.Y - en.body.Y) * 2;

                        if (rand.Next(0, 100) <= Form1.difficulty * 15 && tick % 20 == 1)
                        {
                            
                            if (en.type == "lazer")
                            {

                                FireAsset("lazer", new PointF(en.body.X + (en.body.Width / 2), en.body.Y + (en.body.Height / 2)), (float)(en.body.Height / 1.1), LaunchX * 10, LaunchY * 10, false);

                            }
                            else if(en.type == "normal")
                            {

                                FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (7 * Form1.difficulty), LaunchX, LaunchY, false);

                            }
                            else if (en.type == "buckshot")
                            {

                                FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (7 * Form1.difficulty), LaunchX, LaunchY, false);
                                FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (7 * Form1.difficulty), LaunchX - 50, LaunchY - 50, false);
                                FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (7 * Form1.difficulty), LaunchX + 50, LaunchY + 50, false);

                            }
                            else if(en.type == "armored")
                            {
                                FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (10 * Form1.difficulty), LaunchX, LaunchY, false);
                            }


                        }
                        else if(en.type == "gunner" && tick % 10 == 0)
                        {

                            FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (5 * Form1.difficulty), LaunchX, LaunchY, false);

                        }
                        else if (en.type == "gatlinggunner" && tick % (50/Form1.difficulty) == 0)
                        {

                            FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (12 * Form1.difficulty), LaunchX, LaunchY, false);
                            FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (12 * Form1.difficulty), LaunchX - 50, LaunchY - 50, false);
                            FireAsset("bullet", new PointF(en.body.X + en.body.Width / 2, en.body.Y + en.body.Height / 2), (12 * Form1.difficulty), LaunchX + 50, LaunchY + 50, false);

                        }
                        else if (en.type == "incinerator" && tick % (50 / Form1.difficulty) == 0)
                        {

                            FireAsset("lazer", new PointF(en.body.X + (en.body.Width / 2), en.body.Y + (en.body.Height / 2)), (float)(en.body.Height / 1.1), LaunchX * 10, LaunchY * 10, false);
                            FireAsset("lazer", new PointF(en.body.X + (en.body.Width / 2), en.body.Y + (en.body.Height / 2)), (float)(en.body.Height / 1.1), (LaunchX - 50) * 10, (LaunchY-50) * 10, false);
                            FireAsset("lazer", new PointF(en.body.X + (en.body.Width / 2), en.body.Y + (en.body.Height / 2)), (float)(en.body.Height / 1.1), (LaunchX + 50) * 10, (LaunchY + 50) * 10, false);

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
                            Refresh();

                            //return;
                        }
                        else
                        {
                            if (change != 2 && playerImmune == true)
                            {
                                this.BackColor = Color.FromArgb(255, 100, 100, 100);

                                SoundPlayer parry = new SoundPlayer(Properties.Resources.sound_Parry);

                                parry.Load();
                                parry.Play();

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
                }

                //
                // Lazer Update
                //
                foreach (Lazer l in lazers)
                {
                    if (l.warnTime <= 0)
                    {
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

                        foreach (RectangleF h in l.hitboxes)
                        {
                            if (l.IsFriendly == false && h.IntersectsWith(player) && playerImmune == false)
                            {
                                playerImmune = true;

                                changeScore(-1, false);

                                l.hitboxes.Remove(h);

                                return;
                            }
                        }



                    }
                    else
                    {
                        if (l.IsWarning == false)
                        {

                            lazers.Remove(l);

                            return;

                        }
                        
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

            player.Size = new Size(15,15);
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
