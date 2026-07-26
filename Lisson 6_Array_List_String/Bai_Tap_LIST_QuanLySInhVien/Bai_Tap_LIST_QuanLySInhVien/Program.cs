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
                Console.WriteLine($"Nhập 1 để vào MENU hoặc 2 để Thoát:");
                int menu = Convert.ToInt32(Console.ReadLine());
                List<string> danhSachSinhVien = new List<string>();
                switch (menu)
                {
                    case 1:

                        
                        Console.WriteLine($"Nhập tổng số sinh viên  :");
                        int soSV = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < soSV; i++)
                        {

                            while (true)
                            {
                                Console.WriteLine($"Nhập tên sinh viên {i + 1} :");
                                string tenSV = Console.ReadLine();
                                if (danhSachSinhVien.Contains(tenSV))
                                {
                                    Console.WriteLine("Tên sinh viên đã tồn tại");
                                   // break;
                                    continue;
                                }
                                else
                                {
                                    danhSachSinhVien.Add(tenSV);
                                    Console.WriteLine("Đã thêm tên SV thành công");
                                    Console.WriteLine($"Sinh viên số {i + 1} : " + danhSachSinhVien[i]);
                                    break;
                                }
                            }    

                        }
                        break;
                    case 2:
                        Console.WriteLine("Thoát thành công");
                        return ;

                       // break;
                }
            }

            //Console.WriteLine("Hello, World!");
        }
    }
}
