namespace PascalCase
{
    internal class Program
    {
        static List<Employee> danhSachNV = new List<Employee>();
        static int idx = -1;
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------Menu------------------");
            Console.WriteLine(
                "1. Them Developer\n" +
                "2. Them Tester\n" +
                "3. Hien thi danh sach\n" +
                "4. Cho tat ca nhan vien lam viec\n" +
                "5. Tim theo ID\n" +
                "6. Cap nhat luong\n" +
                "7. Xoa nhan vien\n" +
                "0. Thoat");
            while (true)
            {
                Console.WriteLine("Lua chon nhiem vu: ");
                int luaChon = Convert.ToInt32(Console.ReadLine());
                switch (luaChon)
                {
                    case 1:
                        ThemDeveloper();
                        break;
                    case 2:
                        ThemTester();
                        break;
                    case 3:
                        HienThiDanhSach();
                        break;
                    case 4:
                        ChoTatCaNhanVienLamViec();
                        break;
                    case 5:
                        Console.WriteLine("Nhap vao ID tim kiem: ");
                        int ID = Convert.ToInt32(Console.ReadLine());
                        TimTheoID(ID);
                        break;
                    case 6:
                        CapNhatLuong();
                        break;
                    case 7:
                        XoaNhanVien();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Lua chon khong hop le");
                        break;
                }
            }

        }

        private static void XoaNhanVien()
        {
            if (idx == -1)
            {
                Console.WriteLine("Lua chon thao tac Tim kiem nhan vien.");
            }
            else
            {
                Console.WriteLine($"Da xoa nhan vien {danhSachNV[idx].Name}," +
                    $" ID: {danhSachNV[idx].Id}");
                danhSachNV.RemoveAt(idx);
                idx = -1;
            }
            
        }

        private static void CapNhatLuong()
        {
            if (idx == -1)
            {
                Console.WriteLine("Lua chon thao tac Tim kiem nhan vien.");
            }
            else
            {
                Console.WriteLine(
                    $"Nhan vien {danhSachNV[idx].Name}," +
                    $" ID: {danhSachNV[idx].Id}," +
                    $" muc luong hien tai {danhSachNV[idx].Salary}");
                Console.WriteLine("Nhap vao muc luong moi ");
                danhSachNV[idx].Salary = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine(
                    $"Da cap nhat luong nhan vien {danhSachNV[idx].Name}," +
                    $" ID: {danhSachNV[idx].Id}" +
                    $" muc luong hien tai {danhSachNV[idx].Salary}");
                idx = -1;
            }
        }

        private static void TimTheoID(int ID)
        {
            bool isFound = false;
            foreach (var item in danhSachNV)
            {
                if (item.Id == ID)
                {
                    idx = danhSachNV.IndexOf(item);
                    isFound = true;
                    item.ShowInfor();
                    Console.WriteLine();
                }             
            }
            if (!isFound)
            {
                Console.WriteLine($"Khong tim thay ID: {ID}");
            }

        }

        private static void ChoTatCaNhanVienLamViec()
        {
            foreach (var item in danhSachNV)
            {
                item.Work();
                Console.WriteLine();
            }
        }

        private static void HienThiDanhSach()
        {
            foreach (var item in danhSachNV)
            {
                item.ShowInfor();
            }
        }

        private static void ThemTester()
        {
            Employee tester = new Tester();
            tester.Input();
            danhSachNV.Add(tester);
        }

        private static void ThemDeveloper()
        {
            Employee dev = new Developer();
            dev.Input();
            danhSachNV.Add(dev);
        }
    }
}
