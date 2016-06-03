using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
    public class CalendarBuilder
    {
        private Calendar mealDate = new Calendar();
        private int day;
        private int month;
        private int year;
        private int hours;
        private int minutes;
        private string AMPM;
        private DateTime timeToBeServed;
        private DateTime inputTime;

        public CalendarBuilder() { }

        public void startUp(int userID, string connection, Operator operations)
        {
           
            mealDate.SetUserID(userID);
            List<Meal> allMeals=operations.allMeals(connection);
            for (int i = 0; i < allMeals.Count; i++)
            {
                allMeals[i].printMealTop(connection);
            }
            Console.WriteLine("Choose your meal by id");
            string stringInput = Console.ReadLine();
            int mealId = 666666666;
            bool parse = Int32.TryParse(stringInput, out mealId);
            if(!parse)
            {
                startUp(userID, connection, operations);
            }
            mealDate.setMealID(mealId);
            setDay();
            setMonth();
            setYear();
            setHour();
            setMinutes();
            setAMPM();
            makeDateString();
            inputTime = DateTime.Now;
            buildCalendar(mealId, userID, connection, operations);
            check(userID, connection, operations);
        }

        public void makeDateString()
        {
            string DateString = month + "/" + day + "/" + year + " " + hours + ":" + minutes + ":00 " + AMPM;
            Console.WriteLine("Date String inside CalanderBuider datestring: " + DateString);
            Actions act = new Actions();
            timeToBeServed = act.stringToDateTime(DateString);
        }

        public void check(int userId, string connection, Operator operations)
        {
            mealDate.printCalendar();
            Console.WriteLine("Continue or Restart [C] or [R]");
            string userInput = Console.ReadLine();
            if(userInput == "c" || userInput == "C")
            {
                //insert
                insertCalendar(userId, connection, operations);
            }
            if(userInput == "r" || userInput == "R")
            {
                startUp(userId, connection, operations);
            }
        }

        public void buildCalendar(int mealId, int userId, string connection, Operator operations)
        {
            mealDate.setInputDate(inputTime);
            mealDate.setTimeToBeServed(timeToBeServed);
            mealDate.setMeal(operations.getMealByID(connection, userId, mealId));
        }

        public void insertCalendar(int userId, string connection, Operator operations)
        {
            operations.InsertCalendar(connection, mealDate, userId);
        }

        public void setDay()
        {
            Console.WriteLine("Day of the month: (1-31)");
            string userInput = Console.ReadLine();
            int tempDay = 40;
            bool Parse = Int32.TryParse(userInput, out tempDay);
            if(!Parse)
            {
                setDay();
            }
            if(Parse)
            {
                day = tempDay;
            }
        }

        public void setMonth()
        {
            Console.WriteLine("Month as number: (1-12)");
            string userInput = Console.ReadLine();
            int tempMonth = 13;
            bool Parse = Int32.TryParse(userInput, out tempMonth);
            if (!Parse)
            {
                setMonth();
            }
            if (Parse && tempMonth < 13)
            {
                if (tempMonth < 10)
                {
                 //   tempMonth = '0' + tempMonth;
                }
                month = tempMonth;
            }
        }

        public void setYear()
        {
            Console.WriteLine("Year: (yyyy)");
            string userInput = Console.ReadLine();
            int tempYear = 11111;
            bool Parse = Int32.TryParse(userInput, out tempYear);
            if (!Parse)
            {
                setYear();
            }
            if (Parse && tempYear < 10000)
            {
                year = tempYear;
            }
        }

        public void setHour()
        {
            Console.WriteLine("Hour: (01-12)");
            string userInput = Console.ReadLine();
            int tempHour = 13;
            bool Parse = Int32.TryParse(userInput, out tempHour);
            if (!Parse)
            {
                setHour();
            }
            if (Parse && tempHour < 13)
            {
                if (tempHour < 10)
                {
                //    tempHour = '0' + tempHour;
                }  
                hours = tempHour;
            }
        }

        public void setMinutes()
        {
            Console.WriteLine("Minutes: (00-60)");
            string userInput = Console.ReadLine();
            int tempMinute = 61;
            bool Parse = Int32.TryParse(userInput, out tempMinute);
            if (!Parse)
            {
                setMinutes();
            }
            if (Parse && tempMinute < 61)
            {
                minutes = tempMinute;
            }
        }

        public void setAMPM()
        {
            Console.WriteLine("AM or PM: ");
            string userInput = Console.ReadLine();
            AMPM = userInput;
        }

    }
}
