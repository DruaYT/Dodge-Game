namespace Dodge_Game
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
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("MS Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Lime;
            this.labelTitle.Location = new System.Drawing.Point(194, 49);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(430, 49);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "SELECT DIFFICULTY";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonEasy
            // 
            this.buttonEasy.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.buttonEasy.FlatAppearance.BorderSize = 3;
            this.buttonEasy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEasy.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEasy.ForeColor = System.Drawing.Color.Lime;
            this.buttonEasy.Location = new System.Drawing.Point(258, 121);
            this.buttonEasy.Name = "buttonEasy";
            this.buttonEasy.Size = new System.Drawing.Size(217, 57);
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
            this.buttonNormal.Location = new System.Drawing.Point(258, 193);
            this.buttonNormal.Name = "buttonNormal";
            this.buttonNormal.Size = new System.Drawing.Size(217, 57);
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
            this.buttonHard.Location = new System.Drawing.Point(258, 267);
            this.buttonHard.Name = "buttonHard";
            this.buttonHard.Size = new System.Drawing.Size(217, 57);
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
            this.buttonInsane.Location = new System.Drawing.Point(258, 341);
            this.buttonInsane.Name = "buttonInsane";
            this.buttonInsane.Size = new System.Drawing.Size(217, 57);
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
            this.buttonExit.Location = new System.Drawing.Point(602, 400);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(145, 57);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "QUIT";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonInsane);
            this.Controls.Add(this.buttonHard);
            this.Controls.Add(this.buttonNormal);
            this.Controls.Add(this.buttonEasy);
            this.Controls.Add(this.labelTitle);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(760, 473);
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
    }
}
