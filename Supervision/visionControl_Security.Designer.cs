namespace Supervision
{
    partial class visionControl_Security
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(visionControl_Security));
            this.button_close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_imageControl = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_nbWarning = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_nbDanger = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox_securityLevel = new System.Windows.Forms.PictureBox();
            this.label_securityLevel = new System.Windows.Forms.Label();
            this.label_nbImageControlled = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_imageControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_securityLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // button_close
            // 
            this.button_close.BackColor = System.Drawing.Color.Transparent;
            this.button_close.BackgroundImage = global::Supervision.Properties.Resources.exit_icon;
            this.button_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_close.FlatAppearance.BorderSize = 0;
            this.button_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_close.ForeColor = System.Drawing.Color.Transparent;
            this.button_close.Location = new System.Drawing.Point(436, 7);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(41, 37);
            this.button_close.TabIndex = 6;
            this.button_close.UseVisualStyleBackColor = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Vision control - Security";
            // 
            // pictureBox_imageControl
            // 
            this.pictureBox_imageControl.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_imageControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_imageControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_imageControl.Location = new System.Drawing.Point(28, 51);
            this.pictureBox_imageControl.Name = "pictureBox_imageControl";
            this.pictureBox_imageControl.Size = new System.Drawing.Size(428, 377);
            this.pictureBox_imageControl.TabIndex = 4;
            this.pictureBox_imageControl.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(90)))), ((int)(((byte)(34)))));
            this.label2.Location = new System.Drawing.Point(33, 456);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Security";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 490);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Image controlled : ";
            // 
            // label_nbWarning
            // 
            this.label_nbWarning.AutoSize = true;
            this.label_nbWarning.BackColor = System.Drawing.Color.Transparent;
            this.label_nbWarning.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nbWarning.Location = new System.Drawing.Point(186, 519);
            this.label_nbWarning.Name = "label_nbWarning";
            this.label_nbWarning.Size = new System.Drawing.Size(14, 13);
            this.label_nbWarning.TabIndex = 17;
            this.label_nbWarning.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 519);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Ammount of warnings : ";
            // 
            // label_nbDanger
            // 
            this.label_nbDanger.AutoSize = true;
            this.label_nbDanger.BackColor = System.Drawing.Color.Transparent;
            this.label_nbDanger.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nbDanger.Location = new System.Drawing.Point(186, 547);
            this.label_nbDanger.Name = "label_nbDanger";
            this.label_nbDanger.Size = new System.Drawing.Size(14, 13);
            this.label_nbDanger.TabIndex = 19;
            this.label_nbDanger.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(40, 547);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Ammount of dangers : ";
            // 
            // pictureBox_securityLevel
            // 
            this.pictureBox_securityLevel.BackColor = System.Drawing.Color.Red;
            this.pictureBox_securityLevel.Location = new System.Drawing.Point(39, 577);
            this.pictureBox_securityLevel.Name = "pictureBox_securityLevel";
            this.pictureBox_securityLevel.Size = new System.Drawing.Size(406, 50);
            this.pictureBox_securityLevel.TabIndex = 20;
            this.pictureBox_securityLevel.TabStop = false;
            // 
            // label_securityLevel
            // 
            this.label_securityLevel.BackColor = System.Drawing.Color.Red;
            this.label_securityLevel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_securityLevel.ForeColor = System.Drawing.Color.White;
            this.label_securityLevel.Location = new System.Drawing.Point(154, 594);
            this.label_securityLevel.Name = "label_securityLevel";
            this.label_securityLevel.Size = new System.Drawing.Size(160, 18);
            this.label_securityLevel.TabIndex = 21;
            this.label_securityLevel.Text = "Security level";
            this.label_securityLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_nbImageControlled
            // 
            this.label_nbImageControlled.AutoSize = true;
            this.label_nbImageControlled.BackColor = System.Drawing.Color.Transparent;
            this.label_nbImageControlled.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nbImageControlled.Location = new System.Drawing.Point(186, 490);
            this.label_nbImageControlled.Name = "label_nbImageControlled";
            this.label_nbImageControlled.Size = new System.Drawing.Size(14, 13);
            this.label_nbImageControlled.TabIndex = 22;
            this.label_nbImageControlled.Text = "0";
            // 
            // visionControl_Security
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Supervision.Properties.Resources.visionControlScreen_Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(484, 661);
            this.ControlBox = false;
            this.Controls.Add(this.label_nbImageControlled);
            this.Controls.Add(this.label_securityLevel);
            this.Controls.Add(this.pictureBox_securityLevel);
            this.Controls.Add(this.label_nbDanger);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_nbWarning);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox_imageControl);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 700);
            this.Name = "visionControl_Security";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vision control Security";
            this.Activated += new System.EventHandler(this.visionControl_Security_Activated);
            this.Load += new System.EventHandler(this.visionControl_Security_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_imageControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_securityLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_imageControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_nbWarning;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_nbDanger;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox_securityLevel;
        private System.Windows.Forms.Label label_securityLevel;
        private System.Windows.Forms.Label label_nbImageControlled;
    }
}