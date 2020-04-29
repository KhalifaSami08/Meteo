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
    public partial class ConfigMeasureForm : Form
    {

        public bool formOK = false;
        private List<Mesure> myMeasures;
        private String[] otherMeasures = {"ID SYSTEM", "WATCHDOG" };
        public int idMesureConfigured;

        private int iMin;
        private int iMax;

        public ConfigMeasureForm(List<Mesure> myMeasures)
        {
            InitializeComponent();
            this.myMeasures = myMeasures;
        }

       private void NewMeasureForm_Load(object sender, EventArgs e)
       {
            cmbFomat.Items.AddRange(Mesure.getFormatDispo());

            cmbMeasureType.Items.AddRange(Mesure.getTypeMeasure());
            cmbMeasureType.Items.AddRange(otherMeasures);

            cmbID.Items.AddRange(getListMeasure());

        }

        private object[] getListMeasure()
        {
            object[] lists = new object[myMeasures.Count];

            for (int i = 0; i < myMeasures.Count; i++)
            {
                lists[i] = myMeasures[i].ID_Measure;
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
                formOK = true;
                idMesureConfigured = cmbID.SelectedIndex;
                myMeasures[idMesureConfigured].type_Measure = cmbMeasureType.SelectedItem;
                myMeasures[idMesureConfigured].format = cmbFomat.SelectedItem;
                myMeasures[idMesureConfigured].minValue = iMin;
                myMeasures[idMesureConfigured].maxValue = iMax;

                Close();
            }
            else
            {
                MessageBox.Show("Something WRONG ! ");
            }
        }

        public bool Check()
        {
            if(cmbFomat.SelectedItem is null || cmbMeasureType.SelectedItem is null || cmbID.SelectedItem is null)
            {
                //throw new Exception("One combo box is empty !");
                MessageBox.Show("One combo box is empty !");
                return false;
            }

            try
            {
                Int32.TryParse(txbMin.Text, out iMin);
                Int32.TryParse(txbMax.Text, out iMax);

                if(iMin >= iMax)
                {
                    MessageBox.Show("Min is higher than max ! ");
                    return false;
                }

            }
            catch
            {
                throw new Exception("Min or Max are not number");
            }
            

            return true;
        }

        private void cmbMeasureType_TextChanged(object sender, EventArgs e)
        {
           
            if (cmbMeasureType.SelectedItem.Equals(otherMeasures[0]) || cmbMeasureType.SelectedItem.Equals(otherMeasures[1]))
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
