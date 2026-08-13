using ConsoleApp2.Abstract;

namespace ConsoleApp2.Class_;

public class Nurse:Staff
{
    

    #region Field & Property
    
    private string _ward;
    private string _shiftType;
    private double _totalHoursWorked;
    public string Ward
    {
        get => _ward;
        set => _ward = value;
    }

    public string ShiftType
    {
        get => _shiftType;
        set => _shiftType = value;
    }

    public double TotalHoursWorked
    {
        get => _totalHoursWorked;
        set
        {
            if (value >= 0 && value <= 300.0) _totalHoursWorked = value;
            else throw new Exception("TotalHoursWorked không được âm và không vượt quá 300 giờ/tháng");

        }
    }

    #endregion

    #region Constructor

    public Nurse(string staffId, string fullName, string department, string ward, string shiftType)
        : base(staffId, fullName, department)
    {
        Ward = ward;
        ShiftType = shiftType;
        _totalHoursWorked = 0;
    }


    #endregion

    #region Method

    public override string GetRole()
    {
        //Điều dưỡng [name]: Ca shiftType - Khu ward (Đang trực/Nghỉ)
        string sOnDuty = IsOnDuty ? "Đang trực" : "Nghỉ";
        return $"Điều dưỡng [name]: Ca {_shiftType} - Khu {_ward} ({sOnDuty})";
    }

    public override string GetInfo()
    {
        return base.GetInfo()
               + $"Khu vực: {_ward} | Ca trực: {_shiftType}\n\t"
               + $"Giờ làm tháng này: {_totalHoursWorked}\n\t"
               + $"Ngày vào làm: {HireDate}";

    }

    public override bool CheckIn()
    {
        Console.WriteLine(_shiftType);
        return base.CheckIn();  
    }

    public override bool CheckOut()
    {
        _totalHoursWorked += 8;
        return base.CheckOut();
    }

    public void ChangeShift(string newShift)
    {
        _shiftType = newShift;
        
    }
    #endregion

}