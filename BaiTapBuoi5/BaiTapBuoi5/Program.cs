using System.Text;
using System.Threading.Channels;

namespace BaiTapBuoi5
{
    internal class Program
    {
        static void Bai1()
        {
            Console.Write("Mời nhập 1 số bất kỳ: ");
            double a = Convert.ToDouble(Console.ReadLine());

            if (a > 0)
            
                Console.WriteLine(" a là số dương");

            else if (a < 0)
            
                Console.WriteLine(" a là số âm ");
            
            else
                Console.WriteLine(" a là số không ");
        }

         static void Bai2 ()
        {
            Console.Write("Mời nhập số từ 1 đến 7: ");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a < 1 || a > 7)
            {
                Console.WriteLine(" Không xác định");
            }
            else
            {
                switch (a)
                {
                    case 1:
                        Console.WriteLine(" Chủ nhật");
                        break;

                    case 2:
                        Console.WriteLine("Thứ hai");
                        break;
                    case 3:
                        Console.WriteLine("Thứ ba");
                        break;
                    case 4:
                        Console.WriteLine("Thứ tư");
                        break;
                    case 5:
                        Console.WriteLine("Thứ năm");
                        break;
                    case 6:
                        Console.WriteLine("Thứ sáu");
                        break;
                    case 7:
                        Console.WriteLine("Thứ 7");
                        break;

                }

            }
            
        }

        static void Bai3()
        {
            int i = 1 ;
            Console.WriteLine("In từ 1 đến 10 bằng vòng lặp while: ");
            while ( i<= 10)
            {
                Console.WriteLine(i);
                i++;

            }

        }

        static void Bai4()
        {
            Console.Write("Mời nhập vào 1 số a: ");
            int a = Convert.ToInt32 (Console.ReadLine());
            Console.WriteLine("Danh sách từ 1 đến số vừa nhập là: ");
            for(int i = 1;i <= a; i++)
            {
                Console.WriteLine(" "+i);
            }    
                
        }

        static void Bai5()
        {
            int[] a = new int[5];
            Console.WriteLine("Mời nhập dữ liệu cho mảng: ");
            for (int i =0 ; i < a.Length; i++)
            {
                
                Console.WriteLine("Phần tử: "+(i+1)+ " ");
                a[i] = Convert.ToInt32(Console.ReadLine());
                
            }
            Console.WriteLine("Mảng vừa nhập là");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(" "+a[i]);
            }
                
        }
        static void Bai6()
        {
            int demDuong = 0;
            int demAm = 0;
            int dem0 = 0;

            Console.Write("Bạn muốn nhập bao nhiêu số nguyên: ");
            int a =  Convert.ToInt32(Console.ReadLine());
            int[] b = new int[a];

            for(int i = 0 ; i < b.Length; i++)
            {
                Console.Write("Số thứ "+(i+1)+" ");
                b[i] = Convert.ToInt32(Console.ReadLine());
            }
            
            for (int i = 0 ;i < b.Length; i++)
            {
                if (b[i] > 0)
                {
                    demDuong++;
                }
                else if (b[i] < 0)
                {
                    demAm++;
                }    
                else
                {  
                    dem0++; 
                }
            }
            Console.WriteLine("Có "+ demDuong+ " số dương");
            Console.WriteLine("Có "+demAm+" số âm");
            Console.WriteLine("có "+dem0+" số 0");

        }

        static void Bai7()
        {   // 1 số bất kỳ chia cho 0 đều sai về mặt toán học. trong lập trình cần phải sử lý ngoại lệ
            // hình như chưa có học nên em k xử lý ạ
            double ketQua = 0;
            Console.Write(" Mời nhập số a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write(" Mời nhập số b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write(" Mời nhập phép tính muốn thực hiện: ");
            char phepTing = Convert.ToChar(Console.ReadLine());
            switch (phepTing)
            {
                case '+':
                    ketQua = a + b;
                    break;
                case '-':
                    ketQua = a - b;
                    break;
                case '*':
                    ketQua = a * b;
                    break;
                case '/':
                    ketQua = a / b;
                    break;
                default:
                    Console.WriteLine("Phép tính không hợp lệ");
                    break;

            }
            Console.WriteLine("Kết quả của " + a + phepTing + b + "= " + ketQua);
        }

            static void Bai8()
            {   
                double sum = 0;
                Console.WriteLine("Mời nhập số");
                int a = Convert.ToInt32(Console.ReadLine());
                while (a>=0)
                {

                if (a % 2 == 0)
                {
                    Console.WriteLine("Mời nhập số");
                    a = Convert.ToInt32(Console.ReadLine());
                    continue;
                }
                else
                {
                    sum += a;
                    Console.WriteLine("Mời nhập số");
                    a = Convert.ToInt32(Console.ReadLine());
                }
                }
                        
            Console.WriteLine("Tổng các số lẻ vừa nhập là: " +sum);
            }
            static void Bai9()
            {
                double max = 0;
                double min = 0;
                double sum = 0 ;
                Console.WriteLine("Mảng có mấy phần tử: ");
                int a = Convert.ToInt32(Console.ReadLine());
                int[] b = new int [a];
                for (int i = 0; i < b.Length; i++)
                {
                    Console.WriteLine("Phần tử "+(i+1)+ " ");
                    b[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Mảng vừa nhập là");
                for (int i = 0; i < b.Length; i++) 
                { 
                    Console.WriteLine(" "+b[i]); 
                }
                max = b[0];
                min = b[0];
                for (int i = 0; i < b.Length; i++)
                {   
                    sum += b[i];
                   
                    if(b[i] > max)
                    {
                        max = b[i];
                    }
                    if (b[i] < min)
                    {
                        min = b[i];
                    }

                }
                Console.WriteLine("Phần tử lớn nhất = "+max);
                Console.WriteLine("Phần tử nhỏ nhất = " +min);
                Console.WriteLine("Trung bình cộng của mảng là  = " + (sum/b.Length));
                Console.WriteLine("Mảng sau khi in ngược lại là: ");
                for(int i = (b.Length-1);i>=0;i--)
                {
                    Console.WriteLine(" "+ b[i]);
                }    
            }

        static void Bai10()
        {   
            int demGioi = 0;
            int demKha = 0;
            int demTB = 0;
            int demYeu = 0;
            Console.WriteLine("Mời nhập số lượng học sinh: ");
            int a = Convert.ToInt32(Console.ReadLine());
            double[] b = new double[a];
            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine(" Điểm học Sinh " + (i + 1) + " :");
                b[i] = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("Dãy điểm vừa nhập là");
            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine(" " + b[i]);
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (b[i]>=8)
                    demGioi++;
                else if(b[i]>6.5 && b[i]<7.9)
                    demKha++;
                else if (b[i] > 5 && b[i] < 6.4)
                    demTB++;
                else
                    demYeu++;
            }
            Console.WriteLine("Có "+demGioi+ " học lực giỏi");
            Console.WriteLine("Có " + demKha + " học lực khá");
            Console.WriteLine("Có " + demTB + " học lực TB");
            Console.WriteLine("Có " + demYeu + " học lực yếu");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int a;
            do
            { 

            Console.WriteLine("                    Danh sách bài tâp ");
            Console.WriteLine("Bài 1: Nhập vào 1 sô và kiểm tra số đó là số âm hay dương hay là số 0");
            Console.WriteLine("Bài 2: Nhập vào 1 sô và kiểm tra số là thứ mấy trong tuần nếu không phải in ra không xác định");
            Console.WriteLine("Bài 3: In từ 1 đến 10 bằng vòng lặp while ");
            Console.WriteLine("Bài 4: In từ 1 đến 4 với N nhập từ bàn phim ");
            Console.WriteLine("Bài 5: Nhập phần tử cho mảng có độ dài 5 và in ra mảng ");
            Console.WriteLine("Bài 6: Nhập N số nguyên và đếm số dương, âm và số 0 ");
            Console.WriteLine("Bài 7: Nhập vào 2 số a và b cùng phép tính muốn thực hiện ");
            Console.WriteLine("Bài 8: Nhập số cho tới khi nhập số âm thì dừng lại, in ra tổng các số lẻ");
            Console.WriteLine("Bài 9: Nhập vào mảng, tìm max, min, tính trung bình cộng và in ngược lại mảng ");
            Console.WriteLine("Bài 10: Nhập vào mảng N học sinh và nhập điểm tương ứng. In ra học lực tương ứng ");
            Console.WriteLine("Nhập số 0 để thoát chương trình");
            Console.Write("Mời nhập bài tập muốn chạy: ");
            a = Convert.ToInt32(Console.ReadLine());

            switch (a)
            {
                case 1:
                    Bai1();
                    break;
                case 2:
                    Bai2();
                    break;
                case 3:
                    Bai3();
                    break;
                case 4:
                    Bai4();
                    break;
                case 5:
                    Bai5();
                    break;
                case 6:
                    Bai6();
                    break;
                case 7:
                    Bai7();
                    break;
                case 8:
                    Bai8();
                    break;
                case 9:
                    Bai9();
                    break;
                case 10:
                    Bai10();
                    break;

                default:
                    Console.WriteLine("Không có bài này.");
                    break;
            }
        }

            while (a != 0);
            {
                
            }
        }
    }
}

