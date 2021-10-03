
namespace musix
{
    partial class formSplash
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSplash));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bunifuProgressBar1 = new Bunifu.UI.WinForms.BunifuProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bunifuProgressBar1
            // 
            this.bunifuProgressBar1.AllowAnimations = false;
            this.bunifuProgressBar1.Animation = 0;
            this.bunifuProgressBar1.AnimationSpeed = 30;
            this.bunifuProgressBar1.AnimationStep = 10;
            this.bunifuProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuProgressBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuProgressBar1.BackgroundImage")));
            this.bunifuProgressBar1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuProgressBar1.BorderRadius = 5;
            this.bunifuProgressBar1.BorderThickness = 1;
            this.bunifuProgressBar1.ForeColor = System.Drawing.Color.Transparent;
            this.bunifuProgressBar1.Location = new System.Drawing.Point(50, 275);
            this.bunifuProgressBar1.Maximum = 100;
            this.bunifuProgressBar1.MaximumValue = 100;
            this.bunifuProgressBar1.Minimum = 0;
            this.bunifuProgressBar1.MinimumValue = 0;
            this.bunifuProgressBar1.Name = "bunifuProgressBar1";
            this.bunifuProgressBar1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.bunifuProgressBar1.ProgressBackColor = System.Drawing.Color.Transparent;
            this.bunifuProgressBar1.ProgressColorLeft = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(165)))), ((int)(((byte)(173)))));
            this.bunifuProgressBar1.ProgressColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
            this.bunifuProgressBar1.Size = new System.Drawing.Size(200, 10);
            this.bunifuProgressBar1.TabIndex = 0;
            this.bunifuProgressBar1.Value = 0;
            this.bunifuProgressBar1.ValueByTransition = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(50, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 8;
            this.bunifuElipse1.TargetControl = this;
            // 
            // formSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(300, 310);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bunifuProgressBar1);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formSplash";
            this.Opacity = 0.85D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formSplash";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Bunifu.UI.WinForms.BunifuProgressBar bunifuProgressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}