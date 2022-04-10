using System;

namespace AndOrCondition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Month name:");
            string monthName = Console.ReadLine();
            if (monthName == "December" || monthName =="January" || monthName == "February" )
            {
                Console.WriteLine("Winter");
            }
            else if (monthName =="March" || monthName=="April" || monthName =="May")
            {
                Console.WriteLine("Spring");
            }

            DateTime today = DateTime.Now;

            if (today.Month == 3 && today.Day == 21)
            {
                Console.WriteLine("Ufuk's Birthdate!!");
            }
        }
    }
}
