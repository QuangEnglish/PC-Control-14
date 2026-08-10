namespace Project_Final_OOP.Models;

// Class Sensor - Kế thừa từ Device
// Đại diện cho các loại cảm biến (nhiệt độ, áp suất, lưu lượng...)
// Kế thừa = "là một loại" (Sensor LÀ MỘT Device)
public class Sensor : Device
{
    // ===== FIELDS riêng của Sensor (private) =====
    private string _sensorType;   // Loại cảm biến: Temperature, Pressure, Flow...
    private double _currentValue; // Giá trị đang đo được
    private string _unit;         // Đơn vị: °C, bar, m³/h...
    private double _minValue;     // Giá trị tối thiểu
    private double _maxValue;     // Giá trị tối đa

    // ===== PROPERTIES =====
    public string SensorType
    {
        get { return _sensorType; }
        set { _sensorType = value; }
    }

    // CurrentValue có VALIDATION: giá trị phải nằm trong [MinValue, MaxValue]
    public double CurrentValue
    {
        get { return _currentValue; }
        set
        {
            if (value < _minValue || value > _maxValue)
                throw new ArgumentException(
                    $"Giá trị phải nằm trong khoảng [{_minValue} - {_maxValue}]!");
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

    // ===== CONSTRUCTOR =====
    // Gọi constructor cha bằng "base(deviceId, deviceName, location)"
    // Sau đó gán các field riêng của Sensor
    public Sensor() : base()
    {
        
    }
    public Sensor(string deviceId, string deviceName, string location,
                  string sensorType, string unit, double minValue, double maxValue)
        : base(deviceId, deviceName, location) // Gọi constructor Device
    {
        _sensorType = sensorType;
        _unit = unit;
        _minValue = minValue;
        _maxValue = maxValue;
        _currentValue = 0; // Mặc định giá trị ban đầu = 0
    }

    // ===== METHODS =====

    // Override GetStatus() - BẮT BUỘC vì là abstract ở class cha
    // TÍNH ĐA HÌNH: Cùng method GetStatus() nhưng Sensor hiển thị khác Motor, PLC
    public override string GetStatus()
    {
        string status = IsRunning ? "Running" : "Stopped";
        return $"[{_sensorType}] Value: {_currentValue} {_unit} ({status})";
    }

    // Override GetInfo() - Gọi base.GetInfo() để lấy thông tin chung,
    // rồi thêm thông tin riêng của Sensor
    public override string GetInfo()
    {
        return base.GetInfo() + "\n" +
               $"    Loại: {_sensorType} | Đơn vị: {_unit}\n" +
               $"    Khoảng đo: {_minValue} - {_maxValue}";
    }

    // Giả lập đọc giá trị ngẫu nhiên trong khoảng [MinValue, MaxValue]
    public double ReadValue()
    {
        Random random = new Random();
        // NextDouble() trả về số từ 0.0 đến 1.0
        // Nhân với (max - min) rồi cộng min => giá trị trong khoảng [min, max]
        _currentValue = Math.Round(_minValue + random.NextDouble() * (_maxValue - _minValue), 1);
        return _currentValue;
    }

    // Kiểm tra cảnh báo: true nếu giá trị vượt 80% của MaxValue
    public bool IsAlarm()
    {
        return _currentValue > (_maxValue * 0.8);
    }
}
