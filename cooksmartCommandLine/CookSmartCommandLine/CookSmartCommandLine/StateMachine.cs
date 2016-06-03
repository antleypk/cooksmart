// Include dependencies needed for the class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// namespace: collection of classes which make up a module
namespace CookSmartCommandLine
{
    public class StateMachine
    {
        // Classwide objects 
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
        private List<DateTime> loginAttempts = new List<DateTime>();
        private int validationkount = 0;

        // Blank constructor
        public StateMachine()
        {
            // Empty StateMachine
        }

        // Asks user to either sign in or create a new login
        public void createOrNot(string connection)
        {
            Console.WriteLine("'1' to sign in '2' to create new login");
            string userInput = Console.ReadLine();
            // Trim() function removes spaces from string
            userInput = userInput.Trim();
            if (userInput != "1" && userInput != "2")
            {
                // If the user does not input valid parameters, the menu restarts, recursion
                createOrNot(connection);
            }
            if (userInput == "2")
            {
                // Call createNewLogin() function, send a connection as a parameter
                createNewLogin(connection);
            }
        }

        public void createNewLogin(string connection)
        {
            // Prompt the user for their desired username, error: does not check to see whether username is unique
            Console.WriteLine("Enter User Name:");
            string userName = Console.ReadLine();
            // Prompt the user for their desired password
            Console.WriteLine("Enter Password");
            string password1 = Console.ReadLine();
            // Prompt the user to enter their password again
            Console.WriteLine("Re-enter Password");
            string password2 = Console.ReadLine();
            // Check to see if the user entered the same password twice
            if (password1 != password2)
            {
                // If the two passwords are not the same, writes an message to the console and then recursion happens
                Console.WriteLine("Password MissMatch please try again");
                createNewLogin(connection);
            }
            // Create a new object of type Operator called from operator.cs
            Operator newUser = new Operator();
            // Call the insertUser() function on object newUser, pass connection, userName, and password1 as parameters
            newUser.insertUser(connection, userName, password1);
        }
        public void validation(string connectionString)
        {
            // Provide option to create a new login using createOrNot() function
            createOrNot(connectionString);
            // Create a new object of type Operator called from operator.cs
            Operator operations = new Operator();
            // Prompt the user for their username
            Console.WriteLine("Input UserName:");
            userName = Console.ReadLine();
            // Trim spaces from user input
            userName = userName.Trim();
            // Prompt the user for their password
            Console.WriteLine("Please enter your password: ");
            string password = Console.ReadLine();
            // Trim spaces from user input
            password = password.Trim();
            // Check to see if the supplied username exists in the database
            bool usernamecheck = operations.checkusername(connectionString, userName);
            // Check to see if the password supplied matches the password associated with the username in the database
            bool passwordcheck = operations.checkuser(connectionString, userName, password);

            if (usernamecheck)
            {
                // If username exists, proceed
                if (passwordcheck)
                {
                    // If the password matches the username, login is successful
                    // If login is successful, find the userID
                    int id = operations.GetUserID(connectionString, userName, password);
                    // User is logged in, and UserID is set to global
                    UserID = id;
                }
                else
                {
                    // Create a new object of type DateTime, set equal to the current date and time
                    DateTime now = DateTime.Now;
                    // 
                    List<DateTime> logintimes = operations.userloginattempts(connectionString, userName);
                    // Insert the most recent login attempt to database
                    logintimes.Insert(0, now);
                    // Remove temporary fifth login
                    logintimes.RemoveAt(logintimes.Count - 1);
                    // Update the number of login attempts in the database
                    operations.updatelogins(connectionString, logintimes, userName);
                    // Add a login attempt to validationkount
                    validationkount++;
                    // Write the number of failed login attempts, number of tries remaining, and most recent login attempt
                    Console.WriteLine("Number of wrong tries: " + validationkount);
                    Console.WriteLine("Number of tries remaining: " + (5 - validationkount));
                    Console.WriteLine(Convert.ToString(logintimes[0]));
                    // If validationkount is greater than 4, write "Access is denied" to the console and exit
                    if (validationkount >= 5)
                    {
                        Console.WriteLine("Access is denied");
                        Environment.Exit(0);
                    }
                    validation(connectionString);
                }

            }

            if (validationkount >= 5)
            {
                Console.WriteLine("Access fail");
                Environment.Exit(0);
            }
            if (usernamecheck.ToString() == "False")
            {
                validationkount++;
                Console.WriteLine("\n" + "validation count" + validationkount);
                validation(connectionString);
            }
        }
        // StateMachine.cs is the grandfather of the app CookSmart

        // Startup() is the first function called to set up the app
        public void startUp()
        {
            string connectionString = "Server= 108.167.137.112;Port=3306;Database=tractio2_CookSmart;uid=tractio2_generic;password=Pa88word;Convert Zero Datetime=True";
            Console.Write("Welcome to CookSmart" + "\n");
            Console.WriteLine("CookSmartClassic 1.02+");
            Console.Write("Thanks for choosing Traction Systems" + "\n" + "\n");
            // Checks to see if user has a valid username and password combination (Authentication)
            validation(connectionString);
            // Create a boolean called acted
            bool acted = false;
            // Check to see if the username supplied by the user is empty or less than 5 characters long
            if (userName == "" || userName.Length < 5)
            {
                Console.WriteLine("User Name must be greater than 5 characters");
                // If it is, recursively call startUp() to begin the process again
                startUp();
                acted = true;
            }
            // Display a welcome message and the UserID
            Console.WriteLine("Thanks for choosing CookSmart: " + userName);
            Console.WriteLine("UserID: " + UserID);
            Console.WriteLine();
            if (acted == false)
            {
                // Call the startMenu() function and pass UserID and connectionString as parameters
                startMenu(UserID, connectionString);
            }

        }

        public void startMenu(int userID, string connectionString)
        {

            Operator operations = new Operator();
            Console.WriteLine("Main Menu! \nOptions \n");
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
            Console.WriteLine("Calendar '11'");
            Console.WriteLine("Build Meal '12'");
            Console.WriteLine("Meal Menu '13'");
            Console.WriteLine("Enter 'exit' to quit");
            Console.WriteLine("");

            string userInput = Console.ReadLine();
            userInput = userInput.ToLower();
            bool acted = false;
            if (userInput == "1" || userInput == "ingredients")
            {
                IngredientMenu(operations, connectionString, userID);

            }
            if (userInput == "2" || userInput == "recipes")
            {
                Console.WriteLine("recipes menu");
                RecipeMenu(operations, connectionString, userID);
            }

            if (userInput == "3" || userInput == "instructions")
            {
                Console.WriteLine("instructions menu");
                InstructionMenu(operations, connectionString, userID);
            }
            if (userInput == "4" || userInput == "cookSmart")
            {
                Console.WriteLine();
                operations.cookSmart(connectionString, UserID);
            }
            if (userInput == "5" || userInput == "users")
            {
                Console.WriteLine("User menu");
                UserMenu(operations, connectionString, userID);
            }
            if (userInput == "6")
            {
                Console.WriteLine("New Recipe");
                RecipeGuide myGuide = new RecipeGuide("Test Recipe", UserID);
                Recipe newRecipe = myGuide.startUpRecipeGuide(connectionString, UserID);

            }
            if (userInput == "7")
            {
                Console.WriteLine("Create menu");
                CreateMenu(operations, connectionString);
            }
            if (userInput == "8")
            {
                Console.WriteLine("Stub only");

            }
            if (userInput == "9")
            {
                Console.WriteLine("Stub only");
            }
            if (userInput == "10")
            {
                Console.WriteLine("A quick spot for bebuggig");
                Console.ReadLine();
            }
            if (userInput == "11" || userInput == "calender")
            {
                calenderMenu(connectionString, operations, userID);
            }
            if (userInput == "12")
            {
                MealBuilder newMeal = new MealBuilder();
                newMeal.StartBuilder(connectionString,userID);
            }
            if (userInput == "13")
            {
                Console.WriteLine("Meal Menu");
                mealMenu(connectionString, operations, userID);

            }

            if (userInput == "exit")
            {
                acted = true;
            }

            if (acted == false)
            {
                startMenu(userID, connectionString);
            }

        }
        public void mealMenu(string connection, Operator operations, int userID)
        {
            bool act = false;
            Console.WriteLine();
            Console.WriteLine("Meal Menu");
            Console.WriteLine("All meals '1'");
            Console.WriteLine("Chose meal by ID '2'");
            Console.WriteLine("menu for main");
            Console.WriteLine();
            string userInput = Console.ReadLine();
            userInput = userInput.ToLower();
            if (userInput == "1")
            {
              List<Meal> allmeals =  operations.allMeals(connection);
                for (int i = 0; i < allmeals.Count; i++)
                {
                    Meal temp = new Meal();
                    temp = allmeals.ElementAt(i);
                    temp.printMeal(connection);
                }
                act = true;
                Console.WriteLine();
            }
            if (userInput == "2")
            {
                Operator operation = new Operator();
                List<Meal> allmeals = operations.allMeals(connection);
                for (int c = 0; c < allmeals.Count(); c++)
                {
                    Console.WriteLine(allmeals[c].getName() + " " + allmeals[c].getID());
                    //allmeals[c].printMeal();
                }
                Console.WriteLine();
                Console.WriteLine("Choose your MealID");
                Console.WriteLine();
                string mealIDInput = Console.ReadLine();
                mealIDInput = mealIDInput.Trim();
                int mealID = 489037509;
                 bool parse = Int32.TryParse(mealIDInput, out mealID);
                int index = 0;
                for(int d=0; d<allmeals.Count; d++)
                {
                    if (allmeals[d].getID() == mealID)
                    {
                        index = d;
                    }
                }            
                 Meal petersTest = new Meal(userID, mealID, connection);
                 petersTest.printMeal(connection);

            }
            if (userInput == "menu")
            {
                act = true;
            }
           if (!act)
            {
                mealMenu(connection, operations, userID);
            }        

        }
        public void calenderMenu(string connection, Operator operations, int userID)
        {
            Console.WriteLine("Calender Menu");
            //view all Calendar objects associated with user.
            List<Calendar> UserCalendar = new List<Calendar>();
            UserCalendar = operations.UserCalendar(connection, userID);
            foreach(Calendar c in UserCalendar)
            {
                Console.WriteLine(c.getMeal().getName() + " " + c.getTimeToBeServed().ToString());
            }
            //build a list of meals for user.
            //iterate through and print meals.
            CalendarBuilder petersBuilder = new CalendarBuilder();
            petersBuilder.startUp(userID, connection, operations);
        }
        public void CreateMenu(Operator operations, string connectionString)
        {
            Console.WriteLine("Created Ingredients");
            foreach (Ingredient blah in createdIngredients)
            {
                blah.printIngredient();
            }
            Console.WriteLine("Created Instructions");
            foreach (Instruction meh in createdInstruction)
            {
                meh.printInstructionToConsole();
            }
            Console.WriteLine("All who venture here be warnded");
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
            if (userInput == "1")
            {
                RecipeGuide myGuide = new RecipeGuide("Test Recipe", UserID);
                Recipe myrecipe = myGuide.startUpRecipeGuide(connectionString, UserID);
                myGuide.previewRecipe(myrecipe);
            }
            if (userInput == "2")
            {
                Ingredient myingredient = new Ingredient();
                createdIngredients.Add(myingredient);
            }

            if (userInput == "4")
            {
                Console.WriteLine("Created ingredients:");
                foreach (Ingredient temp in createdIngredients)
                {
                    temp.printIngredient();
                }
                Console.WriteLine("Created instructions:");
                foreach (Instruction temp in createdInstruction)
                {
                    temp.instructionRelavant();
                }
            }
            if (userInput == "5")
            {
                Console.WriteLine("Created ingredients:");
                foreach (Ingredient temp in createdIngredients)
                {
                    temp.printIngredient();
                }
                Console.WriteLine("Select Created Ingredient By Name");
                string ingname = Console.ReadLine();
                foreach (Ingredient temp in createdIngredients)
                {
                    if (temp.getName() == ingname)
                    {
                        operations.insertIngredient(connectionString, temp, UserID);
                    }
                }
            }
            if (userInput == "6")
            {
                Console.WriteLine("Created instructions:");
                foreach (Instruction temp in createdInstruction)
                {
                    temp.printInstructionToConsole();
                }
                Console.WriteLine("Select Created Instruction By Name");
                string insname = Console.ReadLine();
                foreach (Instruction temp in createdInstruction)
                {
                    if (temp.getTitle() == insname)
                    {
                        operations.insertInstruction(connectionString, temp, UserID);
                    }
                }
            }
            if (userInput == "menu")
            {
                acted = true;
            }
            if (acted == false)
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
                foreach (Ingredient tempIngredient in Ingredients)
                {
                    tempIngredient.printIngredient();
                }
            }
            if (userInput == "2")
            {
                createingredient(connectionString, operations, userID);
            }
            if (userInput == "3")
            {
                Ingredient temping = operations.IngredientByID(connectionString, userID);
                temping.printIngredient();

            }
            if (userInput == "4")
            {
                Ingredient temping = operations.IngredientByName(connectionString, userID);
                temping.printIngredient();
            }
            if (userInput.ToLower() == "menu")
            {
                acted = true;
            }
            if (acted == false)
            {
                IngredientMenu(operations, connectionString, userID);
            }

        }
        public void createingredient(string connectionString, Operator operations, int userID)
        {

            Console.WriteLine();
            Ingredient newIngredient = new Ingredient(userID);
            newIngredient.printIngredient();
            Console.WriteLine("Accept 'A' Restart 'R'");
            string userinput = Console.ReadLine();

            if (userinput.ToLower() == "a")
            {
                //Insert Ingredient
                operations.insertIngredient(connectionString, newIngredient, userID);
            }
            if (userinput.ToLower() == "r")
            {
                //restart
                createingredient(connectionString, operations, userID);
            }
        }
        public void InstructionMenu(Operator operations, string connectionString, int userID)
        {
            Console.WriteLine();
            Console.WriteLine("This is the instruction menu! \n Options: ");
            Console.WriteLine("All Instructions '1' ");
            Console.WriteLine("Ingredients from an Instruction '2' ");
            Console.WriteLine("Delete Instruction '3'");
            Console.WriteLine("Update Instruction '4'");

            Console.WriteLine("Main Menu 'Menu'");

            string userInput = Console.ReadLine();
            userInput = userInput.ToLower();
            bool acted = false;

            if (userInput == "1")
            {
                Console.WriteLine();
                List<Instruction> MyInstructions = operations.allInstructions(connectionString, userID);
                int count = 0;
                foreach (Instruction tempIns in MyInstructions)
                {
                    tempIns.instructionRelavant();
                    Console.WriteLine(tempIns.getTitle() + " " + tempIns.getID());
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
            if (userInput == "3")
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
            if (userInput == "4")
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
                    if (Console.ReadLine().ToLower() == "y")
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

                if (userInput == "menu")
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
            userInput = userInput.ToLower();
            if (Users.Any<User>() == false)
            {
                Users = operations.AllUsers(connectionString);
            }

            bool acted = false;

            if (userInput == "1")
            {
                foreach (User tempuser in Users)
                {
                    tempuser.printUser();
                }
            }
            if (userInput == "2")
            {
                //all meals created by the current user
                operations.UserMeals(connectionString,userID);
            }
            if (userInput == "3")
            {
                Kitchen = operations.UserKitchen(connectionString, userID);

                foreach (Kitchen tempkitchen in Kitchen)
                {
                    tempkitchen.printKitchen();

                }
                Kitchen.Clear();
            }
            if (userInput == "4")
            {
            //    Console.WriteLine("Peter Debugging SM 681");
                Calendar = operations.UserCalendar(connectionString, userID);
                for (int i = 0; i < Calendar.Count; i++)
                {
                    ////int mealid = Calendar[i].getMeal().getID();
                    //var starmeal = new Meal();
                    //starmeal.setName()
                    
                    //MealBuilder helper = new MealBuilder();
                    //Meal populatedMeal= helper.AutoBuilder(connectionString, userID, userMeal);
                    //Calendar[i].setMeal(populatedMeal);
                    //Calendar[i].printCalendar();

                }
            }
            if (userInput == "5")
            {

                ShoppingList = operations.ShoppingList(connectionString, userID);

                foreach (Kitchen tempkitchen in ShoppingList)
                {
                    tempkitchen.printKitchen();
                }
                ShoppingList.Clear();
            }
            if (userInput == "6")
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
            if (userInput == "7")
            {
                List<Recipe> Recipes = operations.RecipesByUser(connectionString);
                foreach (Recipe temp in Recipes)
                {
                    temp.printRecipe();
                }
            }
            if (userInput == "8")
            {
                List<Instruction> Instructions = operations.InstructionsByUser(connectionString);
                foreach (Instruction temp in Instructions)
                {
                    temp.printInstructionToConsole();
                }
            }
            if (userInput == "9")
            {
                List<Ingredient> Ingredients = operations.IngredientsByUser(connectionString);
                foreach (Ingredient temp in Ingredients)
                {
                    temp.printIngredient();
                }
            }
            if (userInput == "menu")
            {
                acted = true;
            }
            if (acted == false)
            {
                UserMenu(operations, connectionString, userID);
            }
        }

        public void RecipeMenu(Operator operations, string connectionString, int userID)
        {
            //this speeds up the process by bipassing the database interaction if its already local
            // as a team we need to figure how to do this on a much bigger scale to minimize interactions that happen 
            //in real time so that users feel like the app is fast
            if (Recipes.Any<Recipe>() == false)
            {
                Recipes = operations.allRecipes(connectionString);
             }
            Console.WriteLine("\nRecipe Menu!  Options: \n ");
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
            userInput = userInput.ToLower();
            //  operations.allIngredientInRecipe(connectionString);
            bool acted = false;

            if (userInput == "1" || userInput == "recipe")
            {
                List<Recipe> myRecipes=operations.allRecipes(connectionString);
                foreach (Recipe temprecipe in myRecipes)
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
                Recipe myRecipe = operations.RecipeByID(connectionString, userID);
                // myrecipe.printRecipe();
                // RecipeGuide myGuide = new RecipeGuide(UserID);
                //  myGuide.previewRecipe(myRecipe);
            }
            if (userInput == "5")
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
            if (userInput == "6")
            {
                Recipe myrecipe = operations.RecipeByID(connectionString, userID);

                RecipeGuide guide = new RecipeGuide(userID);
              
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
