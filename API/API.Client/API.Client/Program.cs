using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Collections.Generic;

namespace API.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var respnse = await client.GetAsync("https://localhost:7287/api/products");
            if (respnse.IsSuccessStatusCode)
            {
                var products = await respnse.Content.ReadFromJsonAsync<List<Product>>();

            }
        }

        //static void GetDataWithHttpClient
    }

    public class Product
    {
        public int Id { get; set; }
     
        public string Name { get; set; }
       
        public double? Price { get; set; }
        public int? Stock { get; set; }
        public string? Description { get; set; }
        public double? Discount { get; set; }
        public string? ImageUrl { get; set; }
    }
}
