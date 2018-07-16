using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopify.Helpers
{
    public class Requests
    {
        public async static Task<HttpResponseMessage> Post(string endpoint, HttpContent content, string apikey = null, string password = null)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(
                    System.Text.ASCIIEncoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", apikey, password))));

            var response = await client.PostAsync(endpoint, content);
            
            client.Dispose();
            return response;
        }

        public async static Task<HttpResponseMessage> Get(string endpoint, string apikey = null, string password = null)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(
                    System.Text.ASCIIEncoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", apikey, password))));

             var response = await client.GetAsync(endpoint);

            client.Dispose();

            return response;
        }
    }
}
