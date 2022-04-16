using System;
using System.Collections.Generic;
using System.Linq;

namespace usingLinq
{
    class Program
    {
        private static List<Student> students;

        static void Main(string[] args)
        {
            //Language INtegrated Query.
            students = new List<Student>
           {
                new Student { Id =1, Name="Marwan", LastName="Kaseer", Age=24, AverageScore=74.6, Info="He was a brilliant student!"  },
                new Student { Id =2, Name="Türkay", LastName="Ürkmez", Age=42, AverageScore=85, Info="He was a meh student!"  },
                new Student { Id =3, Name="Nur Bilge", LastName="Kul", Age=29, AverageScore=69.4  },
                new Student { Id =4, Name="Umut", LastName="Oku", Age=29, AverageScore=54  }
           };

            basicLinq();
            getAverageScore();
        }

        private static void getAverageScore()
        {
            var average = students.Max(x => x.AverageScore);
            Console.WriteLine($"Ortalama değer: {average}");
        }

        private static void basicLinq()
        {
            //foreach (var item in students)
            //{
            //    if (item.AverageScore>=70)
            //    {

            //    }
            //}
            var scorebigThan70 = from student in students
                                 where student.AverageScore >= 70
                                 orderby student.AverageScore
                                 select student;

            var alternativeBigThanFive = students.Where(s => s.AverageScore >= 70)
                                                 .OrderByDescending(x=>x.AverageScore)
                                                 .ToList();


            alternativeBigThanFive.ForEach(stu => Console.WriteLine($"{stu.Name} {stu.LastName} {stu.Age} {stu.AverageScore}"));




        }
    }
}
