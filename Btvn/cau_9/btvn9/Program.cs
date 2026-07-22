// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("nhập số phần tử mảng");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"nhập phần tử thứ {i + 1}");
            arr[i] = int.Parse(Console.ReadLine());

        }
        int max = arr[0];
        int min = arr[0];
        int tong = 0;
        for (int i = 0; i < n; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
            if (arr[i] < min)
            {
                min = arr[i];
            }
            tong += arr[i];
        }
        double trungBinh = (double)tong / n;
        Console.WriteLine("số lớn nhất là "+ max);
        Console.WriteLine("số nhỏ nhất là " + min);
        Console.WriteLine("giá trị trung bình " + trungBinh);
        Console.WriteLine("Mảng theo thứ tự ngược lại:");
        for (int i = n - 1; i >= 0; i--)
        {
            Console.Write(arr[i] + " ");
        }
    }
}
