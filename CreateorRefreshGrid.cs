using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meteo
{
    public class CreateorRefreshGrid
    {

        public void createOrRefreshMesureGrid(DataGridView dataGridView2, List<Alarm> myAlarm, List<Measure> myMeasuresConfigured, List<Watchdog> myWatchdogs)
        {
            int nb_COLMes = 6;

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
                Measure m = null;

                foreach (Measure ma in myMeasuresConfigured)
                {
                    if (ma.id == a.id_Alarme)
                    {
                        m = ma;
                    }
                }

                int format = 0;
                Int32.TryParse(m.format + "", out format);

                int lastm = 0;
                if (!(m is null))
                {
                    lastm = generatelastmesure(a.id_Alarme, format, m.minValue, m.maxValue, myWatchdogs, myMeasuresConfigured);

                }
                String[] s = {
                    a.id_Alarme+"",
                    lastm+"",
                    a.type_mesure+"",
                    format+"",
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
            dataGridView2.Columns[3].HeaderText = "Format";
            dataGridView2.Columns[4].HeaderText = "Alarm Low";
            dataGridView2.Columns[5].HeaderText = "Alarm High";

            //Affichage
            for (int i = 0; i < nb_COLMes; i++)
            {
                dataGridView2.Columns[i].Width = CELL_SIZE;
            }

            dataGridView2.Width = nb_COLMes * CELL_SIZE;
        }

        private int generatelastmesure(int id, int octet, int min, int max, List<Watchdog> myWatchdogs, List<Measure> myMeasuresConfigured)
        {
            octet /= 8;
            int begin = 0xaa55aa;

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

            Measure m = null;

            foreach (Measure me in myMeasuresConfigured)
            {
                if (me.id == id)
                {
                    m = me;
                }
            }

            m.data.Add(nombre + "");
            if (m.data.Count > 10)
            {
                m.data.RemoveAt(0);
            }

            return nombre;
        }

        public void createOrRefreshConfigGrid(DataGridView dataGridView1, List<Watchdog> myWatchdogs, List<Measure> myMeasuresConfigured)
        {
            int CELL_SIZE = 110; //Pour l'affichage
            int nb_COLConf = 5;

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

            foreach (Watchdog w in myWatchdogs)
            {

                String[] s = new string[5];
                s[0] = w.id + "";
                s[1] = w.type_Measure + "";
                s[2] = w.format + "";
                s[3] = "none";
                s[4] = "none";


                if (w is Measure)
                {
                    Measure m = (Measure)w;
                    s[3] = m.minValue + "";
                    s[4] = m.maxValue + "";
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

        public void createOrRefreshIdSysGrid(DataGridView dataGridView3, List<IdSys> myIdSysMeasures)
        {
            int Col_Id = 6;
            int CELL_SIZE = 90; //Pour l'affichage

            //Quelques AJUSTEMENTS
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.AllowUserToResizeColumns = false;
            dataGridView3.AllowUserToResizeRows = false;

            DataTable dt = new DataTable();
            dataGridView3.DataSource = dt;

            //Crée Columns et Rows
            for (int i = 0; i < Col_Id; i++)
            {
                dt.Columns.Add();
            }

            foreach (IdSys w in myIdSysMeasures)
            {

                Console.WriteLine(w.id+" : "+w.source+" :: "+w.detail+" ::: "+w.status);

                String[] s = { w.id + "", w.type_Measure + "", w.format + "", w.source, w.detail, w.status};

                dt.Rows.Add(s);
            }


            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Measurement TYPE";
            dataGridView3.Columns[2].HeaderText = "Format(Byte)";

            dataGridView3.Columns[3].HeaderText = "Source";
            dataGridView3.Columns[4].HeaderText = "Detail";
            dataGridView3.Columns[5].HeaderText = "Status";

            //Displaying
            for (int i = 0; i < Col_Id; i++)
            {
                dataGridView3.Columns[i].Width = CELL_SIZE;
            }

            dataGridView3.Width = Col_Id * CELL_SIZE;
        }

        

    }
}
