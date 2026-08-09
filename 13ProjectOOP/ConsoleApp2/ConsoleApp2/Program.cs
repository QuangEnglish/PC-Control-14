using System.Text;
using System.Xml;

namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        DeviceManager deviceManager = new DeviceManager();
        while (true)
        {
            Console.WriteLine("Chọn chức năng: ");
            int chucNang = Convert.ToInt32(Console.ReadLine());
            switch (chucNang)
            {
                case 1://Hiển thị tất cả thiết bị
                    HienThiTatCaThietBi();
                    break;
                case 2://Hiển thị trạng thái thiết bị
                    HienThiTrangThaiThietBi();
                    break;
                case 3://Thêm thiết bị mới
                    AddDevice();
                    break;
                case 4://Tìm kiếm thiết bị theo ID
                    TimKiemThietBiTheoId();
                    break;
                case 5: //Khởi động thiết bị
                    KhoiDongThietBi();
                    break;
                case 6: //Dung thiet bi
                    DungThietBi();
                    break;
                case 7://Khởi động tất cả
                    KhoiDongTatCa();
                    break;
                case 8://Dung tất cả
                    DungTatCa();
                    break;
                case 9:// Đọc giá trị sensor
                    DocGiaTriSensor();
                    break;
                case 10: //Đặt tốc độ Motor
                    DatTocDoMotor();
                    break;
                case 11: //Kết nối, Ngắt PLC
                    KetNoiPLC();
                    break;
                case 0:
                    return;
            }
        }

        void KetNoiPLC()
        {
            Console.WriteLine("Nhập vào ID PLC cần giao tiếp: ");
            string ID = Console.ReadLine();
            Device deviceFounded = deviceManager.FindDevice(ID);
            if (deviceFounded != null && deviceFounded is PLC)
            {
                PLC PLCFounded =(PLC) deviceFounded;
                Console.WriteLine("Lựa chọn: 1: Kết nối, 0: Ngắt kết nối");
                int luaChon = Convert.ToInt32(Console.ReadLine());
                if (luaChon == 0)
                {
                    PLCFounded.Disconnect();
                }
                else if (luaChon == 1)
                {
                    PLCFounded.Connect();
                }
                else Console.WriteLine("Lựa chọn không tồn tại");
            }
            else
            {
                Console.WriteLine("Không tìm thấy ID");
            }
            
        }
        void DatTocDoMotor()
        {
            Console.WriteLine("Nhập vào ID Motor cần đặt tốc độ: ");
            string ID = Console.ReadLine();
            Console.WriteLine(">> Nhập vào tốc độ cần đặt (rpm): ");
            int speed = Convert.ToInt32(Console.ReadLine());
            Device deviceFounded = deviceManager.FindDevice(ID);
            if (deviceFounded != null && deviceFounded is Motor)
            {
                Motor MotorFounded =(Motor) deviceFounded;
                MotorFounded.SetSpeed(speed);
                Console.WriteLine("Hoàn thành set speed");
            }
            else
            {
                Console.WriteLine("Không tìm thấy ID");
            }
        }
        void DocGiaTriSensor()
        {
            Console.WriteLine("Nhập vào ID Sensor cần đọc giá trị: ");
            string ID = Console.ReadLine();
            Console.WriteLine(">> Đang đọc giá trị...");
            Device deviceFounded = deviceManager.FindDevice(ID);
            if (deviceFounded != null && deviceFounded is Sensor)
            {
                Sensor senFounded =(Sensor) deviceFounded;
                Console.WriteLine($">> Giá trị đọc được: {senFounded.ReadValue()}");
                Console.WriteLine("Trạng thái bình thường");
            }
            else
            {
                Console.WriteLine("Không tìm thấy ID");
            }
        }
        void DungTatCa()
        {
            deviceManager.StopAllDevices();
        }
        void KhoiDongTatCa()
        {
            deviceManager.StartAllDevices();
        }
        void HienThiTatCaThietBi()
        {
            deviceManager.GetAllDevice();
        }

        void HienThiTrangThaiThietBi()
        {
            deviceManager.PrintAllStatus();
        }
        void AddDevice()
        {
             while (true)
            {
                string deviceId, deviceName, location,sensorType,unit,brand, model, ipAdress;
                double minValue, maxValue,ratedPower;
                int ratedSpeed;
                Console.WriteLine("Nhập vào loại thiết bị Sensor/Motor/PLC: ");
                string typeEqp = Console.ReadLine();
                Console.WriteLine($"Nhập vào {typeEqp} ID: ");
                deviceId = Console.ReadLine();
                Console.WriteLine($"Nhập vào {typeEqp} Name: ");
                deviceName = Console.ReadLine();
                Console.WriteLine($"Nhập vào {typeEqp} location: ");
                location = Console.ReadLine();
                switch (typeEqp)
                { 
                    case "Sensor":
                        // public Sensor(string deviceId, string deviceName, string location, string sensorType, string unit, double minValue, double maxValue) :
                        Console.WriteLine($"Nhập vào {typeEqp} sensorType: ");sensorType = Console.ReadLine();
                        Console.WriteLine($"Nhập vào {typeEqp} unit: ");unit = Console.ReadLine();
                        Console.WriteLine($"Nhập vào {typeEqp} minValue: ");minValue = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Nhập vào {typeEqp} maxValue: ");maxValue = double.Parse(Console.ReadLine());
                        Device newSensor = new Sensor(deviceId, deviceName, location, sensorType, unit, minValue,maxValue);
                        deviceManager.AddDevice(newSensor);
                        return;
                    case "Motor" :
                        // public Motor(string deviceId, string deviceName, string location, double ratedPower, int ratedSpeed)
                        Console.WriteLine($"Nhập vào {typeEqp} RatedPower: ");ratedPower = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Nhập vào {typeEqp} RatedSpeed: ");ratedSpeed = Convert.ToInt32(Console.ReadLine());
                        Device newMotor = new Motor(deviceId, deviceName, location, ratedPower, ratedSpeed);
                        deviceManager.AddDevice(newMotor);
                        return;
                    case "PLC":
                        //public PLC(string deviceId, string deviceName, string location, string brand, string model, string ipAdress)
                        Console.WriteLine($"Nhập vào {typeEqp} brand: ");brand = Console.ReadLine();
                        Console.WriteLine($"Nhập vào {typeEqp} model: ");model = Console.ReadLine();
                        Console.WriteLine($"Nhập vào {typeEqp} IP Adress: ");ipAdress = Console.ReadLine();
                        Device newPLC = new PLC(deviceId, deviceName, location, brand, model, ipAdress);
                        deviceManager.AddDevice(newPLC);
                        return;
                    default:
                        Console.WriteLine("Nhập đúng loại Sensor / Motor / PLC :");
                        break;
                }
            }
        }
        void DungThietBi()
        {
            Console.WriteLine("Nhập vào ID thiết bị cần Stop: ");
            string ID = Console.ReadLine();
            Device deviceFounded = deviceManager.FindDevice(ID);
            if (deviceFounded != null)
            {
                deviceFounded.Stop();
            }
            else
            {
                Console.WriteLine("Không tìm thấy ID");
            }
        }
        void KhoiDongThietBi()
        {
            Console.WriteLine("Nhập vào ID thiết bị cần khởi động: ");
            string ID = Console.ReadLine();
            Device deviceFounded = deviceManager.FindDevice(ID);
            if (deviceFounded != null)
            {
                deviceFounded.Start();
            }
            else
            {
                Console.WriteLine("Không tìm thấy ID");
            }
        }
        void TimKiemThietBiTheoId()
        {
            Console.WriteLine("Nhập vào ID: ");
            string ID = Console.ReadLine();
            Device deviceFounded = deviceManager.FindDevice(ID);
            if (deviceFounded != null)
            {
                Console.WriteLine($"\t {deviceFounded.GetType().Name} - " + deviceFounded.GetInfo());
            }
            else
            {
                Console.WriteLine("Không tìm thấy ID");
            }
        }

        
        
    }
    
}
