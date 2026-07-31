namespace Lisson11._1_Pham_Vi_Truy_Cap__Ke_Thua
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                List<Student> ds = new List<Student>();
                int chon;

                do
                {
                    Console.WriteLine("\n===== MENU =====");
                    Console.WriteLine("1. Them mot sinh vien");
                    Console.WriteLine("2. Hien thi danh sach sinh vien");
                    Console.WriteLine("3. Tim kiem sinh vien theo id");
                    Console.WriteLine("4. Tim kiem sinh vien theo address");
                    Console.WriteLine("5. Xoa sinh vien theo id");
                    Console.WriteLine("6. Ket thuc");
                    Console.Write("Nhap lua chon: ");
                    chon = int.Parse(Console.ReadLine());

                    switch (chon)
                    {
                        case 1:
                            Student sv = new Student();
                            sv.Input();
                            ds.Add(sv);
                            break;

                        case 2:
                            foreach (Student s in ds)
                            {
                                s.Output();
                            }
                            break;

                        case 3:
                            Console.Write("Nhap id can tim: ");
                            int id = int.Parse(Console.ReadLine());

                            bool found = false;
                            foreach (Student s in ds)
                            {
                                if (s.Id == id)
                                {
                                    s.Output();
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                                Console.WriteLine("Khong tim thay!");
                            break;

                        case 4:
                            Console.Write("Nhap address can tim: ");
                            string address = Console.ReadLine();

                            found = false;
                            foreach (Student s in ds)
                            {
                                if (s.Address.ToLower() == address.ToLower())
                                {
                                    s.Output();
                                    found = true;
                                }
                            }

                            if (!found)
                                Console.WriteLine("Khong tim thay!");
                            break;

                        case 5:
                            Console.Write("Nhap id can xoa: ");
                            id = int.Parse(Console.ReadLine());
                            found = false;

                            for (int i = 0; i < ds.Count; i++)
                            {
                                if (ds[i].Id == id)
                                {
                                    ds.RemoveAt(i);
                                    Console.WriteLine("Da xoa!");
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                                Console.WriteLine("Khong tim thay!");
                            break;

                        case 6:
                            Console.WriteLine("Ket thuc chuong trinh!");
                            break;

                        default:
                            Console.WriteLine("Lua chon khong hop le!");
                            break;
                    }

                } while (chon != 6);
            }
        }
    }
}
