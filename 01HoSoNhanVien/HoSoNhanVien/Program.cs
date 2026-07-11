namespace HoSoNhanVien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string maNhanVien, hoTen, gioiTinh;
            int Age, soNgayCong, kinhNghiem;
            double chieuCao, luongMotNgay;
            float canNang;
            char xepLoai;
            decimal totalLuong;
            bool dangLamViec;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8; ;
            Console.WriteLine("Mã nhân viên     : "); maNhanVien = Console.ReadLine();
            Console.WriteLine("Họ tên   : "); hoTen = Console.ReadLine();
            Console.WriteLine("Tuổi     : "); Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Giới tính     : "); gioiTinh = Console.ReadLine();
            Console.WriteLine("Chiều cao    :");chieuCao = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Cân nặng     : "); canNang = float.Parse(Console.ReadLine());
            Console.WriteLine("Số ngày công     : "); soNgayCong= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Lương một ngày     : "); luongMotNgay = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Số năm kinh nghiệm     : "); kinhNghiem = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Đang làm việc     : "); dangLamViec = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Xếp loại     : "); xepLoai = Convert.ToChar(Console.ReadLine());
            totalLuong = (decimal)(soNgayCong * luongMotNgay);
            Console.WriteLine("==================HỒ SƠ NHÂN VIÊN==================");

            Console.WriteLine($"Mã nhân viên     :{maNhanVien}");
            Console.WriteLine($"Họ tên   :{hoTen}");
            Console.WriteLine($"Tuổi     :{Age}");
            Console.WriteLine($"Giới tính     :{gioiTinh}");
            Console.WriteLine($"Chiều cao    :{chieuCao} m"); 
            Console.WriteLine($"Cân nặng     :{canNang} kg");
            Console.WriteLine($"Số ngày công     :{soNgayCong}"); 
            Console.WriteLine($"Lương một ngày     :{luongMotNgay.ToString("N0")} ");
            Console.WriteLine($"Tổng lương      :{totalLuong.ToString("N0")} VND");
            Console.WriteLine($"Số năm kinh nghiệm     :{kinhNghiem} năm "); 
            Console.WriteLine($"Đang làm việc     :{dangLamViec}"); 
            Console.WriteLine($"Xếp loại     :{xepLoai} ");
        }
    }
}
