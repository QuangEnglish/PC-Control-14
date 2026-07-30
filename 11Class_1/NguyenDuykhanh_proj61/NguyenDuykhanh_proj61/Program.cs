namespace NguyenDuykhanh_proj61
{
    internal class Program
    {
        static List<Student> listStudent = new List<Student>();
        static void Main(string[] args)
        {
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Hien thi danh sach sinh vien");
            Console.WriteLine("3. Tim kiem sinh vien theo ID");
            Console.WriteLine("4. Tim kiem sinh vien theo Address");
            Console.WriteLine("5. Xoa mot sinh vien theo ID");
            Console.WriteLine("6. Ket thuc chuong trinh");
            
            while (true)
            {
                int ThaoTac = Convert.ToInt32(Console.ReadLine());
                switch (ThaoTac)
                {
                    case 1:
                        Console.WriteLine("------------------Them sinh vien---------------------");
                        ThemSinhVien();
                        break;
                    case 2:
                        Console.WriteLine("--------------Hien thi danh sach sinh vien-----------");
                        HienThiDanhSachSinhVien();
                        break;
                    case 3:
                        Console.WriteLine("------------Tim kiem sinh vien theo ID-----------");
                        TimKiemSinhVienTheoID();
                        break;
                    case 4:
                        Console.WriteLine("------------Tim kiem sinh vien theo Address-----------");
                        TimKiemSinhVienTheoAddress();
                        break;
                    case 5:
                        Console.WriteLine("------------Xoa mot sinh vien theo ID-----------");
                        XoaMotSinhVien();
                        break;
                    case 6:
                        Console.WriteLine("===============Ket thuc chuong trinh================");
                        return;
                    default:
                        break;
                }
            }
        }
        static void ThemSinhVien()
        {
            Student sinhVien = new Student();         
            sinhVien.Input();
            listStudent.Add(sinhVien);
            Console.WriteLine("---------------------Da them sinh vien-------------------");
        }
        static void HienThiDanhSachSinhVien()
        {
            foreach (var item in listStudent)
            {
                item.Output();
                Console.WriteLine();
            }
        }
        static void TimKiemSinhVienTheoID()
        {
            Console.WriteLine(" Nhap vao ID sinh vien: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            bool isFind = false;
            foreach (var item in listStudent)
            {
                if (item.Id == ID)
                {
                    item.Output();
                    Console.WriteLine();
                    isFind = true;
                } 
            }
            if (!isFind)
            {
                Console.WriteLine("===========Khong tim thay ID sinh vien================");
            }


        }
        static void TimKiemSinhVienTheoAddress()
        {
            Console.WriteLine(" Nhap vao Adress sinh vien: ");
            string address = Console.ReadLine();
            bool isFind = false;
            foreach (var item in listStudent)
            {
                if (item.Address == address)
                {
                    item.Output();
                    isFind = true;
                    Console.WriteLine();
                }
            }
            if (!isFind)
            {
                Console.WriteLine("===========Khong tim thay ID sinh vien================");
            }

        }
        static void XoaMotSinhVien()
        {
            Console.WriteLine(" Nhap vao ID sinh vien: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            int vitriCanXoa = -1;
            for (int i = 0; i < listStudent.Count; i++)
            {
                if (listStudent[i].Id == ID)
                {
                    vitriCanXoa = i;
                    break;
                }
            }
            if (vitriCanXoa == -1)
            {
                Console.WriteLine("===========Khong tim thay ID sinh vien================");
            }
            else
            {
                listStudent.RemoveAt(vitriCanXoa);
                Console.WriteLine(" ==============Da xoa sinh vien================ ");  
            }
        }
    }
}
