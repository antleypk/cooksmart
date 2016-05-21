using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;


namespace CookSmartCommandLine
{
  public  class CookSmart
    {
        Operator operations = new Operator();
        public Actions actions = new Actions();
        private Recipe myRecipe = new Recipe();
        public CookSmart()
        {

        }


        public void startUpCookSmart(string connection,int userID)
        {
            List<Recipe> recipes=operations.allRecipes(connection);
            for (int i = 0; i < recipes.Count; i++)
            {
               string name= recipes[i].getName();
               int recipid= recipes[i].getId();
                Console.WriteLine(name + " " + recipid);
            }
            Console.WriteLine();
            Console.WriteLine("Select a Recipe by ID");
            string userInput = Console.ReadLine();
            int id = 9999;
            bool parse = int.TryParse(userInput, out id);
            if (id != 9999)
            {
                AutoCookSmart(connection, userID, id);
            }
            if (id == 9999)
            {
                startUpCookSmart(connection, userID);
            }
        }
        public Recipe AutoCookSmart(string connection, int userID, int id)
        {
            myRecipe=operations.recipeFromId(connection, userID, id);
            Console.WriteLine("Ingredient List:");
      
            List<Ingredient> myIngredients = operations.IngredientsInRecipeById(connection, id, userID);
            for (int c = 0; c < myIngredients.Count; c++)
            {
                myIngredients[c].printIngredient();
            }
            myRecipe.addIngredents(myIngredients);
            Console.WriteLine("Instruction List:");
            List<Instruction> myInstructions = operations.allInstructionsInRecipe(connection, userID, id);
            int test = myInstructions.Count;
       //     Console.WriteLine("Instruction count from cook smart: " + test);
            for (int d = 0; d < myInstructions.Count; d++)
            {
                myInstructions[d].printInstructionToConsole();
            }
            myRecipe.setInstructions(myInstructions);
            operations.recipeFromId(connection, userID, id);
            
            Console.WriteLine();
            return myRecipe;
        }
    }
}
