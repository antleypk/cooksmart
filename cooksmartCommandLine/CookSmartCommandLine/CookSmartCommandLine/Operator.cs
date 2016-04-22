using System;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.Collections.Generic;

namespace CookSmartCommandLine
{
    public class Operator
    {

        private List<Ingredient> ingredientsGlobal = new List<Ingredient>();
        public Operator()
        {

        }



        public void allIngredients(string connection)

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
            //   List<Recipe> recipes = new List<Recipe>();
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients = firstAct.allIngredients(conn);
            int ingredientCount=ingredients.Count;
            foreach (Ingredient temp in ingredients )
            {
                temp.printIngredient();
                ingredientsGlobal.Add(temp);
            }

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


        public void allRecipies(string connection)
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
                Console.WriteLine("failed to connect" + ex + "\n");
            }
            Console.WriteLine("Connected to CookSmart DataBase all Recipes" + "\n");
            Actions firstAct = new Actions();
           
            firstAct.AllRecipes(conn);

        }
    }


    }

