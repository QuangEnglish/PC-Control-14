using System.Text;
using System.Threading.Channels;
using System;
using System.Xml;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BaiTapVeNha
{

    internal class Program
    {
        #region Bài tập 1: Ktra số nguyên
        static void KiemTraSo(int so)
        {
            // int so = Convert.ToInt32(Console.ReadLine());
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
            while (i <= sov2)
            {
                Console.WriteLine("Số : " + i);
                i++;
            }

            //do
            //{
            //    Console.WriteLine("Số : " + i);
            //    i++;
            //}
            //while (i <= sov2);


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
            Console.WriteLine("Tổng là : " + a);

        }
        #endregion

        #region  Bài tập 5 Tạo 1 mảng số nguyên 
        static void MangSoNguyen(int[] soNguyen)
        {

            foreach (int i in soNguyen)
            {
                Console.WriteLine("Số nguyên trong mảng lần lượt là :" + i);
            }
        }

        #endregion

        #region  Bài tập 6 nhập số n và đếm số dương, âm, =0
        static void DiemSoAmDuong(int n)
        {
            int soDuong = 0;
            int soAm = 0;
            int soKhong = 0;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhập số :");
                int sov2 = int.Parse(Console.ReadLine());

                if (sov2 > 0)
                {
                    soDuong++;
                }
                else if (sov2 < 0)
                {
                    soAm++;
                }

                else
                    soKhong++;
            }
            Console.WriteLine($"Tổng số dương là: {soDuong}");
            Console.WriteLine($"Tổng số âm là: {soAm}");
            Console.WriteLine($"Tổng số bằng 0 là: {soKhong}");
        }
        #endregion

        # region  Bài tập 7 Viết Ct máy tính đơn giản
        static void MayTinh()
        {
            Console.WriteLine("Nhập số a :");
            double so_a = double.Parse(Console.ReadLine());

            Console.WriteLine("Nhập toán tử :");
            string toanTu = Console.ReadLine();

            Console.WriteLine("Nhập số b :");
            double so_b = double.Parse(Console.ReadLine());

            switch (toanTu)
            {
                case "+":
                    so_a += so_b; Console.WriteLine("Kết quả là :" + so_a);

                    break;
                case "-":
                    so_a -= so_b; Console.WriteLine("Kết quả là :" + so_a);

                    break;
                case "*":
                    so_a *= so_b; Console.WriteLine("Kết quả là :" + so_a);

                    break;
                case "/":

                    if (so_b == 0)
                    {
                        Console.WriteLine("Không chia hết cho 0");
                    }
                    else
                    {
                        so_a /= so_b; Console.WriteLine("Kết quả là :" + so_a);
                    }
                    break;
                default:
                    Console.WriteLine("Toán tử không hợp lệ");

                    break;


            }

        }
        #endregion

        #region Bai tập 8 vòng lặp While Loop tổng các số lẻ dương
        static void TongCacSoLe()
        {
            //Console.WriteLine("Nhập số âm bai8 :");
            //int soBai8 = Convert.ToInt32(Console.ReadLine());
            int tongSoLeDuong = 0;
            while (true)
            {
                Console.WriteLine("Nhập số nguyên bai8 :");
                int soBai8 = Convert.ToInt32(Console.ReadLine());

                if (soBai8 < 0)
                {
                    Console.WriteLine("Đã nhập đúng số âm : " + soBai8);
                    break;
                }
                else if (soBai8 % 2 == 0)
                {
                    continue;
                }
                else
                {
                    tongSoLeDuong += soBai8;
                }



            }
            Console.WriteLine("Tổng các số lẻ dương là : " + tongSoLeDuong);



        }
        #endregion

        #region Bai tập 9 Mảng tìm số lớn,nhỏ nhất, trung bình cộng và in phần từ
        static void TimSoLonNho()
        {
            int[] n = { 1, 2, 3, 4, 5 };
            int max = n[0];
            for (int i = 1; i < n.Length; i++)
            {
                if (n[i] > max)
                {
                    max = n[i];
                }

            }
            Console.WriteLine("Số lớn nhất là : " + max);

            int min = n[0];
            for (int i = 1; i < n.Length; i++)
            {
                if (n[i] < min)
                {
                    min = n[i];
                }

            }
            Console.WriteLine("Số nhỏ nhất là : " + min);

            int tongSoTrongMang = 0;
            for (int i = 0; i < n.Length; i++)
            {
                tongSoTrongMang += n[i];

            }
            int trungBinh = tongSoTrongMang / n.Length;
            Console.WriteLine("Trung Bình Cộng là : " + trungBinh);

            Console.WriteLine("Phần tử trong mảng theo thứ tự ngược lại là : ");
            for (int i = n.Length - 1; i >= 0; i--)
            {

                Console.Write(n[i] + ", ");

            }
        }
            #endregion

            #region Bai tập 10 Phân loại điểm học sinh
            static void PhanLoaiDiem(int n)
            {
                double[] diemHS = new double[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Nhập số điểm từng học sinh :");
                    diemHS[i] = double.Parse(Console.ReadLine());

                }
                for (int i = 0; i < n; i++)
                {
                  if (diemHS[i] >= 8)
                  {
                    Console.WriteLine("Xếp Loại Giỏi : " + diemHS[i]);
                  }
                  else if (diemHS[i] >= 6.5 && diemHS[i] <= 7.9)
                  {
                    Console.WriteLine("Xếp Loại Khá : " + diemHS[i]);
                  }
                  else if (diemHS[i] < 6.5 && diemHS[i] >= 5)
                  {
                    Console.WriteLine("Xếp Loại Trung Binh : " + diemHS[i]);
                  }
                  else
                  {
                    Console.WriteLine("Xếp Loại Yếu : " + diemHS[i]);
                  }
                }
            }
            #endregion
            static void Main(string[] args)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("Nhập bài tập cần chạy :");
                string BaiTap = (Console.ReadLine());
                switch (BaiTap)
                {

                    case "Bai 1":

                        Console.WriteLine("Nhập số cần kiểm tra :");
                        int nhapSo = Convert.ToInt32(Console.ReadLine());
                        KiemTraSo(nhapSo);
                        break;

                    case "Bai 2":

                        Console.WriteLine("Nhập số thứ :");
                        int nhapSov1 = Convert.ToInt32(Console.ReadLine());
                        ThuTrongTuan(nhapSov1);
                        break;

                    case "Bai 3":

                        Console.WriteLine("Các số từ 1 - 10 :");
                        InDaySo(10);
                        break;

                    case "Bai 4":

                        Console.WriteLine("Nhập số n là :");
                        int nhapSov2 = Convert.ToInt32(Console.ReadLine());

                        TongCacSo(nhapSov2);
                        break;

                    case "Bai 5":

                        Console.WriteLine("Nhập số phần tử trong mảng :");
                        int so = Convert.ToInt32(Console.ReadLine());


                        int[] soNguyen = new int[so];
                        //while (so > 0)
                        for (int i = 0; i < so; i++)
                        {
                            Console.WriteLine("Nhập các số nguyên trong mảng :");
                            //  int a = Convert.ToInt32(Console.ReadLine());
                            //if(a >= 0)
                            //{
                            soNguyen[i] = Convert.ToInt32(Console.ReadLine());
                            //}  
                            //else
                            //{
                            //  Console.WriteLine("Cần nhập số Nguyên Dương");
                            //  i--;
                            //}    


                        }
                        MangSoNguyen(soNguyen);
                        //int b = soNguyen[2];
                        //Console.WriteLine(b);

                        break;

                    case "Bai 6":
                        Console.WriteLine("Nhập tổng số nguyên cần kiểm tra:");
                        int nhapSov3 = Convert.ToInt32(Console.ReadLine());
                        DiemSoAmDuong(nhapSov3);

                        break;

                    case "Bai 7":
                        MayTinh();
                        break;

                    case "Bai 8":
                        TongCacSoLe();
                        break;

                    case "Bai 9":
                        TimSoLonNho();
                        break;

                    case "Bai 10":
                        Console.WriteLine("Nhập tổng số học sinh cần kiểm tra Học Lực :");
                        int tongHS = Convert.ToInt32(Console.ReadLine());
                        PhanLoaiDiem(tongHS);
                        break;
                }
            }
        
    }
}  
