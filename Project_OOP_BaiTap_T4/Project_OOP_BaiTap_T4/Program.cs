using Project_OOP_BaiTap_T4.Models;
using Project_OOP_BaiTap_T4.Services;

namespace Project_OOP_BaiTap_T4;

class Program
{
    // StaffManager dùng chung cho toàn bộ chương trình
    private static StaffManager _manager = new StaffManager();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        SeedSampleData(); // tạo sẵn vài nhân viên mẫu để test nhanh

        bool running = true;
        while (running)
        {
            PrintMenu();
            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": ShowAllStaff(); break;
                case "2": ShowAllRoles(); break;
                case "3": AddNewStaff(); break;
                case "4": SearchStaff(); break;
                case "5": CheckInOne(); break;
                case "6": CheckOutOne(); break;
                case "7": _manager.CheckInAll(); Console.WriteLine(">> Tất cả nhân viên đã vào ca."); break;
                case "8": _manager.CheckOutAll(); Console.WriteLine(">> Tất cả nhân viên đã ra ca."); break;
                case "9": HandlePatient(); break;
                case "10": ChangeNurseShift(); break;
                case "11": ProcessPrescription(); break;
                case "0": running = false; Console.WriteLine("Tạm biệt!"); break;
                default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
            }

            if (running)
            {
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                Console.Read();
                try { Console.Clear(); } catch (IOException) { /* console không hỗ trợ Clear (vd: output bị redirect) */ }
            }
        }
    }

    private static void PrintMenu()
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
        Console.Write("Chọn chức năng: ");
    }

    private static void SeedSampleData()
    {
        _manager.AddStaff(new Doctor("BS001", "Nguyễn Văn An", "Tim mạch", "Tim mạch", 20, "BS-2024-001"));
        _manager.AddStaff(new Nurse("DD001", "Trần Thị Bình", "Nội tổng hợp", "ICU", "Sáng"));
        _manager.AddStaff(new Pharmacist("DS001", "Lê Văn Cường", "Dược", "Nhà thuốc chính", "Dược sĩ Đại học"));
    }

    private static void ShowAllStaff()
    {
        Console.WriteLine("=== DANH SÁCH NHÂN VIÊN ===\n");
        List<Staff> all = _manager.GetAllStaff();
        for (int i = 0; i < all.Count; i++)
        {
            Staff s = all[i];
            // s.GetType().Name lấy tên class thực tế (Doctor/Nurse/Pharmacist) tại runtime
            Console.WriteLine($"[{i + 1}] {s.GetType().Name.ToUpper()} - {s.StaffId}");
            Console.WriteLine($"    {s.GetInfo()}\n");
        }
        Console.WriteLine($"Tổng: {all.Count} nhân viên");
    }

    private static void ShowAllRoles()
    {
        Console.WriteLine("=== VAI TRÒ NHÂN VIÊN ===\n");
        _manager.PrintAllRoles();
    }

    private static void AddNewStaff()
    {
        Console.WriteLine("Chọn loại nhân viên: 1. Doctor  2. Nurse  3. Pharmacist");
        string? type = Console.ReadLine();

        Console.Write("Mã nhân viên: ");
        string id = Console.ReadLine() ?? "";
        Console.Write("Họ tên: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Khoa/Phòng ban: ");
        string dept = Console.ReadLine() ?? "";

        try
        {
            switch (type)
            {
                case "1":
                    Console.Write("Chuyên khoa: ");
                    string specialty = Console.ReadLine() ?? "";
                    Console.Write("Số bệnh nhân tối đa: ");
                    int maxPatients = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Số giấy phép hành nghề: ");
                    string license = Console.ReadLine() ?? "";
                    _manager.AddStaff(new Doctor(id, name, dept, specialty, maxPatients, license));
                    break;

                case "2":
                    Console.Write("Khu vực (ward): ");
                    string ward = Console.ReadLine() ?? "";
                    Console.Write("Ca trực (Sáng/Chiều/Đêm): ");
                    string shift = Console.ReadLine() ?? "";
                    _manager.AddStaff(new Nurse(id, name, dept, ward, shift));
                    break;

                case "3":
                    Console.Write("Chi nhánh nhà thuốc: ");
                    string branch = Console.ReadLine() ?? "";
                    Console.Write("Bằng cấp: ");
                    string cert = Console.ReadLine() ?? "";
                    _manager.AddStaff(new Pharmacist(id, name, dept, branch, cert));
                    break;

                default:
                    Console.WriteLine("Loại nhân viên không hợp lệ!");
                    return;
            }
            Console.WriteLine(">> Thêm nhân viên thành công!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($">> Lỗi: {ex.Message}");
        }
    }

    private static void SearchStaff()
    {
        Console.Write("Nhập ID nhân viên cần tìm: ");
        string id = Console.ReadLine() ?? "";
        Staff? staff = _manager.FindStaff(id);
        if (staff == null)
        {
            Console.WriteLine(">> Không tìm thấy nhân viên!");
            return;
        }
        Console.WriteLine($"{staff.GetType().Name.ToUpper()} - {staff.StaffId}");
        Console.WriteLine($"    {staff.GetInfo()}");
    }

    private static void CheckInOne()
    {
        Console.Write("Nhập ID nhân viên: ");
        Staff? staff = _manager.FindStaff(Console.ReadLine() ?? "");
        if (staff == null) { Console.WriteLine(">> Không tìm thấy nhân viên!"); return; }

        bool ok = staff.CheckIn();
        Console.WriteLine(ok ? $">> {staff.FullName} đã vào ca." : $">> {staff.FullName} không thể vào ca.");
    }

    private static void CheckOutOne()
    {
        Console.Write("Nhập ID nhân viên: ");
        Staff? staff = _manager.FindStaff(Console.ReadLine() ?? "");
        if (staff == null) { Console.WriteLine(">> Không tìm thấy nhân viên!"); return; }

        staff.CheckOut();
        Console.WriteLine($">> {staff.FullName} đã ra ca.");
    }

    private static void HandlePatient()
    {
        Console.Write("Nhập ID Bác sĩ: ");
        Staff? staff = _manager.FindStaff(Console.ReadLine() ?? "");
        if (staff is not Doctor doctor)
        {
            Console.WriteLine(">> Không tìm thấy bác sĩ với ID này!");
            return;
        }

        Console.WriteLine("1. Tiếp nhận bệnh nhân   2. Xuất viện bệnh nhân");
        string? action = Console.ReadLine();
        if (action == "1")
        {
            if (doctor.AcceptPatient())
            {
                Console.WriteLine($">> Bác sĩ {doctor.FullName} đã tiếp nhận bệnh nhân!");
                Console.WriteLine($">> Số bệnh nhân hiện tại: {doctor.PatientCount}/{doctor.MaxPatients}");
            }
            else
            {
                Console.WriteLine(">> Đã đủ số bệnh nhân tối đa, không thể tiếp nhận thêm!");
            }
        }
        else if (action == "2")
        {
            if (doctor.DischargePatient())
            {
                Console.WriteLine($">> Bác sĩ {doctor.FullName} đã cho bệnh nhân xuất viện!");
                Console.WriteLine($">> Số bệnh nhân hiện tại: {doctor.PatientCount}/{doctor.MaxPatients}");
            }
            else
            {
                Console.WriteLine(">> Hiện không có bệnh nhân nào để xuất viện!");
            }
        }
    }

    private static void ChangeNurseShift()
    {
        Console.Write("Nhập ID Điều dưỡng: ");
        Staff? staff = _manager.FindStaff(Console.ReadLine() ?? "");
        if (staff is not Nurse nurse)
        {
            Console.WriteLine(">> Không tìm thấy điều dưỡng với ID này!");
            return;
        }

        Console.Write("Ca trực mới (Sáng/Chiều/Đêm): ");
        string newShift = Console.ReadLine() ?? "";
        nurse.ChangeShift(newShift);
    }

    private static void ProcessPrescription()
    {
        Console.Write("Nhập ID Dược sĩ: ");
        Staff? staff = _manager.FindStaff(Console.ReadLine() ?? "");
        if (staff is not Pharmacist pharmacist)
        {
            Console.WriteLine(">> Không tìm thấy dược sĩ với ID này!");
            return;
        }

        pharmacist.ProcessPrescription();
    }
}
