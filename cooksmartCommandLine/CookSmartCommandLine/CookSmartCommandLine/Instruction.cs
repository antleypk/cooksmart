using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
    public class Instruction
    {
        private int id=999999997;
        private string title = "failed @ c#";
        private string description="failed @ c#";
        private List<Ingredient> instructionIngredients = new List<Ingredient>();
        private int order;
        private int userid;
        private int cooktime;
        private int preptime;

        public Instruction()
        {
           
        }
        public Instruction(int userID)
        {
            userid = userID;
        }

        public void addIngredient(Ingredient i)
        {
            instructionIngredients.Add(i);
        }

        public int getUserID()
        {
            return userid;
        }
        public void setUserID(int newuserid)
        {
            userid = newuserid;
        }
        public int getCookTime()
        {
            return cooktime;
        }
        public void setCookTime(int newcooktime)
        {
            cooktime = newcooktime;
        }
        public int getPrepTime()
        {
            return preptime;
        }
        public void setPrepTime(int newpreptime)
        {
            preptime = newpreptime;
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

        public Instruction(int InstructionID, string Title, string Description, int userID)
        {
            id = InstructionID;
            title = Title;
            description = Description;
            userid = userID;
            
        }

        public int getID()
        {
            return id;
        }
        public void setID(int newid)
        {
            id = newid;
        }
        public string getTitle()
        {
            return title;
        }
        public void setTitle(string newtitle)
        {
            title = newtitle;
        }

        public string getDescription()
        {
            return description;

        }
        public void setDescription(string newdescription)
        {
            description = newdescription;
        }
        public string printInstruction()
        {
            string relevant = title + "\n id: " + id + "\n Description: " + description + "\n Order: " + order;
            return relevant;
        }
        public void printInstructionToConsole()
        {
            string tobePrinted = printInstruction();
            Console.WriteLine(tobePrinted);
        }
    }
    }

