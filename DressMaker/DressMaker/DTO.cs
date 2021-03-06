﻿using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimplyFashionAdmin
{
    
    /// <summary>
    /// Info for Designer
    /// </summary>
    public class clsDesigners
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public List<clsAllItems> ItemList { get; set; }
  
        //public decimal TotalValue { get {return  } }
    }

    /// <summary>
    /// Info for all Items of clothing being sold
    /// </summary>
    public class clsAllItems
    {
        // PK
        public string SkuCode { get; set; }
        public string ItemName { get; set; }
        public string ItemDetails { get; set; }
        public decimal BuyPrice { get; set; }
        public DateTime LastModified { get; set; }
        public int QtyInStock { get; set; }
        public string Introduced { get; set; } // for new: year or season introduced w/e its a string
        public string State { get; set; } // for used: bad fair good
        public char Type { get; set; } // new or used
        // Foreign Key
        public string Designer { get; set; }

        // taken from lastyears sdv6 car rentals app
        public override string ToString()
        {
            return string.Format("{0, -20}", SkuCode) +
                   string.Format("{0, -20}", ItemName) +
                   string.Format("{0, -30}", LastModified.ToString()) +
                   string.Format("{0, -20}", Type) +
                   string.Format("{0, -20}", QtyInStock.ToString()) +
                   string.Format("{0, -20}", BuyPrice);
        }

        public static readonly string FACTORY_PROMPT = "Enter U for Used Item" + "\n" + "N for New Item";

        public static clsAllItems NewDesignerItem(char prChoice)
        {
            return new clsAllItems() { Type = Char.ToUpper(prChoice)};
        }
        //public List<clsAllOrders> OrderList { get; set; }

    }
    /// <summary>
    /// Info for all orders 
    /// </summary> 
    public class clsAllOrders
    {
        public int Invoice { get; set; }
        // Foreign Key
        public string SkuCode { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Invoice.ToString() + "\t" + SkuCode + "\t" + Date.ToShortDateString() + "\t" + CustomerName + "\t\t" + Email + "\t\t" + Quantity.ToString() + "\t\t" + Price;
        }
    }

}

