namespace Project_Final_OOP_V2.Models;

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

    public Doctor(string staffId, string fullName, string department,
                  string specialty, int maxPatients, string licenseNumber)
        : base(staffId, fullName, department)
    {
        _specialty = specialty;
        _maxPatients = maxPatients;
        _licenseNumber = licenseNumber;
        _patientCount = 0;
    }

    public override string GetRole()
    {
        string status = IsOnDuty ? "Đang trực" : "Nghỉ";
        return $"Bác sĩ {_specialty}: {_patientCount}/{_maxPatients} bệnh nhân ({status})";
    }

    public override string GetInfo()
    {
        return base.GetInfo() + "\n" +
               $"    Chuyên khoa: {_specialty} | GPHM: {_licenseNumber}\n" +
               $"    Bệnh nhân: {_patientCount}/{_maxPatients}\n" +
               $"    Ngày vào làm: {HireDate:dd/MM/yyyy}";
    }

    public bool AcceptPatient()
    {
        if (_patientCount >= _maxPatients)
        {
            Console.WriteLine($">> Bác sĩ {FullName} đã đầy bệnh nhân!");
            return false;
        }
        _patientCount++;
        Console.WriteLine($">> Bác sĩ {FullName} đã tiếp nhận bệnh nhân!");
        Console.WriteLine($">> Số bệnh nhân hiện tại: {_patientCount}/{_maxPatients}");
        return true;
    }

    public bool DischargePatient()
    {
        if (_patientCount <= 0)
        {
            Console.WriteLine($">> Bác sĩ {FullName} hiện không có bệnh nhân nào!");
            return false;
        }
        _patientCount--;
        Console.WriteLine($">> Bác sĩ {FullName} đã xuất viện 1 bệnh nhân!");
        Console.WriteLine($">> Số bệnh nhân hiện tại: {_patientCount}/{_maxPatients}");
        return true;
    }
}
