using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CookSmartCommandLine
{
    public class Recipe
    {
       private int id = 0;
       private  string name = "Fail to name";
        private string description = "Fail to Describe";
        private List<Instruction> instructionRecipe = new List<Instruction>();
        private int servingsize = 0;
        public Recipe()
        {

        }
        public Recipe(int RecipeID, string Title, string Description, int ServingSize)
        {
            id = RecipeID;
            name = Title;
            description = Description;
            servingsize = ServingSize;

        }
        public void addInstruction(Instruction i)
        {
            instructionRecipe.Add(i);
        }
        public List<Instruction> getInstructionRecipe()
        {
            return instructionRecipe;
        }
        public int getId()
        {
            return id;
        }
        public void setId(int newid)
        {
            id = newid;
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
        public int getServingSize()
        {
            return servingsize;
        }
        public void setServingSize(int newservingsize)
        {
            servingsize = newservingsize;
        }

        public void printRecipe()
        {
            string relevent;
            relevent = id + ": " + name + " Description " + description;

            Console.WriteLine(relevent);
        
        }
        public List<Instruction> getInstructionList()
        {
            return instructionRecipe;
        }
        public void addinstruction(Instruction newInstruction)
        {
            instructionRecipe.Add(newInstruction);
        }
    }
}
