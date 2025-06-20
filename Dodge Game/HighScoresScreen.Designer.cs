namespace Dodge_Game
{
    partial class HighScoresScreen
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
            this.labelScoreEasy = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.labelScoreNormal = new System.Windows.Forms.Label();
            this.labelScoreHard = new System.Windows.Forms.Label();
            this.labelScoreInsane = new System.Windows.Forms.Label();
            this.buttonDataErase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelScoreEasy
            // 
            this.labelScoreEasy.Font = new System.Drawing.Font("MS Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScoreEasy.ForeColor = System.Drawing.Color.Lime;
            this.labelScoreEasy.Location = new System.Drawing.Point(311, 188);
            this.labelScoreEasy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScoreEasy.Name = "labelScoreEasy";
            this.labelScoreEasy.Size = new System.Drawing.Size(458, 28);
            this.labelScoreEasy.TabIndex = 13;
            this.labelScoreEasy.Text = "EASY SCORE - 0";
            this.labelScoreEasy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("MS Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(188, 18);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(599, 83);
            this.labelTitle.TabIndex = 12;
            this.labelTitle.Text = "HIGH SCORES";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonMenu
            // 
            this.buttonMenu.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonMenu.FlatAppearance.BorderSize = 3;
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMenu.ForeColor = System.Drawing.Color.White;
            this.buttonMenu.Location = new System.Drawing.Point(380, 477);
            this.buttonMenu.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(176, 46);
            this.buttonMenu.TabIndex = 11;
            this.buttonMenu.Text = "BACK TO MENU";
            this.buttonMenu.UseVisualStyleBackColor = true;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // labelScoreNormal
            // 
            this.labelScoreNormal.Font = new System.Drawing.Font("MS Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScoreNormal.ForeColor = System.Drawing.Color.Orange;
            this.labelScoreNormal.Location = new System.Drawing.Point(311, 227);
            this.labelScoreNormal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScoreNormal.Name = "labelScoreNormal";
            this.labelScoreNormal.Size = new System.Drawing.Size(458, 28);
            this.labelScoreNormal.TabIndex = 14;
            this.labelScoreNormal.Text = "NORMAL SCORE - 0";
            this.labelScoreNormal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelScoreHard
            // 
            this.labelScoreHard.Font = new System.Drawing.Font("MS Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScoreHard.ForeColor = System.Drawing.Color.Red;
            this.labelScoreHard.Location = new System.Drawing.Point(311, 267);
            this.labelScoreHard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScoreHard.Name = "labelScoreHard";
            this.labelScoreHard.Size = new System.Drawing.Size(458, 28);
            this.labelScoreHard.TabIndex = 15;
            this.labelScoreHard.Text = "HARD SCORE - 0";
            this.labelScoreHard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelScoreInsane
            // 
            this.labelScoreInsane.Font = new System.Drawing.Font("MS Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScoreInsane.ForeColor = System.Drawing.Color.Violet;
            this.labelScoreInsane.Location = new System.Drawing.Point(311, 304);
            this.labelScoreInsane.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScoreInsane.Name = "labelScoreInsane";
            this.labelScoreInsane.Size = new System.Drawing.Size(458, 28);
            this.labelScoreInsane.TabIndex = 16;
            this.labelScoreInsane.Text = "INSANE SCORE - 0";
            this.labelScoreInsane.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDataErase
            // 
            this.buttonDataErase.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonDataErase.FlatAppearance.BorderSize = 3;
            this.buttonDataErase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDataErase.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDataErase.ForeColor = System.Drawing.Color.Red;
            this.buttonDataErase.Location = new System.Drawing.Point(380, 427);
            this.buttonDataErase.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDataErase.Name = "buttonDataErase";
            this.buttonDataErase.Size = new System.Drawing.Size(176, 46);
            this.buttonDataErase.TabIndex = 17;
            this.buttonDataErase.Text = "ERASE DATA";
            this.buttonDataErase.UseVisualStyleBackColor = true;
            this.buttonDataErase.Click += new System.EventHandler(this.buttonDataErase_Click);
            // 
            // HighScoresScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.buttonDataErase);
            this.Controls.Add(this.labelScoreInsane);
            this.Controls.Add(this.labelScoreHard);
            this.Controls.Add(this.labelScoreNormal);
            this.Controls.Add(this.labelScoreEasy);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonMenu);
            this.Name = "HighScoresScreen";
            this.Size = new System.Drawing.Size(960, 540);
            this.Load += new System.EventHandler(this.HighScoresScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelScoreEasy;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Label labelScoreNormal;
        private System.Windows.Forms.Label labelScoreHard;
        private System.Windows.Forms.Label labelScoreInsane;
        private System.Windows.Forms.Button buttonDataErase;
    }
}
