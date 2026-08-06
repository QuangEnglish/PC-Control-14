using System;

namespace Lesson12_OOP_P2.Interface
{
    // Circle implement 3 interface cùng lúc: IShape, IResizable, IColorable
    // Class phải cài đặt (implement) TẤT CẢ method của các interface nó đăng ký
    public class Circle : IResizable, IColorable
    {
        public double Radius { get; private set; }
        public string Color { get; set; }

        public Circle(double radius, string color = "Trang")
        {
            Radius = radius;
            Color = color;
        }

        // Implement IShape
        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public int Draw()
        {
            Console.WriteLine($"Ve hinh tron: ban kinh = {Radius}, mau = {Color}");
            return 100;
        }

        // Implement IResizable
        public void Resize(double factor)
        {
            Radius *= factor;
            Console.WriteLine($"Hinh tron da resize: ban kinh moi = {Radius:F2}");
        }

        // Implement IColorable
        public void SetColor(string color)
        {
            Color = color;
            Console.WriteLine($"Hinh tron da doi mau thanh: {Color}");
        }
    }
}
