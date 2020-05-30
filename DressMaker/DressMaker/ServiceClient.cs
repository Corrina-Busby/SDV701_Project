using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Using a DTO to tranfer data from the client back to the Server 
/// </summary>
/// 
namespace SimplyFashionAdmin
{
    class ServiceClient
    {
        #region >)))O>  Designer methods 
        // >>}}}0>  GET Designer names from MySQL database

        internal async static Task<List<string>> GetDesignerNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/simplyFashion/GetDesignersNames"));
        }

    
        internal static async Task<clsDesigners> GetDesignerAsync(string prDesignerName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsDesigners>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/simplyFashion/GetDesigners?Name=" + prDesignerName));
        }
        #endregion

        #region >)))O>  Item methods
        // >>)))*> GET Items from MySQL database

        internal async static Task<List<clsAllItems>> GetDesignerItemNamesAsync(string prDesigner)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsAllItems>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/simplyFashion/GetDesignerItemNames?Designer=" + prDesigner));
        }
        #endregion

        #region >)))O>  Order methods
        // >>)))*> GET Orders from MySQL database

        internal async static Task<List<clsAllOrders>> GetOrderAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsAllOrders>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/simplyFashion/GetOrder"));
        }

        #endregion
    }

}
