using System;
using System.Collections.Generic;
using System.Linq;

namespace MethodsAndFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            //...
            //....
            //Console.WriteLine(args[0]);
            showOutput("Kodluyoruz bootcamp çok iyi :)");
            int[] numbers = { 12, 9, 25, 36, 0, 22 };
            int average = getAverage(numbers.ToList());

            showOutput($"Ortalama sayı: {average}");

            //if (isPrime(13))
            //{
            //    Console.WriteLine("13 sayısı asaldır");
            //}

            primeNumbersOnValue(10000);

            List<int> first6Numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> small1 = new List<int> { 1, 2, 3 };
            List<int> small2 = new List<int> { 7, 8, 9 };

            bool result1 = isSubCollection(first6Numbers, small1);

            bool result2 = isSubCollection(first6Numbers, small2);

            Console.WriteLine(result1);
            Console.WriteLine(result2);






        }

        static void showOutput(string message)
        {
            Console.WriteLine(message);
        }

        static int getAverage(List<int> numbers)
        {
            int total = 0;
            foreach (var number in numbers)
            {
                total += number;
            }
            return total / numbers.Count;
        }

        static bool isPrime(int number)
        {
            bool isPrimeValue = true;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    isPrimeValue = false;
                    break;
                }
            }

            return isPrimeValue;


        }

        static void primeNumbersOnValue(int value)
        {
            for (int i = 0; i < value; i++)
            {
                if (isPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static int IndexOf(string word, char letter)
        {
            int returnValue = -1;
            for (int index = 0; index < word.Length; index++)
            {
                if (word[index] == letter)
                {
                    returnValue = index;
                }
            }

            return returnValue;
        }
        static int IndexOf(string word, string anotherWord)
        {
            return 0;
        }

        static bool isSubCollection(List<int> main, List<int> small)
        {
            /*
             * main: 2,4,6,8
             * small: 6,7,8
             * 
             */
            bool isOk = true;
            foreach (var number in small)
            {
                if (!main.Contains(number))
                {
                    isOk = false;
                    break;
                }
            }

            return isOk;
        }







    }
}
