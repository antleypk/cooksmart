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
            //string idString = reader["IngredientID"].ToString();
            int id = 9999;
            bool parse = int.TryParse(userInput, out id);
            
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
             //   Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Ingredient List:");
            //     actions.ShoppingListFromRecipe(conn, id);
           List<Ingredient> myIngredients=operations.IngredientsInRecipeById(connection, id, userID);
           for (int c = 0; c < myIngredients.Count; c++)
            {
                myIngredients[c].printIngredient();
            }
            Console.WriteLine("Instruction List:");
            //    actions.InstructionsInRecipe(conn, id,userID);
            List<Instruction> myInstructions=operations.allInstructionsInRecipe(connection, userID, id);
            int test= myInstructions.Count;
            Console.WriteLine("Instruction count from cook smart: " + test);
            for(int d = 0; d < myInstructions.Count; d++)
            {
                myInstructions[d].printInstructionToConsole();
                //string instructionName = myInstructions[d].getTitle();
                //Console.WriteLine("Hello: " + d+" "+instructionName);
            }

            Console.WriteLine();
        }
    }
}
