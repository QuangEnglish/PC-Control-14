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

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Hello, World!");
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
        }
    }
}
