using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.lsp
{
    internal class Case0
    {
        public class Shape
        {
            protected int Width { get; set; }
            protected int Height { get; set; }

            public virtual void SetWidth(int width)
            {
                Width = width;
                Console.WriteLine($"Width set to {width}.");
            }

            public virtual void SetHeight(int height)
            {
                Height = height;
                Console.WriteLine($"Height set to {height}.");
            }

            public virtual int CalculateArea()
            {
                return Width * Height;
            }

            public virtual void Draw()
            {
                Console.WriteLine("Drawing shape.");
            }
        }

        public class Circle : Shape
        {
            public override void SetWidth(int width)
            {
                Width = width;
                Height = width;
                Console.WriteLine($"Circle diameter set to {width}.");
            }

            public override void SetHeight(int height)
            {
                Width = height;
                Height = height;
                Console.WriteLine($"Circle diameter set to {height}.");
            }

            public override int CalculateArea()
            {
                return (int)(Math.PI * (Width / 2) * (Width / 2));
            }

            public override void Draw()
            {
                Console.WriteLine("Drawing circle.");
            }
        }

    }
}
