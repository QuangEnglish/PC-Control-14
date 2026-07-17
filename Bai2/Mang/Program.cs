namespace Mang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap vao kich thuoc cua mang: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int[] arrNumber = new int[a];
            Console.WriteLine("Nhap vao cac phan tu cua mang: ");
            for (int i = 0; i < arrNumber.Length; i++) 
            {
                Console.WriteLine($"Phan tu {i}");
                arrNumber[i] = Convert.ToInt32(Console.ReadLine());
            }

            // hien cac phan tu
            Console.WriteLine("Phan tu lan luot la: ");
            for (int i = 0; i < arrNumber.Length; i++)
            {
                Console.Write(" "+arrNumber[i]);
            }
            Console.WriteLine("\t");

            //tim so lon nhat
            int max = arrNumber[0];
            for (int i = 0; i < arrNumber.Length; i++) 
            {
                if (arrNumber[i] > max) max = arrNumber[i];
            }
            Console.WriteLine("So lon nhat la: "+max);

            // tim so nho nhat
            int min = arrNumber[0];
            for (int i = 0; i < arrNumber.Length; i++)
            {
                if (arrNumber[i] < min) min = arrNumber[i];
            }
            Console.WriteLine("So lon nhat la: " +min);

            //tong cac phan tu trong mang
            int tong = 0;
            for (int i = 0; i < arrNumber.Length; i++)
            {
                 tong += arrNumber[i];
            }
            Console.WriteLine("So lon nhat la: " + tong);
        }
    }
}
