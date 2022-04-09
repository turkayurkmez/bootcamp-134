using System;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Product kolye = new Product();
            try
            {
                kolye.SetPrice(-15);
            }
            catch (Exception x)
            {

                Console.WriteLine(x.Message);
            }
            Console.WriteLine(kolye.GetPrice());

            kolye.Name = "Art 1";
            kolye.StockCount = 1000;
          
                
        }
    }
}
