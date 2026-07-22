// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int x = 0;
        while (x <= 10)
        {
            Console.WriteLine("Giá trị số là " + x);
            x++;
        }
    }

}