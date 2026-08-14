using System;

namespace HospitalStaffManagement.Models
{
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

        public int PrescriptionCount
        {
            get { return _prescriptionCount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Số đơn thuốc không được âm!");
                }
                _prescriptionCount = value;
            }
        }

        public bool IsLicenseValid
        {
            get { return _isLicenseValid; }
        }

        public Pharmacist(string staffId, string fullName, string department, string pharmacyBranch, string certificateLevel)
            : base(staffId, fullName, department)
        {
            _pharmacyBranch = pharmacyBranch;
            _certificateLevel = certificateLevel;
            _prescriptionCount = 0;
            _isLicenseValid = true;
        }

        public override string GetRole()
        {
            string status = "";
            if (IsOnDuty)
            {
                status = "Đang trực";
            }
            else
            {
                status = "Nghỉ";
            }

            return $"Dược sĩ [{_certificateLevel}]: {_pharmacyBranch} - {_prescriptionCount} đơn đã xử lý ({status})";
        }

        public override string GetInfo()
        {
            string baseInfo = base.GetInfo();
            return baseInfo + $"\n    Chi nhánh: {_pharmacyBranch} | Bằng cấp: {_certificateLevel}\n    Đơn đã xử lý hôm nay: {_prescriptionCount}";
        }

        public void ProcessPrescription()
        {
            if (_isLicenseValid == true)
            {
                PrescriptionCount = _prescriptionCount + 1;
                Console.WriteLine($"Dược sĩ {FullName} đã xử lý đơn thuốc thành công!");
            }
            else
            {
                Console.WriteLine("Lỗi: Giấy phép không còn hiệu lực!");
            }
        }

        public void RenewLicense()
        {
            _isLicenseValid = true;
            Console.WriteLine("Đã gia hạn giấy phép thành công!");
        }

        public override bool CheckIn()
        {
            if (_isLicenseValid == false)
            {
                Console.WriteLine("Không thể vào ca do giấy phép hết hạn!");
                return false;
            }
            return base.CheckIn();
        }
    }
}