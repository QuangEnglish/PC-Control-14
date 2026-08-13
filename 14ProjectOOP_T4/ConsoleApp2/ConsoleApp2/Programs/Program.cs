using System.Text;
using ConsoleApp2.Abstract;
using ConsoleApp2.Class_;
using ConsoleApp2.Service;

namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        StaffManager staffManager = new StaffManager();
        Staff doctor = new Doctor(
            "BS001",
            "Nguyễn Văn An",
            "Tim mạch",
            "Tim mạch",
            20,
            "BS-2024-001");
        Staff nurse = new Nurse(
            "DD001",
            "Trần Thị Bình",
            "Nội tổng hợp",
            "ICU",
            "Sáng");

        Staff pharmacist = new Pharmacist(
            "DS001",
            "Lê Văn Cường",
            "Dược",
            "Nhà thuốc chính",
            "Dược sĩ Đại học");
        staffManager.AddStaff(doctor);
        staffManager.AddStaff(nurse);
        staffManager.AddStaff(pharmacist);
        
        while (true)
        {
            Console.Write("Chọn chức năng: ");
            int chucNang = Convert.ToInt32(Console.ReadLine());
            switch (chucNang)
            {
                case 1: //1. Hiển thị tất cả nhân viên
                    HienThiTatCaNhanVien();
                    break;
                case 2: //2. Hiển thị vai trò nhân viên
                    HienThiVaiTroNhanVien();
                    break;
                case 3: //3. Thêm nhân viên mới
                    ThemNhanVienMoi();
                    break;
                case 4: //4. Tìm kiếm nhân viên theo ID
                    TimKiemNhanVienTheoID();
                    break;
                case 7: //7. Tất cả vào ca
                    TatCaVaoCa();
                    break;
                case 8: //8. Tất cả ra ca
                    TatCaRaCa();
                    break;
                
                case 0:
                    return;
                
            }
        }
        void HienThiTatCaNhanVien()
        {
            staffManager.GetAllStaff();
        }

        void HienThiVaiTroNhanVien()
        {
            foreach (var staff in staffManager.StaffList)
            {
                Console.WriteLine(staff.GetRole());
            }
        }

        void ThemNhanVienMoi()
        {
            Console.WriteLine($"Chọn loại nhân viên:\n" +
                              $"1. Doctor\n" +
                              $"2. Nurse\n" +
                              $"3. Pharmacist\n");
            int chucNang = Convert.ToInt32(Console.ReadLine());
            string staffId, fullName, department, specialty,ward,shiftType, pharmacyBranch, certificateLevel;
            int maxPatients;
            string licenseNumber;
            switch (chucNang)
            {

                case 1: //Doctor

                    Console.Write("Doctor ID: ");
                    staffId = Console.ReadLine();
                    Console.Write("Doctor fullname: ");
                    fullName = Console.ReadLine();
                    Console.Write("Doctor Department: ");
                    department = Console.ReadLine();
                    Console.Write("Doctor Specialty: ");
                    specialty = Console.ReadLine();
                    Console.Write("Doctor Max Patients: ");
                    maxPatients = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Doctor License Number: ");
                    licenseNumber = Console.ReadLine();
                    Staff doctor = new Doctor(staffId, fullName, department, specialty, maxPatients, licenseNumber);
                    staffManager.AddStaff(doctor);
                    break;
                case 2: //Nurse
                    Console.Write("Nurse ID: ");
                    staffId = Console.ReadLine();
                    Console.Write("Nurse fullname: ");
                    fullName = Console.ReadLine();
                    Console.Write("Nurse Department: ");
                    department = Console.ReadLine();
                    Console.Write("Nurse Ward: ");
                    ward = Console.ReadLine();
                    Console.WriteLine("Nurse ShiftType: ");
                    shiftType = Console.ReadLine();
                    Staff nurse = new Nurse(staffId, fullName, department, ward, shiftType);
                    staffManager.AddStaff(nurse);
                    break;
                case 3: //Pharmacist
                    Console.Write("Pharmacist ID: ");
                    staffId = Console.ReadLine();
                    Console.Write("Pharmacist fullname: ");
                    fullName = Console.ReadLine();
                    Console.Write("Pharmacist Department: ");
                    department = Console.ReadLine();
                    Console.Write("Pharmacist Branch: ");
                    pharmacyBranch = Console.ReadLine();
                    Console.WriteLine("Pharmacist Certificate Level: ");
                    certificateLevel = Console.ReadLine();
                    Staff pharmacist = new Pharmacist(staffId, fullName, department, pharmacyBranch, certificateLevel);
                    staffManager.AddStaff(pharmacist);
                    break;
            }

           
        }
        void TimKiemNhanVienTheoID()
        {
            Console.Write("Nhập ID nhân viên cần tìm kiếm");
            string IDFind = Console.ReadLine();
            Staff staffFounded = staffManager.FindStaff(IDFind);
            if (staffFounded != null)
            {
                staffFounded.GetInfo();
            }
            else Console.WriteLine("Không tìm thấy ID thỏa mãn");
        }
        void TatCaVaoCa()
        {
            staffManager.CheckInAll();
        }

        void TatCaRaCa()
        {
            staffManager.CheckOutAll();
        }
    }
}