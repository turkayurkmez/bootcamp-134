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
                "kirikkalp72@yahoo.com",
                "nur.bilge@microsoft.com",
                "turkay.urkmez@gmail.com",
                "babyboy@mynet.com",
                "testmail"
               
            };

            List<string> publicDomains = new List<string>()
            {
                "yahoo.com",
                "gmail.com",
                "mynet.com"
            };

            List<string> companyEmails = new List<string>();

            foreach (var mail in emails)
            {
                //foreach (var domain in publicDomains)
                //{
                //    if (!mail.EndsWith(domain))
                //    {

                //    }
                //}
                string[] mailParts = mail.Split('@');
               
                if (mailParts.Length>1)
                {
                    string mailDomain = mailParts[1];
                    bool isExists = publicDomains.Contains(mailDomain);
                    if (!isExists)
                    {
                        companyEmails.Add(mail);
                    }
                }
              
               
            }
            Console.WriteLine("Şirket e-posta adresleri:");
            foreach (var mailAdrees in companyEmails)
            {
                Console.WriteLine(mailAdrees);
            }

            List<string> cities = new List<string>() { "Ankara", "Ankara", "Ankara", "Sinop", "İstanbul", "İstanbul", "Eskişehir", "Ankara" };





        }
    }
}
