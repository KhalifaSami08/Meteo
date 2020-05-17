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
        private List<User> allUsers;
        public User myUser;


        public ConnectUserForm(List<User> allUsers)
        {
            InitializeComponent();
            this.allUsers = allUsers;
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
            else
            {
                MessageBox.Show("Verify your inputs ! ");
            }
        }

        private bool verifyInput()
        {
            if (!(textBox1.Text.Equals("") || textBox2.Text.Equals("")))
            {
                userName = textBox1.Text;
                passWord = textBox2.Text;
                return true;
            }
            return false;
        }

        private void dbConnect()
        {

            foreach(User u in allUsers)
            {

                if (u.userName.Equals(userName))
                {

                    if (passWord.Equals(u.userPassword))
                    {
                        MessageBox.Show("Connected ! ");
                            validForm = true;
                            myUser = u;
                            Close();
                    }
                    else
                    {
                        MessageBox.Show("Password doesn't exist !");
                    }

                }

            }

        }
    }
}
