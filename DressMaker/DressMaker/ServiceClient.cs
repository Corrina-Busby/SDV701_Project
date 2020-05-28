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
    public static class ServiceClient
    {  // >>}}}0> Designer GET requests
        internal async static Task<List<string>> GetDesignerNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/simplyFashion/GetDesignersNames"));
        }
    }
}
 