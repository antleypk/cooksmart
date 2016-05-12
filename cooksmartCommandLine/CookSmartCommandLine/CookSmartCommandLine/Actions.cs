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
            catch (Exception ex)
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
            catch (Exception ex)
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

        public int GetUserID(MySqlConnection conn, string username, string password)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            int userID = 987654321;
            String Action = "CheckUser";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("password", password);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                userID = Convert.ToInt32(reader["UserID"].ToString());
            }
            return userID;
        }


        public bool checkuser(MySqlConnection conn, string username, string password)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            int userID = 987654321;
            String Action = "CheckUser";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("password", password);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                userID = Convert.ToInt32(reader["UserID"].ToString());
            }
            conn.Close();
            return (!(userID == 987654321));
        }
        public bool checkusername(MySqlConnection conn, string username)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            int userID = 987654321;
            string Action = "CheckUserName";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("username", username);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                userID = Convert.ToInt32(reader["UserID"].ToString());
            }
            conn.Close();
            return (!(userID == 987654321));
        }

        public void updatelogins(MySqlConnection conn, List<DateTime> logins, string username)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            string Action = "updatenewlogins";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@first", logins[0]);
            command.Parameters.AddWithValue("@second", logins[1]);
            command.Parameters.AddWithValue("@third", logins[2]);
            command.Parameters.AddWithValue("@forth", logins[3]);
            command.Parameters.AddWithValue("@username", username);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public List<DateTime> userloginattempts(MySqlConnection conn, string userName)
        {
            List<DateTime> userlogins = new List<DateTime>();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            string Action = "userlogintimes";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("username", userName);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DateTime add1 = Convert.ToDateTime(reader["first"].ToString());
                DateTime add2 = Convert.ToDateTime(reader["second"].ToString());
                DateTime add3 = Convert.ToDateTime(reader["third"].ToString());
                DateTime add4 = Convert.ToDateTime(reader["forth"].ToString());

                userlogins.Add(add1);
                userlogins.Add(add2);
                userlogins.Add(add3);
                userlogins.Add(add4);
            }
            conn.Close();
            return userlogins;
        }




        public void UpdateInstruction(MySqlConnection conn, Instruction ins, int userID)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

        public void UpdateRecipe(MySqlConnection conn, Recipe rec, int userID)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            rec.setUserID(userID);
            rec.printRecipe();
            string Action = "UpdateRecipe";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", rec.getName());
            command.Parameters.AddWithValue("@description", rec.getDescription());
            command.Parameters.AddWithValue("@servingsize", rec.getServingSize());
            command.Parameters.AddWithValue("@recipeid", rec.getId());
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
        public void InsertMeal(MySqlConnection conn, Meal myMeal, int userID)
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
            string Action = "InsertNewMeal";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", myMeal.getName());
            command.Parameters.AddWithValue("@description", myMeal.getDescription());
          //  command.Parameters.AddWithValue("@desciption", myMeal.getDescription());
            command.Parameters.AddWithValue("@userid", userID);
           
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void InsertMealRecipe(MySqlConnection conn, int mealID, int userID, int recipeID)
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
            string Action = "InsertMealRecipe";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@recipeid", recipeID);
            command.Parameters.AddWithValue("@mealid", mealID);
            //  command.Parameters.AddWithValue("@desciption", myMeal.getDescription());
            command.Parameters.AddWithValue("@userid", userID);

            command.ExecuteNonQuery();
            conn.Close();
        }


        public int GetMealID(MySqlConnection conn, string name, int userID)
        {
            int mealID = 99999999;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("connection failed, zoroAster says: Check that your IP is valudated");
            }
            string Action = "MealIDByUserIDandName";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", name);
            //  command.Parameters.AddWithValue("@desciption", myMeal.getDescription());
            command.Parameters.AddWithValue("@userid", userID);
            command.ExecuteNonQuery();
            
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                mealID = Convert.ToInt32(reader["MealID"].ToString());
            }
            reader.Close();
            conn.Close();
            return mealID;
        }

        public void InsertCalendar(MySqlConnection conn, Calendar cal, int userID)
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
            string Action = "InsertCalendar";
            MySqlCommand command = new MySqlCommand(Action, conn);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@title", cal.getName());
            command.Parameters.AddWithValue("@description", cal.getDescription());
            command.Parameters.AddWithValue("@timetobeserved", cal.getTimeToBeServed());
            command.Parameters.AddWithValue("@inputdate", cal.getInputDate());
            command.Parameters.AddWithValue("@userid", cal.GetUserID());
            command.ExecuteNonQuery();
            conn.Close();
            command.CommandType = CommandType.StoredProcedure;
        }

        public void InsertUser(MySqlConnection conn, string userName, string password)
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
            string Action = "InsertUser";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", userName);
            command.Parameters.AddWithValue("@password", password);
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
            command.Parameters.AddWithValue("@name", title);
            command.Parameters.AddWithValue("@userid", userID);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
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
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("ingredientid", IngredientList[j].getId());
                    command.Parameters.AddWithValue("instructionid", InstructionList[i].getID());
                    command.Parameters.AddWithValue("quantity", IngredientList[j].getQuantity());
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
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
                    Console.WriteLine("ID: " + reader["RecipeID"].ToString() + " " + reader["Title"].ToString() + " " + reader["Description"].ToString() + " " + reader["ServingSize"].ToString());

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
        public List<Meal> AllMeals(MySqlConnection conn)
        {
            List<Meal> meals = new List<Meal>();
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
            string Action = "AllMeals";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters["?RecipeInput"].Direction = ParameterDirection.Input;
            try
            {
                int userID = 1;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                //    Console.WriteLine("ID: " + reader["MealID"].ToString() + " " + reader["Name"].ToString() + " " + reader["Description"].ToString() + " " + reader["DateTimeAdded"].ToString());
                    string mealString = reader["MealID"].ToString();
                    Meal temp = new Meal();
                    string userString = reader["UserID"].ToString();
                    int mealID = Convert.ToInt32(mealString);
                    bool parse = Int32.TryParse(userString, out userID);
                    if (parse)
                    {
                        temp.setName(reader["Name"].ToString());
                        temp.setID(userID);
                        temp.setDescription(reader["Description"].ToString());
                        temp.setUserID(userID);
                    }
                    if (!parse)
                    {
                        temp.setName(reader["Name"].ToString());
                        temp.setID(userID);
                        temp.setDescription(reader["Description"].ToString());
                        temp.setUserID(userID);
                    }
                    meals.Add(temp);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Write("Reader failed for ingredients!" + "\n");
            }
            return meals;
        }
        public List<Recipe> AllRecipesInMeal(MySqlConnection conn,int mealID,int userID)
        {
            List<Recipe> recipes = new List<Recipe>();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message + "\n");
                Console.Write("connection failed, zoroAster says: Check that your IP is validated" + "\n");
            }
            string Action = "RecipeByMeal";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.Parameters.AddWithValue("@mealid", mealID);
            command.CommandType = CommandType.StoredProcedure;
            Console.WriteLine("meal id: " + mealID);
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                   // Console.WriteLine("ID: " + reader["RecipeID"].ToString() + " " + reader["Title"].ToString() + " " + reader["Description"].ToString() + " " + reader["ServingSize"].ToString());
                    string idstring = reader["RecipeID"].ToString();
                    string description = reader["Description"].ToString();
                    string title = reader["Title"].ToString();
                    string servingString = reader["ServingSize"].ToString();
                    int id = Convert.ToInt32(idstring);
                    int servinSize = Convert.ToInt32(servingString);

                    Recipe tempRecipe = new Recipe(id, title, description, servinSize, userID);
                    recipes.Add(tempRecipe);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                Console.WriteLine(ex.Message);
                Console.Write("Reader failed for ingredients" + "\n");
            }
            return instructions;
        }

        public List<Kitchen> ShoppingListByUser(MySqlConnection conn, int userID)
        {
            List<Kitchen> ShoppingList = new List<Kitchen>();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.Write(ex + "\n");
                Console.Write("connection failed, zoroAster says: Check that your IP is validated" + "\n");
            }
            string Action = "ShoppingListByUser";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@userid", userID);

            MySqlDataReader reader = command.ExecuteReader();
            List<String> columnNames = GetDataReaderColumnNames(reader);

            for (int b = 0; b < columnNames.Count; b++)
            {
                Console.Write(columnNames.ElementAt(b) + " ");
            }
            while (reader.Read())
            {
                string quantitystring = reader["Quantity"].ToString();
                decimal newquantity = Convert.ToDecimal(quantitystring);
                string tempDateTimeString = reader["InputDate"].ToString();
                Console.WriteLine(tempDateTimeString + "Tom & Pete");
                DateTime Outputdate = stringToDateTime(tempDateTimeString);
                Kitchen temp = new Kitchen(reader["Title"].ToString(), reader["Description"].ToString(), newquantity, reader["QuantityType"].ToString(), Outputdate, userID);
                ShoppingList.Add(temp);
            }
            reader.Close();
            conn.Close();
            return ShoppingList;
        }



        public List<Kitchen> ShoppingListByDay(MySqlConnection conn, int userID)
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
                        string quantitystring = reader["Quantity"].ToString();
                        decimal newquantity = Convert.ToDecimal(quantitystring);
                        string tempDateTimeString = reader["InputDate"].ToString();
                        Console.WriteLine(tempDateTimeString + "Tom & Pete");
                        DateTime Outputdate = stringToDateTime(tempDateTimeString);
                        Kitchen temp = new Kitchen(reader["Title"].ToString(), reader["Description"].ToString(), newquantity, reader["QuantityType"].ToString(), Outputdate, userID);
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
        public void ShoppingListByDay(MySqlConnection conn, DateTime selected, int userID)
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
                    Kitchen temp = new Kitchen(reader["Title"].ToString(), reader["Description"].ToString(), newquantity, reader["QuantityType"].ToString(), Outputdate, userID);
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
      //      Console.WriteLine("taxi test");
            //command.Parameters["?RecipeInput"].Direction = ParameterDirection.Input;
            try {
                MySqlDataReader reader = command.ExecuteReader();
    //            Console.WriteLine("inside the function");
                //List<String> columnnames = GetDataReaderColumnNames(reader);
                //for (int i = 0; i < columnnames.Count(); i++)
                //{
                //    Console.Write(" " + columnnames.ElementAt(i));
                //}

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
                Console.WriteLine(ex.Message);
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
                Console.WriteLine(ex.Message);
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
                        Console.WriteLine(reader["Title"].ToString() + " " + reader["Quantity"]);                 
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

        public void printColumnNames(MySqlDataReader reader)
        {
            List<String> columnNames = GetDataReaderColumnNames(reader);
            for (int i = 0; i < columnNames.Count; i++)
            {
                Console.Write(" " + columnNames.ElementAt(i) + " ");
            }
            Console.WriteLine();
        }
        public void InstructionsInRecipe(MySqlConnection conn)
        {
            try
            {
           
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
                    MySqlDataReader reader = command.ExecuteReader();
                    printColumnNames(reader);
                    

                    while (reader.Read())
                    {
                        string orderstring = reader["Order"].ToString();
                        string cooktimestring = reader["CookTime"].ToString();
                        string preptimestring = reader["PrepTime"].ToString();

                        int order;
                        int cooktime;
                        int preptime;
                        bool orderbool = int.TryParse(orderstring, out order);
                        bool cookbool = int.TryParse(cooktimestring, out cooktime);
                        bool prepbool = int.TryParse(preptimestring, out preptime);
                        if(orderbool & cookbool & prepbool)
                        {
                            Console.WriteLine(reader["Title"].ToString() + " " + reader["Description"] + " Order: " + order + " cooktime: " + cooktime + " preptime: " + preptime);
                        }
                        else
                        {
                            Console.WriteLine("Title: " + reader["Title"].ToString());
                        }
  
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
//

        public void UserMealsf(MySqlConnection connn, int userID)
        {//all meals created by a user
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

            conn.Close();
            Console.WriteLine("done");
            Console.ReadLine();

        }

        public void UserMeals(MySqlConnection connn, int userID)
        {
            MySqlConnection conn = connn;
            try
            {
                //Console.WriteLine("What user would you like to see (id int+ENTR)?" + "\n");
                //string userInput = Console.ReadLine();
                //int userID;
                //bool parse = int.TryParse(userInput, out userID);
                bool parse = true;

                if (parse)
                {
                    conn.Open();
                    string Action = "MealByUser";
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
                        Console.WriteLine(reader["Name"].ToString() +" "+ reader["DateTimeAdded"].ToString() + "\n" + reader["Description"] + "\n");
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
        public List<Kitchen> UserKitchen(MySqlConnection connn, int userID)
        {
            List<Kitchen> UserKitchen = new List<Kitchen>();
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

                        Kitchen temp = new Kitchen(reader["Title"].ToString(), reader["Description"].ToString(), newquantity, reader["QuantityType"].ToString(), Outputdate, userID);
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

                    command.Parameters.AddWithValue("@insID", instructionid);
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
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    for(int i=0; i < columnNames.Count; i++)
                    {
                        string name=columnNames.ElementAt(i);
                        Console.Write(name + " ");
                    }
                    Console.WriteLine();
                    while (reader.Read())
                    {

                        string userIDstring = reader["IngredientID"].ToString();
                        userID = Convert.ToInt32(userIDstring);


                        MyIngredient = new Ingredient(userID, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString(), userID);
                    //    MyIngredient.printIngredient();
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

        public void UpdateCalendar(MySqlConnection conn, Calendar cal, int userID)
        {

            
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            String Action = "UpdateCalendar";
            MySqlCommand command = new MySqlCommand(Action, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@title", cal.getName());
            command.Parameters.AddWithValue("@description", cal.getDescription());
            command.Parameters.AddWithValue("@timetobeserved", cal.getTimeToBeServed());
            command.Parameters.AddWithValue("@inputdate", cal.getInputDate());
            command.ExecuteNonQuery();
            conn.Close();
        }

        public List<Calendar> MealCalendar(MySqlConnection conn, int userID)
        {
            List<Calendar> MealCalendar = new List<Calendar>();
            int mealID = 0;
            try
            {
                Console.WriteLine("What meal ID would you like to see (ID+ENTR)?" + "\n");
                string userInput = Console.ReadLine();
                bool parse = int.TryParse(userInput, out mealID);

                if (parse)
                {
                    conn.Open();
                    string Action = "CalendarByMeal";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@mealid", mealID);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);

                    while (reader.Read())
                    {
                        string tempDateTimeString = reader["TimeToBeServed"].ToString();
                        DateTime newDateTime;
                        //  Console.WriteLine(reader["Name"].ToString()+" "+tempDateTimeString);
                        newDateTime = stringToDateTime(tempDateTimeString);

                        Calendar temp = new Calendar(reader["Name"].ToString(), reader["Description"].ToString(), newDateTime, newDateTime.Date, userID,mealID);
                        MealCalendar.Add(temp);
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
            return MealCalendar;
        }

        public List<Calendar> MonthlyCalendar(MySqlConnection conn, int userID)
        {
            List<Calendar> MonthlyCalendar = new List<Calendar>();
            int yearselected = 0;
            int monthselected = 0;
            try
            {
                Console.WriteLine("What year would you like to see (year int+ENTR)?");
                string yearselectedstring = Console.ReadLine();
                Console.WriteLine("What month would you like to see (month int+ENTR)?");
                string monthselectedstring = Console.ReadLine();
                bool parseyear = int.TryParse(yearselectedstring, out yearselected);
                bool parsemonth = int.TryParse(monthselectedstring, out monthselected);

                if (parseyear & parsemonth)
                {
                    conn.Open();
                    string Action = "CalendarByMonth";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@yearselected", yearselected);
                    command.Parameters.AddWithValue("@monthselected", monthselected);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);

                    while (reader.Read())
                    {
                        string tempDateTimeString = reader["TimeToBeServed"].ToString();
                        DateTime newDateTime;
                        //  Console.WriteLine(reader["Name"].ToString()+" "+tempDateTimeString);
                        newDateTime = stringToDateTime(tempDateTimeString);

              //          Calendar temp = new Calendar(reader["Name"].ToString(), reader["Description"].ToString(), newDateTime, DateTime.Now, userID);
             //           MonthlyCalendar.Add(temp);
                        //Console.WriteLine(reader["Name"].ToString() + " \n" + reader["Description"].ToString() + " \n" + reader["TimeToBeServed"].ToString());
                    }
                    reader.Close();
                    if (!parseyear || !parsemonth)
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
            return MonthlyCalendar;
        }

        public List<Calendar> DailyCalendar(MySqlConnection conn, int userID)
        {
            List<Calendar> DailyCalendar = new List<Calendar>();
            int yearselected = 0;
            int monthselected = 0;
            int dayselected = 0;

            Console.WriteLine("What year would you like to see (year int+ENTR)?");
            string yearselectedstring = Console.ReadLine();
            Console.WriteLine("What month would you like to see (month int+ENTR)?");
            string monthselectedstring = Console.ReadLine();
            Console.WriteLine("What day would you like to see (day int +ENTR)?");
            string dayselectedstring = Console.ReadLine();
            bool parseyear = int.TryParse(yearselectedstring, out yearselected);
            bool parsemonth = int.TryParse(monthselectedstring, out monthselected);
            bool parseday = int.TryParse(dayselectedstring, out dayselected);
            try
            {
                bool parse = parseyear & parsemonth & parseday;
                if (parse)
                {
                    conn.Open();
                    string Action = "CalendarByDay";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@yearselected", yearselected);
                    command.Parameters.AddWithValue("@monthselected", monthselected);
                    command.Parameters.AddWithValue("@dayselected", dayselected);

                    MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);

                    while (reader.Read())
                    {
                        string tempDateTimeString = reader["TimeToBeServed"].ToString();
                        DateTime newDateTime;
                        //  Console.WriteLine(reader["Name"].ToString()+" "+tempDateTimeString);
                        newDateTime = stringToDateTime(tempDateTimeString);

                  //      Calendar temp = new Calendar(reader["Name"].ToString(), reader["Description"].ToString(), newDateTime, DateTime.Now, userID);
                 //       DailyCalendar.Add(temp);
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
            return DailyCalendar;
        }

        public List<Calendar> UserCalendar(MySqlConnection connn, int userID,string connection)
        {
            List<Calendar> UserCalendar = new List<Calendar>();
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
                    for (int i=0; i < columnNames.Count; i++)
                    {
                        Console.Write(columnNames.ElementAt(i) + " ");
                    }
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        string mealIDstring = reader["MealID"].ToString();
                        int mealID = Convert.ToInt32(mealIDstring);
                    //    Console.WriteLine("meal id: " + mealIDstring);
                        string tempDateTimeString = reader["TimeToBeServed"].ToString();
                        DateTime newDateTime;
                        //  Console.WriteLine(reader["Name"].ToString()+" "+tempDateTimeString);
                       
                        newDateTime = stringToDateTime(tempDateTimeString);
                        //    Calendar temp = new Calendar(reader["Name"].ToString(), reader["Description"].ToString(), newDateTime, DateTime.Now, userID,mealID);
                        Calendar temp = new Calendar(userID, mealID, newDateTime,connection);
                        UserCalendar.Add(temp);
                        //Console.WriteLine(reader["Name"].ToString() + " \n" + reader["Description"].ToString() + " \n" + reader["TimeToBeServed"].ToString());
                    }
                    conn.Close();
                    reader.Close();
                    Console.ReadLine();
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
            Console.WriteLine("done user calender");
         //   Console.ReadLine();
            return UserCalendar;
        }

        public void UserCalendarstar(MySqlConnection connn, int userID)
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
                    Console.WriteLine(reader["Name"].ToString() + " \n" + reader["Description"].ToString() + " \n" + reader["TimeToBeServed"].ToString(), userID);

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


        public List<Ingredient> IngredientsInRecipe(MySqlConnection connn, int recipeID, int userID)
        {
            List<Ingredient> myIngredients = new List<Ingredient>();
        //    Console.WriteLine("actions 2248");
            MySqlConnection conn = connn;
            try
            {
                //   Console.WriteLine("Connecting to MySQL..." + "\n");
                bool parse = true;
                if (parse)
                {
                    conn.Open();
                    string Action = "IngredientNRecipe";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@recipeid", recipeID);
                     MySqlDataReader reader = command.ExecuteReader();
                    List<String> columnNames = GetDataReaderColumnNames(reader);
                    for (int b = 0; b < columnNames.Count; b++)
                    {
                      Console.Write(columnNames.ElementAt(b) + " ");
                    }
                    Console.WriteLine();
                    while (reader.Read())
                    {
                    //    Console.WriteLine(reader["Title"].ToString());
                        string idString = reader["IngredientID"].ToString();
                        int id = 9999;
                        bool parse2 = int.TryParse(idString, out id);
                      Ingredient  MyIngredient = new Ingredient(id, reader["Title"].ToString(), reader["Description"].ToString(), reader["QuantityType"].ToString(), userID);
                        string quantityString = reader["Quantity"].ToString();
                        int quantity = 99999;
                        bool parse3 = int.TryParse(quantityString, out quantity);
                        MyIngredient.setQuantity(quantity);
                        myIngredients.Add(MyIngredient);
                        MyIngredient.printIngredient();
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
            return myIngredients;

        }
        static List<string> GetDataReaderColumnNames(IDataReader rdr)
        {
            var columnNames = new List<string>();
            for (int i = 0; i < rdr.FieldCount; i++)
                columnNames.Add(rdr.GetName(i));
            return columnNames;
        }


        public List<Instruction> InstructionsInRecipe(MySqlConnection conn, int recipeID,int userID)
        {
            List<Instruction> myInstructions = new List<Instruction>();
            try
            {
                bool parse = true;

                if (parse)
                {
                    conn.Open();
                    string Action = "InstructionNRecipe";
                    MySqlCommand command = new MySqlCommand(Action, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@recipeid", recipeID);
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
                     //   Console.WriteLine(reader["Title"].ToString());
                        string insIDstring = reader["InstructionID"].ToString();
                        int insID = Convert.ToInt32(insIDstring);
                        Instruction MyInstruction = new Instruction(insID, reader["Title"].ToString(), reader["Description"].ToString(), userID);
                        myInstructions.Add(MyInstruction);

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
            return myInstructions;
        }
    }
}