using System.Globalization;
using ConsoleApp2.Abstract;

namespace ConsoleApp2.Service;

public class StaffManager
{
    #region Fields & Property

    private List<Staff> _staffList;

    public List<Staff> StaffList
    {
        get => _staffList;
        set => _staffList = value;
    }

    #endregion

    #region  Constructor

    public StaffManager()
    {
        StaffList = new List<Staff>();
    }

    #endregion
    #region Method
    
    /*`AddStaff(Staff staff)`: Thêm nhân viên vào danh sách
- `RemoveStaff(string staffId)`: Xóa nhân viên theo ID
- `FindStaff(string staffId)`: Tìm nhân viên theo ID, trả về `Staff` hoặc `null`
- `GetAllStaff()`: Trả về danh sách tất cả nhân viên
- `GetStaffByType<T>()`: Trả về danh sách nhân viên theo loại (dùng Generic)
- `CheckInAll()`: Tất cả nhân viên vào ca
- `CheckOutAll()`: Tất cả nhân viên ra ca
- `PrintAllRoles()`: In vai trò tất cả nhân viên (dùng **Polymorphism** - gọi GetRole())*/
    public void AddStaff(Staff staff)
    {
        StaffList.Add(staff);
    }

    public void RemoveStaff(string staffId)
    {
        Staff staffFounded = null;
        foreach (var staff in StaffList)
        {
            if (staff.StaffId == staffId)
            {
                staffFounded = staff;
                break;
            }
        }
        if (staffFounded != null) StaffList.Remove(staffFounded);
        else Console.WriteLine("Không tồn tại staffId tương ứng");
        
    }

    public Staff FindStaff(string staffId)
    {
        Staff staffFounded = null;
        foreach (var staff in StaffList)
        {
            if (staff.StaffId == staffId)
            {
                staffFounded = staff;
                break;
            }
        }

        return staffFounded;
    }

    public void GetAllStaff()
    {
        for (int i = 0; i < _staffList.Count; i++)
        {
            Console.WriteLine($"[{i}] {_staffList[i].GetType().Name} - " + _staffList[i].GetInfo());
        }
    }

    public void CheckInAll()
    {
        foreach (var staff in StaffList)
        {
            staff.CheckIn();
        }
    }
    public void CheckOutAll()
    {
        foreach (var staff in StaffList)
        {
            staff.CheckOut();
        }
    }

    public void PrintAllRoles()
    {
        foreach (var staff in StaffList)
        {
            staff.GetRole();
        }
    }
    #endregion
}