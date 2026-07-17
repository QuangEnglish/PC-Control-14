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
            else { 
                    Console.WriteLine("Số không"); 
                 }


            //Bài 2
            Console.WriteLine("Bài 2");
            Console.WriteLine("Nhập một ngày trong tuần: ");


            String ngay = Console.ReadLine();
            switch (ngay)
            {
                case "1": Console.WriteLine("Chủ nhật"); break;
                case "2": Console.WriteLine("Thứ Hai"); break;
                case "3": Console.WriteLine("Thứ Ba"); break;
                case "4": Console.WriteLine("Thứ Tư"); break;
                case "5": Console.WriteLine("Thứ Năm"); break;
                case "6": Console.WriteLine("Thứ Sáu"); break;
                case "7": Console.WriteLine("Thứ Bảy"); break;
                default: Console.WriteLine("Không phải thứ trong tuần"); break;

             }

            //Bài 3
            int b = 1;
            while (true)
            {
                
                Console.WriteLine($"Số {b++}");
                if (b > 10) break;

            }

            //Bài 4
            Console.WriteLine("Bài 4");
            Console.WriteLine("Nhập một số nguyên nguyên bất kỳ: ");
            int c = Convert.ToInt32(Console.ReadLine());
            int d = 0;
            for (int i = 0; i<=c; i++)
            {
                d += i; 
            }
            Console.WriteLine($"Tổng các số từ 1 đến n: {d}");

            // bài5



        }
    }
}
