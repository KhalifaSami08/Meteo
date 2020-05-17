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

            user = new User(0, "12345");

            ID = 0;
            bTimer = false;

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
            changeLabel();

        }

        private void catchAllUsers()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mklfs\\source\\repos\\Meteo\\Meteo\\Files\\MeteoAccessDB.accdb;Cache Authentication=True";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            try
            {
                dbConnection.Open();

                string req = "SELECT * FROM UserTable";
                OleDbCommand dbCommand = new OleDbCommand(req, dbConnection);
                OleDbDataReader dataReader = dbCommand.ExecuteReader();

                //dataReader.Read();

                while (dataReader.Read())
                {
                    myUsers.Add( new User( dataReader[1].ToString(), dataReader[2].ToString(), Int32.Parse(dataReader[3].ToString())) );

                }

                dbConnection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Command !" + exc.Message);
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectUserForm userForm = new ConnectUserForm(myUsers);
            userForm.ShowDialog();

            if (userForm.validForm)
            {
                foreach (User u in myUsers)
                {
                    if (u.userName.Equals(userForm.userName))
                    {
                        user = userForm.myUser;
                        setRightLayout();
                    }
                }
            }
        }
        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUser cu = new CreateUser(myUsers);
            cu.ShowDialog();
            user = cu.u;
            setRightLayout();
        }

        private void removeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveUser rm = new RemoveUser(myUsers);
            rm.ShowDialog();
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

        private void changeLabel()
        {
            label1.Text = "Your username is : " + user.userName + "\n And your level Access is : " +
                                        user.userAcess.accessName;
        }

        private void createOrReffreshGridConfig()
        {

            CreateorRefreshGrid.createOrRefreshConfigGrid(dataGridView1, myWatchdogs, myMeasuresConfigured);

        }

        private void createOrReffreshGridMeasure()
        {
            CreateorRefreshGrid.createOrRefreshMesureGrid(dataGridView2, myAlarm, myMeasuresConfigured, myWatchdogs);
        }

        private void createOrReffreshGridIdSystem()
        {
            CreateorRefreshGrid.createOrRefreshIdSysGrid(dataGridView3, myIdSysMeasures);
        }



        private void timerGenerate_Tick(object sender, EventArgs e)
        {
            int max = 10;
            if (myWatchdogs.Count <= max)
            {
                myWatchdogs.Add(new Watchdog(ID++, "undef", "undef"));
                createOrReffreshGridConfig();
            }
            else
            {
                myWatchdogs.RemoveAt(0);
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


                    if (f.formType == 0)
                    {

                        Measure m = new Measure(w.id, w.type_Measure, w.format, f.iMin, f.iMax);
                        myMeasuresConfigured.Add(m);

                        myWatchdogs[f.idMesureConfigured] = m;

                        if (myMeasuresConfigured.Count > 10)
                        {
                            myMeasuresConfigured.RemoveAt(0);
                        }
                    }

                    if (f.formType == 1) //idsys or watchdog
                    {
                        IdSys i = new IdSys(w.id, w.type_Measure, w.format, "none", "none", "none");

                        myIdSysMeasures.Add(i);
                        myWatchdogs[f.idMesureConfigured] = i;

                        if (myIdSysMeasures.Count > 10)
                        {
                            myIdSysMeasures.RemoveAt(0);
                        }
                        createOrReffreshGridIdSystem();
                    }

                    createOrReffreshGridConfig();

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

            foreach (Measure m in myMeasuresConfigured)
            {
                if (m.id == idM)
                {
                    mes = m;
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
                disConfig(myMeasuresConfigured[0].id);
            }
        }

        private void disConfig(int id)
        {
            DisConfigForm disConfig = null;
            if (myWatchdogs[id] is Measure)
            {

                disConfig = new DisConfigForm(user, myMeasuresConfigured, id);
                disConfig.ShowDialog();

                if (disConfig.formOK)
                {
                    int pos = disConfig.idRemove;
                    for (int i = 0; i < myMeasuresConfigured.Count; i++)
                    {

                        if (pos == myMeasuresConfigured[i].id)
                        {
                            myMeasuresConfigured.RemoveAt(i);
                        }

                        if (myAlarm.Count != 0)
                        {
                            if (pos == myAlarm[i].id_Alarme)
                            {
                                myAlarm.RemoveAt(i);
                            }
                        }

                    }
                    myWatchdogs.RemoveAt(pos);
                }
            }
            else
            {
                disConfig = new DisConfigForm(user, myIdSysMeasures, id);
                disConfig.ShowDialog();

                if (disConfig.formOK)
                {
                    int pos = disConfig.idRemove;
                    for (int i = 0; i < myIdSysMeasures.Count; i++)
                    {
                        if (pos == myIdSysMeasures[i].id)
                        {
                            myIdSysMeasures.RemoveAt(i);
                        }
                    }
                    myWatchdogs.RemoveAt(pos);
                }
            }


            createOrReffreshGridConfig();
            createOrReffreshGridMeasure();
            createOrReffreshGridIdSystem();

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
                    createOrReffreshGridMeasure();
                    if (!timerMeasure.Enabled)
                    {
                        timerMeasure.Start();
                    }
                }
            }
        }

        private void sauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (myMeasuresConfigured.Count == 0)
            {
                MessageBox.Show("Config List is Empty ! ");
            }
            else
            {
                String file = "C:\\Users\\mklfs\\source\\repos\\Meteo\\Meteo\\Files\\FILELOG.csv";
                StreamWriter sw = new StreamWriter(file);

                sw.Write("ID : ;");
                sw.Write("Type : ;");
                sw.Write("Format : ;");

                sw.Write("Min Value : ;");
                sw.Write("Max Value : ;");

                sw.Write("Min Alarm : ;");
                sw.Write("Max Alarm : ;\n\n");

                foreach (Measure m in myMeasuresConfigured)
                {
                    Alarm a = null;

                    foreach(Alarm al in myAlarm)
                    {
                        if(al.id_Alarme == m.id)
                        {
                            a = al;
                        }
                    }

                    sw.Write(m.id + ";");
                    sw.Write(m.type_Measure + ";");
                    sw.Write(m.format + ";");
                    
                    sw.Write(m.minValue + ";");
                    sw.Write(m.maxValue + ";");

                    sw.Write(a.minAlarm + ";");
                    sw.Write(a.maxAlarm + ";\t");

                    sw.Write("List of Data : ;\t");

                    if (m.data.Count == 0)
                    {
                        sw.Write("List null;");
                    }
                    else
                    {
                        String str = "";
                        foreach (String s in m.data)
                        {
                            str += s + ";\t";
                        }
                        sw.Write(str);
                    }

                    sw.Write("\n");

                }
                MessageBox.Show("File created succesfully ! ");
                sw.Close();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String file = "C:\\Users\\mklfs\\source\\repos\\Meteo\\Meteo\\Files\\FILELOG.csv";
                myWatchdogs.Clear();
                myMeasuresConfigured.Clear();
                myAlarm.Clear();

            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string line;
                    String[] tab;
                    Console.WriteLine(sr.ReadLine());
                    Console.WriteLine(sr.ReadLine());
                    

                    while ((line = sr.ReadLine()) != null)
                    {
                        tab = line.Split(';');
                        Console.WriteLine(line);

                        Measure m = new Measure(Int32.Parse(tab[0]), tab[1], tab[2], Int32.Parse(tab[3]), Int32.Parse(tab[4]));
                        myWatchdogs.Add(m);
                        myMeasuresConfigured.Add(m);
                        myAlarm.Add(new Alarm(Int32.Parse(tab[0]), tab[1], Int32.Parse(tab[5]), Int32.Parse(tab[6])));

                    }
                    createOrReffreshGridMeasure();
                    foreach (Alarm a in myAlarm)
                    {
                        cmbIdGraph.Items.Add(a.id_Alarme);
                    }
                    createOrReffreshGridConfig();
                    timerMeasure.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
        }

        
    }
}
