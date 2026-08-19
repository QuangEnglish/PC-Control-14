using System.Text;

namespace Lesson5_CauDieuKhien_VongLap
{
    internal class Program
    {
        static void Display(int tuoi)
        {
            if(tuoi < 18)
            {
                Console.WriteLine("Chưa đủ tuổi");
                int a = 0;
                while (true)
                {
                    Console.WriteLine("Nhập 1 số: ");
                    a = Convert.ToInt32(Console.ReadLine());
                    if (a % 2 == 0)
                    {
                        Console.WriteLine("Đã tìm thấy số chẵn");
                        //break; // chỉ thoát vòng lặp chứa nó
                        return; // không chỉ thoát khỏi vòng lặp mà nó còn thoát khỏi toàn 
                        // bộ phương thức
                    }
                    Console.WriteLine("Đây là số lẻ");
                }
                //return; // mang ý nghĩa không trả về giá trị mà nó để kết thúc chương trình sớm
            }
            Console.WriteLine("dfsdfdsfdsf");
            Console.WriteLine("Đủ tuổi");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Display(17);
            // 
            // Câu điều khiển 
            // 1. If - else if - else
            //int a = 6;
            //if(a == 6)
            //{
            //    Console.WriteLine("Đúng");
            //}
            //else
            //{
            //    Console.WriteLine("Sai");
            //}
            //// switch -case
            String menu = Console.ReadLine();
            switch (menu)
            {
                case "Bài 1":
                    Console.WriteLine("Thêm học viên");
                    break;
                case "Sửa":
                    Console.WriteLine("Sửa thông tin học viên");
                    break;
                case "Xóa":
                    Console.WriteLine("Xóa học viên");
                    break;
                default:
                    Console.WriteLine("Hủy bỏ thao tác");
                    break;
            }

            // < 4: yếu
            // < 5: trung bình
            // < 8: khá
            //int diem = Convert.ToInt32(Console.ReadLine());
            //switch (diem)
            //{
            //    case < 4:
            //        Console.WriteLine("Yếu");
            //        break;
            //    case < 5:
            //        Console.WriteLine("trung bình");
            //        break;
            //    case < 8:
            //        Console.WriteLine("khá");
            //        break;
            //    default:
            //        Console.WriteLine("Không xác định");
            //        break;
            //}

            // Vòng lặp 
            // 1. Vòng lặp for / foreach
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("Giá trị của i là: "+i);  // 0 -> 9
            //}

            // for(khởi tạo;điều kiện;cập nhật)
            // khởi tạo: chạy 1 lần duy nhất khi vòng lặp bắt đầu
            // điều kiện: mỗi vòng đều kiểm tra, đúng thì chạy tiếp còn sai thì dừng
            // cập nhật: mỗi vòng sẽ thay đổi biến đếm

            //int nhapSo = Convert.ToInt32(Console.ReadLine());
            //for (int i = 0; i < nhapSo; i++)
            //{
            //    if (i == 7)
            //    {
            //        Console.WriteLine("Đã tìm được số 7");
            //    } else if (i == 9)
            //    {
            //        Console.WriteLine("Đã tìm được số 9");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Chưa tìm được số");
            //    }
            //}

            // Cấu trúc dạng mảng
            int[] arrNumber = { 6, 5, 4, 3, 2, 8 };  // 1 mảng số nguyên
            //int phanTuThuNhat = arrNumber[0];
            //Console.WriteLine("Phần tử thứ nhất là: "+phanTuThuNhat);
            //int phanTuCuoiCung = arrNumber[5];
            //Console.WriteLine("Phần tử cuối cùng trong mảng là: "+phanTuCuoiCung);

            // Đề bài: tính tổng các phần tử trong mảng: 28
            int ketQua = 0;

            // vòng lặp for thường: dùng khi cần thay đổi phần tử của mảng hoặc danh sách, tại
            // vì cho truy cập chỉ số
            //for (int i = 0; i < arrNumber.Length; i++)
            //{
            //    // i ở đây là chỉ sổ
            //    ketQua += arrNumber[i];
            //    arrNumber[i] += 1;
            //    Console.WriteLine("Giá trị phần tử trong mảng là: " + arrNumber[i]);
            //}
            //Console.WriteLine("Kết quả là A: " + ketQua);

            // vòng lặp foreach: dùng để duyệt từng phần tử 
            //foreach (int i in arrNumber) // i đại diện cho từng phần tử trong mảng
            //{
            //    // i ở đây là đóng vai trò như 1 phần tử, giá trị của phần tử
            //    Console.WriteLine("Giá trị phần tử trong mảng là: " + i);
            //}


            // Vòng lặp while
            // dùng khi không biết trước sẽ lặp bao nhiêu lần
            int a = 0;
            int b = 0;
            //while (b == 0)
            //{
            //    a = Convert.ToInt32(Console.ReadLine());
            //    // phải có điều kiện dừng
            //    if (a % 2 == 0)
            //    {
            //        Console.WriteLine("Đã tìm thấy số chẵn");
            //        b = 1;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Đã tìm thấy số lẻ");
            //    }
            //}

            //while (true)
            //{
            //    Console.WriteLine("Nhập 1 số: ");
            //    a = Convert.ToInt32(Console.ReadLine());
            //    if (a % 2 == 0)
            //    {
            //        Console.WriteLine("Đã tìm thấy số chẵn");
            //        break;
            //    }
            //    Console.WriteLine("Đây là số lẻ");
            //}


            // Từ khóa return, break, continue
            // break: tác dụng để dừng vòng lặp gần nhất (chứa nó),
            // thoát khỏi điều kiện trong switch case

            // continue: chỉ bỏ qua vòng lặp hiện tại của vòng lặp gần nhất (chứa nó),
            // không thoát vòng for

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Vòng lặp ngoài: {i}");

                for (int j = 1; j <= 5; j++)
                {
                    if (j % 2==0)
                    {
                        continue;
                    }

                    Console.WriteLine($"  j = {j}");
                }

                Console.WriteLine();
            }

            // vòng lặp 1: i = 1; j = 1, j =2, j=3
            // vòng lặp 2: i = 2; j = 1, 2, 3
            // vòng lặp 3: i = 3; j = 1,2,3

            // vòng lặp 1: i = 1; j = 1, 3, 5
            // vòng lặp 2: i = 2; j = 1, 3, 5
            // vòng lặp 3: i = 3; j = 1, 3, 5



        }
    }
}
