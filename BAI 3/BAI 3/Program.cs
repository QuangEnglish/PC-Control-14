using System;
using System.Text;

namespace BAI_3
{
    internal class Program
    {
        static void Display()
        {
            int x = 0;
            int y = 10;
            int z = x + y;
            Console.WriteLine($"giá trị z: {z}");
        }

        static float TinhDienTichHCN()
        {
            float chieuDai = 4.5F;
            float chieuRong = 2.5F;
            float dienTich = chieuDai * chieuRong;
            return dienTich;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Display();

            float ketQua = TinhDienTichHCN();
            Console.WriteLine($"Diện tích hình chữ nhật là: {ketQua}");

            Console.ReadLine();
        }
    }
}