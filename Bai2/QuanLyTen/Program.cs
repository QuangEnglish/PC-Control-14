using System.Text;

namespace QuanLyTen
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            List<string> tenHocSinh = new List<string> { "Anh", "Bình", "Cường", "Dũng", "Huy", "Lan"};
            Console.WriteLine(string.Join(" ,",tenHocSinh));
            Console.WriteLine();
            Console.WriteLine("Bước 1: Số lượng học sinh đã nhập là : " + tenHocSinh.Count);
            Console.WriteLine();

            //b2
            Console.WriteLine("Bước 2: Hiển thị bằng foreach");
            foreach(string i in tenHocSinh) 
            { 
                Console.WriteLine(i); 
            }
            //b3
            Console.WriteLine("Bước 3: Thêm tên Mỹ vào vị trí số 2 và hiển thị");
            tenHocSinh.Insert(2,"Mỹ");
            Console.WriteLine(string.Join(", ",tenHocSinh));
            Console.WriteLine();
            //b4
            Console.WriteLine("Bước 4: Xóa tên Huy và hiển thị");
            tenHocSinh.Remove("Huy");
            Console.WriteLine(string.Join(", ", tenHocSinh));
            Console.WriteLine();
            //b5
            Console.WriteLine("Bước 5: Hiển thị tên sau sắp xếp");
            tenHocSinh.Sort();
            Console.WriteLine(string.Join (", ", tenHocSinh));
            Console.WriteLine();
            //b6
            Console.WriteLine("Bước 6: Hiển thị lại list đảo ngược");
            tenHocSinh.Reverse();
            Console.WriteLine(string.Join(", ", tenHocSinh));
            Console.WriteLine();
            //b7
            Console.WriteLine("Bước 7: Tìm kiếm tên Anh ");
            if (tenHocSinh.Contains("Anh"))
            {
                Console.WriteLine("Tìm Thấy");
            }
            else { Console.WriteLine(" K tìm thấy"); }


            //Nâng cao
            Console.WriteLine("Nâng cao: Nhập vào 1 tên nếu đã có in ra thông báo nếu chưa thì thêm và in ra");
            Console.Write("Mời nhập tên: ");
            string ten = Console.ReadLine();
            if (tenHocSinh.Contains(ten))
            {
                Console.WriteLine("Tên đã tồn tại");
            }
            else
            {   tenHocSinh.Add(ten);
                Console.WriteLine("Đã thêm thành công");
            }
            Console.WriteLine(string.Join(", ",tenHocSinh));
        }
    }
}
