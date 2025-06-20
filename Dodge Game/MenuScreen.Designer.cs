﻿namespace Dodge_Game
{
    partial class MenuScreen
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonEasy = new System.Windows.Forms.Button();
            this.buttonNormal = new System.Windows.Forms.Button();
            this.buttonHard = new System.Windows.Forms.Button();
            this.buttonInsane = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonFullScreen = new System.Windows.Forms.Button();
            this.buttonHighScores = new System.Windows.Forms.Button();
            this.buttonInfiniteMode = new System.Windows.Forms.Button();
            this.labelControls = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTitle.Font = new System.Drawing.Font("Stencil", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Red;
            this.labelTitle.Location = new System.Drawing.Point(146, 15);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(322, 64);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "HELLFIRE";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonEasy
            // 
            this.buttonEasy.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.buttonEasy.FlatAppearance.BorderSize = 3;
            this.buttonEasy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEasy.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEasy.ForeColor = System.Drawing.Color.Lime;
            this.buttonEasy.Location = new System.Drawing.Point(194, 98);
            this.buttonEasy.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEasy.Name = "buttonEasy";
            this.buttonEasy.Size = new System.Drawing.Size(163, 46);
            this.buttonEasy.TabIndex = 1;
            this.buttonEasy.Text = "EASY";
            this.buttonEasy.UseVisualStyleBackColor = true;
            this.buttonEasy.Click += new System.EventHandler(this.buttonEasy_Click);
            // 
            // buttonNormal
            // 
            this.buttonNormal.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.buttonNormal.FlatAppearance.BorderSize = 3;
            this.buttonNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNormal.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNormal.ForeColor = System.Drawing.Color.Yellow;
            this.buttonNormal.Location = new System.Drawing.Point(194, 157);
            this.buttonNormal.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNormal.Name = "buttonNormal";
            this.buttonNormal.Size = new System.Drawing.Size(163, 46);
            this.buttonNormal.TabIndex = 2;
            this.buttonNormal.Text = "NORMAL";
            this.buttonNormal.UseVisualStyleBackColor = true;
            this.buttonNormal.Click += new System.EventHandler(this.buttonNormal_Click);
            // 
            // buttonHard
            // 
            this.buttonHard.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonHard.FlatAppearance.BorderSize = 3;
            this.buttonHard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHard.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHard.ForeColor = System.Drawing.Color.Red;
            this.buttonHard.Location = new System.Drawing.Point(194, 217);
            this.buttonHard.Margin = new System.Windows.Forms.Padding(2);
            this.buttonHard.Name = "buttonHard";
            this.buttonHard.Size = new System.Drawing.Size(163, 46);
            this.buttonHard.TabIndex = 3;
            this.buttonHard.Text = "HARD";
            this.buttonHard.UseVisualStyleBackColor = true;
            this.buttonHard.Click += new System.EventHandler(this.buttonHard_Click);
            // 
            // buttonInsane
            // 
            this.buttonInsane.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.buttonInsane.FlatAppearance.BorderSize = 3;
            this.buttonInsane.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsane.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsane.ForeColor = System.Drawing.Color.Fuchsia;
            this.buttonInsane.Location = new System.Drawing.Point(194, 277);
            this.buttonInsane.Margin = new System.Windows.Forms.Padding(2);
            this.buttonInsane.Name = "buttonInsane";
            this.buttonInsane.Size = new System.Drawing.Size(163, 46);
            this.buttonInsane.TabIndex = 4;
            this.buttonInsane.Text = "INSANE";
            this.buttonInsane.UseVisualStyleBackColor = true;
            this.buttonInsane.Click += new System.EventHandler(this.buttonInsane_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonExit.FlatAppearance.BorderSize = 3;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(452, 325);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(109, 46);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "QUIT";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonFullScreen
            // 
            this.buttonFullScreen.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonFullScreen.FlatAppearance.BorderSize = 3;
            this.buttonFullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFullScreen.Font = new System.Drawing.Font("MS Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFullScreen.ForeColor = System.Drawing.Color.White;
            this.buttonFullScreen.Location = new System.Drawing.Point(452, 274);
            this.buttonFullScreen.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFullScreen.Name = "buttonFullScreen";
            this.buttonFullScreen.Size = new System.Drawing.Size(109, 46);
            this.buttonFullScreen.TabIndex = 6;
            this.buttonFullScreen.Text = "FULLSCREEN";
            this.buttonFullScreen.UseVisualStyleBackColor = true;
            this.buttonFullScreen.Click += new System.EventHandler(this.buttonFullScreen_Click);
            // 
            // buttonHighScores
            // 
            this.buttonHighScores.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonHighScores.FlatAppearance.BorderSize = 3;
            this.buttonHighScores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHighScores.Font = new System.Drawing.Font("MS Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHighScores.ForeColor = System.Drawing.Color.White;
            this.buttonHighScores.Location = new System.Drawing.Point(452, 224);
            this.buttonHighScores.Margin = new System.Windows.Forms.Padding(2);
            this.buttonHighScores.Name = "buttonHighScores";
            this.buttonHighScores.Size = new System.Drawing.Size(109, 46);
            this.buttonHighScores.TabIndex = 7;
            this.buttonHighScores.Text = "HIGH SCORES";
            this.buttonHighScores.UseVisualStyleBackColor = true;
            this.buttonHighScores.Click += new System.EventHandler(this.buttonHighScores_Click);
            // 
            // buttonInfiniteMode
            // 
            this.buttonInfiniteMode.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonInfiniteMode.FlatAppearance.BorderSize = 3;
            this.buttonInfiniteMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfiniteMode.Font = new System.Drawing.Font("MS Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInfiniteMode.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonInfiniteMode.Location = new System.Drawing.Point(452, 174);
            this.buttonInfiniteMode.Margin = new System.Windows.Forms.Padding(2);
            this.buttonInfiniteMode.Name = "buttonInfiniteMode";
            this.buttonInfiniteMode.Size = new System.Drawing.Size(109, 46);
            this.buttonInfiniteMode.TabIndex = 8;
            this.buttonInfiniteMode.Text = "INFINITE MODE";
            this.buttonInfiniteMode.UseVisualStyleBackColor = true;
            this.buttonInfiniteMode.Click += new System.EventHandler(this.buttonInfiniteMode_Click);
            // 
            // labelControls
            // 
            this.labelControls.BackColor = System.Drawing.Color.Transparent;
            this.labelControls.Font = new System.Drawing.Font("MS PGothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControls.ForeColor = System.Drawing.Color.White;
            this.labelControls.Location = new System.Drawing.Point(2, 122);
            this.labelControls.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelControls.Name = "labelControls";
            this.labelControls.Size = new System.Drawing.Size(370, 216);
            this.labelControls.TabIndex = 9;
            this.labelControls.Text = "[W,A,S,D] To move\r\n[Spacebar] To dodge / parry\r\n[Left Mouse Button] To shoot\r\n[P]" +
    " To pause\r\n";
            this.labelControls.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.labelControls);
            this.Controls.Add(this.buttonInfiniteMode);
            this.Controls.Add(this.buttonHighScores);
            this.Controls.Add(this.buttonFullScreen);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonInsane);
            this.Controls.Add(this.buttonHard);
            this.Controls.Add(this.buttonNormal);
            this.Controls.Add(this.buttonEasy);
            this.Controls.Add(this.labelTitle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(570, 384);
            this.Load += new System.EventHandler(this.MenuScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonEasy;
        private System.Windows.Forms.Button buttonNormal;
        private System.Windows.Forms.Button buttonHard;
        private System.Windows.Forms.Button buttonInsane;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonFullScreen;
        private System.Windows.Forms.Button buttonHighScores;
        private System.Windows.Forms.Button buttonInfiniteMode;
        private System.Windows.Forms.Label labelControls;
    }
}
