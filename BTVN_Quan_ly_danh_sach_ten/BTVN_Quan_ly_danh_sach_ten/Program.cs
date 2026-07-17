using System.Text;

namespace BTVN_Quan_ly_danh_sach_ten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //Bước 1: Tạo danh sách và thêm dữ liệu
            List<string> danhSach = new List<string>();

            danhSach.Add("Anh");
            danhSach.Add("Bình");
            danhSach.Add("Cường");
            danhSach.Add("Dũng");
            danhSach.Add("Huy");
            danhSach.Add("Lan");

            // Bước 2: In toàn bộ danh sách
            Console.WriteLine("Danh sách tên trong List");
            foreach (string danhSachten in danhSach)
            {
                Console.WriteLine(danhSachten);
            }


            // Bước 3: Chèn phần tử
            Console.WriteLine(" ");

            Console.WriteLine("Danh sách sau khi chèn thêm tên 'Hai' vị trí thứ 3");
            danhSach.Insert(2, "Hải");

            foreach (string danhSachtenMoi in danhSach)
            {
                Console.WriteLine(danhSachtenMoi);
            }

            // Bước 4: Xóa phần tử
            Console.WriteLine(" ");
            Console.WriteLine("Danh sách sau khi xóa tên 'Huy'");
            danhSach.Remove("Huy");

            foreach (string danhSachtenSauXoa in danhSach)
            {
                Console.WriteLine(danhSachtenSauXoa);
            }

            // Bước 5: Sắp xếp danh sách
            Console.WriteLine(" ");
            Console.WriteLine("Danh sách sau khi sắp xếp");
            danhSach.Sort();
            foreach (string danhSachtenSapXep in danhSach)
            {
                Console.WriteLine(danhSachtenSapXep);
            }

            // Bước 6: Đảo ngược danh sách
            Console.WriteLine(" ");
            Console.WriteLine("Danh sách sau khi đảo ngược");
            danhSach.Reverse();

            foreach (string danhSachtenDaoNguoc in danhSach)
            {
                Console.WriteLine(danhSachtenDaoNguoc);
            }

            // Bước 7: Kiểm tra danh sách có chứa "Anh" hay không
            Console.WriteLine(" ");
            Console.WriteLine("Kiểm tra danh sách có chứa tên 'Anh' hay không");
            if (danhSach.Contains("Anh"))
            {
                Console.WriteLine("Danh sách có chứa tên 'Anh'");
            }
            else
            {
                Console.WriteLine("Danh sách không chứa tên 'Anh'");
            }
        }
    }
}
