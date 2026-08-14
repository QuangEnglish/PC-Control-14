using Project_OOP_BaiTap_T4.Models;

namespace Project_OOP_BaiTap_T4.Services;

// Class quản lý danh sách toàn bộ nhân viên bệnh viện
public class StaffManager
{
    private List<Staff> _staffList = new List<Staff>();

    public void AddStaff(Staff staff)
    {
        _staffList.Add(staff);
    }

    // Xóa nhân viên theo ID, trả về true nếu xóa thành công
    public bool RemoveStaff(string staffId)
    {
        Staff? staff = FindStaff(staffId);
        if (staff == null)
            return false;
        return _staffList.Remove(staff);
    }

    // Tìm theo ID, trả về null nếu không thấy
    public Staff? FindStaff(string staffId)
    {
        return _staffList.FirstOrDefault(s => s.StaffId == staffId);
    }

    public List<Staff> GetAllStaff()
    {
        return _staffList;
    }

    // GENERIC method: T phải là Staff hoặc lớp con của Staff (Doctor, Nurse, Pharmacist)
    // "where T : Staff" ràng buộc kiểu, cho phép dùng "is T" để lọc theo loại cụ thể
    public List<T> GetStaffByType<T>() where T : Staff
    {
        return _staffList.OfType<T>().ToList();
    }

    public void CheckInAll()
    {
        foreach (Staff staff in _staffList)
        {
            staff.CheckIn();
        }
    }

    public void CheckOutAll()
    {
        foreach (Staff staff in _staffList)
        {
            staff.CheckOut();
        }
    }

    // POLYMORPHISM: cùng một lời gọi staff.GetRole(), nhưng Doctor/Nurse/Pharmacist
    // mỗi loại tự chạy code override riêng của mình -> in ra nội dung khác nhau.
    public void PrintAllRoles()
    {
        foreach (Staff staff in _staffList)
        {
            Console.WriteLine($"{staff.StaffId}: {staff.GetRole()}");
        }
    }
}
