namespace ConsoleApp2;

public abstract class Device:IControllable
{
    
    #region  Fields & Properties

    private readonly string _deviceId;
    private string _deviceName;
    private string _location;
    private bool _isRunning;
    private DateTime _installDate;

    public string DeviceId
    {
        get { return _deviceId; }
    }

    public string DeviceName
    {
        get { return _deviceName;}
        set { _deviceName = value ?? throw new Exception(nameof(value)); }
    }

    public string Location
    {
        get { return _location;}
        set
        {
            _location = value;
        } 
    }

    public bool IsRunning
    {
        get { return _isRunning; }
    }

    public DateTime InstallDate
    {
        get { return _installDate; }
        set { _installDate = value; }
    }
    #endregion

    #region  Constructor
    public Device(string deviceId, string deviceName, string location)
    {
        _deviceId = deviceId;
        DeviceName = deviceName;
        Location = location;
        InstallDate = DateTime.Now;
        _isRunning = false;
    }
    #endregion

    #region  Methods

    public abstract string GetStatus();

    public virtual string GetInfo()
    {
        string infor = $"{_deviceId}\n" +
                       $"\t Tên: {_deviceName}\n" +
                       $"\t Vị trí: {_location}\n";
        return infor;
    }
    public virtual bool Start()
    {
        _isRunning = true;
        return true;
    }

    public virtual bool Stop()
    {
        _isRunning = false;
        return true;
    }

    public void Reset()
    {
        Stop();
        Console.WriteLine("Device reset");
    }

    #endregion


}