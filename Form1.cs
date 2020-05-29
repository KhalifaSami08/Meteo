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

        private CreateorRefreshGrid createorRefreshGrid;
        private int ID;
        private bool bTimer;

        private List<Watchdog> myWatchdogs; //all watchdog

        private List<IdSys> myIdSysMeasures; //id sys
        private List<Measure> myMeasuresConfigured; //measures
        private List<Alarm> myAlarm;//alarms


        /**
        * 
        * DEBUT Code Examen Collection(reste voir bas de page)
        * 
        */
        private List<Log> myLogs;
        /*
         * 
         * FIN CODE Examen Collection
         * 
         */

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

            user = new User(0);

            createorRefreshGrid = new CreateorRefreshGrid();
            ID = 0;
            bTimer = false;

            createOrReffreshGridConfig();
            createOrReffreshGridMeasure();
            createOrReffreshGridIdSystem();

            setRightLayout();
            catchAllUsers();

            tabIndex.SelectTab(tabLogs);

            /**
             * 
             * DEBUT Code Examen INIT
             * 
             */
            myLogs = new List<Log>();
            initExamValues();
            /*
             * 
             * FIN CODE EXAM INIT
             * 
             */
        }

        //Enable or Disable toolStripMenu 
        private void setRightLayout()
        {

            configNewAlarmToolStripMenuItem.Enabled = true;
            configToolStripMenuItem.Enabled = true;
            disconfigToolStripMenuItem.Enabled = true;
            createNewToolStripMenuItem.Enabled = true;
            removeUserToolStripMenuItem.Enabled = true;

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
                    myUsers.Add(new User(dataReader[1].ToString(), dataReader[2].ToString(), Int32.Parse(dataReader[3].ToString())));
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

                /*
                * 
                * EXAM DEBUT Connect USER
                * 
                */

                Log l = new Log("User", "Connection de user : " + user.userName + "! ");
                Console.WriteLine("Log crée : " + l.logDescription);
                AddlogToDatabase(l);

                /*
                 * 
                 * EXAM FIN Connect USER
                 * 
                 */
            }
        }
        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUser cu = new CreateUser(myUsers);
            cu.ShowDialog();

            user = cu.u;
            setRightLayout();

            /*
            * 
            * EXAM DEBUT ADD USER
            * 
            */

            Log l = new Log("User", "Nouvel User Crée ! Nom : " + cu.u.userName + ", Clé Accés : " + cu.u.userAcess.accessKeyId);
            Console.WriteLine("Log crée : " + l.logDescription);
            AddlogToDatabase(l);

            /*
             * 
             * EXAM FIN ADD USER
             * 
             */
        }

        private void removeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveUser rm = new RemoveUser(myUsers);
            rm.ShowDialog();

            /*
            * 
            * EXAM DEBUT REMOVE USER
            * 
            */

            Log l = new Log("User", " Utilisateur '" + rm.userName + "' a été supprimé ! ");
            Console.WriteLine("Log crée : " + l.logDescription);
            AddlogToDatabase(l);

            /*
             * 
             * EXAM FIN REMOVE USER
             * 
             */
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

            createorRefreshGrid.createOrRefreshConfigGrid(dataGridView1, myWatchdogs, myMeasuresConfigured);

        }

        private void createOrReffreshGridMeasure()
        {
            createorRefreshGrid.createOrRefreshMesureGrid(dataGridView2, myAlarm, myMeasuresConfigured, myWatchdogs);
        }

        private void createOrReffreshGridIdSystem()
        {
            createorRefreshGrid.createOrRefreshIdSysGrid(dataGridView3, myIdSysMeasures);
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

                    Watchdog w = f.watch;


                    if (f.formType == 0)
                    {

                        Measure m = new Measure(w.id, w.type_Measure, w.format, f.iMin, f.iMax);
                        myMeasuresConfigured.Add(m);

                        /*
                         * 
                         * EXAM DEBUT ADD LOG CONFIG
                         * 
                         */

                        Log l = new Log("Id", "Nouvel Id Crée ! Id : " + w.id);
                        Console.WriteLine("Log crée : " + l.logDescription);
                        AddlogToDatabase(l);

                        /*
                         * 
                         * EXAM FIN ADD LOG CONFIG 
                         * 
                         */

                        for (int i = 0; i < myWatchdogs.Count; i++)
                        {
                            if (w.id == myWatchdogs[i].id)
                            {
                                myWatchdogs[i] = m;
                            }
                        }

                        if (myMeasuresConfigured.Count > 10)
                        {
                            myMeasuresConfigured.RemoveAt(0);
                        }
                    }
                    else if (f.formType == 1) //idsys or watchdog
                    {
                        IdSys ids = new IdSys(w.id, w.type_Measure, w.format, generateSource(w.id), generateDetail(), generateStatus());

                        myIdSysMeasures.Add(ids);

                        for (int i = 0; i < myWatchdogs.Count; i++)
                        {
                            if (w.id == myWatchdogs[i].id)
                            {
                                myWatchdogs[i] = ids;
                            }
                        }

                        if (myIdSysMeasures.Count > 10)
                        {
                            myIdSysMeasures.RemoveAt(0);
                        }
                        createOrReffreshGridIdSystem();
                    }
                    else
                    {
                        MessageBox.Show("Mistake ! ");
                    }

                    createOrReffreshGridConfig();

                }
            }
        }

        private String generateSource(int id)
        {
            String s = "";
            Random rnd = new Random();
            int rand = rnd.Next(0, 2);
            //Console.WriteLine("Source : " + rand);
            switch (rand)
            {
                case 0: // == 0xaa
                    s = "System";
                    break;
                case 1:
                    s = "Id - " + id;
                    break;
            }
            return s;
        }

        private String generateDetail()
        {
            String s = "";
            Random rnd = new Random();
            int rand = rnd.Next(0, 4);
            //Console.WriteLine("Detail : " + rand);
            switch (rand)
            {
                case 0: // == 0x00
                    s = "No Detail";
                    break;
                case 1: // == 0x55
                    s = "Surcurrent";
                    break;
                case 2: // == 0xaa
                    s = "overvoltage ";
                    break;
                case 3: // == 0xff
                    s = "overtemperature";
                    break;
            }
            return s;
        }

        private String generateStatus()
        {
            String s = "";
            Random rnd = new Random();
            int rand = rnd.Next(0, 2);
            //Console.WriteLine("Status : " + rand);
            switch (rand)
            {
                case 0: // == 0x55
                    s = "Active";
                    break;

                case 1: // == 0xaa
                    s = "inactive";
                    break;
            }
            return s;
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
                    /*
                    * 
                    * EXAM DEBUT REMOVE LOG DISCONFIG
                    * 
                    */

                    Log l = new Log("Id", "Nouvel Id Supprimé (DisConfig) ! ID : " + myWatchdogs[pos].id);
                    Console.WriteLine("Log crée : " + l.logDescription);
                    AddlogToDatabase(l);

                    /*
                     * 
                     * EXAM FIN REMOVE LOG DISCONFIG
                     * 
                     */
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

                    /**
                     * 
                     * Exam DEBUT Ajout de Logs Alarm
                     * 
                     */

                    Log l = new Log("Alarm", "Nouvelle Alarme crée - ID : " + f.A.id_Alarme + ", Min : " + f.A.minAlarm + ", Max : " + f.A.maxAlarm);
                    Console.WriteLine("Log crée : " + l.logDescription);
                    AddlogToDatabase(l);

                    /**
                     * 
                     * Exam FIN Ajout de Logs Alarm
                     * 
                     */

                    createOrReffreshGridMeasure();
                    if (!timerMeasure.Enabled)
                    {
                        timerMeasure.Start();
                    }
                    foreach (Alarm a in myAlarm)
                    {
                        cmbIdGraph.Items.Add(a.id_Alarme);
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

                    foreach (Alarm al in myAlarm)
                    {
                        if (al.id_Alarme == m.id)
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

        /***
         * 
         * CODE EXAMEN DEBUT
         * 
         */

        private void initExamValues() //methode appelée dans le form_load
        {
            object[] itemsCmbEvValues = { 5, 10, 25, 50 };
            cmbNbEv.Items.AddRange(itemsCmbEvValues);
            cmbNbEv.SelectedItem = itemsCmbEvValues[0];
            cmbNbEv.DropDownStyle = ComboBoxStyle.DropDownList;


            object[] itemsFilterValues = { "No Filter", "User", "Id", "Alarm" };
            cmbFilter.Items.AddRange(itemsFilterValues);
            cmbFilter.SelectedItem = itemsFilterValues[0];
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;


            reqSelectInit();
            CreateOrReffreshDatagridLog();

        }

        private void dbLogConnectExam(string req, int param) //je fais le select et le insert dans la même methode
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mklfs\\source\\repos\\Meteo\\Meteo\\Files\\DB_Logs.accdb;Cache Authentication=True";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            try //Gestion d'Erreurs
            {

                dbConnection.Open();

                OleDbCommand dbCommand = new OleDbCommand(req, dbConnection);
                OleDbDataReader dataReader = dbCommand.ExecuteReader();

                if (param == 0) //0 = requete select
                {
                    while (dataReader.Read())
                    {
                        myLogs.Add(new Log(Int32.Parse(dataReader[0].ToString()), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString()));
                        Console.WriteLine("Ref : " + dataReader[0].ToString());
                    }
                }
                else if (param == 1) //requete insert
                {
                    Console.WriteLine(req + " insert Succefully \n");
                }
                else
                {
                    throw new Exception("Oups, ce paramétre n'existe pas pourla BDD ! ");
                }


                dbConnection.Close();
                /*
                * Note : j'utilise les fermetures de bdd ainsi que des collections pour travailler en mode déconnecté 
                */
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Command !" + exc.Message);
            }
        }

        private void reqSelectInit()
        {
            string req = "SELECT * FROM LogsTable";
            dbLogConnectExam(req, 0);

        }

        private void reqSelectFilter(string filter)
        {
            myLogs.Clear();
            string req = "SELECT * FROM LogsTable WHERE LogType = '" + filter + "'";
            dbLogConnectExam(req, 0);
        }

        private void AddlogToDatabase(Log l)
        {
            l.logRef = myLogs.Count;
            myLogs.Add(l);
            string req = "INSERT INTO LogsTable(LogDate,LogType,LogDescription) VALUES ('" + l.logDate + "','" + l.logType + "','" + l.logDescription + "');";
            dbLogConnectExam(req, 1);
        }

        //REFRESH DATAGRID
        private void CreateOrReffreshDatagridLog()
        {
            int CELL_SIZE = 140; //Pour l'affichage
            int nb_COLConf = 4;

            //Quelques AJUSTEMENTS
            dataGridViewLog.RowHeadersVisible = false;
            dataGridViewLog.AllowUserToResizeColumns = false;
            dataGridViewLog.AllowUserToResizeRows = false;
            dataGridViewLog.ScrollBars = ScrollBars.None;

            DataTable dt = new DataTable();
            dataGridViewLog.DataSource = dt;

            //Crée Columns et Rows
            for (int i = 0; i < nb_COLConf; i++)
            {
                dt.Columns.Add();
            }

            foreach (Log l in myLogs)
            {

                String[] s = new string[4];
                s[0] = l.logRef.ToString();
                s[1] = l.logDate;
                s[2] = l.logType;
                s[3] = l.logDescription;

                dt.Rows.Add(s);
            }
            dataGridViewLog.Columns[0].HeaderText = "Ref";
            dataGridViewLog.Columns[1].HeaderText = "Date";
            dataGridViewLog.Columns[2].HeaderText = "Measurement TYPE";
            dataGridViewLog.Columns[3].HeaderText = "Description";

            //Displaying
            for (int i = 0; i < nb_COLConf; i++)
            {
                dataGridViewLog.Columns[i].Width = CELL_SIZE;
            }

            dataGridViewLog.Width = nb_COLConf * CELL_SIZE;
        }

        //BUTTON DATAGRID REFRESH
        private void bSetDatagrid_Click(object sender, EventArgs e)
        {
            //Filter
            string valCmbFiler = cmbFilter.SelectedItem.ToString();
            if (valCmbFiler.Equals("No Filter"))
            {
                reqSelectInit();
            }
            else
            {
                reqSelectFilter(valCmbFiler);
            }

            //NbEvents
            int nbEvents = 0;
            Int32.TryParse(cmbNbEv.SelectedItem.ToString(), out nbEvents);
            
            while (myLogs.Count> nbEvents)
            {
                myLogs.RemoveAt(0);
            }

            CreateOrReffreshDatagridLog();
        }

        //EXPORT CSV
        private void bExport_Click(object sender, EventArgs e)
        {
            if (myLogs.Count == 0)
            {
                MessageBox.Show("Logs List is Empty ! ");
            }
            else
            {
                String file = "C:\\Users\\mklfs\\source\\repos\\Meteo\\Meteo\\Files\\FILELOG_EXAM.csv"; //pas confondre avec FileLog qui est mon export de mes alarmes de base
                using (StreamWriter sw = new StreamWriter(file))
                {
                    try //Gestion d'erreur part 2
                    {
                        sw.Write("Ref : ;");
                        sw.Write("Date : ;");
                        sw.Write("Type : ;");
                        sw.Write("Description : ;\n\n");

                        foreach (Log l in myLogs)
                        {

                            sw.Write(l.logRef + ";");
                            sw.Write(l.logDate + ";");
                            sw.Write(l.logType + ";");
                            sw.Write(l.logDescription + ";");

                            sw.Write("\n");

                        }
                        MessageBox.Show("File created succesfully ! ");
                        sw.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The file could not be Written :");
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }




        /***
         * 
         * CODE EXAMEN FIN
         * 
         */

    }
}
