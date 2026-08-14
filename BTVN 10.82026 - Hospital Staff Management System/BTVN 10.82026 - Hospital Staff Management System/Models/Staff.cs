namespace BTVN_10._82026___Hospital_Staff_Management_System;

public abstract class Staff : IWorkable
{
    //field 
    private string _staffId; //mã nv
    private string _fullName; // họ tên nv
    private string _department;// khoa/ phòng ban
    private bool _isOnDuty; // Trạng thái đang trực hay không
    private DateTime _hireDate; // Ngày vào làm
    
    //property
    public string StaffId { get => _staffId; } // chỉ cho phép đọc (get), không cho sửa từ bên ngoài

    public string FullName
    {
        get => _fullName;
        set 
        {
            if (string.IsNullOrWhiteSpace(value)) //không được để trống
                throw new ArgumentException("Họ tên không được để trống!");
            _fullName = value;
        }
    }

    public string Department { get => _department; set => _department = value; }
    
    public bool IsOnDuty{get => _isOnDuty;} //chỉ cho phép đọc từ bên ngoà
    
    public DateTime HireDate { get => _hireDate; set => _hireDate = value; }
    
    //-------------------------Construction-------------------
    protected Staff(string staffId, string fullName, string department)
    {
        _staffId = staffId;
        FullName = fullName;           // Gán qua property để validation được áp dụng ngay từ đầu
        _department = department;
        _hireDate = DateTime.Now;      // Yêu cầu đề bài: tự động gán ngày vào làm là thời điểm hiện tại
        _isOnDuty = false;             // Yêu cầu đề bài: mặc định nhân viên mới tạo chưa vào ca
    }
    
    // ----------------------Method----------------
    // ABSTRACT method: không có phần thân (body), BẮT BUỘC mọi class con phải override.
    // Đây chính là nền tảng cho tính ĐA HÌNH (Polymorphism) - mỗi loại nhân viên có 1 vai trò khác nhau.
    public abstract string GetRole();
    
    // VIRTUAL method: có sẵn phần thân mặc định, class con CÓ THỂ (không bắt buộc) override
    // để bổ sung thêm thông tin riêng (dùng base.GetInfo() để tái sử dụng lại đoạn này).
    public virtual string GetInfo()
    {
        return $"Họ tên: {_fullName}\n    Khoa: {_department}";
    }
    
    // Hiện thực (implement) method CheckIn() từ interface IWorkable.
    // Dùng "virtual" để lớp Nurse/Pharmacist vẫn có thể override thêm hành vi riêng.
    public virtual bool CheckIn()
    {
        _isOnDuty = true;
        return true;
    }

    // Hiện thực method CheckOut() từ interface IWorkable.
    public virtual bool CheckOut()
    {
        _isOnDuty = false;
        return true;
    }

    // Hiện thực method TakeLeave() từ interface IWorkable.
    // Nghỉ phép nghĩa là phải ra ca trước, sau đó thông báo ra màn hình.
    public void TakeLeave()
    {
        _isOnDuty = false;
        Console.WriteLine("Nhân viên đã xin nghỉ phép");
    }
}