namespace Meteo
{
    partial class AlarmForm
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
            this.Lid = new System.Windows.Forms.Label();
            this.cmbID = new System.Windows.Forms.ComboBox();
            this.lMin = new System.Windows.Forms.Label();
            this.lMax = new System.Windows.Forms.Label();
            this.txbMin = new System.Windows.Forms.TextBox();
            this.txbMax = new System.Windows.Forms.TextBox();
            this.bValid = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lid
            // 
            this.Lid.AutoSize = true;
            this.Lid.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lid.Location = new System.Drawing.Point(98, 26);
            this.Lid.Name = "Lid";
            this.Lid.Size = new System.Drawing.Size(50, 25);
            this.Lid.TabIndex = 0;
            this.Lid.Text = "ID : ";
            // 
            // cmbID
            // 
            this.cmbID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbID.FormattingEnabled = true;
            this.cmbID.Location = new System.Drawing.Point(97, 68);
            this.cmbID.Name = "cmbID";
            this.cmbID.Size = new System.Drawing.Size(66, 21);
            this.cmbID.TabIndex = 1;
            // 
            // lMin
            // 
            this.lMin.AutoSize = true;
            this.lMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMin.Location = new System.Drawing.Point(66, 117);
            this.lMin.Name = "lMin";
            this.lMin.Size = new System.Drawing.Size(124, 25);
            this.lMin.TabIndex = 2;
            this.lMin.Text = "Min alarm : ";
            // 
            // lMax
            // 
            this.lMax.AutoSize = true;
            this.lMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMax.Location = new System.Drawing.Point(66, 223);
            this.lMax.Name = "lMax";
            this.lMax.Size = new System.Drawing.Size(130, 25);
            this.lMax.TabIndex = 3;
            this.lMax.Text = "Max alarm : ";
            // 
            // txbMin
            // 
            this.txbMin.Location = new System.Drawing.Point(97, 165);
            this.txbMin.Name = "txbMin";
            this.txbMin.Size = new System.Drawing.Size(66, 20);
            this.txbMin.TabIndex = 4;
            // 
            // txbMax
            // 
            this.txbMax.Location = new System.Drawing.Point(97, 283);
            this.txbMax.Name = "txbMax";
            this.txbMax.Size = new System.Drawing.Size(66, 20);
            this.txbMax.TabIndex = 5;
            // 
            // bValid
            // 
            this.bValid.Location = new System.Drawing.Point(71, 336);
            this.bValid.Name = "bValid";
            this.bValid.Size = new System.Drawing.Size(122, 31);
            this.bValid.TabIndex = 6;
            this.bValid.Text = "Valid";
            this.bValid.UseVisualStyleBackColor = true;
            this.bValid.Click += new System.EventHandler(this.bValid_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(71, 386);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(122, 32);
            this.bCancel.TabIndex = 7;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // AlarmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 442);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bValid);
            this.Controls.Add(this.txbMax);
            this.Controls.Add(this.txbMin);
            this.Controls.Add(this.lMax);
            this.Controls.Add(this.lMin);
            this.Controls.Add(this.cmbID);
            this.Controls.Add(this.Lid);
            this.Name = "AlarmForm";
            this.Text = "AlarmForm";
            this.Load += new System.EventHandler(this.AlarmForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lid;
        private System.Windows.Forms.ComboBox cmbID;
        private System.Windows.Forms.Label lMin;
        private System.Windows.Forms.Label lMax;
        private System.Windows.Forms.TextBox txbMin;
        private System.Windows.Forms.TextBox txbMax;
        private System.Windows.Forms.Button bValid;
        private System.Windows.Forms.Button bCancel;
    }
}