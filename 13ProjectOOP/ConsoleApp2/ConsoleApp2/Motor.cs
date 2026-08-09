namespace ConsoleApp2;

public class Motor:Device
{
    #region Fileds & Properties

    private double _ratedPower;
    private int _ratedSpeed;
    private int _currentSpeed;

    public int CurrentSpeed
    {
        get => _currentSpeed;
        set
        {
            if (value >= 0 && value <= 1.2 * RatedSpeed) _currentSpeed = value;
            else throw new Exception("CurrentSpeed out spec");
        }
    }

    public int RatedSpeed
    {
        get => _ratedSpeed;
        set => _ratedSpeed = value;
    }

    public double RatedPower
    {
        get => _ratedPower;
        set => _ratedPower = value;
    }

    #endregion

    #region Constructor

    public Motor(string deviceId, string deviceName, string location, double ratedPower, int ratedSpeed)
        : base(deviceId, deviceName, location)
    {
        RatedPower = ratedPower;
        RatedSpeed = ratedSpeed;
        CurrentSpeed = 0;
    }

    #endregion

    #region Method

    public override string GetStatus()
    {
    //Trả về "Motor [name]: currentSpeed/ratedSpeed RPM (Running/Stopped)
        string sRun = IsRunning ? "Running" : "Stopped";
        return $"{DeviceId}: Motor {DeviceName}: {_currentSpeed}/{_ratedSpeed} RPM {sRun}";
    }

    public override string GetInfo()
    {
        return base.GetInfo() +
               $"\t Công suất: {_ratedPower} | Tốc độ định mức: {_ratedSpeed} RPM\n" +
               $"\t Ngày lắp: {InstallDate}\n";
    }

    public override bool Start()
    {
        CurrentSpeed = RatedSpeed;
        Console.WriteLine(">> "+DeviceName+" đã khởi động!");
        Console.WriteLine($"Tốc độ hiện tại: {_currentSpeed}");
        return base.Start();
    }
    public override bool Stop()
    {
        CurrentSpeed = 0;
        return base.Start();
    }

    public void SetSpeed(int speed)
    {
        CurrentSpeed = speed;
    }


    #endregion

}