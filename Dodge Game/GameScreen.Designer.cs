namespace Dodge_Game
{
    partial class GameScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.labelStats = new System.Windows.Forms.Label();
            this.buttonResume = new System.Windows.Forms.Button();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.pauseLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // labelStats
            // 
            this.labelStats.AutoSize = true;
            this.labelStats.BackColor = System.Drawing.Color.Transparent;
            this.labelStats.Font = new System.Drawing.Font("MS PGothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStats.ForeColor = System.Drawing.Color.White;
            this.labelStats.Location = new System.Drawing.Point(157, 11);
            this.labelStats.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStats.Name = "labelStats";
            this.labelStats.Size = new System.Drawing.Size(180, 19);
            this.labelStats.TabIndex = 0;
            this.labelStats.Text = "LIVES: 3 - SCORE: 0";
            this.labelStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonResume
            // 
            this.buttonResume.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonResume.FlatAppearance.BorderSize = 3;
            this.buttonResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResume.Font = new System.Drawing.Font("MS Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResume.ForeColor = System.Drawing.Color.White;
            this.buttonResume.Location = new System.Drawing.Point(196, 153);
            this.buttonResume.Margin = new System.Windows.Forms.Padding(2);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(109, 46);
            this.buttonResume.TabIndex = 7;
            this.buttonResume.Text = "RESUME";
            this.buttonResume.UseVisualStyleBackColor = true;
            this.buttonResume.Click += new System.EventHandler(this.buttonResume_Click);
            // 
            // buttonMenu
            // 
            this.buttonMenu.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonMenu.FlatAppearance.BorderSize = 3;
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.Font = new System.Drawing.Font("MS Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMenu.ForeColor = System.Drawing.Color.White;
            this.buttonMenu.Location = new System.Drawing.Point(196, 213);
            this.buttonMenu.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(109, 46);
            this.buttonMenu.TabIndex = 8;
            this.buttonMenu.Text = "MENU";
            this.buttonMenu.UseVisualStyleBackColor = true;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // pauseLabel
            // 
            this.pauseLabel.AutoSize = true;
            this.pauseLabel.BackColor = System.Drawing.Color.Transparent;
            this.pauseLabel.Font = new System.Drawing.Font("MS PGothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseLabel.ForeColor = System.Drawing.Color.White;
            this.pauseLabel.Location = new System.Drawing.Point(206, 101);
            this.pauseLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pauseLabel.Name = "pauseLabel";
            this.pauseLabel.Size = new System.Drawing.Size(99, 24);
            this.pauseLabel.TabIndex = 9;
            this.pauseLabel.Text = "PAUSED";
            this.pauseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.pauseLabel);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.buttonResume);
            this.Controls.Add(this.labelStats);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(516, 386);
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameScreen_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameScreen_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label labelStats;
        private System.Windows.Forms.Button buttonResume;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Label pauseLabel;
    }
}
