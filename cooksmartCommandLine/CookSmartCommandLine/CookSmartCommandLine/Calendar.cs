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
        private DateTime timetobeserved = DateTime.Now;
        public Calendar()
        {
            
        }

        public Calendar(string Name, string Description, DateTime TimeToBeServed)
        {
            name = Name;
            description = Description;
            timetobeserved = TimeToBeServed;
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
        public void printCalendar()
        {
            Console.Write("Name: " + name + "\n Description" + description + "\n TimeToBeServed" + timetobeserved);
        }
    }
}
