namespace BTVN_10._82026___Hospital_Staff_Management_System;

public class Doctor : Staff
{
    //field
    private string _specialty; //Chuyên khoa (Nội, Ngoại, Tim mạch, Thần kinh...)
    private int _patientCount; //Số bệnh nhân đang phụ trách
    private int _maxPatients; //Số bệnh nhân tối đa có thể nhận
    private string _licenseNumber; //Số giấy phép hành nghề
    
    // property
    public string Specialty { get => _specialty; set => _specialty = value; }

    public int PatientCount
    {
        get => _patientCount;
        set
        {
            if (value < 0)
                throw new ArgumentException("Số bệnh nhân không được âm!");
            if (value > _maxPatients)
                throw new ArgumentException("Số bệnh nhân vượt quá giới hạn cho phép!");
            _patientCount = value;
        }
    }
    
    public int MaxPatient { get => _maxPatients; set => _maxPatients = value; }
    public string LicenseNumber { get => _licenseNumber; set => _licenseNumber = value; }

    //-----------------------Construction-------------------
    // ": base(staffId, fullName, department)" -> gọi constructor của class cha Staff
    // để khởi tạo các trường chung (StaffId, FullName, Department, HireDate, IsOnDuty)
    public Doctor(string staffId, string fullName, string department, string specialty,  int maxPatients, string licenseNumber) : base(staffId, fullName, department)
    {
        _specialty = specialty;
        _maxPatients = maxPatients;
        _licenseNumber = licenseNumber;
        _patientCount = 0; // Yêu cầu đề bài: bác sĩ mới chưa có bệnh nhân nào
    }
    
    //----------------------Method--------------------------
    // OVERRIDE GetRole() (đa hình) - Doctor có định dạng vai trò riêng.
    public override string GetRole()
    {
        string trangThai = IsOnDuty ? "Đang trực" : "Nghỉ";
        return $"Bác sĩ {_specialty}: {_patientCount}/{_maxPatients} bệnh nhân ({trangThai})";
    }
    
    // OVERRIDE GetInfo(): gọi base.GetInfo() (Họ tên + Khoa) rồi bổ sung thông tin riêng của Doctor.
    public override string GetInfo()
    {
        return base.GetInfo() +
               $"\n    Chuyên khoa: {_specialty} | GPHM: {_licenseNumber}" +
               $"\n    Bệnh nhân: {_patientCount}/{_maxPatients}" +
               $"\n    Ngày vào làm: {HireDate:dd/MM/yyyy}";
    }
    
    // Tiếp nhận thêm 1 bệnh nhân. Trả về false nếu đã đầy (bằng MaxPatients).
    public bool AcceptPatient()
    {
        if (_patientCount >= _maxPatients)
            return false;

        PatientCount = _patientCount + 1; // gán qua property để validation luôn chạy
        return true;
    }
    
    // Xuất viện (giảm) 1 bệnh nhân. Trả về false nếu hiện đang không có bệnh nhân nào (bằng 0).
    public bool DischargePatient()
    {
        if (_patientCount <= 0)
            return false;

        PatientCount = _patientCount - 1;
        return true;
    }
}