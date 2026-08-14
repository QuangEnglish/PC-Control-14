namespace Project_Final_OOP_V2.Models;

// Class Pharmacist kế thừa từ Staff - đại diện cho dược sĩ
public class Pharmacist : Staff
{
    // === ENCAPSULATION: private fields riêng của Pharmacist ===
    private string _pharmacyBranch;
    private string _certificateLevel;
    private int _prescriptionCount;
    private bool _isLicenseValid;

    // === PROPERTIES ===
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

    // PrescriptionCount: validation - không được âm
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

    // IsLicenseValid: chỉ cho phép đọc từ bên ngoài
    public bool IsLicenseValid
    {
        get { return _isLicenseValid; }
    }

    // === CONSTRUCTOR: gọi base constructor của Staff ===
    public Pharmacist(string staffId, string fullName, string department,
                      string pharmacyBranch, string certificateLevel)
        : base(staffId, fullName, department)
    {
        _pharmacyBranch = pharmacyBranch;
        _certificateLevel = certificateLevel;
        _prescriptionCount = 0;
        _isLicenseValid = true;
    }

    // === POLYMORPHISM: Override GetRole() ===
    public override string GetRole()
    {
        string status = IsOnDuty ? "Đang trực" : "Nghỉ";
        return $"Dược sĩ {_certificateLevel}: {_pharmacyBranch} - {_prescriptionCount} đơn đã xử lý ({status})";
    }

    // Override GetInfo(): gọi base.GetInfo() + thêm thông tin riêng
    public override string GetInfo()
    {
        return base.GetInfo() + "\n" +
               $"    Chi nhánh: {_pharmacyBranch} | Bằng cấp: {_certificateLevel}\n" +
               $"    Đơn đã xử lý hôm nay: {_prescriptionCount}\n" +
               $"    Ngày vào làm: {HireDate:dd/MM/yyyy}";
    }

    // Xử lý đơn thuốc - chỉ xử lý được khi giấy phép còn hiệu lực
    public void ProcessPrescription()
    {
        if (!_isLicenseValid)
        {
            Console.WriteLine(">> Lỗi: Giấy phép đã hết hạn! Không thể xử lý đơn thuốc.");
            return;
        }
        Console.WriteLine(">> Đang xử lý đơn thuốc...");
        _prescriptionCount++;
        Console.WriteLine($">> Dược sĩ {FullName} đã xử lý đơn thuốc thành công!");
        Console.WriteLine($">> Tổng đơn hôm nay: {_prescriptionCount}");
    }

    // Gia hạn giấy phép
    public void RenewLicense()
    {
        _isLicenseValid = true;
        Console.WriteLine($">> Giấy phép của dược sĩ {FullName} đã được gia hạn thành công!");
    }

    // Override CheckIn(): chỉ vào ca khi giấy phép còn hiệu lực
    public override bool CheckIn()
    {
        if (!_isLicenseValid)
        {
            Console.WriteLine($">> Lỗi: Dược sĩ {FullName} không thể vào ca - Giấy phép đã hết hạn!");
            return false;
        }
        base.CheckIn();
        return true;
    }
}
