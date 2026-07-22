// See https://aka.ms/new-console-template for more information
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Nhập số ");
        int x = int.Parse(Console.ReadLine());
        switch (x)
        {
            case 1:
                Console.WriteLine("Thứ Chủ nhật");
                break;
            case 2:
                Console.WriteLine("Thứ hai");
                break;
            case 3:
                Console.WriteLine("Thứ ba");
                break;
                case 4:
                Console.WriteLine("Thứ Tư");
                break;
                case 5:
                Console.WriteLine("Thứ Năm");
                break;
                case 6:
                Console.WriteLine("Thứ Sáu");
                break;
            case 7:
                Console.WriteLine("Thứ Bảy");
                break;

            default:
                Console.WriteLine("Không hợp lệ");
                break;
        }   
    }
}
