using System;
using System.Text;

namespace BAI4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

         
            Console.Write("Bạn hãy nhập điểm của bạn: ");
            int diemHocLuc = Convert.ToInt32(Console.ReadLine());

            string xepLoai = XepLoaiHocLuc(diemHocLuc);
            Console.WriteLine($"Xếp loại học lực: {xepLoai}");


         
            Console.Write("Bạn hãy nhập số của bạn: ");
            int nhapSoV2 = (int)float.Parse(Console.ReadLine());
            int yV2 = 2;
            string zV2 = " ";
            bool zV3 = true;

            KiemTraSo(nhapSoV2, yV2, zV2, zV3);


            int x = 10;
            TangGiaTri(x);
            Console.WriteLine($"Giá trị của x sau khi gọi hàm TangGiaTri: {x}");


          
            string a = "Nguyen";
            ThayDoiChuoi(a);
            Console.WriteLine("Giá trị của a là: " + a);

            string b = "Nguyen";
            ThayDoiChuoiRef(ref b);
            Console.WriteLine("Giá trị của b là: " + b);

            int maxValue, minValue;
            TimMaxMin(10, 20, 30, out maxValue, out minValue);
            Console.WriteLine($"Giá trị maxValue là: {maxValue}");
            Console.WriteLine($"Giá trị minValue là: {minValue}");

            Console.ReadLine();
        }

   

        static void KiemTraSo(int x, int y, string z, bool f)
        {
            if (x % 2 == 0)
            {
                Console.WriteLine("Là số chẵn");
            }
            else
            {
                Console.WriteLine("Là số lẻ");
            }
        }

        static string XepLoaiHocLuc(int diem)
        {
            if (diem >= 8) return "Giỏi";
            if (diem >= 6.5) return "Khá";
            if (diem >= 5) return "Trung bình";
            return "Yếu";
        }

        static void TangGiaTri(int x)
        {
            x += 10;
            Console.WriteLine($"Giá trị trong hàm của x là: {x}");
        }

        static void ThayDoiChuoi(string s)
        {
            s = "Thay doi";
        }

        static void ThayDoiChuoiRef(ref string s)
        {
            s = "Thay doi";
        }

        static void TimMaxMin(int n1, int n2, int n3, out int max, out int min)
        {
            max = Math.Max(n1, Math.Max(n2, n3));
            min = Math.Min(n1, Math.Min(n2, n3));
        }
    }
}