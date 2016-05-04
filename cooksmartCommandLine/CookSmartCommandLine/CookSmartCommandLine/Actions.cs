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

        public void DeleteInstructionWithIngredient(MySqlConnection conn, Instruction ins, int userID)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            String Action = "DeleteInstructionWithIngredient";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@instructionid", ins.getID());
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteInstructionWithoutIngredient(MySqlConnection conn, Instruction ins, int userID)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            String Action = "DeleteInstructionWithoutIngredient";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@instructionid", ins.getID());
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteRecipeWithInstruction(MySqlConnection conn, Recipe rec, int userID)
        {
            try
            {
                conn.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            String Action = "DeleteRecipeWithInstruction";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@recipeid", rec.getId());
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteRecipeWithoutInstruction(MySqlConnection conn, Recipe rec, int userID)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            String Action = "DeleteRecipeWithoutInstruction";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@recipeid", rec.getId());
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateQuantity(MySqlConnection conn, Instruction ins, Ingredient ing, int quantity, int userID)
        {
            try
            {
                   conn.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ing.setQuantity(quantity);
            String Action = "UpdateQuantity";

            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@instructionid", ins.getID());
            command.Parameters.AddWithValue("@ingredientid", ing.getId());
            command.Parameters.AddWithValue("@quantity", quantity);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void reorder(MySqlConnection conn, Recipe rec, Instruction ins, int order, int userID)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ins.setOrder(order);
            String Action = "Reorder";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@instructionid", ins.getID());
            command.Parameters.AddWithValue("@recipeid", rec.getId());
            command.Parameters.AddWithValue("@order", order);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateInstruction(MySqlConnection conn, string title, string description, int preptime, int cooktime, Instruction ins, int userID)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ins.setTitle(title);
            ins.setDescription(description);
            ins.setCookTime(cooktime);
            ins.setPrepTime(preptime);
            String Action = "UpdateInstruction";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@title", ins.getTitle());
            command.Parameters.AddWithValue("@description", ins.getDescription());
            command.Parameters.AddWithValue("@cooktime", ins.getCookTime());
            command.Parameters.AddWithValue("@preptime", ins.getPrepTime());
            command.Parameters.AddWithValue("@instructionid", ins.getID());
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateRecipe(MySqlConnection conn, string title, string description, int servingsize, Recipe rec, int userID)
            {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            rec.setName(title);
            rec.setDescription(description);
            rec.setServingSize(servingsize);
            rec.setUserID(userID);
            string Action = "UpdateRecipe";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@title", rec.getName());
            command.Parameters.AddWithValue("@description", rec.getDescription());
            command.Parameters.AddWithValue("@servingsize", rec.getServingSize());
            command.Parameters.AddWithValue("@instructionid", rec.getId());
            command.ExecuteNonQuery();
            conn.Close();
            }
        public void InsertIngredient(MySqlConnection conn, Ingredient ing, int userID)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("connection failed, zoroAster says: Check that your IP is validated");
            }
            string Action = "InsertIngredient";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@title", ing.getName());
            command.Parameters.AddWithValue("@description", ing.getDescription());
            command.Parameters.AddWithValue("@quantitytype", ing.getQuantityType());
            command.Parameters.AddWithValue("@userid", ing.getUserID());
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void InsertInstruction(MySqlConnection conn, Instruction ins, int userID)
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
            string Action = "InsertInstructionWithUser";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", ins.getTitle());
            command.Parameters.AddWithValue("@description", ins.getDescription());
            command.Parameters.AddWithValue("@userid", userID);

            command.ExecuteNonQuery();
            conn.Close();
        }
        public void InsertRecipe(MySqlConnection conn, Recipe rec, int userID)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("connection failed, zoroAster says: Check that your IP is valudated");
            }
            string Action = "InsertRecipe";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", rec.getName());
            command.Parameters.AddWithValue("@description", rec.getDescription());
            command.Parameters.AddWithValue("@servingsize", rec.getServingSize());
            command.Parameters.AddWithValue("@userid", userID);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public int GetInstructionID(MySqlConnection conn, int userID, Instruction Ins)
        {
            int instructionid = 0;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("connection failed, zoroAster says: Check that your IP is valudated");
            }
            string Action = "InstructionIDbyNameandUserID";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            string title = Ins.getTitle();
            Console.WriteLine("Title = " + title + " And Id = " + userID);
            command.Parameters.AddWithValue("@name", title);
            command.Parameters.AddWithValue("@userid", userID);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("test line on actions.cs ln100");
                instructionid = Convert.ToInt32(reader["InstructionID"].ToString());
            }
            reader.Close();
            conn.Close();
            return instructionid;
        }
        public int GetIngredientID(MySqlConnection conn, int userID, string title)
        {
            int ingredientid = 0;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Connection failed, zoroAster says: Check that your IP is validated");
            }
            string Action = "IngredientIDbyNameandUserID";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", title);
            command.Parameters.AddWithValue("@userid", userID);
            Console.WriteLine("Title = " + title + " And ID = " + userID);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ingredientid = Convert.ToInt32(reader["IngredientID"].ToString());
            }
            reader.Close();
            conn.Close();
            return ingredientid;
        }

        public int GetRecipeID(MySqlConnection conn, int userID, string title)
        {
            int recipeid = 0;
            Console.WriteLine("User ID is: " + userID.ToString());
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("connection failed, zoroAster says: Check that your IP is valudated");
            }
            string Action = "RecipeID byName andUserID";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;

            Console.WriteLine("Title = " + title + " And Id = " + userID);
            command.Parameters.AddWithValue("@name", title);
            command.Parameters.AddWithValue("@userid", userID);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                recipeid = Convert.ToInt32(reader["RecipeID"].ToString());
            }
            reader.Close();
            conn.Close();
            return recipeid;
        }

        public void insertInstructionRecipe(MySqlConnection conn, int userID, Recipe rec)
        {
            List<Instruction> InstructionList = rec.getInstructionList();
            string name = rec.getName();
            int recipeID = GetRecipeID(conn, userID, name);

            for (int i = 0; i < InstructionList.Count; i++)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("connection failed, zoroAster says: Check that your IP is valudated");
                }
                string Action = "InsertInstructionRecipe";
                MySqlCommand command = new MySqlCommand(Action, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("recipeid", recipeID);
                command.Parameters.AddWithValue("instructionid", rec.getInstructionList()[i].getID());
                command.Parameters.AddWithValue("orderer", rec.getInstructionList()[i].getOrder());
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void insertRecipeIngredient(MySqlConnection conn, int userID, Recipe rec)
        {
            List<Ingredient> IngredientList = rec.getRecipeIngredient();
            int recipeID = rec.getId();

            for (int i = 0; i < IngredientList.Count; i++)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine("connection failed, zoroAster says: Check that your IP is valudated");
                }
                string Action = "InsertRecipeIngredient";
                MySqlCommand command = new MySqlCommand(Action, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("recipeid", recipeID);
                command.Parameters.AddWithValue("ingredientid", IngredientList[i].getId());
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void insertInstructionIngredient(MySqlConnection conn, int userID, Recipe rec)
        {
            List<Instruction> InstructionList = rec.getInstructionList();
            for (int i = 0; i < InstructionList.Count; i++)
            {
                List<Ingredient> IngredientList = InstructionList[i].getInstructionIngredients();
                for (int j = 0; j < IngredientList.Count; j++)
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("connection failed, zoroAster says: Check that your IP is valudated");
                    }
                    string Action = "InsertInstructionIngredient";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    Console.WriteLine("action testing ln209");
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("ingredientid", IngredientList[j].getId());
                    command.Parameters.AddWithValue("instructionid", InstructionList[i].getID());
                    command.Parameters.AddWithValue("quantity", IngredientList[j].getQuantity());
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }



        public Ingredient StoreIngredient(MySqlConnection conn, int userid)
        {
            Console.WriteLine("Input Ingredient Name");
            string IngName = Console.ReadLine();
            Console.WriteLine("Input Ingredient Description");
            string IngDesc = Console.ReadLine();
            Console.WriteLine("Input Ingredient Quantity Type");
            string IngType = Console.ReadLine();
            int IngCount = 0;
            Ingredient newing = new Ingredient(IngCount, IngName, IngDesc, IngType, userid);

            return newing;
        }
        public Instruction StoreInstruction(MySqlConnection conn, int userID, int order)
        {
            Console.WriteLine("Input Instruction Name");
            string InsName = Console.ReadLine();
            Console.WriteLine("Input Ingredient Description");
            string InsDesc = Console.ReadLine();

            Instruction newins = new Instruction(0, InsName, InsDesc, userID);
            newins.setOrder(order);

            return newins;
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

        public List<Instruction> allInstructions(MySqlConnection conn, int userID)
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
                    string idString = reader["InstructionID"].ToString();
                    int id = 9999;
                    bool parse = int.TryParse(idString, out id);
                    Instruction temp = new Instruction(id, reader["Title"].ToString(), reader["Description"].ToString(), userID);
                    instructions.Add(temp);
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
                int Yearint = Convert.ToInt32(Year);
                int Monthint = Convert.ToInt32(Month);
                int Dayint = Convert.ToInt32(Day);
                DateTime selected = new DateTime(Yearint, Monthint, Dayint);
                Console.WriteLine(selected);
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
                        string quantitystring = reader["Totalquantity"].ToString();
                        decimal newquantity = Convert.ToDecimal(quantitystring);
                        string tempDateTimeString = reader["InputDate"].ToString();
                        Console.WriteLine(tempDateTimeString + "Tom & Pete");
                        DateTime Outputdate = stringToDateTime(tempDateTimeString);
                        Kitchen temp = new Kitchen(reader["Title"].ToString(), reader["Description"].ToString(), newquantity, reader["QuantityType"].ToString(), Outputdate);
                        ShoppingList.Add(temp);
                    }
                    reader.Close();
                    conn.Close();
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
        public void ShoppingListByDay(MySqlConnection conn, DateTime selected)
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

                    string quantitystring = reader["Totalquantity"].ToString();
                    decimal newquantity = Convert.ToDecimal(quantitystring);
                    string tempDateTimeString = reader["InputDate"].ToString();
                    DateTime Outputdate = stringToDateTime(tempDateTimeString);
                    Console.WriteLine(tempDateTimeString + "Tom & Pete");
                    Kitchen temp = new Kitchen(reader["Title"].ToString(), reader["Description"].ToString(), newquantity, reader["QuantityType"].ToString(), Outputdate);
                    ShoppingList.Add(temp);
                }
                reader.Close();
                conn.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Done 8");
        }


        public List<Ingredient> allIngredients(MySqlConnection conn, int userID)
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
            Console.WriteLine("taxi test");
            //command.Parameters["?RecipeInput"].Direction = ParameterDirection.Input;
            try {
                MySqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("inside the function");
                List<String> columnnames = GetDataReaderColumnNames(reader);
                for (int i = 0; i < columnnames.Count(); i++)
                {
                    Console.Write(" " + columnnames.ElementAt(i));
                }

                while (reader.Read())
                {
                    string idString = reader["IngredientID"].ToString();
                    int id = 9999;
                    bool parse = int.TryParse(idString, out id);
                    Ingredient temp = new Ingredient(id, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString(), userID);
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
                    conn.Close();
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
                    conn.Close();
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
        public void ShoppingListFromRecipe(MySqlConnection connn, Recipe rec)
        {

            //   string connString = "Server= 108.167.137.112;Port=3306;Database=tractio2_CookSmart;uid=tractio2_Frank;password=Pa88word";
            //   MySqlConnection conn = new MySqlConnection(connString);
            MySqlConnection conn = connn;
            try
            {
                //   Console.WriteLine("Connecting to MySQL..." + "\n");
                int recipeID = rec.getId();

                bool parse = true;
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


            conn.Close();
        }


        public void ShoppingListGetRecipe(MySqlConnection connn)
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


            conn.Close();
            Console.ReadLine();
        }

        public List<Ingredient> IngredientsByUser(MySqlConnection connn)
        {
            List<Ingredient> ReturnIngredients = new List<Ingredient>();
            MySqlConnection conn = connn;
            try
            {
                Console.WriteLine("What User ID? (ID + ENTER)?");
                int userID = Convert.ToInt32(Console.ReadLine());
                bool parse = true;
                if (parse)
                {
                    conn.Open();
                    string Action = "IngredientsByUser";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userid", userID);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    while (reader.Read())
                    {
                        string idstring = reader["IngredientID"].ToString();
                        int id = Convert.ToInt32(idstring);
                        Ingredient temp = new Ingredient(id, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString(), userID);
                        ReturnIngredients.Add(temp);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            Console.WriteLine("done");

            return ReturnIngredients;

        }

        public List<Instruction> InstructionsByUser(MySqlConnection connn)
        {
            List<Instruction> ReturnInstructions = new List<Instruction>();
            MySqlConnection conn = connn;
            try
            {
                Console.WriteLine("What User ID? (ID + ENTR)?");
                int userID = Convert.ToInt32(Console.ReadLine());
                bool parse = true;
                if (parse)
                {
                    conn.Open();
                    string Action = "InstructionsByUser";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userid", userID);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    while (reader.Read())
                    {
                        string idstring = reader["InstructionID"].ToString();
                        int id = Convert.ToInt32(idstring);
                        Instruction temp = new Instruction(id, reader["Title"].ToString(), reader["Description"].ToString(), userID);
                        ReturnInstructions.Add(temp);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            Console.WriteLine("done");
            return ReturnInstructions;
        }

        public List<Recipe> RecipesByUser(MySqlConnection connn)
        {
            List<Recipe> ReturnRecipes = new List<Recipe>();
            MySqlConnection conn = connn;
            try
            {
                Console.WriteLine("What User ID? (ID +ENTR)?" + "\n");
                int userID = Convert.ToInt32(Console.ReadLine());
                bool parse = true;
                if (parse)
                {
                    conn.Open();
                    string Action = "RecipesByUser";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@userid", userID);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    while (reader.Read())
                    {
                        string idstring = reader["RecipeID"].ToString();
                        int id = Convert.ToInt32(idstring);
                        string servingsizestring = reader["ServingSize"].ToString();
                        int servingsize = Convert.ToInt32(servingsizestring);
                        Recipe temp = new Recipe(id, reader["Title"].ToString(), reader["Description"].ToString(), servingsize, userID);
                        ReturnRecipes.Add(temp);
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
            return ReturnRecipes;
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

        public DateTime stringToDateTime(string stringIN)
        {
            // Console.WriteLine("Date string: " + stringIN);
            string tempDateTimeString = stringIN;
            string month = "";
            string day = "";
            string year = "";
            int count = 0;
            for (int i = 0; i < 10; i++)
            {

                if (tempDateTimeString.ElementAt(i) != '/')
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
            string hours = "";
            string minutes = "";
            string seconds = "";
            bool am = true;
            int spaceCount = 0;
            int colonCount = 0;
            for (int b = 0; b < tempDateTimeString.Count(); b++)
            {
                if (tempDateTimeString.ElementAt(b) == ' ')
                {
                    spaceCount++;
                }
                if (tempDateTimeString.ElementAt(b) != ':')
                {


                    if (spaceCount == 1 && colonCount == 0)
                    {
                        hours = hours + tempDateTimeString.ElementAt(b);
                    }
                    if (spaceCount == 1 && colonCount == 1)
                    {
                        minutes = minutes + tempDateTimeString.ElementAt(b);
                    }
                    if (spaceCount == 1 && colonCount == 2)
                    {
                        seconds = seconds + tempDateTimeString.ElementAt(b);
                    }

                }

                if (spaceCount == 2 && colonCount == 2)
                {
                    if (tempDateTimeString.ElementAt(b) == 'P')
                    {
                        am = false;
                    }
                }
                if (tempDateTimeString.ElementAt(b) == ':')
                {
                    colonCount++;
                }
            }

            minutes = minutes.Trim();
            seconds = seconds.Trim();
            hours = hours.Trim();


            int minInt = Convert.ToInt32(minutes);
            int hoursInt = Convert.ToInt32(hours);
            int secondsInt = Convert.ToInt32(seconds);

            if (am == false)
            {
                if (hoursInt != 12)
                {
                    hoursInt = hoursInt + 12;
                }
            }

            int yearint = Convert.ToInt32(year);
            int monthint = Convert.ToInt32(month);
            int dayint = Convert.ToInt32(day);
            // DateTime Outputdate = new DateTime(yearint, monthint, dayint, hoursInt,minInt,secondsInt);
            DateTime Outputdate = new DateTime(yearint, monthint, dayint, hoursInt, minInt, secondsInt);
            DateTime newoutput = Outputdate.AddHours(hoursInt);
            int temphour = Outputdate.Hour;

            //Outputdate.AddHours(hoursInt);


            return Outputdate;
        }
        public List<Kitchen> UserKitchen(MySqlConnection connn)
        {
            List<Kitchen> UserKitchen = new List<Kitchen>();
            MySqlConnection conn = connn;
            int userID = 0;
            Console.WriteLine("What user would you like to see (id int+ENTR*)?" + "\n");
            string userInput = Console.ReadLine();
            bool parse = int.TryParse(userInput, out userID);
            try
            {
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
                        decimal newquantity = Convert.ToDecimal(quantitystring);
                        string tempDateTimeString = reader["PutOnShelf"].ToString();

                        DateTime Outputdate = stringToDateTime(tempDateTimeString);
                        Console.WriteLine(reader["Title"].ToString());

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

        public Instruction InstructionByName(MySqlConnection connn, int guserID)
        {
            Instruction MyInstruction = new Instruction(guserID);
            MySqlConnection conn = connn;
            string InsName = "";
            try
            {
                Console.WriteLine("What Instruction Name? (name string +ENTR)?" + "\n");
                InsName = Console.ReadLine();
                bool parse = true;
                if (parse)
                {
                    conn.Open();

                    string Action = "InstructionByName";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@inputname", InsName);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        List<String> columnNames = GetDataReaderColumnNames(reader);
                        string insIDstring = reader["InstructionID"].ToString();
                        int insID = Convert.ToInt32(insIDstring);


                        MyInstruction = new Instruction(insID, reader["Title"].ToString(), reader["Description"].ToString(), guserID);
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
            //Console.WriteLine(MyInstruction.printInstruction());
            return MyInstruction;
        }
        public Instruction InstructionByID(MySqlConnection connn, int guserID)
        {
            Instruction MyInstruction = new Instruction(guserID);
            MySqlConnection conn = connn;
            int instructionid = 999;
            try
            {
                Console.WriteLine("What Instruction ID? (ID +ENTR)?" + "\n");
                instructionid = Convert.ToInt32(Console.ReadLine());
                bool parse = true;
                if (parse)
                {
                    conn.Open();

                    string Action = "InstructionByID";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@instructionid", instructionid);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        List<String> columnNames = GetDataReaderColumnNames(reader);


                        MyInstruction = new Instruction(instructionid, reader["Title"].ToString(), reader["Description"].ToString(), guserID);
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
            //Console.WriteLine(MyInstruction.printInstruction());
            return MyInstruction;
        }



        public Ingredient GetIngredientFromID(MySqlConnection connn, int userID, int ingredientid)
        {
            Ingredient MyIngredient = new Ingredient();
            MySqlConnection conn = connn;
            try
            {
                bool parse = true;
                if (parse)
                {
                    conn.Open();
                    string Action = "IngredientByID";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ingredientid", ingredientid);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        List<String> columnNames = GetDataReaderColumnNames(reader);
                        MyIngredient = new Ingredient(ingredientid, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString(), userID);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return MyIngredient;
            }
        public Ingredient GetIngredientByID(MySqlConnection connn, int userID)
        {
            Ingredient MyIngredient = new Ingredient();
            MySqlConnection conn = connn;
            int ingredientID = 0;
            try
            {
                Console.WriteLine("What Ingredient ID? (int id + ENTR)?");
                ingredientID = Convert.ToInt32(Console.ReadLine());
                bool parse = true;
                if (parse)
                {
                    conn.Open();
                    string Action = "IngredientByID";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ingredientid", ingredientID);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        List<String> columnNames = GetDataReaderColumnNames(reader);
                        MyIngredient = new Ingredient(ingredientID, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString(), userID);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return MyIngredient;
        }

        public Recipe GetRecipeByID(MySqlConnection connn, int userID)
        {
            Recipe MyRecipe = new Recipe(userID);
            MySqlConnection conn = connn;
            int recipeID = 0;
            int servingsize = 0;
            try
            {
                Console.WriteLine("What Recipe Id? (int id +ENTR)?" + "\n");
                recipeID = Convert.ToInt32(Console.ReadLine());
                bool parse = true;
                if (parse)
                {
                    conn.Open();

                    string Action = "RecipeByID";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@recipeid", recipeID);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        List<String> columnNames = GetDataReaderColumnNames(reader);
                        string servingSizeString = reader["ServingSize"].ToString();
                        servingsize = Convert.ToInt32(servingSizeString);


                        MyRecipe = new Recipe(recipeID, reader["Title"].ToString(), reader["Description"].ToString(), servingsize, userID);
                    }
                    reader.Close();
                    conn.Close();
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
            return MyRecipe;
        }

        public Ingredient IngredientByName(MySqlConnection connn, int userID)
        {
            Ingredient MyIngredient = new Ingredient();
            MySqlConnection conn = connn;
            string IngName = "";
            try
            {
                Console.WriteLine("What Ingredient Name? (name string +ENTR)?" + "\n");
                IngName = Console.ReadLine();
                bool parse = true;
                if (parse)
                {
                    conn.Open();
                    
                        string Action = "IngredientByName";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    
                    command.Parameters.AddWithValue("@inputname", IngName);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        List<String> columnNames = GetDataReaderColumnNames(reader);
                    string userIDstring = reader["id"].ToString();
                    userID = Convert.ToInt32(userIDstring);
                    
                    
                        MyIngredient =  new Ingredient(userID, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString(), userID);
                    }
                    reader.Close();
                    conn.Close();
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
            return MyIngredient;
        }

        public List<Calendar> UserCalendar(MySqlConnection connn)
        {
            List<Calendar> UserCalendar = new List<Calendar>();
            MySqlConnection conn = connn;
            int userID = 0;
            try
            {
                Console.WriteLine("What user would you like to see (id int+ENTR)?" + "\n");
                string userInput = Console.ReadLine();
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
                    
                    while (reader.Read())
                    {
                        string tempDateTimeString = reader["TimeToBeServed"].ToString();
                        DateTime newDateTime;
                        //  Console.WriteLine(reader["Name"].ToString()+" "+tempDateTimeString);
                        newDateTime = stringToDateTime(tempDateTimeString);
                        
                        Calendar temp = new Calendar(reader["Name"].ToString(), reader["Description"].ToString(), newDateTime, DateTime.Now);
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
         //   Console.ReadLine();
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
                    Console.WriteLine("post columuns");
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
                    conn.Close();
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

        public void IngredientsFromRecipe(MySqlConnection connn, Recipe rec)
        {

            //   string connString = "Server= 108.167.137.112;Port=3306;Database=tractio2_CookSmart;uid=tractio2_Frank;password=Pa88word";
            //   MySqlConnection conn = new MySqlConnection(connString);
            MySqlConnection conn = connn;
            try
            {

                int recipeID = rec.getId();
                bool parse = true;

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
                    conn.Close();
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
                        string idString = reader["id"].ToString();
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