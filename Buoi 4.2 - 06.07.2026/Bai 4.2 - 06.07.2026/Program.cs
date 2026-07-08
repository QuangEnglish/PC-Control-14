using System.Numerics;
using System.Text;

namespace Bai_4._2___06._07._2026
{
    internal class Program
    {
        #region Hàm không trả về giá trị, không có tham số
        static void Display()
        {
            int x = 0;
            int y = 10;
            int z = x + y;
            Console.WriteLine($"giá trị z: {z}");

        }
        #endregion

        #region Hàm không trả về giá trị, có truyền tham số
        static void DisplayV2(int x ,int y)
        {
            int z = x + y;
            Console.WriteLine($"giá trị z (V2): {z}");

        }
        #endregion

        #region Hàm có trả về giá trị, không tham số
        static float TinhDienTich()
        {
            float chieuDai = 4.5F;
            float chieuRong = 2.5F;
            float dienTich = chieuDai * chieuRong;
            return dienTich;
        }
        #endregion

        #region Hàm có trả về giá trị, có tham số
        static float TinhDienTichV2(float chieuDai, float chieuRong)
        {
            float dienTich = chieuDai * chieuRong;
            return dienTich;
        }
        #endregion

        #region
        static string XepLoaiHocLuc (int x) 
        {
            if (x < 7) return "Trung bình";
            else if (x < 8) return "Khá";
            else if (x < 9) return "Khá Giỏi";
            else return "Giỏi";

        }

        #endregion

        #region
        static void KiemTraSo(int x)
        {
            if (x % 2 == 0) Console.WriteLine("Đây là số chẵn");
            else Console.WriteLine("Đây là số lẻ");
        }
        #endregion

        // Tham trị (làm hàm nhận bản sao của biến gốc)
        static void TangGiaTri(int x)
        {
            x += 10;
            Console.WriteLine($"Giá trị trong hàm của x là: {x}");


        }

        // Tham chiếu (là hàm ko nhận bảo sao mà nhận chính bản gốc)
        static void TangGiaTriRef(ref int x)
        {
            x += 10;
            Console.WriteLine($"Giá trị trong hàm của x là: {x}");


        }

        static void TimMaxMin(int x,  int y, int z, out int maxValue, out int minValue)
        {
            maxValue = Math.Max(x,Math.Max(y,z));
            minValue = Math.Min(x, Math.Min(y, z));

        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Hello, World!");
            
            /*
            Display();
            float dienTich = TinhDienTich();
            Console.WriteLine("Diện Tích : " +dienTich);

            int x = 0;
            double y = 10;  
            DisplayV2(x, (int)y);

            float chieuDai = 4.5F;
            float chieuRong = 2.5F;
            float dienTichV2 = TinhDienTichV2(chieuDai, chieuRong);
            Console.WriteLine("Diện Tích V2 : " + dienTichV2);

          
            Console.WriteLine("Nhập điểm: ");
            int Diem = Convert.ToInt32(Console.ReadLine());
            String hocLuc = XepLoaiHocLuc(Diem);
            Console.WriteLine("Học Lực: " + hocLuc);
            

            Console.WriteLine("Nhập số của bạn: ");
            int soCuaBan = Convert.ToInt32(Console.ReadLine());
            KiemTraSo(soCuaBan);

            

            int bienDem = 10;
            TangGiaTri(bienDem);
            Console.WriteLine("Giá trị bienDem là: " +bienDem);

            int x = 5;
            TangGiaTriRef(ref x);
            Console.WriteLine("Giá trị biến x là: " +x);
            */

            int maxValue, minValue;
            TimMaxMin(10, 20, 30, out maxValue, out minValue);
            Console.WriteLine($"Giá trị Max là: {maxValue}");
            Console.WriteLine($"Giá trị Min là: {minValue}");


        }
    }
}
