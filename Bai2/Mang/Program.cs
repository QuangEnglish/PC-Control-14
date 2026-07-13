using System.Text;

namespace Mang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Mời nhập số phần tử của mảng: ");
            int soPhanTu = Convert.ToInt32(Console.ReadLine());
            double[] mang = new double[soPhanTu];

            double max = mang[0], min = mang[0], sum = mang[0];
            for (int i = 0; i < soPhanTu; i++)
            {
                Console.WriteLine("Phần tử thứ " + (i + 1) + " :");
                mang[i] = Convert.ToDouble(Console.ReadLine());

                sum += mang[i];
                if (mang[i] > max)
                    max = mang[i];
                if (mang[i] < min)
                    min = mang[i];
            }
            Console.Write("Mảng vừa nhập là: ");
            Console.Write(String.Join("  ", mang));
            Console.WriteLine();
            Console.WriteLine("Max = " + max);
            Console.WriteLine("Min = " + min);
            Console.WriteLine("Sum = " + sum);
        }
    }
}
