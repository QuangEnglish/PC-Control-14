using Project_Final_OOP.Interfaces;

namespace Project_Final_OOP.Models;

// Abstract class Device - Class cha (cơ sở) cho tất cả thiết bị
// "abstract" nghĩa là KHÔNG THỂ tạo đối tượng trực tiếp từ class này
// Chỉ có thể tạo đối tượng từ các class con (Sensor, Motor, PLC)
// Device implement IControllable => phải cài đặt Start(), Stop(), Reset()
public abstract class Device : IControllable
{
    // ===== FIELDS (private) - TÍNH ĐÓNG GÓI =====
    // Các field được đặt private để bảo vệ dữ liệu
    // Bên ngoài KHÔNG thể truy cập trực tiếp, phải qua Property
    private string _deviceId;
    private string _deviceName;
    private string _location;
    private bool _isRunning;
    private DateTime _installDate;

    // ===== PROPERTIES (public) - Cổng truy cập có kiểm soát =====

    // DeviceId: chỉ cho phép ĐỌC (get), không cho SỬA từ bên ngoài
    // => dùng private set: chỉ trong class mới gán được
    public string DeviceId
    {
        get { return _deviceId; }
        private set { _deviceId = value; }
    }

    // DeviceName: có VALIDATION trong setter
    // => nếu tên trống sẽ ném lỗi, đảm bảo dữ liệu luôn hợp lệ
    public string DeviceName
    {
        get { return _deviceName; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Tên thiết bị không được để trống!");
            _deviceName = value;
        }
    }

    // Location: get/set bình thường
    public string Location
    {
        get { return _location; }
        set { _location = value; }
    }

    // IsRunning: chỉ cho phép ĐỌC từ bên ngoài
    // => protected set: class con có thể gán, bên ngoài thì không
    public bool IsRunning
    {
        get { return _isRunning; }
        protected set { _isRunning = value; }
    }

    // InstallDate: get/set bình thường
    public DateTime InstallDate
    {
        get { return _installDate; }
        set { _installDate = value; }
    }

    // ===== CONSTRUCTOR =====
    public Device()
    {
        
    }
    // Nhận 3 tham số, tự động gán ngày lắp đặt và trạng thái ban đầu
    public Device(string deviceId, string deviceName, string location)
    {
        _deviceId = deviceId;
        DeviceName = deviceName; // Dùng Property để chạy qua validation
        _location = location;
        _isRunning = false;        // Mặc định chưa chạy
        _installDate = DateTime.Now; // Tự động lấy ngày hiện tại
    }

    // ===== METHODS =====

    // Abstract method - BẮT BUỘC class con phải override (ghi đè)
    // Không có body {} ở đây vì mỗi loại thiết bị sẽ hiển thị trạng thái khác nhau
    public abstract string GetStatus();

    // Virtual method - Class con CÓ THỂ override hoặc không
    // "virtual" cho phép class con ghi đè nếu muốn bổ sung thông tin
    public virtual string GetInfo()
    {
        return $"ID: {_deviceId}\n" +
               $"    Tên: {_deviceName}\n" +
               $"    Vị trí: {_location}\n" +
               $"    Ngày lắp: {_installDate:dd/MM/yyyy}";
    }

    // Implement Start() từ interface IControllable
    // "virtual" để class con có thể override thêm logic riêng
    public virtual bool Start()
    {
        _isRunning = true;
        return true;
    }

    // Implement Stop() từ interface IControllable
    public virtual bool Stop()
    {
        _isRunning = false;
        return true;
    }

    // Implement Reset() từ interface IControllable
    public void Reset()
    {
        Stop(); // Gọi Stop() trước
        Console.WriteLine($">> {_deviceName} đã được reset!");
    }
}
