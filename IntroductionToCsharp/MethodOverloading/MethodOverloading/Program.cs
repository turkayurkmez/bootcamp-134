using System;

namespace MethodOverloading
{

    public enum Geometry
    {
        Square,
        Circle,
        Rectangle,
        Triangle

    }

    public enum TurkishManAffinity
    {
        Baba = 1,
        Abi = 2,
        Amca = 4,
        Dayi = 8,
        Dede= 16
    }
    class Program
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine($"3 birim kare: {getArea(3, "Square")} ");
            Console.WriteLine($"4 birim daire:{getArea(4, "Circle")}");
            Console.WriteLine($"4 ve 8 birim üçgen:{getArea(4,8, "Triangle")}");
            Console.WriteLine($"5 ve 9 birim dikdörtgen:{getArea(5, 9, "Rectangle")}");



            Console.WriteLine($"Örnek 1 Kare: {alternativeGetArea(15)}");
            Console.WriteLine($"Örnek 2 Daire: {alternativeGetArea(5,geometry:"Circle")}");
            Console.WriteLine($"Örnek 3 Üçgen: {alternativeGetArea(5,6, geometry: "Triangle")}");

            Console.WriteLine($"Enum ile örnek: {alternativeGetAreaWithEnum(4,5, Geometry.Rectangle)}");

            TurkishManAffinity affinity = TurkishManAffinity.Abi | TurkishManAffinity.Dayi;
            Console.WriteLine($"Türkayın akrabalık değeri:{affinity}");

        }
        /// <summary>
        /// get area for Circle or square
        /// </summary>
        /// <param name="unit1Length"></param>
        /// <param name="geometry"></param>
        /// <returns></returns>
        static double getArea(int unit1Length, string geometry)
        {
            double calculatedValue = 0.0;
            switch (geometry)
            {
                case "Square":
                    calculatedValue = unit1Length * unit1Length;
                    break;
                case "Circle":
                    calculatedValue = (unit1Length * unit1Length) * Math.PI ;
                    break;
                default:
                    Console.WriteLine("Sadece Circle ya da Square değeri girilebilir");
                    break;
            }

            return calculatedValue;
        }
        /// <summary>
        /// get area for Rectangle or Triangle
        /// </summary>
        /// <param name="unit1Length"></param>
        /// <param name="unit2Length"></param>
        /// <param name="geometry">Rectangle or Triangle</param>
        /// <returns></returns>
        static double getArea(int unit1Length, int unit2Length, string geometry)
        {
            double calculatedValue = 0.0;
            switch (geometry)
            {
                case "Rectangle":
                    calculatedValue = unit1Length * unit2Length;
                    break;
                case "Triangle":
                    calculatedValue = (unit1Length * unit2Length) / 2;
                    break;
                default:
                    Console.WriteLine("Sadece Rectangle ya da Triangle değeri girilebilir");
                    break;
            }

            return calculatedValue;
        }

        static double alternativeGetArea(int unit1Length, int unit2Length = 1, string geometry = "Square")
        {
            double calculatedValue = 0.0;
            switch (geometry)
            {
                case "Square":
                    calculatedValue = unit1Length * unit1Length;
                    break;
                case "Circle":
                    calculatedValue = (unit1Length * unit1Length) * Math.PI;
                    break;
                case "Rectangle":
                    calculatedValue = unit1Length * unit2Length;
                    break;
                case "Triangle":
                    calculatedValue = (unit1Length * unit2Length) / 2;
                    break;
                default:
                    Console.WriteLine("Sadece Circle, Square, Rectangle ya da Triangle  değerlerinden biri girilebilir");
                    break;
            }
            return calculatedValue;
        }


        static double alternativeGetAreaWithEnum(int unit1Length, int unit2Length = 1, Geometry geometry= Geometry.Square)
        {
            double returnValue = 0.0;
            switch (geometry)
            {
                case Geometry.Square:
                    returnValue = Math.Pow(unit1Length, 2);
                    break;
                case Geometry.Circle:
                    returnValue = Math.Pow(unit1Length, 2) * Math.PI;
                    break;
                case Geometry.Rectangle:
                    returnValue = unit1Length * unit2Length;
                    break;
                case Geometry.Triangle:
                    returnValue = (unit1Length * unit2Length)/2;
                    break;
                default:
                    break;
            }

            return returnValue;
        }


    }
}
