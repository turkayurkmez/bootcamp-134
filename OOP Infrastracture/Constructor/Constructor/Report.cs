using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor
{
    public enum Formats
    {
        PDF,Excel
    }
    public class Report
    {
        public string Owner { get; set; }
        public string Type { get; set; }
        public Formats Format { get; set; }
        public DateTime CreatedDate { get; set; }



        public Report()
        {
            CreatedDate = DateTime.Now;
            Format = Formats.PDF;
            Type = "Monthly Sales Report";
            Console.WriteLine("Rapor sınıfından instance alındı!");
        }

        public Report(string owner):this()
        {
            Owner = owner;
        }
        public Report(Formats format ): this()
        {
            Format = format;
        }


    }
}
