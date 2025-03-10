using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.dip
{
    internal class Case3
    {
        public class MySQLDatabase
        {
            private string connectionString;
            public MySQLDatabase(string connectionString)
            {
                this.connectionString = connectionString; 
            }

            public void Connect()
            {
                Thread.Sleep(3000);
                Console.WriteLine($"Connection done {connectionString}");
            }

            public void Disconnect()
            {
                // NOIMPL
            }

            public List<string> GetRecords()
            {
                return new List<string> { "data1", "data2" };
            }

            public void WriteLogEntry(string entry)
            {
                File.WriteAllText("log.txt", entry);
            }
        }

        public class ReportGenerator
        {
            private MySQLDatabase database;
            private List<string> reportData = [];

            public ReportGenerator()
            {
                database = new MySQLDatabase("mysql://dsadlkasjdklasjdaklsjd");
            }

            public void GenerateReport()
            {
                database.Connect();
                reportData = database.GetRecords();

                ProcessData();
                var s = FormatReport();
                SaveReport(string.Join(';', s));
            }

            private void ProcessData()
            {
                if (reportData.Count > 100)
                {
                    reportData = reportData.GetRange(0, 100);
                }
            }

            private List<string> FormatReport()
            {
                var res = new List<string>();
                foreach (var item in reportData)
                {
                    res.Add($"Item: {item.ToUpper()}");
                    Console.WriteLine($"Item: {item.ToUpper()}");
                }
                return res;
            }

            public void SaveReport(string formattedText)
            {
                database.WriteLogEntry(formattedText);
            }
        }
    }
}
