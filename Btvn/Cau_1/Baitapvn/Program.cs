// See https://aka.ms/new-console-template for more information
using System.Text;

static class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("nhập vào một số nguyên ");
        int x = int.Parse(Console.ReadLine());
        if (x > 0 )
        {
            Console.WriteLine("Là số dương");
        }
        else if (x < 0)
        {
            Console.WriteLine("Là số âm");
        }
        else
        {
            Console.WriteLine("Là số 0");
        }
        
        
        
    }
}








