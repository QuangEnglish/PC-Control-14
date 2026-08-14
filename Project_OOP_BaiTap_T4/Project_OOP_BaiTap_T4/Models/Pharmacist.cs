namespace Project_OOP_BaiTap_T4.Models;

// Dược sĩ - kế thừa từ Staff
public class Pharmacist : Staff
{
    private string _pharmacyBranch;
    private string _certificateLevel;
    private int _prescriptionCount;
    private bool _isLicenseValid;

    public string PharmacyBranch
    {
        get { return _pharmacyBranch; }
        set { _pharmacyBranch = value; }
    }

    public string CertificateLevel
    {
        get { return _certificateLevel; }
        set { _certificateLevel = value; }
    }

    // Validation: không âm
    public int PrescriptionCount
    {
        get { return _prescriptionCount; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Số đơn thuốc không được âm!");
            _prescriptionCount = value;
        }
    }

    // Read-only ra bên ngoài: chỉ đổi được qua RenewLicense() (hoặc nội bộ class)
    public bool IsLicenseValid
    {
        get { return _isLicenseValid; }
    }

    public Pharmacist(string staffId, string fullName, string department,
                       string pharmacyBranch, string certificateLevel)
        : base(staffId, fullName, department)
    {
        _pharmacyBranch = pharmacyBranch;
        _certificateLevel = certificateLevel;
        _prescriptionCount = 0;
        _isLicenseValid = true;
    }

    public override string GetRole()
    {
        string trangThai = IsOnDuty ? "Đang trực" : "Nghỉ";
        return $"Dược sĩ {CertificateLevel}: {PharmacyBranch} - {PrescriptionCount} đơn đã xử lý ({trangThai})";
    }

    public override string GetInfo()
    {
        return base.GetInfo() +
               $"\n    Chi nhánh: {PharmacyBranch} | Bằng cấp: {CertificateLevel}" +
               $"\n    Đơn đã xử lý hôm nay: {PrescriptionCount}" +
               $"\n    Ngày vào làm: {HireDate:dd/MM/yyyy}";
    }

    // Chỉ xử lý được đơn thuốc khi giấy phép còn hiệu lực
    public void ProcessPrescription()
    {
        if (!IsLicenseValid)
        {
            Console.WriteLine(">> Giấy phép hành nghề đã hết hạn, không thể xử lý đơn thuốc!");
            return;
        }
        Console.WriteLine(">> Đang xử lý đơn thuốc...");
        PrescriptionCount++;
        Console.WriteLine($">> Dược sĩ {FullName} đã xử lý đơn thuốc thành công!");
        Console.WriteLine($">> Tổng đơn hôm nay: {PrescriptionCount}");
    }

    // Gia hạn giấy phép
    public void RenewLicense()
    {
        _isLicenseValid = true;
        Console.WriteLine($">> Giấy phép của dược sĩ {FullName} đã được gia hạn!");
    }

    // Override CheckIn: chỉ vào ca được khi giấy phép còn hiệu lực
    public override bool CheckIn()
    {
        if (!IsLicenseValid)
        {
            Console.WriteLine(">> Không thể vào ca: giấy phép hành nghề đã hết hạn!");
            return false;
        }
        return base.CheckIn();
    }
}
