using System.Runtime.ConstrainedExecution;
using ConsoleApp2.Abstract;

namespace ConsoleApp2.Class_;

public class Pharmacist:Staff 
{
   

    #region Field & Property
    
    private string _pharmacyBranch;
    private string _certificateLevel;
    private int _prescriptionCount;
    private bool _isLicenseValid;
    public string PharmacyBranch
    {
        get => _pharmacyBranch;
        set => _pharmacyBranch = value;
    }

    public string CertificateLevel
    {
        get => _certificateLevel;
        set => _certificateLevel = value;
    }

    public int PrescriptionCount
    {
        get => _prescriptionCount;
        set
        {
            if (value >= 0) _prescriptionCount = value;
            else throw new Exception("PrescriptionCount không được âm");
        }
    }

    public bool IsLicenseValid
    {
        get => _isLicenseValid;
    }

    #endregion

    #region Constructor

    public Pharmacist(string staffId, string fullName, string department, string pharmacyBranch,
        string certificateLevel)
        : base(staffId, fullName, department)
    {
        PharmacyBranch = pharmacyBranch;
        CertificateLevel = certificateLevel;
        _prescriptionCount = 0;
        _isLicenseValid = true;
    }

    #endregion

    #region Method
    public override string GetRole()
    {
        //"Dược sĩ [certificateLevel]: branch - prescriptionCount đơn đã xử lý (Đang trực/Nghỉ)"`
        string sOnDuty = IsOnDuty ? "Đang trực" : "Nghỉ";
        return $"Dược sĩ [{_certificateLevel}]: {_pharmacyBranch} - {_prescriptionCount} đơn đã xử lý ({sOnDuty})";

    }

    public override string GetInfo()
    {
        return base.GetInfo()
               + $"Chi nhánh: {_pharmacyBranch} | Bằng cấp: {_certificateLevel}\n\t"
               + $"Đơn đã xử lí hôm nay: {_prescriptionCount}\n\t"
               + $"Ngày vào làm: {HireDate}";


    }

    public void ProcessPrescription()
    {
        if (IsLicenseValid)
        {
            _prescriptionCount++;
            Console.WriteLine("ProcessPrescription Done");

        }
    }

    public void RenewLicense()
    {
        _isLicenseValid = true;
        Console.WriteLine("RenewLicense done");
    }

    public override bool CheckIn()
    {
        if (IsLicenseValid)
        {
            return base.CheckIn();
        }
        else return false;

    }

    #endregion

}