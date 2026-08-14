namespace BTVN_10._82026___Hospital_Staff_Management_System.Service;

public class StaffManager
{
    //field
    // Danh sách nhân viên. Nhờ Staff là abstract class nên List<Staff> có thể chứa
    // đồng thời Doctor, Nurse, Pharmacist (đây chính là biểu hiện của tính ĐA HÌNH).
    private List<Staff> _staffList = new List<Staff>();
    
    //Properties
    // Thêm 1 nhân viên (bất kỳ loại nào kế thừa từ Staff) vào danh sách.
    public void AddStaff(Staff staff)
    {
        _staffList.Add(staff);
    }

    // Xóa nhân viên theo mã ID. Trả về true nếu xóa thành công, false nếu không tìm thấy.
    public bool RemoveStaff(string staffId)
    {
        Staff? staff = FindStaff(staffId);
        if (staff == null)
            return false;

        _staffList.Remove(staff);
        return true;
    }
    
    // Tìm nhân viên theo mã ID. Trả về null nếu không tìm thấy.
    public Staff? FindStaff(string staffId)
    {
        foreach (Staff s in _staffList)
        {
            if (s.StaffId == staffId)
                return s;
        }
        return null;
    }
    
    // Trả về toàn bộ danh sách nhân viên.
    public List<Staff> GetAllStaff()
    {
        return _staffList;
    }
    
    // GENERIC method: lọc ra danh sách nhân viên theo đúng 1 loại cụ thể, ví dụ GetStaffByType<Doctor>()
    // sẽ chỉ trả về các bác sĩ. "where T : Staff" ràng buộc T phải là Staff hoặc lớp con của Staff.
    public List<T> GetStaffByType<T>() where T : Staff
    {
        List<T> result = new List<T>();
        foreach (Staff s in _staffList)
        {
            // "is" + pattern matching: kiểm tra kiểu thực sự của đối tượng lúc runtime
            if (s is T typedStaff)
                result.Add(typedStaff);
        }
        return result;
    }

    // Cho toàn bộ nhân viên vào ca.
    public void CheckInAll()
    {
        foreach (Staff s in _staffList)
            s.CheckIn();
    }

    // Cho toàn bộ nhân viên ra ca.
    public void CheckOutAll()
    {
        foreach (Staff s in _staffList)
            s.CheckOut();
    }

    // In vai trò của tất cả nhân viên.
    // Đây là minh chứng rõ nhất cho tính ĐA HÌNH (Polymorphism):
    // cùng gọi s.GetRole() nhưng Doctor/Nurse/Pharmacist sẽ cho ra kết quả khác nhau
    // tùy theo kiểu THỰC SỰ của đối tượng lúc runtime, dù biến s có kiểu khai báo là Staff.
    public void PrintAllRoles()
    {
        foreach (Staff s in _staffList)
        {
            Console.WriteLine($"{s.StaffId}: {s.GetRole()}");
        }
    }
}