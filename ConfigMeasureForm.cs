using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Meteo
{
    public partial class ConfigMeasureForm : Form
    {

        public int formType;
        private List<Watchdog> myWatchdogs;
        public Watchdog watch;
        public int idMesureConfigured;


        public int iMin;
        public int iMax;

        /*public ConfigMeasureForm(List<Mesure> myMeasures)
        {
            InitializeComponent();
            this.myMeasures = myMeasures;
        }*/

        public ConfigMeasureForm(List<Watchdog> myWatchdogs,int id)
        {
            InitializeComponent();
            this.myWatchdogs = myWatchdogs;
            cmbID.Text= id+"";
            formType = -1;
        }

        private void NewMeasureForm_Load(object sender, EventArgs e)
       {
            cmbFomat.Items.AddRange(Measure.getFormatDispo());

            cmbMeasureType.Items.AddRange(Measure.getTypeMeasure());
            cmbMeasureType.Items.AddRange(IdSys.getTypeMeasure());

            cmbID.Items.AddRange(getListMeasure());
            cmbID.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private object[] getListMeasure()
        {
            object[] lists = new object[myWatchdogs.Count];

            for (int i = 0; i < myWatchdogs.Count; i++)
            {
                lists[i] = myWatchdogs[i].id;
            }
            return lists;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSubmit_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                Int32.TryParse(cmbID.Text, out idMesureConfigured);

                if (!(cmbMeasureType.SelectedItem.Equals(IdSys.getTypeMeasure()[0]) ||
                      cmbMeasureType.SelectedItem.Equals(IdSys.getTypeMeasure()[1])))
                {
                    formType = 0;
                    
                }
                else
                {
                    formType = 1;
                }

                foreach(Watchdog w in myWatchdogs)
                {
                    if(w.id == idMesureConfigured)
                    {
                        watch = w;
                        w.type_Measure = cmbMeasureType.SelectedItem;
                        w.format = cmbFomat.SelectedItem;
                    }
                }
               

                Close();
            }
            else
            {
                MessageBox.Show("Something WRONG ! ");
            }
        }

        public bool Check()
        {
            if(cmbFomat.SelectedItem is null || cmbMeasureType.SelectedItem is null)
            {
                //throw new Exception("One combo box is empty !");
                MessageBox.Show("One combo box is empty !");
                return false;
            }

            if ( ! (cmbMeasureType.SelectedItem.Equals(IdSys.getTypeMeasure()[0]) || cmbMeasureType.SelectedItem.Equals(IdSys.getTypeMeasure()[1])))
            {
                try
                {
                    Int32.TryParse(txbMin.Text, out iMin);
                    Int32.TryParse(txbMax.Text, out iMax);

                    if (iMin >= iMax)
                    {
                        MessageBox.Show("Min is higher than max ! ");
                        return false;
                    }

                }
                catch
                {
                    throw new Exception("Min or Max are not number");
                }
            }

            return true;
        }

        private void cmbMeasureType_TextChanged(object sender, EventArgs e)
        {
           
            if (cmbMeasureType.SelectedItem.Equals(IdSys.getTypeMeasure()[0]) || cmbMeasureType.SelectedItem.Equals(IdSys.getTypeMeasure()[1] ))
            {
                gBoxMinMax.Visible = false;
            }
            else
            {
                gBoxMinMax.Visible = true;
            }
            
        }
    }
}
