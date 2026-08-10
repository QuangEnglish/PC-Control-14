using System.Security.AccessControl;

namespace Lesson_13_BTVN_CuoiKhoa_OOP.Machine;

 public class Sensor : Device  // Đại diện cho các loại cảm biến (nhiệt độ, áp suất, lưu lượng...)
 {
     // Filed
     private string _sensorType;      //string - Loại cảm biến (Temperature, Pressure, Flow, Level...)
     private double _currentValue;   //double - Giá trị đang đo được 
     private string _unit;          //string - Đơn vị (°C, bar, m³/h, mm...)
     private double _minValue;     //double - Giá trị tối thiểu
     private double _maxValue;    //double - Giá trị tối đa

     // Propertis
     public string SensorType
     {
         get { return _sensorType; }
         set { _sensorType = value; }
     }
     public double CurrentValue
     {
         get { return _currentValue; }
         set
         {
             if (value < MinValue || value > MaxValue)
             {
                 throw new ArgumentException(
                     "CurrentValue phai nam trong khoang MinValue va MaxValue.");
             }

             _currentValue = value;
         }
         
     }
     public string Unit
     {
         get { return _unit; }  
         set { _unit = value; }
     }

     public double MinValue
     {
         get { return _minValue; }
         set { _minValue = value; }
     }

     public double MaxValue
     {
         get { return _maxValue; }
         set { _maxValue = value; }
     }
     
     // Contructor
    public Sensor(
        string deviceId, 
        string devieName,
        string location,
        string sensorType,
        string unit,
        double minValue,
        double maxValue
       )
        :base(deviceId, devieName,location)
    {
        SensorType = sensorType;
        Unit  = unit;
        MinValue = minValue;
        MaxValue = maxValue;
        
        _currentValue = 0;
    }
    
    // Override GetStatus()
    public override string GetStatus()
    {
        //string status = IsRunning ? "Running" : "Stopped"; // Viết tắt ?: = if/else

        string status;

        if (IsRunning)
        {
            status = "Running";
        }
        else
        {
            status = "Stopped";
        }
        
        return "[" + SensorType + "] Value: "
               + CurrentValue + " "
               + Unit + " (" + status + ")";
    }

    // Override GetInfo()
    public override string GetInfo()
    {
        return base.GetInfo()
               + ", SensorType: " + SensorType
               + ", CurrentValue: " + CurrentValue
               + ", Unit: " + Unit
               + ", MinValue: " + MinValue
               + ", MaxValue: " + MaxValue;
    }

    // ReadValue()
    public void ReadValue()
    {
        Random random = new Random(); // Ramdom là class có sẵn trong C# (tạo số ngẫu nhiên)
                                     // random là tên biến để dùng đói tượng Random

        CurrentValue = MinValue +
                       random.NextDouble() * (MaxValue - MinValue);
        //Phương thức NextDouble() tạo ra một số thực ngẫu nhiên từ 0.0 đến nhỏ hơn 1.0.
    }

    // IsAlarm()
    public bool IsAlarm()
    {
        return CurrentValue > MaxValue * 0.8;
    }
}