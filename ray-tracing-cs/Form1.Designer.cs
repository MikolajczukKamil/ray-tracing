
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
            this.zoomControll = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.renderingControl = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.thredsControl = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.smallBallControl = new System.Windows.Forms.CheckBox();
            this.bigBallControl = new System.Windows.Forms.CheckBox();
            this.groundControl = new System.Windows.Forms.CheckBox();
            this.redLightControl = new System.Windows.Forms.CheckBox();
            this.blueLightControl = new System.Windows.Forms.CheckBox();
            this.blue2LightControl = new System.Windows.Forms.CheckBox();
            this.greenLightControl = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.renderedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // renderedImage
            // 
            this.renderedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.renderedImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.renderedImage.Location = new System.Drawing.Point(0, 0);
            this.renderedImage.Name = "renderedImage";
            this.renderedImage.Size = new System.Drawing.Size(850, 761);
            this.renderedImage.TabIndex = 0;
            this.renderedImage.TabStop = false;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(856, 715);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(255, 46);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.start);
            // 
            // zoomControll
            // 
            this.zoomControll.FormattingEnabled = true;
            this.zoomControll.Items.AddRange(new object[] {
            "0.2",
            "0.5",
            "1",
            "1.5",
            "2",
            "5",
            "10"});
            this.zoomControll.Location = new System.Drawing.Point(856, 42);
            this.zoomControll.Name = "zoomControll";
            this.zoomControll.Size = new System.Drawing.Size(255, 23);
            this.zoomControll.TabIndex = 2;
            this.zoomControll.SelectedValue = "1.5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(856, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Zoom";
            // 
            // renderingControl
            // 
            this.renderingControl.FormattingEnabled = true;
            this.renderingControl.Items.AddRange(new object[] {
            "Losowo",
            "Polami"});
            this.renderingControl.Location = new System.Drawing.Point(856, 121);
            this.renderingControl.Name = "renderingControl";
            this.renderingControl.Size = new System.Drawing.Size(255, 23);
            this.renderingControl.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(856, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rendering";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(856, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ilość wątków";
            // 
            // thredsControl
            // 
            this.thredsControl.FormattingEnabled = true;
            this.thredsControl.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64"});
            this.thredsControl.Location = new System.Drawing.Point(856, 197);
            this.thredsControl.Name = "thredsControl";
            this.thredsControl.Size = new System.Drawing.Size(255, 23);
            this.thredsControl.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(856, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Zawartość";
            // 
            // bigBollControl
            // 
            this.smallBallControl.AutoSize = true;
            this.smallBallControl.Location = new System.Drawing.Point(856, 275);
            this.smallBallControl.Name = "smallBallControl";
            this.smallBallControl.Size = new System.Drawing.Size(77, 19);
            this.smallBallControl.TabIndex = 9;
            this.smallBallControl.Text = "Mała kula";
            this.smallBallControl.UseVisualStyleBackColor = true;
            this.smallBallControl.Checked = true;
            // 
            // bigBallControl
            // 
            this.bigBallControl.AutoSize = true;
            this.bigBallControl.Location = new System.Drawing.Point(856, 300);
            this.bigBallControl.Name = "bigBallControl";
            this.bigBallControl.Size = new System.Drawing.Size(77, 19);
            this.bigBallControl.TabIndex = 10;
            this.bigBallControl.Text = "Duża kula";
            this.bigBallControl.UseVisualStyleBackColor = true;
            this.bigBallControl.Checked = true;
            // 
            // groundControl
            // 
            this.groundControl.AutoSize = true;
            this.groundControl.Location = new System.Drawing.Point(856, 325);
            this.groundControl.Name = "groundControl";
            this.groundControl.Size = new System.Drawing.Size(124, 19);
            this.groundControl.TabIndex = 11;
            this.groundControl.Text = "Podłoga szachowa";
            this.groundControl.UseVisualStyleBackColor = true;
            this.groundControl.Checked = true;
            // 
            // redLightControl
            // 
            this.redLightControl.AutoSize = true;
            this.redLightControl.Location = new System.Drawing.Point(857, 383);
            this.redLightControl.Name = "redLightControl";
            this.redLightControl.Size = new System.Drawing.Size(78, 19);
            this.redLightControl.TabIndex = 12;
            this.redLightControl.Text = "Czerwone";
            this.redLightControl.UseVisualStyleBackColor = true;
            this.redLightControl.Checked = true;
            // 
            // blueLightControl
            // 
            this.blueLightControl.AutoSize = true;
            this.blueLightControl.Location = new System.Drawing.Point(857, 408);
            this.blueLightControl.Name = "blueLightControl";
            this.blueLightControl.Size = new System.Drawing.Size(80, 19);
            this.blueLightControl.TabIndex = 13;
            this.blueLightControl.Text = "Niebieskie";
            this.blueLightControl.UseVisualStyleBackColor = true;
            this.blueLightControl.Checked = true;
            // 
            // blue2LightControl
            // 
            this.blue2LightControl.AutoSize = true;
            this.blue2LightControl.Location = new System.Drawing.Point(856, 433);
            this.blue2LightControl.Name = "blue2LightControl";
            this.blue2LightControl.Size = new System.Drawing.Size(106, 19);
            this.blue2LightControl.TabIndex = 14;
            this.blue2LightControl.Text = "Inne Niebieskie";
            this.blue2LightControl.UseVisualStyleBackColor = true;
            this.blue2LightControl.Checked = true;
            // 
            // greenLightControl
            // 
            this.greenLightControl.AutoSize = true;
            this.greenLightControl.Location = new System.Drawing.Point(857, 458);
            this.greenLightControl.Name = "greenLightControl";
            this.greenLightControl.Size = new System.Drawing.Size(65, 19);
            this.greenLightControl.TabIndex = 15;
            this.greenLightControl.Text = "Zielone";
            this.greenLightControl.UseVisualStyleBackColor = true;
            this.greenLightControl.Checked = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(853, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Światła";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 761);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.greenLightControl);
            this.Controls.Add(this.blue2LightControl);
            this.Controls.Add(this.blueLightControl);
            this.Controls.Add(this.redLightControl);
            this.Controls.Add(this.groundControl);
            this.Controls.Add(this.bigBallControl);
            this.Controls.Add(this.smallBallControl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.thredsControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.renderingControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zoomControll);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.renderedImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.renderedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox renderedImage;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ComboBox zoomControll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox renderingControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox thredsControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox smallBallControl;
        private System.Windows.Forms.CheckBox bigBallControl;
        private System.Windows.Forms.CheckBox groundControl;
        private System.Windows.Forms.CheckBox redLightControl;
        private System.Windows.Forms.CheckBox blueLightControl;
        private System.Windows.Forms.CheckBox blue2LightControl;
        private System.Windows.Forms.CheckBox greenLightControl;
        private System.Windows.Forms.Label label5;
    }
}

