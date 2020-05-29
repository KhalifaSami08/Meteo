using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meteo
{
    public partial class RemoveUser : Form
    {
        private List<User> myUsers;
        public string userName;

        public RemoveUser(List<User> myUsers)
        {
            InitializeComponent();
            this.myUsers = myUsers;
        }

        private void RemoveUser_Load(object sender, EventArgs e)
        {
            foreach(User u in myUsers)
            {
                comboBox1.Items.Add(u.userName);
            }

        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bok_Click(object sender, EventArgs e)
        {

            if(!(comboBox1.SelectedItem is null))
            {
                dbConnect();
                Close();
            }
            else
            {
                MessageBox.Show("Combo is null");
            }

        }

        private void dbConnect()
        {

            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mklfs\\source\\repos\\Meteo\\Meteo\\Files\\MeteoAccessDB.accdb;Cache Authentication=True";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            try
            {
                dbConnection.Open();
                userName = comboBox1.SelectedItem.ToString();

                string req = "DELETE FROM UserTable WHERE UserName = '"+ comboBox1.SelectedItem.ToString()+"'";
                Console.WriteLine(req);
                OleDbCommand dbCommand = new OleDbCommand(req, dbConnection);
                OleDbDataReader dataReader = dbCommand.ExecuteReader();

                User uToRemove = null;
                foreach(User u in myUsers)
                {
                    if (u.userName.Equals(comboBox1.SelectedItem.ToString()))
                    {
                        uToRemove = u;
                    }
                }
                myUsers.Remove(uToRemove);

                MessageBox.Show("User removed");

                dbConnection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Command !" + exc.Message);
            }


        }
    }
}
