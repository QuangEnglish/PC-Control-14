using System.Text;
using System.Threading.Channels;

namespace Bai_tap_ve_nha_phan_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Nhập bài tập cần tìm");
            int baitap = Convert.ToInt32(Console.ReadLine());
            switch (baitap)
            {
                case 1: Displaybai1(); break;
                case 2: Displaybai2(); break;
                case 3: Displaybai3(); break;
                case 4: Displaybai4(); break;
                case 5: Displaybai5(); break;
                case 6: Displaybai6(); break;
                case 7: Displaybai7(); break;
                case 8: Displaybai8(); break;
                case 9: Displaybai9(); break;
                case 10: Displaybai10(); break;

            }


        }
        static void Displaybai1()
        {
            Console.WriteLine("Hãy nhập số bất kỳ");
            int i = Convert.ToInt32(Console.ReadLine());
            if (i == 0)
            {
                Console.WriteLine("Số không");
            }
            else if (i > 0) { Console.WriteLine("Số dương"); }
            else
            {
                Console.WriteLine("Số âm");
            }


        }
        static void Displaybai2()
        {
            Console.WriteLine("Hãy nhập số:");
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Console.WriteLine("Chủ nhật");
                    break;
                case 2:
                    Console.WriteLine("Thứ 2");
                    break;
                case 3:
                    Console.WriteLine("Thứ 3");
                    break;
                case 4:
                    Console.WriteLine("Thứ 4");
                    break;
                case 5:
                    Console.WriteLine("Thứ 5");
                    break;
                case 6:
                    Console.WriteLine("Thứ 6");
                    break;
                case 7:
                    Console.WriteLine("Thứ 7");
                    break;
            }
        }
        static void Displaybai3()
        {
            int b = 0;
            while (b < 10) { b++; Console.WriteLine(b); }

        }
        static void Displaybai4()
        {
            Console.WriteLine("Hãy nhập số n");
            int nhapso = Convert.ToInt32(Console.ReadLine());
            int tong = 0;
            for (int i = 1; i <= nhapso; i++)
            {
                tong += i;
            }
            Console.WriteLine("Giá trị tổng từ 1 đến n là: " + tong);

        }
        static void Displaybai5()
        {
            Console.WriteLine("Hãy nhập 5 số nguyên");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            int d = Convert.ToInt32(Console.ReadLine());
            int e = Convert.ToInt32(Console.ReadLine());
            int[] mangdctao = { a, b, c, d, e };
            Console.WriteLine("Mang moi duoc tao ra la: ");
            foreach (int i in mangdctao) { Console.WriteLine(i); }
        }
        static void Displaybai6()
        {

            Console.WriteLine("Hãy nhập 5 số nguyên");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            int d = Convert.ToInt32(Console.ReadLine());
            int e = Convert.ToInt32(Console.ReadLine());
            int[] mangdctao = { a, b, c, d, e };
            int sokhong = 0;
            int soduong = 0;
            int soam = 0;
            for (int i = 0; i < 5; i++)
            {
                if (mangdctao[i] == 0) { sokhong++; }
                else if (mangdctao[i] > 0) { soduong++; }
                else { soam++; }
            }
            Console.WriteLine("Số lượng số không là: " + sokhong);
            Console.WriteLine("Số lượng số âm là: " + soam);
            Console.WriteLine("Số lượng số dương là: " + soduong);

        }
        static void Displaybai7()
        {
            Console.WriteLine("Hãy nhập số a");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Hãy nhập số b");
            double b = Convert.ToDouble(Console.ReadLine());
            double cong = a + b;
            double tru = a - b;
            double nhan = a * b;
            double chia = a / b;
            Console.WriteLine("a+b=" + cong);
            Console.WriteLine("a-b=" + tru);
            Console.WriteLine("a*b=" + nhan);

            switch (b) { case 0: Console.WriteLine("Không thể chia cho 0"); break; default: Console.WriteLine("a/b=" + chia); break; }

        }
        static void Displaybai8()
        {

            Console.WriteLine("Hãy nhập số");
            int tongsoleduong = 0;
            while (true)
            {

                int i = Convert.ToInt32(Console.ReadLine());
                if (i < 0) { break; }
                else if (i % 2 == 0) { continue; }
                else { }
                tongsoleduong += i;

            }
            Console.WriteLine("Tổng số lẻ dương là: " + tongsoleduong);
        }
        static void Displaybai9()
        {
            Console.WriteLine("Hãy tạo mảng gồm 5 số nguyên");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            int d = Convert.ToInt32(Console.ReadLine());
            int e = Convert.ToInt32(Console.ReadLine());
            int[] mangdctao = { a, b, c, d, e };
            int max = mangdctao[0];
            int min = mangdctao[0];
            for (int i = 0; i < mangdctao.Length; i++)
            {
                if (mangdctao[i] > max) { max = mangdctao[i]; }
                if (mangdctao[i] < min) { min = mangdctao[i]; }

            }
            Console.WriteLine("Số lớn nhất là: " + max);
            Console.WriteLine("Số bé nhất là: " + min);
            Console.WriteLine("Mảng đảo ngược là");

            for (int i = 4; i >= 0; i--) { Console.WriteLine(mangdctao[i]); }
        }
        static void Displaybai10()
        {
            Console.WriteLine("Nhập điểm học sinh A:");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Nhập điểm học sinh B:");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Nhập điểm học sinh C:");
            double c = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Nhập điểm học sinh D:");
            double d = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Nhập điểm học sinh E:");
            double e = Convert.ToDouble(Console.ReadLine());
            double[] mangdiem = { a, b, c, d, e };
            string phanloai = "";
            for (int i = 0; i < mangdiem.Length; i++)
            {
                if (mangdiem[i] >= 8) { phanloai = "Giỏi"; }
                else if (mangdiem[i] >= 6.5 && mangdiem[i] <= 7.9) { phanloai = "Khá"; }
                else if (mangdiem[i] >= 5 && mangdiem[i] <= 6.4) { phanloai = "Trung bình"; }
                else if (mangdiem[i] >= 0 && mangdiem[i] < 5) { phanloai = "Yếu"; }
                else { phanloai = "Không hợp lệ, hãy nhập lại"; }
                Console.WriteLine(phanloai);

            }
        }
    }
}