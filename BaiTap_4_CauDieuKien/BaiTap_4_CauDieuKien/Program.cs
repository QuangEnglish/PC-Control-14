using System.Text;

namespace BaiTap_4_CauDieuKien
{
    
    internal class Program
    {
        #region Bài tập 1: Ktra số nguyên
        static void KiemTraSo(int so)
        {
            //int so = Convert.ToInt32(Console.ReadLine());
            if (so > 0)
            {
                Console.WriteLine($"Số dương : {so}");
            }
            else if (so < 0)
            {
                Console.WriteLine($"Số âm : {so}");
            }
            else
            {
                Console.WriteLine($"Số không : {so}");
            }
        }
        #endregion
        #region Bài tập 2 : In ra thứ trong tuần
        static void ThuTrongTuan(int sov1)
        {
            switch (sov1)
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
                default:
                    Console.WriteLine("Không Hợp Lệ");
                    break;


            }
        }
        #endregion
        #region Bài tập 3 : In ra các số từ 1-10
        static void InDaySo(int sov2)
        {
            int i = 1;
            //while (i < sov2)
            //{
            //    Console.WriteLine("Số : " + i);
            //    i++;
            //}
            //Console.WriteLine("Số : 10");
            do 
            {
                Console.WriteLine("Số : " + i);
                i++;
            }
            while (i < sov2);
            Console.WriteLine("Số : 10");

        }
        #endregion
        #region Bài tập 4: Tổng các số từ 1 - n
        static void TongCacSo(int n)
        {
            int a = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i <= n)
                    a += i;
                Console.WriteLine(a);
            }
            Console.WriteLine("Tổng là : "+ a);

        }
        #endregion
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Console.WriteLine("Hello, World!");
            int nhapSo = Convert.ToInt32(Console.ReadLine());
            KiemTraSo(nhapSo);

            int nhapSov1 = Convert.ToInt32(Console.ReadLine());
            ThuTrongTuan(nhapSov1);

            int nhapSov2 = Convert.ToInt32(Console.ReadLine());
            InDaySo(10);
            TongCacSo(10);
                
        }
    }
}
