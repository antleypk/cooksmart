using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmartCommandLine
{
    public class Kitchen
    {
        string title = "C# Name Fail kitchen";
        string description = "C# Description fail kitchen";
        decimal quantity = -1;
        string quantitytype = "C# QuantityType fail kitech";
        DateTime putonshelf;
        int userid = 0;
    public Kitchen()
            {
      
            }
    public Kitchen(string Title, string Description, decimal TotalQuantity, string QuantityType, DateTime PutOnShelf, int userID)
        {
            title = Title;
            description = Description;
            quantity = TotalQuantity;
            quantitytype = QuantityType;
            putonshelf = PutOnShelf;
            userid = userID;
        }

        public int getuserID()
        {
            return userid;
        }

        public void setuserid(int newuserid)
        {
            userid = newuserid;
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
        public decimal getTotalQuantity()
        {
            return quantity;
        }
        public void setTotalQuantity(decimal newquantity)
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
            Console.Write(" \n Name: " + title + " \n Description: " + description + "\n TotalQuantity: " + quantity + "\n quantitytype " + quantitytype + " \n PutOnShelf " + putonshelf + "\n ");
        }
    }
}
