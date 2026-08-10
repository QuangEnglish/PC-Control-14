using Lesson_13_BTVN_CuoiKhoa_OOP.Machine;

namespace Lesson_13_BTVN_CuoiKhoa_OOP.Services;

public class DeviceManager
{
    /*
    #region Xử lý theo cách thông thường không dùng LINQ

   private List<Device> _devices;
    // - Danh sách thiết bị
    
    // Contructor
    public DeviceManager()
    {
        _devices = new List<Device>();
    }
    
    // Các Methods
    
    // Thêm thiết bị vào danh sách
    public void AddDevice(Device device)
    {
        _devices.Add(device);
    }
    
     //Tìm thiết bị theo ID, trả về Device hoặc null
    public Device FindDevice(string deviceId)
    {
        foreach (Device device in _devices)
        {
            if (device.DeviceId == deviceId)
            {
                return device;
            }
        }

        return null;
    }
    // Xóa thiết bị theo ID
    public bool RemoveDevice(string deviced)
    {
        Device device = FindDevice(deviced);
        
        if (device == null)
        {
            return false;
        }
        
        _devices.Remove(device);
        return true;

    }
    
    // Trả về danh sách tất cả thiết bị
    public List<Device> GetDevices()
    {
        return _devices;
    }
    
    // Trả về danh sách thiết bị theo loại (dùng Generic)
    public List<T> GetDevicesByType<T>() where T : Device
    {
        List<T> result = new List<T>();
        foreach (Device device in result)
        {
            if (device is T)
            { 
                result.Add((T)device);
            }
        }
        return result;
    }

    // Khởi tạo tất cả thiết bị
    public void StartAllDevices()
    {
        foreach (Device device in _devices)
        {
            device.Start();
        }
    }
    
    //  Dừng tất cả thiết bị
    public void StopAllDevices()
    {
        foreach (Device device in _devices)
        {
            device.Stop();
        }
    }
    
    //  In trạng thái tất cả thiết bị (dùng Polymorphism - gọi GetStatus())
    public void PrintAllStatus()
    {
        foreach (Device device in _devices)
        {
            
            Console.WriteLine(device.GetStatus());
        }
    }
    #endregion
    */

    #region Dùng LINQ

    private List<Device> _devices;

    public DeviceManager()
    {
        _devices = new List<Device>();
    }

    // Thêm thiết bị
    public void AddDevice(Device device)
    {
        _devices.Add(device);
    }

    // Xóa thiết bị theo ID
    public bool RemoveDevice(string deviceId)
    {
        Device device = _devices.FirstOrDefault(d => d.DeviceId == deviceId);

        if (device == null)
        {
            return false;
        }

        _devices.Remove(device);
        return true;
    }

    // Tìm thiết bị theo ID
    public Device FindDevice(string deviceId)
    {
        return _devices.FirstOrDefault(d => d.DeviceId == deviceId);
    }

    // Lấy tất cả thiết bị
    public List<Device> GetAllDevices()
    {
        return _devices;
    }

    // Lấy thiết bị theo loại - Generic + LINQ
    public List<T> GetDevicesByType<T>() where T : Device
    {
        return _devices.OfType<T>().ToList();
    }

    // Khởi động tất cả thiết bị
    public void StartAllDevices()
    {
        _devices.ForEach(device => device.Start());
    }

    // Dừng tất cả thiết bị
    public void StopAllDevices()
    {
        _devices.ForEach(device => device.Stop());
    }

    // In trạng thái tất cả thiết bị
    public void PrintAllStatus()
    {
        _devices.ForEach(device =>
            Console.WriteLine(device.GetStatus()));
    }

    #endregion
}