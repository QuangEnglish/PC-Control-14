namespace Lesson13_2_Hospital_Staff_Management_System;

public class Pharmacist : Staff
  //Đại diện cho dược sĩ.
{
    private string _pharmacyBranch;    //string - Chi nhánh nhà thuốc (Nhà thuốc chính, Nhà thuốc cấp cứu...)
    private string _certificateLevel;  // string - Bằng cấp (Dược sĩ Đại học, Dược sĩ Cao đẳng...)
    private int _prescriptionCount;    // int - Số đơn thuốc đã xử lý trong ngày
    private bool _isLicenseValid;      //bool - Giấy phép còn hiệu lực không
    
    // Properties
    // PharmacyBranch
    public string PharmacyBranch { get { return _pharmacyBranch; } set { _pharmacyBranch = value; } }
    // CertificateLevel
    public string CertificateLevel { get { return _certificateLevel; } set { _certificateLevel = value; } }
    // PrescriptionCount
    public int PrescriptionCount { get { return _prescriptionCount; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException( "So don thuoc khong duoc am.");
            }
            _prescriptionCount = value;
        } 
    }
    // IsLicenseValid - chỉ đọc bên ngoài
    public bool IsLicenseValid { get { return _isLicenseValid; } }
    
    // Constructor
    public Pharmacist(
        string staffId,
        string fullName,
        string department,
        string pharmacyBranch,
        string certificateLevel)
        : base(staffId, fullName, department)
    {
        PharmacyBranch = pharmacyBranch; 
        CertificateLevel = certificateLevel; 
        _prescriptionCount = 0; 
        _isLicenseValid = true;
    }
    // GetRole
    public override string GetRole()
    {
        
        string status = IsOnDuty ? "Đang trực" : "Nghỉ";
        return $"Dược sĩ {CertificateLevel}: {PharmacyBranch} - " 
               + $"{PrescriptionCount} đơn đã xử lý ({status})";
    }
    
    // GetInfo
    public override string GetInfo()
    {
        base.GetInfo();
        return base.GetInfo() + $", Chi nhánh: {PharmacyBranch}" + $", Bằng cấp: {CertificateLevel}";
    }
    
    // ProcessPrescription
    public void ProcessPrescription()
    {
        if (!IsLicenseValid)
        {
            Console.WriteLine( "Giấy phép đã hết hạn. Không thể xử lý đơn thuốc."); 
            return;
        } 
        PrescriptionCount++;
        Console.WriteLine( $"Đã xử lý đơn thuốc. Tổng số đơn: {PrescriptionCount}");
    } 
    // RenewLicense
    public void RenewLicense()
    {
        _isLicenseValid = true;
        Console.WriteLine("Giấy phép đã được gia hạn.");
    } 
    // CheckIn
    public override bool CheckIn()
    {
        if (!IsLicenseValid)
        {
            Console.WriteLine("Giấy phép đã hết hạn. Không thể vào ca.");
            return false;
        }

        return base.CheckIn();
    }
}