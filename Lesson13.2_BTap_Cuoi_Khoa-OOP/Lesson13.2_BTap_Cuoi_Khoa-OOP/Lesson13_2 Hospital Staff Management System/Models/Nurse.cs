namespace Lesson13_2_Hospital_Staff_Management_System;

public class Nurse : Staff
// Đại diện cho y tá/điều dưỡng.
{
    // Filed
    private string _ward;             // string - Khu vực phụ trách (Khu A, Khu B, ICU...)
    private string _shiftType;        // string - Loại ca trực (Sáng, Chiều, Đêm)
    private double _totalHoursWorked; // double - Tổng số giờ đã làm trong tháng

    // Properties
    // Ward
     public string Ward { get { return _ward; } set { _ward = value; } }
     // ShiftType
     public string ShiftType { get { return _shiftType; } set { _shiftType = value; } }
     // TotalHoursWorked
     public double TotalHoursWorked
     {
         get { return _totalHoursWorked; } 
         set
         {
             if (value < 0 || value > 300)
             {
                 throw new ArgumentException( "So gio lam phai tu 0 den 300 gio/thang.");
                 
             } 
             _totalHoursWorked = value;
             
         }
     }
     
     // Constructor
     public Nurse(
         string staffId,
         string fullName,
         string department,
         string ward,
         string shiftType)
         : base(
             staffId,
             fullName,
             department)
     {
         Ward = ward;
         ShiftType = shiftType; 
         _totalHoursWorked = 0;
     }
     
     // Các Methods
     // GetRole
     public override string GetRole()
     {
         string status = IsOnDuty ? "Đang trực" : "Nghỉ"; 
         return $"Điều dưỡng {FullName}: Ca {ShiftType} - Khu {Ward} ({status})";
     } 
     // GetInfo
     public override string GetInfo()
     {
         return base.GetInfo() + $", Khu vực: {Ward}" 
                               + $", Ca trực: {ShiftType}" 
                               + $", Tổng giờ: {TotalHoursWorked}";
     } 
     //CheckIn
     public override bool CheckIn()
     {
         bool result = base.CheckIn();
         if (result)
         {
             Console.WriteLine($"Ca trực hiện tại: {ShiftType}");
         }
      
         return result;
     } 
     
     // CheckOut
     public override bool CheckOut()
     {
         bool result = base.CheckOut();
         if (result)
         {
             TotalHoursWorked += 8;
         }
         return result;
     }
     
     // ChangeShift
     public void ChangeShift(string newShift)
     {
         if (newShift != "Sáng" && newShift != "Chiều" && newShift != "Đêm")
         {
             throw new ArgumentException( "Ca trực chỉ có: Sáng, Chiều hoặc Đêm.");
         } 
         ShiftType = newShift;
     }
}