using System.Text;

namespace Lesson3_Method_Scope
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

        #region Hàm không trả về giá trị, có tham số
        static void DisplayV2(int x, int y)
        {
            int z = x + y;
            Console.WriteLine($"giá trị z: {z}");
        }
        #endregion

        #region hàm có trả về giá trị, không tham số
        static float TinhDienTichHCN()
        {
            float chieuDai = 4.5F;
            float chieuRong = 2.5F;
            float dienTich = chieuDai * chieuRong;
            return dienTich;
        }
        #endregion

        #region hàm có trả về giá trị, có tham số
        static float TinhDienTichHCNV2(float chieuDai, float chieuRong)
        {
            //float dienTich = chieuDai * chieuRong;
            //return dienTich;
            return chieuDai * chieuRong;
        }
        #endregion




        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; 
            // Hàm là 1 khối code được đặt tên

            // hàm không có kiểu trả về, không có tham số
            Display();

            // hàm không có kiểu trả về, có tham số
            int x = 0;
            double y = 10;
            DisplayV2(x, (int)y);

            // Hàm có kiểu trả về, không tham số
            float dienTich = TinhDienTichHCN();
            Console.WriteLine("Diện tích HCN là: "+dienTich);

            // Hàm có kiểu trả về, có tham số
            float chieuDai = 4.5F;
            float chieuRong = 2.5F;
            float dienTichV2 = TinhDienTichHCNV2(chieuDai, chieuRong);
            Console.WriteLine("Diện tích HCN V2 là: " + dienTichV2);

            decimal price = 19.06666M;



        }
    }
}
