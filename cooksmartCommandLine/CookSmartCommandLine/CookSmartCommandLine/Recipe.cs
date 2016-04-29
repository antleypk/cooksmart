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
        public int getId()
        {
            return id;
        }
        public string getName()
        {
            return name;
        }
        public string getDescription()
        {
            return description;
        }
        public int getServingSize()
        {
            return servingsize;
        }

        public string printRecipe()
        {
            string relevent;
            relevent = id + ": " + name + " Description " + description;

            return relevent;
        }
    }
}
