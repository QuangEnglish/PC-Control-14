namespace _04HamVaPhamViTruyCapCuaHam
{
    internal class Program
    {
        #region Ham khong tra ve gia tri va khong co tham so
        static void Display()
        {
            int x = 0;
            int y = 10;
            int z = x + y;
            Console.WriteLine($"giá trị của z {z}");
        }
        #endregion
        #region Ham khong tra ve gia tri va co tham so
        static void DisplayV2(double x, double y)
        {
            double z = x + y;
            Console.WriteLine($"giá trị của z {z}");
        }
        #endregion
        #region Ham tra ve gia tri va khong co tham so
        static float TinhDienTich()
        {
            float chieudai = 4.5f;
            float chieurong = 2.5f;
            float dientich = chieudai * chieurong;
            return dientich;
        }

        #endregion

        static void TangGiaTri(int a)
        {
            a += 10;
        }
        static void TanGiaTriRef(ref int a)
        {
            a += 10;
        }
        static void Thaydoichuoi(string a)
        {
            a = "Hoang ";
        }
        static void ThaydoichuoiRef(ref string a)
        {
            a = "Hoang ";
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            int a = 10;
            TangGiaTri(a);
            Console.WriteLine( $"tang gia tri a: {a}");
            TanGiaTriRef(ref a);
            Console.WriteLine(  $"tan gia tri ref a : {a}");

            string b = "nguyen";
            Thaydoichuoi(b);
            Console.WriteLine($"thay doi chuoi b: {b}");
            ThaydoichuoiRef(ref b);
            Console.WriteLine($"thay doi chuoi ref B: {b}");


        }
    }
}
