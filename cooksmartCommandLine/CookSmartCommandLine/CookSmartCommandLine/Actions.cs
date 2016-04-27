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
        public void InsertIngredient(MySqlConnection conn)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("connection failed, zoroAster says: Check that your IP is validated");
            }
            string Action = "InsertIngredient";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            Console.WriteLine("Input Ingredient Name");
            string IngName = Console.ReadLine();
            Console.WriteLine("Input Ingredient Description");
            string IngDesc = Console.ReadLine();
            Console.WriteLine("Input Ingredient Quantity Type");
            string IngType = Console.ReadLine();
            List<Ingredient> ings = allIngredients(conn);
            int IngCount = ings.Count() + 2;
            command.Parameters.AddWithValue("@id", IngCount);
            command.Parameters.AddWithValue("@title", IngName);
            command.Parameters.AddWithValue("@description", IngDesc);
            command.Parameters.AddWithValue("@quantitytype", IngType);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public List<Ingredient> StoreIngredient(MySqlConnection conn, List<Ingredient> ings)
        {
            Console.WriteLine("Input Ingredient Name");
            string IngName = Console.ReadLine();
            Console.WriteLine("Input Ingredient Description");
            string IngDesc = Console.ReadLine();
            Console.WriteLine("Input Ingredient Quantity Type");
            string IngType = Console.ReadLine();
            int IngCount = ings.Count() + 2;
            Ingredient newing = new Ingredient(IngCount, IngName, IngDesc, IngType);
            ings.Add(newing);
            return ings;
        }

        public List<Recipe> AllRecipes(MySqlConnection conn)
        {
            List<Recipe> recipes = new List<Recipe>();
            try
            {
                //finny fail
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.Write(ex + "\n");
                Console.Write("connection failed, zoroAster says: Check that your IP is validated" + "\n");
            }
            string Action = "AllRecipesAlphabetical";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters["?RecipeInput"].Direction = ParameterDirection.Input;
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["RecipeID"].ToString() + " " + reader["Title"].ToString() + " " + reader["Description"].ToString() + " " + reader["ServingSize"].ToString());
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
                Console.WriteLine(ex.ToString());
                Console.Write("Reader failed for ingredients!" + "\n");
            }
            return recipes;
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
                    //Console.WriteLine(reader["InstructionID"].ToString() + " " + reader["Title"].ToString() + " " + reader["Order"].ToString());
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


        public List<Kitchen> ShoppingListByDay(MySqlConnection conn)
        {
            List<Kitchen> ShoppingList = new List<Kitchen>();
            try
            {


                Console.WriteLine("What year (id + entr \n");
                string Year = Console.ReadLine();
                Console.WriteLine("What Month?");
                string Month = Console.ReadLine();
                Console.WriteLine("What Day? peter and tom");
                string Day = Console.ReadLine();
                DateTime selected = new DateTime(Convert.ToInt32(Year), Convert.ToInt32(Month), Convert.ToInt32(Day));
                bool parse = true;
                
                if (parse)
                {
                    conn.Open();
                    string Action = "ShoppingListFromCalendar";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@inputdate", selected);

                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);

                    for (int b = 0; b < columnNames.Count; b++)
                    {

                        Console.Write(columnNames.ElementAt(b) + " ");
                    }
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        DateTime parsedDate;
                        
                        string datetimestring = reader["InputDate"].ToString();
                        Console.WriteLine(datetimestring);
                        string pattern = "mm/dd/yyyy";
                        int year = Convert.ToInt32(datetimestring.Split()[2]);
                        int day = Convert.ToInt32(datetimestring.Split()[1]);
                        int month = Convert.ToInt32(datetimestring.Split()[0]);
                        Console.Write("String datetime " + datetimestring + " year" + year);
                        DateTime present = new DateTime(1000, 0, 0);
                        bool parse3 = DateTime.TryParse(datetimestring, out present);
                        string quantitystring = reader["TotalQuantity"].ToString();
                        int quantity = -1;

                        if (DateTime.TryParseExact(datetimestring, pattern, null, System.Globalization.DateTimeStyles.None, out parsedDate))
                        {
                            Kitchen tempkitchen = new Kitchen(reader["Title"].ToString(), reader["Description"].ToString(), quantity, reader["QuantityType"].ToString(), new DateTime(2016,04,20));
                            ShoppingList.Add(tempkitchen);
                        }
                        else
                        {
                            Console.WriteLine("Couldn't get it to work");
                        }
                        bool parse2 = int.TryParse(quantitystring, out quantity);
                        
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
            Console.WriteLine("Done 9");
            return ShoppingList;
        }
        public List<Kitchen> ShoppingListByDay(MySqlConnection conn, DateTime selected)
        {
            List<Kitchen> ShoppingList = new List<Kitchen>();
            try
            {
                conn.Open();
            string Action = "ShoppingListFromCalendar";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@inputdate", selected);

            MySqlDataReader reader = command.ExecuteReader();
            List<String> columnNames = GetDataReaderColumnNames(reader);
            for (int b = 0; b < columnNames.Count; b++)
            {
                Console.Write(columnNames.ElementAt(b) + " ");
            }
            Console.WriteLine();
            while (reader.Read())
            {      
                
                string quantitystring = reader["TotalQuantity"].ToString();
                    int quantity = -1;
                    bool parse2 = int.TryParse(quantitystring, out quantity);
                    Kitchen tempkitchen = new Kitchen(reader["Title"].ToString(), reader["Description"].ToString(), quantity, reader["QuantityType"].ToString(), new DateTime(2016,04,20));

                    ShoppingList.Add(tempkitchen);
            }
            reader.Close();

}

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Done 8");
            return ShoppingList;
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


        public List<User> allUsers(MySqlConnection conn)
        {
            List<User> Users = new List<User>();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.Write(ex + "\n");
                Console.Write("connection failed, zoroAster says: Check that your IP is validated" + "\n");
            }
            string Action = "AllUsers";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters["?RecipeInput"].Direction = ParameterDirection.Input;
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string idString = reader["UserID"].ToString();
                    int id = 9999;
                    bool parse = int.TryParse(idString, out id);
                    User temp = new User(id, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["UserName"].ToString(), reader["DisplayName"].ToString(), reader["Password"].ToString());
                    Users.Add(temp);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.Write("Reader failed for users" + "\n");
            }
            return Users;
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
                    command.Parameters.AddWithValue("@instructionid", instructionID);

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

                    while (reader.Read())
                    {

                        //   Console.Write("\n");
                        Console.WriteLine(reader["Title"].ToString() + " " + reader["Order"].ToString());
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

        public void UserMeals(MySqlConnection connn, int userID)
        {
            MySqlConnection conn = connn;
            try
            {
                bool parse = true;
                if (parse)
                {
                    conn.Open();
                    string Action = "MealsByUser";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userid", userID);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    Console.WriteLine(reader["Title"].ToString() + "\n" + reader["Description"].ToString() + "\n");

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



        public void UserMeals(MySqlConnection connn)
        {

            //   string connString = "Server= 108.167.137.112;Port=3306;Database=tractio2_CookSmart;uid=tractio2_Frank;password=Pa88word";
            //   MySqlConnection conn = new MySqlConnection(connString);

            MySqlConnection conn = connn;
            try
            {
                //   Console.WriteLine("Connecting to MySQL..." + "\n");
                Console.WriteLine("What user would you like to see (id int+ENTR)?" + "\n");
                string userInput = Console.ReadLine();
                int userID;
                bool parse = int.TryParse(userInput, out userID);

                if (parse)
                {
                    conn.Open();
                    string Action = "MealsByUser";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userid", userID);
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
                        Console.WriteLine(reader["Name"].ToString() + "\n" + reader["Description"] + "\n");
                        //   string idString = reader["IngredientID"].ToString();
                        string idString = " ";
                        int id = 9999;
                        bool parse2 = int.TryParse(idString, out id);

                        //Ingredient temp = new Ingredient(id, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString());
                        //temp.printIngredient();
                    }
                    reader.Close();
                    if (parse == false)
                    {
                        Console.WriteLine("failed to parse your input sorry" + "\n");
                    }

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


        public List<Kitchen> UserKitchen(MySqlConnection connn)
        {
            List<Kitchen> UserKitchen = new List<Kitchen>();
            MySqlConnection conn = connn;
            try
            {
                Console.WriteLine("What user would you like to see (id int+ENTR)?" + "\n");
                string userInput = Console.ReadLine();
                int userID;
                bool parse = int.TryParse(userInput, out userID);

                if (parse)
                {
                    conn.Open();
                    string Action = "KitchenByUser";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userid", userID);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    for (int b = 0; b < columnNames.Count; b++)
                    {
                        Console.Write(columnNames.ElementAt(b) + " ");
                    }
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        string quantitystring = reader["quantity"].ToString();
                        int newquantity = Convert.ToInt32(quantitystring);
                        string tempDateTimeString = reader["PutOnShelf"].ToString();
                        Console.WriteLine(tempDateTimeString + "Tom & Pete");
                        string month="";
                        string day="";
                        string year="";
                        int count=0;
                        for (int i = 0; i < 10; i++)
                        {
                            
                            if (tempDateTimeString.ElementAt(i)!='/')
                            {
                                if (count == 0)
                                {
                                    month = month + tempDateTimeString.ElementAt(i);
                                    
                                }
                                if (count == 1)
                                {
                                    day = day + tempDateTimeString.ElementAt(i);
                                    
                                }
                                if (count == 2)
                                {
                                    year = year + tempDateTimeString.ElementAt(i);
                                    
                                }

                            }
                            if (tempDateTimeString.ElementAt(i) == '/')
                            {
                                count++;
                            }
                        }
                        Console.WriteLine("Month :" + month + " day: " + day + " year: " + year);
                        int yearint = Convert.ToInt32(year);
                        int monthint = Convert.ToInt32(month);
                        int dayint = Convert.ToInt32(day);
                        DateTime Outputdate = new DateTime(yearint, monthint, dayint);
                        Console.WriteLine();
                        Kitchen temp = new Kitchen(reader["Title"].ToString(), reader["Description"].ToString(), newquantity, reader["QuantityType"].ToString(), Outputdate);
                        UserKitchen.Add(temp);
                    }
                    reader.Close();
                    if (parse == false)
                    {
                        Console.WriteLine("failed to parse your input sorry" + "\n");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            conn.Close();
            Console.WriteLine("done");
            Console.ReadLine();
            return UserKitchen;
            }

        public List<Calendar> UserCalendar(MySqlConnection connn)
        {
            List<Calendar> UserCalendar = new List<Calendar>();
            MySqlConnection conn = connn;
            try
            {
                Console.WriteLine("What user would you like to see (id int+ENTR)?" + "\n");
                string userInput = Console.ReadLine();
                int userID;
                bool parse = int.TryParse(userInput, out userID);

                if (parse)
                {
                    conn.Open();
                    string Action = "CalendarByUser";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userid", userID);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    //for (int b = 0; b < columnNames.Count; b++)
                    //{
                    //    Console.Write(columnNames.ElementAt(b) + " ");
                    //}
                    //Console.WriteLine();
                    while (reader.Read())
                    {
                        string tempDateTimeString = reader["TimeToBeServed"].ToString();
                        DateTime newDateTime = Convert.ToDateTime(tempDateTimeString);
                        //Console.WriteLine();
                        Calendar temp = new Calendar(reader["Name"].ToString(), reader["Description"].ToString(), DateTime.Now, newDateTime);
                        UserCalendar.Add(temp);
                        //Console.WriteLine(reader["Name"].ToString() + " \n" + reader["Description"].ToString() + " \n" + reader["TimeToBeServed"].ToString());
                    }
                    reader.Close();
                    if (parse == false)
                    {
                        Console.WriteLine("failed to parse your input sorry" + "\n");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            conn.Close();
            Console.WriteLine("done");
            Console.ReadLine();
            return UserCalendar;
        }

        public void UserCalendar(MySqlConnection connn, int userID)
        {
            MySqlConnection conn = connn;
            try
            {
                bool parse = true;
                if (parse)
                {
                    conn.Open();
                    string Action = "CalendarByUser";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userid", userID);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    Console.WriteLine(reader["Name"].ToString() + " \n" + reader["Description"].ToString() + " \n" + reader["TimeToBeServed"].ToString());

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            conn.Close();
            Console.WriteLine("done 8");
            Console.ReadLine();

        }


        public void UserKitchen(MySqlConnection connn, int userID)
        {
            MySqlConnection conn = connn;
            try
            {
                bool parse = true;
                if (parse)
                {
                    conn.Open();
                    string Action = "KitchenByUser";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userid", userID);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    Console.WriteLine(reader["Title"].ToString());

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            conn.Close();
            Console.WriteLine("done 8");
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