using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
    public class User
    {
        private int userid;
        private string firstname;
        private string lastname;
        private string username;
        private string displayname;
        private string password;
        public User()
        {

        }

        public User(int UserID, string FirstName, string LastName, string UserName, string DisplayName, string Password)
        {
            userid = UserID;
            firstname = FirstName;
            lastname = LastName;
            username = UserName;
            displayname = DisplayName;
            password = Password;
        }
        public int getID()
        {
            return userid;
        }
        public string getFirstName()
        {
            return firstname;
        }
        public string getLastName()
        {
            return lastname;
        }
        public string getUserName()
        {
            return username;
        }
        public string getDisplayName()
        {
            return displayname;
        }
        public string getPassword()
        {
            return password;
        }
    }
}