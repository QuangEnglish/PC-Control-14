using System.Text;

namespace DanhSach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // tạo list và thêm 5 thành phố
            List<string> thanhPho = new List<string>
            {
                "Hai Phong",
                "Bac GIang",
                "Bac Ninh",
                "Ha Noi",
                "Thai Nguyen"
            };
            // sắp xếp list
            thanhPho.Sort();

            Console.WriteLine("Thứ tự các thành phố trong list sắp xếp theo A-Z :");
            foreach (string sapXep in thanhPho)
            {
                Console.WriteLine(sapXep);

            }

            // xóa thành phố Ha Noi
            thanhPho.Remove("Ha Noi");

            // thêm 5 thành phố mới
            thanhPho.Add("Hai Duong");
            thanhPho.Add("Nam Dinh");
            thanhPho.Add("Ha Long");
            thanhPho.Add("Quang Ninh");
            thanhPho.Add("Tuyen Quang");

            Console.WriteLine("Thứ tự các thành phố trong list sau khi xóa 'Ha Noi' và thêm 5 thanh phố mới :");
            foreach (string danhSachMoi in thanhPho)
            {
                Console.WriteLine(danhSachMoi);

            }
            //Console.WriteLine("Hello, World!");
        }
    }
}
