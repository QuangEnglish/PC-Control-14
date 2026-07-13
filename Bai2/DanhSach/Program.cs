using System.Text;

namespace DanhSach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            List<string> thanhPho = new List<string>();
            Console.WriteLine("Nhập số lượng thành phố");
            int a  = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("Thành phố "+(i+1) +" là");
                thanhPho.Add(Console.ReadLine());
            }
            Console.WriteLine("Cách thành phố bạn vừa nhập là: ");
            Console.WriteLine(string.Join(" ,", thanhPho));
            Console.WriteLine("Danh sách các thành phố sau khi sắp sếp: ");
            thanhPho.Sort();
            Console.WriteLine(string.Join(", ", thanhPho));
            thanhPho.Remove("Hà Nội");
            Console.WriteLine("Danh sách các thành phố sau khi xóa Hà Nội: ");
            Console.Write(string.Join(", ", thanhPho));
            Console.WriteLine("Mời Nhập thêm 5 thành phố: ");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Thành phố " + (i + 1) + " là");
                thanhPho.Add(Console.ReadLine());
            }
            Console.WriteLine("Danh sách các tất cả thành phố : ");
            Console.WriteLine(string.Join(", ",thanhPho));
        }
    }
}
