//Здесь интерфейс IMultiFunctionDevice нарушал принцип ISP, так как заставлял классы реализовывать методы, которые они не поддерживают (например, BasicPhone был вынужден реализовывать Browse и SendEmail с выбрасыванием исключений), поэтому я разделил его на несколько специализированных интерфейсов (ICallable, IBrowsable и др.), чтобы классы могли реализовывать только те интерфейсы, которые им действительно нужны, и убрал неиспользуемые using-директивы.

using System;

namespace ConsoleApp2.isp
{
    public interface ICallable
    {
        void Call(string number);
    }

    public interface IBrowsable
    {
        void Browse(string url);
    }

    public interface IPhotographable
    {
        void TakePhoto();
    }

    public interface IEmailSender
    {
        void SendEmail(string recipient, string subject, string body);
    }

    public interface ISmsSender
    {
        void SendSms(string recipient, string message);
    }

    public interface IMusicPlayer
    {
        void PlayMusic();
    }

    public class SmartPhone : ICallable, IBrowsable, IPhotographable, IEmailSender, IMusicPlayer
    {
        public string Model { get; }
        public string OS { get; }

        public SmartPhone(string model, string os)
        {
            Model = model;
            OS = os;
        }

        public void Call(string number)
        {
            Console.WriteLine($"SmartPhone {Model} calling {number}");
        }

        public void Browse(string url)
        {
            Console.WriteLine($"SmartPhone {Model} browsing {url}");
        }

        public void TakePhoto()
        {
            Console.WriteLine($"SmartPhone {Model} takes a high quality photo");
        }

        public void SendEmail(string recipient, string subject, string body)
        {
            Console.WriteLine($"SmartPhone {Model} sending email to {recipient}");
        }

        public void PlayMusic()
        {
            Console.WriteLine($"SmartPhone {Model} is playing music");
        }
    }

    public class BasicPhone : ICallable, IPhotographable, ISmsSender
    {
        public string Model { get; }

        public BasicPhone(string model)
        {
            Model = model;
        }

        public void Call(string number)
        {
            Console.WriteLine($"BasicPhone {Model} calling {number}");
        }

        public void TakePhoto()
        {
            Console.WriteLine($"BasicPhone {Model} takes a very low quality photo");
        }

        public void SendSms(string recipient, string message)
        {
            Console.WriteLine($"BasicPhone {Model} sending SMS to {recipient}");
        }
    }
}
