using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.Collections.Generic;

namespace CookSmartCommandLine
{
  public  class CookSmart
    {
        Operator operations = new Operator();
        public Actions actions = new Actions();
        public CookSmart()
        {

        }


        public void startUpCookSmart(string connection)
        {
            operations.allRecipes(connection);
            Console.WriteLine("Select a Recipe by ID");
            string userInput = Console.ReadLine();
            //string idString = reader["IngredientID"].ToString();
            int id = 9999;
            bool parse = int.TryParse(userInput, out id);
            
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Ingredient List:");
            actions.ShoppingListFromRecipe(conn, id);
            Console.WriteLine("Instruction List:");
            actions.InstructionsInRecipe(conn, id);
        }
    }
}
