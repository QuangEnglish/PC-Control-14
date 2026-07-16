using System.Text;

namespace Danh_sach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding= Encoding.UTF8;
            Console.WriteLine("Hãy nhập 5 tp TTTW");
            int i = 0;
            List<string> Thanhpho = new List<string>();
            for (i = 0; i < 5; i++) { string s = Console.ReadLine(); Thanhpho.Add(s); }
            Console.WriteLine("Danh sách 5 TP là ");
            for (i = 0; i < 5; i++) { Console.WriteLine(Thanhpho[i]); }
            Thanhpho.Sort();
            Console.WriteLine("Danh sách sắp xếp lại:");
            for (i = 0; i < 5; i++) { Console.WriteLine(Thanhpho[i]); }
            Thanhpho.Remove("Hà Nội");
            Console.WriteLine("Hãy nhập thêm 4 TP nữa");
            for (i = 0; i < 4; i++) { string n = Console.ReadLine();Thanhpho.Add(n); }
            Console.WriteLine("Danh sách 9 TP là:");
            for (i = 0; i < 9; i++) { Console.WriteLine(Thanhpho[i]); }

        }
    }
}
