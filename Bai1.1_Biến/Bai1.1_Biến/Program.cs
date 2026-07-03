namespace Bai1._1_Biến
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Thông tin gồm :");

            Console.WriteLine("Mã Nhân Viên : ");
            string maNhanVien = Console.ReadLine();

            Console.WriteLine("Họ Tên : ");
            string hoTen = Console.ReadLine();

            Console.WriteLine("Tuổi : ");
            int tuoi = int.Parse( Console.ReadLine());

            Console.WriteLine("Giới Tính : ");
            string gioiTinh = Console.ReadLine();

            Console.WriteLine("Chiều Cao : " );
            double chieuCao = double.Parse( Console.ReadLine());

            Console.WriteLine("Cân Nặng : ");
            float canNang = float.Parse(Console.ReadLine());

            Console.WriteLine("Số Ngày Công : ");
            int soNgayCong = int.Parse(Console.ReadLine());

            Console.WriteLine("Lương 1 Ngày :");
            double luong1Ngay = double.Parse(Console.ReadLine());

            //Console.WriteLine("Tổng Lương :");
            decimal tongLuong = soNgayCong * (decimal)luong1Ngay;

            Console.WriteLine("King Nghiệm :");
            int kinhNghiem = int.Parse(Console.ReadLine());

            Console.WriteLine("Dang Làm Việc :");
            bool dangLamViec = bool.Parse(Console.ReadLine());

            Console.WriteLine("Xếp Loại :");
            char xiepLoai = Console.ReadLine()[0];
            

            Console.WriteLine("                ==== HO SO NHAN VIEN ====");
            Console.WriteLine("      Mã Nhân Viên : " +maNhanVien);
            Console.WriteLine("      Họ Tên : " + hoTen);
            Console.WriteLine("      Tuổi : " + tuoi);
            Console.WriteLine("      Giới Tính : " + gioiTinh);
            Console.WriteLine("      Chiều Cao : " + chieuCao+ "m");
            Console.WriteLine("      Cân Nặng : " + canNang+ "Kg");
            Console.WriteLine("      Số Ngày Công : " + soNgayCong);
            Console.WriteLine("      Lương 1 Ngày : " + luong1Ngay);
            Console.WriteLine("      Tổng Lương : " + tongLuong);
            Console.WriteLine("      King Nghiệm : " + kinhNghiem+ "nam");
            Console.WriteLine("      Dang Làm Việc : " + dangLamViec);
            Console.WriteLine("      Xếp Loại : " + xiepLoai);
            
        }
    }
}
