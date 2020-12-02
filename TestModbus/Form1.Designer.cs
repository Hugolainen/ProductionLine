namespace TestModbus
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btConnect = new System.Windows.Forms.Button();
            this.tBoxLog = new System.Windows.Forms.TextBox();
            this.btReadInputBits = new System.Windows.Forms.Button();
            this.btReadInputRegisters = new System.Windows.Forms.Button();
            this.btReadCoils = new System.Windows.Forms.Button();
            this.btReadHoldingRegisters = new System.Windows.Forms.Button();
            this.btWriteCoils = new System.Windows.Forms.Button();
            this.btWriteRegisters = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(12, 12);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(119, 51);
            this.btConnect.TabIndex = 0;
            this.btConnect.Text = "Connexion";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // tBoxLog
            // 
            this.tBoxLog.Location = new System.Drawing.Point(12, 261);
            this.tBoxLog.Multiline = true;
            this.tBoxLog.Name = "tBoxLog";
            this.tBoxLog.ReadOnly = true;
            this.tBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBoxLog.Size = new System.Drawing.Size(776, 177);
            this.tBoxLog.TabIndex = 1;
            // 
            // btReadInputBits
            // 
            this.btReadInputBits.Location = new System.Drawing.Point(234, 12);
            this.btReadInputBits.Name = "btReadInputBits";
            this.btReadInputBits.Size = new System.Drawing.Size(119, 51);
            this.btReadInputBits.TabIndex = 2;
            this.btReadInputBits.Text = "Lire input bits";
            this.btReadInputBits.UseVisualStyleBackColor = true;
            this.btReadInputBits.Click += new System.EventHandler(this.btReadInputBits_Click);
            // 
            // btReadInputRegisters
            // 
            this.btReadInputRegisters.Location = new System.Drawing.Point(359, 12);
            this.btReadInputRegisters.Name = "btReadInputRegisters";
            this.btReadInputRegisters.Size = new System.Drawing.Size(119, 51);
            this.btReadInputRegisters.TabIndex = 3;
            this.btReadInputRegisters.Text = "Lire input registers";
            this.btReadInputRegisters.UseVisualStyleBackColor = true;
            this.btReadInputRegisters.Click += new System.EventHandler(this.btReadInputRegisters_Click);
            // 
            // btReadCoils
            // 
            this.btReadCoils.Location = new System.Drawing.Point(234, 69);
            this.btReadCoils.Name = "btReadCoils";
            this.btReadCoils.Size = new System.Drawing.Size(119, 51);
            this.btReadCoils.TabIndex = 4;
            this.btReadCoils.Text = "Lire coils";
            this.btReadCoils.UseVisualStyleBackColor = true;
            this.btReadCoils.Click += new System.EventHandler(this.btReadCoils_Click);
            // 
            // btReadHoldingRegisters
            // 
            this.btReadHoldingRegisters.Location = new System.Drawing.Point(359, 69);
            this.btReadHoldingRegisters.Name = "btReadHoldingRegisters";
            this.btReadHoldingRegisters.Size = new System.Drawing.Size(119, 51);
            this.btReadHoldingRegisters.TabIndex = 5;
            this.btReadHoldingRegisters.Text = "Lire holding registers";
            this.btReadHoldingRegisters.UseVisualStyleBackColor = true;
            this.btReadHoldingRegisters.Click += new System.EventHandler(this.btReadHoldingRegisters_Click);
            // 
            // btWriteCoils
            // 
            this.btWriteCoils.Location = new System.Drawing.Point(537, 12);
            this.btWriteCoils.Name = "btWriteCoils";
            this.btWriteCoils.Size = new System.Drawing.Size(119, 51);
            this.btWriteCoils.TabIndex = 6;
            this.btWriteCoils.Text = "Écrire coils";
            this.btWriteCoils.UseVisualStyleBackColor = true;
            this.btWriteCoils.Click += new System.EventHandler(this.btWriteCoils_Click);
            // 
            // btWriteRegisters
            // 
            this.btWriteRegisters.Location = new System.Drawing.Point(537, 69);
            this.btWriteRegisters.Name = "btWriteRegisters";
            this.btWriteRegisters.Size = new System.Drawing.Size(119, 51);
            this.btWriteRegisters.TabIndex = 7;
            this.btWriteRegisters.Text = "Écrire registrers";
            this.btWriteRegisters.UseVisualStyleBackColor = true;
            this.btWriteRegisters.Click += new System.EventHandler(this.btWriteRegisters_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btWriteRegisters);
            this.Controls.Add(this.btWriteCoils);
            this.Controls.Add(this.btReadHoldingRegisters);
            this.Controls.Add(this.btReadCoils);
            this.Controls.Add(this.btReadInputRegisters);
            this.Controls.Add(this.btReadInputBits);
            this.Controls.Add(this.tBoxLog);
            this.Controls.Add(this.btConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.TextBox tBoxLog;
        private System.Windows.Forms.Button btReadInputBits;
        private System.Windows.Forms.Button btReadInputRegisters;
        private System.Windows.Forms.Button btReadCoils;
        private System.Windows.Forms.Button btReadHoldingRegisters;
        private System.Windows.Forms.Button btWriteCoils;
        private System.Windows.Forms.Button btWriteRegisters;
    }
}

