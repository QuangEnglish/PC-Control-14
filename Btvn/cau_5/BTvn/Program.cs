// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Nhập số lượng phần tử n: ");
        int n = int.Parse(Console.ReadLine());
        int soduong = 0;
        int soam = 0;
        int sokhong = 0;

        for (int i = 0; i < n; i++)

            Console.Write($"Nhập số thứ {i + 1}: ");
        int x = int.Parse(Console.ReadLine());
       
       
            if (x>0)
            {
                soduong++;
            }
            else if (x < 0)
            {
                soam++;
            }
            else
            {
                sokhong++;
            }
            {
                Console.WriteLine("kết quả");
                Console.WriteLine("so dương "+ soduong);
                Console.WriteLine("so dương " + soam);
                Console.WriteLine("so dương " + sokhong);
            }
        }
    }
}
