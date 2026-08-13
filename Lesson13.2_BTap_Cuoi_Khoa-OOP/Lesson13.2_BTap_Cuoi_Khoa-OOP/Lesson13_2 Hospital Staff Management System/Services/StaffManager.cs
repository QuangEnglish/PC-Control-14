namespace Lesson13_2_Hospital_Staff_Management_System;

 public class StaffManager
 //Class quản lý danh sách tất cả nhân viên.
{
      private List<Staff> _staffs ;

      public StaffManager()
      {
           _staffs = new List<Staff>();
      }

      // Them nhan vien vao danh sach
     public void AddStaff(Staff staff)
     {
          _staffs.Add(staff);
     }
     
     // Xoa nhan vien theo ID
     public bool  RemoveStaff(string staffId)
     {
          
         Staff staff = _staffs.FirstOrDefault(s => s.StaffId == staffId);

         if (staff == null)
         {
              return false;
         }
         _staffs.Remove(staff);
         return true;
     }
     
     // Tim nhan vien theo ID, tra ve staff hoac null
     public Staff  FindStaff(string staffId)
     {
         return _staffs.FirstOrDefault(s => s.StaffId == staffId);
        
     }

     // Hien thi tat ca nhan vien
     public List<Staff> GetAllStaff()
     {
          return _staffs;
     }
     
     //Trả về danh sách nhân viên theo loại (dùng Generic)
     public List<T> GetStaffByType<T>() where T : Staff
     {
          return _staffs.OfType<T>().ToList();
     }
     
     // Tất cả nhân viên vào ca
     public void CheckInAll()
     {
          foreach (Staff staff in _staffs)
          {
               staff.CheckIn();
          }
     } 
     
     // Tất cả nhân viên ra ca
     public void CheckOutAll()
     {
          foreach (Staff staff in _staffs)
          {
               staff.CheckOut();
          }
     }
     
     // In vai trò tất cả nhân viên
     public void PrintAllRoles()
     {
          foreach (Staff staff in _staffs)
          {
               Console.WriteLine(staff.GetRole());
          }
     }
}