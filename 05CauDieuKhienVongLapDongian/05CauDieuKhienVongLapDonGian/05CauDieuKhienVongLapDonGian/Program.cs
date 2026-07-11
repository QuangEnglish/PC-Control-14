using System.Diagnostics.CodeAnalysis;

namespace _05CauDieuKhienVongLapDonGian
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            while (true)
            {
                Console.WriteLine("Nhap vao bai tap so: ");
                int baiTap = Convert.ToInt32(Console.ReadLine());
                switch (baiTap)
                {
                    case 1:
                        Console.WriteLine("Bai tap 1: ");
                        Console.WriteLine("Nhap vao mot so nguyen, kiem tra am duong: ");
                        int soNguyen = Convert.ToInt32(Console.ReadLine());
                        BaiTap1(soNguyen);
                        Console.WriteLine("=======================================");
                        break;
                    case 2:
                        Console.WriteLine("Bai tap 2: ");
                        Console.WriteLine("Nhap vao mot so tu 1 - 7, in ra thu trong tuan: ");
                        int soThu = Convert.ToInt32(Console.ReadLine());
                        BaiTap2(soThu);
                        Console.WriteLine("=======================================");
                        break;
                    case 3:
                        Console.WriteLine("Bai tap 3: In ra cac so tu 1 den 10 bang vong lap While: ");
                        BaiTap3();
                        break;
                        Console.WriteLine("=======================================");
                    case 4:
                        Console.WriteLine("Bai tap 4: Nhap vao mot so nguyen n, tinh tong tu 1 den n: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        BaiTap4(n);
                        Console.WriteLine("=======================================");
                        break;
                    case 5:
                        Console.WriteLine("Bai tap 5: Nhap vao 5 so nguyen, in ra man hinh: ");
                        int[] arrSoNguyen = new int[5];
                        BaiTap5(arrSoNguyen);
                        Console.WriteLine("=======================================");
                        break;
                    case 6:
                        Console.WriteLine("Bai tap 6: Nhap vao N so nguyen, dem so duong am bang 0: ");
                        Console.WriteLine("Nhap so luong so: ");
                        int N = Convert.ToInt32(Console.ReadLine());
                        int[] arrSoNguyenN = new int[N];
                        BaiTap6(arrSoNguyenN);
                        Console.WriteLine("=======================================");
                        break;
                    case 7:
                        Console.WriteLine("Bai tap 7: Nhap vao 2 so a, b va phep toan ");
                        int soA, soB;
                        string phepToan; 
                        Console.WriteLine("Nhap so a: "); soA = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nhap so b: "); soB = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nhap phep toan : "); phepToan = Console.ReadLine();
                        BaiTap7(soA, soB, phepToan);
                        Console.WriteLine("=======================================");
                        break;
                    case 8:
                        Console.WriteLine("Bai tap 8: Nhap cac so tu ban phim cho den khi nhap so am, tinh tong so le duong");
                        BaiTap8();
                        Console.WriteLine("=======================================");
                        break;
                    case 9:
                        Console.WriteLine("Bai tap 9: Nhap vao mang so nguyen , min, max, average, in nguoc");
                        int soLuongPhanTu;
                        Console.WriteLine("Nhap so luong phan tu: "); soLuongPhanTu= Convert.ToInt32(Console.ReadLine());
                        int[] arrBai9 = new int[soLuongPhanTu];
                        BaiTap9(arrBai9);
                        Console.WriteLine("=======================================");
                        break;
                    case 10:
                        Console.WriteLine("Bai tap 10: Phan loai diem hoc sinh");
                        Console.WriteLine("Nhap so luong hoc sinh: ");
                        int soHocSinh = Convert.ToInt32(Console.ReadLine());
                        float[] arrBai10 = new float[soHocSinh];
                        BaiTap10(arrBai10);
                        Console.WriteLine("=======================================");
                        break;
                    default:
                        Console.WriteLine("Nhap so bai tap tu 1 - 10");
                        Console.WriteLine("=======================================");
                        break;
                }

            }
        }
        #region BaiTap1
        static void BaiTap1(int soNguyen)
        {
            if (soNguyen > 0) Console.WriteLine("So duong");
            else if (soNguyen < 0) Console.WriteLine("So am");
            else Console.WriteLine("So khong"); 
        }
        #endregion
        #region BaiTap2
        static void BaiTap2(int soThu)
        {
            switch(soThu)
            {
                case 2:
                    Console.WriteLine("Thu Hai") ;
                    break;
                case 3:
                    Console.WriteLine("Thu Ba");
                    break;
                case 4:
                    Console.WriteLine("Thu Tu");
                    break;
                case 5:
                    Console.WriteLine("Thu Nam");
                    break;
                case 6:
                    Console.WriteLine("Thu Sau");
                    break;
                case 7:
                    Console.WriteLine("Thu Bay");
                    break;
                case 1:
                    Console.WriteLine("Chu Nhat");
                    break;
                default: Console.WriteLine("Khong xac dinh") ;
                    break;
            }
        }
        #endregion
        #region BaiTap3
        static void BaiTap3()
        {
            int i = 1;
            while (i <= 10)
            {
                Console.WriteLine(i);
                i++;
            }
        }
        #endregion
        #region BaiTap4
        static void BaiTap4(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            Console.WriteLine($"Tong cac so tu 1 den {n} la: {sum}");
        }
        #endregion
        #region BaiTap5
        static void BaiTap5(int[] arrSoNguyen)
        {
            for (int i = 0; i < 5; i++)
            {
                arrSoNguyen[i] = Convert.ToInt32(Console.ReadLine());
            }
            foreach (int i in arrSoNguyen)
            {
                Console.WriteLine(i);
            }
        }
        #endregion
        #region BaiTap6
        static void BaiTap6(int[] arrSoNguyenN)
        {
            int countDuong = 0, countAm = 0, count0 = 0;

            for (int i = 0; i < arrSoNguyenN.Length; i++)
            {
                arrSoNguyenN[i] = Convert.ToInt32(Console.ReadLine());
                if (arrSoNguyenN[i] > 0) countDuong++;
                else if (arrSoNguyenN[i] < 0) countAm++;
                else count0++;
            }
            Console.WriteLine($"Co {countDuong} so duong");
            Console.WriteLine($"Co {countAm} so am");
            Console.WriteLine($"Co {count0} so 0");

        }
        #endregion
        #region BaiTap7
        static void BaiTap7( int soA, int soB, string phepToan)
        {
            switch (phepToan)
            {
                case "+":
                    Console.WriteLine($"Ket qua: {soA + soB}");
                    break;
                case "-":
                    Console.WriteLine($"Ket qua: {soA - soB}");
                    break;
                case "*":
                    Console.WriteLine($"Ket qua: {soA * soB}");
                    break;
                case "/":
                    if (soB != 0)
                        Console.WriteLine($"Ket qua: {soA / soB}");
                    else
                        Console.WriteLine("Khong the chia cho 0");
                    break;
                default:
                    Console.WriteLine("Phep toan khong hop le");
                    break;
            }
        }
        #endregion
        #region BaiTap8
        static void BaiTap8()
        {
            int sum = 0;
            while(true)
            {
                int a = Convert.ToInt32(Console.ReadLine());
                if (a < 0) break;
                if (a % 2 == 1) sum += a;

            }
            Console.WriteLine("Tong cac so le duong: " + sum);
            // Implement the logic for BaiTap8 here
        }
        #endregion
        #region BaiTap9
        static void BaiTap9(int[] arrBai9)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            int sum = 0;
            for (int i = 0; i <arrBai9.Length; i++)
            {
                arrBai9[i] = Convert.ToInt32(Console.ReadLine());
                if (arrBai9[i] < min) min = arrBai9[i];
                if (arrBai9[i] > max) max = arrBai9[i];
                sum += arrBai9[i];
            }
            Console.WriteLine("So lon nhat: " + max);
            Console.WriteLine("So nho nhat: " + min);
            Console.WriteLine("Trung binh cong: " + (float)sum/arrBai9.Length);
            for (int i = arrBai9.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(arrBai9[i]);
            }
        }
        #endregion
        #region BaiTap10
        static void BaiTap10(float[] arrBai10)
        {
            int countGioi = 0, countKha = 0, countTrungBinh = 0, countYeu = 0;
            for (int i = 0; i < arrBai10.Length; i++)
            {
                arrBai10[i] = float.Parse(Console.ReadLine());
                if (arrBai10[i] >= 8F) countGioi++;
                else if (arrBai10[i] >= 6.5F) countKha++;
                else if (arrBai10[i] >= 5F) countTrungBinh++;
                else countYeu++;
            }
            Console.WriteLine("So hoc sinh gioi: " + countGioi);
            Console.WriteLine("So hoc sinh kha: " + countKha);
            Console.WriteLine("So hoc sinh Trung binh: " + countTrungBinh);
            Console.WriteLine("So hoc sinh yeu: " + countYeu);

        }
        #endregion
    }
}
