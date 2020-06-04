using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFashionApi
{
    /// <summary>
    /// Info for Designer
    /// </summary>
    public class clsDesigners
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        
        public List<clsAllItems> ItemList { get; set; }
    }
    /// <summary>
    /// Info for all Items of clothing being sold
    /// </summary>
    public class clsAllItems
    {
        public string SkuCode  { get; set; } 
        public string ItemName { get; set; }
        public string ItemDetails { get; set; }
        public decimal BuyPrice { get; set; }
        public string LastModified { get; set; }
        public int QtyInStock { get; set; }
        public string Introduced { get; set; }
        public string State { get; set; }
        public char Type { get; set; }
        // Foreign Key
        public string Designer { get; set; }

        //public List<clsAllOrders> OrderList { get; set; }
    }
    /// <summary>
    /// Info for all orders of clothing being sold for Designer
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
    }
}
