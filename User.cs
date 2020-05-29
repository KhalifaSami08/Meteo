using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Meteo
{
    public class User
    {
        public static int accessKeyId { get; set; } //static beacause only one will be instacied.

        public string userPassword { get; set; }

        public string userName { get; set; }

        public Access userAcess;

        public User(string userName, string userPassword, int accessKeyId)
        {
            this.userName = userName;
            this.userPassword = userPassword;
            User.accessKeyId = accessKeyId;
            userAcess = new Access();
        }
        
        public User(int accessKeyId)
        {
            this.userPassword = "12345";
            User.accessKeyId = accessKeyId;
            userAcess = new Access();
            this.userName = userAcess.accessName;
        }


    }

    public class Access
    {
        public int accessKeyId { get; set; }
        public string accessName { get; set; }
        public bool allowCreateID { get; set; }
        public bool allowDestroyID { get; set; }
        public bool allowConfigAlarm { get; set; }
        public bool userCreation { get; set; }

        public Access()
        {
            this.accessKeyId = User.accessKeyId;
            setAllUsersAccess();
        }

        private void setAllUsersAccess()
        {
            switch (accessKeyId)
            {
                case 0:
                    accessName = "Admin";
                    allowCreateID = true;
                    allowDestroyID = true;
                    allowConfigAlarm = true;
                    userCreation = true;
                    break;
                
                case 1:
                    accessName = "Master";
                    allowCreateID = true;
                    allowDestroyID = true;
                    allowConfigAlarm = true;
                    userCreation = false;
                    break;

                case 2:
                    accessName = "Middle";
                    allowCreateID = true;
                    allowDestroyID = false;
                    allowConfigAlarm = true;
                    userCreation = false;
                    break;

                case 3:
                    accessName = "Basic";
                    allowCreateID = false;
                    allowDestroyID = false;
                    allowConfigAlarm = true;
                    userCreation = false;
                    break;

                case 4:
                    accessName = "NoRight";
                    allowCreateID = false;
                    allowDestroyID = false;
                    allowConfigAlarm = false;
                    userCreation = false;
                    break;
            }
        }

    }



}
