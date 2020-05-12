using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Meteo
{
    public partial class Form1 : Form
    {

        private User user;
        private List<User> myUsers;


        private int ID;
        private bool bTimer;

        private List<Watchdog> myWatchdogs; //all watchdog

        private List<IdSys> myIdSysMeasures; //id sys
        private List<Measure> myMeasuresConfigured; //measures
        private List<Alarm> myAlarm;//alarms

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myUsers = new List<User>();
            myWatchdogs = new List<Watchdog>();
            myMeasuresConfigured = new List<Measure>();
            myAlarm = new List<Alarm>();
            myIdSysMeasures = new List<IdSys>();

            user = new User("MiddleRights", "12345", 1);

            ID = 0;
            bTimer = false;
            label1.Text = "Your Right Level is : " + user.userAcess.accessKeyId;
            
            createOrReffreshGridConfig();
            createOrReffreshGridMeasure();
            createOrReffreshGridIdSystem();

            setRightLayout();
            catchAllUsers();

            tabIndex.SelectTab(tabConfig);
        }

        //Enable or Disable toolStripMenu 
        private void setRightLayout()
        {
            switch (user.userAcess.accessKeyId)
            {
                case 4:
                    configNewAlarmToolStripMenuItem.Enabled = false;
                    configToolStripMenuItem.Enabled = false;
                    disconfigToolStripMenuItem.Enabled = false;
                    createNewToolStripMenuItem.Enabled = false;
                    removeUserToolStripMenuItem.Enabled = false;
                    break;

                case 3:
                    configToolStripMenuItem.Enabled = false;
                    disconfigToolStripMenuItem.Enabled = false;
                    createNewToolStripMenuItem.Enabled = false;
                    removeUserToolStripMenuItem.Enabled = false;
                    break;

                case 2:
                    disconfigToolStripMenuItem.Enabled = false;
                    createNewToolStripMenuItem.Enabled = false;
                    removeUserToolStripMenuItem.Enabled = false;
                    break;

                case 1:
                    createNewToolStripMenuItem.Enabled = false;
                    removeUserToolStripMenuItem.Enabled = false;
                    break;
            }
        }

        private void catchAllUsers()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mklfs\\source\\repos\\Meteo\\MeteoAccessDB.accdb;Cache Authentication=True";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            try
            {
                dbConnection.Open();

                string req = "SELECT * FROM UserTable";
                OleDbCommand dbCommand = new OleDbCommand(req, dbConnection);
                OleDbDataReader dataReader = dbCommand.ExecuteReader();

                dataReader.Read();

                while (dataReader.HasRows)
                {
                    myUsers.Add(new User(dataReader[1].ToString(), dataReader[2].ToString(), Int32.Parse(dataReader[3].ToString())));
                    Console.WriteLine(dataReader[1].ToString());

                }

                dbConnection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Command !" + exc.Message);
            }
        }

        private void bOnOff_Click(object sender, EventArgs e)
        {
            if (!user.userAcess.allowCreateID)
            {
                MessageBox.Show("You have no right to add ID");
            }
            else
            {

                tabIndex.SelectTab(tabConfig);
                if (!bTimer)
                {
                    timerGenerate.Enabled = true;
                    bOnOff.Text = "TIMER OFF";
                    bTimer = true;
                }
                else
                {
                    timerGenerate.Enabled = false;
                    bOnOff.Text = "TIMER ON";
                    bTimer = false;
                }

            }
        }

        private void createOrReffreshGridConfig()
        {

           CreateorRefreshGrid.createOrRefreshConfigGrid(dataGridView1, myWatchdogs);

        }

        private void createOrReffreshGridMeasure()
        {

            CreateorRefreshGrid.createOrRefreshMesureGrid(dataGridView2,myAlarm,myMeasuresConfigured, myWatchdogs);
        }

        private void createOrReffreshGridIdSystem()
        {
            CreateorRefreshGrid.createOrRefreshIdSysGrid(dataGridView3,myIdSysMeasures);
        }

        

        private void timerGenerate_Tick(object sender, EventArgs e)
        {
            int max = 10;
            if (myWatchdogs.Count <= max)
            {
                myWatchdogs.Add(new Measure(ID++, "undef", "undef", 0, 0));
                createOrReffreshGridConfig();
            }
            else
            {
                myWatchdogs.RemoveAt(0);
            }

        }

        private void bAlarm_Click(object sender, EventArgs e)
        {


        }

        private void sauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (myMeasuresConfigured.Count == 0)
            {
                MessageBox.Show("Config List is Empty ! ");
            }
            else
            {
                String file = "C:\\Users\\mklfs\\source\\repos\\Meteo\\FILELOG.csv";
                StreamWriter sw = new StreamWriter(file);

                foreach (Measure m in myMeasuresConfigured)
                {
                    sw.Write("ID : " + m.ID_Measure + ";\n");
                    sw.Write("Type : " + m.type_Measure + ";\n");
                    sw.Write("Format : " + m.format + ";\n");
                    sw.Write("Min Value : " + m.minValue + ";\n");
                    sw.Write("Max Value : " + m.maxValue + ";\n \n");

                    sw.Write("List of Data : \n");

                    String str = "";
                    foreach (String s in m.data)
                    {
                        str += s + ";\t";
                    }
                    sw.Write(str + ";\n \n");

                }
                MessageBox.Show("File created succesfully ! ");
                sw.Close();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int i = Int32.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());


            if (dataGridView1.Rows[row].Cells[1].Value.Equals("undef") &&
                dataGridView1.Rows[row].Cells[2].Value.Equals("undef"))
            {
                configClick(i);
            }
            else
            {
                disConfig(i);
            }

        }

        private void bConfig_Click(object sender, EventArgs e)
        {

        }

        private void configClick(int id)
        {

            if (timerGenerate.Enabled)
            {
                timerGenerate.Enabled = false;
                bOnOff.Text = "TIMER ON";
            }

            if (myWatchdogs.Count == 0)
            {
                MessageBox.Show("Error ! Measure List is Empty ");
            }
            else
            {
                ConfigMeasureForm f = new ConfigMeasureForm(myWatchdogs, id);
                f.ShowDialog();

                if (f.formType != -1) //isOk
                {
                    Watchdog w = myWatchdogs[f.idMesureConfigured];

                    myMeasuresConfigured.Add(new Measure(w.id,w.type_Measure,w.format,f.iMin,f.iMax));
                    if (myMeasuresConfigured.Count > 10)
                    {
                        myMeasuresConfigured.RemoveAt(0);
                    }
                    createOrReffreshGridConfig();

                    if (f.formType == 1) //idsys or watchdog
                    {
                        myIdSysMeasures.Add(new IdSys(w.id, w.type_Measure, w.format,"","",""));
                        createOrReffreshGridIdSystem();
                    }

                }
                
            }

        }

        private void timerMeasure_Tick(object sender, EventArgs e)
        {
            createOrReffreshGridMeasure();
        }

        private void graphicShow(int idM)
        {
            this.chart1.Series.Clear();
            this.chart1.Titles.Clear();
            Measure mes = null;

            foreach(Measure m in myMeasuresConfigured)
            {
                if(m.id == idM)
                {
                    mes = (Measure)myWatchdogs[idM];
                }
            }
            this.chart1.Titles.Add("Graphic for ID : " + idM);
            Series s = this.chart1.Series.Add("Data Mesure : ");
            s.ChartType = SeriesChartType.Spline;
            foreach (String item in mes.data)
            {
                s.Points.AddY(item);
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            timerGraph.Enabled = true;
            refreshGraph();
        }

        private void timerGraph_Tick(object sender, EventArgs e)
        {
            refreshGraph();
        }

        private void refreshGraph()
        {
            int i = 0;

            try
            {
                Int32.TryParse(cmbIdGraph.Text, out i);
            }
            catch
            {
                MessageBox.Show("Id Graphic Selected not valid  ! ");
            }

            graphicShow(i);
        }

        private void portCOMToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            PortCOMForm pf = new PortCOMForm();
            pf.ShowDialog();

        }
        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectUserForm userForm = new ConnectUserForm();
            userForm.ShowDialog();

            if (userForm.validForm)
            {
                foreach(User u in myUsers)
                {
                    if (u.userName.Equals(userForm.userName))
                    {
                        user = u;
                        MessageBox.Show("Your username is : " + u.userName + ", And your level Access is : " +
                                        u.userAcess);
                    }
                }
            }
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configClick(0);
        }

        private void disconfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (myMeasuresConfigured.Count <= 0)
            {
                MessageBox.Show("Config list is empty ! ");
            }
            else
            {
                disConfig(myMeasuresConfigured[0].ID_Measure);
            }
        }

        private void disConfig(int id)
        {
            DisConfigForm disConfig = new DisConfigForm(user, myMeasuresConfigured, id);
            disConfig.ShowDialog();

            if (disConfig.formOK)
            {
                int pos = disConfig.idRemove;
                for (int i = 0; i < myMeasuresConfigured.Count; i++)
                {
                    if (pos == myMeasuresConfigured[i].ID_Measure)
                    {
                        myMeasuresConfigured.RemoveAt(i);
                    }

                    if (pos == myAlarm[i].id_Alarme)
                    {
                        myAlarm.RemoveAt(i);
                    }
                }
                myWatchdogs.RemoveAt(pos);
                createOrReffreshGridConfig();
                createOrReffreshGridMeasure();
            }
        }

        private void configNewAlarmToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (myMeasuresConfigured.Count == 0)
            {
                MessageBox.Show("Error ! Measure List is Empty ! ");
            }
            else
            {

                AlarmForm f = new AlarmForm(myMeasuresConfigured);
                f.ShowDialog();

                if (f.valid)
                {
                    myAlarm.Add(f.A);
                    cmbIdGraph.Items.Add(f.A.id_Alarme);
                    createOrReffreshGridMeasure();
                    if (!timerMeasure.Enabled)
                    {
                        timerMeasure.Start();
                    }
                }
            }
        }
    }
}
