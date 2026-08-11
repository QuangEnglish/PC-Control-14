using System.Globalization;
using Lesson_13_BTVN_CuoiKhoa_OOP.Machine;
using Lesson_13_BTVN_CuoiKhoa_OOP.Services;

namespace Lesson_13_BTVN_CuoiKhoa_OOP;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        DeviceManager manager = new DeviceManager();

        //Device device = new Device();
        Sensor sensor = new Sensor(
            "SEN001",
            "Temperature Sensor 1",
            "Production Line 1",
            "Temperature",
            "Đơn vị: °C",
            0.0,
            100.0);
        manager.AddDevice(sensor);

        Motor motor = new Motor(
            "MOTO01",
            "Conveyor Motor 1",
            "Production Line 1",
            5.5,
            1450);
        manager.AddDevice(motor);
        
        PLC plc = new PLC(
            "PLC001",
            "Main PLC",
            "Control Room",
            "Siemens",
            "S7-1200",
            "192.168.1.10");
        manager.AddDevice(plc);
        
        
        // Device managers = new Sensor("","","",
        //     "","",2.2,2.2);
        // manager.AddDevice(managers);
        // managers.GetInfo();

        // dòng 208 chưa hiểu lắm
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine(" INDUSTRIAL DEVICE MANAGEMENT SYSTEM");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Hiển thị tất cả thết bị");
            Console.WriteLine("2. Hiển thị tất cả trang thái thiết bị");
            Console.WriteLine("3. Thêm thiết bị mới");
            Console.WriteLine("4. Tìm kiếm thiết bị theo ID");
            Console.WriteLine("5. Khởi động thiết bị");
            Console.WriteLine("6. Dừng thiết bị");
            Console.WriteLine("7. Khởi động tất cả");
            Console.WriteLine("8. Dừng tất cả");
            Console.WriteLine("9. Đọc giá trị Sensor");
            Console.WriteLine("10. Đặt tốc độ Motor");
            Console.WriteLine("11. Kết nối / Ngắt PLC");
            Console.WriteLine("12. Thoát");
            Console.WriteLine("========================================");
            Console.Write("Chọn chức năng: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ShowAllDevices(manager);
                    break;
                case 2:
                    manager.PrintAllStatus();
                    break;
                case 3:
                    AddDevice(manager);
                    break;
                case 4:
                    FindDevice(manager);
                    break;
                case 5:
                    StartDevice(manager);
                    break;
                case 6:
                    StopDevice(manager);
                    break;
                case 7:
                    manager.StartAllDevices();
                    Console.WriteLine("Da khoi dong tat ca thiet bi.");
                    break;
                case 8:
                    manager.StopAllDevices();
                    Console.WriteLine("Da dung tat ca thiet bi.");
                    break;
                case 9:
                    ReadSensor(manager);
                    break;
                case 10:
                    SetMotorSpeed(manager);
                    break;
                case 11:
                    ConnectDisconnectPLC(manager);
                    break;
                case 12:
                    Console.WriteLine("Da thoat chuong trinh.");
                    return;
                default:
                    Console.WriteLine("Chuc nang khong hop le.");
                    break;

            }

        }

        // Các Hàm sử lý 
        // 1. Hiển thị tất cả thiết bị
        static void ShowAllDevices(DeviceManager manager)
        {
            List<Device> devices = manager.GetAllDevices();

            Console.WriteLine();
            Console.WriteLine("=== DANH SACH THIET BI ===");

            if (devices.Count == 0)
            {
                Console.WriteLine("Chưa có thiết bị");
                return;
            }

            int number = 1;
            foreach (Device device in devices)
            {
                //  Console.WriteLine(device.GetInfo());
                Console.WriteLine();
                if (device is Sensor sensor)
                {
                    Console.WriteLine("[" + number + "] SENSOR - " + sensor.DeviceId);
                    Console.WriteLine("Ten: " + sensor.DeviceName);
                    Console.WriteLine("Vi tri: " + sensor.Location);
                    Console.WriteLine("Loai: " + sensor.SensorType + " | Don vi: " + sensor.Unit);
                    Console.WriteLine("Khoang do: " + sensor.MinValue + " - " + sensor.MaxValue);
                    Console.WriteLine("Ngay lap: " + sensor.InstallDate.ToString("dd/MM/yyyy"));
                }
                else if (device is Motor motor)
                {
                    Console.WriteLine("[" + number + "] MOTOR - " + motor.DeviceId);
                    Console.WriteLine("Ten: " + motor.DeviceName);
                    Console.WriteLine("Vi tri: " + motor.Location);
                    Console.WriteLine("Cong suat: " + motor.RatedPower + " kW | Toc do dinh muc: " + motor.RatedSpeed +
                                      " RPM");
                    Console.WriteLine("Ngay lap: " + motor.InstallDate.ToString("dd/MM/yyyy"));

                }
                else if (device is PLC plc)
                {
                    Console.WriteLine("[" + number + "] PLC - " + plc.DeviceId);
                    Console.WriteLine("Ten: " + plc.DeviceName);
                    Console.WriteLine("Vi tri: " + plc.Location);
                    Console.WriteLine("Hang: " + plc.Brand + " " + plc.Model);
                    Console.WriteLine("IP: " + plc.IpAddress);
                    Console.WriteLine("Ngay lap: " + plc.InstallDate.ToString("dd/MM/yyyy"));
                }

                number++;
            }

            Console.WriteLine();
            Console.WriteLine("Tong: " + devices.Count + " thiet bi");
        }

    }
    
    // 2. Hiển thị trạng thái
    static void ShowAllStatus(DeviceManager manager)
    {
        Console.WriteLine();
        Console.WriteLine("=== TRANG THAI THIET BI ===");

        List<Device> devices = manager.GetAllDevices();

        foreach (Device device in devices)
        {
            Console.WriteLine(
                device.DeviceId + ": " + device.GetStatus());
        }
    }

    #region Methods Thêm thiết bị mới
 
        // 3. Thêm thiết bị mới
        static void AddDevice(DeviceManager manager)
        {
            Console.WriteLine();
            Console.WriteLine("1. Sensor");
            Console.WriteLine("2. Motor");
            Console.WriteLine("3. PLC");
            
            Console.Write("Chon loai thiet bi: ");
            string type = Console.ReadLine();
            
            Console.Write("Device ID: ");
            string deviceId = Console.ReadLine();
            
            Console.Write("Device Name: ");
            string deviceName = Console.ReadLine();
            
            Console.Write("Location: ");
            string location = Console.ReadLine();

            if (type == "1")
            {
                Console.Write("Sensor Type: ");
                string sensorType = Console.ReadLine();
                
                Console.Write("Unit: ");
                string unit = Console.ReadLine();
                
                Console.Write("Min Value: ");
                double minValue = double.Parse(Console.ReadLine());
                
                Console.Write("Max Value: ");
                double maxValue = double.Parse(Console.ReadLine());
                
                Sensor sensor = new Sensor
                    (
                        deviceId, 
                        deviceName,
                        location,
                        sensorType,
                        unit, 
                        minValue,
                        maxValue);
                
                manager.AddDevice(sensor);
                Console.WriteLine("Them Sensor thanh cong.");
                
            } else if (type == "2")
            {
                Console.Write("Rated Power (kW): ");
                double ratedPower = double.Parse(Console.ReadLine());
                
                Console.Write("Rated Speed (RPM): ");
                int ratedSpeed = int.Parse(Console.ReadLine());
                
                Motor motor = new Motor
                    ( 
                        deviceId,
                        deviceName,
                        location, 
                        ratedPower, 
                        ratedSpeed);
                
                manager.AddDevice(motor);
                Console.WriteLine("Them Motor thanh cong.");
                
            } else if (type == "3")
            {
                Console.Write("Brand: ");
                string brand = Console.ReadLine();
                
                Console.Write("Model: ");
                string model = Console.ReadLine(); 
                
                Console.Write("IP Address: ");
                string ipAddress = Console.ReadLine();
                
                PLC plc = new PLC
                    ( 
                        deviceId,
                        deviceName, 
                        location,
                        brand,
                        model,
                        ipAddress);
                
                manager.AddDevice(plc);
                Console.WriteLine("Them PLC thanh cong.");
                
            }
            else
            {
                Console.WriteLine("Loai thiet bi khong hop le.");
            } 
        
        }
        #endregion
        // 4. Tìm kiếm thiết bị theo ID
        static void FindDevice(DeviceManager manager)
        {
            Console.Write("Nhap Device ID: ");
            string id = Console.ReadLine();

            Device device = manager.FindDevice(id);  // chưa hiểu lắm 

            if (device == null)
            {
                Console.WriteLine("Không tìm thấy thiết bị");
            }
            else
            {
                Console.WriteLine(device.GetInfo());
            }
            
        }
        
        // 5.  Khởi động thiết bị
        static void StartDevice(DeviceManager manager)
        {
            Console.Write("Nhap Device ID: ");
            string id = Console.ReadLine();
            
            Device device = manager.FindDevice(id);
            
            if (device == null)
            {
                Console.WriteLine("Không tìm thấy thiết bị");
                return;
            }
            
            bool result = device.Start();
            
            if (!result)
            {
                Console.WriteLine("Không thể khởi động thiết bị");
               // Console.WriteLine("Khởi động thành công");
               return;
            }

            if (device is Motor motor)
            {
                Console.WriteLine( ">> Motor " + motor.DeviceName + " da khoi dong!");
                Console.WriteLine( ">> Toc do hien tai: " + motor.CurrentSpeed + " RPM");
            }
            else
            {
                Console.WriteLine( ">> " + device.DeviceName + " Da khoi dong!");
            }
        }
        
        // 6. Dừng thiết bị
        static void StopDevice(DeviceManager manager)
        {
            Console.Write("Nhap Device ID: ");
            string id = Console.ReadLine();
            
            Device device = manager.FindDevice(id);

            if (device == null)
            {
                Console.WriteLine("Không tìm thấy thiết bị");
                return ;
            }
            
            bool result = device.Stop();

            if (result)
            {
                Console.WriteLine("Đã dừng thiết bị");
            }

        }
        
        // 9. Đọc giá trị Sensor
        static void ReadSensor(DeviceManager manager)
        {
            Console.Write("Nhap Sensor ID: ");
            string id = Console.ReadLine();
            
            Device  device = manager.FindDevice(id);

            if (device == null)
            {
                Console.WriteLine("Không tìm thấy Sensor");
                return ;
            }

            if (device is not Sensor sensor)
            {
                Console.WriteLine("Thiet bi nay khong phai Sensor.");
                return;
            } 
            
            Console.WriteLine("Dang doc gia tri...");
            sensor.ReadValue();
            
            Console.WriteLine( "Gia tri doc duoc: " + sensor.CurrentValue.ToString("F1") + " " + sensor.Unit);

            
            if (sensor.IsAlarm())
            {
                Console.WriteLine("CANH BAO: Gia tri Sensor vuot 80% MaxValue! ");
            }
            else
            {
                Console.WriteLine("Giá trị Sensor bình thường");
            }
        }
        
        // 10. Đặt tốc độ Motor
        static void SetMotorSpeed(DeviceManager manager)
        {
            Console.Write("Nhap Motor ID: "); 
            string id = Console.ReadLine();
            
            Device device = manager.FindDevice(id);

            if (device == null)
            {
                Console.WriteLine("Khong tim thay thiet bi.");
                return;
            } 
            
            Motor motor = device as Motor;

            if (motor == null)
            {
                Console.WriteLine("Thiet bi nay khong phai Motor.");
                return;
            } 
            
            Console.Write("Nhap toc do moi: "); 
            int speed = int.Parse(Console.ReadLine());

            try
            {
                motor.SetSpeed(speed);
                Console.WriteLine("Dat toc do thanh cong.");
                Console.WriteLine(motor.GetStatus());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        // 11. Connect / Disconnect PLC
        static void ConnectDisconnectPLC(DeviceManager manager)
        {
            Console.Write("Nhap PLC ID: ");
            string id = Console.ReadLine();
            
            Device device = manager.FindDevice(id);

            if (device == null)
            {
                Console.WriteLine("Khong tim thay thiet bi.");
                return;
            } 
            
            PLC plc = device as PLC;

            if (plc == null)
            {
                Console.WriteLine("Thiet bi nay khong phai PLC.");
                return;
            } 
            Console.WriteLine("1. Connect");
            Console.WriteLine("2. Disconnect");
            Console.Write("Chon: ");
            
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                plc.Connect();
            } 
            else if (choice == "2")
            {
                plc.Disconnect();
            }
            else
            {
                Console.WriteLine("Lua chon khong hop le.");
            }
        }
}

      
