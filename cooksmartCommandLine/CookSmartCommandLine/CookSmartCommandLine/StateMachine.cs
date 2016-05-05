using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
   public class StateMachine
    {
        private List<Ingredient> Ingredients = new List<Ingredient>();
        private string userName;
        private int UserID = 420;
        private List<Recipe> Recipes = new List<Recipe>();
        private List<User> Users = new List<User>();
        private List<Calendar> Calendar = new List<Calendar>();
        private List<Kitchen> Kitchen = new List<Kitchen>();
        private List<Kitchen> ShoppingList = new List<Kitchen>();
        private List<Kitchen> TodaysShopping = new List<Kitchen>();
        private List<Ingredient> createdIngredients = new List<Ingredient>();
        private List<Instruction> createdInstruction = new List<Instruction>();
        private int validationkount = 0;

        public StateMachine()
        {

        }
        public void validation(string connectionString)
        {
            
        Operator operations = new Operator();
            Console.WriteLine("Input UserName:");
            userName = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            string password = Console.ReadLine();
            bool checkpass = operations.checkuser(connectionString, userName, password);
            Console.WriteLine(checkpass+" for the love of jerry");

            if(validationkount >= 5)
            {
                Console.WriteLine("Access fail");
                Environment.Exit(0);
            }
            if (checkpass)
            {
                int id = operations.GetUserID(connectionString, userName, password);

                UserID = id;
                Console.WriteLine("You did it!  Id: " + UserID);
            }
            if (checkpass.ToString() == "False")
            {
                validationkount++;
                Console.WriteLine("validation count" + validationkount);
                validation(connectionString);
            }
        }
        public void startUp()
        {
            string connectionString = "Server= 108.167.137.112;Port=3306;Database=tractio2_CookSmart;uid=tractio2_generic;password=Pa88word;Convert Zero Datetime=True";

            int userID = UserID;
            Console.Write("Welcome to CookSmart" + "\n");
            Console.Write("Thanks for chosing Traction Systems"+"\n"+"\n");

            validation(connectionString);

            bool acted = false;
            if (userName == "" || userName.Length<5)
            {
                Console.WriteLine("User Name must be greater than 5 characters");
           
                startUp();
                acted = true;
            }
            Console.WriteLine("Thanks for choosing CookSmart: " + userName );
            Console.WriteLine("UserID: " + UserID);
            Console.WriteLine();
            if (acted == false)
            {
                startMenu(UserID,connectionString);
            }
            
        }

        public void startMenu(int userID,string connectionString)
        {

            Operator operations = new Operator();
            Console.Write("Ingredients '1'" + "\n");
            Console.Write("Recipes '2'" + "\n");
            Console.Write("Instructions '3' " + "\n");
            Console.WriteLine("CookSmart '4' ");
            Console.WriteLine("User Menu '5' ");
            Console.WriteLine("Recipe Builder '6'");
            Console.WriteLine("Create menu '7'");
            Console.WriteLine("RecipeID by Name and user ID '8'");
            Console.WriteLine("IngredientID by Name and user ID '9'");
            Console.WriteLine("GOD MODE '10'");
            Console.WriteLine("Caldender '11'");
            Console.WriteLine("Enter 'exit' to quit");

            string userInput = Console.ReadLine();
            bool acted = false;
            if (userInput == "1" || userInput== "Ingredients")
            {
                IngredientMenu(operations, connectionString, userID);
                
            }
            if(userInput=="2" || userInput == "Recipes")
            {
                Console.WriteLine("Recipes Menu");
                RecipeMenu(operations,connectionString, userID);
            }

            if (userInput=="3" || userInput == "Instructions")
            {
                Console.WriteLine("Instructions menu");
                InstructionMenu(operations, connectionString, userID);
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
                RecipeGuide myGuide= new RecipeGuide("Test Recipe", UserID);
                Recipe newRecipe = myGuide.startUpRecipeGuide(connectionString, UserID);
               
            }
            if (userInput == "7")
            {
                Console.WriteLine("Create menu");
                CreateMenu(operations, connectionString);
            }
            if (userInput == "8")
            {
                int test = operations.GetRecipeID(connectionString, 420, "Tomtest829");
                Console.WriteLine("ultimate puzzlement");
                Console.WriteLine("primary key: " + test);

            }
            if (userInput == "9")
            {
                int test = operations.GetIngredientID(connectionString, 69, "ginger tears");
                Console.WriteLine(test);
            }
            if(userInput == "10")
            {
                Console.WriteLine("Insert Ingredient here");
                Ingredient ing = operations.storeIngredient(connectionString, userID);
                operations.insertIngredient(connectionString, ing, userID);
                operations.GetIngredientID(connectionString, userID, ing.getName());
                operations.IngredientFromID(connectionString, userID, ing.getId());
            }
            if(userInput=="11" || userInput == "Calender")
            {
                calenderMenu(connectionString, operations);
            }
            

            if (userInput == "exit")
            {
                acted = true;
            }

            if (acted == false)
            {
                startMenu(userID,connectionString);
            }

        }
        public void calenderMenu(string connection, Operator operations)
        {
            Console.WriteLine("Calender Menu");
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
                RecipeGuide myGuide = new RecipeGuide("Test Recipe", UserID);
                Recipe myrecipe = myGuide.startUpRecipeGuide(connectionString,UserID);
                myGuide.previewRecipe(myrecipe);
            }
            if(userInput == "2")
            {
                Ingredient myingredient = operations.storeIngredient(connectionString, UserID);
                createdIngredients.Add(myingredient);
            }
            if(userInput == "3")
            {
                Instruction myinstruction = operations.storeInstruction(connectionString, UserID,0);
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
                        operations.insertIngredient(connectionString, temp, UserID);
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
                        operations.insertInstruction(connectionString, temp,UserID);
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

        public void IngredientMenu(Operator operations, string connectionString, int userID)
        {
            Console.Write("All Ingredients" + "\n");
            Console.WriteLine("Show All Ingredients '1'");
            Console.WriteLine("Insert Ingredient '2'");
            Console.WriteLine("Ingredient by ID '3'");
            Console.WriteLine("Main Menu 'Menu'");

            string userInput = Console.ReadLine();

            bool acted = false;

            
                Ingredients = operations.allIngredients(connectionString, userID);
            
            if (userInput == "1")
            {
                foreach (Ingredient tempIngredient in Ingredients){
                    tempIngredient.printIngredient();
                }
            }
            if(userInput == "2")
            {
                createingredient(connectionString, operations, userID);
            }
            if(userInput == "3")
            {
                Ingredient temping = operations.IngredientByID(connectionString,userID);
                temping.printIngredient();

            }
            if(userInput == "4")
            {
                
            }
            if(userInput == "Menu")
            {
                acted = true;
            }
            if(acted == false)
            {
                IngredientMenu(operations, connectionString, userID);
            }
           
        }
        public void createingredient(string connectionString, Operator operations, int userID)
        {

            Console.WriteLine();

            //List<Ingredient> Ingredients = operations.allIngredients(connectionString);
            Ingredient newIngredient = operations.storeIngredient(connectionString, userID);
            newIngredient.printIngredient();
            Console.WriteLine("Accept 'A' Restart 'R'");
            string userinput = Console.ReadLine();

            if (userinput == "A")
            {
                //Insert Ingredient
                operations.insertIngredient(connectionString, newIngredient, userID);
            }
            if (userinput == "R")
            {
                //restart
                createingredient(connectionString, operations, userID);
            }
        }
        public void InstructionMenu(Operator operations, string connectionString, int userID)
        {
            Console.WriteLine();
            Console.WriteLine("All Instructions '1' ");
            Console.WriteLine("Ingredients from an Instruction '2' ");
            Console.WriteLine("Delete Instruction '3'");
            Console.WriteLine("Update Instruction '4'");

            Console.WriteLine("Main Menu 'Menu'");

            string userInput = Console.ReadLine();

            bool acted = false;

            if(userInput == "1")
            {
                Console.WriteLine();
                List<Instruction> MyInstructions = operations.allInstructions(connectionString, userID); 
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
                operations.allInstructions(connectionString, userID);
                operations.allIngredientInInstruction(connectionString);
            }
            if(userInput == "3")
            {
                Console.WriteLine();
                operations.allInstructions(connectionString, userID);
                Console.WriteLine("Select Instruction by ID");
                Instruction ins = operations.InstructionByID(connectionString, userID);
                if (ins.getInstructionIngredients().Any<Ingredient>())
                {
                    operations.DeleteInstructionWithIngredient(connectionString, ins, userID);
                }
                else
                {
                    operations.DeleteInstructionWithoutIngredient(connectionString, ins, userID);
                }

            }
            if(userInput == "4")
            {
                Instruction ins = operations.InstructionByID(connectionString, userID);
                string title = "";
                string description = "";
                int preptime;
                int cooktime;
                Console.WriteLine("Title is: " + ins.getTitle());
                Console.WriteLine("Description is: " + ins.getDescription());
                Console.WriteLine("Preptime is: " + ins.getPrepTime());
                Console.WriteLine("Cooktime is: " + ins.getCookTime());
                Console.WriteLine("Update?  Y/N");
                if(Console.ReadLine() == "Y")
                {
                    Console.WriteLine("New Title: ");
                    title = Console.ReadLine();
                    Console.WriteLine("New Description: ");
                    description = Console.ReadLine();
                    Console.WriteLine("New Preptime: ");
                    preptime = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("New Cooktime: ");
                    cooktime = Convert.ToInt32(Console.ReadLine());
                    ins.setTitle(title);
                    ins.setDescription(description);
                    ins.setCookTime(cooktime);
                    ins.setPrepTime(preptime);
                    operations.UpdateInstruction(connectionString, ins, userID);
                }
            }
            
            if (userInput == "Menu")
            {
                acted = true;
            }
            if(acted == false)
            {
                InstructionMenu(operations, connectionString, userID);
                
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

        public void RecipeMenu(Operator operations, string connectionString, int userID)
        {
            //i would like you to explain this to me
            //if (Recipes.Any<Recipe>() == false)
            //{
                Recipes = operations.allRecipes(connectionString);
            //}

            Console.WriteLine();
            Console.Write("All Recipes (recipe or 1)" + "\n");
            Console.Write("See ingredients from a recipe '2' " + "\n");
            Console.Write("See instructions from a recipe '3' " + "\n");
            Console.WriteLine("Print recipe by ID '4' ");
            Console.WriteLine("Delete Recipe '5'");
            Console.WriteLine("Update Recipe '6'");
            Console.WriteLine("Reorder Recipe '7'");
            Console.Write("'menu' for main menu" + "\n");
            Console.WriteLine();


           

            //  Console.Write("all Ingredients in a receipe" + "\n");

            string userInput = Console.ReadLine();
             
            //  operations.allIngredientInRecipe(connectionString);
            bool acted = false;

            //if(userInput=="1" || userInput == "recipe")
            //{
            //    foreach(Recipe temprecipe in Recipes)
            //    {
            //        temprecipe.printRecipe();
            //    }
            //}

            if (userInput == "2")
            {
                operations.allIngredientInRecipe(connectionString);
            }
            if (userInput == "3")
            {
                operations.allInstructionInRecipe(connectionString);
            }
            if (userInput == "4")
            {
                Recipe myrecipe = operations.RecipeByID(connectionString,userID);
                myrecipe.printRecipe();
            }
            if(userInput == "5")
            {
                operations.allRecipes(connectionString);
                Console.WriteLine("Select Recipe By ID");
                Recipe Rec = operations.RecipeByID(connectionString, userID);
                if (Rec.getInstructionRecipe().Any<Instruction>())
                {
                    operations.DeleteRecipeWithInstruction(connectionString, userID, Rec);
                }
                else
                {
                    operations.DeleteRecipeWithoutInstruction(connectionString, userID, Rec);
                }
            }
            if(userInput == "6")
            {
                Recipe myrecipe = operations.RecipeByID(connectionString, userID);

                string title = "";
                string description = "";
                int servingsize = 0;
                Console.WriteLine("Title is: " + myrecipe.getName());
                Console.WriteLine("Description is: " + myrecipe.getDescription());
                Console.WriteLine("Serving Size is: " + myrecipe.getServingSize());
                Console.WriteLine("Update?  Y/N");
                if(Console.ReadLine() == "Y")
                {
                    Console.WriteLine("New title: ");
                    title = Console.ReadLine();
                    Console.WriteLine("New Description: ");
                    description = Console.ReadLine();
                    Console.WriteLine("New Serving Size");
                    servingsize = Convert.ToInt32(Console.ReadLine());
                    myrecipe.setName(title);
                    myrecipe.setDescription(description);
                    myrecipe.setServingSize(servingsize);
                    operations.UpdateRecipe(connectionString, myrecipe, userID);
                }

                //operations.UpdateRecipe(connection, );
            }
            if (userInput == "menu")
            {
                acted = true;
            }

            if (acted == false)
            {
                RecipeMenu(operations, connectionString, userID);
            }
        }
        public void Instructions(Operator operations, string connectionString)
        {
            Console.Write("All Instruction Menu" + "\n");
            
        }

        


    }
}
