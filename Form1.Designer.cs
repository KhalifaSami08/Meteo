namespace Meteo
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timerGenerate = new System.Windows.Forms.Timer(this.components);
            this.bOnOff = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sauvegarderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pORTCOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portCOMToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alarmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configNewAlarmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabGraphics = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbIdGraph = new System.Windows.Forms.ComboBox();
            this.tabIdSystem = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabMeasure = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabIndex = new System.Windows.Forms.TabControl();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timerMeasure = new System.Windows.Forms.Timer(this.components);
            this.timerGraph = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabGraphics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabIdSystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabMeasure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabIndex.SuspendLayout();
            this.tabConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerGenerate
            // 
            this.timerGenerate.Interval = 1000;
            this.timerGenerate.Tick += new System.EventHandler(this.timerGenerate_Tick);
            // 
            // bOnOff
            // 
            this.bOnOff.Location = new System.Drawing.Point(310, 53);
            this.bOnOff.Name = "bOnOff";
            this.bOnOff.Size = new System.Drawing.Size(119, 37);
            this.bOnOff.TabIndex = 1;
            this.bOnOff.Text = "TIMER ON";
            this.bOnOff.UseVisualStyleBackColor = true;
            this.bOnOff.Click += new System.EventHandler(this.bOnOff_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.connexionToolStripMenuItem,
            this.userToolStripMenuItem,
            this.configurationsToolStripMenuItem,
            this.alarmToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(742, 27);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sauvegarderToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // sauvegarderToolStripMenuItem
            // 
            this.sauvegarderToolStripMenuItem.Name = "sauvegarderToolStripMenuItem";
            this.sauvegarderToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.sauvegarderToolStripMenuItem.Text = "Save";
            this.sauvegarderToolStripMenuItem.Click += new System.EventHandler(this.sauvegarderToolStripMenuItem_Click);
            // 
            // connexionToolStripMenuItem
            // 
            this.connexionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pORTCOMToolStripMenuItem,
            this.portCOMToolStripMenuItem1});
            this.connexionToolStripMenuItem.Name = "connexionToolStripMenuItem";
            this.connexionToolStripMenuItem.Size = new System.Drawing.Size(86, 23);
            this.connexionToolStripMenuItem.Text = "Connexion";
            // 
            // pORTCOMToolStripMenuItem
            // 
            this.pORTCOMToolStripMenuItem.Name = "pORTCOMToolStripMenuItem";
            this.pORTCOMToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.pORTCOMToolStripMenuItem.Text = "Local";
            // 
            // portCOMToolStripMenuItem1
            // 
            this.portCOMToolStripMenuItem1.Name = "portCOMToolStripMenuItem1";
            this.portCOMToolStripMenuItem1.Size = new System.Drawing.Size(146, 24);
            this.portCOMToolStripMenuItem1.Text = "Port COM";
            this.portCOMToolStripMenuItem1.Click += new System.EventHandler(this.portCOMToolStripMenuItem1_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.createNewToolStripMenuItem,
            this.removeUserToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(49, 23);
            this.userToolStripMenuItem.Text = "User";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // createNewToolStripMenuItem
            // 
            this.createNewToolStripMenuItem.Name = "createNewToolStripMenuItem";
            this.createNewToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.createNewToolStripMenuItem.Text = "Create User";
            this.createNewToolStripMenuItem.Click += new System.EventHandler(this.createNewToolStripMenuItem_Click);
            // 
            // removeUserToolStripMenuItem
            // 
            this.removeUserToolStripMenuItem.Name = "removeUserToolStripMenuItem";
            this.removeUserToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.removeUserToolStripMenuItem.Text = "Remove User";
            this.removeUserToolStripMenuItem.Click += new System.EventHandler(this.removeUserToolStripMenuItem_Click);
            // 
            // configurationsToolStripMenuItem
            // 
            this.configurationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.disconfigToolStripMenuItem});
            this.configurationsToolStripMenuItem.Name = "configurationsToolStripMenuItem";
            this.configurationsToolStripMenuItem.Size = new System.Drawing.Size(111, 23);
            this.configurationsToolStripMenuItem.Text = "Configurations";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.configToolStripMenuItem.Text = "Config ID";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // disconfigToolStripMenuItem
            // 
            this.disconfigToolStripMenuItem.Name = "disconfigToolStripMenuItem";
            this.disconfigToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.disconfigToolStripMenuItem.Text = "Disconfig ID";
            this.disconfigToolStripMenuItem.Click += new System.EventHandler(this.disconfigToolStripMenuItem_Click);
            // 
            // alarmToolStripMenuItem
            // 
            this.alarmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configNewAlarmToolStripMenuItem});
            this.alarmToolStripMenuItem.Name = "alarmToolStripMenuItem";
            this.alarmToolStripMenuItem.Size = new System.Drawing.Size(57, 23);
            this.alarmToolStripMenuItem.Text = "Alarm";
            // 
            // configNewAlarmToolStripMenuItem
            // 
            this.configNewAlarmToolStripMenuItem.Name = "configNewAlarmToolStripMenuItem";
            this.configNewAlarmToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.configNewAlarmToolStripMenuItem.Text = "New Alarm";
            this.configNewAlarmToolStripMenuItem.Click += new System.EventHandler(this.configNewAlarmToolStripMenuItem_Click);
            // 
            // tabGraphics
            // 
            this.tabGraphics.Controls.Add(this.chart1);
            this.tabGraphics.Controls.Add(this.cmbIdGraph);
            this.tabGraphics.Location = new System.Drawing.Point(4, 22);
            this.tabGraphics.Name = "tabGraphics";
            this.tabGraphics.Padding = new System.Windows.Forms.Padding(3);
            this.tabGraphics.Size = new System.Drawing.Size(565, 321);
            this.tabGraphics.TabIndex = 4;
            this.tabGraphics.Text = "Graphics";
            this.tabGraphics.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(16, 49);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(530, 246);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // cmbIdGraph
            // 
            this.cmbIdGraph.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdGraph.FormattingEnabled = true;
            this.cmbIdGraph.Location = new System.Drawing.Point(246, 22);
            this.cmbIdGraph.Name = "cmbIdGraph";
            this.cmbIdGraph.Size = new System.Drawing.Size(70, 21);
            this.cmbIdGraph.TabIndex = 0;
            this.cmbIdGraph.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // tabIdSystem
            // 
            this.tabIdSystem.Controls.Add(this.dataGridView3);
            this.tabIdSystem.Location = new System.Drawing.Point(4, 22);
            this.tabIdSystem.Name = "tabIdSystem";
            this.tabIdSystem.Padding = new System.Windows.Forms.Padding(3);
            this.tabIdSystem.Size = new System.Drawing.Size(565, 321);
            this.tabIdSystem.TabIndex = 2;
            this.tabIdSystem.Text = "Id System";
            this.tabIdSystem.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(6, 6);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 45;
            this.dataGridView3.Size = new System.Drawing.Size(553, 309);
            this.dataGridView3.TabIndex = 0;
            // 
            // tabMeasure
            // 
            this.tabMeasure.Controls.Add(this.dataGridView2);
            this.tabMeasure.Location = new System.Drawing.Point(4, 22);
            this.tabMeasure.Name = "tabMeasure";
            this.tabMeasure.Padding = new System.Windows.Forms.Padding(3);
            this.tabMeasure.Size = new System.Drawing.Size(565, 321);
            this.tabMeasure.TabIndex = 0;
            this.tabMeasure.Text = "Measure";
            this.tabMeasure.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.Location = new System.Drawing.Point(6, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 45;
            this.dataGridView2.Size = new System.Drawing.Size(550, 309);
            this.dataGridView2.TabIndex = 0;
            // 
            // tabIndex
            // 
            this.tabIndex.Controls.Add(this.tabMeasure);
            this.tabIndex.Controls.Add(this.tabIdSystem);
            this.tabIndex.Controls.Add(this.tabGraphics);
            this.tabIndex.Controls.Add(this.tabConfig);
            this.tabIndex.Location = new System.Drawing.Point(94, 105);
            this.tabIndex.Name = "tabIndex";
            this.tabIndex.SelectedIndex = 0;
            this.tabIndex.Size = new System.Drawing.Size(573, 347);
            this.tabIndex.TabIndex = 0;
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.dataGridView1);
            this.tabConfig.Location = new System.Drawing.Point(4, 22);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(565, 321);
            this.tabConfig.TabIndex = 6;
            this.tabConfig.Text = "Config";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.Location = new System.Drawing.Point(5, 8);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 45;
            this.dataGridView1.Size = new System.Drawing.Size(554, 310);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // timerMeasure
            // 
            this.timerMeasure.Interval = 1000;
            this.timerMeasure.Tick += new System.EventHandler(this.timerMeasure_Tick);
            // 
            // timerGraph
            // 
            this.timerGraph.Interval = 1000;
            this.timerGraph.Tick += new System.EventHandler(this.timerGraph_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(508, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "   ";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 477);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bOnOff);
            this.Controls.Add(this.tabIndex);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabGraphics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabIdSystem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabMeasure.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabIndex.ResumeLayout(false);
            this.tabConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerGenerate;
        private System.Windows.Forms.Button bOnOff;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sauvegarderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connexionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pORTCOMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portCOMToolStripMenuItem1;
        private System.Windows.Forms.TabPage tabGraphics;
        private System.Windows.Forms.TabPage tabIdSystem;
        private System.Windows.Forms.TabPage tabMeasure;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabControl tabIndex;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timerMeasure;
        private System.Windows.Forms.ComboBox cmbIdGraph;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timerGraph;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alarmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configNewAlarmToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
    }
}

