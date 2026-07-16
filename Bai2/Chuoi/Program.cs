using System.Text;
using System.Threading.Channels;

namespace Chuoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Nhập a,b hoặc c để vào bài tập tương ứng");
            string a=Console.ReadLine();
            switch (a) { case "a": Displaya(); break;
                case "b": Displayb(); break;
                case "c": Displayc();break;
            default: Console.WriteLine("Chỉ nhập a,b hoặc c");break;
            }
            }

        
        static string Displaya()
        {
            Console.WriteLine("Hãy nhập chuỗi");
            string i = Console.ReadLine();
            int a = 0;
            Console.WriteLine("Chuỗi được viết thành từng dòng như sau:");
            for (a = 0; a < i.Length; a++)
            {
                Console.WriteLine(i[a]);
            }
            return i;
        }
        static string Displayb()
        {
            Console.WriteLine("Hãy nhập chuỗi gồm khoảng trắng:");
            string n = Console.ReadLine();
            Console.WriteLine("Kết quả mỗi từ một dòng, bỏ khoảng trắng");
            for (int b = 0; b < n.Length; b++)
            {
                if (n[b] != ' ')
                {
                    Console.Write(n[b]);
                }
                else
                { Console.Write("\n"); }

            }
            return n;
        }
        static string Displayc()
        {
            Console.WriteLine("Hãy nhập vào một chuỗi");
            string c = Console.ReadLine();
            int b = 0;
            int a = 0;
            string ketqua = new string(c.Distinct().ToArray());

            for (a = 0; a < ketqua.Length; a++)
            {
                int dem = 0;

                for (b = 0; b < c.Length; b++)
                {
                    if (ketqua[a] == c[b]) { dem++; }

                }

                Console.WriteLine("Ký tự " + c[a] + " xuất hiện " + dem + " lần");


            }
            return c;
        }


    }

}
