using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCoreConsole
{
    public class Util
    {
        public static async Task<string> GetData(int index)
        {
            string url = "http://decode16dataapi.azurewebsites.net/data" + index.ToString() + ".txt";
            var client = new System.Net.Http.HttpClient();
            return await client.GetStringAsync(url);
        }
        public static string GetDataPre(int index)
        {
            Task<string> dt = Util.GetData(index);
            dt.Wait();
            return "<pre>" + dt.Result.Replace("\r\n", "<br />") + "</pre>";
        }
    }
}
