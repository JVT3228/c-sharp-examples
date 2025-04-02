using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.dip
{
    internal class Case2
    {
        // 1. Создан интерфейс ILogger для абстракции (DIP: модули зависят от абстракций)
        public interface ILogger
        {
            void WriteLog(string log);
            void ArchiveLog();
        }

        // 2. Класс Logger теперь реализует ILogger (DIP: детали зависят от абстракций)
        public class Logger : ILogger
        {
            public string FilePath { get; }

            public Logger(string filePath)
            {
                FilePath = filePath;
            }

            // Реализация методов интерфейса
            public void WriteLog(string log)
            {
                // 3. Исправлено: интерполяция строк вместо конкатенации (Clean Code)
                Console.WriteLine($"Writing log to file {FilePath}: {log}");
            }

            public void ArchiveLog()
            {
                Console.WriteLine($"Archiving log file {FilePath}");
            }

            // Эти методы не входят в ILogger, так как не используются в UserActivity (ISP)
            public void ClearLog()
            {
                Console.WriteLine($"Clearing log file {FilePath}");
            }

            public void GetLogStatus()
            {
                Console.WriteLine($"Checking log status for file {FilePath}");
            }
        }

        public class UserActivity
        {
            // 4. Зависимость от интерфейса, а не конкретного класса (DIP)
            private readonly ILogger _logger; // 5. Добавлен readonly (безопасность данных)
            public string UserName { get; }
            public int ActivityCount { get; private set; }

            // 6. Внедрение зависимости через конструктор (DIP: инверсия управления)
            public UserActivity(string userName, ILogger logger)
            {
                UserName = userName;
                ActivityCount = 0;
                _logger = logger; // Раньше было: new Logger("user_activity.log") → нарушение DIP
            }

            public void RecordActivity(string activity)
            {
                ActivityCount++;
                _logger.WriteLog($"User {UserName} did {activity}. Count: {ActivityCount}");
            }

            public void ResetActivityCount()
            {
                ActivityCount = 0;
                _logger.WriteLog($"Reset activity count for {UserName}");
            }

            public void ArchiveActivity()
            {
                _logger.ArchiveLog(); // Используется только метод из интерфейса
            }

            public void DisplayActivity()
            {
                Console.WriteLine($"User {UserName} has {ActivityCount} activities recorded.");
            }
        }
    }
}
