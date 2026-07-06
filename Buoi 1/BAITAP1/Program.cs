using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAITAP1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=========== HO SƠ NHÂN VIÊN ===========");
            Console.Write("Nhap ma nhan vien: ");
            string manhanvien = Console.ReadLine();
            Console.Write("Nhap ho va ten: ");
            string hovaten = Console.ReadLine();
            Console.Write("Nhap tuoi: ");
            int tuoi =Convert.ToInt32( Console.ReadLine());
            Console.Write("Nhap chieu cao: ");
            double chieucao = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nhap can nang: ");
            float cannang = Convert.ToSingle(Console.ReadLine());
            Console.Write("So ngay lam viec: ");
            int songaylamviec = Convert.ToInt32(Console.ReadLine());
            Console.Write("luong 1 ngay: ");
            double luong1ngay = Convert.ToDouble(Console.ReadLine());
            decimal tongluong = (decimal)(songaylamviec * luong1ngay);
            Console.WriteLine("Tong luong ca thang la: " + tongluong + "VND");
            Console.Write("So nam kinh nghiem: ");
            int sonamkinhnghiem = Convert.ToInt32(Console.ReadLine());
            Console.Write("Co dang lam viec hay khong ?: ");
            bool danglamviec = Convert.ToBoolean(Console.ReadLine());
            Console.Write("Xep loai: ");
            char xeploai = Convert.ToChar(Console.ReadLine());
        }
    }
}
