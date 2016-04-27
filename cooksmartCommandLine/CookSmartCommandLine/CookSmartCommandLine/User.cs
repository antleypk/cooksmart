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
           this.userid = UserID;
           this.firstname = FirstName;
           this.lastname = LastName;
           this.username = UserName;
           this.displayname = DisplayName;
           this.password = Password;
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
        public void printUser()
        {
            //      private int id = 0;
            //private string name = "Ingredient name failed c#";
            //public string description = "Description failed c#";
            //private string quantitytype = "QuantityType failed at c#";
            Console.Write("ID: " + userid + "\n First Name: " + firstname + "\n Last Name: " + lastname + "\n User Name " + username + "\n Display Name " + displayname + "\n password: " + password  + "\n");
        }
    }
}