using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Parser.src.Util
{
    public class HttpUtil
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetDataFromUrlAsync(string url)
        {
            string content = "";

            try
            {
                content = await client.GetStringAsync(url);
            }
            catch (Exception e)
            { 
                return "Error executing request to " + url + "\n" + e.Message;
            }
            return content;
        }

    }
}