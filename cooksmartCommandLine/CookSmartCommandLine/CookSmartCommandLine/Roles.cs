using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
                        { 
    public class Roles{
    private int id = 0;
    private string name = "Role name c# Fail";
    private string description = "Role Descrition C# Fail";
        public Roles(int RoleID, string Name, string Description)
        {
            id = RoleID;
            name = Name;
            description = Description;
        }
        public int getID()
        {
            return id;
        }
        public string getName()
        {
            return name;
        }
        public string Description()
        {
            return description;
        }

    }
}