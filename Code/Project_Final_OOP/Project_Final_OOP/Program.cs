using Project_Final_OOP.Models;
using Project_Final_OOP.Services;

namespace Project_Final_OOP;

class Program
{
    static void Main(string[] args)
    { 
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        //Device deviceV1 = new Device("vv", "vv", "vv");
        Sensor sensorV1 = new Sensor();
        // Tạo DeviceManager để quản lý tất cả thiết bị
        DeviceManager manager = new DeviceManager();

        // Tạo sẵn một số thiết bị mẫu
        CreateSampleDevices(manager);

        // Vòng lặp menu chính
        bool running = true;
        while (running)
        {
            ShowMenu();
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowAllDevices(manager);
                    break;
                case "2":
                    manager.PrintAllStatus();
                    break;
                case "3":
                    AddNewDevice(manager);
                    break;
                case "4":
                    SearchDevice(manager);
                    break;
                case "5":
                    StartDevice(manager);
                    break;
                case "6":
                    StopDevice(manager);
                    break;
                case "7":
                    manager.StartAllDevices();
                    break;
                case "8":
                    manager.StopAllDevices();
                    break;
                case "9":
                    ReadSensorValue(manager);
                    break;
                case "10":
                    SetMotorSpeed(manager);
                    break;
                case "11":
                    TogglePLCConnection(manager);
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("\n>> Tạm biệt! Hẹn gặp lại.");
                    break;
                default:
                    Console.WriteLine("\n>> Lựa chọn không hợp lệ! Vui lòng chọn lại.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
            }
        }
    }

    // Hiển thị menu
    static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("   INDUSTRIAL DEVICE MANAGEMENT SYSTEM");
        Console.WriteLine("========================================");
        Console.WriteLine("1. Hiển thị tất cả thiết bị");
        Console.WriteLine("2. Hiển thị trạng thái thiết bị");
        Console.WriteLine("3. Thêm thiết bị mới");
        Console.WriteLine("4. Tìm kiếm thiết bị theo ID");
        Console.WriteLine("5. Khởi động thiết bị");
        Console.WriteLine("6. Dừng thiết bị");
        Console.WriteLine("7. Khởi động tất cả");
        Console.WriteLine("8. Dừng tất cả");
        Console.WriteLine("9. Đọc giá trị Sensor");
        Console.WriteLine("10. Đặt tốc độ Motor");
        Console.WriteLine("11. Kết nối/Ngắt PLC");
        Console.WriteLine("0. Thoát");
        Console.WriteLine("========================================");
        Console.Write("Chọn chức năng: ");
    }

    // Tạo thiết bị mẫu ban đầu
    static void CreateSampleDevices(DeviceManager manager)
    {
        // Tạo Sensor
        Sensor sensor1 = new Sensor("SEN001", "Temperature Sensor 1", "Production Line 1",
                                     "Temperature", "°C", 0, 100);
        Sensor sensor2 = new Sensor("SEN002", "Pressure Sensor 1", "Production Line 2",
                                     "Pressure", "bar", 0, 10);

        // Tạo Motor
        Motor motor1 = new Motor("MOT001", "Conveyor Motor 1", "Production Line 1", 5.5, 1450);
        Motor motor2 = new Motor("MOT002", "Pump Motor 1", "Utility Room", 3.0, 2900);

        // Tạo PLC
        PLC plc1 = new PLC("PLC001", "Main PLC", "Control Room",
                            "Siemens", "S7-1200", "192.168.1.10");

        // Thêm vào manager - ĐA HÌNH: tất cả đều là Device
        manager.AddDevice(sensor1);
        manager.AddDevice(sensor2);
        manager.AddDevice(motor1);
        manager.AddDevice(motor2);
        manager.AddDevice(plc1);
    }

    // Chức năng 1: Hiển thị tất cả thiết bị
    static void ShowAllDevices(DeviceManager manager)
    {
        List<Device> devices = manager.GetAllDevices();
        Console.WriteLine("\n=== DANH SÁCH THIẾT BỊ ===\n");

        for (int i = 0; i < devices.Count; i++)
        {
            Device device = devices[i];
            // Xác định loại thiết bị bằng pattern matching
            string type = device switch
            {
                Sensor => "SENSOR",
                Motor => "MOTOR",
                PLC => "PLC",
                _ => "DEVICE"
            };

            Console.WriteLine($"[{i + 1}] {type} - {device.DeviceId}");
            // ĐA HÌNH: GetInfo() cho kết quả khác nhau tùy loại thiết bị
            Console.WriteLine($"    {device.GetInfo()}");
            Console.WriteLine();
        }

        Console.WriteLine($"Tổng: {devices.Count} thiết bị");
    }

    // Chức năng 3: Thêm thiết bị mới
    static void AddNewDevice(DeviceManager manager)
    {
        Console.WriteLine("\n=== THÊM THIẾT BỊ MỚI ===");
        Console.WriteLine("Chọn loại thiết bị:");
        Console.WriteLine("1. Sensor");
        Console.WriteLine("2. Motor");
        Console.WriteLine("3. PLC");
        Console.Write("Lựa chọn: ");
        string? type = Console.ReadLine();

        try
        {
            Console.Write("Nhập ID thiết bị: ");
            string id = Console.ReadLine() ?? "";
            Console.Write("Nhập tên thiết bị: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Nhập vị trí: ");
            string location = Console.ReadLine() ?? "";

            switch (type)
            {
                case "1":
                    Console.Write("Loại sensor (Temperature/Pressure/Flow): ");
                    string sensorType = Console.ReadLine() ?? "";
                    Console.Write("Đơn vị (°C/bar/m³/h): ");
                    string unit = Console.ReadLine() ?? "";
                    Console.Write("Giá trị tối thiểu: ");
                    double minVal = double.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Giá trị tối đa: ");
                    double maxVal = double.Parse(Console.ReadLine() ?? "100");
                    manager.AddDevice(new Sensor(id, name, location, sensorType, unit, minVal, maxVal));
                    break;

                case "2":
                    Console.Write("Công suất (kW): ");
                    double power = double.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Tốc độ định mức (RPM): ");
                    int speed = int.Parse(Console.ReadLine() ?? "0");
                    manager.AddDevice(new Motor(id, name, location, power, speed));
                    break;

                case "3":
                    Console.Write("Hãng sản xuất: ");
                    string brand = Console.ReadLine() ?? "";
                    Console.Write("Model: ");
                    string model = Console.ReadLine() ?? "";
                    Console.Write("Địa chỉ IP: ");
                    string ip = Console.ReadLine() ?? "";
                    manager.AddDevice(new PLC(id, name, location, brand, model, ip));
                    break;

                default:
                    Console.WriteLine(">> Loại thiết bị không hợp lệ!");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($">> Lỗi: {ex.Message}");
        }
    }

    // Chức năng 4: Tìm kiếm thiết bị
    static void SearchDevice(DeviceManager manager)
    {
        Console.Write("\nNhập ID thiết bị cần tìm: ");
        string id = Console.ReadLine() ?? "";
        Device? device = manager.FindDevice(id);

        if (device != null)
        {
            Console.WriteLine("\n>> Tìm thấy thiết bị:");
            Console.WriteLine($"    {device.GetInfo()}");
            Console.WriteLine($"    Trạng thái: {device.GetStatus()}");
        }
        else
        {
            Console.WriteLine($">> Không tìm thấy thiết bị có ID: {id}");
        }
    }

    // Chức năng 5: Khởi động thiết bị
    static void StartDevice(DeviceManager manager)
    {
        Console.Write("\nNhập ID thiết bị: ");
        string id = Console.ReadLine() ?? "";
        Device? device = manager.FindDevice(id);

        if (device != null)
        {
            bool success = device.Start(); // ĐA HÌNH
            if (success)
            {
                Console.WriteLine($">> {device.DeviceName} đã khởi động!");
                if (device is Motor motor)
                    Console.WriteLine($">> Tốc độ hiện tại: {motor.CurrentSpeed} RPM");
            }
        }
        else
        {
            Console.WriteLine($">> Không tìm thấy thiết bị có ID: {id}");
        }
    }

    // Chức năng 6: Dừng thiết bị
    static void StopDevice(DeviceManager manager)
    {
        Console.Write("\nNhập ID thiết bị: ");
        string id = Console.ReadLine() ?? "";
        Device? device = manager.FindDevice(id);

        if (device != null)
        {
            device.Stop(); // ĐA HÌNH
            Console.WriteLine($">> {device.DeviceName} đã dừng!");
        }
        else
        {
            Console.WriteLine($">> Không tìm thấy thiết bị có ID: {id}");
        }
    }

    // Chức năng 9: Đọc giá trị Sensor
    static void ReadSensorValue(DeviceManager manager)
    {
        Console.Write("\nNhập ID Sensor: ");
        string id = Console.ReadLine() ?? "";
        Device? device = manager.FindDevice(id);

        if (device is Sensor sensor) // Ép kiểu an toàn bằng "is"
        {
            Console.WriteLine(">> Đang đọc giá trị...");
            double value = sensor.ReadValue();
            Console.WriteLine($">> Giá trị đọc được: {value} {sensor.Unit}");

            if (sensor.IsAlarm())
                Console.WriteLine(">> Trạng thái: CẢNH BÁO! Giá trị vượt ngưỡng!");
            else
                Console.WriteLine(">> Trạng thái: Bình thường");
        }
        else if (device == null)
        {
            Console.WriteLine($">> Không tìm thấy thiết bị có ID: {id}");
        }
        else
        {
            Console.WriteLine(">> Thiết bị này không phải là Sensor!");
        }
    }

    // Chức năng 10: Đặt tốc độ Motor
    static void SetMotorSpeed(DeviceManager manager)
    {
        Console.Write("\nNhập ID Motor: ");
        string id = Console.ReadLine() ?? "";
        Device? device = manager.FindDevice(id);

        if (device is Motor motor)
        {
            Console.Write("Nhập tốc độ mới (RPM): ");
            try
            {
                int speed = int.Parse(Console.ReadLine() ?? "0");
                motor.SetSpeed(speed);
            }
            catch (Exception ex)
            {
                Console.WriteLine($">> Lỗi: {ex.Message}");
            }
        }
        else if (device == null)
        {
            Console.WriteLine($">> Không tìm thấy thiết bị có ID: {id}");
        }
        else
        {
            Console.WriteLine(">> Thiết bị này không phải là Motor!");
        }
    }

    // Chức năng 11: Kết nối/Ngắt PLC
    static void TogglePLCConnection(DeviceManager manager)
    {
        Console.Write("\nNhập ID PLC: ");
        string id = Console.ReadLine() ?? "";
        Device? device = manager.FindDevice(id);

        if (device is PLC plc)
        {
            if (plc.IsConnected)
            {
                plc.Disconnect();
            }
            else
            {
                plc.Connect();
            }
        }
        else if (device == null)
        {
            Console.WriteLine($">> Không tìm thấy thiết bị có ID: {id}");
        }
        else
        {
            Console.WriteLine(">> Thiết bị này không phải là PLC!");
        }
    }
}
