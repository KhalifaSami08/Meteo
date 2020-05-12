using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meteo
{
    public partial class AlarmForm : Form
    {
        public bool valid;
        
        private List<Measure> myIdMeasuresConfigured;
        public Measure m;
        private Alarm a;
        private int idSelected;

        public int iminAlarm;
        public int imaxAlarm;

        internal Alarm A { get => a; set => a = value; }

        public AlarmForm(List<Measure> myMeasures)
        {
            InitializeComponent();
            this.myIdMeasuresConfigured = myMeasures;
        }

        private void AlarmForm_Load(object sender, EventArgs e)
        {
            valid = false;
            cmbID.Items.AddRange(getListMeasure());
        }

        private object[] getListMeasure()
        {
            object[] lists = new object[myIdMeasuresConfigured.Count];

            for (int i = 0; i < myIdMeasuresConfigured.Count; i++)
            {
                lists[i] = myIdMeasuresConfigured[i].ID_Measure;
            }
            return lists;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bValid_Click(object sender, EventArgs e)
        {
            if (checkOK())
            {

                A = new Alarm(idSelected, (String)m.type_Measure, iminAlarm, imaxAlarm);
                Close();
            }
            else
            {
                MessageBox.Show("Not ok ! ");
            }
        }

        private bool checkOK()
        {

            try
            {
                Int32.TryParse(txbMin.Text, out iminAlarm);
                Int32.TryParse(txbMax.Text, out imaxAlarm);

            }
            catch
            {
                throw new Exception("Min or max are not number");
            }

            if (iminAlarm >= imaxAlarm || imaxAlarm < m.maxValue || iminAlarm > m.minValue)
            {
                MessageBox.Show("Min or Max values aren't valid ! \n Max must be High than : " + m.maxValue + " \n Min must be lower than : " + m.minValue);

            }
            else
            {
                if (!(cmbID.SelectedItem is null))
                {
                    valid = true;
                }
            }


            return valid;
        }

        private void cmbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            idSelected = Convert.ToInt32(cmbID.SelectedItem);

            foreach (Measure me in myIdMeasuresConfigured)
            {
                if (idSelected == me.ID_Measure)
                {
                    m = me;
                }
            }
        }
    }
}
