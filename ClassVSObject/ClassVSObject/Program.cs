using System;

namespace ClassVSObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Person trainerOfBootcamp = new Person();
            trainerOfBootcamp.Name = "Türkay";
            trainerOfBootcamp.LastName = "Ürkmez";
            trainerOfBootcamp.Salary = 100000;

            Person cooker = new Person();
            cooker.Name = "Perihan";
            cooker.LastName = "Elibol";

            Person student1 = new Person();
            student1.Name = "Ahmed Jam";

            Person student2 = student1;
            student2.Name = "İrem Ergin";

            Console.WriteLine(student1.Name);

            /*
             * Musteri musteri = new Musteri();
             
             * Yemek sandvic = new Yemek();
             * Sepet yemekSepeti = new Sepet();
             * yemekSepeti.Ekle(sanvic);
             * musteri.SiparisVer(yemekSepeti);
             * 
             *
             */

            Console.WriteLine(trainerOfBootcamp.LastName);



        }
    }
}
