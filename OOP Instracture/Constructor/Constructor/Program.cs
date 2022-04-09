using System;

namespace Constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Report report = new Report();
            Console.WriteLine($"tarih: {report.CreatedDate}, format:{report.Format} ve türü: {report.Type}");

            Report performanceReport = new Report("Türkay");
            Console.WriteLine($"tarih: {performanceReport.CreatedDate}, format:{performanceReport.Format} ve türü: {performanceReport.Type} bu raporun sahibi: {performanceReport.Owner}");

            Report customReport = new Report(Formats.Excel);

        }
    }
}
