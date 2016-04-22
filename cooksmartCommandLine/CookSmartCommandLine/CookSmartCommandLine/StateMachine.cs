﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
   public class StateMachine
    {
        public StateMachine()
        {

        }

        public void startUp()
        {
            Console.Write("Welcome to CookSmart" + "\n");
            Console.Write("Thanks for chosing Traction Systems"+"\n"+"\n");
            startMenu();
        }

        public void startMenu()
        {
            // a menu should be put here
            Operator operations = new Operator();
            string connectionString = "Server= 108.167.137.112;Port=3306;Database=tractio2_CookSmart;uid=tractio2_Frank;password=Pa88word";
            Console.Write("Ingredients '1'" + "\n");
            Console.Write("Recipes '2'" + "\n");
            Console.Write("Instructions '3' " + "\n");
            Console.WriteLine("CookSmart '4' ");
            Console.Write("Enter 'exit' to quit" + "\n");

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
            if (userInput == "4")
            {
                Console.WriteLine();
                operations.cookSmart(connectionString);
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


        public void IngredientMenu(Operator operations, string connectionString)
        {
            Console.Write("All Ingredients" + "\n");
            operations.allIngredients(connectionString);
           
        }

        public void InstructionMenu(Operator operations, string connectionString)
        {
            Console.WriteLine();
            Console.WriteLine("All Instructions '1' ");
            Console.WriteLine("Instructions from a Recipe '2' ");
            Console.WriteLine("Ingredients from an Instruction '3' ");

            Console.WriteLine("Main Menu 'Menu'");

            string userInput = Console.ReadLine();

            bool acted = false;

            if(userInput == "1")
            {
                Console.WriteLine();
                operations.allInstructions(connectionString);
                
            }
            if(userInput == "2")
            {
                Console.WriteLine();
                operations.allRecipes(connectionString);
                operations.allInstructionInRecipe(connectionString);
            }
            if (userInput == "3")
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

        public void RecipeMenu(Operator operations, string connectionString)
        {
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
                operations.allRecipes(connectionString);
            }

            if (userInput == "2")
            {
                operations.allRecipes(connectionString);
                operations.allIngredientInRecipe(connectionString);
            }
            if (userInput == "3")
            {
                operations.allRecipes(connectionString);
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
