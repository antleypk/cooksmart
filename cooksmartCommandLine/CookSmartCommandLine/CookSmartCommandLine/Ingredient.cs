﻿using System;
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
        private int userid;
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
            //      private int id = 0;
            //private string name = "Ingredient name failed c#";
            //public string description = "Description failed c#";
            //private string quantitytype = "QuantityType failed at c#";
            Console.Write("ID: " + id + " \n Name: " + name + " \n Description: " + description + "\n Quantity " + quantity + "\n Quantity Type " + quantitytype + "\n");
        }
    }
}
