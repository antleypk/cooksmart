using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
    public class MealBuilder
    {
        public List<Recipe> RecipiesInMeal = new List<Recipe>();
        public MealBuilder() { }

        public void PrintRecipies(string connection)
        {
            Operator operations = new Operator();

            operations.allRecipes(connection);
        }

        public void CheckMeal(string connection, Meal userMeal,int userID)
        {
            Console.WriteLine(userMeal.getName());
            Console.WriteLine(userMeal.getDescription());
            userMeal.printRecipesInMealWhenIncomplete();
            Console.WriteLine("continue or restart");
            string userInput = Console.ReadLine();
            bool acted = false;
            if (userInput == "continue")
            {
                //save the meal
                saveMeal(connection,userMeal, userID);
                acted = true;
            }
            if (userInput == "restart" || acted==false)
            {
                StartBuilder(connection, userID);
                acted = true;
            }
           
            
        }

        public void saveMeal(string connection, Meal myMeal,int userID)
        {
            Operator operation = new Operator();
            operation.insertMeal(connection, myMeal, userID);
            int mealID = operation.getMealID(connection, userID, myMeal.getName());
            myMeal.setID(mealID);
            Console.WriteLine("meal primary key: " + mealID);
            Console.WriteLine("recipes in meal: " + myMeal.recipeCount());
            for(int i=0; i < myMeal.recipeCount(); i++)
            {
                int recipeID = myMeal.getRecipeIDfromindex(i);
                Console.WriteLine("recipe id in meal builder: " + recipeID);
                operation.insertMealRecipe(connection, mealID, userID, recipeID);
            }
        }
        public void StartBuilder(string connection,int userID)
        {
            var userMeal = new Meal();
            int numberOfRecipes = 0;
            Console.WriteLine("What is the name of your meal?");
            string mealName = Console.ReadLine();
            userMeal.setName(mealName);
            Console.WriteLine("Please give a description of your meal.");
            string mealDescription = Console.ReadLine();
            userMeal.setDescription(mealDescription);
            bool stop = true;
            while (stop)
            {
                PrintRecipies(connection);
                Console.WriteLine("Recipes in meal " + numberOfRecipes.ToString());
                Console.WriteLine("Choose recipie by ID type 'continue' to continue.");
                string recipieID = Console.ReadLine();
                if(recipieID == "continue")
                {
                    stop = false;
                }
                else
                {
                    int recipieId = Int32.Parse(recipieID.Trim());
                    userMeal.addRecipesInMeal(connection, recipieId);
                    numberOfRecipes += 1;
                }
            }
            CheckMeal(connection, userMeal,userID);
        }
        public Meal AutoBuilder(string connection, int userID, Meal userMeal)
        {
          // we should be able to make meals build off id alone. i think we already can but just forgot what it was called
            
            CheckMeal(connection, userMeal, userID);
            return userMeal;
        }
    }
}
