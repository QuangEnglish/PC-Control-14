using System;

namespace Lesson12_OOP_P2.Interface
{
    // Triangle chỉ implement IShape và IColorable, KHÔNG implement IResizable
    // Mỗi class tự quyết định implement những interface nào phù hợp
    public class Triangle : IShape, IColorable
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        public string Color { get; set; }

        public Triangle(double a, double b, double c, string color = "Do")
        {
            A = a;
            B = b;
            C = c;
            Color = color;
        }

        // Implement IShape
        public double CalculateArea()
        {
            // Công thức Heron
            double s = (A + B + C) / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }

        public double CalculatePerimeter()
        {
            return A + B + C;
        }

        public int Draw()
        {
            Console.WriteLine($"Ve hinh tam giac: canh {A}, {B}, {C}, mau = {Color}");
            return 5000;
        }

        // Implement IColorable
        public void SetColor(string color)
        {
            Color = color;
            Console.WriteLine($"Hinh tam giac da doi mau thanh: {Color}");
        }
    }
}
