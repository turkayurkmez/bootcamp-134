using System;
using System.Collections.Generic;

namespace forEachLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> products = new List<string>();
            products.Add("Samsung A51");
            products.Add("Xiaomi");
            products.Add("Oppo");
            products.Add("IPhone");
            products.Add("IBilmemne");

            List<string> storage = new List<string>();



            foreach (string product in products)
            {
                Console.WriteLine(product);
                if (product.StartsWith("I"))
                {
                  
                    storage.Add(product);
                    //products.Remove(product);
                }

            }

            foreach (string item in storage)
            {
                products.Remove(item);
            }
            Console.WriteLine("Son hali:");
            Console.WriteLine();
            Console.WriteLine("--------------------");
            foreach (string product in products)
            {
                Console.WriteLine(product);
            }






        }
    }
}
