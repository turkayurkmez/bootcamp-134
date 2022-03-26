using System;
using System.Collections.Generic;

namespace BuiltInMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bir kelime giriniz");

            string word = Console.ReadLine();

            //int index = word.IndexOf('i', 5);
            int startIndex = 0;
            Console.WriteLine("Aradığınız harf:");
            string charackter = Console.ReadLine();

            Console.Write($"{charackter} harfinin index değerleri:");

            while (word.IndexOf(charackter, startIndex) != -1)
            {
                int findingIndex = word.IndexOf(charackter, startIndex);
                Console.Write($"{findingIndex}, ");
                startIndex = findingIndex + 1;

            }
            //Console.WriteLine(index);

            //Başka bir örnek....
            List<string> emails = new List<string>()
            {
                "turkay.urkmez@dinamikzihin.com",
                "kirikkalp72@gmail.com",
                "nur.bilge@microsoft.com",
                "turkay.urkmez@gmail.com",
                "babyboy@mynet.com"
            };


        }
    }
}
