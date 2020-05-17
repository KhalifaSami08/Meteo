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
    public partial class DisConfigForm : Form
    {
        private User user;
        public int idRemove;

        private List<Measure> configuredListMeasure;
        private List<IdSys> configuredListIdsys;

        public bool formOK;
        public DisConfigForm(User u, List<Measure> configuredList, int id)
        {
            InitializeComponent();
            this.user = u;
            this.configuredListMeasure = configuredList;
            this.idRemove = id;
        }
        public DisConfigForm(User u, List<IdSys> configuredListIdsys, int id)
        {
            InitializeComponent();
            this.user = u;
            this.configuredListIdsys = configuredListIdsys;
            this.idRemove = id;
        }

        private void DisConfigForm_Load(object sender, EventArgs e)
        {
            formOK = false;

            if (configuredListIdsys is null)
            {
                foreach (Measure w in configuredListMeasure)
                {
                    comboBox1.Items.Add(w.id);
                }
            }
            else
            {
                foreach (IdSys w in configuredListIdsys)
                {
                    comboBox1.Items.Add(w.id);
                }
            }

            comboBox1.Text = ""+idRemove;
            
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text is null)
            {
                MessageBox.Show("Select index ! ");
            }
            else
            {
                if (textBox1.Text.Equals(user.userPassword))//password okx
                {
                    Int32.TryParse(comboBox1.SelectedItem.ToString(), out idRemove);
                    MessageBox.Show("Mesure Removed");
                    formOK = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Wrong Password ! ");
                }
            }
        }


    }
}
