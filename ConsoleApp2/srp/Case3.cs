//Здесь класс  Order имел несколько методов, то есть ответственностей, что нарушает принцип SRP "единственной ответственности", так что я разделил эти методы на несколько классов
﻿using System;
using System.Collections.Generic;

namespace ConsoleApp2.srp
{
    class Order
    {
        public int OrderId;
        public List<string> Items = new List<string>();

        public void AddItem(string item) 
        { 
            Items.Add(item);
        }
    }

    class OrderRepository
    {
        public void Save(Order order)
        {
            Console.WriteLine("Order saved to database!");
        }
    }

    class OrderPrinter
    {
        public void Print(Order order)
        {
            Console.WriteLine("Order #" + OrderId);
            foreach (var item in Items)
            {
                Console.WriteLine(" - " + item);
            }
        }
    }

    class EmailService
    {
        public void SendConfirmation(Order order)
        {
            Console.WriteLine("Order confirmation email sent!");
        }
    }

    public class App
    {
        static void Main()
        {
            // Принцип явных зависимостей из Clean Code
            var order = new Order();
            var printer = new OrderPrinter();
            var repository = new OrderRepository();
            var emailService = new EmailService();

            order.AddItem("Laptop");
            printer.Print(order);
            repository.Save(order);
            emailService.SendConfirmation(order);
        }
    }
}
