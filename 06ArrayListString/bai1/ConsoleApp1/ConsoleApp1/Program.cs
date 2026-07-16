namespace Mang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap vao kich thuoc mang: ");
            int arSize = Convert.ToInt32(Console.ReadLine());
            int[] arrMang = new int[arSize];
            for (int i = 0; i < arSize; i++)
            {
                arrMang[i] = Convert.ToInt32(Console.ReadLine());
            }

            int max = int.MinValue;
            int min = int.MaxValue;
            int sum = 0;
            foreach (int i in arrMang)
            {
                sum += i;
                if (i > max) max = i;
                if (i < min) min = i;
            }
            Console.WriteLine($"so lon nhat: {max}");
            Console.WriteLine($"so nho nhat: {min}");
            Console.WriteLine($"tong cua mang: {sum}");
        }
    }
}
