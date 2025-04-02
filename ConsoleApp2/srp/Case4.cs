using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.srp
{
    class Case4
    {
        // 1. Класс только для хранения данных сотрудника (SRP)
        public class Employee
        {
            public string Name { get; set; }
            public double Salary { get; private set; }

            public void SetSalary(double amount) => Salary = amount;
        }

        // 2. Класс для вывода информации (SRP)
        public class EmployeePrinter
        {
            public void PrintInfo(Employee employee)
            {
                Console.WriteLine($"Employee: {employee.Name}, Salary: ${employee.Salary}");
            }
        }

        // 3. Класс для работы с файлами (SRP)
        public class EmployeeRepository
        {
            public void SaveToFile(Employee employee, string filePath)
            {
                File.WriteAllText(filePath, $"{employee.Name} - {employee.Salary}");
                Console.WriteLine("Employee saved to file!");
            }

            public void LoadFromFile(string filePath)
            {
                string data = File.ReadAllText(filePath);
                Console.WriteLine($"Loaded: {data}");
            }
        }

        class Program
        {
            static void Main()
            {
                // Создаем объекты с разделенными обязанностями
                var emp = new Employee { Name = "John" };
                emp.SetSalary(5000);

                var printer = new EmployeePrinter();
                printer.PrintInfo(emp);

                var repository = new EmployeeRepository();
                repository.SaveToFile(emp, "employee.txt");
            }
        }
    }
}
