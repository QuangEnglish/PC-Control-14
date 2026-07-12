using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan6
{
      /*    Bài 1: If/Else Đơn Giản
            Viết chương trình nhập vào một số nguyên và kiểm tra:
            Nếu số > 0: in "Số dương"
            Nếu số< 0: in "Số âm"
            Nếu số = 0: in "Số không"
            Bài 2: Switch Case Cơ Bản
            Viết chương trình nhập vào một số từ 1-7 và in ra thứ trong tuần tương ứng.
            1: Chủ Nhật, 2: Thứ Hai, ..., 7: Thứ Bảy
            Nếu không hợp lệ: in "Không hợp lệ
            Bài 3: While Loop Đơn Giản
            Viết chương trình in ra các số từ 1 đến 10 bằng vòng lặp while.
            Bài 4: For Loop Cơ Bản
            Viết chương trình tính tổng các số từ 1 đến n (n nhập từ bàn phím).
            Bài 5: Array Cơ Bản
            Tạo một mảng 5 số nguyên, nhập giá trị từ bàn phím và in ra màn hình
            Bài 6: Kết Hợp If/Else và For Loop
            Viết chương trình nhập vào n số nguyên và đếm:
            Có bao nhiêu số dương
            Có bao nhiêu số âm
            Có bao nhiêu số bằng 0
            Bài 7: Switch Case với Phép Tính Viết máy tính đơn giản:
            Nhập 2 số a, b và phép toán(+, -, *, /) Dùng switch case để thực hiện phép tính Kiểm tra chia cho 0
            Bài 8: While Loop với Break/Continue
            Viết chương trình:
            Nhập các số từ bàn phím cho đến khi nhập số âm(dùng while) Bỏ qua các số chẵn(dùng continue)
            Tính tổng các số lẻ dương
            Bài 9: Array với For Loop
            Cho mảng số nguyên, viết chương trình:
            Tìm số lớn nhất và nhỏ nhất
            Tính trung bình cộng
            In ra các phần tử theo thứ tự ngược lại
            
            Bài 10: Kết Hợp If/Else và Array Viết chương trình phân loại điểm học sinh:
            Nhập điểm cho n học sinh(mảng) Đếm số học sinh: Giỏi(>=8), Khá(6.5-7.9), Trung bình(5-6.4), Yếu(<5)
      */
    internal class Program
    {
      
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            
            while (true)
            {
                Console.WriteLine(" Hãy chọn chương trình bạn muốn chạy: ");
                Console.WriteLine(" Bài 1: If/Else Đơn Giản");
                Console.WriteLine(" Bài 2: Switch Case Cơ Bản");
                Console.WriteLine(" Bài 3: While Loop Đơn Giản");
                Console.WriteLine(" Bài 4: For Loop Cơ Bản");
                Console.WriteLine(" Bài 5: Array Cơ Bản");
                Console.WriteLine(" Bài 6: Kết Hợp If/Else và For Loop");
                Console.WriteLine(" Bài 7: Switch Case với Phép Tính");
                Console.WriteLine(" Bài 8: While Loop với Break/Continue");
                Console.WriteLine(" Bài 9: Array với For Loop");
                Console.WriteLine(" Bài 10: Kết Hợp If/Else và Array");
                Console.WriteLine(" Nhập số bài bạn muốn chạy (1-10) hoặc nhập 0 để thoát: ");
                string Select =Console.ReadLine();
                switch (Select)
                {
                    case "1":
                        Bai_1();
                        break;
                    case "2":
                        Bai_2();
                        break;
                    case "3":
                        Bai_3();
                        break;
                    case "4":
                        Bai_4();
                        break;
                    case "5":
                        Bai_5();
                        break;
                    case "6":
                        Bai_6();
                        break;
                    case "7":
                        Bai_7();
                        break;
                    case "8":
                        Bai_8();
                        break;
                    case "9":
                        Bai_9();
                        break;
                    case "10":
                        Bai_10();
                        break;
                    case "0":
                        Console.WriteLine("Thoát chương trình.");
                        return;
                }

            }
        }
        //-------tim so nguyen
        static void Bai_1()
        {
            Console.WriteLine( "Nhập một số nguyên: ");

           int so =Convert.ToInt32 (Console.ReadLine());

            if (so < 0) Console.WriteLine("Số âm");
            else if (so > 0) Console.WriteLine("Số dương");
            else Console.WriteLine("Số không");
          //  Console.WriteLine("Nhấn phím bất kỳ để tiếp tục...");
            Console.WriteLine("----------------------------------------------");
        }
        static void Bai_2()
        {
            Console.WriteLine("Nhập một số từ 1-7: ");
            int so = Convert.ToInt32(Console.ReadLine());
            if ((so < 0) && (so > 7))
            {
                Console.WriteLine("Không hợp lệ");
                
            }
            else
            {
                switch (so)
                {
                    case 1:
                        Console.WriteLine("Chủ Nhật");
                        break;
                    case 2:
                        Console.WriteLine("Thứ Hai");
                        break;
                    case 3:
                        Console.WriteLine("Thứ Ba");
                        break;
                    case 4:
                        Console.WriteLine("Thứ Tư");
                        break;
                    case 5:
                        Console.WriteLine("Thứ Năm");
                        break;
                    case 6:
                        Console.WriteLine("Thứ Sáu");
                        break;
                    case 7:
                        Console.WriteLine("Thứ Bảy");
                        break;
                }
            }
            Console.WriteLine("----------------------------------------------");
        }
        static void Bai_3()
        {
            Console.WriteLine("In ra các số từ 1 đến 10: ");
            while (true) 
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine(i);
                }
                break;
            }
            Console.WriteLine("----------------------------------------------");
        }
        static void Bai_4()
        {
            Console.WriteLine("Nhập một số nguyên n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            Console.WriteLine("Tổng các số từ 1 đến {0} là: {1}", n, sum);
            Console.WriteLine("----------------------------------------------");
        }
        static void Bai_5()
        {
            Console.WriteLine("Nhập 5 số nguyên: ");
            int[] arr = new int[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Nhập số thứ {0}: ", i + 1);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Các số bạn đã nhập là: ");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(arr[i]);
            }

            Console.WriteLine("----------------------------------------------");
        }
        static void Bai_6()
        {
            Console.WriteLine("Nhập số lượng số nguyên n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int SoDuong = 0;
            int SoAm = 0;
            int SoKhong = 0;
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhập số thứ {0}: ", i + 1);
                arr[i] = Convert.ToInt32(Console.ReadLine());

            }
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > 0) SoDuong++;
                else if (arr[i] < 0) SoAm++;
                else SoKhong++;
            }
            Console.WriteLine(" Số lượng số dương: {0}", SoDuong);
            Console.WriteLine(" Số lượng số âm: {0}", SoAm);
            Console.WriteLine(" Số lượng số bằng 0: {0}", SoKhong);
            Console.WriteLine("----------------------------------------------");
        }

        static void Bai_7()
        {
            Console.WriteLine("Nhập 2 số a, b ");
            Console.WriteLine("Nhập số a: ");
             int a=Convert.ToInt32 ( Console.ReadLine());
            Console.WriteLine("Nhập số b: ");
               int b= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nhập phép toán (+, -, *, /): ");

            string pt = Console.ReadLine();
            switch (pt)
            {
                case "+":
                    Console.WriteLine("Kết quả: {0}", a + b);
                    break;
                case "-":
                    Console.WriteLine("Kết quả: {0}", a - b);
                    break;
                case "*":
                    Console.WriteLine("Kết quả: {0}", a * b);
                    break;
                case "/":
                    if (b == 0)
                    {
                        Console.WriteLine("Không thể chia cho 0");
                    }
                    else
                    {
                        Console.WriteLine("Kết quả: {0}", a / b);
                    }
                    break;
                default:
                    Console.WriteLine("Phép toán không hợp lệ");
                    break;
            }
            Console.WriteLine("----------------------------------------------");
        }
        static void Bai_8()
        {
            Console.WriteLine("Nhập các số (nhập số âm để dừng): ");
            int tongsoleduong = 0;
            while (true)
            {
                Console.Write("Nhập số: ");
                int so = Convert.ToInt32(Console.ReadLine());
                if (so < 0)
                {
                    break;
                }
                else if (so > 0)
                {
                    if (so % 2 != 0)
                    {
                        tongsoleduong += so;
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.WriteLine("Tổng các số lẻ dương là: {0}", tongsoleduong);
            }
                Console.WriteLine("----------------------------------------------");
            
        }
        static void Bai_9()
        {
            Console.WriteLine("Tìm số lớn nhất và nhỏ nhất trong mảng :   ");
            Console.WriteLine("Nhập số lượng phần tử của mảng: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for(int i = 0; i < n; i++)
            {
                Console.Write("Nhập phần tử thứ {0}: ", i + 1);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
             int MAX = arr[0];
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > MAX)
                {
                    MAX = arr[i];
                }
            }
            Console.WriteLine("Số lớn nhất trong mảng là: {0}", MAX);
            int Min = arr[0];
            for (int i = 0; i < n; i++)
            {
                if (arr[i] < Min)
                {
                    Min = arr[i];
                }
            }
            Console.WriteLine("Số nhỏ nhất trong mảng là: {0}", Min);

            Console.WriteLine("----------------------------------------------");
        }
        static void Bai_10()
        {
            
            Console.WriteLine("Bài 10: Kết Hợp If/Else và Array Viết chương trình phân loại điểm học sinh:\r\n            Nhập điểm cho n học sinh(mảng) Đếm số học sinh: Giỏi(>=8), Khá(6.5-7.9), Trung bình(5-6.4), Yếu(<5) ");
            Console.WriteLine("Nhập số lượng học sinh: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhập điểm học sinh thứ {0}: ", i + 1);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int Gioi = 0;
            int Kha = 0;
            int TrungBinh = 0;
            int yeu = 0;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] >= 8)
                {
                    Gioi++;
                }
                else if (arr[i] >= 6.5 && arr[i] < 8)
                {
                    Kha++;
                }
                else if (arr[i] >= 5 && arr[i] < 6.5)
                {
                    TrungBinh++;
                }
                else
                {
                    yeu++;
                }
            }
            Console.WriteLine("Số học sinh Giỏi: {0}", Gioi);
            Console.WriteLine("Số học sinh Khá: {0}", Kha);
            Console.WriteLine("Số học sinh Trung bình: {0}", TrungBinh);
            Console.WriteLine("Số học sinh Yếu: {0}", yeu);
            Console.WriteLine("----------------------------------------------");
        }
    }
}
