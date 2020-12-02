namespace Supervision
{
    partial class startingScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(startingScreen));
            this.button_goToLocalScreen = new System.Windows.Forms.Button();
            this.button_goToFieldScreen = new System.Windows.Forms.Button();
            this.button_connect = new System.Windows.Forms.Button();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.label_welcoming = new System.Windows.Forms.Label();
            this.pictureBox_User = new System.Windows.Forms.PictureBox();
            this.label_username = new System.Windows.Forms.Label();
            this.label_user = new System.Windows.Forms.Label();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.pictureBox_localScreen1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_localScreen2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_fieldScreen2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_fieldScreen1 = new System.Windows.Forms.PictureBox();
            this.button_goToGlobalScreen = new System.Windows.Forms.Button();
            this.pictureBox_globalScreen = new System.Windows.Forms.PictureBox();
            this.textBox_connectModbus_IP = new System.Windows.Forms.TextBox();
            this.button_connectModbus = new System.Windows.Forms.Button();
            this.textBox_connectModbus_Port = new System.Windows.Forms.TextBox();
            this.label_ModbusIP = new System.Windows.Forms.Label();
            this.label_ModbusPort = new System.Windows.Forms.Label();
            this.label_rtInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_User)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_localScreen1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_localScreen2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fieldScreen2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fieldScreen1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_globalScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // button_goToLocalScreen
            // 
            this.button_goToLocalScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(56)))));
            this.button_goToLocalScreen.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_goToLocalScreen.ForeColor = System.Drawing.Color.White;
            this.button_goToLocalScreen.Location = new System.Drawing.Point(547, 249);
            this.button_goToLocalScreen.Name = "button_goToLocalScreen";
            this.button_goToLocalScreen.Size = new System.Drawing.Size(260, 37);
            this.button_goToLocalScreen.TabIndex = 0;
            this.button_goToLocalScreen.Text = "Local";
            this.button_goToLocalScreen.UseVisualStyleBackColor = false;
            this.button_goToLocalScreen.Click += new System.EventHandler(this.button_goToLocalScreen_Click);
            // 
            // button_goToFieldScreen
            // 
            this.button_goToFieldScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(56)))));
            this.button_goToFieldScreen.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_goToFieldScreen.ForeColor = System.Drawing.Color.White;
            this.button_goToFieldScreen.Location = new System.Drawing.Point(547, 379);
            this.button_goToFieldScreen.Name = "button_goToFieldScreen";
            this.button_goToFieldScreen.Size = new System.Drawing.Size(260, 37);
            this.button_goToFieldScreen.TabIndex = 1;
            this.button_goToFieldScreen.Text = "Field";
            this.button_goToFieldScreen.UseVisualStyleBackColor = false;
            this.button_goToFieldScreen.Click += new System.EventHandler(this.button_goToFieldScreen_Click);
            // 
            // button_connect
            // 
            this.button_connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(194)))), ((int)(((byte)(31)))));
            this.button_connect.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_connect.Location = new System.Drawing.Point(265, 390);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(155, 55);
            this.button_connect.TabIndex = 3;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = false;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // textBox_username
            // 
            this.textBox_username.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_username.Location = new System.Drawing.Point(195, 272);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(227, 27);
            this.textBox_username.TabIndex = 5;
            // 
            // textBox_password
            // 
            this.textBox_password.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_password.Location = new System.Drawing.Point(193, 347);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(227, 27);
            this.textBox_password.TabIndex = 6;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.BackColor = System.Drawing.Color.Transparent;
            this.label_password.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_password.Location = new System.Drawing.Point(164, 317);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(113, 23);
            this.label_password.TabIndex = 7;
            this.label_password.Text = "Password";
            // 
            // label_welcoming
            // 
            this.label_welcoming.AutoSize = true;
            this.label_welcoming.BackColor = System.Drawing.Color.Transparent;
            this.label_welcoming.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_welcoming.ForeColor = System.Drawing.Color.White;
            this.label_welcoming.Location = new System.Drawing.Point(78, 20);
            this.label_welcoming.Name = "label_welcoming";
            this.label_welcoming.Size = new System.Drawing.Size(211, 45);
            this.label_welcoming.TabIndex = 8;
            this.label_welcoming.Text = "Welcome";
            // 
            // pictureBox_User
            // 
            this.pictureBox_User.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_User.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_User.InitialImage = null;
            this.pictureBox_User.Location = new System.Drawing.Point(78, 100);
            this.pictureBox_User.MaximumSize = new System.Drawing.Size(65, 100);
            this.pictureBox_User.MinimumSize = new System.Drawing.Size(65, 100);
            this.pictureBox_User.Name = "pictureBox_User";
            this.pictureBox_User.Size = new System.Drawing.Size(65, 100);
            this.pictureBox_User.TabIndex = 9;
            this.pictureBox_User.TabStop = false;
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.BackColor = System.Drawing.Color.Transparent;
            this.label_username.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_username.Location = new System.Drawing.Point(159, 238);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(118, 23);
            this.label_username.TabIndex = 4;
            this.label_username.Text = "Username";
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.BackColor = System.Drawing.Color.Transparent;
            this.label_user.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_user.Location = new System.Drawing.Point(149, 100);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(204, 23);
            this.label_user.TabIndex = 10;
            this.label_user.Text = "No one connected";
            // 
            // button_disconnect
            // 
            this.button_disconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(90)))), ((int)(((byte)(34)))));
            this.button_disconnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_disconnect.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_disconnect.Location = new System.Drawing.Point(163, 136);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(190, 64);
            this.button_disconnect.TabIndex = 11;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = false;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.Transparent;
            this.button_exit.BackgroundImage = global::Supervision.Properties.Resources.exit_icon;
            this.button_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_exit.FlatAppearance.BorderSize = 0;
            this.button_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.ForeColor = System.Drawing.Color.Transparent;
            this.button_exit.Location = new System.Drawing.Point(12, 13);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(56, 54);
            this.button_exit.TabIndex = 12;
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // pictureBox_localScreen1
            // 
            this.pictureBox_localScreen1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_localScreen1.BackgroundImage = global::Supervision.Properties.Resources.factory1_icon;
            this.pictureBox_localScreen1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_localScreen1.Location = new System.Drawing.Point(547, 292);
            this.pictureBox_localScreen1.Name = "pictureBox_localScreen1";
            this.pictureBox_localScreen1.Size = new System.Drawing.Size(104, 70);
            this.pictureBox_localScreen1.TabIndex = 14;
            this.pictureBox_localScreen1.TabStop = false;
            // 
            // pictureBox_localScreen2
            // 
            this.pictureBox_localScreen2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_localScreen2.BackgroundImage = global::Supervision.Properties.Resources.factory2_icon;
            this.pictureBox_localScreen2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_localScreen2.Location = new System.Drawing.Point(695, 292);
            this.pictureBox_localScreen2.Name = "pictureBox_localScreen2";
            this.pictureBox_localScreen2.Size = new System.Drawing.Size(112, 70);
            this.pictureBox_localScreen2.TabIndex = 15;
            this.pictureBox_localScreen2.TabStop = false;
            // 
            // pictureBox_fieldScreen2
            // 
            this.pictureBox_fieldScreen2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_fieldScreen2.BackgroundImage = global::Supervision.Properties.Resources.bottleLine_icon;
            this.pictureBox_fieldScreen2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_fieldScreen2.Location = new System.Drawing.Point(695, 422);
            this.pictureBox_fieldScreen2.Name = "pictureBox_fieldScreen2";
            this.pictureBox_fieldScreen2.Size = new System.Drawing.Size(112, 91);
            this.pictureBox_fieldScreen2.TabIndex = 16;
            this.pictureBox_fieldScreen2.TabStop = false;
            // 
            // pictureBox_fieldScreen1
            // 
            this.pictureBox_fieldScreen1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_fieldScreen1.BackgroundImage = global::Supervision.Properties.Resources.fieldScren_icon;
            this.pictureBox_fieldScreen1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_fieldScreen1.Location = new System.Drawing.Point(547, 422);
            this.pictureBox_fieldScreen1.Name = "pictureBox_fieldScreen1";
            this.pictureBox_fieldScreen1.Size = new System.Drawing.Size(112, 91);
            this.pictureBox_fieldScreen1.TabIndex = 17;
            this.pictureBox_fieldScreen1.TabStop = false;
            // 
            // button_goToGlobalScreen
            // 
            this.button_goToGlobalScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(56)))));
            this.button_goToGlobalScreen.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_goToGlobalScreen.ForeColor = System.Drawing.Color.White;
            this.button_goToGlobalScreen.Location = new System.Drawing.Point(547, 104);
            this.button_goToGlobalScreen.Name = "button_goToGlobalScreen";
            this.button_goToGlobalScreen.Size = new System.Drawing.Size(260, 38);
            this.button_goToGlobalScreen.TabIndex = 0;
            this.button_goToGlobalScreen.Text = "Global";
            this.button_goToGlobalScreen.UseVisualStyleBackColor = false;
            this.button_goToGlobalScreen.Click += new System.EventHandler(this.button_goToGlobaleScreen_Click);
            // 
            // pictureBox_globalScreen
            // 
            this.pictureBox_globalScreen.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_globalScreen.BackgroundImage = global::Supervision.Properties.Resources.globalScreen_icon;
            this.pictureBox_globalScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_globalScreen.Location = new System.Drawing.Point(573, 148);
            this.pictureBox_globalScreen.Name = "pictureBox_globalScreen";
            this.pictureBox_globalScreen.Size = new System.Drawing.Size(211, 92);
            this.pictureBox_globalScreen.TabIndex = 13;
            this.pictureBox_globalScreen.TabStop = false;
            // 
            // textBox_connectModbus_IP
            // 
            this.textBox_connectModbus_IP.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_connectModbus_IP.Location = new System.Drawing.Point(320, 20);
            this.textBox_connectModbus_IP.Name = "textBox_connectModbus_IP";
            this.textBox_connectModbus_IP.Size = new System.Drawing.Size(194, 23);
            this.textBox_connectModbus_IP.TabIndex = 18;
            this.textBox_connectModbus_IP.Text = "Runtime IP address";
            // 
            // button_connectModbus
            // 
            this.button_connectModbus.Location = new System.Drawing.Point(520, 20);
            this.button_connectModbus.Name = "button_connectModbus";
            this.button_connectModbus.Size = new System.Drawing.Size(75, 47);
            this.button_connectModbus.TabIndex = 19;
            this.button_connectModbus.Text = "Connect";
            this.button_connectModbus.UseVisualStyleBackColor = true;
            this.button_connectModbus.Click += new System.EventHandler(this.button_connectModbus_Click);
            // 
            // textBox_connectModbus_Port
            // 
            this.textBox_connectModbus_Port.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_connectModbus_Port.Location = new System.Drawing.Point(320, 44);
            this.textBox_connectModbus_Port.Name = "textBox_connectModbus_Port";
            this.textBox_connectModbus_Port.Size = new System.Drawing.Size(194, 23);
            this.textBox_connectModbus_Port.TabIndex = 20;
            this.textBox_connectModbus_Port.Text = "Runtime port";
            // 
            // label_ModbusIP
            // 
            this.label_ModbusIP.AutoSize = true;
            this.label_ModbusIP.BackColor = System.Drawing.Color.Transparent;
            this.label_ModbusIP.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ModbusIP.ForeColor = System.Drawing.Color.White;
            this.label_ModbusIP.Location = new System.Drawing.Point(317, 35);
            this.label_ModbusIP.Name = "label_ModbusIP";
            this.label_ModbusIP.Size = new System.Drawing.Size(82, 18);
            this.label_ModbusIP.TabIndex = 21;
            this.label_ModbusIP.Text = "modbusIP";
            // 
            // label_ModbusPort
            // 
            this.label_ModbusPort.AutoSize = true;
            this.label_ModbusPort.BackColor = System.Drawing.Color.Transparent;
            this.label_ModbusPort.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ModbusPort.ForeColor = System.Drawing.Color.White;
            this.label_ModbusPort.Location = new System.Drawing.Point(317, 55);
            this.label_ModbusPort.Name = "label_ModbusPort";
            this.label_ModbusPort.Size = new System.Drawing.Size(99, 18);
            this.label_ModbusPort.TabIndex = 22;
            this.label_ModbusPort.Text = "modbusPort";
            // 
            // label_rtInfo
            // 
            this.label_rtInfo.AutoSize = true;
            this.label_rtInfo.BackColor = System.Drawing.Color.Transparent;
            this.label_rtInfo.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_rtInfo.ForeColor = System.Drawing.Color.White;
            this.label_rtInfo.Location = new System.Drawing.Point(317, 13);
            this.label_rtInfo.Name = "label_rtInfo";
            this.label_rtInfo.Size = new System.Drawing.Size(176, 18);
            this.label_rtInfo.TabIndex = 23;
            this.label_rtInfo.Text = "Runtime information";
            // 
            // startingScreen
            // 
            this.AcceptButton = this.button_connect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Supervision.Properties.Resources.startingPage_Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.button_disconnect;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.ControlBox = false;
            this.Controls.Add(this.label_rtInfo);
            this.Controls.Add(this.label_ModbusPort);
            this.Controls.Add(this.label_ModbusIP);
            this.Controls.Add(this.textBox_connectModbus_Port);
            this.Controls.Add(this.button_connectModbus);
            this.Controls.Add(this.textBox_connectModbus_IP);
            this.Controls.Add(this.pictureBox_globalScreen);
            this.Controls.Add(this.pictureBox_fieldScreen1);
            this.Controls.Add(this.button_goToGlobalScreen);
            this.Controls.Add(this.pictureBox_fieldScreen2);
            this.Controls.Add(this.pictureBox_localScreen2);
            this.Controls.Add(this.pictureBox_localScreen1);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.label_user);
            this.Controls.Add(this.pictureBox_User);
            this.Controls.Add(this.label_welcoming);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.button_goToFieldScreen);
            this.Controls.Add(this.button_goToLocalScreen);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "startingScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chaine de production virtuelle";
            this.Activated += new System.EventHandler(this.startingScreen_Activated);
            this.Shown += new System.EventHandler(this.startingScreen_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_User)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_localScreen1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_localScreen2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fieldScreen2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fieldScreen1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_globalScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_goToLocalScreen;
        private System.Windows.Forms.Button button_goToFieldScreen;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label_welcoming;
        private System.Windows.Forms.PictureBox pictureBox_User;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.PictureBox pictureBox_localScreen1;
        private System.Windows.Forms.PictureBox pictureBox_localScreen2;
        private System.Windows.Forms.PictureBox pictureBox_fieldScreen2;
        private System.Windows.Forms.PictureBox pictureBox_fieldScreen1;
        private System.Windows.Forms.Button button_goToGlobalScreen;
        private System.Windows.Forms.PictureBox pictureBox_globalScreen;
        private System.Windows.Forms.TextBox textBox_connectModbus_IP;
        private System.Windows.Forms.Button button_connectModbus;
        private System.Windows.Forms.TextBox textBox_connectModbus_Port;
        private System.Windows.Forms.Label label_ModbusIP;
        private System.Windows.Forms.Label label_ModbusPort;
        private System.Windows.Forms.Label label_rtInfo;
    }
}