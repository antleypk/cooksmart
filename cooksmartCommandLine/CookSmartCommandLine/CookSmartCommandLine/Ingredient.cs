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
        private decimal quantity;
        //blank constructor
        public Ingredient()
        {

        }

        public decimal getQuantity()
        {
            return quantity;
        }

        public void setQuantity(decimal newQuantity)
        {
            quantity = newQuantity;
        }

        public Ingredient(int IngredientID, string Title,string Description, int Quantity, string QuantityType)
        {
            id = IngredientID;
            name = Title;
            description = Description;
            quantity = Quantity;
            quantitytype = QuantityType;

        }
        public Ingredient(int IngredientID, string Title, string Description, string QuantityType)
        {
            id = IngredientID;
            name = Title;
            description = Description;
           // quantity = Quantity;
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

        public void setName(string newName)
        {
            name = newName;
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
            Console.Write("ID: " + id + " \n Name: " + name + " \n Description: " + description + "\n Quantity " + quantity + "\n Quantity Type " + quantitytype + "\n");
        }
    }
}
