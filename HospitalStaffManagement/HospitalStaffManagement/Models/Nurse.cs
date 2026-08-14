using System;

namespace HospitalStaffManagement.Models
{
    public class Nurse : Staff
    {
        private string _ward;
        private string _shiftType;
        private double _totalHoursWorked;

        public string Ward
        {
            get { return _ward; }
            set { _ward = value; }
        }

        public string ShiftType
        {
            get { return _shiftType; }
            set { _shiftType = value; }
        }

        public double TotalHoursWorked
        {
            get { return _totalHoursWorked; }
            set
            {
                if (value < 0 || value > 300)
                {
                    throw new ArgumentException("Số giờ làm không hợp lệ!");
                }
                _totalHoursWorked = value;
            }
        }

        public Nurse(string staffId, string fullName, string department, string ward, string shiftType)
            : base(staffId, fullName, department)
        {
            _ward = ward;
            _shiftType = shiftType;
            _totalHoursWorked = 0;
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

            return $"Điều dưỡng [{FullName}]: Ca {_shiftType} - Khu {_ward} ({status})";
        }

        public override string GetInfo()
        {
            string baseInfo = base.GetInfo();
            return baseInfo + $"\n    Khu vực: {_ward} | Ca trực: {_shiftType}\n    Giờ làm tháng này: {_totalHoursWorked} giờ";
        }

        public override bool CheckIn()
        {
            bool check = base.CheckIn();
            Console.WriteLine($"Điều dưỡng {FullName} đang trực ca {_shiftType}");
            return check;
        }

        public override bool CheckOut()
        {
            bool check = base.CheckOut();
            TotalHoursWorked = _totalHoursWorked + 8;
            return check;
        }

        public void ChangeShift(string newShift)
        {
            if (newShift == "Sáng" || newShift == "Chiều" || newShift == "Đêm")
            {
                _shiftType = newShift;
                Console.WriteLine($"Đã đổi sang ca {newShift}");
            }
            else
            {
                Console.WriteLine("Ca trực không hợp lệ!");
            }
        }
    }
}