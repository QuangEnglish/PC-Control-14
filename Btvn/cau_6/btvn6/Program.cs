// See https://aka.ms/new-console-template for more information
using System.Text.Json.Serialization;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("nhập vào số a");
        Double a = double.Parse(Console.ReadLine());
        Console.WriteLine("nhập vào số b");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("nhập vào phép toán");
        char pheptoan = char.Parse(Console.ReadLine());
        switch (pheptoan)
        {
            case '+':
                Console.WriteLine("kết quả là: " + (a + b));
                break;
            case '-':
                Console.WriteLine("kết quả là: " + (a - b));
                break;
            case '*':
                Console.WriteLine("kết quả là: " + (a * b));
                break;
            case '/':

                if (b == 0)
                {
                    Console.WriteLine("không thể chia cho 0");
                    break;
                }
                else
                {
                    Console.WriteLine("kết quả là: " + (a / b));
                    break;
                }
               
            default:
                Console.WriteLine("phép toán không hợp lệ");
                break;
        }
    }
}