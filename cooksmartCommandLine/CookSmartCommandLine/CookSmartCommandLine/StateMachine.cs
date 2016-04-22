using System;
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
            Console.Write("Enter 'exit' to quit" + "\n");

            string userInput = Console.ReadLine();
            bool acted = false;
            if (userInput == "1")
            {
                IngredientMenu(operations, connectionString);
                
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


        


    }
}
