using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.isp
{
    internal class Case1
    {
        public interface IOfficeDevice
        {
            void Print(string document);
            void Scan(string document);
            void Fax(string document);
            void Copy(string document);
        }

        public class BasicPrinter : IOfficeDevice
        {
            public string Model { get; set; }

            public BasicPrinter(string model)
            {
                Model = model;
            }

            public void Print(string document)
            {
                Console.WriteLine("BasicPrinter printing: " + document);
            }

            public void Scan(string document)
            {
                throw new NotImplementedException("BasicPrinter cannot scan documents");
            }

            public void Fax(string document)
            {
                throw new NotImplementedException("BasicPrinter cannot fax documents");
            }

            public void Copy(string document)
            {
                throw new NotImplementedException("BasicPrinter cannot copy documents");
            }

            public void Maintenance()
            {
                Console.WriteLine("Performing maintenance on BasicPrinter " + Model);
            }
        }

        public class AllInOnePrinter : IOfficeDevice
        {
            public string Model { get; set; }

            public AllInOnePrinter(string model)
            {
                Model = model;
            }

            public void Print(string document)
            {
                Console.WriteLine("AllInOnePrinter printing: " + document);
            }

            public void Scan(string document)
            {
                Console.WriteLine("AllInOnePrinter scanning: " + document);
            }

            public void Fax(string document)
            {
                Console.WriteLine("AllInOnePrinter faxing: " + document);
            }

            public void Copy(string document)
            {
                Console.WriteLine("AllInOnePrinter copying: " + document);
            }

            public void Calibrate()
            {
                Console.WriteLine("Calibrating printer " + Model); 
            }
        }

    }
}
