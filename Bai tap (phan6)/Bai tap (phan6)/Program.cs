using System.Text;

namespace Bai_tap__phan6_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Phần 6: Bài Tập");
            
            //bài 1
            Console.WriteLine("Bài 1"); 
            Console.WriteLine("Nhập một số nguyên: ");
            int a = Convert.ToInt32(Console.ReadLine()); 
            if (a > 0) Console.WriteLine("Số dương");
            else if (a < 0) Console.WriteLine("Số âm");
            else if (a > 0) Console.WriteLine("Số không");



        }
    }
}
