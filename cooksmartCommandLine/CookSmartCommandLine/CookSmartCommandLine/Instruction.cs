using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
    public class Instruction
    {
        private int id=999999999;
        private string title = "failed @ c#";
        private string description="failed @ c#";
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
        public string printInstruction()
        {
            string relevant = "Title: " + title +" id: "+id+ " Description: " + description;
            return relevant;
        }
        public void printInstructionToConsole()
        {
            string tobePrinted = printInstruction();
            Console.WriteLine(tobePrinted);
        }
    }
    }

