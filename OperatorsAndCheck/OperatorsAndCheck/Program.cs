using System;

namespace OperatorsAndCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = ((3 * 5)+9)/2;
            string newWord = "Bootcamp" + 134;
            Console.WriteLine(newWord);
            Console.WriteLine(x.ToString());

            byte bigNumber = 254;
            byte smallNumber = 3;


            try
            {
                checked
                {
                    byte total = (byte)(bigNumber + smallNumber);
                    Console.WriteLine(total);
                }
            }
            catch (System.OverflowException ex)
            {

                Console.WriteLine("Total value cannot cast to byte data type");
            }

            Console.WriteLine("Number 1 is:");
           

            try
            {
                int number1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Number 2 is:");
                int number2 = Convert.ToInt32(Console.ReadLine());
                int division = number1 / number2;
                Console.WriteLine($"Result {division} " );
            }
            catch (FormatException)
            {

                Console.WriteLine("Please just give digits");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Number 2 cannot be 0");
            }



        }
    }
}
