namespace Project_Final_OOP.Models;

// Class PLC - Kế thừa từ Device
// Đại diện cho bộ điều khiển PLC (Programmable Logic Controller)
public class PLC : Device
{
    // ===== FIELDS riêng của PLC (private) =====
    private string _brand;        // Hãng sản xuất: Siemens, Mitsubishi, Omron...
    private string _model;        // Model: S7-1200, FX5U, CP1H...
    private string _ipAddress;    // Địa chỉ IP
    private bool _isConnected;    // Trạng thái kết nối

    // ===== PROPERTIES =====
    public string Brand
    {
        get { return _brand; }
        set { _brand = value; }
    }

    public string Model
    {
        get { return _model; }
        set { _model = value; }
    }

    // IpAddress có VALIDATION: kiểm tra định dạng IP đơn giản (phải chứa 3 dấu chấm)
    // Ví dụ hợp lệ: 192.168.1.10 (có 3 dấu chấm)
    // Ví dụ KHÔNG hợp lệ: 192.168 (chỉ có 1 dấu chấm)
    public string IpAddress
    {
        get { return _ipAddress; }
        set
        {
            if (value.Count(c => c == '.') != 3)
                throw new ArgumentException("Địa chỉ IP không hợp lệ! (phải có dạng x.x.x.x)");
            _ipAddress = value;
        }
    }

    public bool IsConnected
    {
        get { return _isConnected; }
        set { _isConnected = value; }
    }

    // ===== CONSTRUCTOR =====
    public PLC(string deviceId, string deviceName, string location,
               string brand, string model, string ipAddress)
        : base(deviceId, deviceName, location) // Gọi constructor Device
    {
        _brand = brand;
        _model = model;
        IpAddress = ipAddress; // Dùng Property để validate IP
        _isConnected = false;  // Mặc định chưa kết nối
    }

    // ===== METHODS =====

    // Override GetStatus() - Hiển thị trạng thái riêng của PLC
    public override string GetStatus()
    {
        string connStatus = _isConnected ? "Connected" : "Disconnected";
        string runStatus = IsRunning ? "Running" : "Stopped";
        return $"PLC {_brand} {_model}: {connStatus} - {runStatus}";
    }

    // Override GetInfo() - Thêm thông tin IP, hãng, model
    public override string GetInfo()
    {
        return base.GetInfo() + "\n" +
               $"    Hãng: {_brand} {_model}\n" +
               $"    IP: {_ipAddress}";
    }

    // Kết nối PLC
    public void Connect()
    {
        _isConnected = true;
        Console.WriteLine($">> {DeviceName} đã kết nối thành công! (IP: {_ipAddress})");
    }

    // Ngắt kết nối PLC
    public void Disconnect()
    {
        _isConnected = false;
        Console.WriteLine($">> {DeviceName} đã ngắt kết nối!");
    }

    // Override Start() - PLC chỉ start được khi đã Connect
    public override bool Start()
    {
        if (!_isConnected)
        {
            Console.WriteLine(">> Lỗi: PLC chưa được kết nối! Hãy Connect trước.");
            return false; // Không cho phép start
        }
        base.Start(); // Gọi Start() của Device
        return true;
    }
}
