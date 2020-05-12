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
    public partial class ConnectUserForm : Form
    {

        public String userName;
        String passWord;
        public bool validForm;


        public ConnectUserForm()
        {
            InitializeComponent();
        }

        private void ConnectUserForm_Load(object sender, EventArgs e)
        {
            validForm = false;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            if (verifyInput())
            {
                dbConnect();
            }
        }

        private bool verifyInput()
        {
            if(textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                return true;
            }
            return false;
        }

        private void dbConnect()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mklfs\\source\\repos\\Meteo\\MeteoAccessDB.accdb;Cache Authentication=True";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            try
            {
                dbConnection.Open();

                string req = "SELECT * FROM UserTable WHERE UserName = '" + userName + "'";
                OleDbCommand dbCommand = new OleDbCommand(req, dbConnection);
                OleDbDataReader dataReader = dbCommand.ExecuteReader();


                if (dataReader.HasRows)
                {

                    if (passWord.Equals(dataReader[2].ToString()))
                    {
                        MessageBox.Show("Connected ! ");
                        validForm = true;



                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Password not Valid !");
                    }

                }
                else
                {
                    MessageBox.Show("Username doesn't exist !");
                }


                dbConnection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Command !" + exc.Message);
            }
        }

    }
}
