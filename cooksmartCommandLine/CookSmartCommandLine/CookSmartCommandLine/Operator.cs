using System;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace CookSmartCommandLine
{
    public class Operator
    {

        private List<Ingredient> ingredientsGlobal = new List<Ingredient>();

        private List<Instruction> instructionsGlobal = new List<Instruction>();

        private List<Recipe> recipesGlobal = new List<Recipe>();

        private List<Calendar> calendarsGlobal = new List<Calendar>();

        public Operator()
        {

        }

        public void insertIngredient(string connection, Ingredient ing, int userID)

        {
            MySqlConnection conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect");
            }
            Console.WriteLine("Connected to CookSmart Database");
            Actions firstAct = new Actions();
            firstAct.InsertIngredient(conn, ing, userID);
        }
        public void insertMeal(string connection, Meal myMeal, int userID)

        {
            MySqlConnection conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect");
            }
            Console.WriteLine("Connected to CookSmart Database");
            Actions firstAct = new Actions();
            firstAct.InsertMeal(conn, myMeal, userID);
        }
        public void insertMealRecipe(string connection, int mealID, int userID,int recipeID)

        {
            MySqlConnection conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect");
            }
            Console.WriteLine("Connected to CookSmart Database");
            Actions firstAct = new Actions();
            firstAct.InsertMealRecipe(conn, mealID, userID,recipeID);
        }

        public void insertUser(string connection, string userName, string password)

        {
            MySqlConnection conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect");
            }
            Console.WriteLine("Connected to CookSmart Database");
            Actions firstAct = new Actions();
            firstAct.InsertUser(conn, userName, password); 
        }

        public void insertInstruction(string connection, Instruction ins, int userid)
        {
            MySqlConnection conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect");
            }
            Console.WriteLine("Connected to CookSmart Database");
            Actions firstAct = new Actions();
            firstAct.InsertInstruction(conn, ins, userid);
        }

        public Ingredient storeIngredient(string connection, int userid)

        {
            Ingredient tempIngredient = new Ingredient(userid);
            return tempIngredient;
        }


        public Instruction storeInstruction (string connection, int userID, int order)

        {
            Console.WriteLine("Input Instruction Name");
            string InsName = Console.ReadLine();
            Console.WriteLine("Input Ingredient Description");
            string InsDesc = Console.ReadLine();

            Instruction newins = new Instruction(0, InsName, InsDesc, userID);
            newins.setOrder(order);

            return newins;
        }


        public List<Ingredient> allIngredients(string connection, int userID)

        {
            List<Ingredient> ingredients = new List<Ingredient>();

            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to connect" + "\n");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            //   List<Recipe> recipes = new List<Recipe>();
            ingredients = firstAct.allIngredients(conn, userID);
            int ingredientCount = ingredients.Count;
           
            return ingredients;

        }
        public void allIngredientInRecipe(string connection)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.IngredientsInRecipe(conn);
        }

        public List<Ingredient> IngredientsInRecipeById(string connection, int recipeid,int userid)
        {

            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
           return firstAct.IngredientsInRecipe(conn,recipeid,userid);

        }

        public List<Recipe> RecipesInMealById(string connection, int mealid, int userid)
        {

            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.RecipesInMeal(conn, mealid, userid);
        }

        public void allIngredientFromRecipe(string connection, Recipe rec)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.IngredientsFromRecipe(conn,rec);
        }

        public Instruction InstructionByName(string connection, int guserID)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to connect" + "\n");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.InstructionByName(conn, guserID);
        }

        public Instruction InstructionByID(string connection, int guserID)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.InstructionByID(conn, guserID);
        }


        public List<Ingredient> IngredientsByUser(string connection)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.IngredientsByUser(conn);
        }


        public List<Instruction> InstructionsByUser(string connection)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.InstructionsByUser(conn);
        }

        public List<Recipe> RecipesByUser(string connection)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to connect" + "\n");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.RecipesByUser(conn);
        }

        public Ingredient IngredientByName(string connection, int userID)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to connect" + "\n");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.IngredientByName(conn, userID);
        }



        public Recipe RecipeByID(string connection, int userID)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to connect" + "\n");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.GetRecipeByID(conn, userID);
        }
        public int getMealID(string connection, int userID, string name)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to connect" + "\n");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.GetMealID(conn, name, userID);
        }


        public Ingredient IngredientByID(string connection, int userID)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.GetIngredientByID(conn, userID);


        }

        public Ingredient IngredientFromID(string connection, int userID, int ingID)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.GetIngredientFromID(conn, userID, ingID);


        }
        public List<User> AllUsers(string connection)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.allUsers(conn);
        }


        public void UserMeals(string connection, int userid)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.UserMeals(conn, userid);
        }

        public List<Kitchen> UserKitchen(string connection, int userID)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.UserKitchen(conn, userID);
        }

        public List<Kitchen> ShoppingList(string connection, int userID)
        {
            List<Kitchen> ShoppingList = new List<Kitchen>();
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.ShoppingListByUser(conn, userID);
        }

        public List<Calendar> UserCalendar(string connection, int userID)
        {
            List<Calendar> UserCalendar = new List<Calendar>();
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL...User Calendar" + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            UserCalendar= firstAct.UserCalendar(conn, userID,connection);

            return UserCalendar;
        }

        public List<Calendar> MealCalendar(string connection, int userid)
        {
            List<Calendar> MealCalendar = new List<Calendar>();
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.MealCalendar(conn, userid);
        }

        public List<Calendar> MonthlyCalendar(string connection, int userid)
        {
            List<Calendar> MealCalendar = new List<Calendar>();
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.MonthlyCalendar(conn, userid);
        }
        public List<Calendar> DailyCalendar(string connection, int userid)
        {
            List<Calendar> MealCalendar = new List<Calendar>();
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.DailyCalendar(conn, userid);
        }


        public int GetRecipeID(string connection, int userID, Recipe rec)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                //  Console.WriteLine("Connecting to MySQL...Get RecIpeID 3 input" + "\n");
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            string name = rec.getName();
            return firstAct.GetRecipeID(conn, userID, name);
        }
        public int GetRecipeID(string connection, int userID, string name)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL...Get RecIpeID 3 input" + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.GetRecipeID(conn, userID, name);
        }


        public int GetIngredientID(string connection, int userID, string name)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL...Get RecIpeID 3 input" + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.GetIngredientID(conn, userID, name);
        }



        public int GetInstructionID(string connection, int userID, Instruction Ins)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL...Get RecIpeID 3 input" + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.GetInstructionID(conn, userID, Ins);
        }

        public void InsertRecipe(string connection, int userID, Recipe rec)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.InsertRecipe(conn, rec, userID);
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
        }


        public void DeleteRecipeWithInstruction(string connection, int userID, Recipe rec)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.DeleteRecipeWithInstruction(conn, rec, userID);
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
        }

        public void DeleteRecipeWithoutInstruction(string connection, int userID, Recipe rec)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.DeleteRecipeWithoutInstruction(conn, rec, userID);
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
        }


        public void DeleteInstructionWithIngredient(string connection, Instruction ins, int userID)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.DeleteInstructionWithIngredient(conn, ins, userID);
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
        }

        public void DeleteInstructionWithoutIngredient(string connection, Instruction ins, int userID)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.DeleteInstructionWithoutIngredient(conn, ins, userID);
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
        }
        public void UpdateCalendar(string connection, Calendar Cal, int userID)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.UpdateCalendar(conn, Cal, userID);
        }

        public void UpdateQuantity(string connection, Instruction ins, Ingredient ing, int quantity, int userID)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.UpdateQuantity(conn, ins, ing, quantity, userID);
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
        }



        public int GetUserID(string connection, string userName, string passWord)
        {
            
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.GetUserID(conn, userName, passWord);
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
        }

        public bool checkuser(string connection, string userName, string passWord)
        {
            
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.checkuser(conn, userName, passWord);
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
        }


        public bool checkusername(string connection, string userName)
        {
         
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.checkusername(conn, userName);
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
        }


        public List<DateTime> userloginattempts(string connection, string userName)
        {
          
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.userloginattempts(conn, userName);
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
        }


        public void updatelogins(string connection, List<DateTime> logins, string username)
        {
            
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.updatelogins(conn, logins, username);
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
        }

        public void reorder(string connection, Recipe rec, Instruction ins, int order, int userID)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.reorder(conn, rec, ins, order, userID);
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
        }

        public void UpdateInstruction(string connection, Instruction ins, int userID)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.UpdateInstruction(conn, ins, userID);
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
        }

        public void UpdateRecipe(string connection, Recipe rec, int userID)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.UpdateRecipe(conn, rec, userID);
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
        }



        public void InsertInstructionIngredient(string connection, int userID, Recipe rec)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..insertInstructionIngredient." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.insertInstructionIngredient(conn, userID, rec);
        }

        public void InsertCalendar(string connection, Calendar cal, int userID)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..insertInstructionIngredient." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.InsertCalendar(conn, cal, userID);
        }


        public void InsertInstructionRecipe(string connection, int userID, Recipe rec)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..InsertInstructionRecipe." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.insertInstructionRecipe(conn, userID, rec);
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
        }

        public void InsertRecipeIngredient(string connection, int userID, Recipe rec)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.insertRecipeIngredient(conn, userID, rec);
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
        }


        public void allInstructionInRecipe(string connection)
        {
            MySqlConnection conn;
            
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
                conn = new MySqlConnection(connection);
                Console.WriteLine("Connected to CookSmart DataBase" + "\n");
                Actions firstAct = new Actions();
                firstAct.InstructionsInRecipe(conn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
           
            
        }
        


        public List<Recipe> allRecipes(string connection)
        {

            MySqlConnection conn;

        

                conn = new MySqlConnection(connection);
            
            
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase all Recipes" + "\n");
            Actions firstAct = new Actions();

            List<Recipe> recipes = firstAct.AllRecipes(conn);
            
            return recipes;

        }
        public List<Meal> allMeals(string connection)
        {

            MySqlConnection conn;

            //    connectionString = "Server= 108.167.137.112;Port=3306;Database=tractio2_CookSmart;uid=tractio2_Frank;password=Pa88word";

            conn = new MySqlConnection(connection);


            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase all Recipes" + "\n");
            Actions firstAct = new Actions();

            List<Meal> meals = firstAct.AllMeals(conn);

            return meals;

        }
        public List<Recipe> allRecipesInMeal(string connection,int mealID,int userID)
        {

           MySqlConnection conn;

        
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..all recipesInMeal." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Actions firstAct = new Actions();

            List<Recipe> recipes = firstAct.AllRecipesInMeal(conn,mealID,userID);
            //foreach (Recipe temprec in recipes)
            //{
            //    int temprecipeid = temprec.getId();

            //    temprec.printRecipe();
            //    recipesGlobal.Add(temprec);
            //}
            Console.WriteLine("operator 1203: recipesNmealcount: " + recipes.Count);
            return recipes;

        }



        public List<Instruction> allInstructions(string connection, int userID)
        {
            List<Instruction> instructions = new List<Instruction>();
            MySqlConnection conn;

            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase all Instructions" + "\n");
            Actions firstAct = new Actions();

            instructions = firstAct.allInstructions(conn, userID);
            foreach(Instruction temp in instructions)
            {
                temp.printInstruction();
                instructionsGlobal.Add(temp);
            }
            return instructions;

        }


        public Recipe recipeFromId(string connection, int userID)
        {

            Operator operations = new Operator();
            Recipe tempRecipe = operations.recipeFromId(connection, userID);

            return tempRecipe;
        }

        public void cookSmart(string connection,int userid)
        {
            CookSmart cookSmart = new CookSmart();
            cookSmart.startUpCookSmart(connection,userid);

        }
        public void allIngredientInInstruction(string connection)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.IngredientsInInstruction(conn);
        }
        public List<Instruction> allInstructionsInRecipe(string connection,int userid, int recipeId)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
               // Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
           return firstAct.InstructionsInRecipe(conn,recipeId,userid);
        }

        public void ShoppingListFromRecipe(string connection)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.ShoppingListGetRecipe(conn);
        }
        public void ShoppingListFromrecipe(string connection, Recipe rec)
        {
            MySqlConnection conn;
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.ShoppingListFromRecipe(conn, rec);
        }
    }
    }