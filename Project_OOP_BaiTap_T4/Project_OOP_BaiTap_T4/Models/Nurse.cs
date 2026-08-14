namespace Project_OOP_BaiTap_T4.Models;

// Điều dưỡng - kế thừa từ Staff
public class Nurse : Staff
{
    private string _ward;
    private string _shiftType;
    private double _totalHoursWorked;

    public string Ward
    {
        get { return _ward; }
        set { _ward = value; }
    }

    public string ShiftType
    {
        get { return _shiftType; }
        set { _shiftType = value; }
    }

    // Validation: không âm và không vượt quá 300 giờ/tháng
    public double TotalHoursWorked
    {
        get { return _totalHoursWorked; }
        set
        {
            if (value < 0 || value > 300)
                throw new ArgumentException("Tổng giờ làm không hợp lệ (0 - 300 giờ/tháng)!");
            _totalHoursWorked = value;
        }
    }

    public Nurse(string staffId, string fullName, string department, string ward, string shiftType)
        : base(staffId, fullName, department)
    {
        _ward = ward;
        _shiftType = shiftType;
        _totalHoursWorked = 0;
    }

    public override string GetRole()
    {
        string trangThai = IsOnDuty ? "Đang trực" : "Nghỉ";
        return $"Điều dưỡng {FullName}: Ca {ShiftType} - Khu {Ward} ({trangThai})";
    }

    public override string GetInfo()
    {
        return base.GetInfo() +
               $"\n    Khu vực: {Ward} | Ca trực: {ShiftType}" +
               $"\n    Giờ làm tháng này: {TotalHoursWorked} giờ" +
               $"\n    Ngày vào làm: {HireDate:dd/MM/yyyy}";
    }

    // Override CheckIn: gọi base.CheckIn() trước rồi làm thêm việc riêng (in ca trực)
    public override bool CheckIn()
    {
        bool result = base.CheckIn();
        Console.WriteLine($">> Điều dưỡng {FullName} vào ca {ShiftType} tại khu {Ward}");
        return result;
    }

    // Override CheckOut: gọi base.CheckOut() rồi cộng dồn 8 giờ làm việc
    public override bool CheckOut()
    {
        bool result = base.CheckOut();
        TotalHoursWorked += 8;
        return result;
    }

    // Đổi ca trực, chỉ chấp nhận 3 giá trị hợp lệ
    public bool ChangeShift(string newShift)
    {
        if (newShift != "Sáng" && newShift != "Chiều" && newShift != "Đêm")
        {
            Console.WriteLine("Ca trực không hợp lệ! Chỉ nhận: Sáng, Chiều, Đêm");
            return false;
        }
        ShiftType = newShift;
        Console.WriteLine($">> Đã đổi ca trực sang: {newShift}");
        return true;
    }
}
