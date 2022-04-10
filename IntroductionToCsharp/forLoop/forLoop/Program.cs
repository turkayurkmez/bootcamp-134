using System;

namespace forLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] courses =  { "Matematik", "C#", "Html", "Css", "JavaScript","Sql" };


            for (int i = 0; i < courses.Length; i++)
            {
                Console.WriteLine(courses[i]);
            }

            int[] ages = { 42, 29, 26, 29, 29, 23 };
            int ageTotal = 0;
            for (int age = 0; age < ages.Length; age++)
            {
                ageTotal += ages[age];
            }

            int average = ageTotal / ages.Length;

            Console.WriteLine($"Yaş ortalaması:{average}");

            int[] numbers = { 36, 12, 26, 9, -4, 22, 8 };

            int minNumber = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (minNumber > numbers[i])
                {
                    minNumber = numbers[i];
                }
            }

            Console.WriteLine($"En küçük sayı:{minNumber}");

        }
    }
}
