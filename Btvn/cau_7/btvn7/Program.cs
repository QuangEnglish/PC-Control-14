// See https://aka.ms/new-console-template for more information
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        int tong = 0;
        while (true)
        {
            Console.WriteLine("nhập số");
            int so = int.Parse(Console.ReadLine());
            if (so < 0)
            {
                break;
            }
            if (so % 2 == 0)
            {
                continue;

            }
            tong += so;
            {

            }

            Console.WriteLine(" Tổng các số lẻ dương là: " + tong);

        }
    }
}
