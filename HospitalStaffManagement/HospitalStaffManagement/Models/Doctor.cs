using System;

namespace HospitalStaffManagement.Models
{
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

        public int PatientCount
        {
            get { return _patientCount; }
            set
            {
                if (value < 0 || value > _maxPatients)
                {
                    throw new ArgumentException("Số bệnh nhân không hợp lệ!");
                }
                _patientCount = value;
            }
        }

        public Doctor(string staffId, string fullName, string department, string specialty, int maxPatients, string licenseNumber)
            : base(staffId, fullName, department)
        {
            _specialty = specialty;
            _maxPatients = maxPatients;
            _licenseNumber = licenseNumber;
            _patientCount = 0;
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

            return $"Bác sĩ [{_specialty}]: {_patientCount}/{_maxPatients} bệnh nhân ({status})";
        }

        public override string GetInfo()
        {
            string baseInfo = base.GetInfo();
            return baseInfo + $"\n    Chuyên khoa: {_specialty} | GPHM: {_licenseNumber}\n    Bệnh nhân: {_patientCount}/{_maxPatients}";
        }

        public bool AcceptPatient()
        {
            if (_patientCount < _maxPatients)
            {
                PatientCount = _patientCount + 1;
                return true;
            }
            return false;
        }

        public bool DischargePatient()
        {
            if (_patientCount > 0)
            {
                PatientCount = _patientCount - 1;
                return true;
            }
            return false;
        }
    }
}