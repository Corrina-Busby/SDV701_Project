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
        #region >)))O>  DESIGNER methods

        internal async static Task<List<string>> GetDesignersNamesAsync()
        { // GET
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/simplyFashion/GetDesignersNames"));
        }
    
        internal static async Task<clsDesigners> GetDesignerAsync(string prDesignerName)
        { // GET
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsDesigners>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/simplyFashion/GetDesigners?Name=" + prDesignerName));
        }
        #endregion

        #region >)))O>  ITEM methods

        internal async static Task<List<clsAllItems>> GetDesignerItemsAsync(string prDesigner)
        { // GET
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsAllItems>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/simplyFashion/GetDesignerItems?Designer=" + prDesigner));
        }

        internal async static Task<string> PostItemAsync(clsAllItems prItem)
        { // POST
            return await InsertOrUpdateAsync(prItem, "http://localhost:60064/api/simplyFashion/PostItem", "POST");
        }

        internal async static Task<string> PutItemAsync(clsAllItems prItem)
        { // PUT
            return await InsertOrUpdateAsync(prItem, "http://localhost:60064/api/simplyFashion/PutItem", "PUT");
        }

        internal async static Task<string> DeleteItem(string lcKey)
        { // DELETE
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
                ($"http://localhost:60064/api/simplyFashion/DeleteItem?skuCode={lcKey}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }
        #endregion

        #region >)))O>  QUANTITY UPDATE Item method

        internal async static Task<string> PutQuantityAsync(clsAllItems prItem)
        { //PUT
            return await InsertOrUpdateAsync(prItem, "http://localhost:60064/api/simplyFashion/PutQuantity", "PUT");
        }
        #endregion

        #region >)))O>  Order methods

        internal async static Task<List<clsAllOrders>> GetOrderAsync()
        { // GET
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsAllOrders>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/simplyFashion/GetOrder"));
        }

        internal async static Task<string> PostOrderAsync(clsAllOrders prOrder)
        { // POST
                return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/simplyFashion/PostOrder", "POST");
        }

        internal async static Task<string> DeleteOrder(string lcKey)
        { // DELETE
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
                ($"http://localhost:60064/api/simplyFashion/DeleteOrder?invoice={lcKey}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }
        #endregion

        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content = new StringContent(JsonConvert.SerializeObject(prItem), Encoding.UTF8, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }
    }
}
