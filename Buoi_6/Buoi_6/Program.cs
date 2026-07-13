using System.Text;

namespace Buoi_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.OutputEncoding = Encoding.UTF8;
            /*
            //switch - case
            String menu = Console.ReadLine();
            switch (menu)
            {
                case "Thêm": Console.WriteLine("Thêm học viên");            break;
                case "Sửa":  Console.WriteLine("Sửa thông tin học viên");   break;
                case "Xóa":  Console.WriteLine("Xóa học viên");             break;
                default:     Console.WriteLine("Hủy bỏ thao tác");          break;
            }

            // Vòng lặp
            //1. Vòng lặp fỏ / foreach
            for (int i = 0; i < 10; i++) Console.WriteLine("Giá trị của i là: "+i);

            int nhapSo = Convert.ToInt32(Console.ReadLine());
            for(int i=0; i<nhapSo; i++)
            {
                if (i == 7) Console.WriteLine("Đã tìm dc so 7");
                else if (i == 9) Console.WriteLine("Đã tìm dc số 9");
                else Console.WriteLine("Chưa tìm dc số");
            }
            */
            //Cấu trúc dạng mảng
            int[] arrNumber = { 6, 5, 4, 3, 2, 8 };
            //int phanTuThuNhat = arrNumber[0];
            //Console.WriteLine("Phần tử thứ nhất là: " + phanTuThuNhat);
            //Console.WriteLine("Phần tử cuối cùng trong mảng là: " + arrNumber[5]);

            //// Đề bài: Tính tổng các phần tử trong mảng: 28
            //int tongCuaMang = 0;
            ////Vòng lặp for thường dùng khi cần thay đổi từng phần tử của mnảng
            ////tại vì cho truy cập chỉ số
            //for (int i = 0; i < arrNumber.Length; i++) // i ở đây là chỉ số
            //{
            //    tongCuaMang += arrNumber[i];
            //    arrNumber[i] += 1;
            //    Console.WriteLine("Cộng 1 cho từng phần tử của mảng: " + arrNumber[i]);
            //}
            //Console.WriteLine("Tổng của mảng là: " + tongCuaMang);

            //Vòng lặp foreach dùng duyệt từng phần tử
            //foreach (int i in arrNumber) // i ở đây là đại diện cho từng phần tử trong mảng
            //{
            //    tongCuaMang += i;
            //}
            //Console.WriteLine("Tổng của mảng là: " + tongCuaMang);

            // Vòng lặp while
            // dùng khi ko biết trước sẽ lặp bao nhiêu lần
            //int a = Convert.ToInt32(Console.ReadLine());
            //while (a < 8)
            //{
            //    Console.WriteLie("Nhập Tiếp");
            //    // phải có điều kiện dừng
            //    a++;
            //}

            while (true)
            {
                Console.WriteLine("Nhập 1 số");
                int a = Convert.ToInt32(Console.ReadLine());
                if (a % 2 == 0)
                {
                    Console.WriteLine("đây là số chẵn"); break;
                }
                Console.WriteLine("đây là số lẻ");


                // Vòng lặp do while              
            }
            // Từ khóa return, break, continue
            // break: tác dụng để dùng vòng lặp gần nhất (chứa nó)
            // continue: chi bỏ qua vòng lặp hiện tại của vòng lặp gần nhất (chứa nó), ko thoát vòng lặp
            // return: 
            if (tuoi < 18)
            {
                Console.WriteLine("Trẻ vị thành niên");
                int a = 0;
                while (true)
                {
                    Console.WriteLine("Nhập 1 số: ");
                    a= Convert.ToInt32(Console.ReadLine()); 
                    if(a%2 = 0)

                }
                return; // không chỉ thoát khỏi vòng lặp mà còn thoát khỏi toàn bộ phương thức.
            }
            Console.WriteLine("Trưởng thành");
        }
    }
}