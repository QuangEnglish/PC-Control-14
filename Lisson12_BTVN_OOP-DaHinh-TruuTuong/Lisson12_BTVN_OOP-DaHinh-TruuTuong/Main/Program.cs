namespace Lisson12_BTVN_OOP_DaHinh_TruuTuong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee employee = new Developer("1234", 20, "HAI", 4.0, "Khong");
            //employee.ShowInfo();

            //Developer developer = new Developer("125225", 25, "Nam", 3.0, "Co");
            //developer.ShowInfo();

            //Person developerV2 = new Developer();
            //developerV2.Name = "HaiNam";
            //developerV2.Show();

            //Tester tester = new Tester();
            //tester.Work();
            //tester.ShowInfo();

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Employee> employees = new List<Employee>();

            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Thêm Developer");
                Console.WriteLine("2. Thêm Tester");
                Console.WriteLine("3. Hiển thị danh sách");
                Console.WriteLine("4. Cho tất cả nhân viên làm việc");
                Console.WriteLine("5. Tìm theo ID");
                Console.WriteLine("6. Cập nhật lương");
                Console.WriteLine("7. Xóa nhân viên");
                Console.WriteLine("0. Thoát");

                Console.Write(" Mời Chọn: ");

                int meNu = Convert.ToInt32(Console.ReadLine());

                //if (meNu == 0) return;

                switch (meNu)
                {
                    case 1:
                        ThemDeveloper(employees);
                        break;

                    case 2:
                        ThemTester(employees);
                        break;

                    case 3:
                        foreach (Employee e in employees)
                        {
                            e.ShowInfo();
                            Console.WriteLine("----------------");
                        }
                        break;

                    case 4:
                        foreach (Employee e in employees)
                        {
                            e.Work();   // Đúng yêu cầu đề
                        }
                        break;

                    case 5:
                        Console.Write("Nhập ID: ");
                        string id = Console.ReadLine();

                        foreach (Employee e in employees)
                        {
                            if (e.Id == id)
                            {
                                e.ShowInfo();
                                break;
                            }
                        }
                        break;

                    case 6:
                        Console.Write("\n Nhập ID: ");
                        id = Console.ReadLine();

                        foreach (Employee e in employees)
                        {
                            if (e.Id == id)
                            {
                                Console.Write("\n Nhập lương mới: ");
                                e.Salary = double.Parse(Console.ReadLine());
                                break;
                            }
                        }
                        break;

                    case 7:
                        Console.Write("\n Nhập ID cần xóa: ");
                        id = Console.ReadLine();

                        Employee xoa = null;

                        foreach (Employee e in employees)
                        {
                            if (e.Id == id)
                            {
                                xoa = e;
                                break;
                            }
                        }

                        if (xoa != null)
                            employees.Remove(xoa);

                        break;

                    case 0:
                        Console.WriteLine("Tạm Biệt!");
                        //meNu = 0;
                        return;
                }
            }

            static void ThemDeveloper(List<Employee> employees)
            {
                Console.Write("ID: ");
                string id = Console.ReadLine();

                Console.Write("Tuổi: ");
                int age = int.Parse(Console.ReadLine());


                Console.Write("Tên: ");
                string name = Console.ReadLine();

                Console.Write("Lương: ");
                double salary = double.Parse(Console.ReadLine());

                Console.Write("Phòng ban: ");
                string departmen = Console.ReadLine();

                employees.Add(new Developer(id, age, name, salary, departmen));
            }

            static void ThemTester(List<Employee> employees)
            {
                Console.Write("ID: ");
                string id = Console.ReadLine();

                Console.Write("Tuổi: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Tên: ");
                string name = Console.ReadLine();

                Console.Write("Lương: ");
                double salary = double.Parse(Console.ReadLine());

                Console.Write("Phòng ban: ");
                string departmen = Console.ReadLine();

                employees.Add(new Tester(id, age, name, salary, departmen));
            }

        }
    }
}
