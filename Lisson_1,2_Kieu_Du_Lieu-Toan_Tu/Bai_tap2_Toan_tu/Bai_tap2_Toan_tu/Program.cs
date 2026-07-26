namespace Bai_tap2_Toan_tu
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Nhap so thu nhat:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap toan tu:");
            char b = Console.ReadLine()[0];
            Console.WriteLine("Nhap so thu hai:");
            double c = double.Parse(Console.ReadLine());

            //int tong = a + c;
            //double hieu = a - c;
            //decimal tich = a * c;
            //decimal thuong = a / c;
            //int du = a % c;


            if (b == '+')
            {
                Console.WriteLine("Tong :");
                Console.WriteLine(a + c);
            }
            else if (b == '-')
            {
                Console.WriteLine("Hieu :");
                Console.WriteLine(a - c);
            }
            else if (b == '*')
            {
                Console.WriteLine("Tich :");
                Console.WriteLine(a * c);
            }
            else if (b == '/')
            {
                Console.WriteLine("Thuong :");
                Console.WriteLine(a/c);
            }
            else if (b == '%')
            {
                Console.WriteLine("Du :");
                Console.WriteLine(a % c);
            }
        }

    }
}

