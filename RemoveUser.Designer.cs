namespace Meteo
{
    partial class RemoveUser
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.bok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(190, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(84, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username :";
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(64, 166);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(92, 39);
            this.bCancel.TabIndex = 2;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bok
            // 
            this.bok.Location = new System.Drawing.Point(216, 166);
            this.bok.Name = "bok";
            this.bok.Size = new System.Drawing.Size(88, 39);
            this.bok.TabIndex = 3;
            this.bok.Text = "Ok";
            this.bok.UseVisualStyleBackColor = true;
            this.bok.Click += new System.EventHandler(this.bok_Click);
            // 
            // RemoveUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 263);
            this.Controls.Add(this.bok);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "RemoveUser";
            this.Text = "RemoveUser";
            this.Load += new System.EventHandler(this.RemoveUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bok;
    }
}