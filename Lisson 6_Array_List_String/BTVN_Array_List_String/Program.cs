using System.Text;

namespace Mang
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // nhập từ người dùng kích thước mảng
            Console.WriteLine("Nhập kích thước của mảng : ");
            int soPhanTu = Convert.ToInt32(Console.ReadLine());

            int[] mang = new int[soPhanTu];

            int max = mang[0];
            int min = mang[0];
            int tong = 0;

            for (int i =0; i < soPhanTu; i++)
            {
                // nhập từ người dùng phần tử trong mảng
                Console.WriteLine($"Nhập phần tử số {i} là :");
                mang[i] = Convert.ToInt32(Console.ReadLine());

                if (max < mang[i]) max = mang[i];
                else if (min > mang[i]) min = mang[i];

                tong += mang[i];

            } 
            
            // số lớn nhất , nhỏ nhất , tổng
            Console.WriteLine($"Số lớn nhất là : {max}");
            Console.WriteLine($"Số nhỏ nhất là : {min}");
            Console.WriteLine($"Tổng các phần tử là : {tong}");
        }
    }
}
