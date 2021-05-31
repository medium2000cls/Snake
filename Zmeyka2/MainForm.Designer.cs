
namespace Zmeyka2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            this.BoxEmpty = new System.Windows.Forms.PictureBox();
            this.BoxPlayer = new System.Windows.Forms.PictureBox();
            this.BoxApple = new System.Windows.Forms.PictureBox();
            this.BoxObstacle = new System.Windows.Forms.PictureBox();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.BoxEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.BoxPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.BoxApple)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.BoxObstacle)).BeginInit();
            this.SuspendLayout();
            // 
            // BoxEmpty
            // 
            this.BoxEmpty.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (192)))), ((int) (((byte) (255)))));
            this.BoxEmpty.Location = new System.Drawing.Point(12, 4);
            this.BoxEmpty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BoxEmpty.Name = "BoxEmpty";
            this.BoxEmpty.Size = new System.Drawing.Size(9, 9);
            this.BoxEmpty.TabIndex = 0;
            this.BoxEmpty.TabStop = false;
            // 
            // BoxPlayer
            // 
            this.BoxPlayer.BackColor = System.Drawing.Color.Red;
            this.BoxPlayer.Location = new System.Drawing.Point(27, 4);
            this.BoxPlayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BoxPlayer.Name = "BoxPlayer";
            this.BoxPlayer.Size = new System.Drawing.Size(9, 9);
            this.BoxPlayer.TabIndex = 1;
            this.BoxPlayer.TabStop = false;
            // 
            // BoxApple
            // 
            this.BoxApple.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (128)))), ((int) (((byte) (0)))));
            this.BoxApple.Location = new System.Drawing.Point(42, 4);
            this.BoxApple.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BoxApple.Name = "BoxApple";
            this.BoxApple.Size = new System.Drawing.Size(9, 9);
            this.BoxApple.TabIndex = 2;
            this.BoxApple.TabStop = false;
            // 
            // BoxObstacle
            // 
            this.BoxObstacle.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.BoxObstacle.Location = new System.Drawing.Point(57, 4);
            this.BoxObstacle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BoxObstacle.Name = "BoxObstacle";
            this.BoxObstacle.Size = new System.Drawing.Size(9, 9);
            this.BoxObstacle.TabIndex = 3;
            this.BoxObstacle.TabStop = false;
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(484, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(571, 731);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.BoxObstacle);
            this.Controls.Add(this.BoxApple);
            this.Controls.Add(this.BoxPlayer);
            this.Controls.Add(this.BoxEmpty);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Змейка";
            ((System.ComponentModel.ISupportInitialize) (this.BoxEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.BoxPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.BoxApple)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.BoxObstacle)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button buttonStart;

        #endregion

        private System.Windows.Forms.PictureBox BoxEmpty;
        private System.Windows.Forms.PictureBox BoxPlayer;
        private System.Windows.Forms.PictureBox BoxApple;
        private System.Windows.Forms.PictureBox BoxObstacle;
    }
}

