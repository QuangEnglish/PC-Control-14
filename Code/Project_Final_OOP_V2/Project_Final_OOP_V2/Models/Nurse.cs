namespace Project_Final_OOP_V2.Models;

// Class Nurse kế thừa từ Staff - đại diện cho y tá/điều dưỡng
public class Nurse : Staff
{
    // === ENCAPSULATION: private fields riêng của Nurse ===
    private string _ward;
    private string _shiftType;
    private double _totalHoursWorked;

    // === PROPERTIES ===
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

    // TotalHoursWorked: validation - không âm và không vượt quá 300 giờ/tháng
    public double TotalHoursWorked
    {
        get { return _totalHoursWorked; }
        set
        {
            if (value < 0 || value > 300)
                throw new ArgumentException("Số giờ làm không hợp lệ! (0 - 300 giờ/tháng)");
            _totalHoursWorked = value;
        }
    }

    // === CONSTRUCTOR: gọi base constructor của Staff ===
    public Nurse(string staffId, string fullName, string department,
                 string ward, string shiftType)
        : base(staffId, fullName, department)
    {
        _ward = ward;
        _shiftType = shiftType;
        _totalHoursWorked = 0;
    }

    // === POLYMORPHISM: Override GetRole() ===
    public override string GetRole()
    {
        string status = IsOnDuty ? "Đang trực" : "Nghỉ";
        return $"Điều dưỡng {FullName}: Ca {_shiftType} - Khu {_ward} ({status})";
    }

    // Override GetInfo(): gọi base.GetInfo() + thêm thông tin riêng
    public override string GetInfo()
    {
        return base.GetInfo() + "\n" +
               $"    Khu vực: {_ward} | Ca trực: {_shiftType}\n" +
               $"    Giờ làm tháng này: {_totalHoursWorked} giờ\n" +
               $"    Ngày vào làm: {HireDate:dd/MM/yyyy}";
    }

    // Override CheckIn(): gọi base.CheckIn() + in ra ca trực hiện tại
    public override bool CheckIn()
    {
        base.CheckIn();
        Console.WriteLine($">> Ca trực hiện tại: {_shiftType}");
        return true;
    }

    // Override CheckOut(): gọi base.CheckOut() + cộng 8 giờ vào TotalHoursWorked
    public override bool CheckOut()
    {
        base.CheckOut();
        if (_totalHoursWorked + 8 <= 300)
        {
            _totalHoursWorked += 8;
            Console.WriteLine($">> Đã cộng 8 giờ. Tổng giờ làm tháng này: {_totalHoursWorked} giờ");
        }
        else
        {
            Console.WriteLine(">> Cảnh báo: Đã đạt giới hạn giờ làm trong tháng!");
        }
        return true;
    }

    // Đổi ca trực, chỉ nhận "Sáng", "Chiều", "Đêm"
    public void ChangeShift(string newShift)
    {
        if (newShift != "Sáng" && newShift != "Chiều" && newShift != "Đêm")
        {
            Console.WriteLine(">> Lỗi: Ca trực chỉ được là 'Sáng', 'Chiều' hoặc 'Đêm'!");
            return;
        }
        string oldShift = _shiftType;
        _shiftType = newShift;
        Console.WriteLine($">> Điều dưỡng {FullName} đã đổi ca từ {oldShift} sang {newShift}.");
    }
}
