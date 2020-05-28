using SimplyFashionAdmin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFashionApi
{
    public class SimplyFashionController : System.Web.Http.ApiController
    {
        #region >}}}o> API requests ALL designer names
        public List<string> GetDesignerNames()
        {
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
        public clsDesigners GetDesigner(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Name", Name);
            DataTable lcResult =
            clsDbConnection.GetDataTable("SELECT * FROM designer WHERE Name = @name", par);
            if (lcResult.Rows.Count > 0)
                return new clsDesigners()
                {
                    Name = (string)lcResult.Rows[0]["Name"],
                    Phone = (string)lcResult.Rows[0]["Phone"]
                };
            else
                return null;
        }
        #endregion
    }
}
