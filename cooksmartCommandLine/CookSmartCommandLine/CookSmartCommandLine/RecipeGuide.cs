using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;



namespace CookSmartCommandLine
{
    public class RecipeGuide
    {
        //we need all the parts to build a recipe right here
        List<Ingredient> MyIngredients = new List<Ingredient>();

        List<Instruction> MyInstructions = new List<Instruction>();
        int userID=777777777;
        Recipe thisrecipe = new Recipe();
        Operator operations = new Operator();
        private string name = "";
        private string conn;
        public RecipeGuide(int UserID)
        {
            userID = UserID;
        }

        public RecipeGuide(string NameIn, int UserID)
        {
            name = NameIn;
            userID = UserID;
        }

        public Recipe startUpRecipeGuide(string connection,int userID)
        {
            this.conn = connection;
            Console.WriteLine("Insert Recipe Name: ");
            string userinput = Console.ReadLine();
            thisrecipe.setName(userinput);
            Console.WriteLine("Insert Recipe Description");
            userinput = Console.ReadLine();
            thisrecipe.setDescription(userinput);
            Console.WriteLine("Set Serving Size (Should be integer)");
            userinput = Console.ReadLine();
            thisrecipe.setServingSize(Convert.ToInt32(userinput));
            List<Ingredient> ListTempIngredients = operations.allIngredients(connection,userID);
            Console.WriteLine("Ingredients" + ListTempIngredients.Count);
            Console.WriteLine();

           // List<Instruction> ListTempInstructions = operations.allInstructions(connection);
         //   Console.WriteLine("Instructions" + ListTempInstructions.Count);
            foreach (Ingredient tempIngredient in ListTempIngredients)
            {
                tempIngredient.printIngredient();
            }


            setIngredientsInRecipe(ListTempIngredients, userID);
            Console.WriteLine("Please set instructions:");
            setInstructionsInRecipe(connection,userID);
            populateQuantities();
            
            for(int i=0; i < MyInstructions.Count(); i++)
            {
                thisrecipe.addInstruction(MyInstructions[i]);
            }
            //Console.WriteLine("Instructions Should be here");
            //foreach(Instruction temp in thisrecipe.getInstructionRecipe())
            //{
            //    temp.printInstructionToConsole();
            //}

            //preview revi
            previewRecipe(thisrecipe);
            
            bool acted = false;
            while (!acted)
            {
                Console.WriteLine("Continue or Restart?  'C' or 'R'");
                string userInput = Console.ReadLine();
                if (userInput == "R")
                {
                    startUpRecipeGuide(connection,userID);
                    acted = true;
                }
                if (userInput == "C")
                {
                    insertRecipe(thisrecipe,connection, userID);
                    
                    acted = true;
                }
            }
            return thisrecipe;
            

        }
        public void previewRecipe(Recipe thisrecipe)
        {
            Console.WriteLine("\n Top level Info");
            decimal quantity = 0;
            string quantityunits = "";
            int id = thisrecipe.getId();
            string name = thisrecipe.getName();
            string description = thisrecipe.getDescription();
            int servingsize = thisrecipe.getServingSize();
            Console.WriteLine("\n + id + \n: " + id + "\n + Title \n" + name + "\n + Description + \n" + description + "\n + Serving Size \n" + servingsize);
            List<Instruction> previewinstructions = thisrecipe.getInstructionRecipe();
            for(int i = 0; i < previewinstructions.Count(); i++)
            {
                int order = previewinstructions[i].getOrder() + 1;
                Console.WriteLine("\n Instruction #: " + order);
                name = previewinstructions[i].getTitle();
                description = previewinstructions[i].getDescription();
                id = previewinstructions[i].getID();
                Console.WriteLine("\n  id  \n: " + id + "\n  Title \n" + name + "\n  Description  \n" + description);
                List<Ingredient> previewingredients = previewinstructions[i].getInstructionIngredients();
                for(int j = 0; j < previewingredients.Count(); j++)
                {
                    int myOrder = (previewinstructions[i].getOrder()) + 1;
                    Console.WriteLine("\n Ingredients for Instruction #: " + myOrder);
                    name = previewingredients[j].getName();
                    description = previewingredients[j].getDescription();
                    id = previewingredients[j].getId();
                    quantity = previewingredients[j].getQuantity();
                    quantityunits = previewingredients[j].getQuantityType();
                    Console.WriteLine("\n id \n: " + id + "\n Title \n" + name + "\n Description \n" + description + "\n Quantity \n" + quantity + "\n Quantity Type \n" + quantityunits);
                }
            }
        }
        public void createInstruction(int userID)
        {
            Console.WriteLine("Instruction Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Description Name: ");
            string description = Console.ReadLine();
            int order = MyInstructions.Count + 1;
            Console.WriteLine("The order is: " + order);
            Instruction tempInstruction = new Instruction(userID);
            tempInstruction.setTitle(name);
            tempInstruction.setDescription(description);
            tempInstruction.setOrder(order);
            tempInstruction.setUserID(userID);
            MyInstructions.Add(tempInstruction);
            

        }
        public void createIngredient(int userID)
        {
            
            Console.WriteLine("New Ingredient Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Description Name: ");
            string description = Console.ReadLine();
            Console.WriteLine("Quantity Type");
            string quantitytype = Console.ReadLine();
            Ingredient tempingredient = new Ingredient();
            tempingredient.setName(name);
            tempingredient.setDescription(description);
            tempingredient.setQuantityType(quantitytype);
            tempingredient.setUserID(userID);
            tempingredient.setId(8888888);
            MyIngredients.Add(tempingredient);
        }
        public void insertRecipe(Recipe recipetoinsert, string connection, int userID) {

            //insertRecipe into Database
            //Print recipetoinsert's instructions:
            operations.InsertRecipe(conn, userID, recipetoinsert);
            //find primary key of recipe inserted
            int recipeid = operations.GetRecipeID(conn, userID, recipetoinsert);
            //set primary key
            recipetoinsert.setId(recipeid);
            //loop through MyIngredients; check for new Ingredients.  If new, Insert, then find primary key.
            for(int i = 0; i < MyIngredients.Count; i++)
            {
                //If ingredient is new, id = 8888888
                int id = MyIngredients[i].getId();
                if(id == 8888888)
                {
                    Console.WriteLine(MyIngredients[i].getName());
                    //Insert Ingredient into Database
                    operations.insertIngredient(connection, MyIngredients[i], userID);
                    //obtain primary key from database
                    int primarykey = operations.GetIngredientID(connection, userID, MyIngredients[i].getName());
                    //reset primary key from default to actual
                    MyIngredients[i].setId(primarykey);
                }
            }




            operations.InsertRecipeIngredient(conn, userID, recipetoinsert);


            //this will not work because the recipeIDs are wrong
            insertNewInstructions(connection,userID);//this will fix this
            operations.InsertInstructionRecipe(conn, userID, recipetoinsert);


            operations.InsertInstructionIngredient(conn, userID, recipetoinsert);
            

            operations.allIngredientFromRecipe(conn, recipetoinsert);
        }


        public void insertNewInstructions(string connection,int userID)
        {
            for(int i = 0; i < MyInstructions.Count; i++)
            {
                operations.insertInstruction(connection, MyInstructions[i],userID);
                int primarykey = operations.GetInstructionID(connection, userID, MyInstructions[i]);
                MyInstructions[i].setID(primarykey);
            }

            
            
        }


        public void setIngredientsInRecipe(List<Ingredient> totalIngredients, int userID)
        {
            Console.WriteLine("Ingredients in My Recipe: " + MyIngredients.Count);
            bool finish = false;
            Console.WriteLine("Create new Ingredient (create) or add from list (add)?");
            string userInput2 = Console.ReadLine();
            if(userInput2 == "add")
            {
                Console.WriteLine("Print the Ingredient Name from the List: ");
                string userInput = Console.ReadLine();
                userInput = userInput.Trim();
                Ingredient hold = new Ingredient();
                List<Ingredient> tempList = new List<Ingredient>();
                foreach (Ingredient temp in totalIngredients)
                {
                   
                    if (userInput == temp.getName())
                    {
                        tempList.Add(temp);
                        hold = temp;
                     //   Console.WriteLine("duplicate");
                        
                    }
                  
                }
               // Console.WriteLine("ingredient count" + tempList.Count);
                if (tempList.Count > 1)
                {

                    for (int d = 0; d < tempList.Count; d++)
                    {
                        Console.WriteLine("Position: " + d);
                        tempList[d].printIngredient();
                    }
                    Console.WriteLine("Please Select an ingredient by ID");
                    string uInput=Console.ReadLine();
                    int uInputInt = 0;
                    bool par = Int32.TryParse(uInput, out uInputInt);
                    int posistion = 0;
                    for(int f = 0; f < tempList.Count(); f++)
                    {
                        if (tempList[f].getId() == uInputInt)
                        {
                            posistion = f;
                        }
                    }

                    hold = tempList[posistion];
                    if (!par)
                    {
                        Console.WriteLine("User Error, input non-int");
                    }
                }

                MyIngredients.Add(hold);
                
            }
            if(userInput2 == "create")
            {
                createIngredient(userID);
            }
            
            Console.WriteLine("MyIngredients count after " + MyIngredients.Count);
            Console.WriteLine("Done adding Ingredients?  (Y/N)");
            string userInput3 = Console.ReadLine();
            if (userInput3 == "Y")
            {
                finish = true;
            }
            if (finish==false)
            {
                setIngredientsInRecipe(totalIngredients,userID);
            }
            

        }

        public void populateQuantities()
        {
            Instruction currentInstruction;
            Ingredient currentIngredient;

            for (int i = 0; i < MyInstructions.Count(); i++)
            {

                bool finish = false;
                currentInstruction = MyInstructions[i];
                currentInstruction.setOrder(i + 1);
                Console.WriteLine("Instruction #: " + (i+1));
                currentInstruction.printInstructionToConsole();
                currentInstruction.setOrder(i);
                while (finish == false)
                {
                    int ingredientCount = MyIngredients.Count();
                    Console.WriteLine("Available Ingredients: ");
                    for (int e = 0; e < MyIngredients.Count(); e++)
                    {
                        Console.WriteLine("Positition: "+e);
                        currentIngredient = MyIngredients[e];
                        currentIngredient.printIngredient();
                    }
                    Console.WriteLine("Select the ingredient to go with the instruction by position or 'continue' to exit");
                    string userInput = Console.ReadLine();
                    userInput = userInput.Trim();
                    if (userInput == "continue")
                    {
                        finish = true;
                    }
                    else
                    {
                        Ingredient ingredient=new Ingredient();
                        try
                        {
                            //ingredient = MyIngredients.Single(x => x.getId() == Convert.ToInt32(userInput));
                            //how do we deal with multiple things with the same name, b/c we dont have primary keys for 
                            //all ingredients
                            ingredient = MyIngredients.Single(x => x.getName() == userInput);
                        }
                        catch
                        {
                           // ingredient = new Ingredient();
                            Console.WriteLine("UserInput Error: ID=USERID != 2 reality");
                        }
                        Console.WriteLine("Select the quantity of the ingredient");
                        userInput = Console.ReadLine();
                        decimal quantity;
                        bool parse = Decimal.TryParse(userInput, out quantity);
                        if (parse==false)
                        {
                            quantity = 99999987;
                        }
                        ingredient.setQuantity(quantity);
                        currentInstruction.addIngredient(ingredient);
                    }
                }
            }
        }

        public void checkQuantities(Recipe rec)
        {
            List<Ingredient> RecipeIngredient = rec.getRecipeIngredient();
            List<Ingredient> InstructionIngredient = new List<Ingredient>();
            for (int i = 0; i < rec.getInstructionRecipe().Count; i++)
            {
                Instruction thisinstruction = rec.getInstructionRecipe()[i];
                for (int j = 0; j < thisinstruction.getInstructionIngredients().Count; j++) {
                    bool New = true;
                    for (int k = 0; k < InstructionIngredient.Count(); k++) 
                    {
                        if (InstructionIngredient[k].getName() == thisinstruction.getInstructionIngredients()[j].getName()){
                            New = false;
                            Console.WriteLine("Call");
                            
                            decimal currentquantity = InstructionIngredient[k].getQuantity();
                            Console.WriteLine("currentquantity is" + currentquantity);
                            Console.WriteLine("Will Add" + thisinstruction.getInstructionIngredients()[j].getQuantity());
                            InstructionIngredient[k].setQuantity(currentquantity + thisinstruction.getInstructionIngredients()[j].getQuantity());
                            break;

                        }
                        if (New)
                        {
                            InstructionIngredient.Add(thisinstruction.getInstructionIngredients()[j]);
                        }
                    }

                    InstructionIngredient.Add(thisinstruction.getInstructionIngredients()[j]);
                }
            }
            foreach (Ingredient temp in RecipeIngredient)
            {
                temp.printIngredient();
            }
            foreach(Ingredient temp in InstructionIngredient)
            {
                temp.printIngredient();
            }
        }

        public void setInstructionsInRecipe(string connectionString, int userID)
        {
           int count = 0;
            foreach(Instruction temp in MyInstructions)
            {
               
                count++;
                temp.setOrder(count);
                temp.printInstructionToConsole();

            }
            bool acted = false;
            Console.WriteLine("Add Instruction? (Add/No)");
            string userInput = Console.ReadLine();

           
            if (userInput == "Add")
            {
                createInstruction(userID);
            }
            Console.WriteLine("Done with Instructions? (Done/No)");
            userInput = Console.ReadLine();
            
            if(userInput == "Done")
            {
                acted = true;
            }
            if (acted == false)
            {
                setInstructionsInRecipe(connectionString, userID);
            }
            
            
        }


    }
        }

