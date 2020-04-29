namespace Meteo
{
    partial class PortCOMForm
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
            this.lPort = new System.Windows.Forms.Label();
            this.lBaudrate = new System.Windows.Forms.Label();
            this.lData = new System.Windows.Forms.Label();
            this.lStop = new System.Windows.Forms.Label();
            this.lParity = new System.Windows.Forms.Label();
            this.bConnect = new System.Windows.Forms.Button();
            this.bDisconnect = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lPort
            // 
            this.lPort.AutoSize = true;
            this.lPort.Location = new System.Drawing.Point(37, 41);
            this.lPort.Name = "lPort";
            this.lPort.Size = new System.Drawing.Size(80, 15);
            this.lPort.TabIndex = 0;
            this.lPort.Text = "PORT COM : ";
            // 
            // lBaudrate
            // 
            this.lBaudrate.AutoSize = true;
            this.lBaudrate.Location = new System.Drawing.Point(37, 88);
            this.lBaudrate.Name = "lBaudrate";
            this.lBaudrate.Size = new System.Drawing.Size(66, 15);
            this.lBaudrate.TabIndex = 1;
            this.lBaudrate.Text = "Baudrate : ";
            // 
            // lData
            // 
            this.lData.AutoSize = true;
            this.lData.Location = new System.Drawing.Point(37, 139);
            this.lData.Name = "lData";
            this.lData.Size = new System.Drawing.Size(42, 15);
            this.lData.TabIndex = 2;
            this.lData.Text = "Data : ";
            // 
            // lStop
            // 
            this.lStop.AutoSize = true;
            this.lStop.Location = new System.Drawing.Point(37, 189);
            this.lStop.Name = "lStop";
            this.lStop.Size = new System.Drawing.Size(41, 15);
            this.lStop.TabIndex = 3;
            this.lStop.Text = "Stop : ";
            // 
            // lParity
            // 
            this.lParity.AutoSize = true;
            this.lParity.Location = new System.Drawing.Point(37, 244);
            this.lParity.Name = "lParity";
            this.lParity.Size = new System.Drawing.Size(46, 15);
            this.lParity.TabIndex = 4;
            this.lParity.Text = "Parity : ";
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(40, 285);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(77, 28);
            this.bConnect.TabIndex = 5;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            // 
            // bDisconnect
            // 
            this.bDisconnect.Location = new System.Drawing.Point(145, 285);
            this.bDisconnect.Name = "bDisconnect";
            this.bDisconnect.Size = new System.Drawing.Size(85, 28);
            this.bDisconnect.TabIndex = 6;
            this.bDisconnect.Text = "Disconnect";
            this.bDisconnect.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(158, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(72, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(155, 88);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(72, 21);
            this.comboBox2.TabIndex = 8;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(155, 139);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(75, 21);
            this.comboBox3.TabIndex = 9;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(155, 189);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(72, 21);
            this.comboBox4.TabIndex = 10;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(155, 238);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(72, 21);
            this.comboBox5.TabIndex = 11;
            // 
            // PortCOMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 325);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.bDisconnect);
            this.Controls.Add(this.bConnect);
            this.Controls.Add(this.lParity);
            this.Controls.Add(this.lStop);
            this.Controls.Add(this.lData);
            this.Controls.Add(this.lBaudrate);
            this.Controls.Add(this.lPort);
            this.Name = "PortCOMForm";
            this.Text = "PortCOMForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lPort;
        private System.Windows.Forms.Label lBaudrate;
        private System.Windows.Forms.Label lData;
        private System.Windows.Forms.Label lStop;
        private System.Windows.Forms.Label lParity;
        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.Button bDisconnect;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox5;
    }
}