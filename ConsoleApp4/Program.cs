using ConsoleApp4;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine(
    "========================================\n   HOSPITAL STAFF MANAGEMENT SYSTEM\n========================================\n1. Hiển thị tất cả nhân viên\n2. Hiển thị vai trò nhân viên\n3. Thêm nhân viên mới\n4. Tìm kiếm nhân viên theo ID\n5. Vào ca (Check In)\n6. Ra ca (Check Out)\n7. Tất cả vào ca\n8. Tất cả ra ca\n9. Tiếp nhận / Xuất viện bệnh nhân (Doctor)\n10. Đổi ca trực (Nurse)\n11. Xử lý đơn thuốc (Pharmacist)\n0. Thoát\n========================================\nChọn chức năng:\n");
    StaffManager staffmanager = new StaffManager();
    while (true)
    {
        Console.WriteLine("Hãy chọn chức năng");
        double chucnang = Convert.ToDouble(Console.ReadLine());
        if (chucnang == 0)
        {
            break;
        }
        switch (chucnang)
        {
            case 1:
                Console.WriteLine("=== DANH SÁCH NHÂN VIÊN ===");
                staffmanager.GetAllStaff();
                foreach (Staff staff in staffmanager.GetAllStaff())
                {
                    int i = 0;
                    i++;
                    Console.WriteLine($"[{i}]");
                    Console.WriteLine(staff.GetInfo());
                }

                Console.WriteLine($"Tổng: {staffmanager.GetAllStaff().Count()} nhân viên");
                break;
            case 2:
                staffmanager.PrintAllRoles().ForEach(staff => Console.WriteLine(staff.GetRole()));
                break;
            case 3:
                Console.WriteLine("Hãy chọn chức vụ");
                Console.WriteLine("1. Doctor");
                Console.WriteLine("2. Nurse");
                Console.WriteLine("3. Pharmacist");
                int a = Convert.ToInt32(Console.ReadLine());
                if (a == 1)
                {
                    Console.WriteLine("Nhập ID");
                    string staffID = Console.ReadLine();
                    Console.WriteLine("Nhập tên đầy đủ");
                    string fullName = Console.ReadLine();
                    Console.WriteLine("Nhập phòng ban");
                    string department = Console.ReadLine();
                    Console.WriteLine("Nhập chuyên môn");
                    string specialty = Console.ReadLine();
                    Console.WriteLine("Nhập số bệnh nhân Max");
                    int maxPatient = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nhập số giấy phép");
                    string licenseNumber = Console.ReadLine();
                    staffmanager.AddStaff(new Doctor(staffID, fullName, department, specialty, maxPatient, licenseNumber));
                }
                else if (a == 2)
                {
                    Console.WriteLine("Nhập ID");
                    string staffID = Console.ReadLine();
                    Console.WriteLine("Nhập tên đầy đủ");
                    string fullName = Console.ReadLine();
                    Console.WriteLine("Nhập phòng ban");
                    string department = Console.ReadLine();
                    Console.WriteLine("Nhập khu vực");
                    string ward = Console.ReadLine();
                    Console.WriteLine("Nhập ca làm việc");
                    string shiftType = Console.ReadLine();
                    staffmanager.AddStaff(new Nurse(staffID, fullName, department, ward, shiftType));
                }
                else if (a == 3)
                {
                    Console.WriteLine("Nhập ID");
                    string staffID = Console.ReadLine();
                    Console.WriteLine("Nhập tên đầy đủ");
                    string fullName = Console.ReadLine();
                    Console.WriteLine("Nhập phòng ban");
                    string department = Console.ReadLine();
                    Console.WriteLine("Nhập chi nhánh");
                    string pharmacyBranch = Console.ReadLine();
                    Console.WriteLine("Nhập bằng cấp");
                    string certificateLevel = Console.ReadLine();
                    staffmanager.AddStaff(new Pharmacist(staffID, fullName, department, pharmacyBranch, certificateLevel));
                }
                break;
            case 4:
                Console.WriteLine("Hãy nhập ID cần tìm");
                string IDcantim = Console.ReadLine();
                Console.WriteLine(staffmanager.FindStaff(IDcantim).FullName); 
                break;
            case 5:
                Console.WriteLine("Nhập ID cần checkin");
                string ID = Console.ReadLine();
                staffmanager.FindStaff(ID).CheckIn();
                break;
            case 6:
                Console.WriteLine("Nhập ID cần checkout");
                string IDcheckout = Console.ReadLine();
                staffmanager.FindStaff(IDcheckout).CheckOut();
                break;
            case 7: 
                staffmanager.CheckInAll();
                break;
            case 8:
                staffmanager.CheckOutAll();
                break;
            case 9:
                Console.WriteLine("Tiếp nhận (1) hay xuất viện (2)");
                int luachon =  Convert.ToInt32(Console.ReadLine());
                if (luachon == 1)
                {
                    Console.WriteLine("Hãy nhập ID bác sĩ");
                    string IDbacsi = Console.ReadLine();

                    if (staffmanager.FindStaff(IDbacsi) is Doctor doctor)
                    {
                        doctor.AcceptPatient();
                    }
                    else
                    {
                        Console.WriteLine("Đây không phải bác sĩ");   
                    }
                }
                else if (luachon==2)
                {
                    Console.WriteLine("Hãy nhập ID bác sĩ");
                    string IDbacsi = Console.ReadLine();

                    if (staffmanager.FindStaff(IDbacsi) is Doctor doctor)
                    {
                        doctor.DischargePatient();
                    }
                    else
                    {
                        Console.WriteLine("Đây không phải bác sĩ");   
                    }
                }
                break;
            case 10:
                Console.WriteLine("Nhập ID y tá cần đổi ca trực");
                string doica =  Console.ReadLine();
                Console.WriteLine("Cần đổi sang ca nào");
                string camoi =  Console.ReadLine();
                if (staffmanager.FindStaff(doica) is Nurse nurse)
                {
                    nurse.ChangeShift(camoi);
                }
                else
                {
                    Console.WriteLine("Đây không phải y tá");   
                }
                break;
            case 11:
                Console.WriteLine("Hãy nhập ID dược sĩ");
                string IDduocsi = Console.ReadLine();
                if (staffmanager.FindStaff(IDduocsi) is Pharmacist pharmacist)
                {
                    pharmacist.ProcessPrescription();
                }
                else
                {
                    Console.WriteLine("Đây không phải dược sĩ");   
                }
                break;
        }
    }

