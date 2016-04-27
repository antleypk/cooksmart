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

        private List<Recipe> recipesGlobal = new List<Recipe>();

        private List<Calendar> calendarsGlobal = new List<Calendar>();

        public Operator()
        {

        }

        public void insertIngredient(string connection)

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
            firstAct.InsertIngredient(conn);
        }

        public void storeIngredient(string connection, List<Ingredient> ings)

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
            firstAct.StoreIngredient(conn, ings);
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
            foreach (Ingredient temp in ingredients)
            {
                temp.printIngredient();
                ingredientsGlobal.Add(temp);

            }
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

        public void allInstructions(string connection)
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
            Console.WriteLine("Connected to CookSmart DataBase all Instructions" + "\n");
            Actions firstAct = new Actions();

            firstAct.allInstructions(conn);

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
            firstAct.ShoppingListFromRecipe(conn);
        }

    }
    }