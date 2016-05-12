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
        private List<Calendar> calendar = new List<Calendar>();
        private List<Kitchen> Kitchen = new List<Kitchen>();
        private List<Kitchen> ShoppingList = new List<Kitchen>();
        private List<Kitchen> TodaysShopping = new List<Kitchen>();
        private List<Ingredient> createdIngredients = new List<Ingredient>();
        private List<Instruction> createdInstruction = new List<Instruction>();
        private List<DateTime> loginAttempts = new List<DateTime>();
        
        private int validationkount = 0;

        public StateMachine()
        {
           
            }
        public void createOrNot(string connection)
        {
            Console.WriteLine("'1' to sign in '2' to create new login");
            string userInput = Console.ReadLine();
            if(userInput!="1" && userInput != "2")
            {
                createOrNot(connection);
            }
            if (userInput == "2")
            {
                createNewLogin(connection);
            }
        }
        public void createNewLogin(string connection)
        {
            Console.WriteLine("Enter User Name:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password1 = Console.ReadLine();
            Console.WriteLine("Re-enter Password");
            string password2 = Console.ReadLine();
            if (password1 != password2)
            {
                Console.WriteLine("Password MissMatch please try again");
                createNewLogin(connection);
            }
            Operator newUser = new Operator();
            newUser.insertUser(connection, userName, password1);
        }
        public void validation(string connectionString)
        {

            createOrNot(connectionString);
            Operator operations = new Operator();
            Console.WriteLine("Input UserName:");
            userName = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            string password = Console.ReadLine();
            bool usernamecheck = operations.checkusername(connectionString, userName);
            bool passwordcheck = operations.checkuser(connectionString, userName, password);
            if (usernamecheck)
            {
                if (passwordcheck)
                {

                    int id = operations.GetUserID(connectionString, userName, password);
                    UserID = id;
                }
                else
                {
                    DateTime now = DateTime.Now;
                    List<DateTime> logintimes = operations.userloginattempts(connectionString, userName);
                    logintimes.Insert(0, now);
                    logintimes.RemoveAt(logintimes.Count - 1);
                    operations.updatelogins(connectionString, logintimes, userName);
                    validationkount++;
                    Console.WriteLine("Number of wrong tries: " + validationkount);
                    Console.WriteLine("Number of tries remaining: " + (5 - validationkount));
                    Console.WriteLine(Convert.ToString(logintimes[0]));
                    if(validationkount >= 5)
                    {
                        Console.WriteLine("Access fail");
                        Environment.Exit(0);
                    }
                    validation(connectionString);
                }

            }

            if(validationkount >= 5)
            {
                Console.WriteLine("Access fail");
                Environment.Exit(0);
            }
            if (usernamecheck.ToString() == "False")
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
            Console.WriteLine("CookSmartClassic1.0+");
            Console.Write("Thanks for choosing Traction Systems"+"\n"+"\n");

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
            Console.WriteLine("Main Menu!  Submenu Options \n \n");
            Console.Write("Ingredients '1'" + "\n");
            Console.Write("Recipes '2'" + "\n");
            Console.Write("Instructions '3' " + "\n");
            Console.WriteLine("CookSmart '4' ");
            Console.WriteLine("User Menu '5' ");
            Console.WriteLine("Recipe Builder '6'");
            Console.WriteLine("Create menu '7'");
            //not what it does below
            Console.WriteLine("RecipeID by Name and user ID '8'"); // returns Recipe ID, with its a name and a userID as input
            Console.WriteLine("IngredientID by Name and user ID '9'");
            Console.WriteLine("GOD MODE '10'");
            Console.WriteLine("Calendar '11'");
            Console.WriteLine("Build Meal '12'");
            Console.WriteLine("Meal Menu '13' ");
            Console.WriteLine("Enter 'exit' to quit");
            Console.WriteLine("");

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
                operations.cookSmart(connectionString,UserID);
            }
            if(userInput == "5" || userInput == "Users")
            {
                Console.WriteLine("User menu"); 
                UserMenu(operations, connectionString, userID);
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

                Console.WriteLine("Note that you can only view recipe primary keys of recipes you created");
                Console.WriteLine("Please Enter Recipe Title");
                string recipeTitle = Console.ReadLine();
                int recipeID = operations.GetRecipeID(connectionString, userID, recipeTitle);
                Console.WriteLine("recipeID: " + recipeID);

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
                calenderMenu(connectionString, operations, userID);
            }
            if(userInput=="12")
            {
                MealBuilder newMeal = new MealBuilder();
                newMeal.StartBuilder(connectionString,UserID);
            }
            if (userInput == "13")
            {
                mealMenu(connectionString, operations, UserID);
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
        public void mealMenu(string connection, Operator operations, int userID)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to the Meal Menu");
            Console.WriteLine("All Meals (1)");
            Console.WriteLine("menu for main Menu");

            bool acted = false;
            string userInput = Console.ReadLine();


            if (userInput == "1")
            {
                List<Meal> allmeals = operations.allMeals(connection);
                for (int i = 0; i < allmeals.Count; i++)
                {
                    Meal temp = allmeals.ElementAt(i);
                    string title = temp.getName();
                    int author = temp.getUserID();
                    Console.WriteLine(title + " created by " + author);
                }
                acted = true;
            }



            if (userInput == "menu")
            {
                acted = true;
            }

            if (!acted)
            {
                mealMenu(connection, operations, userID);
            }
        }
        public void calenderMenu(string connection, Operator operations, int userID)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Calender Menu");
            Console.WriteLine("Add meal to calendar (1)");
            Console.WriteLine("Type 'Menu' for main menu.");
            string userInput = Console.ReadLine();
            userInput.Trim().ToLower();
            bool acted = false;

            if (userInput == "menu")
            {
                acted = true;
            }
            if(userInput == "1")
            {
                Console.WriteLine("Finney State Machine 263");
                operations.UserMeals(connection, UserID);
                acted = true;
            }
            if (!acted)
            {
                calenderMenu(connection, operations, userID);
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

            Console.WriteLine("This is the create/insert menu!  Please pick from these options");
            Console.WriteLine("Create new: \n");
            Console.WriteLine("Recipe '1'");
            Console.WriteLine("Ingredient '2'");
 
            Console.WriteLine("Show All Created ingredients/instructions '4'");
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

            Console.WriteLine("");
            Console.WriteLine("This is the Ingredient menu!");
            // Console.Write("All Ingredients" + "\n");
            Console.WriteLine("Options: number/Menu + enter ");
            Console.WriteLine();
            Console.WriteLine("Show All Ingredients '1'");
            Console.WriteLine("Insert Ingredient '2'");
            Console.WriteLine("Ingredient by ID '3'");
            Console.WriteLine("Ingredient by name '4'");
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
                Ingredient temping = operations.IngredientByName(connectionString, userID);
                temping.printIngredient();
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
            Console.WriteLine("");
            Console.WriteLine("This is the instruction menu! \n Options: ");
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
                    Console.WriteLine(tempIns.getTitle()+" "+tempIns.getID());
                    count++;
                }
                MyInstructions.Clear();
                Console.WriteLine();
                
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
               
                if (ins.getUserID() == userID)
                {
                    if (ins.getInstructionIngredients().Any<Ingredient>())
                    {
                        operations.DeleteInstructionWithIngredient(connectionString, ins, userID);
                    }
                    else
                    {
                        operations.DeleteInstructionWithoutIngredient(connectionString, ins, userID);
                    }
                }
               

            }
            if(userInput == "4")
            {
                Instruction ins = operations.InstructionByID(connectionString, userID);
                if (ins.getUserID() == userID)
                {
                    string title = "";
                    string description = "";
                    int preptime;
                    int cooktime;
                    Console.WriteLine("Title is: " + ins.getTitle());
                    Console.WriteLine("Description is: " + ins.getDescription());
                    Console.WriteLine("Preptime is: " + ins.getPrepTime());
                    Console.WriteLine("Cooktime is: " + ins.getCookTime());
                    Console.WriteLine("Update?  Y/N");
                    if (Console.ReadLine() == "Y")
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
                if (acted == false)
                {
                    InstructionMenu(operations, connectionString, userID);

                }
            }
               
        }
        public void UserMenu(Operator operations, string connectionString, int userID)
        {
            Console.WriteLine("This is the User Menu!  Options:");
            Console.WriteLine("All Users (1) ");
            Console.WriteLine("All Meals created by User (2) ");
            Console.WriteLine("Kitchen by User (3)");
            Console.WriteLine("Calendar by User (4)");
            Console.WriteLine("Shopping List from Calendar (5)");
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
                //all meals created by the current user
                operations.UserMeals(connectionString, UserID);
            }
            if(userInput == "3")
            {
                    Kitchen = operations.UserKitchen(connectionString, userID);

                foreach(Kitchen tempkitchen in Kitchen)
                {
                    tempkitchen.printKitchen();
                    
                }
                Kitchen.Clear();
            }
            if(userInput == "4")
            {
                    calendar = operations.UserCalendar(connectionString, userID);
            }
            if(userInput == "5")
            {

                    ShoppingList = operations.ShoppingList(connectionString, userID);

                foreach (Kitchen tempkitchen in ShoppingList)
                {
                    tempkitchen.printKitchen();
                }
                ShoppingList.Clear();
            }
            if(userInput == "6")
            {

                    ShoppingList = operations.ShoppingList(connectionString, userID);


                    Kitchen = operations.UserKitchen(connectionString, userID);

                List<Kitchen> TodaysShopping = new List<Kitchen>();
                foreach (Kitchen tempkitchen1 in ShoppingList)
                {
                    foreach (Kitchen tempkitchen2 in Kitchen)
                    {
                        if (tempkitchen1.getTitle() == tempkitchen2.getTitle())
                        {
                            decimal newquantity = Math.Max(0, tempkitchen1.getTotalQuantity() - tempkitchen2.getTotalQuantity());
                            tempkitchen1.setTotalQuantity(newquantity);

                        }
                        TodaysShopping.Add(tempkitchen1);
                    }
                }
                foreach (Kitchen tempkitchen in TodaysShopping)
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
                UserMenu(operations, connectionString, userID);
            }
        }

        /// <summary>
        /// Returns the menu that a user would use to navigate the recipe class
        /// </summary>
        /// <param name="operations">send an operator</param>
        /// <param name="connectionString">a connection string</param>
        /// <param name="userID">the current user's unique Identifier</param>
        public void RecipeMenu(Operator operations, string connectionString, int userID)
        {

            if (Recipes.Any<Recipe>() == false)
            {
                Recipes = operations.allRecipes(connectionString);
            }

            Console.WriteLine("\n \n Recipe Menu!  Options: \n ");
            Console.Write("All Recipes (recipe or 1)" + "\n");
            Console.Write("See ingredients from a recipe '2' " + "\n");
            Console.Write("See instructions from a recipe '3' " + "\n");
            Console.WriteLine("Print recipe by ID '4' ");
            Console.WriteLine("Delete Recipe '5'");
            Console.WriteLine("Update Recipe '6'");
            Console.WriteLine("Reorder Recipe '7'");
            Console.Write("'menu' for main menu" + "\n");
            Console.WriteLine();

            string userInput = Console.ReadLine();
             
            bool acted = false;

            if (userInput == "1" || userInput == "recipe")
            {
                foreach (Recipe temprecipe in Recipes)
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
            if (userInput == "4")
            {
                Recipe myRecipe = operations.RecipeByID(connectionString,userID);
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

    }
}
