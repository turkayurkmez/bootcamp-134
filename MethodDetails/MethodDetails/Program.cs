using System;

namespace MethodDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = divide(12, 3);
            int outputValue = 0;
            int result2 = divide(15, 2, out outputValue);
            Console.WriteLine($"Bölüm: {result2}, kalan:{outputValue}");
            int number = 8;
            sample(ref number);
            Console.WriteLine($"main metodundaki number değeri: {number}");

            sum("test",14, 7, 15, 0, 23, 5, 9,15);
        }

        static int divide(int a, int b)
        {
            return a / b;
        }

        static int divide(int a, int b, out int modulo)
        {
            modulo = a % b;
            return a / b;

        }

        static void sample(ref int parameter)
        {
            parameter *= 3;
            Console.WriteLine(parameter);
        }

        static int sum(string info,params int[] numbers)
        {
            int total = 0;
            foreach (var item in numbers)
            {
                total += item;
            }
            return total;
        }


    }
}
