namespace Mang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hãy nhập kích thước mảng");
            int kichthuocmang = Convert.ToInt32(Console.ReadLine());
            int[] mang = new int[kichthuocmang];
            Console.WriteLine("Hãy nhập phần tử trong mảng");
            for (int i = 0; i < kichthuocmang; i++)
            {

                mang[i] = Convert.ToInt32(Console.ReadLine());

            }
            int max = mang.Max();
            Console.WriteLine("Số lớn nhất trong mảng là: " + max);
            int min = mang.Min();
            Console.WriteLine("Số nhỏ nhất trong mảng là: " + min);
            int tong = mang.Sum();
            Console.WriteLine("Tổng các số trong  mảng là: " + tong);

        }
    }
}
