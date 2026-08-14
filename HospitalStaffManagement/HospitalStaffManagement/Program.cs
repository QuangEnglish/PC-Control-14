using System;
using System.Text;
using System.Collections.Generic;
using HospitalStaffManagement.Models;
using HospitalStaffManagement.Services;

namespace HospitalStaffManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            StaffManager manager = new StaffManager();

            Doctor doctor = new Doctor("BS001", "Nguyễn Văn An", "Tim mạch", "Tim mạch", 20, "BS-2024-001");
            Nurse nurse = new Nurse("DD001", "Trần Thị Bình", "Nội tổng hợp", "ICU", "Sáng");
            Pharmacist pharmacist = new Pharmacist("DS001", "Lê Văn Cường", "Dược", "Nhà thuốc chính", "Dược sĩ Đại học");

            manager.AddStaff(doctor);
            manager.AddStaff(nurse);
            manager.AddStaff(pharmacist);

            while (true)
            {
                Console.WriteLine("\n========================================");
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

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("\n=== DANH SÁCH NHÂN VIÊN ===");
                    List<Staff> list = manager.GetAllStaff();
                    for (int i = 0; i < list.Count; i++)
                    {
                        string typeName = "STAFF";
                        if (list[i] is Doctor)
                        {
                            typeName = "DOCTOR";
                        }
                        else if (list[i] is Nurse)
                        {
                            typeName = "NURSE";
                        }
                        else if (list[i] is Pharmacist)
                        {
                            typeName = "PHARMACIST";
                        }

                        Console.WriteLine($"\n[{i + 1}] {typeName} - {list[i].StaffId}");
                        Console.WriteLine(list[i].GetInfo());
                    }
                    Console.WriteLine($"\nTổng: {list.Count} nhân viên");
                }
                else if (choice == "2")
                {
                    Console.WriteLine("");
                    manager.PrintAllRoles();
                }
                else if (choice == "3")
                {
                    Console.Write("Loại nhân viên (1-Doctor, 2-Nurse, 3-Pharmacist): ");
                    string type = Console.ReadLine();
                    Console.Write("Mã NV: ");
                    string id = Console.ReadLine();
                    Console.Write("Họ tên: ");
                    string name = Console.ReadLine();
                    Console.Write("Khoa/Phòng: ");
                    string dept = Console.ReadLine();

                    if (type == "1")
                    {
                        Console.Write("Chuyên khoa: ");
                        string spec = Console.ReadLine();
                        Console.Write("Số bệnh nhân tối đa: ");
                        int max = int.Parse(Console.ReadLine());
                        Console.Write("Giấy phép hành nghề: ");
                        string license = Console.ReadLine();

                        manager.AddStaff(new Doctor(id, name, dept, spec, max, license));
                        Console.WriteLine("Đã thêm Bác sĩ thành công!");
                    }
                    else if (type == "2")
                    {
                        Console.Write("Khu vực: ");
                        string ward = Console.ReadLine();
                        Console.Write("Ca trực (Sáng/Chiều/Đêm): ");
                        string shift = Console.ReadLine();

                        manager.AddStaff(new Nurse(id, name, dept, ward, shift));
                        Console.WriteLine("Đã thêm Điều dưỡng thành công!");
                    }
                    else if (type == "3")
                    {
                        Console.Write("Chi nhánh: ");
                        string branch = Console.ReadLine();
                        Console.Write("Bằng cấp: ");
                        string cert = Console.ReadLine();

                        manager.AddStaff(new Pharmacist(id, name, dept, branch, cert));
                        Console.WriteLine("Đã thêm Dược sĩ thành công!");
                    }
                }
                else if (choice == "4")
                {
                    Console.Write("Nhập ID cần tìm: ");
                    string findId = Console.ReadLine();
                    Staff s = manager.FindStaff(findId);

                    if (s != null)
                    {
                        Console.WriteLine(s.GetInfo());
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy nhân viên này!");
                    }
                }
                else if (choice == "5")
                {
                    Console.Write("Nhập ID nhân viên vào ca: ");
                    string id = Console.ReadLine();
                    Staff s = manager.FindStaff(id);

                    if (s != null)
                    {
                        s.CheckIn();
                        Console.WriteLine("Đã ghi nhận vào ca.");
                    }
                }
                else if (choice == "6")
                {
                    Console.Write("Nhập ID nhân viên ra ca: ");
                    string id = Console.ReadLine();
                    Staff s = manager.FindStaff(id);

                    if (s != null)
                    {
                        s.CheckOut();
                        Console.WriteLine("Đã ghi nhận ra ca.");
                    }
                }
                else if (choice == "7")
                {
                    manager.CheckInAll();
                    Console.WriteLine("Tất cả nhân viên đã vào ca.");
                }
                else if (choice == "8")
                {
                    manager.CheckOutAll();
                    Console.WriteLine("Tất cả nhân viên đã ra ca.");
                }
                else if (choice == "9")
                {
                    Console.Write("Nhập ID Bác sĩ: ");
                    string id = Console.ReadLine();
                    Staff s = manager.FindStaff(id);

                    if (s is Doctor)
                    {
                        Doctor d = (Doctor)s;
                        Console.Write("Chọn (1-Tiếp nhận bệnh nhân | 2-Xuất viện): ");
                        string opt = Console.ReadLine();

                        if (opt == "1")
                        {
                            if (d.AcceptPatient())
                            {
                                Console.WriteLine($">> Bác sĩ {d.FullName} đã tiếp nhận bệnh nhân!");
                                Console.WriteLine($">> Số bệnh nhân hiện tại: {d.PatientCount}/{d.MaxPatients}");
                            }
                            else
                            {
                                Console.WriteLine("Bác sĩ đã quá tải bệnh nhân!");
                            }
                        }
                        else if (opt == "2")
                        {
                            if (d.DischargePatient())
                            {
                                Console.WriteLine("Đã cho bệnh nhân xuất viện.");
                            }
                            else
                            {
                                Console.WriteLine("Hiện tại không có bệnh nhân nào để xuất viện.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID này không phải là Bác sĩ!");
                    }
                }
                else if (choice == "10")
                {
                    Console.Write("Nhập ID Điều dưỡng: ");
                    string id = Console.ReadLine();
                    Staff s = manager.FindStaff(id);

                    if (s is Nurse)
                    {
                        Nurse n = (Nurse)s;
                        Console.Write("Nhập ca trực mới (Sáng/Chiều/Đêm): ");
                        string newShift = Console.ReadLine();
                        n.ChangeShift(newShift);
                    }
                    else
                    {
                        Console.WriteLine("ID này không phải là Điều dưỡng!");
                    }
                }
                else if (choice == "11")
                {
                    Console.Write("Nhập ID Dược sĩ: ");
                    string id = Console.ReadLine();
                    Staff s = manager.FindStaff(id);

                    if (s is Pharmacist)
                    {
                        Pharmacist p = (Pharmacist)s;
                        Console.WriteLine(">> Đang xử lý đơn thuốc...");
                        p.ProcessPrescription();
                        Console.WriteLine($">> Tổng đơn hôm nay: {p.PrescriptionCount}");
                    }
                    else
                    {
                        Console.WriteLine("ID này không phải là Dược sĩ!");
                    }
                }
                else if (choice == "0")
                {
                    break;
                }
            }
        }
    }
}