
namespace ray_tracing_cs
{
    partial class Form1
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.renderedImage = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.renderedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // renderedImage
            // 
            this.renderedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.renderedImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.renderedImage.Location = new System.Drawing.Point(0, 0);
            this.renderedImage.Name = "renderedImage";
            this.renderedImage.Size = new System.Drawing.Size(256, 256);
            this.renderedImage.TabIndex = 0;
            this.renderedImage.TabStop = false;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(277, 210);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(216, 46);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.start);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 256);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.renderedImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.renderedImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox renderedImage;
        private System.Windows.Forms.Button startButton;
    }
}

