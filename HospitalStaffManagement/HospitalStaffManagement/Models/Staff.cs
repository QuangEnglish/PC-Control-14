using System;
using HospitalStaffManagement.Interfaces;

namespace HospitalStaffManagement.Models
{
    public abstract class Staff : IWorkable
    {
        private string _staffId;
        private string _fullName;
        private string _department;
        private bool _isOnDuty;
        private DateTime _hireDate;

        public string StaffId
        {
            get { return _staffId; }
        }

        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Họ tên không được để trống!");
                }
                _fullName = value;
            }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public bool IsOnDuty
        {
            get { return _isOnDuty; }
            protected set { _isOnDuty = value; }
        }

        public DateTime HireDate
        {
            get { return _hireDate; }
        }

        public Staff(string staffId, string fullName, string department)
        {
            _staffId = staffId;
            FullName = fullName;
            _department = department;
            _hireDate = DateTime.Now;
            _isOnDuty = false;
        }

        public abstract string GetRole();

        public virtual string GetInfo()
        {
            return $"    Họ tên: {_fullName}\n    Khoa: {_department}\n    Ngày vào làm: {_hireDate.ToString("dd/MM/yyyy")}";
        }

        public virtual bool CheckIn()
        {
            _isOnDuty = true;
            return true;
        }

        public virtual bool CheckOut()
        {
            _isOnDuty = false;
            return true;
        }

        public virtual void TakeLeave()
        {
            CheckOut();
            Console.WriteLine("Nhân viên đã xin nghỉ phép");
        }
    }
}