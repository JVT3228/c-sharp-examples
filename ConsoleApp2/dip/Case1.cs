//Здесь класс Notifier нарушал принцип DIP, так как напрямую зависел от конкретного класса EmailSender (создавал его экземпляр внутри себя), поэтому я ввел интерфейс IMessageSender, сделал зависимость внедряемой через конструктор и переименовал метод SendEmail в более универсальный Send, чтобы класс Notifier зависел от абстракции, а не от конкретной реализации, что позволяет легко подменять способ отправки сообщений без изменения кода 'Notifier'.Удалил неиспользуемые using-директивы

using System;

namespace ConsoleApp2.dip
{
    public interface IMessageSender
    {
        void Connect();
        void Send(string recipient, string subject, string message);
        void Disconnect();
        void Log(string log);
    }

    public class EmailSender : IMessageSender
    {
        public string SmtpServer { get; }
        public int Port { get; }

        public EmailSender(string smtpServer, int port)
        {
            SmtpServer = smtpServer;
            Port = port;
        }

        public void Connect()
        {
            Console.WriteLine($"Connecting to SMTP server {SmtpServer}:{Port}");
        }

        public void Send(string recipient, string subject, string message)
        {
            Console.WriteLine($"Sending email to {recipient} with subject {subject}");
        }

        public void Disconnect()
        {
            Console.WriteLine($"Disconnecting from SMTP server {SmtpServer}");
        }

        public void Log(string log)
        {
            Console.WriteLine($"Logging email: {log}");
        }
    }

    public class Notifier
    {
        private readonly IMessageSender _messageSender;
        public string NotifierName { get; private set; }

        public Notifier(string name, IMessageSender messageSender)
        {
            NotifierName = name;
            _messageSender = messageSender;
        }

        public void Notify(string recipient, string subject, string message)
        {
            _messageSender.Connect();
            _messageSender.Send(recipient, subject, message);
            _messageSender.Disconnect();
        }

        public void LogNotification(string log)
        {
            _messageSender.Log(log);
        }

        public void UpdateNotifierName(string newName)
        {
            NotifierName = newName;
            Console.WriteLine($"Notifier name updated to {NotifierName}");
        }

        public void ShowNotifierInfo()
        {
            Console.WriteLine($"Notifier: {NotifierName}");
        }
    }
}
