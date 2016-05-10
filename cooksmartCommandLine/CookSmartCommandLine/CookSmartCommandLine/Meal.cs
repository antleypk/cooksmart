using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
  public  class Meal
    {
        private string Connection;
        private int userid;
        private int mealid;
        private List<Recipe> recipesInMeal = new List<Recipe>();
        public Meal()
        {

        }

        public Meal(int UserID,int MealID,string conn)
        {
            Connection = conn;
            userid = UserID;
            mealid = MealID;
            //works
            setRecipesInMeal(Connection);
            setInstructionsInRecipe(Connection);
            //works
            setIngredientsInRecipes(Connection);
          //  check();
        }

        public void check()
        {
            for(int i=0; i < recipesInMeal.Count; i++)
            {
                recipesInMeal.ElementAt(i).printRecipe();
            }
        }
        public void setRecipesInMeal(string connection)
        {
            Operator operation = new Operator();   
           recipesInMeal=operation.allRecipesInMeal(connection, mealid,userid);
            int temp = recipesInMeal.Count;
            for(int i=0; i < recipesInMeal.Count; i++)
            {
                Console.WriteLine("Instruction list");
               List<Instruction>myinstructions= recipesInMeal.ElementAt(i).getInstructionList();
                int instructionCount=myinstructions.Count;
                Console.WriteLine("instruction count " + instructionCount);
            }
           
        }
        public int recipeCount()
        {
            return recipesInMeal.Count;
        }
        public Recipe getRecipebyID(int id)
        {
            return recipesInMeal.ElementAt(id);
        }

        public void setInstructionsInRecipe(string connection)
        {
         //   Console.WriteLine("set instructions in recipe meal66");
            Operator operations = new Operator();
         //   Console.WriteLine("there are: " + recipesInMeal.Count);
            for(int i = 0; i < recipesInMeal.Count; i++)
            {
              //  Console.WriteLine(" recipe count loop: "+i);
                Recipe tempRecipe = new Recipe();
                int tempRecipeID = recipesInMeal.ElementAt(0).getId();

                List<Instruction> tempInstructionList = operations.allInstructionsInRecipe(connection, userid, tempRecipeID);
                int tempCount = tempInstructionList.Count();
           //     Console.WriteLine("instruciton count " + tempCount);
                for (int b = 0; b < tempInstructionList.Count; b++)
                {
                    int c = b + 1;
                    tempInstructionList.ElementAt(b).setOrder(c);
                    Console.WriteLine("instruction "+c+" "+ tempInstructionList.ElementAt(b).printInstruction());
                }
                recipesInMeal.ElementAt(i).setInstructions(tempInstructionList);
            }
        }
        public void setIngredientsInRecipes(string connection)
        {
            for(int i=0; i < recipesInMeal.Count; i++)
            {
                int temp=recipesInMeal.ElementAt(i).getId();
                Operator operations = new Operator();
                Console.WriteLine("temp recipe id number: " + temp);
                List<Ingredient> ingredients= operations.IngredientsInRecipeById(connection, temp,userid);
                recipesInMeal.ElementAt(i).addIngredents(ingredients);
            }
        }
    }
}
