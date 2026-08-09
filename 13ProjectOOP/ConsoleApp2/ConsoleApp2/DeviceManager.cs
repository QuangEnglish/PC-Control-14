namespace ConsoleApp2;

public class DeviceManager
{
    #region Fields & Properties

    private List<Device> _devices;

    #endregion

    #region Constructor

    public DeviceManager()
    {
        _devices = new List<Device>();
    }

    #endregion
    #region Methods

    /*Yêu cầu về Methods:
    AddDevice(Device device) : Thêm thiết bị vào danh sách
        RemoveDevice(string deviceId) : Xóa thiết bị theo ID
        FindDevice(string deviceId) : Tìm thiết bị theo ID, trả về Device hoặc null
    GetAllDevices() : Trả về danh sách tất cả thiết bị
        GetDevicesByType<T>() : Trả về danh sách thiết bị theo loại (dùng Generic)
    StartAllDevices() : Khởi động tất cả thiết bị
        StopAllDevices() : Dừng tất cả thiết bị
        PrintAllStatus() : In trạng thái tất cả thiết bị (dùng Polymorphism - gọi GetStatus())*/
    public Device FindDevice(string deviceId)
    {
        foreach (var device in _devices)
        {
            if (device.DeviceId == deviceId)
            {
                return device;
                break;
            }
        }

        return null;
    }
    public void GetAllDevice()
    {
        Console.WriteLine("=============  DANH SÁCH THIẾT BỊ  ============");
        for (int i = 0; i < _devices.Count; i++)
        {
            string nameDevice = _devices[i].GetType().Name;
            Console.WriteLine($"[{i}]\t {nameDevice} - " + _devices[i].GetInfo());
        }
        Console.WriteLine($"Tổng: {_devices.Count} thiết bị");
    }

    public void PrintAllStatus()
    {
        Console.WriteLine("=============  TRẠNG THÁI THẾT BỊ  ============");
        for (int i = 0; i < _devices.Count; i++)
        {
            Console.WriteLine(_devices[i].GetStatus());
        }
        
    }
    public void AddDevice(Device device)
    {
           _devices.Add(device);
    }

    public void StartAllDevices()
    {
        foreach (var device in _devices)
        {
            device.Start();
        }
    }

    public void StopAllDevices()
    {
        foreach (var device in _devices)
        {
            device.Stop();
        }
    }

    #endregion
}