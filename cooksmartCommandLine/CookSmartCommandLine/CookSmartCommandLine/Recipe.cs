using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CookSmartCommandLine
{
    public class Recipe
    {
       private int id = 919999979;
       private  string name = "Fail to name recipe";
        private string description = "Fail to Describe";
        private List<Instruction> instructionRecipe = new List<Instruction>();
        private List<Ingredient> recipeIngredient = new List<Ingredient>();
        private int servingsize = 0;
        private int userid = 0;
        public Recipe()
        {

        }
        public Recipe(int userID)
        {
            userid = userID;
        }
        public Recipe(int RecipeID, string Title, string Description, int ServingSize, int userID)
        {
            id = RecipeID;
            name = Title;
            description = Description;
            servingsize = ServingSize;
            userid = userID;

        }
        public int getUserID()
        {
            return userid;
        }
        public void setUserID(int newuserid)
        {
            id = newuserid;
        }
        public void addInstruction(Instruction i)
        {
            instructionRecipe.Add(i);
        }
        public List<Ingredient> getRecipeIngredient()
        {
            return recipeIngredient;
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
        public void printFullRecipe()
        {
            Console.WriteLine(name);
            Console.WriteLine();
            for (int i=0;i< instructionRecipe.Count; i++)
            {
                instructionRecipe[i].printInstructionToConsole();
            }
            Console.WriteLine();
            for(int b = 0; b < recipeIngredient.Count; b++)
            {
                recipeIngredient[b].printIngredient();
            }
        }

        public List<Instruction> getInstructionList()
        {
            return instructionRecipe;
        }
        public void addinstruction(Instruction newInstruction)
        {
            instructionRecipe.Add(newInstruction);
        }
        public void addIngredents(List<Ingredient> wholeList)
        {
            recipeIngredient = wholeList; 
        }
        public void setInstructions(List<Instruction> wholeList)
        {
            instructionRecipe = wholeList;
        }
    }
}
