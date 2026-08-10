using System.Globalization;

namespace Lesson_13_BTVN_CuoiKhoa_OOP.Machine;

public abstract class Device : IControllable  
// Đây là class cơ sở cho tất cả thiết bị, implement interface 

{

    private readonly string _deviceId;    //string - Mã thiết bị
    private string _deviceName;          //string - Tên thiết bị
    private string _location;           //string - Vị trí lắp đặt
    
    private bool _isRunning;                     //bool - Trạng thái đang chạy hay không
    private readonly DateTime _installDate;      //DateTime - Ngày lắp đặt
    
    // Propertis
    public string DeviceId        //Chi cho phep doc tu ben ngoai
    { 
        get { return _deviceId; }
    }
 
    public string DeviceName    // Khong duoc de trong 
    {
        get { return _deviceName; }
        set   
        {
            if (string.IsNullOrWhiteSpace(value))  // phuong thuc kiem tra chuoi string
            {
                throw new ArgumentException("DeviceName khong duoc de trong.");
            }

            _deviceName = value;
        }
    }


    public bool IsRunning     //Chi cho phep doc tu ben ngoai
    {
        get { return _isRunning; }

    }

    public DateTime InstallDate   // Kiểu DateTime
    {
        get { return _installDate; }
    }

    public string Location
    {
        get { return _location; }
        set { _location = value; }
    }
    
    // Contructor
    public Device(string deviceId,string deviceName,  string location )
    {
        
        _deviceId = deviceId;
        Location = location;
        DeviceName = deviceName;
        
        _installDate = DateTime.Now;
        _isRunning = false;
    }
    
    // Abstract method
    public abstract string GetStatus();

    // Virtual method
    public virtual string GetInfo()
    {
        return "ID: " + DeviceId 
                      + ", Name: " + DeviceName
                      + ", Location: " + Location
                      + ", Install Date: " + InstallDate;
    }

    // Implement IControllable
    public virtual bool Start()
    {
        _isRunning = true;
        return true; // Kết quả OK
    }

    public virtual bool Stop()
    {
        _isRunning = false;
        return true; // Kết quả Ok
    }

    public void Reset()
    {
        Stop();  // Đã stop
        Console.WriteLine("Device reset"); // Thông báo reset
        
    }
    
}