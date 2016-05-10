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

        public void StartBuilder(string connection)
        {
            var userMeal = new Meal();
            Console.WriteLine("What is the name of your meal?");
            string mealName = Console.ReadLine();
            userMeal.setName(mealName);
            bool stop = true;
            while (stop)
            {
                PrintRecipies(connection);
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
                }
            }
        }
    }
}
