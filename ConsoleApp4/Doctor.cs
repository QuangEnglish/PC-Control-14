namespace ConsoleApp4;

public class Doctor : Staff
{
    private string _specialty;
    private int _patientCount;
    private int _maxPatient;
    private string _licenseNumber;

    public string Specialty { get; set; }

    public int PatientCount
    {
        get { return _patientCount; }
        set
        {
            if (value < 0 || value > MaxPatient)
            {
                throw new ArgumentException();
            }
        }
    }
    public int MaxPatient { get; set; }
    public string LicenseNumber { get; set; }

    public Doctor(string staffId, string fullName, string department, string specialty, int maxPatient, string licenseNumber) : base(staffId, fullName, department)    
    {
        Specialty = specialty;
        MaxPatient = maxPatient;
        LicenseNumber = licenseNumber;
        _patientCount = 0;
    }

    public override string GetRole()
    {
        if (IsOnDuty == true)
        {
            return $"{StaffId}: Bác sĩ {Specialty}: {PatientCount}/{MaxPatient} bệnh nhân (Đang trực)";
        }
        else
        {
            return $"{StaffId}: Bác sĩ {Specialty}: {PatientCount}/{MaxPatient} bệnh nhân, (Nghỉ)";
        }
    }

    public override string GetInfo()
    {
        return $"Doctor" + base.GetInfo() + $"Chuyên khoa: {Specialty} | {LicenseNumber}\nBệnh nhân: {PatientCount}/{MaxPatient}\nNgày vào làm: {HireDate}";
    }

    public bool AcceptPatient()
    {
        PatientCount++;
        Console.WriteLine($"Bác sĩ {FullName} đã tiếp nhận bệnh nhân");
        Console.WriteLine($"Số bệnh nhân hiện tại: {PatientCount}/{MaxPatient}");
        if (PatientCount >= MaxPatient)
        {
            PatientCount = MaxPatient;
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool DischargePatient()
    {
        PatientCount--;
        if (PatientCount == 0)
        {
            PatientCount = 0;
            return false;
        }
        else
        {
            return true;
        }
    }
}