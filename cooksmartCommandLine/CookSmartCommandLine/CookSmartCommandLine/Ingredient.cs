using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
   public class Ingredient
    {
        private int id=897897897;
        private string name = "Ingredient name failed c#";
        public string description = "Description failed c#";
        private string quantitytype = "QuantityType failed at c#";
        private decimal quantity; // for example quantity type for eggs would be 1 egg
        private int userid;
       
        public Ingredient()
        {
            //blank constructor
        }

        public decimal getQuantity()
        {
            return quantity;
        }

        public void setQuantity(decimal newQuantity)
        {
            quantity = newQuantity;
        }

        public Ingredient(int IngredientID, string Title,string Description, int Quantity, string QuantityType,int userID)
        {
            id = IngredientID;
            name = Title;
            description = Description;
            quantity = Quantity;
            quantitytype = QuantityType;
            userid = userID;

        }
        public int getUserID()
        {
            return userid;
        }
        public void setUserID(int newuserid)
        {
            userid = newuserid;
        }

        public Ingredient(int IngredientID, string Title, string Description, string QuantityType, int userID)
        {
            id = IngredientID;
            name = Title;
            description = Description;
           // quantity = Quantity;
            quantitytype = QuantityType;
            userid = userID;

        }
        public int getId()
        {
            return id;
        }
        public void setId(int newid)
        {
            id = newid;
        }
        public string getName()
        {
            return name;
        }
        public string getDescription()
        {
            return description;
        }
        public void setDescription(string newdescription)
        {
            description = newdescription;
        }
        public void setName(string newName)
        {
            name = newName;
        }
        public Ingredient(int userID)
        {
            Console.WriteLine("Input Ingredient Name");
            string IngName = Console.ReadLine();
            Console.WriteLine("Input Ingredient Description");
            string IngDesc = Console.ReadLine();
            Console.WriteLine("Input Ingredient Quantity Type");
            string IngType = Console.ReadLine();
      //    int IngCount = 0;
         // Ingredient newing = new Ingredient(IngCount, IngName, IngDesc, IngType, userid);
            id = 897897897;
            name = IngName;
            description = IngDesc;
            quantitytype = IngType;
            userid=userID;
    }

    public string getQuantityType()
        {
            return quantitytype;
        }
        public void setQuantityType(string newquantitytype)
        {
            quantitytype = newquantitytype;
        }

        public void printIngredient()
        {

            //   Console.Write("ID: " + id + " \n Name: " + name + " \n Description: " + description + "\n Quantity " + quantity + "\n Quantity Type " + quantitytype + "\n");
            Console.WriteLine(id + " " + name + " " + description + " " +quantity+" "+ quantitytype);
        }
    }
}
