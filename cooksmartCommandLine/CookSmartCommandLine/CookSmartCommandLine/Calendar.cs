using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
    public class Calendar
    {
        
        private string name = "C# Name Fail";
        private string description = "C# Description Fail";
        private DateTime timetobeserved = DateTime.MaxValue;
        public DateTime inputdate = DateTime.MaxValue;
        private int userid = 0;
        private int mealid = 0;
        private Meal myMeal;
        private string connection;
        public Calendar()
        {
            
        }
        public Meal getMeal()
        {
            return myMeal;
        }

        public Calendar(string Name, string Description, DateTime TimeToBeServed, DateTime InputDate, int userID,int Mealid)
        {
            name = Name;
            description = Description;
            timetobeserved = TimeToBeServed;
            inputdate = InputDate;
            userid = userID;
            mealid = Mealid;
        }
        public Calendar( int userID, int Mealid, DateTime timetobeServed, string connectionS)
        {
       //     name = Name;
       //     description = Description;
        //    timetobeserved = TimeToBeServed;
          //  inputdate = InputDate;
            userid = userID;
            mealid = Mealid;
            connection = connectionS;
            myMeal = new Meal(userid, mealid, connection);
            Console.WriteLine("recipe in meal count: "+myMeal.recipeCount());
            
        }
        

        public DateTime DateServed()
        {
            return timetobeserved.Date;
        }

        public Boolean ServedToday()
        {
            DateTime today = DateTime.Today;
            return (timetobeserved.Date == today);
        }
        public int GetUserID()
        {
            return userid;
        }
        public void SetUserID(int newuserid)
        {
            userid = newuserid;
        }

        public Boolean ServedThisMonth()
        {
            int thisyear = DateTime.Today.Year;
            int thismonth = DateTime.Today.Month;
            return ((timetobeserved.Year == thisyear) & (timetobeserved.Month == thismonth));
        }

        public Boolean ServedOnDay(DateTime timeserved)
        {
            return (timetobeserved.Date == timeserved.Date);
        }
        public Boolean ServedOnMonth(DateTime timeserved)
        {
            int yearserved = timeserved.Date.Year;
            int monthserved = timeserved.Date.Month;
            return ((timetobeserved.Date.Year == yearserved) & (timetobeserved.Date.Month == monthserved));
        }

        public string getName()
        {
            return name;
        }
        public void setName(string newname)
        {
            name = newname;
        }
        public string getDescription()
        {
            return description;
        }
        public void setDescription(string newdescription)
        {
            description = newdescription;
        }
        public DateTime getTimeToBeServed()
        {
            return timetobeserved;
        }
        public void setTimeToBeServed(DateTime newtimetobeserved)
        {
            timetobeserved = newtimetobeserved;
        }
        public DateTime getInputDate()
        {
            return inputdate;
        }
        public void setInputDate(DateTime newinputdate)
        {
            inputdate = newinputdate;
        }
        public void printCalendar()
        {
            Console.Write("\n Name: " + name + "\n Description " + description + "\n TimeToBeServed " + timetobeserved + " \n");
        }
    }
}
