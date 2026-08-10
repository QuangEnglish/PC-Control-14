namespace Lesson_13_BTVN_CuoiKhoa_OOP.Machine;

public class PLC : Device // Đại diện cho bộ điều khiển PLC.
{
    // Filed
    private string _brand;      // string - Hãng sản xuất (Siemens, Mitsubishi, Omron...)
    private string _model;      // string - Model (S7-1200, FX5U, CP1H...)
    private string _ipAddress;  // string - Địa chỉ IP
    private bool _isConnected;  // bool - Trạng thái kết nối

    // Propertis
    public string Brand { get; set; }
    public string Model { get; set; }
    
    public string IpAddress 
    { get  { return _ipAddress; } 
        set
        {
            int count = 0;
            //  kiểm tra định dạng IP đơn giản (chứa 3 dấu chấm)
            foreach (var c  in value)
            {
                if (c == '.')
                {
                    count++;
                }
            }

            if (count != 3)
            {
                throw new ArgumentOutOfRangeException(
                    "IpAddress Phải có 3 dấu chấm.");
            }
                
            _ipAddress = value;
        }
        
    }
    
    public bool IsConnected
    {
        get { return _isConnected; }    
    }
    
    // Contructor
    public PLC
    (
        string deviceId,
        string devieName,
        string location,
        string brand,
        string model,
        string ipAddress)
        : base(deviceId, devieName, location)
    {
        
        Brand = brand;
        Model = model;
        IpAddress = ipAddress;
        _isConnected = false;
    }
    
    // GetStatus
    public override string GetStatus() 
    {
        string connectionStatus;
        string runningStatus;

        if (IsConnected)
        {
            connectionStatus = "Connected";
        }
        else
        {
            connectionStatus = "Disconnected";
        }

        if (IsRunning)
        {
            runningStatus = "Running";
        }
        else
        {
            runningStatus = "Stopped";
        }

        return "PLC [" + Brand + " " + Model + "]: "
               + connectionStatus + "-"
               + runningStatus;
    }

    // GetInfo
    public override string GetInfo() // thêm thông tin IP, brand, model
    {
        return base.GetInfo()
               + ", Brand: " + Brand
               + ", Model: " + Model
               + ", IP: " + IpAddress;
    }

    // Connect
    public void Connect()  // in thông báo
    {
        _isConnected = true;

        Console.WriteLine(
            "PLC " + Brand + " " + Model + " da ket noi.");
    }

    // Disconnect
    public void Disconnect()  // in thông báo
    {
        _isConnected = false;

        Console.WriteLine(
            "PLC " + Brand + " " + Model + " da ngat ket noi.");
    }

    // Start
    // Chỉ start được khi đã Connect, nếu chưa connect thì return false
    public override bool Start()
    {
        if (!IsConnected)
        {
            Console.WriteLine("PLC chua ket noi.");
            return false;
        }

        return base.Start();
    }
}