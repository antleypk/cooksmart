using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
    public class QuantityUnits
    {
        private int id = 0;
        private string name = "QuantityUnitsName C# Fail";
        private string description = "QuantityUnitsDescription C# Fail";
        public QuantityUnits(int QuantityUnitsID, string Title, string Description)
        {
            id = QuantityUnitsID;
            name = Title;
            description = Description;
        }
        public int getID()
        {
            return id;
        }
        public string getTitle()
        {
            return name;
        }
        public string getDescription()
        {
            return description;
        }
    }
}
