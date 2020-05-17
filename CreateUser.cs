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
    public partial class CreateUser : Form
    {
        public User u;
        private List<User> myUsers;

        private String userName;
        private String userPassword;
        private int userAccessKey_ID;

        public CreateUser(List<User> myUsers)
        {
            InitializeComponent();
            this.myUsers = myUsers;
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            u = null;
            Object[] o = {"Admin","Master","Middle","Basic","NoRight" };
            comboBox1.Items.AddRange(o);
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            if (check())
            {
                userName = textBox1.Text;
                userPassword = textBox2.Text;

                int access = -1;
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Admin":
                        access = 0;
                        break;

                    case "Master":
                        access = 1;
                        break;

                    case "Middle":
                        access = 2;
                        break;

                    case "Basic":
                        access = 3;
                        break;

                    case "NoRight":
                        access = 4;
                        break;
                    
                    default:
                        MessageBox.Show("Error Access ! ");
                        break;
                }

                userAccessKey_ID = access;
                
                u = new User(userName, userPassword, access);
                myUsers.Add(u);
                dbAccess();
                MessageBox.Show("User Added");
                Close();
            }
            else
            {
                MessageBox.Show("Check your inputs ! ");
            }
        }

        private bool check()
        {
            bool b = false;

            if(!(textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("")))
            {
                if(textBox2.Text.Equals(textBox3.Text)){

                    if(!(comboBox1.SelectedItem is null))
                    {
                        b = true;
                    }
                }
            }

            return b;

        }

        private void dbAccess()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mklfs\\source\\repos\\Meteo\\Meteo\\Files\\MeteoAccessDB.accdb;Cache Authentication=True";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            try
            {
                dbConnection.Open();

                string req = "INSERT INTO UserTable(UserName,UserPassword,AccessKey_ID) VALUES ('"+userName+"','"+userPassword+"','"+userAccessKey_ID+"');";
                Console.WriteLine(req);
                OleDbCommand dbCommand = new OleDbCommand(req, dbConnection);
                OleDbDataReader dataReader = dbCommand.ExecuteReader();

                dbConnection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Command !" + exc.Message);
            }
        }

    }
}
