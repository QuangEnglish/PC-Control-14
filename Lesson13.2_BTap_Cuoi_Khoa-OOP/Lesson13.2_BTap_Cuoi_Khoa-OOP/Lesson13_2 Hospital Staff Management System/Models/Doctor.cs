using System.Globalization;

namespace Lesson13_2_Hospital_Staff_Management_System;

public class Doctor : Staff
// Đại diện cho bác sĩ trong bệnh viện.
{
   private string _specialty; //: string - Chuyên khoa (Nội, Ngoại, Tim mạch, Thần kinh...)
   private int _patientCount; //: int - Số bệnh nhân đang phụ trách
   private int _maxPatients; //: int - Số bệnh nhân tối đa có thể nhận
   private string _licenseNumber; //: string - Số giấy phép hành nghề

   // Properties
   public string Specialty { get; set; }

   public int PatientCount
   {
      get { return _patientCount; }
      set
      {
         if (value < 0 || value > _maxPatients)
         {
            throw new ArgumentException("Không được âm và không vượt quá `MaxPatients`");
         }

         _patientCount = value;
      }
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
   
   // Constructor
   public Doctor(
      string staffId,
      string fullName,
      string department,
      string specialty,
     
      int maxPatients,
      string licenseNumber)
      : base(staffId,fullName, department)
   {
      Specialty = specialty;
      MaxPatients = maxPatients;
      LicenseNumber = licenseNumber;
      
      _maxPatients = 0;
   }
   
   // Methods
   public override string GetRole()
   {
       base.GetInfo();
       string dutyStatus = IsOnDuty ? "Đang trực" : "Nghỉ";
      return $"Bác sĩ" + "[" + _specialty+ "]:"+ _patientCount+"/"+_maxPatients +"bệnh nhân ("+dutyStatus+")";
       
   }

   public override string GetInfo()
   {
      base.GetInfo();
      return "Chuyên khoa: " + Specialty 
                    + ", Số bệnh nhân đang phụ trách: " + PatientCount
                    + ", Số bệnh nhân tối đa có thể nhận: " + MaxPatients
                    + ", Số giấy phép hành nghề: " + LicenseNumber;
   }
   
   // Tăng `PatientCount` lên 1, trả về `bool` (false nếu đã đầy)
   public bool AcceptPatient()
   {
      if (PatientCount >= MaxPatients)
      {
         return false;
      }

      PatientCount++;
      return true;
   }
   
   // Giảm `PatientCount` đi 1, trả về `bool` (false nếu đang 0)
   public bool DischargePatient()
   {
      if (PatientCount <= 0)
      {
         return false;
      }

      PatientCount--;
      return true;
   }

 
   
}
