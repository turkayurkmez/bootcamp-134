using System;
using System.Collections.Generic;

namespace ArraysAndCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //elemanları biliyorsanız:
            string[] shoppingList = new string[] { "Elma", "Salatalık", "Domates" };
            Console.WriteLine($"ilk eleman: {shoppingList[0]}");
            Console.WriteLine($"array içindeki toplam eleman: {shoppingList.Length}");
            Console.WriteLine($"array içindeki son eleman: {shoppingList[shoppingList.Length-1]}");

            //elemanların kaç adet olacağını biliyorsam:
            string[] participants = new string[38];
            participants[0] = "Abdullah Halit";
            participants[1] = "Ahmad Hamdan";
            participants[37] = "Umut Oku";

            //42
            //Kırk iki

            string[] birler = { "", "bir", "iki", "üç", "dört", "beş", "altı", "yedi", "sekiz", "dokuz" };
            string[] onlar = { "", "on", "yirmi", "otuz", "kırk", "elli", "altmış", "yetmiş", "seksen", "doksan" };

            Console.WriteLine("1 ile 100 arasında bir sayı giriniz");
            int number = Convert.ToInt32(Console.ReadLine());
            int onlarBasamagindakiSayi = number / 10;
            int birlerBasamagindakiSayi = number % 10;

            //16.697.885
            //Array.Resize(ref shoppingList, shoppingList.Length + 1);
            //shoppingList[shoppingList.Length - 1] = "Peynir";
            List<string> anotherShopList = new List<string>();
            anotherShopList.Add("Peynir");
            anotherShopList.Add("Zeytin");
            anotherShopList.Add("Su");







            Console.WriteLine($"{onlar[onlarBasamagindakiSayi]} {birler[birlerBasamagindakiSayi]}");

        }
    }
}
