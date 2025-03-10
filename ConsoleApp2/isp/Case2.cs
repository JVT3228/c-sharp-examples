﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.isp
{
    internal class Case2
    {
        public interface IMultiFunctionDevice
        {
            void Call(string number);
            void Browse(string url);
            void TakePhoto();
            void SendEmail(string recipient, string subject, string body);
        }

        public class SmartPhone : IMultiFunctionDevice
        {
            public string Model { get; set; }
            public string OS { get; set; }

            public SmartPhone(string model, string os)
            {
                Model = model;
                OS = os;
            }

            public void Call(string number)
            {
                Console.WriteLine("SmartPhone " + Model + " calling " + number);
            }

            public void Browse(string url)
            {
                Console.WriteLine("SmartPhone " + Model + " browsing " + url);
            }

            public void TakePhoto()
            {
                Console.WriteLine("SmartPhone " + Model + " takes a high quality photo");
            }

            public void SendEmail(string recipient, string subject, string body)
            {
                Console.WriteLine("SmartPhone " + Model + " sending email to " + recipient);
            }

            public void PlayMusic()
            {
                Console.WriteLine("SmartPhone " + Model + " is playing music");
            }
        }

        public class BasicPhone : IMultiFunctionDevice
        {
            public string Model { get; set; }

            public BasicPhone(string model)
            {
                Model = model;
            }

            public void Call(string number)
            {
                Console.WriteLine("BasicPhone " + Model + " calling " + number);
            }

            public void Browse(string url)
            {
                throw new NotSupportedException("BasicPhone " + Model + " does not support browsing.");
            }

            public void TakePhoto()
            {
                Console.WriteLine("BasicPhone " + Model + " takes a very low quality photo");
            }

            public void SendEmail(string recipient, string subject, string body)
            {
                throw new NotSupportedException("BasicPhone " + Model + " does not support sending emails.");
            }

            public void SendSMS(string recipient, string message)
            {
                Console.WriteLine("BasicPhone " + Model + " sending SMS to " + recipient);
            }
        }

    }
}
