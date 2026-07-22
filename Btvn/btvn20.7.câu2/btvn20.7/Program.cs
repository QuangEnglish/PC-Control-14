// See https://aka.ms/new-console-template for more information
using System.Collections;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Queue<string> luongSx = new Queue<string>();
        luongSx.Enqueue(" kiểm tra cảm biến A ");
        luongSx.Enqueue(" Gửi Cảnh Báo ");
        luongSx.Enqueue(" Cập nhật cơ sở dữ liệu ");
        foreach (string item in luongSx)
        {
            Console.WriteLine(item);
        }
        while (luongSx.Count > 0)
        {
            string item = luongSx.Dequeue();
            Console.WriteLine($"Đang xử lý: {item}");
        }
    }
}