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
        
      
        private string description = "C# Description Fail";
        private DateTime timetobeserved;
        public DateTime inputdate = DateTime.MaxValue;
        private int userid = 89874645;
        private int mealid = 863789179;
        private Meal myMeal;
        private string connection;
        public int getMealID()
        {
            return mealid;
        }
        public Calendar()
        {
            
        }
        public Meal getMeal()
        {
            return myMeal;
        }

       public Calendar(int userID, int MealID, DateTime TimetobeServed)
        {
            userid = userID;
    
        }

        public Calendar( int userID, int Mealid, DateTime TimetobeServed, string connectionS)
        {
            timetobeserved = TimetobeServed;
            userid = userID;
            mealid = Mealid;
            connection = connectionS;
         
            myMeal = new Meal(userid, mealid, connection);
           
            
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

        public void setMealID(int mealID)
        {
            mealid = mealID;   
        }

        public void setMeal(Meal newMeal)
        {
            myMeal = newMeal;
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
            Console.Write("\n"+mealid+" Name: " +myMeal.getMealName() + "\n TimeToBeServed " + timetobeserved + " \n");
        }
    }
}
