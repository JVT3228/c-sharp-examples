using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.srp
{
    class Case2
    {
        class User
        {
            public string Name;
            public string Email;
            public string Password;

            public void Register(string name, string email, string password)
            {
                Name = name;
                Email = email;
                Password = password;
                Console.WriteLine("User registered!");
            }

            public void PrintUserInfo()
            {
                Console.WriteLine("User: " + Name + " Email: " + Email);
            }

            public void ChangePassword(string newPassword)
            {
                Password = newPassword;
                Console.WriteLine("Password changed!");
            }

            public void SendEmail(string message)
            {
                Console.WriteLine("Email sent to " + Email + ": " + message);
            }
        }

        public class App
        {
            public void Execute()
            {
                User user = new User();
                user.Register("Tim", "tim@example.com", "123456");
                user.PrintUserInfo();
                user.SendEmail("Hello!");
            }
        }
    }
}
