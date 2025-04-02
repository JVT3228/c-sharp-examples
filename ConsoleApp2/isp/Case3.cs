using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.isp
{
    internal class Case3
    {
        // 1. Разделяем интерфейсы согласно ISP
        public interface IFileReadable
        {
            void OpenFile();
            string ReadFile();
        }

        public interface IFileWritable
        {
            void WriteFile(string content);
        }

        public interface IFileSharable
        {
            void ShareFile(string recipient);
        }

        public interface IFileArchivable
        {
            void ArchiveFile();
        }

        public interface IFileInfoProvider
        {
            void GetFileDetails();
        }

        // 2. Стандартный файл реализует все необходимые интерфейсы
        public class StandardFile : IFileReadable, IFileWritable, IFileSharable, IFileArchivable, IFileInfoProvider
        {
            public string FileName { get; }
            public string FilePath { get; }

            public StandardFile(string fileName, string filePath)
            {
                FileName = fileName;
                FilePath = filePath;
            }

            public void OpenFile()
            {
                Console.WriteLine($"Opening file {FileName} at {FilePath}");
            }

            public string ReadFile()
            {
                return $"Contents of {FileName}";
            }

            public void WriteFile(string content)
            {
                Console.WriteLine($"Writing to file {FileName}: {content}");
            }

            public void ShareFile(string recipient)
            {
                Console.WriteLine($"Sharing file {FileName} with {recipient}");
            }

            public void ArchiveFile()
            {
                Console.WriteLine($"Archiving file {FileName}");
            }

            public void GetFileDetails()
            {
                Console.WriteLine($"File details: {FileName}, located at {FilePath}");
            }
        }

        // 3. ReadOnlyFile реализует только чтение и информацию
        public class ReadOnlyFile : IFileReadable, IFileInfoProvider
        {
            public string FileName { get; }
            public string FilePath { get; }

            public ReadOnlyFile(string fileName, string filePath)
            {
                FileName = fileName;
                FilePath = filePath;
            }

            public void OpenFile()
            {
                Console.WriteLine($"Opening read-only file {FileName} at {FilePath}");
            }

            public string ReadFile()
            {
                return $"Read-only content from {FileName}";
            }

            public void GetFileDetails()
            {
                Console.WriteLine($"File Info: {FileName} at {FilePath}");
            }
        }
    }
}
