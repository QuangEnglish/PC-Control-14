using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;

namespace btvn16_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Check phần 1 hay 2");
            int c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 1: Displaycoban(); break;
                case 2: Displaynangcao(); break;
                default: Console.WriteLine("Hãy nhập lại"); break;
            }

        }
        static List<string> Displaycoban()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Hãy nhập tên các nhân viên");
            List<string> Tennhanvien = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                String a = Console.ReadLine();
                Tennhanvien.Add(a);
            }
            Console.WriteLine("Số lượng nhân viên là: " + Tennhanvien.Count);
            Console.WriteLine("Danh sách nhân viên là: ");
            foreach (string a in Tennhanvien) { Console.WriteLine(a); }
            Console.WriteLine("Hãy nhập tên nhân viên mới");
            Tennhanvien.Insert(2, Console.ReadLine());
            Console.WriteLine("Danh sách mới:");
            foreach (string a in Tennhanvien) { Console.WriteLine(a); }
            Tennhanvien.Remove("Huy");
            Console.WriteLine("Danh sách không có Huy");
            foreach (string a in Tennhanvien) { Console.WriteLine(a); }
            Tennhanvien.Sort();
            Console.WriteLine("Danh sách A-Z");
            foreach (string a in Tennhanvien) { Console.WriteLine(a); }
            Tennhanvien.Reverse();
            Console.WriteLine("Danh sách Z-A");
            foreach (string a in Tennhanvien) { Console.WriteLine(a); }
            Console.WriteLine("Nhập tên nhân viên cần tìm");
            bool b = Tennhanvien.Contains("Tên Anh có xuất hiện trong danh sách không");
            if (b = true) { Console.WriteLine("Tìm thấy"); }
            else { Console.WriteLine("Không tìm thấy"); }
            return Tennhanvien;
        }
        static List<string> Displaynangcao()
        {
            List<string> Danhsach = new() { "anh", "binh", "duong", "hung" };
            Console.WriteLine("Bạn muốn thêm mấy cái tên mới");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hãy thêm");
            for (int j = 0; j < i; j++)
            {
                string s = Console.ReadLine();
                bool a = Danhsach.Contains(s);
                if (a == true) { Console.WriteLine("Tên đã tồn tại"); }
                else { Console.WriteLine("Đã thêm"); Danhsach.Add(s); }

            }
            Console.WriteLine("Danh sách mới sau khi thêm");
            foreach (string a in Danhsach) { Console.WriteLine(a); }
            return Danhsach;

        }
    }
}
