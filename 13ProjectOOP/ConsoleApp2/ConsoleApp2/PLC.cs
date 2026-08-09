namespace ConsoleApp2;

public class PLC:Device
{
    #region Fields & Properties

    private string _brand;
    private string _model;
    private string _ipAdress;
    private bool _isConnected;

    public string Brand
    {
        get => _brand;
        set => _brand = value;
    }

    public string Model
    {
        get => _model;
        set => _model = value;
    }

    public string IpAdress
    {
        get => _ipAdress;
        set
        {
            //kieemr tra 3 dau cham
            _ipAdress = value;
        }
    }

    #endregion

    #region Constructor

    public PLC(string deviceId, string deviceName, string location, string brand, string model, string ipAdress)
        : base(deviceId, deviceName, location)
    {
        Brand = brand;
        Model = model;
        IpAdress = ipAdress;
        _isConnected = false;
    }

    #endregion

    #region Methods

    public override string GetStatus()
    {
        /*Trả về "PLC [brand model]: Connected/Disconnected -
        Running/Stopped*/
        string sConnect = _isConnected ? "Connected" : "Disconnected";
        string sRun = IsRunning ? "Running" : "Stopped";
        return $"{DeviceId}: PLC [{_brand}] {sConnect} {sRun}";
        
    }

    public override string GetInfo()
    {
        return base.GetInfo() +
               $"\t Hãng {_brand} - {_model}\n" +
               $"\t IP: {_ipAdress}\n" +
               $"\t Ngày lắp: {InstallDate}\n";;      
    }

    public void Connect()
    {
        _isConnected = true;
        Console.WriteLine("Connected");
    }
    public void Disconnect()
    {
        _isConnected = false;
        Console.WriteLine("Disconnected");
    }

    public override bool Start()
    {
        if (_isConnected)
        {
            Console.WriteLine(">> "+DeviceName+" đã khởi động!");
            return base.Start();
        }
        else
        {
            return false;
        }
    }

    #endregion
}