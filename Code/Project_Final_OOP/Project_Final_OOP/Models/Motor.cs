namespace Project_Final_OOP.Models;

// Class Motor - Kế thừa từ Device
// Đại diện cho động cơ, bơm, quạt...
public class Motor : Device
{
    // ===== FIELDS riêng của Motor (private) =====
    private double _ratedPower;   // Công suất định mức (kW)
    private int _ratedSpeed;      // Tốc độ định mức (RPM)
    private int _currentSpeed;    // Tốc độ hiện tại (RPM)

    // ===== PROPERTIES =====
    public double RatedPower
    {
        get { return _ratedPower; }
        set { _ratedPower = value; }
    }

    public int RatedSpeed
    {
        get { return _ratedSpeed; }
        set { _ratedSpeed = value; }
    }

    // CurrentSpeed có VALIDATION:
    // - Không được âm
    // - Không vượt quá 120% tốc độ định mức (bảo vệ motor)
    public int CurrentSpeed
    {
        get { return _currentSpeed; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Tốc độ không được âm!");
            if (value > _ratedSpeed * 1.2)
                throw new ArgumentException(
                    $"Tốc độ không được vượt quá 120% định mức ({_ratedSpeed * 1.2} RPM)!");
            _currentSpeed = value;
        }
    }

    // ===== CONSTRUCTOR =====
    public Motor(string deviceId, string deviceName, string location,
                 double ratedPower, int ratedSpeed)
        : base(deviceId, deviceName, location) // Gọi constructor Device
    {
        _ratedPower = ratedPower;
        _ratedSpeed = ratedSpeed;
        _currentSpeed = 0; // Mặc định motor chưa quay
    }

    // ===== METHODS =====

    // Override GetStatus() - Hiển thị trạng thái riêng của Motor
    public override string GetStatus()
    {
        string status = IsRunning ? "Running" : "Stopped";
        return $"Motor {DeviceName}: {_currentSpeed}/{_ratedSpeed} RPM ({status})";
    }

    // Override GetInfo() - Thêm thông tin công suất và tốc độ
    public override string GetInfo()
    {
        return base.GetInfo() + "\n" +
               $"    Công suất: {_ratedPower} kW | Tốc độ định mức: {_ratedSpeed} RPM";
    }

    // Override Start() - Gọi base.Start() + tự động set tốc độ = tốc độ định mức
    public override bool Start()
    {
        base.Start(); // Gọi Start() của Device => set IsRunning = true
        CurrentSpeed = _ratedSpeed; // Motor chạy ở tốc độ định mức
        return true;
    }

    // Override Stop() - Gọi base.Stop() + set tốc độ = 0
    public override bool Stop()
    {
        base.Stop(); // Gọi Stop() của Device => set IsRunning = false
        _currentSpeed = 0; // Motor dừng => tốc độ = 0
        return true;
    }

    // Đặt tốc độ cho motor (có validation qua Property)
    public void SetSpeed(int speed)
    {
        if (!IsRunning)
        {
            Console.WriteLine(">> Motor chưa khởi động! Hãy Start trước.");
            return;
        }
        CurrentSpeed = speed; // Gán qua Property để chạy validation
        Console.WriteLine($">> Đã đặt tốc độ: {_currentSpeed} RPM");
    }
}
