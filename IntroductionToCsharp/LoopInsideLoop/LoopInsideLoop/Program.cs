using System;

namespace LoopInsideLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * çarpım tablosu...
             * 2 x 1 =2
             * 2 x 2 =4
             * 2 x 9 = 18
             * 
             * 3 x 1 = 3
             */

            for (int i = 2; i <= 9; i++)
            {
                for (int y = 1; y <= 9; y++)
                {
                    Console.WriteLine($"{i} x {y} = {i * y}");

                }
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
