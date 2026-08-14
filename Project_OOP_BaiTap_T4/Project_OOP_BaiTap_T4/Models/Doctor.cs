namespace Project_OOP_BaiTap_T4.Models;

// Bác sĩ - kế thừa (Inheritance) từ Staff
public class Doctor : Staff
{
    private string _specialty;
    private int _patientCount;
    private int _maxPatients;
    private string _licenseNumber;

    public string Specialty
    {
        get { return _specialty; }
        set { _specialty = value; }
    }

    public int MaxPatients
    {
        get { return _maxPatients; }
        set { _maxPatients = value; }
    }

    public string LicenseNumber
    {
        get { return _licenseNumber; }
        set { _licenseNumber = value; }
    }

    // Validation: không âm và không vượt quá MaxPatients
    public int PatientCount
    {
        get { return _patientCount; }
        set
        {
            if (value < 0 || value > _maxPatients)
                throw new ArgumentException("Số bệnh nhân không hợp lệ!");
            _patientCount = value;
        }
    }

    // "base(staffId, fullName, department)" gọi constructor của Staff trước,
    // sau đó mới chạy phần thân constructor của Doctor.
    public Doctor(string staffId, string fullName, string department,
                  string specialty, int maxPatients, string licenseNumber)
        : base(staffId, fullName, department)
    {
        _specialty = specialty;
        _maxPatients = maxPatients;
        _licenseNumber = licenseNumber;
        _patientCount = 0;
    }

    // POLYMORPHISM: override GetRole -> mỗi loại nhân viên trả lời khác nhau
    public override string GetRole()
    {
        string trangThai = IsOnDuty ? "Đang trực" : "Nghỉ";
        return $"Bác sĩ {Specialty}: {PatientCount}/{MaxPatients} bệnh nhân ({trangThai})";
    }

    // Gọi base.GetInfo() để lấy thông tin chung, rồi nối thêm thông tin riêng của Doctor
    public override string GetInfo()
    {
        return base.GetInfo() +
               $"\n    Chuyên khoa: {Specialty} | GPHM: {LicenseNumber}" +
               $"\n    Bệnh nhân: {PatientCount}/{MaxPatients}" +
               $"\n    Ngày vào làm: {HireDate:dd/MM/yyyy}";
    }

    // Tăng số bệnh nhân lên 1, false nếu đã đầy
    public bool AcceptPatient()
    {
        if (_patientCount >= _maxPatients)
            return false;
        PatientCount++;
        return true;
    }

    // Giảm số bệnh nhân đi 1, false nếu đang bằng 0
    public bool DischargePatient()
    {
        if (_patientCount <= 0)
            return false;
        PatientCount--;
        return true;
    }
}
