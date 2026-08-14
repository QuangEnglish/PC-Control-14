using Project_OOP_BaiTap_T4.Interfaces;

namespace Project_OOP_BaiTap_T4.Models;

// Class cha (abstract) cho toàn bộ nhân viên trong bệnh viện.
// - ABSTRACTION: "abstract class" nghĩa là không thể new Staff() trực tiếp,
//   bắt buộc phải tạo qua class con (Doctor, Nurse, Pharmacist).
// - Implement IWorkable => Staff phải viết đủ CheckIn/CheckOut/TakeLeave.
public abstract class Staff : IWorkable
{
    // ----- ENCAPSULATION: fields luôn private, chỉ truy cập qua property -----
    private string _staffId;
    private string _fullName = string.Empty;
    private string _department;
    private bool _isOnDuty;
    private DateTime _hireDate;

    // Chỉ có "get" => bên ngoài đọc được nhưng không gán lại được (read-only property)
    public string StaffId
    {
        get { return _staffId; }
    }

    // Có validation: không cho phép tên rỗng
    public string FullName
    {
        get { return _fullName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Họ tên không được để trống!");
            _fullName = value;
        }
    }

    public string Department
    {
        get { return _department; }
        set { _department = value; }
    }

    // Read-only ra bên ngoài: chỉ Staff (và class con) mới đổi được trạng thái trực,
    // và chỉ thông qua CheckIn()/CheckOut() để đảm bảo logic luôn nhất quán.
    public bool IsOnDuty
    {
        get { return _isOnDuty; }
    }

    public DateTime HireDate
    {
        get { return _hireDate; }
    }

    // Constructor nhận 3 tham số bắt buộc, các field còn lại tự khởi tạo mặc định
    protected Staff(string staffId, string fullName, string department)
    {
        _staffId = staffId;
        FullName = fullName; // gán qua property để chạy luôn validation
        _department = department;
        _hireDate = DateTime.Now;
        _isOnDuty = false;
    }

    // ----- ABSTRACTION: mỗi loại nhân viên có vai trò khác nhau -----
    // Không có "body", bắt buộc class con phải override.
    public abstract string GetRole();

    // ----- POLYMORPHISM: virtual method có thể bị override, nhưng có sẵn hành vi mặc định -----
    public virtual string GetInfo()
    {
        return $"Họ tên: {FullName}\n    Khoa: {Department}";
    }

    // ----- Implement IWorkable -----
    public virtual bool CheckIn()
    {
        _isOnDuty = true;
        return true;
    }

    public virtual bool CheckOut()
    {
        _isOnDuty = false;
        return true;
    }

    public void TakeLeave()
    {
        CheckOut();
        Console.WriteLine("Nhân viên đã xin nghỉ phép");
    }
}
