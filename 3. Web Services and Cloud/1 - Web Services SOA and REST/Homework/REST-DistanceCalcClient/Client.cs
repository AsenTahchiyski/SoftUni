using System;
using System.Net.Http;
using System.Threading;

namespace REST_DistanceCalcClient
{
    class Client
    {
        static void Main()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:3968/api/points");
            var query = "?x1=5&y1=5&x2=10&y2=10";
            PrintDistanceAsync(httpClient, query);
            Thread.Sleep(1000);
        }

        private async static void PrintDistanceAsync(HttpClient client, string query)
        {
            var response = await client.GetAsync(query);
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
    }
}
