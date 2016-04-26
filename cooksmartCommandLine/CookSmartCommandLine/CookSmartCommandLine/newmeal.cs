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
    public class newmeal
    {
        Operator operations = new Operator();
        public Actions actions = new Actions();
        public newmeal()
        {

        }
        public void startupnewmeal(String connection)
        {
            MySqlConnection conn = new MySqlConnection(connection);
            Console.WriteLine("Input Recipe Name:");
            string RecipeName = Console.ReadLine();
            Console.WriteLine("Input Recipe Description");
            string RecipeDescription = Console.ReadLine();
            actions.AllRecipes(conn);
            Console.WriteLine("Are the ingredients you want here? y/n");
            string IngredientCheck = Console.ReadLine();
            if(IngredientCheck == "n")
            {

            }
        }
    }
}
