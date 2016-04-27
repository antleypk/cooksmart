using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
    public class Kitchen
    {
        string title = "C# Name Fail";
        string description = "C# Description fail";
        int quantity = -1;
        string quantitytype = "C# QuantityType fail";
        DateTime putonshelf = new DateTime(2000,01,01);
    public Kitchen()
            {
      
            }
    public Kitchen(string Title, string Description, int Quantity, string QuantityType, DateTime PutOnShelf)
        {
            title = Title;
            description = Description;
            quantity = Quantity;
            quantitytype = QuantityType;
            putonshelf = PutOnShelf;
        }



        public string getTitle()
        {
            return title;
        }
        public void setTitle(string newtitle)
        {
            title = newtitle;
        }
        public string getDescription()
        {
            return description;
        }
        public void setDescription(string newdescription)
        {
            description = newdescription;
        }
        public int getQuantity()
        {
            return quantity;
        }
        public void setQuantity(int newquantity)
        {
            quantity = newquantity;
        }
        public string getQuantityType()
        {
            return quantitytype;
        }
        public void setQuantityType(string newquantitytype)
        {
            quantitytype = newquantitytype;
        }
        public DateTime getPutOnShelf()
        {
            return putonshelf;
        }
        public void setPutOnShelf(DateTime newputonshelf)
        {
            putonshelf = newputonshelf;
        }
        public void printKitchen()
        {
            Console.Write(" \n Name: " + title + " \n Description: " + description + "\n Quantity: " + quantity + "\n quantitytype " + quantitytype + " \n PutOnShelf " + putonshelf + "\n ");
        }
    }
}
