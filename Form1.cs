using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private static readonly int nb_COLConf = 5;
        private static readonly int nb_COLMes = 6;
        private String[] otherMeasures = { "ID SYSTEM", "WATCHDOG" };

        private int ID;
        private bool bTimer;

        private List<Mesure> myMeasures;
        private List<Mesure> myMeasuresConfigured;
        private List<Alarm> myAlarm;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myMeasures = new List<Mesure>();
            myMeasuresConfigured = new List<Mesure>();
            myAlarm = new List<Alarm>();
            ID = 0;
            bTimer = false;
            createOrReffreshGridConfig();
            createOrReffreshGridMeasure();
            tabIndex.SelectTab(tabConfig);
        }

        private void bOnOff_Click(object sender, EventArgs e)
        {
            tabIndex.SelectTab(tabConfig);
            if (!bTimer)
            {
                timerGenerate.Enabled = true;
                bOnOff.Text = "OFF";
                bTimer = true;
            }
            else
            {
                timerGenerate.Enabled = false;
                bOnOff.Text = "ON";
                bTimer = false;
            }

        }

        private void createOrReffreshGridConfig()
        {

            int CELL_SIZE = 110; //Pour l'affichage

            //Quelques AJUSTEMENTS
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;

            DataTable dt = new DataTable();
            dataGridView1.DataSource = dt;

            //Crée Columns et Rows
            for (int i = 0; i < nb_COLConf; i++)
            {
                dt.Columns.Add();
            }

            foreach (Mesure m in myMeasures)
            {

                String[] s = new string[5];
                s[0] = m.ID_Measure + "";
                s[1] = m.type_Measure + "";
                s[2] = m.format + "";

                Console.WriteLine(s[2]);
                if (!(m.type_Measure.Equals(otherMeasures[0]) || m.type_Measure.Equals(otherMeasures[1])))
                {
                    s[3] = m.minValue + "";
                    s[4] = m.maxValue + "";

                }
                else
                {
                    s[3] = "";
                    s[4] = "";
                }

                dt.Rows.Add(s);
            }
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Measurement TYPE";
            dataGridView1.Columns[2].HeaderText = "Format(Byte)";
            dataGridView1.Columns[3].HeaderText = "Min Val.";
            dataGridView1.Columns[4].HeaderText = "Max Val.";

            //Displaying
            for (int i = 0; i < nb_COLConf; i++)
            {
                dataGridView1.Columns[i].Width = CELL_SIZE;
            }

            dataGridView1.Width = nb_COLConf * CELL_SIZE;

        }

        private void createOrReffreshGridMeasure()
        {
            int CELL_SIZE = 90; //Pour l'affichage

            //Quelques AJUSTEMENTS
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;

            DataTable dt = new DataTable();
            dataGridView2.DataSource = dt;

            //Crée Columns et Rows
            for (int i = 0; i < nb_COLMes; i++)
            {
                dt.Columns.Add();
            }

            for (int i = 0; i < myAlarm.Count; i++)
            {
                Alarm a = myAlarm[i];
                Mesure m = null;

                foreach (Mesure ma in myMeasuresConfigured)
                {
                    if (ma.ID_Measure == a.id_Alarme)
                    {
                        m = ma;
                    }
                }
                int format = 0;
                try
                {
                    format = Int32.Parse(m.format + "");
                }
                catch
                {
                    MessageBox.Show("Probleme CAST");
                }

                int lastm = generatelastmesure(a.id_Alarme, format, m.minValue, m.maxValue);
                String[] s = {
                    a.id_Alarme+"",
                    lastm+"",
                    a.type_mesure+"",
                    "",
                    a.minAlarm+"",
                    a.maxAlarm+"",
                };

                dt.Rows.Add(s);

                if (a.minAlarm > lastm)
                {
                    dataGridView2.Rows[i].Cells[4].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView2.Rows[i].Cells[4].Style.BackColor = Color.Green;
                }
                if (a.maxAlarm < lastm)
                {
                    dataGridView2.Rows[i].Cells[5].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView2.Rows[i].Cells[5].Style.BackColor = Color.Green;
                }

            }

            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Last Measure";
            dataGridView2.Columns[2].HeaderText = "Units";
            dataGridView2.Columns[3].HeaderText = "Time(s)";
            dataGridView2.Columns[4].HeaderText = "Alarm Low";
            dataGridView2.Columns[5].HeaderText = "Alarm High";

            //Affichage
            for (int i = 0; i < nb_COLMes; i++)
            {
                dataGridView2.Columns[i].Width = CELL_SIZE;
            }

            dataGridView2.Width = nb_COLMes * CELL_SIZE;

        }

        private int generatelastmesure(int id, int octet, int min, int max)
        {
            octet /= 8;
            int begin = 17085; // 0xaa-0x55-0xaa in decimal

            // Random rnd = new Random();
            //String nbr;
            int nombre = 0;

            for (int i = 0; i < octet; i++)
            {
                int j = new Random().Next(0, 256);
                nombre += j;
                Console.WriteLine("nbr " + i + " : " + nombre);
            }

            //Int32.TryParse(nbr, out nombre);
            nombre = (nombre / 255) * (max - min) + min; //rule of 3

            String trames = begin + "" + id + "" + octet + "" + nombre;

            //myMeasures[id].data.Add(trames);
            myMeasures[id].data.Add(nombre + "");
            if (myMeasures[id].data.Count > 10)
            {
                myMeasures[id].data.RemoveAt(0);
            }

            return nombre;
        }

        private void timerGenerate_Tick(object sender, EventArgs e)
        {
            int max = 10;
            if (myMeasures.Count <= max)
            {
                myMeasures.Add(new Mesure(ID++, "undef", "undef", 0, 0));
                createOrReffreshGridConfig();
            }
            else
            {
                myMeasures.RemoveAt(0);
            }

        }

        private void bAlarm_Click(object sender, EventArgs e)
        {
            if (myMeasures.Count == 0)
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

                foreach (Mesure m in myMeasuresConfigured)
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
            configClick();
        }

        private void bConfig_Click(object sender, EventArgs e)
        {
            configClick();
        }

        private void configClick()
        {

            if (timerGenerate.Enabled)
            {
                timerGenerate.Enabled = false;
                bOnOff.Text = "ON";
            }

            if (myMeasures.Count == 0)
            {
                MessageBox.Show("Error ! Measure List is Empty ");
            }
            else
            {
                ConfigMeasureForm f = new ConfigMeasureForm(myMeasures);
                f.ShowDialog();

                if (f.formOK)
                {
                    myMeasuresConfigured.Add(myMeasures[f.idMesureConfigured]);
                    if (myMeasuresConfigured.Count > 10)
                    {
                        myMeasuresConfigured.RemoveAt(0);
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

            Mesure m = myMeasures[idM];
            this.chart1.Titles.Add("Graphic for ID : " + idM);
            Series s = this.chart1.Series.Add("Data Mesure : ");
            s.ChartType = SeriesChartType.Spline;
            foreach (String item in m.data)
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

        }
    }
}
