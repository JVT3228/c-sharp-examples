//Здесь класс  Order имел несколько методов, то есть ответственностей, что нарушает принцип SRP "единственной ответственности", так что я разделил эти методы на несколько классов. А ещё убрал лишние using которые не используются в коде.
using System;
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
            Console.WriteLine("Order #" + order.OrderId + " saved to database!");
        }
    }

    class OrderPrinter
    {
        public void Print(Order order)
        {
            Console.WriteLine("Order #" + order.OrderId);
            foreach (var item in order.Items)
            {
                Console.WriteLine(" - " + item);
            }
        }
    }

    class EmailService
    {
        public void SendConfirmation(Order order)
        {
            Console.WriteLine("Order confirmation for #" + order.OrderId + " sent!");
        }
    }

    public class App
    {
        static void Main()
        {
            Order order = new Order();
            OrderPrinter printer = new OrderPrinter();
            OrderRepository repository = new OrderRepository();
            EmailService emailService = new EmailService();

            order.AddItem("Laptop");
            printer.Print(order);
            repository.Save(order);
            emailService.SendConfirmation(order);
        }
    }
}
