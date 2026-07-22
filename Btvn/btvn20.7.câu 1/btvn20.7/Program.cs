// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Runtime.ConstrainedExecution;


internal class Program
{
   internal static void Main(string[] args)
        
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Queue<string> spGiaCong = new Queue<String>();
        Console.Write("Nhập số lượng sản phẩm: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Nhập tên phôi thứ " + (i + 1) + ":");
            string ten = Console.ReadLine();
            spGiaCong.Enqueue(ten);
        }
      
        foreach (var item in spGiaCong)
        {
            Console.WriteLine("Tên " +item);
        }
        while (spGiaCong.Count > 0)
        {
            string ten = spGiaCong.Dequeue();
            Console.WriteLine("Tên phôi được lấy ra: " + ten);
        }
    }
}