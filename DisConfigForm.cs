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
        private List<Measure> configuredList;
        public bool formOK;
        public DisConfigForm(User u,List<Measure> configuredList,int id)
        {
            InitializeComponent();
            this.user = u;
            this.configuredList = configuredList;
            this.idRemove = id;
            formOK = false;
        }

        private void DisConfigForm_Load(object sender, EventArgs e)
        {
            foreach (Measure m in configuredList)
            {
                comboBox1.Items.Add(m.ID_Measure);
            }

            comboBox1.Text = idRemove+"";

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
                if (textBox1.Text.Equals(user.userPassword))
                {
                    idRemove = Int32.Parse(comboBox1.SelectedItem.ToString());
                    MessageBox.Show(" Mesure Removed");
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
