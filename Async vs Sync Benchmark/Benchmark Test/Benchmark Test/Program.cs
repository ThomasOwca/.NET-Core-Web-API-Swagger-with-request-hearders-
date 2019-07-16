using PizzeriaData.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Benchmark_Test
{
    static class Program
    {
        static HttpClient client;
        static Stopwatch stopWatch;

        static Program()
        {
            client = new HttpClient();
            stopWatch = new Stopwatch();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Testing");
            RunBenchmark().Wait();
        }

        static async Task RunBenchmark()
        {
            long asyncExec = await GetOrdersAsync();
            long syncExec = await GetOrdersSync();


            Console.WriteLine($"Async Execution Time (ms): {asyncExec}");
            Console.WriteLine($"Sync Execution Time (ms): {syncExec}");
        }

        static async Task<long> GetOrdersAsync()
        {
            stopWatch.Start();

            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44307/api/orders/async");
                if (response.IsSuccessStatusCode)
                {
                    var orders = await response.Content.ReadAsAsync<List<Order>>();
                    Console.WriteLine($"Max total found in list : ${orders.Max(order => order.Total)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }

        static async Task<long> GetOrdersSync()
        {
            stopWatch.Start();

            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44307/api/orders/sync");
                if (response.IsSuccessStatusCode)
                {
                    var orders = await response.Content.ReadAsAsync<List<Order>>();
                    Console.WriteLine($"Max total found in list : ${orders.Max(order => order.Total)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }

        static async Task<long> GetOrdersAndPizzaAsync()
        {
            stopWatch.Start();

            List<Task<HttpResponseMessage>> tasks = new List<Task<HttpResponseMessage>>();

            try
            {
                tasks.Add(client.GetAsync("https://localhost:44307/api/orders/async"));
                tasks.Add(client.GetAsync("https://localhost:44307/api/orders/async"));

                var responses = await Task.WhenAll(tasks);


                if (responses[0].IsSuccessStatusCode)
                {
                    var orders = await responses[0].Content.ReadAsAsync<List<Order>>();
                    Console.WriteLine($"Max total found in list : ${orders.Max(order => order.Total)}");
                }

                if (responses[1].IsSuccessStatusCode)
                {
                    var orders = await responses[0].Content.ReadAsAsync<List<Order>>();
                    Console.WriteLine($"Min total found in list : ${orders.Min(order => order.Total)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }

        static async Task<long> GetOrdersAndPizzaSync()
        {
            stopWatch.Start();

            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44307/api/orders/sync");
                if (response.IsSuccessStatusCode)
                {
                    var orders = await response.Content.ReadAsAsync<List<Order>>();
                    Console.WriteLine($"Max total found in list : ${orders.Max(order => order.Total)}");
                }

                HttpResponseMessage response2 = await client.GetAsync("https://localhost:44307/api/orders/sync");
                if (response.IsSuccessStatusCode)
                {
                    var orders = await response2.Content.ReadAsAsync<List<Order>>();
                    Console.WriteLine($"Min total found in list : ${orders.Min(order => order.Total)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }
    }
}
