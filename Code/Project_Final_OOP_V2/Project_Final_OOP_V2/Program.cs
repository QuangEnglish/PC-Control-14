using Project_Final_OOP_V2.Models;
using Project_Final_OOP_V2.Services;

namespace Project_Final_OOP_V2;

class Program
{
    static void Main(string[] args)
    {
        // Tạo StaffManager và thêm dữ liệu mẫu
        StaffManager manager = new StaffManager();
        SeedData(manager);

        bool running = true;
        while (running)
        {
            ShowMenu();
            Console.Write("Chọn chức năng: ");
            string? choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    ShowAllStaff(manager);
                    break;
                case "2":
                    manager.PrintAllRoles();
                    break;
                case "3":
                    AddNewStaff(manager);
                    break;
                case "4":
                    FindStaffById(manager);
                    break;
                case "5":
                    CheckInStaff(manager);
                    break;
                case "6":
                    CheckOutStaff(manager);
                    break;
                case "7":
                    manager.CheckInAll();
                    break;
                case "8":
                    manager.CheckOutAll();
                    break;
                case "9":
                    HandlePatient(manager);
                    break;
                case "10":
                    ChangeNurseShift(manager);
                    break;
                case "11":
                    ProcessPrescription(manager);
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Cảm ơn bạn đã sử dụng hệ thống! Tạm biệt!");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chọn lại.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    // Hiển thị menu chính
    static void ShowMenu()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("   HOSPITAL STAFF MANAGEMENT SYSTEM");
        Console.WriteLine("========================================");
        Console.WriteLine("1. Hiển thị tất cả nhân viên");
        Console.WriteLine("2. Hiển thị vai trò nhân viên");
        Console.WriteLine("3. Thêm nhân viên mới");
        Console.WriteLine("4. Tìm kiếm nhân viên theo ID");
        Console.WriteLine("5. Vào ca (Check In)");
        Console.WriteLine("6. Ra ca (Check Out)");
        Console.WriteLine("7. Tất cả vào ca");
        Console.WriteLine("8. Tất cả ra ca");
        Console.WriteLine("9. Tiếp nhận / Xuất viện bệnh nhân (Doctor)");
        Console.WriteLine("10. Đổi ca trực (Nurse)");
        Console.WriteLine("11. Xử lý đơn thuốc (Pharmacist)");
        Console.WriteLine("0. Thoát");
        Console.WriteLine("========================================");
    }

    // Thêm dữ liệu mẫu
    static void SeedData(StaffManager manager)
    {
        manager.AddStaff(new Doctor("BS001", "Nguyễn Văn An", "Tim mạch",
            "Tim mạch", 20, "BS-2024-001"));
        manager.AddStaff(new Nurse("DD001", "Trần Thị Bình", "Nội tổng hợp",
            "ICU", "Sáng"));
        manager.AddStaff(new Pharmacist("DS001", "Lê Văn Cường", "Dược",
            "Nhà thuốc chính", "Dược sĩ Đại học"));
        Console.Clear();
    }

    // 1. Hiển thị tất cả nhân viên
    static void ShowAllStaff(StaffManager manager)
    {
        List<Staff> allStaff = manager.GetAllStaff();
        Console.WriteLine("=== DANH SÁCH NHÂN VIÊN ===\n");

        for (int i = 0; i < allStaff.Count; i++)
        {
            Staff staff = allStaff[i];
            string type = staff switch
            {
                Doctor => "DOCTOR",
                Nurse => "NURSE",
                Pharmacist => "PHARMACIST",
                _ => "STAFF"
            };

            Console.WriteLine($"[{i + 1}] {type} - {staff.StaffId}");
            Console.WriteLine($"    {staff.GetInfo()}");
            Console.WriteLine();
        }

        Console.WriteLine($"Tổng: {allStaff.Count} nhân viên");
    }

    // 3. Thêm nhân viên mới
    static void AddNewStaff(StaffManager manager)
    {
        Console.WriteLine("=== THÊM NHÂN VIÊN MỚI ===");
        Console.WriteLine("1. Bác sĩ (Doctor)");
        Console.WriteLine("2. Điều dưỡng (Nurse)");
        Console.WriteLine("3. Dược sĩ (Pharmacist)");
        Console.Write("Chọn loại nhân viên: ");
        string? type = Console.ReadLine();

        Console.Write("Nhập mã nhân viên: ");
        string staffId = Console.ReadLine() ?? "";
        Console.Write("Nhập họ tên: ");
        string fullName = Console.ReadLine() ?? "";
        Console.Write("Nhập khoa/phòng ban: ");
        string department = Console.ReadLine() ?? "";

        try
        {
            switch (type)
            {
                case "1":
                    Console.Write("Nhập chuyên khoa: ");
                    string specialty = Console.ReadLine() ?? "";
                    Console.Write("Nhập số bệnh nhân tối đa: ");
                    int maxPatients = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Nhập số giấy phép hành nghề: ");
                    string license = Console.ReadLine() ?? "";
                    manager.AddStaff(new Doctor(staffId, fullName, department,
                        specialty, maxPatients, license));
                    break;

                case "2":
                    Console.Write("Nhập khu vực phụ trách: ");
                    string ward = Console.ReadLine() ?? "";
                    Console.Write("Nhập ca trực (Sáng/Chiều/Đêm): ");
                    string shift = Console.ReadLine() ?? "";
                    manager.AddStaff(new Nurse(staffId, fullName, department,
                        ward, shift));
                    break;

                case "3":
                    Console.Write("Nhập chi nhánh nhà thuốc: ");
                    string branch = Console.ReadLine() ?? "";
                    Console.Write("Nhập bằng cấp: ");
                    string cert = Console.ReadLine() ?? "";
                    manager.AddStaff(new Pharmacist(staffId, fullName, department,
                        branch, cert));
                    break;

                default:
                    Console.WriteLine("Loại nhân viên không hợp lệ!");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}");
        }
    }

    // 4. Tìm kiếm nhân viên theo ID
    static void FindStaffById(StaffManager manager)
    {
        Console.Write("Nhập ID nhân viên cần tìm: ");
        string id = Console.ReadLine() ?? "";
        Staff? staff = manager.FindStaff(id);

        if (staff == null)
        {
            Console.WriteLine($">> Không tìm thấy nhân viên có ID: {id}");
        }
        else
        {
            Console.WriteLine("\n=== KẾT QUẢ TÌM KIẾM ===\n");
            Console.WriteLine($"    {staff.GetInfo()}");
            Console.WriteLine($"    Vai trò: {staff.GetRole()}");
        }
    }

    // 5. Vào ca (Check In) cho 1 nhân viên
    static void CheckInStaff(StaffManager manager)
    {
        Console.Write("Nhập ID nhân viên cần vào ca: ");
        string id = Console.ReadLine() ?? "";
        Staff? staff = manager.FindStaff(id);

        if (staff == null)
            Console.WriteLine($">> Không tìm thấy nhân viên có ID: {id}");
        else
            staff.CheckIn();
    }

    // 6. Ra ca (Check Out) cho 1 nhân viên
    static void CheckOutStaff(StaffManager manager)
    {
        Console.Write("Nhập ID nhân viên cần ra ca: ");
        string id = Console.ReadLine() ?? "";
        Staff? staff = manager.FindStaff(id);

        if (staff == null)
            Console.WriteLine($">> Không tìm thấy nhân viên có ID: {id}");
        else
            staff.CheckOut();
    }

    // 9. Tiếp nhận / Xuất viện bệnh nhân
    static void HandlePatient(StaffManager manager)
    {
        Console.Write("Nhập ID Bác sĩ: ");
        string id = Console.ReadLine() ?? "";
        Staff? staff = manager.FindStaff(id);

        if (staff == null)
        {
            Console.WriteLine($">> Không tìm thấy nhân viên có ID: {id}");
            return;
        }

        if (staff is not Doctor doctor)
        {
            Console.WriteLine(">> Nhân viên này không phải là bác sĩ!");
            return;
        }

        Console.WriteLine("1. Tiếp nhận bệnh nhân");
        Console.WriteLine("2. Xuất viện bệnh nhân");
        Console.Write("Chọn: ");
        string? choice = Console.ReadLine();

        if (choice == "1")
            doctor.AcceptPatient();
        else if (choice == "2")
            doctor.DischargePatient();
        else
            Console.WriteLine("Lựa chọn không hợp lệ!");
    }

    // 10. Đổi ca trực cho Nurse
    static void ChangeNurseShift(StaffManager manager)
    {
        Console.Write("Nhập ID Điều dưỡng: ");
        string id = Console.ReadLine() ?? "";
        Staff? staff = manager.FindStaff(id);

        if (staff == null)
        {
            Console.WriteLine($">> Không tìm thấy nhân viên có ID: {id}");
            return;
        }

        if (staff is not Nurse nurse)
        {
            Console.WriteLine(">> Nhân viên này không phải là điều dưỡng!");
            return;
        }

        Console.Write("Nhập ca trực mới (Sáng/Chiều/Đêm): ");
        string newShift = Console.ReadLine() ?? "";
        nurse.ChangeShift(newShift);
    }

    // 11. Xử lý đơn thuốc
    static void ProcessPrescription(StaffManager manager)
    {
        Console.Write("Nhập ID Dược sĩ: ");
        string id = Console.ReadLine() ?? "";
        Staff? staff = manager.FindStaff(id);

        if (staff == null)
        {
            Console.WriteLine($">> Không tìm thấy nhân viên có ID: {id}");
            return;
        }

        if (staff is not Pharmacist pharmacist)
        {
            Console.WriteLine(">> Nhân viên này không phải là dược sĩ!");
            return;
        }

        pharmacist.ProcessPrescription();
    }
}
