using System;

namespace Lesson12_OOP_P2.Interface
{
    // Rectangle cũng implement 3 interface nhưng cài đặt khác Circle
    public class Rectangle : IResizable, IColorable
    {
        public double Width { get; private set; }
        public double Height { get; private set; }
        public string Color { get; set; }

        public Rectangle(double width, double height, string color = "Xanh")
        {
            Width = width;
            Height = height;
            Color = color;
        }

        // Implement IShape
        public double CalculateArea()
        {
            return Width * Height;
        }

        public double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }

        public double Draw()
        {
            Console.WriteLine($"Ve hinh chu nhat: {Width} x {Height}, mau = {Color}");
            return 1000;
        }
        

        // Implement IResizable
        public void Resize(double factor)
        {
            Width *= factor;
            Height *= factor;
            Console.WriteLine($"Hinh chu nhat da resize: {Width:F2} x {Height:F2}");
        }

        // Implement IColorable
        public void SetColor(string color)
        {
            Color = color;
            Console.WriteLine($"Hinh chu nhat da doi mau thanh: {Color}");
        }
    }
}
