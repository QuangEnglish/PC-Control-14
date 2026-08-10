namespace Lesson13_2_Hospital_Staff_Management_System;

public abstract class Staff : IWorkable
// Đây là class cơ sở cho tất cả nhân viên, **implement interface `IWorkable`**.
{
    // Filed
    private string _staffId;      // : string - Mã nhân viên
    private string _fullName;     // : string - Họ tên nhân viên
    private string _department;   // : string - Khoa/Phòng ban
    private bool _isOnDuty;       // : bool - Trạng thái đang trực hay không
    private DateTime _hireDate;   // : DateTime - Ngày vào làm

    
    // Properties
    public string StaffId   //Chi cho phep doc tu ben ngoai
    {
        get{ return _staffId; }
        
    }
    public string FullName
    { get{ return _fullName; } // Khong duoc de trong 
        set
        {
            if (string.IsNullOrWhiteSpace(value)) // phuong thuc kiem tra chuoi string
            {
                throw new ArgumentException("FullName Không được để trống");
            }
        }
    }
    public string Department { get; set; }
    
    public bool IsOnDuty  //Chi cho phep doc tu ben ngoai
    {
        get { return _isOnDuty; }
    }

    public DateTime HireDate
    {
        get { return _hireDate; }
    }
    
    // Constructor

    public Staff(
        string staffId,
        string fullName,
        string department)
    {
        _staffId =  staffId;
        FullName = fullName;
        Department = department;
        
        _isOnDuty = false;
        _hireDate = DateTime.Now;
    }
    
    // Methods
    public abstract string GetRole();

    public virtual string GetInfo()
    {
        return "Mã nhân viên: " + StaffId
                                +", Họ tên nhân viên: " + FullName
                                +", Khoa/Phòng ban: " + Department
                                + ", Trạng thái đang trực hay không: " + IsOnDuty
                                + ", Ngày vào làm: " + HireDate;
    }
    
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