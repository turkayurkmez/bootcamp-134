using System;
using System.Collections.Generic;
using System.Linq;

namespace usingDelegate
{
    class Program
    {
        static List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        static void Main(string[] args)
        {
            /*
             * yukarıdaki numbers isimli array içindeki sayıları programcının dilediği gibi filtrelemesini istiyoruz
             */
            //.NET 1.0
            var filtered = Filters.Filter(numbers, isMultiply3);

            //.NET 2.0:
            var filtered2 = Filters.Filter(numbers, delegate (int c) { return c < 5; });
            //.NET 3.5:
            var filtered3 = Filters.Filter(numbers, c => c % 5 == 0);

            //foreach (var item in filtered2)
            //{
            //    Console.WriteLine(item);
            //}

            filtered3.ForEach(p =>
            {
                Console.WriteLine(p);
            });

            filtered3.Where(x => x % 2 == 0);
        }

        static bool isEven(int item)
        {
            return item % 2 == 0;
        }

        static bool isMultiply3(int item)
        {
            return item % 3 == 0;
        }
    }
}
