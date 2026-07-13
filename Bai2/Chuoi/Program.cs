using System.Text;

namespace Chuoi
{
    internal class Program
    {
        static void BaiA()
        {
            Console.WriteLine("Mời nhập chuỗi: ");
            string chuoiA = Console.ReadLine();
            foreach (char i in chuoiA)
            {
                Console.WriteLine(i);
            }
        }

        static void BaiB(string a)
        {
            string chuoiB = a.Replace(" ", "");
            foreach (char i in chuoiB)
            {
                Console.WriteLine(i);
            }
        }

        static void BaiC(string a)
        {

            int[] dem = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                int cout = 0;
                for (int j = 0; j < a.Length; j++)
                {

                    if (a[j] == a[i])
                    {
                        cout++;
                    }
                }
                dem[i] = cout;
            }
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i] + " xuất hiện " + dem[i] +" lần");
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("A: Nhập vào chuỗi và in mỗi ký tự ra 1 dòng ");
            Console.WriteLine("B: Nhập vào chuỗi và in mỗi ký tự ra 1 dòng và loại bỏ khoảng trắng");
            Console.WriteLine("C: Nhập vào chuỗi và đếm số lần xuất hiện ký tự ");
            char luaChon = Convert.ToChar(Console.ReadLine());

            switch (luaChon)
            {
                case 'a':
                    BaiA();
                    break;
                case 'b':
                    Console.WriteLine("Mời nhập chuỗi");
                    string chuoiB = Console.ReadLine();
                    BaiB(chuoiB);
                    break;
                case 'c':
                    Console.WriteLine("Mời nhập chuỗi");
                    string chuoiC = Console.ReadLine();
                    BaiC(chuoiC);
                    break;
            }

        }
    }
}
