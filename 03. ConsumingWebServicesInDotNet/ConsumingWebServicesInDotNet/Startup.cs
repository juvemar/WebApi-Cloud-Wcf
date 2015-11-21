namespace ConsumingWebServicesInDotNet
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class Startup
    {
        public static void Main()
        {
            string query = "quis";
            int count = 5;

            SearchForArticles(count, query);
        }

        private static void SearchForArticles(int count, string query)
        {
            using (HttpClient client = new HttpClient())
            {
                string uri = "http://jsonplaceholder.typicode.com/photos";

                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage message = client.GetAsync("").Result;

                if (message.IsSuccessStatusCode)
                {
                    var articles = message.Content.ReadAsStringAsync().Result;
                    var collection = JsonConvert.DeserializeObject<List<Article>>(articles);

                    collection
                        .Where(a => a.Title.Contains(query))
                        .Take(count)
                        .ToList()
                        .ForEach(a => Console.WriteLine("{0} - {1}", a.Title, a.Url));
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)message.StatusCode, message.ReasonPhrase);
                }
            }
        }
    }
}
