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
        private int userid=0;
        private int cookid=0;
        private int mealid = 765683921;
        private string mealName;
        private string mealDescription;
        private List<Recipe> recipesInMeal = new List<Recipe>();
        private List<int> recipeIdInMeal = new List<int>();
        public Meal()
        {

        }

        public Meal(int UserID, int MealID, string conn)
        {
            Connection = conn;
            userid = UserID;
            mealid = MealID;

            setNameAutoMatic(Connection);
            //works
            setRecipesInMeal(Connection);

            setInstructionsInRecipe(Connection);
            //works
            setIngredientsInRecipes(Connection);
          //  check();
        }
        
        public void setUPmealoffline(int MEALID, string NAME, string DESCRIPTION, int USERID)
        {
            mealName = NAME;
            mealid = MEALID;
            mealDescription = DESCRIPTION;
            userid = USERID;
        }
      
        public void setNameAutoMatic(string connection)
        {
            Operator operations = new Operator();
            Meal mymeal = operations.getMealByID(connection, userid, mealid);
            mealName = mymeal.getMealName();
            mealDescription = mymeal.getDescription();
            cookid = mymeal.getcook();
        }
        public string getDesction()
        {
            return mealDescription;
        }
        public string getMealName()
        {
            return mealName;
        }

        public void check()
        {
            for(int i=0; i < recipesInMeal.Count; i++)
            {
                recipesInMeal.ElementAt(i).printRecipe();
            }
        }
        public void setUserID(int userIN)
        {
            userid = userIN;
        }
        public int getUserID()
        {
            return userid;
        }
        public int getcook()
        {
            return cookid;
        }
        public void setRecipesInMeal(string connection)
        {
            Operator operation = new Operator();
            recipesInMeal = operation.allRecipesInMeal(connection, mealid, userid);
            int temp = recipesInMeal.Count;
            for (int i = 0; i < recipesInMeal.Count; i++)
            {
                Operator operations = new Operator();
                Recipe tempRecipe = recipesInMeal[i];

          //      Console.WriteLine("Instruction list");
                List<Instruction> myinstructions = operations.allInstructionsInRecipe(connection, userid, tempRecipe.getId());
                int instructionCount = myinstructions.Count;
                //Console.WriteLine("instruction count " + instructionCount);
                //for (int b = 0; b < myinstructions.Count; b++)
                //{
                //    string title = myinstructions[b].getTitle();
                //    Console.WriteLine("Hello wont you tell me your name: " + b + " " + title);
                //}
                tempRecipe.setInstructions(myinstructions);
            }
           
        }

        public void printRecipesInMealWhenIncomplete()
        {
            foreach(int r in recipeIdInMeal)
            {
                Console.WriteLine(r.ToString());
            }
        }
        public int getRecipeIDfromindex(int index)
        {
            int primarykey = 0;
           primarykey=recipeIdInMeal.ElementAt(index);


            return primarykey;
        }

        public void setName(string name)
        {
            mealName = name;
        }

        public void setDescription(string description)
        {
            mealDescription = description;
        }

        public string getDescription()
        {
            return mealDescription;
        }

        public string getName() { return mealName; }
        
        public void addRecipesInMeal(string connection, int id)
        {
            recipeIdInMeal.Add(id);
            Operator operation = new Operator();
            Recipe addedRecipe = operation.allRecipes(connection).SingleOrDefault(x => x.getId() == id);
            recipesInMeal.Add(addedRecipe);
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
              //      Console.WriteLine("instruction "+c+" "+ tempInstructionList.ElementAt(b).printInstruction());
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
          //      Console.WriteLine("temp recipe id number: " + temp);
                List<Ingredient> ingredients= operations.IngredientsInRecipeById(connection, temp,userid);
                recipesInMeal.ElementAt(i).addIngredents(ingredients);
            }
        }

        public void setID(int ID)
        {
            mealid = ID;
        }
        public int getID()
        {
            return mealid;
        }
        public void printMeal(string connection)
        {
            Console.WriteLine(mealName + " " + mealid);
            Console.WriteLine("Recipe Count: " + recipesInMeal.Count);

            CookSmart newCookSmart = new CookSmart();
            for(int i=0; i < recipesInMeal.Count; i++)
            {
            
                int recipeID = recipesInMeal[i].getId();
                Console.WriteLine(recipesInMeal[i].getName());
                newCookSmart.AutoCookSmart(connection, userid, recipeID);

            }
           
        }
    }
}
