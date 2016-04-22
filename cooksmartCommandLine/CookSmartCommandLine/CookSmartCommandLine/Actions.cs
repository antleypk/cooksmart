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
  public class Actions
    {
        public Actions()
        {

        }

        public List<Ingredient> allIngredients(MySqlConnection conn)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
         
            conn.Open();
            string Action = "AllIngredientsAlphabetical";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters["?RecipeInput"].Direction = ParameterDirection.Input;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string idString = reader["IngredientID"].ToString();
                int id=9999;
                bool parse = int.TryParse(idString, out id);
                Ingredient temp = new Ingredient(id, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString());
                ingredients.Add(temp);
            }
            reader.Close();
            conn.Close();
            return ingredients;
        }

        public void IngredientsInRecipe(MySqlConnection connn)
        {

            //   string connString = "Server= 108.167.137.112;Port=3306;Database=tractio2_CookSmart;uid=tractio2_Frank;password=Pa88word";
            //   MySqlConnection conn = new MySqlConnection(connString);
            MySqlConnection conn = connn;
            try
            {
                //   Console.WriteLine("Connecting to MySQL..." + "\n");
                Console.WriteLine("What recipe would you like to see (id int+ENTR)?" + "\n");
                string userInput = Console.ReadLine();
                int recipeID = 0;
                bool parse = int.TryParse(userInput, out recipeID);

                if (parse)
                {
                    conn.Open();
                    string Action = "IngredientsInRecipe";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RecipeInput", recipeID);
                    //command.Parameters["?RecipeInput"].Direction = ParameterDirection.Input;
                    //command.CommandText = "CREATE PROCEDURE `ViewRecipes`() NOT DETERMINISTIC READS SQL DATA SQL SECURITY DEFINER SELECT Recipe.Title, Recipe.RecipeID FROM Recipe ORDER BY Recipe.Title";
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Title"].ToString());
                    }
                    reader.Close();
                }
                if (parse == false)
                {
                    Console.WriteLine("failed to parse your input sorry" + "\n");
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            //while (reader.Read())
            //{
            //    Console.WriteLine(reader["RecipeID"].ToString());
            //    Console.WriteLine(reader["Title"].ToString());
            //}
            conn.Close();
            Console.WriteLine("done");
            Console.ReadLine();

        }

        public void AllRecipes(MySqlConnection conn)
        {
           // List<Ingredient> ingredients = new List<Ingredient>();

            conn.Open();
            string Action = "AllIngredientsAlphabetical";
            // string Action = "AllIngredientsAlphabetical";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters["?RecipeInput"].Direction = ParameterDirection.Input;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                reader["Title"].ToString();
                //string idString = reader["IngredientID"].ToString();
                //int id = 9999;
                //bool parse = int.TryParse(idString, out id);
                //Ingredient temp = new Ingredient(id, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString());
                //ingredients.Add(temp);
            }
            reader.Close();
            conn.Close();
        //    return ingredients;
        }


    }
}