namespace BTVN_10._82026___Hospital_Staff_Management_System;

public class Nurse : Staff
{
    //Field
    private string _ward;
    private string _shiftType;
    private double _totalHoursWorked;
    
    //Property
    public string Ward { get => _ward; set => _ward = value; } //Khu vực phụ trách (Khu A, Khu B, ICU...)
    public string ShiftType { get => _shiftType; set => _shiftType = value; } //Loại ca trực (Sáng, Chiều, Đêm)

    public double TotalHoursWorked //Tổng số giờ đã làm trong tháng không được âm và không vượt quá 300 giờ/tháng.
    {
        get => _totalHoursWorked;
        set
        {
            if (value < 0) 
                throw new ArgumentException("Số giờ làm không được âm!");
            if (value > 300)
                throw new ArgumentException("Số giờ làm không được vượt quá 300 giờ/tháng!");
            _totalHoursWorked = value;
        }
    } 
    
    //-----------------Constructor--------------------
    public Nurse(string staffId, string fullName, string department, string ward, string shiftType) : base(staffId,
        fullName, department)
    {
        _ward = ward;
        _shiftType = shiftType;
        _totalHoursWorked = 0;
    }
    
    //----------------------Method-------------------------
    // OVERRIDE GetRole() (đa hình) - Nurse có định dạng vai trò riêng.
    public override string GetRole()
    {
        string trangThai = IsOnDuty ? "Đang trực" : "Nghỉ";
        return $"Điều dưỡng {FullName}: Ca {_shiftType} - Khu {_ward} ({trangThai})";
    }
    
    // OVERRIDE GetInfo(): tái sử dụng base.GetInfo() rồi thêm thông tin khu vực, ca trực.
    public override string GetInfo()
    {
        return base.GetInfo() +
               $"\n    Khu vực: {_ward} | Ca trực: {_shiftType}" +
               $"\n    Giờ làm tháng này: {_totalHoursWorked} giờ" +
               $"\n    Ngày vào làm: {HireDate:dd/MM/yyyy}";
    }
    
    // OVERRIDE CheckIn(): gọi base.CheckIn() (set IsOnDuty = true) rồi in thêm ca trực hiện tại.
    public override bool CheckIn()
    {
        bool result = base.CheckIn();
        Console.WriteLine($">> Điều dưỡng {FullName} đã vào ca {_shiftType}");
        return result;
    }
    
    // OVERRIDE CheckOut(): gọi base.CheckOut() rồi cộng dồn 8 giờ vào TotalHoursWorked.
    public override bool CheckOut()
    {
        bool result = base.CheckOut();

        // Nếu cộng thêm 8 giờ mà vượt quá giới hạn 300 giờ/tháng thì chặn lại tối đa 300 (tránh crash).
        double gioMoi = _totalHoursWorked + 8;
        TotalHoursWorked = gioMoi > 300 ? 300 : gioMoi;

        return result;
    }
    
    // Đổi ca trực - có validation, chỉ chấp nhận đúng 3 giá trị: "Sáng", "Chiều", "Đêm".
    public bool ChangeShift(string newShift)
    {
        if (newShift != "Sáng" && newShift != "Chiều" && newShift != "Đêm")
        {
            Console.WriteLine(">> Ca trực không hợp lệ! Chỉ nhận: Sáng, Chiều, Đêm");
            return false;
        }

        _shiftType = newShift;
        Console.WriteLine($">> Đã đổi ca trực sang: {newShift}");
        return true;
    }
}