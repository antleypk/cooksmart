using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
    public class Instruction
    {
        private int id;
        private string title;
        private string description;
        public Instruction()
        {

        }

        public Instruction(int InstructionID, string Title, string Description)
        {
            id = InstructionID;
            title = Title;
            description = Description;
        }

        public int getID()
        {
            return id;
        }
        public string getTitle()
        {
            return title;
        }

        public string getDescription()
        {
            return description;

        }
        public string printrelevant()
        {
            string relevant = "Title: " + title + " Description: " + description;
            return relevant;
        }
    }
}
