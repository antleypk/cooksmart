using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.Collections.Generic;


namespace CookSmartCommandLine
{
    public class RecipeGuide
    {
        //we need all the parts to build a recipe right here
        List<Ingredient> MyIngredients = new List<Ingredient>();

        List<Instruction> MyInstructions = new List<Instruction>();
        Recipe thisrecipe = new Recipe();
        Operator operations = new Operator();
        private string name = "";
        private string conn;
        public RecipeGuide()
        {

        }

        public RecipeGuide(string NameIn)
        {
            name = NameIn;

        }

        public Recipe startUpRecipeGuide(string connection)
        {
            this.conn = connection;
            Console.WriteLine("Insert Recipe Name: ");
            string userinput = Console.ReadLine();
            thisrecipe.setName(userinput);
            Console.WriteLine("Insert Recipe Description");
            userinput = Console.ReadLine();
            thisrecipe.setDescription(userinput);
            Console.WriteLine("Set Serving Size");
            userinput = Console.ReadLine();
            thisrecipe.setServingSize(Convert.ToInt32(userinput));
            List<Ingredient> ListTempIngredients = operations.allIngredients(connection);
            Console.WriteLine("Ingredients" + ListTempIngredients.Count);
            Console.WriteLine();

           // List<Instruction> ListTempInstructions = operations.allInstructions(connection);
         //   Console.WriteLine("Instructions" + ListTempInstructions.Count);
            foreach (Ingredient tempIngredient in ListTempIngredients)
            {
                tempIngredient.printIngredient();
            }


            setIngredientsInRecipe(ListTempIngredients);
            setInstructionsInRecipe(connection);
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
                    startUpRecipeGuide(connection);
                    acted = true;
                }
                if (userInput == "C")
                {
                    insertRecipe(thisrecipe);
                    acted = true;
                }
            }
            return thisrecipe;
            

        }
        public void previewRecipe(Recipe thisrecipe)
        {
            Console.WriteLine("Top level Info");
            double quantity = 0;
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
        public void insertRecipe(Recipe recipetoinsert)
        {
            operations.InsertRecipe(conn,1, recipetoinsert);
            int recipeid = operations.GetRecipeID(conn, 1, recipetoinsert);
            operations.InsertInstructionRecipe(conn, 1, recipetoinsert);
            operations.InsertInstructionIngredient(conn, 1, recipetoinsert);
        }

        public void setIngredientsInRecipe(List<Ingredient> totalIngredients)
        {
            Console.WriteLine("Total ingredients " + totalIngredients.Count);
            Console.WriteLine("MyIngredients count before " + MyIngredients.Count);
            Console.WriteLine("'continue' to continue");
            bool finish = false;
            Console.WriteLine("Input the name of the ingredient you wish to chose");
            string userInput = Console.ReadLine();
            userInput = userInput.Trim();
            foreach(Ingredient temp in totalIngredients)
            {
                if (userInput == temp.getName())
                {
                    MyIngredients.Add(temp);
                    
                }
            }
            Console.WriteLine("MyIngredients count after " + MyIngredients.Count);
            if (userInput == "continue")
            {
                finish = true;
            }
            if (finish==false)
            {
                setIngredientsInRecipe(totalIngredients);
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
                currentInstruction.printInstructionToConsole();
                currentInstruction.setOrder(i);
                while (finish == false)
                {
                    int ingredientCount = MyIngredients.Count();
 //                   Console.WriteLine("ingredient count inside " + ingredientCount);
                    for (int e = 0; e < MyIngredients.Count(); e++)
                    {
                        currentIngredient = MyIngredients[e];
                        currentIngredient.printIngredient();
                    }
                    Console.WriteLine("Select the ingredient to go with the instruction by id or 'continue' to exit");
                    string userInput = Console.ReadLine();
                    userInput = userInput.Trim();
                    if (userInput == "continue")
                    {
                        finish = true;
                    }
                    else
                    {
                        Ingredient ingredient;
                        try
                        {
                             ingredient = MyIngredients.Single(x => x.getId() == Convert.ToInt32(userInput));
                        }
                        catch
                        {
                            ingredient = new Ingredient();
                            Console.WriteLine("UserInput Error: ID=USERID != 2 reality");
                        }
                        currentInstruction.addIngredient(ingredient);
                        Console.WriteLine("Select the quantity of the ingredient");
                        userInput = Console.ReadLine();
                        userInput = userInput.Trim();
                        ingredient.setQuantity(Convert.ToDouble(userInput));
                    }
                }
            }
        }
        

        public void setInstructionsInRecipe(string connectionString)
        {

           List<Instruction> tempInstructions= operations.allInstructions(connectionString);
            foreach(Instruction instruction in tempInstructions)
            {
                instruction.printInstructionToConsole();
            }
           int tempCount= tempInstructions.Count;
            Console.WriteLine( "MyIngredients count before " + MyIngredients.Count+" tempinstruction count before"+tempCount);
            Console.WriteLine(" Instruction global after " + MyInstructions.Count);
            Console.WriteLine("'continue' to continue");
            bool finish = false;
            Console.WriteLine("Input the id of the instruction you wish to chose");
            string userInput = Console.ReadLine();
            userInput = userInput.Trim();
            foreach (Instruction instruction in tempInstructions)
            {
               if( instruction.getID().ToString()== userInput)
                {
                    MyInstructions.Add(instruction);
                }
            }

            Console.WriteLine("Instruction global after " + MyInstructions.Count);
            if (userInput == "continue")
            {
                finish = true;
            }
            if (finish == false)
            {
                setInstructionsInRecipe(connectionString);
            }


        }

    }
        }

