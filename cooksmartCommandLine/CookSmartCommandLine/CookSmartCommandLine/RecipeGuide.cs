﻿using System;
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
        Operator operations = new Operator();
        private string name = "";
        public RecipeGuide()
        {

        }

        public RecipeGuide(string NameIn)
        {
            name = NameIn;

        }

        public void startUpRecipeGuide(string connection)
        {
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

            for(int i=0; i < MyInstructions.Count(); i++)
            {
                bool finish = false;
                currentInstruction = MyInstructions[i];
                currentInstruction.printInstructionToConsole();
                currentInstruction.setOrder(i);
                while (finish == false)
                {
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
                        Ingredient ingredient = MyIngredients.Single(x => x.getId() == Convert.ToInt32(userInput));
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
