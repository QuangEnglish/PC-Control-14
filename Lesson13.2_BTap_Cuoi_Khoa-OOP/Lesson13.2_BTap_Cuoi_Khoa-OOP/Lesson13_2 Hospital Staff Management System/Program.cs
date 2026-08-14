using System.Globalization;

namespace Lesson13_2_Hospital_Staff_Management_System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        StaffManager manager = new StaffManager();

        // Tao du lieu mau
        Doctor doctor = new Doctor(
            "BS001",
            "Nguyễn Văn An",
            "Tim mạch",
            "Tim mạch",
            20,
            "BS-2024-001");

        Nurse nurse = new Nurse(
            "DD001",
            "Trần Thị Bình",
            "Nội tổng hợp",
            "ICU",
            "Sáng");

        Pharmacist pharmacist = new Pharmacist(
            "DS001",
            "Lê Văn Cường",
            "Dược",
            "Nhà thuốc chính",
            "Dược sĩ Đại học");

        manager.AddStaff(doctor);
        manager.AddStaff(nurse);
        manager.AddStaff(pharmacist);

       int choice;
       
        do
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine(" HOSPITAL STAFF MANAGEMENT SYSTEM");
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
            
            int.TryParse(Console.ReadLine(), out choice);
           // int choice = Convert.ToInt32(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                    ShowAllStaff(manager);
                    break;
                case 2:
                    manager.PrintAllRoles();
                    break;
                case 3:
                    AddStaff(manager); break;
                case 4:
                    FindStaff(manager); break;
                case 5:
                    CheckInStaff(manager); break;
                case 6:
                    CheckOutStaff(manager); break;
                case 7:
                    manager.CheckInAll();
                    Console.WriteLine(">> Tất cả nhân viên đã vào ca.");
                    break;
                case 8:
                    manager.CheckOutAll();
                    Console.WriteLine(">> Tất cả nhân viên đã ra ca.");
                    break;
                case 9:
                    DoctorPatientMenu(manager); break;
                case 10:
                    ChangeNurseShift(manager); break;
                case 11:
                    ProcessPrescription(manager); break;
                case 0:
                    Console.WriteLine(">> Thoát chương trình."); break;
                default:
                    Console.WriteLine(">> Chức năng không hợp lệ."); break;
            }

        } while (choice != 0);

        // 1. Hiển thị tất cả nhân viên1
        static void ShowAllStaff(StaffManager manager)
        {
            Console.WriteLine();
            Console.WriteLine("=== DANH SÁCH NHÂN VIÊN ===");

            var staffs = manager.GetAllStaff();

            if (staffs.Count == 0)
            {
                Console.WriteLine("Chua co nhan vien nao");
                return;
            }

            int count = 1;
            foreach (var staff in staffs)
            {
                Console.WriteLine();
                if (staff is Doctor doctor)
                {
                    Console.WriteLine($"[{count}] DOCTOR - {doctor.StaffId}");
                    Console.WriteLine($" Họ tên: {doctor.FullName}");
                    Console.WriteLine($" Khoa: {doctor.Department}");
                    Console.WriteLine($" Chuyên khoa: {doctor.Specialty} | " + $"GPHM: {doctor.LicenseNumber}");
                    Console.WriteLine($" Bệnh nhân: {doctor.PatientCount}/{doctor.MaxPatients}");
                    Console.WriteLine($" Ngày vào làm: " + $"{doctor.HireDate:dd/MM/yyyy}");
                }
                else if (staff is Nurse nurse)
                {
                    Console.WriteLine($"[{count}] NURSE - {nurse.StaffId}");
                    Console.WriteLine($" Họ tên: {nurse.FullName}");
                    Console.WriteLine($" Khoa: {nurse.Department}");
                    Console.WriteLine($" Khu vực: {nurse.Ward} | " + $"Ca trực: {nurse.ShiftType}");
                    Console.WriteLine($" Giờ làm tháng này: " + $"{nurse.TotalHoursWorked} giờ");
                    Console.WriteLine($" Ngày vào làm: " + $"{nurse.HireDate:dd/MM/yyyy}");
                }
                else if (staff is Pharmacist pharmacist)
                {
                    Console.WriteLine($"[{count}] PHARMACIST - " + $"{pharmacist.StaffId}");
                    Console.WriteLine($" Họ tên: {pharmacist.FullName}");
                    Console.WriteLine($" Khoa: {pharmacist.Department}");
                    Console.WriteLine($" Chi nhánh: {pharmacist.PharmacyBranch} | " +
                                      $"Bằng cấp: {pharmacist.CertificateLevel}");
                    Console.WriteLine($" Đơn đã xử lý hôm nay: " + $"{pharmacist.PrescriptionCount}");
                    Console.WriteLine($" Ngày vào làm: " + $"{pharmacist.HireDate:dd/MM/yyyy}");
                }

                count++;
            }

            Console.WriteLine();
            Console.WriteLine($"Tổng: {staffs.Count} nhân viên");

        }

        // 3. Them nhan vien moi
        static void AddStaff(StaffManager manager)
        {
            Console.WriteLine();
            Console.WriteLine("=== THÊM NHÂN VIÊN ===");

            Console.WriteLine("1. Doctor");
            Console.WriteLine("2. Nurse");
            Console.WriteLine("3. Pharmacist");
            Console.Write("Chọn loại: ");

            int type = int.Parse(Console.ReadLine());

            Console.Write("Staff ID: ");
            string staffId = Console.ReadLine();
            Console.Write("Họ tên: ");
            string fullName = Console.ReadLine();
            Console.Write("Khoa: ");
            string department = Console.ReadLine();

            if (type == 1)
            {
                Console.Write("Chuyên khoa: ");
                string specialty = Console.ReadLine();
                Console.Write("GPHM: ");
                string licenseNumber = Console.ReadLine();
                Console.Write("Số bệnh nhân tối đa: ");
                int maxPatients = int.Parse(Console.ReadLine());

                Doctor doctor = new Doctor(
                    staffId,
                    fullName,
                    department,
                    specialty,
                    maxPatients,
                    licenseNumber);

                manager.AddStaff(doctor);

                Console.WriteLine(">> Đã thêm Doctor.");

            }
            else if (type == 2)
            {
                Console.Write("Khu vực: ");
                string ward = Console.ReadLine();
                Console.Write("Ca trực: ");
                string shiftType = Console.ReadLine();

                Nurse nurse = new Nurse(
                    staffId, fullName,
                    department,
                    ward,
                    shiftType);

                manager.AddStaff(nurse);

                Console.WriteLine(">> Đã thêm Nurse.");
            }
            else if (type == 3)
            {
                Console.Write("Chi nhánh nhà thuốc: ");
                string pharmacyBranch = Console.ReadLine();
                Console.Write("Bằng cấp: ");
                string certificateLevel = Console.ReadLine();

                Pharmacist pharmacist = new Pharmacist(
                    staffId,
                    fullName,
                    department,
                    pharmacyBranch,
                    certificateLevel);

                manager.AddStaff(pharmacist);

                Console.WriteLine(">> Đã thêm Pharmacist.");
            }
            else
            {
                Console.WriteLine(">> Loại nhân viên không hợp lệ.");
            }

        }

        // 4. Tìm nhân viên
        static void FindStaff(StaffManager manager)
        {
            Console.Write("Nhập Staff ID: ");
            string staffId = Console.ReadLine();

            Staff staff = manager.FindStaff(staffId);

            if (staff == null)
            {
                Console.WriteLine(">> Không tìm thấy nhân viên.");
                return;
            }

            Console.WriteLine("=== THÔNG TIN NHÂN VIÊN ===");
            Console.WriteLine(staff.GetInfo());
        }

        // 5. CheckInAll
        static void CheckInStaff(StaffManager manager)
        {
            Console.Write("Nhập Staff ID: ");
            string staffId = Console.ReadLine();

            Staff staff = manager.FindStaff(staffId);

            if (staff == null)
            {
                Console.WriteLine(">> Không tìm thấy nhân viên.");
                return;
            }

            bool result = staff.CheckIn();

            if (result)
            {
                Console.WriteLine($">> {staff.FullName} đã vào ca!");
            }
            else
            {
                Console.WriteLine(">> Không thể vào ca.");
            }
        }

        // 6. CheclOutAll
        static void CheckOutStaff(StaffManager manager)
        {
            Console.Write("Nhập Staff ID: ");
            string staffId = Console.ReadLine();

            Staff staff = manager.FindStaff(staffId);

            if (staff == null)
            {
                Console.WriteLine(">> Không tìm thấy nhân viên.");
                return;
            }

            bool result = staff.CheckOut();

            if (result)
            {
                Console.WriteLine($">> {staff.FullName} đã ra ca!");
            }
            else
            {
                Console.WriteLine(">> Không thể vào ca.");
            }
        }

        // 9. Doctor: tiếp nhận / xuất viện
        static void DoctorPatientMenu(StaffManager manager)
        {
            Console.WriteLine();
            Console.WriteLine("1. Tiếp nhận bệnh nhân");
            Console.WriteLine("2. Xuất viện bệnh nhân");
            Console.Write("Chọn: ");

            int choice = int.Parse(Console.ReadLine());

            Console.Write("Nhập ID Bác sĩ: ");
            string staffId = Console.ReadLine();

            Staff staff = manager.FindStaff(staffId);

            if (staff is not Doctor doctor)
            {
                Console.WriteLine(">> Nhân viên này không phải Doctor.");
                return;
            }

            if (choice == 1)
            {
                bool result = doctor.AcceptPatient();

                if (result)
                {
                    Console.WriteLine($">> Bác sĩ {doctor.FullName} "
                                      + $"đã tiếp nhận bệnh nhân!");
                    Console.WriteLine($">> Số bệnh nhân hiện tại: "
                                      + $"{doctor.PatientCount}/{doctor.MaxPatients}");
                }
                else
                {
                    Console.WriteLine(">> Bác sĩ đã đủ số bệnh nhân.");
                }
            }


            else if (choice == 2)
            {
                bool result = doctor.DischargePatient();

                if (result)
                {
                    Console.WriteLine($">> Bệnh nhân đã được xuất viện.");
                    Console.WriteLine($">> Số bệnh nhân hiện tại: "
                                      + $"{doctor.PatientCount}/{doctor.MaxPatients}");
                }
                else
                {
                    Console.WriteLine(">> Hiện tại không có bệnh nhân.");
                }
            }
            
        }


        // 10. Nurse: đổi ca
            static void ChangeNurseShift(StaffManager manager)
            {
                Console.Write("Nhập ID Nurse: ");
                string staffId = Console.ReadLine();

                Staff staff = manager.FindStaff(staffId);

                if (staff is not Nurse nurse)
                {
                    Console.WriteLine(">> Nhân viên này không phải Nurse.");
                    return;
                }

                Console.Write("Nhập ca mới (Sang/Chieu/Dem): ");
                string newShift = Console.ReadLine();

                try
                {
                    nurse.ChangeShift(newShift);
                    Console.WriteLine($">> Đã đổi ca thành: {nurse.ShiftType}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($">> Lỗi: {ex.Message}");
                }
            }

            // 11. Pharmacist: xử lý đơn thuốc
            static void ProcessPrescription(StaffManager manager)
                {
                    Console.Write("Nhập ID Dược sĩ: ");
                    string staffId = Console.ReadLine();

                    Staff staff = manager.FindStaff(staffId);

                    if (staff is not Pharmacist pharmacist)
                    {
                        Console.WriteLine(">> Nhân viên này không phải Pharmacist.");
                        return;
                    }

                    Console.WriteLine(">> Đang xử lý đơn thuốc...");

                    pharmacist.ProcessPrescription();

                    if (pharmacist.IsLicenseValid)
                    {
                        Console.WriteLine($">> Dược sĩ {pharmacist.FullName} "
                                          + "đã xử lý đơn thuốc thành công!");

                        Console.WriteLine($">> Tổng đơn hôm nay: " + $"{pharmacist.PrescriptionCount}");
                    }


                }
            
        
    }
}


