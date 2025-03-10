using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.ocp
{
    class Case2
    {
        class Circle
        {
            public double Radius;
            public Circle(double radius)
            {
                Radius = radius;
            }
            public double GetArea()
            {
                return Math.PI * Radius * Radius;
            }
        }
        class Rectangle
        {
            public double Width;
            public double Height;
            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }
            public double GetArea()
            {
                return Width * Height;
            }
        }
        class AreaCalculator
        {
            public double Calculate(object shape)
            {
                if (shape is Circle)
                {
                    return ((Circle)shape).GetArea();
                }
                else if (shape is Rectangle)
                {
                    return ((Rectangle)shape).GetArea();
                }
                return 0;
            }
        }
        class Program
        {
            static void Main()
            {
                Circle c = new Circle(5);
                Rectangle r = new Rectangle(4, 6);
                AreaCalculator calculator = new AreaCalculator();
                Console.WriteLine("Circle area: " + calculator.Calculate(c));
                Console.WriteLine("Rectangle area: " + calculator.Calculate(r));
            }
        }


        //class Figure
        //{
        //    public virtual double GetArea()
        //    {
        //        return 0;
        //    }
        //}

        //class Circle : Figure
        //{
        //    public double Radius { get; set; }
        //    public Circle(double radius)
        //    {
        //        Radius = radius;
        //    }
        //    public override double GetArea()
        //    {
        //        return Math.PI * Radius * Radius;
        //    }
        //}
        //class Rectangle : Figure
        //{
        //    public double Width { get; set; }
        //    public double Height { get; set; }
        //    public Rectangle(double width, double height)
        //    {
        //        Width = width;
        //        Height = height;
        //    }
        //    public override double GetArea()
        //    {
        //        return Width * Height;
        //    }
        //}
        //class Application
        //{
        //    static void Main()
        //    {
        //        var c = new Circle(5);
        //        var r = new Rectangle(4, 6);
        //        Console.WriteLine("Circle area: " + c.GetArea());
        //        Console.WriteLine("Rectangle area: " + r.GetArea());
        //    }
        //}
    }
}
