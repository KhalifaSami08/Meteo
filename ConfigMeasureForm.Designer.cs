namespace Meteo
{
    partial class ConfigMeasureForm
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
            this.l_ID = new System.Windows.Forms.Label();
            this.lMeasureType = new System.Windows.Forms.Label();
            this.lFormat = new System.Windows.Forms.Label();
            this.lmin = new System.Windows.Forms.Label();
            this.lmax = new System.Windows.Forms.Label();
            this.bSubmit = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.cmbMeasureType = new System.Windows.Forms.ComboBox();
            this.cmbFomat = new System.Windows.Forms.ComboBox();
            this.gBoxMinMax = new System.Windows.Forms.GroupBox();
            this.txbMax = new System.Windows.Forms.TextBox();
            this.txbMin = new System.Windows.Forms.TextBox();
            this.cmbID = new System.Windows.Forms.ComboBox();
            this.gBoxMinMax.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_ID
            // 
            this.l_ID.AutoSize = true;
            this.l_ID.Location = new System.Drawing.Point(52, 35);
            this.l_ID.Name = "l_ID";
            this.l_ID.Size = new System.Drawing.Size(28, 15);
            this.l_ID.TabIndex = 0;
            this.l_ID.Text = "ID : ";
            // 
            // lMeasureType
            // 
            this.lMeasureType.AutoSize = true;
            this.lMeasureType.Location = new System.Drawing.Point(157, 35);
            this.lMeasureType.Name = "lMeasureType";
            this.lMeasureType.Size = new System.Drawing.Size(94, 15);
            this.lMeasureType.TabIndex = 1;
            this.lMeasureType.Text = "Measure Type : ";
            // 
            // lFormat
            // 
            this.lFormat.AutoSize = true;
            this.lFormat.Location = new System.Drawing.Point(322, 35);
            this.lFormat.Name = "lFormat";
            this.lFormat.Size = new System.Drawing.Size(89, 15);
            this.lFormat.TabIndex = 2;
            this.lFormat.Text = "Format (Byte) : ";
            // 
            // lmin
            // 
            this.lmin.AutoSize = true;
            this.lmin.Location = new System.Drawing.Point(28, 23);
            this.lmin.Name = "lmin";
            this.lmin.Size = new System.Drawing.Size(37, 15);
            this.lmin.TabIndex = 3;
            this.lmin.Text = "Min : ";
            // 
            // lmax
            // 
            this.lmax.AutoSize = true;
            this.lmax.Location = new System.Drawing.Point(118, 23);
            this.lmax.Name = "lmax";
            this.lmax.Size = new System.Drawing.Size(40, 15);
            this.lmax.TabIndex = 4;
            this.lmax.Text = "Max : ";
            // 
            // bSubmit
            // 
            this.bSubmit.Location = new System.Drawing.Point(41, 152);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(90, 28);
            this.bSubmit.TabIndex = 5;
            this.bSubmit.Text = "Submit";
            this.bSubmit.UseVisualStyleBackColor = true;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(548, 152);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(87, 28);
            this.bCancel.TabIndex = 6;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // cmbMeasureType
            // 
            this.cmbMeasureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeasureType.FormattingEnabled = true;
            this.cmbMeasureType.Location = new System.Drawing.Point(132, 77);
            this.cmbMeasureType.Name = "cmbMeasureType";
            this.cmbMeasureType.Size = new System.Drawing.Size(146, 21);
            this.cmbMeasureType.TabIndex = 12;
            this.cmbMeasureType.TextChanged += new System.EventHandler(this.cmbMeasureType_TextChanged);
            // 
            // cmbFomat
            // 
            this.cmbFomat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFomat.FormattingEnabled = true;
            this.cmbFomat.Location = new System.Drawing.Point(325, 76);
            this.cmbFomat.Name = "cmbFomat";
            this.cmbFomat.Size = new System.Drawing.Size(80, 21);
            this.cmbFomat.TabIndex = 13;
            // 
            // gBoxMinMax
            // 
            this.gBoxMinMax.Controls.Add(this.txbMax);
            this.gBoxMinMax.Controls.Add(this.txbMin);
            this.gBoxMinMax.Controls.Add(this.lmin);
            this.gBoxMinMax.Controls.Add(this.lmax);
            this.gBoxMinMax.Location = new System.Drawing.Point(435, 12);
            this.gBoxMinMax.Name = "gBoxMinMax";
            this.gBoxMinMax.Size = new System.Drawing.Size(200, 123);
            this.gBoxMinMax.TabIndex = 16;
            this.gBoxMinMax.TabStop = false;
            // 
            // txbMax
            // 
            this.txbMax.Location = new System.Drawing.Point(113, 65);
            this.txbMax.Name = "txbMax";
            this.txbMax.Size = new System.Drawing.Size(45, 20);
            this.txbMax.TabIndex = 6;
            // 
            // txbMin
            // 
            this.txbMin.Location = new System.Drawing.Point(31, 64);
            this.txbMin.Name = "txbMin";
            this.txbMin.Size = new System.Drawing.Size(43, 20);
            this.txbMin.TabIndex = 5;
            // 
            // cmbID
            // 
            this.cmbID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbID.FormattingEnabled = true;
            this.cmbID.Location = new System.Drawing.Point(41, 76);
            this.cmbID.Name = "cmbID";
            this.cmbID.Size = new System.Drawing.Size(46, 21);
            this.cmbID.TabIndex = 17;
            // 
            // ConfigMeasureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 197);
            this.Controls.Add(this.cmbID);
            this.Controls.Add(this.gBoxMinMax);
            this.Controls.Add(this.cmbFomat);
            this.Controls.Add(this.cmbMeasureType);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSubmit);
            this.Controls.Add(this.lFormat);
            this.Controls.Add(this.lMeasureType);
            this.Controls.Add(this.l_ID);
            this.Name = "ConfigMeasureForm";
            this.Text = "NewMeasureForm";
            this.Load += new System.EventHandler(this.NewMeasureForm_Load);
            this.gBoxMinMax.ResumeLayout(false);
            this.gBoxMinMax.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_ID;
        private System.Windows.Forms.Label lMeasureType;
        private System.Windows.Forms.Label lFormat;
        private System.Windows.Forms.Label lmin;
        private System.Windows.Forms.Label lmax;
        private System.Windows.Forms.Button bSubmit;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.ComboBox cmbMeasureType;
        private System.Windows.Forms.ComboBox cmbFomat;
        private System.Windows.Forms.GroupBox gBoxMinMax;
        private System.Windows.Forms.ComboBox cmbID;
        private System.Windows.Forms.TextBox txbMax;
        private System.Windows.Forms.TextBox txbMin;
    }
}