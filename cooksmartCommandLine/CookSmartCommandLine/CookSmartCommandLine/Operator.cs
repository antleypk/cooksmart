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
                Console.WriteLine("failed to connect");
            }
            Console.WriteLine("Connected to CookSmart Database");
            Actions firstAct = new Actions();
            firstAct.InsertIngredient(conn, ing, userID);
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
                Console.WriteLine("failed to connect");
            }
            Console.WriteLine("Connected to CookSmart Database");
            Actions firstAct = new Actions();
            firstAct.InsertInstruction(conn, ins, userid);
        }

        public Ingredient storeIngredient(string connection)

        {
            MySqlConnection conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to connect");
            }
            Console.WriteLine("Connected to CookSmart Database");
            Actions firstAct = new Actions();
            return firstAct.StoreIngredient(conn);
        }


        public Instruction storeInstruction (string connection)

        {
            MySqlConnection conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to connect");
            }
            Console.WriteLine("Connected to CookSmart Database");
            Actions firstAct = new Actions();
            return firstAct.StoreInstruction(conn);
        }


        public List<Ingredient> allIngredients(string connection)

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
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            //   List<Recipe> recipes = new List<Recipe>();
            ingredients = firstAct.allIngredients(conn);
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
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.IngredientsInRecipe(conn);
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
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.IngredientsFromRecipe(conn,rec);
        }

        public Instruction InstructionByName(string connection)
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
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.InstructionByName(conn);
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
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.RecipesByUser(conn);
        }

        public Ingredient IngredientByName(string connection)
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
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.IngredientByName(conn);
        }
        public Recipe RecipeByID(string connection)
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
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.GetRecipeByID(conn);
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
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.allUsers(conn);
        }


        public void UserMeals(string connection)
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
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.UserMeals(conn);
        }

        public List<Kitchen> UserKitchen(string connection)
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
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.UserKitchen(conn);
        }

        public List<Kitchen> ShoppingList(string connection)
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
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.ShoppingListByDay(conn);
        }

        public List<Calendar> UserCalendar(string connection)
        {
            List<Calendar> UserCalendar = new List<Calendar>();
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
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            return firstAct.UserCalendar(conn);
        }
        public int GetRecipeID(string connection, int userID, Recipe rec)
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
            //print recipes
            //ask user to input recipe name and description
            //Ask user for 1st instruction text, description (joiner IDs)
            //ask user for Ingredients, Quantity for 1st instruction (Joiner IDs)
            //Repeat instructions until done.
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
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.InstructionsInRecipe(conn);
        }

        public List<Kitchen> TodaysShopping(string connection, List<Kitchen> MyKitchen, List<Kitchen> ShoppingList)
        {
            List<Kitchen> TodaysShopping = new List<Kitchen>();
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
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            
            foreach(Kitchen tempkitchen1 in ShoppingList)
            {
                foreach(Kitchen tempkitchen2 in MyKitchen)
                {
                    if (tempkitchen1.getTitle() == tempkitchen2.getTitle())
                    {
                        decimal newquantity = Math.Max(0,tempkitchen1.getTotalQuantity() - tempkitchen2.getTotalQuantity());
                        tempkitchen1.setTotalQuantity(newquantity);
                        
                    }
                    TodaysShopping.Add(tempkitchen1);
                }
            }
            return TodaysShopping;

        }


        public List<Recipe> allRecipes(string connection)
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
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase all Recipes" + "\n");
            Actions firstAct = new Actions();

            List<Recipe> recipes = firstAct.AllRecipes(conn);
            foreach (Recipe temprec in recipes)
            {
                int temprecipeid = temprec.getId();
       
                temprec.printRecipe();
                recipesGlobal.Add(temprec);

            }
            return recipes;

        }

        public List<Instruction> allInstructions(string connection)
        {
            List<Instruction> instructions = new List<Instruction>();
            MySqlConnection conn;

            //    connectionString = "Server= 108.167.137.112;Port=3306;Database=tractio2_CookSmart;uid=tractio2_Frank;password=Pa88word";
            conn = new MySqlConnection(connection);
            try
            {
                Console.WriteLine("Connecting to MySQL..." + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase all Instructions" + "\n");
            Actions firstAct = new Actions();

            instructions = firstAct.allInstructions(conn);
            foreach(Instruction temp in instructions)
            {
                temp.printInstruction();
                instructionsGlobal.Add(temp);
            }
            return instructions;

        }

      

        public void cookSmart(string connection)
        {
            CookSmart cookSmart = new CookSmart();
            cookSmart.startUpCookSmart(connection);

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
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.IngredientsInInstruction(conn);
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
                Console.WriteLine("failed to connect" + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase" + "\n");
            Actions firstAct = new Actions();
            firstAct.ShoppingListFromRecipe(conn, rec);
        }
    }
    }