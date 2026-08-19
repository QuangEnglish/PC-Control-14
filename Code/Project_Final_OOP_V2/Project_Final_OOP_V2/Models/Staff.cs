using Project_Final_OOP_V2.Interfaces;

namespace Project_Final_OOP_V2.Models;

// Abstract class cơ sở cho tất cả nhân viên, implement IWorkable
public abstract class Staff : IWorkable
{
    // === ENCAPSULATION: Tất cả fields đều private ===
    private string _staffId;
    private string _fullName;
    private string _department;
    private bool _isOnDuty;
    private DateTime _hireDate;

    // === PROPERTIES với validation ===

    // StaffId: chỉ cho phép đọc từ bên ngoài
    public string StaffId
    {
        get { return _staffId; }
    }

    // FullName: có validation - không được để trống
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

    // IsOnDuty: chỉ cho phép đọc từ bên ngoài
    public bool IsOnDuty
    {
        get { return _isOnDuty; }
    }

    public DateTime HireDate
    {
        get { return _hireDate; }
        set { _hireDate = value; }
    }

    // === CONSTRUCTOR ===
    public Staff(string staffId, string fullName, string department)
    {
        _staffId = staffId;
        FullName = fullName; // Dùng property để validate
        _department = department;
        _hireDate = DateTime.Now;
        _isOnDuty = false;
    }

    // === ABSTRACTION: abstract method - mỗi loại nhân viên override khác nhau ===
    public abstract string GetRole();

    // Virtual method - có thể override ở class con
    public virtual string GetInfo()
    {
        return $"Mã NV: {_staffId}\n" +
               $"    Họ tên: {_fullName}\n" +
               $"    Khoa: {_department}";
    }

    // === IMPLEMENT INTERFACE IWorkable ===

    // Vào ca
    public virtual bool CheckIn()
    {
        _isOnDuty = true;
        Console.WriteLine($">> {_fullName} đã vào ca!");
        return true;
    }

    // Ra ca
    public virtual bool CheckOut()
    {
        _isOnDuty = false;
        Console.WriteLine($">> {_fullName} đã ra ca!");
        return true;
    }

    // Xin nghỉ phép
    public void TakeLeave()
    {
        CheckOut();
        Console.WriteLine($">> Nhân viên {_fullName} đã xin nghỉ phép.");
    }
}
