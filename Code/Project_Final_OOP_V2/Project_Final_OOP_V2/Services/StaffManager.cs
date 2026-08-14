using Project_Final_OOP_V2.Models;

namespace Project_Final_OOP_V2.Services;

// Class quản lý danh sách tất cả nhân viên
public class StaffManager
{
    // Danh sách nhân viên
    private List<Staff> _staffList;

    public StaffManager()
    {
        _staffList = new List<Staff>();
    }

    // Thêm nhân viên vào danh sách
    public void AddStaff(Staff staff)
    {
        _staffList.Add(staff);
        Console.WriteLine($">> Đã thêm nhân viên: {staff.FullName} ({staff.StaffId})");
    }

    // Xóa nhân viên theo ID
    public bool RemoveStaff(string staffId)
    {
        Staff? staff = FindStaff(staffId);
        if (staff == null)
        {
            Console.WriteLine($">> Không tìm thấy nhân viên có ID: {staffId}");
            return false;
        }
        _staffList.Remove(staff);
        Console.WriteLine($">> Đã xóa nhân viên: {staff.FullName} ({staffId})");
        return true;
    }

    // Tìm nhân viên theo ID
    public Staff? FindStaff(string staffId)
    {
        foreach (var staff in _staffList)
        {
            if (staff.StaffId == staffId)
                return staff;
        }
        return null;
    }

    // Trả về danh sách tất cả nhân viên
    public List<Staff> GetAllStaff()
    {
        return _staffList;
    }

    // Trả về danh sách nhân viên theo loại (dùng Generic)
    public List<T> GetStaffByType<T>() where T : Staff
    {
        List<T> result = new List<T>();
        foreach (var staff in _staffList)
        {
            if (staff is T typedStaff)
                result.Add(typedStaff);
        }
        return result;
    }

    // Tất cả nhân viên vào ca
    public void CheckInAll()
    {
        Console.WriteLine("=== TẤT CẢ NHÂN VIÊN VÀO CA ===\n");
        foreach (var staff in _staffList)
        {
            staff.CheckIn();
        }
    }

    // Tất cả nhân viên ra ca
    public void CheckOutAll()
    {
        Console.WriteLine("=== TẤT CẢ NHÂN VIÊN RA CA ===\n");
        foreach (var staff in _staffList)
        {
            staff.CheckOut();
        }
    }

    // In vai trò tất cả nhân viên (POLYMORPHISM - gọi GetRole())
    public void PrintAllRoles()
    {
        Console.WriteLine("=== VAI TRÒ NHÂN VIÊN ===\n");
        foreach (var staff in _staffList)
        {
            // Đa hình: cùng gọi GetRole() nhưng mỗi loại nhân viên hiển thị khác nhau
            Console.WriteLine($"{staff.StaffId}: {staff.GetRole()}");
        }
    }
}
