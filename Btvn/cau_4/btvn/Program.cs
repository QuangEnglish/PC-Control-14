// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int x =int.Parse(Console.ReadLine());
        
        int tong = 0;
        for (int i = 0; i < x ; i++)
        {
            tong +=   i;
            Console.WriteLine(  "Tổng các số là: "+tong );
        }
    }

}