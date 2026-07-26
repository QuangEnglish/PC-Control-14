namespace Bai_Tap3._1_Ham_XepLoaiHocLuc
{
    internal class Program
    {
        #region Ham Xep Loai Hoc Luc
        static string TinhXepLoaiHocLuc(float diem)
        {
            if(diem < 0 || diem > 10)
            {
                return "Loi Sai Cu Phap";
            }
            else if ( diem <= 5)
            {
                return "Trung Binh";
            }
        
            else if (diem <= 8)
            {
                return "Kha";
            }
            //else if (diem > 5 && diem <= 8)
            //{
            //    return "Kha";
            //}
            else 
            {
                return "Gioi";
            }
            //else if (diem >= 8 && diem <= 10)
            //{
            //    return "Gioi";
            //}
            //else
            //{
            //    return "Loi Sai Cu Phap";
            //}

        }
        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap So Diem :");
            float diemv1 = float.Parse(Console.ReadLine());
            //int diemv1 = Convert.ToInt32(Console.ReadLine());
            string xepLoai = TinhXepLoaiHocLuc(diemv1);
            Console.WriteLine($"Xep Loai Hoc Luc Cua Ban La : {xepLoai}");
        }
    }
}
