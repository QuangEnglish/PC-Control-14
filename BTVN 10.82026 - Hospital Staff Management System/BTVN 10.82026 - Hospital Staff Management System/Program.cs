using BTVN_10._82026___Hospital_Staff_Management_System.Service;

namespace BTVN_10._82026___Hospital_Staff_Management_System;

class Program
{
    private static object _manager;

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // StaffManager dùng chung cho toàn bộ chương trình.
        SeedData(); // Tạo sẵn vài nhân viên mẫu để demo cho nhanh

        bool isRunning = true;
        while (isRunning)
        {
            ShowMenu();
            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": ShowAllStaff(); break;
                case "2": ShowAllRoles(); break;
                case "3": AddNewStaff(); break;
                case "4": SearchStaff(); break;
                case "5": DoCheckIn(); break;
                case "6": DoCheckOut(); break;
                case "7": _manager.CheckInAll(); Console.WriteLine(">> Tất cả nhân viên đã vào ca."); break;
                case "8": _manager.CheckOutAll(); Console.WriteLine(">> Tất cả nhân viên đã ra ca."); break;
                case "9": HandlePatient(); break;
                case "10": ChangeNurseShift(); break;
                case "11": ProcessPrescriptionMenu(); break;
                case "0": isRunning = false; Console.WriteLine("Tạm biệt!"); break;
                default: Console.WriteLine(">> Lựa chọn không hợp lệ!"); break;
            }

            if (isRunning)
            {
                Console.WriteLine("\nNhấn Enter để tiếp tục...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    // Tạo sẵn 3 nhân viên mẫu (đúng như ví dụ trong đề bài) để chương trình có dữ liệu ngay khi chạy.
    private static void SeedData()
    {
        _manager.AddStaff(new Doctor("BS001", "Nguyễn Văn An", "Tim mạch",
                                      "Tim mạch", 20, "BS-2024-001"));

        _manager.AddStaff(new Nurse("DD001", "Trần Thị Bình", "Nội tổng hợp",
                                     "ICU", "Sáng"));

        _manager.AddStaff(new Pharmacist("DS001", "Lê Văn Cường", "Dược",
                                          "Nhà thuốc chính", "Dược sĩ Đại học"));
    }

    // ====================== MENU ======================
    private static void ShowMenu()
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

    // ====================== CÁC CHỨC NĂNG ======================

    // 1. Hiển thị tất cả nhân viên (dùng GetInfo() - mỗi loại nhân viên tự hiển thị thông tin riêng)
    private static void ShowAllStaff()
    {
        List<Staff> list = _manager.GetAllStaff();
        Console.WriteLine("=== DANH SÁCH NHÂN VIÊN ===\n");

        for (int i = 0; i < list.Count; i++)
        {
            Staff s = list[i];
            string loai = s.GetType().Name.ToUpper(); // DOCTOR / NURSE / PHARMACIST
            Console.WriteLine($"[{i + 1}] {loai} - {s.StaffId}");
            Console.WriteLine("    " + s.GetInfo());
            Console.WriteLine();
        }

        Console.WriteLine($"Tổng: {list.Count} nhân viên");
    }

    // 2. Hiển thị vai trò tất cả nhân viên (Polymorphism - StaffManager.PrintAllRoles)
    private static void ShowAllRoles()
    {
        Console.WriteLine("=== VAI TRÒ NHÂN VIÊN ===\n");
        _manager.PrintAllRoles();
    }

    // 3. Thêm nhân viên mới - cho phép chọn loại nhân viên rồi nhập thông tin tương ứng
    private static void AddNewStaff()
    {
        Console.WriteLine("Chọn loại nhân viên:");
        Console.WriteLine("1. Bác sĩ (Doctor)");
        Console.WriteLine("2. Điều dưỡng (Nurse)");
        Console.WriteLine("3. Dược sĩ (Pharmacist)");
        Console.Write("Lựa chọn: ");
        string? type = Console.ReadLine();

        Console.Write("Mã nhân viên: ");
        string staffId = Console.ReadLine() ?? "";

        Console.Write("Họ tên: ");
        string fullName = Console.ReadLine() ?? "";

        Console.Write("Khoa/Phòng ban: ");
        string department = Console.ReadLine() ?? "";

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

                    _manager.AddStaff(new Doctor(staffId, fullName, department,
                                                  specialty, maxPatients, license));
                    Console.WriteLine(">> Đã thêm bác sĩ thành công!");
                    break;

                case "2":
                    Console.Write("Khu vực phụ trách: ");
                    string ward = Console.ReadLine() ?? "";
                    Console.Write("Ca trực (Sáng/Chiều/Đêm): ");
                    string shiftType = Console.ReadLine() ?? "";

                    _manager.AddStaff(new Nurse(staffId, fullName, department, ward, shiftType));
                    Console.WriteLine(">> Đã thêm điều dưỡng thành công!");
                    break;

                case "3":
                    Console.Write("Chi nhánh nhà thuốc: ");
                    string branch = Console.ReadLine() ?? "";
                    Console.Write("Bằng cấp: ");
                    string certificate = Console.ReadLine() ?? "";

                    _manager.AddStaff(new Pharmacist(staffId, fullName, department, branch, certificate));
                    Console.WriteLine(">> Đã thêm dược sĩ thành công!");
                    break;

                default:
                    Console.WriteLine(">> Loại nhân viên không hợp lệ!");
                    break;
            }
        }
        catch (Exception ex)
        {
            // Bắt lỗi validation ném ra từ các Property (ví dụ FullName trống, số âm...)
            Console.WriteLine($">> Lỗi: {ex.Message}");
        }
    }

    // 4. Tìm kiếm nhân viên theo ID
    private static void SearchStaff()
    {
        Console.Write("Nhập ID cần tìm: ");
        string staffId = Console.ReadLine() ?? "";

        Staff? staff = _manager.FindStaff(staffId);
        if (staff == null)
        {
            Console.WriteLine(">> Không tìm thấy nhân viên!");
            return;
        }

        string loai = staff.GetType().Name.ToUpper();
        Console.WriteLine($"{loai} - {staff.StaffId}");
        Console.WriteLine("    " + staff.GetInfo());
    }

    // 5. Vào ca (Check In) theo ID
    private static void DoCheckIn()
    {
        Console.Write("Nhập ID nhân viên: ");
        string staffId = Console.ReadLine() ?? "";

        Staff? staff = _manager.FindStaff(staffId);
        if (staff == null)
        {
            Console.WriteLine(">> Không tìm thấy nhân viên!");
            return;
        }

        bool result = staff.CheckIn();
        Console.WriteLine(result
            ? $">> {staff.FullName} đã vào ca."
            : $">> {staff.FullName} không thể vào ca.");
    }

    // 6. Ra ca (Check Out) theo ID
    private static void DoCheckOut()
    {
        Console.Write("Nhập ID nhân viên: ");
        string staffId = Console.ReadLine() ?? "";

        Staff? staff = _manager.FindStaff(staffId);
        if (staff == null)
        {
            Console.WriteLine(">> Không tìm thấy nhân viên!");
            return;
        }

        staff.CheckOut();
        Console.WriteLine($">> {staff.FullName} đã ra ca.");
    }

    // 9. Tiếp nhận / Xuất viện bệnh nhân - chỉ áp dụng cho Doctor
    private static void HandlePatient()
    {
        Console.Write("Nhập ID Bác sĩ: ");
        string staffId = Console.ReadLine() ?? "";

        // Dùng "as" để ép kiểu an toàn: nếu không phải Doctor thì doctor sẽ là null.
        Staff? staff = _manager.FindStaff(staffId);
        if (staff is not Doctor doctor)
        {
            Console.WriteLine(">> Không tìm thấy bác sĩ với ID này!");
            return;
        }

        Console.WriteLine("1. Tiếp nhận bệnh nhân");
        Console.WriteLine("2. Xuất viện bệnh nhân");
        Console.Write("Lựa chọn: ");
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
                Console.WriteLine(">> Đã đạt số bệnh nhân tối đa, không thể tiếp nhận thêm!");
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
        else
        {
            Console.WriteLine(">> Lựa chọn không hợp lệ!");
        }
    }

    // 10. Đổi ca trực - chỉ áp dụng cho Nurse
    private static void ChangeNurseShift()
    {
        Console.Write("Nhập ID Điều dưỡng: ");
        string staffId = Console.ReadLine() ?? "";

        Staff? staff = _manager.FindStaff(staffId);
        if (staff is not Nurse nurse)
        {
            Console.WriteLine(">> Không tìm thấy điều dưỡng với ID này!");
            return;
        }

        Console.Write("Nhập ca trực mới (Sáng/Chiều/Đêm): ");
        string newShift = Console.ReadLine() ?? "";
        nurse.ChangeShift(newShift);
    }

    // 11. Xử lý đơn thuốc - chỉ áp dụng cho Pharmacist
    private static void ProcessPrescriptionMenu()
    {
        Console.Write("Nhập ID Dược sĩ: ");
        string staffId = Console.ReadLine() ?? "";

        Staff? staff = _manager.FindStaff(staffId);
        if (staff is not Pharmacist pharmacist)
        {
            Console.WriteLine(">> Không tìm thấy dược sĩ với ID này!");
            return;
        }

        pharmacist.ProcessPrescription();
        
    }
}