using ConsoleApp2.Interface;

namespace ConsoleApp2.Abstract;

public abstract class Staff:IWorkable
{
    #region Field & Properties
    private readonly string _staffId;
    private string _fullName;
    private string _department;
    private bool _isOnDuty;
    private DateTime _hireDate;
    public string StaffId
    {
        get => _staffId;
    }

    public string FullName
    {
        get => _fullName;
        set => _fullName = value ?? throw new ArgumentNullException("Full Name không được để trống");
    }

    public string Department
    {
        get => _department;
        set => _department = value ?? throw new ArgumentNullException(nameof(value));
    }

    public bool IsOnDuty
    {
        get => _isOnDuty;
    }

    public DateTime HireDate
    {
        get => _hireDate;
        set => _hireDate = value;
    }
    #endregion

    #region  Contructor

    public Staff(string staffId, string fullName, string department)
    
    {
        _staffId = staffId;
        FullName = fullName;
        Department = department;
        _hireDate = DateTime.Now;
        _isOnDuty = false;
    }

    #endregion

    #region Method

    public abstract string GetRole();

    public virtual string GetInfo()
    {
        return $"{_staffId}\n\t"
               + "Họ và tên: " + FullName + "\n\t"
               + "Khoa: " + Department + "\n\t";
        //Thông tin cơ bản của nhân viên
        
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

    #endregion


}