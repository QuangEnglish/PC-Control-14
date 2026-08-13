namespace ConsoleApp4;

public class Nurse : Staff
{
    private string _ward;
    private string _shiftType;
    private double _totalHoursWorked;

    public string Ward { get; set; }

    public double TotalHoursWorked
    {
        get { return _totalHoursWorked; }
        set {
            if (value < 0 || value > 300)
            {
                throw new ArgumentOutOfRangeException();
            }
            _totalHoursWorked = value;
        }
    }
    public string ShiftType { get; set; }

    public Nurse(string staffId, string fullName, string department, string ward, string shiftType) : base(staffId, fullName, department)
    {
        Ward = ward;
        ShiftType = shiftType;
        _totalHoursWorked = 0;
    }

    public override string GetRole()
    {
        if (IsOnDuty == true)
        {
         return $"{StaffId}: Điều dưỡng {FullName}: Ca {ShiftType} - Khu {Ward} (Đang trực)";
        }
        else
        {
         return $"{StaffId}: Điều dưỡng {FullName}: Ca {ShiftType} - Khu {Ward} (Nghỉ)";
        }
    }

    public override string GetInfo()
    {
        return $"Nurse" + base.GetInfo() + $"Khu vực: {Ward} | Ca trực: {ShiftType}\nGiờ làm tháng này: {TotalHoursWorked}\nNgày vào làm: {HireDate}";
    }

    public override bool CheckIn()
    {
        Console.WriteLine(ShiftType);
        return base.CheckIn();
    }
    
    public override bool CheckOut()
    {
        TotalHoursWorked = TotalHoursWorked + 8;
        return base.CheckOut();
    }

    public void ChangeShift(string newShift)
    {
        if (newShift != "Sáng" && newShift != "Chiều" && newShift != "Đêm")
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}