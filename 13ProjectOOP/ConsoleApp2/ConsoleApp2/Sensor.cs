namespace ConsoleApp2;

public class Sensor:Device
{
    #region Fields & Properties
    private string _sensorType;
    private double _currentValue;
    private string _unit;
    private double _minValue;
    private double _maxValue;

    public string SensorType
    {
        get => _sensorType;
        set => _sensorType = value;
    }

    public double CurrentValue
    {
        get => _currentValue;
        set
        {
            if (value >= MinValue && value <= MaxValue) _currentValue = value;
            else throw new Exception("Validation");
        }
    }

    public string Unit
    {
        get => _unit;
        set => _unit = value;
    }

    public double MinValue
    {
        get => _minValue;
        set => _minValue = value;
    }

    public double MaxValue
    {
        get => _maxValue;
        set => _maxValue = value;
    }
    #endregion

    #region Constructor

    public Sensor(string deviceId, string deviceName, string location, string sensorType, string unit, double minValue, double maxValue) :
        base(deviceId, deviceName,location)
    {
        SensorType = sensorType;
        Unit = unit;
        MinValue = minValue;
        MaxValue = maxValue;
        CurrentValue = 0;
    }
    
    #endregion

    #region Method

    public override string GetStatus()
    {
        /*Trả về chuỗi dạng "[SensorType] Value: currentValue unit
            (Running/Stopped)"*/
        string sRun = IsRunning ? "Running" : "Stopped";
        return $"{DeviceId}: [{_sensorType}] Value: {_currentValue} {_unit} {sRun}";
    }

    public override string GetInfo()
    {
        return base.GetInfo() +
               $"\t Loại: {_sensorType} | Đơn vị: {_unit}\n" +
               $"\t Khoảng đo: {_minValue} - {_maxValue}\n" +
               $"\t Ngày lắp: {InstallDate}\n";
    }
    public double ReadValue()
    {
        //Giả lập đọc giá trị ngẫu nhiên trong khoảng [MinValue, MaxValue]
        Random rand = new Random();
        return Math.Round(rand.NextDouble() * (_maxValue - _minValue),2);
    }

    public bool IsAlarm()
    {
        return _currentValue > 0.8 * _maxValue;
    }

    #endregion
}