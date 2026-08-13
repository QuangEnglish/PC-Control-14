using ConsoleApp2.Abstract;

namespace ConsoleApp2.Class_;

public class Doctor:Staff
{


    #region Field & Property

    private string _specialty;
    private int _patientCount;
    private int _maxPatients;
    private string _licenseNumber;
    
    public string Specialty
    {
        get => _specialty;
        set => _specialty = value;
    }

    public int PatientCount
    {
        get => _patientCount;
        set
        {
            if (value >= 0 && value < MaxPatients) _patientCount = value;
            else throw new Exception("Patient count không được âm và không vượt quá `MaxPatients`");
        }
    }

    public int MaxPatients
    {
        get => _maxPatients;
        set => _maxPatients = value;
    }

    public string LicenseNumber
    {
        get => _licenseNumber;
        set => _licenseNumber = value;
    }

    #endregion

    #region Contructor

    public Doctor(string staffId, string fullName, string department, string specialty, int maxPatients,
        string licenseNumber)
        : base(staffId, fullName, department)
    {
        Specialty = specialty;
        MaxPatients = maxPatients;
        LicenseNumber = licenseNumber;
        _patientCount = 0;
    }


    #endregion

    #region Method

    public override string GetRole()
    {
        //"Bác sĩ [specialty]: patientCount/maxPatients bệnh nhân (Đang trực/Nghỉ)
        string sOnDuty = IsOnDuty ? "Đang trực" : "Nghỉ";
        return $"Bác sĩ [{_specialty}]: {_patientCount}/{_maxPatients} bệnh nhân ({sOnDuty})";

    }

    public override string GetInfo()
    {
        return base.GetInfo()
            + $"Chuyên khoa: {_specialty} + | GPHM: {_licenseNumber}\n\t"
            + $"Bệnh nhân: {_patientCount}/{_maxPatients}\n\t"
            + $"Ngày vào làm: {HireDate}";
        
    }

    public bool AcceptPatient()
    {
        if (_patientCount == _maxPatients)
        {
            return false;
        }
        else
        {
            _patientCount++;
            return true;
        }
        
    }
    public bool DischargePatient()
    {
        if (_patientCount == 0)
        {
            return false;
        }
        else
        {
            _patientCount--;
            return true;
        }
        
    }

    #endregion
}