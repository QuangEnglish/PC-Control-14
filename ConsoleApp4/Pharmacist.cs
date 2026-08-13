namespace ConsoleApp4;

public class Pharmacist : Staff
{
    private string _pharmacybranch;
    private string _certificateLevel;
    private int _prescriptionCount;
    private bool _isLicensedValid;

    public string Pharmacybranch { get; set; }
    public string CertificateLevel { get; set; }
    public int PrescriptionCount { get; set; }
    public bool IsLicensedValid { get; set; }

    public Pharmacist(string staffId, string fullName, string department, string pharmacybranch, string certificateLevel) : base(staffId, fullName, department)
    {
        Pharmacybranch = pharmacybranch;
        CertificateLevel = certificateLevel;
        _prescriptionCount = 0;
        _isLicensedValid = false;
    }

    public override string GetRole()
    {
        if (IsOnDuty == true)
        {
            return $"{StaffId}: Dược sĩ {CertificateLevel}: {Pharmacybranch} - {PrescriptionCount} đơn đã xử lý (Đang trực)";
        }
        else
        {
            return $"{StaffId}: Dược sĩ {CertificateLevel}: {Pharmacybranch} - {PrescriptionCount} đơn đã xử lý (Nghỉ)";
        }
    }

    public override string GetInfo()
    {
        return $"Pharmacist" + base.GetInfo() + $"Chi nhánh: {Pharmacybranch} | Bằng cấp: {CertificateLevel}\nĐơn đã xử lý hôm nay: {PrescriptionCount}\nNgày vào làm: {HireDate}";
    }

    public void ProcessPrescription()
    {
        if (IsLicensedValid == true)
        {
            PrescriptionCount++;
            Console.WriteLine("Đang xử lý đơn thuốc...");
            Console.WriteLine($"Dược sĩ {FullName} đã xử lý đơn thuốc thành công!");
            Console.WriteLine($"Tổng đơn hôm nay: {_prescriptionCount}");
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public void RenewLicense()
    {
        _isLicensedValid = true;
        Console.WriteLine("Đã Renew");
    }

    public override bool CheckIn()
    {
        if (IsLicensedValid == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}