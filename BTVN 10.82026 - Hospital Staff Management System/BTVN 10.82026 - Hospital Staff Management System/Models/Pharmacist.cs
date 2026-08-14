namespace BTVN_10._82026___Hospital_Staff_Management_System;

public class Pharmacist : Staff
{
    //field
    private string _pharmacyBranch;   // Chi nhánh nhà thuốc
    private string _certificateLevel; // Bằng cấp
    private int _prescriptionCount;   // Số đơn thuốc đã xử lý trong ngày
    private bool _isLicenseValid;     // Giấy phép còn hiệu lực hay không

    // properties
    public string PharmacyBranch { get => _pharmacyBranch; set => _pharmacyBranch = value; }
    public string CertificateLevel { get => _certificateLevel; set => _certificateLevel = value; }

    public int PrescriptionCount
    {
        get => _prescriptionCount;
        set
        {
            if (value < 0)
                throw new ArgumentException("Số đơn thuốc không được âm!");
            _prescriptionCount = value;
        }
    }

    public bool IsLicenseValid { get => _isLicenseValid;}
    
    //---------------------Constructor-------------------------
    public Pharmacist(string staffId, string fullName, string department,
        string pharmacyBranch, string certificateLevel)
        : base(staffId, fullName, department)
    {
        _pharmacyBranch = pharmacyBranch;
        _certificateLevel = certificateLevel;
        _prescriptionCount = 0;   // Chưa xử lý đơn thuốc nào
        _isLicenseValid = true;   // Mặc định giấy phép còn hiệu lực khi mới tạo
    }
    
    //---------------Method--------------------
    // OVERRIDE GetRole() (đa hình) - Pharmacist có định dạng vai trò riêng.
    public override string GetRole()
    {
        string trangThai = IsOnDuty ? "Đang trực" : "Nghỉ";
        return $"Dược sĩ {_certificateLevel}: {_pharmacyBranch} - {_prescriptionCount} đơn đã xử lý ({trangThai})";
    }

    // OVERRIDE GetInfo(): tái sử dụng base.GetInfo() rồi thêm thông tin chi nhánh, bằng cấp.
    public override string GetInfo()
    {
        return base.GetInfo() +
               $"\n    Chi nhánh: {_pharmacyBranch} | Bằng cấp: {_certificateLevel}" +
               $"\n    Đơn đã xử lý hôm nay: {_prescriptionCount}" +
               $"\n    Ngày vào làm: {HireDate:dd/MM/yyyy}";
    }

    // Xử lý 1 đơn thuốc - chỉ thực hiện được khi giấy phép còn hiệu lực.
    public void ProcessPrescription()
    {
        if (!_isLicenseValid)
        {
            Console.WriteLine(">> Giấy phép đã hết hạn, không thể xử lý đơn thuốc!");
            return;
        }

        Console.WriteLine(">> Đang xử lý đơn thuốc...");
        PrescriptionCount = _prescriptionCount + 1;
        Console.WriteLine($">> Dược sĩ {FullName} đã xử lý đơn thuốc thành công!");
        Console.WriteLine($">> Tổng đơn hôm nay: {_prescriptionCount}");
    }

    // Gia hạn lại giấy phép hành nghề.
    public void RenewLicense()
    {
        _isLicenseValid = true;
        Console.WriteLine($">> Đã gia hạn giấy phép cho dược sĩ {FullName}");
    }

    // OVERRIDE CheckIn(): chỉ vào ca được khi giấy phép còn hiệu lực, ngược lại trả về false.
    public override bool CheckIn()
    {
        if (!_isLicenseValid)
        {
            Console.WriteLine(">> Giấy phép hết hạn, không thể vào ca!");
            return false;
        }

        return base.CheckIn();
    }
    
}