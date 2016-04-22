using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
   public class Ingredient
    {
        private int id=0;
        private string name = "Ingredient name failed c#";
        public string description = "Description failed c#";
        private string quantitytype = "QuantityType failed at c#";

        public Ingredient()
        {

        }

        public Ingredient(int IngredientID, string Title,string Description, string QuantityType)
        {
            id = IngredientID;
            name = Title;
            description = Description;
            quantitytype = QuantityType;

        }
        public int getId()
        {
            return id;
        }
        public string getName()
        {
            return name;
        }
        public string getDescription()
        {
            return description;
        }

        public string getQuantityType()
        {
            return quantitytype;
        }

        public void printIngredient()
        {
            //      private int id = 0;
            //private string name = "Ingredient name failed c#";
            //public string description = "Description failed c#";
            //private string quantitytype = "QuantityType failed at c#";
            Console.Write("ID: " + id + " Name: " + name + " Description: " + description + " Quantity Type " + quantitytype + "\n");
        }
    }
}
