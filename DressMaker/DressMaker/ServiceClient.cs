using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_Admin
{
    public static class ServiceClient
    {
       // #region >>}}}0> Designer GET requests
        internal async static Task<List<string>> GetDesignerNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserilizeObject<List<string>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/simplyFashion/GetDesignersNames"));
        }
    }
}
