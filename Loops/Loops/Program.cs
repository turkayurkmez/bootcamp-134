using System;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *  Sayı tahmin oyunu:
             *  1. Program rastgele bir sayı üretir.
             *  2. Kullanıcıdan bir tahmin istenir.
             *  3. Girilen tahmine göre aşağı ya da yukarı biçiminde yönlendirilir.
             *  4. Sayı bilinene dek 2. adıma dönülür.
             */
            bool isGameFinished = false;
            Random randomNumberGenerator = new Random();
            //  1. Program rastgele bir sayı üretir.
            int randomNumber = randomNumberGenerator.Next(0, 100);
            while (!isGameFinished)
            {
                // 2. Kullanıcıdan bir tahmin istenir.
                Console.WriteLine("Tahmininizi girin:");
                int guess = Convert.ToInt32(Console.ReadLine());
                // 3. Girilen tahmine göre aşağı ya da yukarı biçiminde yönlendirilir.
                if (guess < randomNumber)
                {
                    Console.WriteLine("Yukarı!");
                }
                else if (guess > randomNumber)
                {
                    Console.WriteLine("Aşağı!");
                }
                else
                {
                    Console.WriteLine("Bildiniz!");
                    isGameFinished = true;
                }
            }

            //do
            //{
            //    // 2. Kullanıcıdan bir tahmin istenir.
            //    Console.WriteLine("Tahmininizi girin:");
            //    int guess = Convert.ToInt32(Console.ReadLine());
            //    // 3. Girilen tahmine göre aşağı ya da yukarı biçiminde yönlendirilir.
            //    if (guess < randomNumber)
            //    {
            //        Console.WriteLine("Yukarı!");
            //    }
            //    else if (guess > randomNumber)
            //    {
            //        Console.WriteLine("Aşağı!");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Bildiniz!");
            //        isGameFinished = true;
            //    }
            //} while (!isGameFinished);

        }
    }
}
