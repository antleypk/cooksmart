using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
   public class StateMachine
    {
        List<Ingredient> Ingredients = new List<Ingredient>();
        string userName;

        List<Recipe> Recipes = new List<Recipe>();
        List<User> Users = new List<User>();
        List<Calendar> Calendar = new List<Calendar>();
        List<Kitchen> Kitchen = new List<Kitchen>();
        List<Kitchen> ShoppingList = new List<Kitchen>();
        List<Kitchen> TodaysShopping = new List<Kitchen>();
        List<Ingredient> createdIngredients = new List<Ingredient>();
        List<Instruction> createdInstruction = new List<Instruction>();


        public StateMachine()
        {

        }

        public void startUp()
        {
            Console.Write("Welcome to CookSmart" + "\n");
            Console.Write("Thanks for chosing Traction Systems"+"\n"+"\n");
            Console.WriteLine("Input UserName:");
            userName = Console.ReadLine();
            bool acted = false;
            if (userName == "" || userName.Length<5)
            {
                Console.WriteLine("User Name must be greater than 5 characters");
                startUp();
                acted = true;
            }
            Console.WriteLine("Thanks for choosing CookSmart: " + userName + "\n");

            if (acted == false)
            {
                startMenu();
            }
            
        }

                public void startMenu()
        {
            // a menu should be put here
            Operator operations = new Operator();
            string connectionString = "Server= 108.167.137.112;Port=3306;Database=tractio2_CookSmart;uid=tractio2_Frank;password=Pa88word;Convert Zero Datetime=True";
            Console.Write("Ingredients '1'" + "\n");
            Console.Write("Recipes '2'" + "\n");
            Console.Write("Instructions '3' " + "\n");
            Console.WriteLine("CookSmart '4' ");
            Console.WriteLine("User Menu '5' ");
            Console.WriteLine("Recipe Builder '6'");
            Console.WriteLine("Create menu '7'");
            Console.WriteLine("Enter 'exit' to quit");

            string userInput = Console.ReadLine();
            bool acted = false;
            if (userInput == "1" || userInput== "Ingredients")
            {
                IngredientMenu(operations, connectionString);
                
            }
            if(userInput=="2" || userInput == "Recipes")
            {
                Console.WriteLine("Recipes Menu");
                RecipeMenu(operations,connectionString);
            }

            if (userInput=="3" || userInput == "Instructions")
            {
                Console.WriteLine("Instructions menu");
                InstructionMenu(operations, connectionString);
            }
            if (userInput == "4" || userInput == "CookSmart")
            {
                Console.WriteLine();
                operations.cookSmart(connectionString);
            }
            if(userInput == "5" || userInput == "Users")
            {
                Console.WriteLine("User menu");
                UserMenu(operations, connectionString);
            }
            if (userInput == "6")
            {
                Console.WriteLine("New Recipe");
                RecipeGuide myGuide= new RecipeGuide("Test Recipe");
                Recipe myrecipe = myGuide.startUpRecipeGuide(connectionString);
                myGuide.previewRecipe(myrecipe);
            }
            if (userInput == "7")
            {
                Console.WriteLine("Create menu");
                CreateMenu(operations, connectionString);
            }
            if (userInput == "exit")
            {
                acted = true;
            }

            if (acted == false)
            {
                startMenu();
            }

        }

        public void CreateMenu(Operator operations, string connectionString)
        {
            Console.WriteLine("Created Ingredients");
            foreach(Ingredient blah in createdIngredients)
            {
                blah.printIngredient();
            }
            Console.WriteLine("Created Instructions");
            foreach(Instruction meh in createdInstruction)
            {
                meh.printInstructionToConsole();
            }
            Console.WriteLine("Create new: \n");
            Console.WriteLine("Recipe '1'");
            Console.WriteLine("Ingredient '2'");
            Console.WriteLine("Instruction '3'");
            Console.WriteLine("Show All Created '4'");
            Console.WriteLine("Insert Created Ingredient '5'");
            Console.WriteLine("Insert Created Instruction '6'");
            Console.WriteLine("Main Menu 'menu'");

            string userInput = Console.ReadLine();

            

            bool acted = false;
            if(userInput == "1")
            {
                RecipeGuide myGuide = new RecipeGuide("Test Recipe");
                Recipe myrecipe = myGuide.startUpRecipeGuide(connectionString);
                myGuide.previewRecipe(myrecipe);
            }
            if(userInput == "2")
            {
                Ingredient myingredient = operations.storeIngredient(connectionString);
                createdIngredients.Add(myingredient);
            }
            if(userInput == "3")
            {
                Instruction myinstruction = operations.storeInstruction(connectionString);
                createdInstruction.Add(myinstruction);
            }
            if(userInput == "4")
            {
                Console.WriteLine("Created ingredients:");
                foreach(Ingredient temp in createdIngredients)
                {
                    temp.printIngredient();
                }
                Console.WriteLine("Created instructions:");
                foreach(Instruction temp in createdInstruction)
                {
                    temp.printInstruction();
                }
            }
            if(userInput == "5")
            {
                Console.WriteLine("Created ingredients:");
                foreach (Ingredient temp in createdIngredients)
                {
                    temp.printIngredient();
                }
                Console.WriteLine("Select Created Ingredient By Name");
                string ingname = Console.ReadLine();
                foreach(Ingredient temp in createdIngredients)
                {
                    if(temp.getName() == ingname)
                    {
                        operations.insertIngredient(connectionString, temp);
                    }
                }
            }
            if(userInput == "6")
            {
                Console.WriteLine("Created instructions:");
                foreach (Instruction temp in createdInstruction)
                {
                    temp.printInstructionToConsole();
                }
                Console.WriteLine("Select Created Instruction By Name");
                string insname = Console.ReadLine();
                foreach(Instruction temp in createdInstruction)
                {
                    if(temp.getTitle() == insname)
                    {
                        operations.insertInstruction(connectionString, temp);
                    }
                }
            }
            if(userInput == "menu")
            {
                acted = true;
            }
            if(acted == false)
            {
                CreateMenu(operations, connectionString);
            }
        }

        public void IngredientMenu(Operator operations, string connectionString)
        {
            Console.Write("All Ingredients" + "\n");
            Console.WriteLine("Show All Ingredients '1'");
            Console.WriteLine("Insert Ingredient '2'");
            Console.WriteLine("Main Menu 'Menu'");

            string userInput = Console.ReadLine();

            bool acted = false;

            if (Ingredients.Any<Ingredient>() == false)
            {
                Ingredients = operations.allIngredients(connectionString);
            }
            if (userInput == "1")
            {
                foreach (Ingredient tempIngredient in Ingredients){
                    tempIngredient.printIngredient();
                }
            }
            if(userInput == "2")
            {
                Console.WriteLine();

                //List<Ingredient> Ingredients = operations.allIngredients(connectionString);
                operations.storeIngredient(connectionString);
            }
            if(userInput == "Menu")
            {
                acted = true;
            }
            if(acted == false)
            {
                IngredientMenu(operations, connectionString);
            }
           
        }

        public void InstructionMenu(Operator operations, string connectionString)
        {
            Console.WriteLine();
            Console.WriteLine("All Instructions '1' ");
            Console.WriteLine("Ingredients from an Instruction '2' ");

            Console.WriteLine("Main Menu 'Menu'");

            string userInput = Console.ReadLine();

            bool acted = false;

            if(userInput == "1")
            {
                Console.WriteLine();
                List<Instruction> MyInstructions = operations.allInstructions(connectionString); 
                int count = 0;
                foreach (Instruction tempIns in MyInstructions)
                {
                    tempIns.printInstruction();
                    Console.WriteLine(tempIns.getTitle());
                    count++;
                }
                MyInstructions.Clear();
                
            }
            if (userInput == "2")
            {
                Console.WriteLine();
                operations.allInstructions(connectionString);
                operations.allIngredientInInstruction(connectionString);
            }
            
            if (userInput == "Menu")
            {
                acted = true;
            }
            if(acted == false)
            {
                InstructionMenu(operations, connectionString);
            }
        }

        public void UserMenu(Operator operations, string connectionString)
        {
            Console.WriteLine("All Users (1) ");
            Console.WriteLine("All Meals by User (2) ");
            Console.WriteLine("Kitchen by User (3)");
            Console.WriteLine("Calendar by User (4)");
            Console.WriteLine("Shopping List By Day (5)");
            Console.WriteLine("Shopping List Minus Kitchen (6)");
            Console.WriteLine("All Recipes By User (7)");
            Console.WriteLine("All Instructions By User (8)");
            Console.WriteLine("All Ingredients By User (9)");
            Console.WriteLine("'menu' for main menu");
            string userInput = Console.ReadLine();

            if (Users.Any<User>() == false)
            {
                Users = operations.AllUsers(connectionString);
            }

            bool acted = false;

            if(userInput == "1")
            {
                foreach(User tempuser in Users)
                {
                    tempuser.printUser();
                }
            }
            if(userInput == "2"){
                operations.UserMeals(connectionString);
            }
            if(userInput == "3")
            {
                    Kitchen = operations.UserKitchen(connectionString);

                foreach(Kitchen tempkitchen in Kitchen)
                {
                    tempkitchen.printKitchen();
                    
                }
                Kitchen.Clear();
            }
            if(userInput == "4")
            {

                    Calendar = operations.UserCalendar(connectionString);

                foreach (Calendar tempcalendar in Calendar)
                {
                    tempcalendar.printCalendar();
                }
                Calendar.Clear();
            }
            if(userInput == "5")
            {

                    ShoppingList = operations.ShoppingList(connectionString);

                foreach (Kitchen tempkitchen in ShoppingList)
                {
                    tempkitchen.printKitchen();
                }
                ShoppingList.Clear();
            }
            if(userInput == "6")
            {

                    ShoppingList = operations.ShoppingList(connectionString);


                    Kitchen = operations.UserKitchen(connectionString);

                TodaysShopping = operations.TodaysShopping(connectionString, Kitchen, ShoppingList);
                foreach(Kitchen tempkitchen in TodaysShopping)
                {
                    tempkitchen.printKitchen();
                }
                ShoppingList.Clear();
                Kitchen.Clear();
                TodaysShopping.Clear();
            }
            if(userInput == "7")
            {
                List<Recipe> Recipes = operations.RecipesByUser(connectionString);
                foreach (Recipe temp in Recipes)
                {
                    temp.printRecipe();
                }
            }
            if(userInput == "8")
            {
                List<Instruction> Instructions = operations.InstructionsByUser(connectionString);
                foreach(Instruction temp in Instructions)
                {
                    temp.printInstructionToConsole();
                }
            }
            if(userInput == "9")
            {
                List<Ingredient> Ingredients = operations.IngredientsByUser(connectionString);
                foreach(Ingredient temp in Ingredients)
                {
                    temp.printIngredient();
                }
            }
            if(userInput == "menu")
            {
                acted = true;
            }
            if(acted == false)
            {
                UserMenu(operations, connectionString);
            }
        }

        public void RecipeMenu(Operator operations, string connectionString)
        {
            //i would like you to explain this to me
            if (Recipes.Any<Recipe>() == false)
            {
                Recipes = operations.allRecipes(connectionString);
            }

            Console.WriteLine();
            Console.Write("All Recipes (recipe or 1)" + "\n");
            Console.Write("See ingredients from a recipe '2' " + "\n");
            Console.Write("See instructions from a recipe '3' " + "\n");
            Console.Write("'menu' for main menu" + "\n");
            Console.WriteLine();


           

            //  Console.Write("all Ingredients in a receipe" + "\n");

            string userInput = Console.ReadLine();
             
            //  operations.allIngredientInRecipe(connectionString);
            bool acted = false;

            if(userInput=="1" || userInput == "recipe")
            {
                foreach(Recipe temprecipe in Recipes)
                {
                    temprecipe.printRecipe();
                }
            }

            if (userInput == "2")
            {
                operations.allIngredientInRecipe(connectionString);
            }
            if (userInput == "3")
            {
                operations.allInstructionInRecipe(connectionString);
            }
            if (userInput == "menu")
            {
                acted = true;
            }

            if (acted == false)
            {
                RecipeMenu(operations, connectionString);
            }
        }
        public void Instructions(Operator operations, string connectionString)
        {
            Console.Write("All Instruction Menu" + "\n");
            
        }

        


    }
}
