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
            while (reader.Read())
            {


                string idString = reader["RecipeID"].ToString();
                int id = 9999;
                bool parse = int.TryParse(idString, out id);

                string servingString = reader["ServingSize"].ToString();
                int servingSize = 9999;
                bool parse2 = int.TryParse(servingString, out servingSize);
                Recipe tempRecipe = new Recipe(id, reader["Title"].ToString(), reader["Description"].ToString(), servingSize);
                string relavent = tempRecipe.getRelavent();
                Console.Write(relavent + "\n");
            }
            reader.Close();
            conn.Close();
            //    return ingredients;
        }

        public List<Instruction> allInstructions(MySqlConnection conn)
        {
            List<Instruction> instructions = new List<Instruction>();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.Write(ex + "\n");
                Console.Write("connection failed, zoroAster says: Check that your IP is validated" + "\n");
            }
            string Action = "AllInstructions";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters["?RecipeInput"].Direction = ParameterDirection.Input;
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                List<String> columnNames = GetDataReaderColumnNames(reader);
                for (int b = 0; b < columnNames.Count; b++)
                {
                    Console.Write(columnNames.ElementAt(b) + " ");
                }
                while (reader.Read())
                {
                    Console.WriteLine(reader["InstructionID"].ToString() + " " + reader["Title"].ToString() + " " + reader["Order"].ToString());
                    //string idString = reader["IngredientID"].ToString();
                    //int id = 9999;
                    //bool parse = int.TryParse(idString, out id);
                    //Ingredient temp = new Ingredient(id, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString());
                    //ingredients.Add(temp);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.Write("Reader failed for ingredients" + "\n");
            }
            return instructions;
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
                Console.Write(ex + "\n");
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

        public void IngredientsInInstruction(MySqlConnection conn)
        {
            try
            {


                Console.WriteLine("What instruction would you like to see (id int+ENTR)?" + "\n");
                string userInput = Console.ReadLine();
                int instructionID;
                bool parse = int.TryParse(userInput, out instructionID);

                if (parse)
                {
                    conn.Open();
                    string Action = "IngredientsInInstruction";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InputInstruction", instructionID);

                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    for (int b = 0; b < columnNames.Count; b++)
                    {
                        Console.Write(columnNames.ElementAt(b) + " ");
                    }
                    while (reader.Read())
                    {

                        //   Console.Write("\n");
                        Console.WriteLine(reader["Title"].ToString() + " " + reader["Quantity"]);
                        //string idString = reader["InstructionID"].ToString();
                        //int id = 9999;
                        //bool parse2 = int.TryParse(idString, out id);

                        //Ingredient temp = new Ingredient(id, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString());
                        //temp.printIngredient();
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
        }

        public void InstructionsInRecipe(MySqlConnection conn)
        {
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
                    string Action = "InstructionsInRecipe";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@recipeid", recipeID);
                    //command.Parameters["?RecipeInput"].Direction = ParameterDirection.Input;
                    //command.CommandText = "CREATE PROCEDURE `ViewRecipes`() NOT DETERMINISTIC READS SQL DATA SQL SECURITY DEFINER SELECT Recipe.Title, Recipe.RecipeID FROM Recipe ORDER BY Recipe.Title";
                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    for (int b = 0; b < columnNames.Count; b++)
                    {
                        Console.Write(columnNames.ElementAt(b) + " ");
                    }
                    while (reader.Read())
                    {

                        //   Console.Write("\n");
                        Console.WriteLine(reader["Title"].ToString()+" "+reader["Order"].ToString());
                        //string idString = reader["InstructionID"].ToString();
                        //int id = 9999;
                        //bool parse2 = int.TryParse(idString, out id);

                        //Ingredient temp = new Ingredient(id, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString());
                        //temp.printIngredient();
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
        }


        public void ShoppingListFromRecipe(MySqlConnection connn)
        {

            //   string connString = "Server= 108.167.137.112;Port=3306;Database=tractio2_CookSmart;uid=tractio2_Frank;password=Pa88word";
            //   MySqlConnection conn = new MySqlConnection(connString);
            MySqlConnection conn = connn;
            try
            {
                //   Console.WriteLine("Connecting to MySQL..." + "\n");
                Console.WriteLine("What recipe would you like to buy (id int+ENTR)?" + "\n");
                string userInput = Console.ReadLine();
                int recipeID;
                bool parse = int.TryParse(userInput, out recipeID);

                if (parse)
                {
                    conn.Open();
                  //  Console.WriteLine("before the break");
                    string Action = "ShoppingListFromRecipeViaInstruction";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@recipeid", recipeID);
                    //command.Parameters["?RecipeInput"].Direction = ParameterDirection.Input;
                    //command.CommandText = "CREATE PROCEDURE `ViewRecipes`() NOT DETERMINISTIC READS SQL DATA SQL SECURITY DEFINER SELECT Recipe.Title, Recipe.RecipeID FROM Recipe ORDER BY Recipe.Title";
                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    for (int b = 0; b < columnNames.Count; b++)
                    {
                            Console.Write(columnNames.ElementAt(b) + " ");
                    }
                    while (reader.Read())
                    {

                        //   Console.Write("\n");
                        Console.WriteLine(reader["Title"].ToString() + " " + reader["Quantity"] + " " + reader["QuantityType"]);
                        string idString = reader["RecipeID"].ToString();
                        int id = 9999;
                        bool parse2 = int.TryParse(idString, out id);

                        //Ingredient temp = new Ingredient(id, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString());
                        //temp.printIngredient();
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
            Console.WriteLine("done p");
            Console.ReadLine();

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
                int recipeID;
                bool parse = int.TryParse(userInput, out recipeID);

                if (parse)
                {
                    conn.Open();
                    string Action = "IngredientsInRecipe";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@recipeid", recipeID);
                    //command.Parameters["?RecipeInput"].Direction = ParameterDirection.Input;
                    //command.CommandText = "CREATE PROCEDURE `ViewRecipes`() NOT DETERMINISTIC READS SQL DATA SQL SECURITY DEFINER SELECT Recipe.Title, Recipe.RecipeID FROM Recipe ORDER BY Recipe.Title";
                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    for (int b = 0; b < columnNames.Count; b++)
                    {
                             Console.Write(columnNames.ElementAt(b) + " ");
                    }
                    Console.WriteLine();
                    while (reader.Read())
                    {

                        //   Console.Write("\n");
                        Console.WriteLine(reader["Title"].ToString() + " " + reader["Quantity"]);
                        //   string idString = reader["IngredientID"].ToString();
                        string idString = " ";
                        int id = 9999;
                        bool parse2 = int.TryParse(idString, out id);

                        //Ingredient temp = new Ingredient(id, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString());
                        //temp.printIngredient();
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
            Console.WriteLine("done q");
            Console.ReadLine();

        }

        public void ShoppingListFromRecipe(MySqlConnection connn, int recipeID)
        {
            MySqlConnection conn = connn;
            try
            {
                bool parse = true;
                if (parse)
                {
                    conn.Open();
                    string Action = "ShoppingListFromRecipeViaInstruction";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("recipeid", recipeID);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    for (int b = 0; b < columnNames.Count; b++)
                    {
                        //      Console.Write(columnNames.ElementAt(b) + " ");
                    }
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Title"].ToString() + " " + reader["Quantity"].ToString() + " " + reader["QuantityType"].ToString());
                    }
                    reader.Close();
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            Console.WriteLine();
         }


        public void IngredientsInRecipe(MySqlConnection connn, int recipeID)
        {

            //   string connString = "Server= 108.167.137.112;Port=3306;Database=tractio2_CookSmart;uid=tractio2_Frank;password=Pa88word";
            //   MySqlConnection conn = new MySqlConnection(connString);
            MySqlConnection conn = connn;
            try
            {
                //   Console.WriteLine("Connecting to MySQL..." + "\n");
                bool parse = true;
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
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    for (int b = 0; b < columnNames.Count; b++)
                    {
                  //      Console.Write(columnNames.ElementAt(b) + " ");
                    }
                    while (reader.Read())
                    {

                        //   Console.Write("\n");
                        Console.WriteLine(reader["Title"].ToString());
                        string idString = reader["IngredientID"].ToString();
                        int id = 9999;
                        bool parse2 = int.TryParse(idString, out id);

                        //Ingredient temp = new Ingredient(id, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString());
                        //temp.printIngredient();
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


        public void InstructionsInRecipe(MySqlConnection conn, int recipeID)
        {
            try
            {
                bool parse = true;

                if (parse)
                {
                    conn.Open();
                    string Action = "InstructionsInRecipe";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@recipeid", recipeID);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    for (int b = 0; b < columnNames.Count; b++)
                    {
                       // Console.Write(columnNames.ElementAt(b) + " ");
                    }
                    while (reader.Read())
                    {

                        //   Console.Write("\n");
                        Console.WriteLine(reader["Title"].ToString());
                        //string idString = reader["InstructionID"].ToString();
                        //int id = 9999;
                        //bool parse2 = int.TryParse(idString, out id);

                        //Ingredient temp = new Ingredient(id, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString());
                        //temp.printIngredient();
                    }
                    Console.WriteLine();
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
        }
    }
}