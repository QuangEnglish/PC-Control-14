using Project_Final_OOP.Models;

namespace Project_Final_OOP.Services;

// Class DeviceManager - Quản lý danh sách tất cả thiết bị
// Class này KHÔNG kế thừa từ Device, nó chỉ CHỨA một danh sách Device
// Đây là quan hệ "HAS-A" (có một), khác với kế thừa "IS-A" (là một)
public class DeviceManager
{
    // Danh sách thiết bị - dùng List<Device> (class cha)
    // Nhờ TÍNH ĐA HÌNH, List<Device> có thể chứa Sensor, Motor, PLC
    private List<Device> _devices;

    public DeviceManager()
    {
        _devices = new List<Device>();
    }

    // Thêm thiết bị vào danh sách
    public void AddDevice(Device device)
    {
        _devices.Add(device);
        Console.WriteLine($">> Đã thêm thiết bị: {device.DeviceName} ({device.DeviceId})");
    }

    // Xóa thiết bị theo ID
    public bool RemoveDevice(string deviceId)
    {
        Device? device = FindDevice(deviceId);
        if (device != null)
        {
            _devices.Remove(device);
            Console.WriteLine($">> Đã xóa thiết bị: {device.DeviceName}");
            return true;
        }
        Console.WriteLine($">> Không tìm thấy thiết bị có ID: {deviceId}");
        return false;
    }

    // Tìm thiết bị theo ID - trả về Device hoặc null
    public Device? FindDevice(string deviceId)
    {
        foreach (Device device in _devices)
        {
            if (device.DeviceId == deviceId)
                return device;
        }
        return null;
    }

    // Trả về danh sách tất cả thiết bị
    public List<Device> GetAllDevices()
    {
        return _devices;
    }

    // Trả về danh sách thiết bị theo loại - dùng GENERIC <T>
    // Ví dụ: GetDevicesByType<Sensor>() => trả về tất cả Sensor
    // "where T : Device" ràng buộc T phải là Device hoặc class con của Device
    public List<T> GetDevicesByType<T>() where T : Device
    {
        List<T> result = new List<T>();
        foreach (Device device in _devices)
        {
            // "is T" kiểm tra xem device có phải kiểu T không
            if (device is T typedDevice)
                result.Add(typedDevice);
        }
        return result;
    }

    // Khởi động tất cả thiết bị
    public void StartAllDevices()
    {
        Console.WriteLine(">> Đang khởi động tất cả thiết bị...");
        foreach (Device device in _devices)
        {
            bool success = device.Start(); // ĐA HÌNH: mỗi loại chạy Start() riêng
            if (success)
                Console.WriteLine($"   + {device.DeviceName}: Đã khởi động");
            else
                Console.WriteLine($"   - {device.DeviceName}: Khởi động thất bại");
        }
    }

    // Dừng tất cả thiết bị
    public void StopAllDevices()
    {
        Console.WriteLine(">> Đang dừng tất cả thiết bị...");
        foreach (Device device in _devices)
        {
            device.Stop(); // ĐA HÌNH: mỗi loại chạy Stop() riêng
            Console.WriteLine($"   + {device.DeviceName}: Đã dừng");
        }
    }

    // In trạng thái tất cả thiết bị - MINH HỌA TÍNH ĐA HÌNH
    // Cùng gọi GetStatus() nhưng mỗi loại thiết bị hiển thị khác nhau
    public void PrintAllStatus()
    {
        Console.WriteLine("\n=== TRẠNG THÁI THIẾT BỊ ===\n");
        foreach (Device device in _devices)
        {
            // ĐA HÌNH ở đây:
            // - Nếu device là Sensor => gọi Sensor.GetStatus()
            // - Nếu device là Motor  => gọi Motor.GetStatus()
            // - Nếu device là PLC    => gọi PLC.GetStatus()
            Console.WriteLine($"{device.DeviceId}: {device.GetStatus()}");
        }
    }
}
