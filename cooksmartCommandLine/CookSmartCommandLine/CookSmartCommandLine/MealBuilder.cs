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

        public void CheckMeal(string connection, Meal userMeal)
        {
            Console.WriteLine(userMeal.getName());
            Console.WriteLine(userMeal.getDescription());
            userMeal.printRecipesInMeal();
        }

        public void StartBuilder(string connection)
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
            CheckMeal(connection, userMeal);
        }
    }
}
