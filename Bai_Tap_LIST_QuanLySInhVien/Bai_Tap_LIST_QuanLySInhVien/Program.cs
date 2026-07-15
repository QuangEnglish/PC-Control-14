using System.Text;

namespace Bai_Tap_LIST_QuanLySInhVien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.WriteLine($"Nhập MENU hoặc Thoát:");
                int menu = Convert.ToInt32(Console.ReadLine());
                List<string> danhSachSinhVien = new List<string>();
                switch (menu)
                {
                    case 1:

                        
                        Console.WriteLine($"Nhập tổng số sinh viên  :");
                        int soSV = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < soSV; i++)
                        {
                            Console.WriteLine($"Nhập tên sinh viên {i} :");
                            string tenSV = Console.ReadLine();
                            danhSachSinhVien.Add(tenSV);
                            Console.WriteLine("Đã thêm tên SV thành công");
                            Console.WriteLine("Sinh viên số 1 : "+string.Join(" ",danhSachSinhVien));
                        }
                        break;
                    case 2:
                        Console.WriteLine("Thoát thành công");
                        return ;

                       // break;
                }
            }

            Console.WriteLine("Hello, World!");
        }
    }
}
