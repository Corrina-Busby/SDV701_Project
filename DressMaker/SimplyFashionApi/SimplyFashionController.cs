using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding.Binders;

namespace SimplyFashionApi
{
    public class SimplyFashionController : System.Web.Http.ApiController
    {
        //.////////////////./
        ///// Designers /////
        //.////////////////./

        #region >}}}o> API requests ALL designers names

        public List<string> GetDesignersNames()
        { // GET
            DataTable lcResult = clsDbConnection.GetDataTable(
                "SELECT name FROM designer", 
                null);
            
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

        #endregion

        #region >}}}*> API requests ONE Designers details

        public clsDesigners GetDesigners(string Name)
        { // GET
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("name", Name);
            DataTable lcResult =
            clsDbConnection.GetDataTable(
                "SELECT * " + 
                "FROM designer " + 
                "WHERE name = @name", 
                par);

            if (lcResult.Rows.Count > 0)
                return new clsDesigners()
                {
                    Name = (string)lcResult.Rows[0]["name"],
                    Phone = (string)lcResult.Rows[0]["phone"], 
                   // ItemList = GetDesignerItems(Name)
                };
            else
                return null;
        }

        #endregion

        //.////////////./
        ///// Items /////
        //.////////////./
  
        #region >>}}}*> GET a Designers DESIGNER item

        public List<string> GetDesignerItemNames(string Designer)
        { // GET
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("designer", Designer);
            DataTable lcResult = clsDbConnection.GetDataTable(
                "SELECT itemName " +
                "FROM item " +
                "WHERE designer = @designer", par);
            List<string> lcNames = new List<string>();

            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

        #endregion

        #region >>)))0> Get all Designers DESIGNER item(s) related to that designer i.e. Gucci

        public List<clsAllItems> GetDesignerItems(string Designer)
        { // GET
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("designer", Designer);
            DataTable lcResult = clsDbConnection.GetDataTable(
                "SELECT * " + 
                "FROM item " +
                "WHERE designer = @designer", 
                par);
            List<clsAllItems> lcItemList = new List<clsAllItems>();

            foreach (DataRow dr in lcResult.Rows)
                lcItemList.Add(dataRow2AllItem(dr));
            return lcItemList;
        }

        // Convert DataRow to object
        private clsAllItems dataRow2AllItem(DataRow prDataRow)
        {
            return new clsAllItems()
            {
                SkuCode = Convert.ToString(prDataRow["skuCode"]),
                ItemName = Convert.ToString(prDataRow["itemName"]),
                ItemDetails = Convert.ToString(prDataRow["itemDetails"]),
                BuyPrice = Convert.ToDecimal(prDataRow["buyPrice"]),
                LastModified = Convert.ToString(prDataRow["lastModified"]),
                QtyInStock = Convert.ToInt32(prDataRow["qtyInStock"]),
                Introduced = Convert.ToString(prDataRow["introduced"]),
                State = Convert.ToString(prDataRow["state"]),
                Type = Convert.ToString(prDataRow["type"]),
                Designer = Convert.ToString(prDataRow["Designer"])

            };
        }

        #endregion

        #region >>)))0> Get ONE item 

        public List<clsAllItems> GetItem(string prSkuCode)
        { // GET
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("skuCode", prSkuCode);
            DataTable lcResult = clsDbConnection.GetDataTable(
                "SELECT * " +
                "FROM item " +
                "WHERE skuCode = @skuCode",
                par);
            List<clsAllItems> lcItemList = new List<clsAllItems>();

            foreach (DataRow dr in lcResult.Rows)
                lcItemList.Add(dataRow2Item(dr));
            return lcItemList;
        }

        // Convert DataRow to object
        private clsAllItems dataRow2Item(DataRow prDataRow)
        { 
            return new clsAllItems()
            {
                SkuCode = Convert.ToString(prDataRow["skuCode"]),
                ItemName = Convert.ToString(prDataRow["itemName"]),
                ItemDetails = Convert.ToString(prDataRow["itemDetails"]),
                BuyPrice = Convert.ToDecimal(prDataRow["buyPrice"]),
                LastModified = Convert.ToString(prDataRow["lastModified"]),
                QtyInStock = Convert.ToInt32(prDataRow["qtyInStock"]),
                Introduced = Convert.ToString(prDataRow["introduced"]),
                State = Convert.ToString(prDataRow["state"]),
                Type = Convert.ToString(prDataRow["type"]),
                Designer = Convert.ToString(prDataRow["Designer"])

            };
        }

        #endregion

        #region >>}}}0> INSERTS designer ITEM with the POST protocol 

        // `condition` now exhanged to state due to MySql workbench issues!!!

        public string PostItem(clsAllItems prItem)
        {   // POST
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                    "INSERT INTO item (skuCode, itemName, itemDetails, buyPrice, lastModified, qtyInStock, introduced, state, type, designer) " +
                    "VALUES (@skuCode, @itemName, @itemDetails, @buyPrice, @lastModified, @qtyInStock, @introduced, @state, @type, @designer)",
                    prepareItemParameters(prItem));
                if (lcRecCount == 1)
                    return "One Designer Item Added";
                else
                    return "Unexpected designer item insert count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return "001 " + ex.GetBaseException().Message;
            }
        }
        #endregion

        #region >>)))*> PREPARE ITEM PARAMETERS

        private Dictionary<string, object> prepareItemParameters(clsAllItems prItem)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(10);
            par.Add("skuCode", prItem.SkuCode);
            par.Add("itemName", prItem.ItemName);
            par.Add("itemDetails", prItem.ItemDetails);
            par.Add("buyPrice", prItem.BuyPrice);
            par.Add("lastModified", prItem.LastModified);
            par.Add("qtyInStock", prItem.QtyInStock);
            par.Add("introduced", prItem.Introduced);
            par.Add("state", prItem.State);
            par.Add("type", prItem.Type);
            par.Add("designer", prItem.Designer);
            return par;
        }
        #endregion

        #region >>}}}o> UPDATE an ITEM using the PUT protocol 
        public string PutItem(clsAllItems prItem)
        {   // UPDATE
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                    "UPDATE item " +
                    "SET itemName = @itemName, itemDetails = @itemDetails," +
                    "buyPrice = @buyPrice, lastModified = @lastModified, qtyInStock = @qtyInStock," +
                    "introduced = @introduced, state = @state, type = @type, designer = @designer " +
                    "WHERE skuCode = @skuCode",
                    prepareItemParameters(prItem));
                if (lcRecCount == 1)
                    return "One artwork added";
                else
                    return "Unexpected artwork update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }
        #endregion

        #region >>}}}*> UPDATE Quantity using the PUT protocol
        public string PutQuantity(clsAllItems prItem)
        {   // UPDATE
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                    "UPDATE item " +
                    "SET qtyInStock = @qtyInStock " +                    
                    "WHERE skuCode = @skuCode",
                    prepareItemParameters(prItem));
                if (lcRecCount == 1)
                    return "One Quantity added";
                else
                    return "Unexpected Quantity update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }
        #endregion

        #region >>)))*> DELETE ITEM using DELETE Protocol

        public string DeleteItem(string SkuCode)
        {   // Delete
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                   "DELETE FROM item WHERE skuCode = @skuCode",
                    prepareDeleteItemParameters(SkuCode));
                if (lcRecCount == 1)
                    return "One Item Deleted";
                else
                    return "Unexpected Item Delete Count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }
        #endregion

        #region >>)))*> PREPARE DELETE ITEM PARAMETERS

        private Dictionary<string, object> prepareDeleteItemParameters(string prSkuCode)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("skuCode", prSkuCode);
            return par;
        }
        #endregion

        //./////////////./
        ///// Orders /////
        //./////////////./

        #region >>}}}0> GET all Orders from the customers

        public List<clsAllOrders> GetOrder()
        { // GET
            DataTable lcResult = clsDbConnection.GetDataTable(
                "SELECT * " +
                "FROM pendingOrder ", null);
            List<clsAllOrders> lcOrderList = new List<clsAllOrders>();

            foreach (DataRow dr in lcResult.Rows)
                lcOrderList.Add(dataRow2AllOrders(dr));
            return lcOrderList;
        }

        // Convert DataRow to object
        private clsAllOrders dataRow2AllOrders(DataRow prDataRow)
        {
            return new clsAllOrders()
            {
                Invoice = Convert.ToInt32(prDataRow["invoice"]),
                SkuCode = Convert.ToString(prDataRow["skuCode"]),
                Date = Convert.ToDateTime(prDataRow["date"]),
                Quantity = Convert.ToInt32(prDataRow["qty"]),
                Price = Convert.ToDecimal(prDataRow["price"]),
                CustomerName = Convert.ToString(prDataRow["customerName"]),
                Email = Convert.ToString(prDataRow["email"])
            };
        }

        #endregion

        #region >>)))o> POST Orders

        public string PostOrder(clsAllOrders prOrder)
        {   // POST
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                        "INSERT INTO pendingOrder (skuCode, date, qty, price, customerName, email) " +
                        "VALUES (@skuCode, @date, @qty, @price, @customerName, @email)",
                        prepareOrderParameters(prOrder));

                if (lcRecCount == 1)
                    return "One Order Added";
                else
                    return "Unexpected order update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }
        #endregion

        #region >>)))*> PREPARE ORDER PARAMETERS

        private Dictionary<string, object> prepareOrderParameters(clsAllOrders prOrder)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(7);
            par.Add("invoice", prOrder.Invoice);
            par.Add("skuCode", prOrder.SkuCode);
            par.Add("date", prOrder.Date);
            par.Add("qty", prOrder.Quantity);
            par.Add("price", prOrder.Price);
            par.Add("customerName", prOrder.CustomerName);
            par.Add("email", prOrder.Email);
            return par;
        }

        #endregion

        #region >)))0> Delete an Order from the pending order table

        public string DeleteOrder(string Invoice)
        {   // Delete
            try
            {
                int lcRecCount = clsDbConnection.Execute(
                   "DELETE FROM pendingOrder WHERE invoice = @invoice",
                    prepareDeleteOrderParameters(Invoice));
                if (lcRecCount == 1)
                    return "One Order Item Deleted";
                else
                    return "Unexpected Order Item Delete Count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }
        #endregion

        #region >>)))*> PREPARE DELETE ORDER PARAMETERS

        private Dictionary<string, object> prepareDeleteOrderParameters(string prInvoice)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("invoice", prInvoice);
            return par;
        }
        #endregion
    }
}
