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
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.Write(ex+"\n");
                Console.Write("connection failed, zoroAster says: Check that your IP is validated" + "\n");
            }
            string Action = "AllIngredientsAlphabetical";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters["?RecipeInput"].Direction = ParameterDirection.Input;
            try {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string idString = reader["IngredientID"].ToString();
                    int id = 9999;
                    bool parse = int.TryParse(idString, out id);
                    Ingredient temp = new Ingredient(id, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString());
                    ingredients.Add(temp);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.Write("Reader failed for ingredients" + "\n");
            }
            return ingredients;
        }

        public void IngredientsInRecipe(MySqlConnection conn)
        {

            //   string connString = "Server= 108.167.137.112;Port=3306;Database=tractio2_CookSmart;uid=tractio2_Frank;password=Pa88word";
            //   MySqlConnection conn = new MySqlConnection(connString);
         //   MySqlConnection conn = connn;
            try
            {
                //   Console.WriteLine("Connecting to MySQL..." + "\n");
                Console.WriteLine("What recipe would you like to see (id int+ENTR)?" + "\n");
                string userInput = Console.ReadLine();
                int recipeID;
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
                    List<String> columnNames=GetDataReaderColumnNames(reader);
                    for (int b = 0; b < columnNames.Count; b++)
                    {
                        Console.Write(columnNames.ElementAt(b) + " ");
                    }
                    Console.WriteLine();
                    while (reader.Read())
                    {

                        Console.Write(reader["Title"].ToString());
                        Console.Write("\n");
                        //Console.WriteLine(reader["Title"].ToString());
                        string idString = reader["IngredientID"].ToString();
                        int id = 9999;
                        bool parse2 = int.TryParse(idString, out id);

                        Ingredient temp = new Ingredient(id, reader["Title"].ToString(), reader["Description"].ToString(),"invald");
                        temp.printIngredient();
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
        static List<string> GetDataReaderColumnNames(IDataReader rdr)
        {
            var columnNames = new List<string>();
            for (int i = 0; i < rdr.FieldCount; i++)
                columnNames.Add(rdr.GetName(i));
            return columnNames;
        }

        public void AllRecipes(MySqlConnection conn)
        {
           // List<Ingredient> ingredients = new List<Ingredient>();

            conn.Open();
            string Action = "AllRecipesAlphabetical";
            // string Action = "AllIngredientsAlphabetical";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters["?RecipeInput"].Direction = ParameterDirection.Input;

            MySqlDataReader reader = command.ExecuteReader();
            List<String> columnNames = GetDataReaderColumnNames(reader);
            for (int b = 0; b < columnNames.Count; b++)
            {
               // Console.Write(columnNames.ElementAt(b) + "   ");
            }
            Console.WriteLine();

            while (reader.Read())
            {
                
       
                string idString = reader["RecipeID"].ToString();
                int id = 9999;
                bool parse = int.TryParse(idString, out id);
                
                string servingString = reader["ServingSize"].ToString();
                int servingSize = 9999;
                bool parse2 = int.TryParse(servingString, out servingSize);
                Recipe tempRecipe = new Recipe(id, reader["Title"].ToString(), reader["Description"].ToString(), servingSize);
                string relavent=tempRecipe.getRelavent();
                Console.Write(relavent + "\n");


                

                //string RecipeName = reader["Title"].ToString();
                //Console.Write(idString + "   " + RecipeName + "\n");
            }
            reader.Close();
            conn.Close();
        //    return ingredients;
        }


    }
}