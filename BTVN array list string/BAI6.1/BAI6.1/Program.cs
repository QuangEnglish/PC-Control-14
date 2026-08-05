namespace BAI6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap vao so luong phan tu cua mang: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap phan tu thu " + i + ": ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            int max = arr[0];
            int min = arr[0];
            int tong = 0;

            for (int i = 0; i < n; i++)
            {
                tong += arr[i];

                if (arr[i] > max)
                {
                    max = arr[i];
                }

                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            Console.WriteLine("So lon nhat la: " + max);
            Console.WriteLine("So nho nhat la: " + min);
            Console.WriteLine("Tong cac phan tu la: " + tong);

            Console.ReadLine();
        }
    }
}
