using System.Text;

namespace Buoi_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.OutputEncoding = Encoding.UTF8;
            //Toán Tử Logic
            if ( 5 == 5 && 6 == 7) 
            {
                Console.WriteLine("Đúng");
            }
            else
            {
                Console.WriteLine("Sai");
            }

            // Toán tử 3 ngôi
            int x = 5;
            int y = 6;
            String result = x == y ? "x bằng y" : "x khác y";
            Console.WriteLine("giá trị result: " + result);

            // Toán tử gán
            int a = 10;
            a += 5;
            Console.WriteLine("Kết Quả = " + a);

            // Toán tử tăng giảm
            // a++ : sử dụng giá trị trước sau mới tăng
            // ++a : tăng giá trị trước rồi mới đi sử dụng

            int b = 5;
            Console.WriteLine($"Giá Trị b: {b++}");
            Console.WriteLine($"Giá Trị b++: {b}");

            Console.WriteLine($"Giá Trị ++b: {++b}");
            Console.WriteLine($"Giá Trị b: {b}");

            //Toán từ NUll
            string name = null;
            string nameV2 = "";
            string nameV3 = " "; // độ dùa ký tự bằng 1, chuỗi

            int? age = null; // nullbale value type
            // Nullbale<int> age = null;
            int defaultAge = age ?? 18;
            int total = age ?? 18; // nếu mà biến age là null thì tôi lấy mặc định giá trị là 18
            Console.WriteLine("giá trị total: " + total);
        }
    }
}
