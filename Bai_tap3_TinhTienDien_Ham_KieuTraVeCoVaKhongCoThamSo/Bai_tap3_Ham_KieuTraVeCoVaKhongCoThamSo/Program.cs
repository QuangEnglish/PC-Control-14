using System.Text;
using System.Threading.Channels;

namespace Bai_tap3_Ham_KieuTraVeCoVaKhongCoThamSo
{
    internal class Program
    {
        #region Ham tinh so tien dien 
        static decimal TinhSoTienDien(int a)
        {
            decimal soTien = 0;
            if (a <= 50)
            {
                soTien = a * 1800;
            }
            else if(a > 50 & a <= 100)
            {
                soTien = a * 2000;
            }
            else
            {
                soTien = a * 2500;
            }
                return soTien;
            
        }
        #endregion
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Nhập số điện :");
            int soDien = int.Parse (Console.ReadLine());

            decimal soTienDien = TinhSoTienDien(soDien);
            Console.WriteLine($"Số Tiền Điện Tháng Này : {soTienDien} VND" );
        }
    }
}
