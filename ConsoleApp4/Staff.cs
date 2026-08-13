namespace ConsoleApp4;

public abstract class Staff : IWorkable
{
    private string _staffId;
    private string _fullName;
    private string _department;
    private bool _isOnDuty;
    private DateTime _hireDate;

    public string StaffId { get; private set; }

    public string FullName
    {
        get { return _fullName;}
        set {
            if (value == "")
            {
                throw new ArgumentException("Staff Full Name cannot be empty");
            }
            _fullName = value;
        }
    }
    public string Department { get; set; }
    public bool IsOnDuty { get; private set; }
    public DateTime HireDate { get; set; }

    public Staff(string staffId, string fullName, string department)
    {
        StaffId = staffId;
        FullName = fullName;
        Department = department;
        IsOnDuty = false;
        HireDate = DateTime.Now;
    }
    public abstract string GetRole();

    public virtual string GetInfo()
    {
        return $" - {StaffId}\nHọ tên: {FullName}\nKhoa: {Department}\n";
    }
    public virtual bool CheckIn()
    {
        IsOnDuty = true;
        return true;
    }
    public virtual bool CheckOut()
    {
        IsOnDuty = false;
        return true;
    }
    public void TakeLeave()
    {
        CheckOut();
        Console.WriteLine("Nhân viên đã xin nghỉ phép");
    }
}