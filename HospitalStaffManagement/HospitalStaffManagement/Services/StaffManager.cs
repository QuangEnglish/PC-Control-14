using System;
using System.Collections.Generic;
using HospitalStaffManagement.Models;

namespace HospitalStaffManagement.Services
{
    public class StaffManager
    {
        private List<Staff> _staffList = new List<Staff>();

        public void AddStaff(Staff staff)
        {
            _staffList.Add(staff);
        }

        public void RemoveStaff(string staffId)
        {
            Staff found = FindStaff(staffId);
            if (found != null)
            {
                _staffList.Remove(found);
            }
        }

        public Staff FindStaff(string staffId)
        {
            for (int i = 0; i < _staffList.Count; i++)
            {
                if (_staffList[i].StaffId == staffId)
                {
                    return _staffList[i];
                }
            }
            return null;
        }

        public List<Staff> GetAllStaff()
        {
            return _staffList;
        }

        public List<T> GetStaffByType<T>() where T : Staff
        {
            List<T> list = new List<T>();
            for (int i = 0; i < _staffList.Count; i++)
            {
                if (_staffList[i] is T)
                {
                    list.Add((T)_staffList[i]);
                }
            }
            return list;
        }

        public void CheckInAll()
        {
            for (int i = 0; i < _staffList.Count; i++)
            {
                _staffList[i].CheckIn();
            }
        }

        public void CheckOutAll()
        {
            for (int i = 0; i < _staffList.Count; i++)
            {
                _staffList[i].CheckOut();
            }
        }

        public void PrintAllRoles()
        {
            Console.WriteLine("=== VAI TRÒ NHÂN VIÊN ===");
            for (int i = 0; i < _staffList.Count; i++)
            {
                Console.WriteLine($"{_staffList[i].StaffId}: {_staffList[i].GetRole()}");
            }
        }
    }
}