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
        private List<Ingredient> instructionIngredients = new List<Ingredient>();
        private int order;
        public Instruction()
        {

        }

        public void addIngredient(Ingredient i)
        {
            instructionIngredients.Add(i);
        }

        public int getOrder()
        {
            return order;
        }

        public void setOrder(int newOrder)
        {
            order = newOrder;
        }

        public List<Ingredient> getInstructionIngredients()
        {
            return instructionIngredients;
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
            string relevant = title +"\n id: "+id+ "\n Description: " + description;
            return relevant;
        }
        public void printInstructionToConsole()
        {
            string tobePrinted = printInstruction();
            Console.WriteLine(tobePrinted);
        }
    }
    }

