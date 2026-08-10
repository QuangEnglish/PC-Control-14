using System;
using System.Collections.Generic;
using System.Text;
using BT_cuoi_khoa;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        DeviceManager deviceManager = new DeviceManager();

        // Tạo thiết bị mặc định
        Sensor sensor = new Sensor(
            "S01",
            "Temperature Sensor",
            "Factory A",
            isRunning: false,
            DateTime.Now,
            "Temperature",
            "°C",
            0.0,
            100.0
        );

        Motor motor = new Motor(
            "M01",
            "Motor 1",
            "Factory A",
            isRunning: false,
            DateTime.Now,
            5000.0,
            1500
        );

        Plc plc = new Plc(
            "P01",
            "PLC 1",
            "Factory B",
            isRunning: false,
            DateTime.Now,
            "Siemens",
            "S7-1200",
            "192.168.1.10"
        );

        // Thêm thiết bị vào DeviceManager
        deviceManager.ThemThietBi(sensor);
        deviceManager.ThemThietBi(motor);
        deviceManager.ThemThietBi(plc);

        while (true)
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("   INDUSTRIAL DEVICE MANAGEMENT SYSTEM");
            Console.WriteLine("==============================================");
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
            Console.WriteLine("11. Kết nối / Ngắt PLC");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("____________________________________");

            Console.Write("Chọn chức năng: ");

            switch (Console.ReadLine())
            {
                // 1. HIỂN THỊ TẤT CẢ THIẾT BỊ
                case "1":
                {
                    Console.WriteLine("\n===== DANH SÁCH THIẾT BỊ =====");

                    List<Device> allDevices = deviceManager.GetAllDevices();

                    if (allDevices.Count == 0)
                    {
                        Console.WriteLine("Danh sách thiết bị đang trống.");
                    }
                    else
                    {
                        foreach (Device item in allDevices)
                        {
                            Console.WriteLine(item.GetInfo());
                            Console.WriteLine("--------------------------------");
                        }
                    }

                    TamDung();
                    break;
                }
                // 2. HIỂN THỊ TRẠNG THÁI
                case "2":
                {
                    Console.WriteLine("\n===== TRẠNG THÁI THIẾT BỊ =====");

                    deviceManager.PrintAllStatus();

                    TamDung();
                    break;
                }
                // 3. THÊM THIẾT BỊ
                case "3":
                {
                    Console.WriteLine("\n===== THÊM THIẾT BỊ =====");
                    Console.WriteLine("1. Sensor");
                    Console.WriteLine("2. Motor");
                    Console.WriteLine("3. PLC");

                    Console.Write("Chọn loại thiết bị: ");
                    string luaChon = Console.ReadLine() ?? "";

                    Console.Write("Device ID: ");
                    string deviceId = Console.ReadLine() ?? "";

                    Console.Write("Device Name: ");
                    string deviceName = Console.ReadLine() ?? "";

                    Console.Write("Location: ");
                    string location = Console.ReadLine() ?? "";

                    switch (luaChon)
                    {
                        // SENSOR
                        case "1":
                        {
                            Console.Write("Sensor Type: ");
                            string sensorType = Console.ReadLine() ?? "";

                            Console.Write("Unit: ");
                            string unit = Console.ReadLine() ?? "";

                            Console.Write("Min Value: ");
                            double minValue =
                                double.Parse(Console.ReadLine() ?? "0");

                            Console.Write("Max Value: ");
                            double maxValue =
                                double.Parse(Console.ReadLine() ?? "100");

                            Sensor newSensor = new Sensor(
                                deviceId,
                                deviceName,
                                location,
                                isRunning: false,
                                DateTime.Now,
                                sensorType,
                                unit,
                                minValue,
                                maxValue
                            );

                            deviceManager.ThemThietBi(newSensor);

                            Console.WriteLine("Đã thêm Sensor.");

                            break;
                        }
                        // MOTOR
                        case "2":
                        {
                            Console.Write("Rated Power: ");
                            double ratedPower =
                                double.Parse(Console.ReadLine() ?? "0");

                            Console.Write("Rated Speed: ");
                            int ratedSpeed =
                                int.Parse(Console.ReadLine() ?? "0");

                            Motor newMotor = new Motor(
                                deviceId,
                                deviceName,
                                location,
                                isRunning: false,
                                DateTime.Now,
                                ratedPower,
                                ratedSpeed
                            );

                            deviceManager.ThemThietBi(newMotor);

                            Console.WriteLine("Đã thêm Motor.");

                            break;
                        }
                        // PLC
                        case "3":
                        {
                            Console.Write("Brand: ");
                            string brand = Console.ReadLine() ?? "";

                            Console.Write("Model: ");
                            string model = Console.ReadLine() ?? "";

                            Console.Write("IP Address: ");
                            string ipAddress = Console.ReadLine() ?? "";

                            Plc newPlc = new Plc(
                                deviceId,
                                deviceName,
                                location,
                                isRunning: false,
                                DateTime.Now,
                                brand,
                                model,
                                ipAddress
                            );

                            deviceManager.ThemThietBi(newPlc);

                            Console.WriteLine("Đã thêm PLC.");

                            break;
                        }

                        default:
                        {
                            Console.WriteLine("Loại thiết bị không hợp lệ.");
                            break;
                        }
                    }

                    TamDung();
                    break;
                }
                // 4. TÌM KIẾM THIẾT BỊ
                case "4":
                {
                    Console.Write("\nNhập Device ID: ");

                    string deviceId = Console.ReadLine() ?? "";

                    Device foundDevice =
                        deviceManager.TimThietBi(deviceId);

                    if (foundDevice != null)
                    {
                        Console.WriteLine(
                            "\n===== THIẾT BỊ TÌM THẤY ====="
                        );

                        Console.WriteLine(foundDevice.GetInfo());
                    }
                    else
                    {
                        Console.WriteLine(
                            "Không tìm thấy thiết bị."
                        );
                    }

                    TamDung();
                    break;
                }
                // 5. KHỞI ĐỘNG THIẾT BỊ
                case "5":
                {
                    Console.Write("\nNhập Device ID: ");

                    string deviceId = Console.ReadLine() ?? "";

                    Device foundDevice =
                        deviceManager.TimThietBi(deviceId);

                    if (foundDevice != null)
                    {
                        foundDevice.Start();

                        Console.WriteLine(
                            "Đã khởi động thiết bị."
                        );
                    }
                    else
                    {
                        Console.WriteLine(
                            "Không tìm thấy thiết bị."
                        );
                    }

                    TamDung();
                    break;
                }
                // 6. DỪNG THIẾT BỊ
                case "6":
                {
                    Console.Write("\nNhập Device ID: ");

                    string deviceId = Console.ReadLine() ?? "";

                    Device foundDevice =
                        deviceManager.TimThietBi(deviceId);

                    if (foundDevice != null)
                    {
                        foundDevice.Stop();

                        Console.WriteLine(
                            "Đã dừng thiết bị."
                        );
                    }
                    else
                    {
                        Console.WriteLine(
                            "Không tìm thấy thiết bị."
                        );
                    }

                    TamDung();
                    break;
                }
                // 7. KHỞI ĐỘNG TẤT CẢ
                case "7":
                {
                    deviceManager.StartAllDevices();

                    Console.WriteLine(
                        "\nĐã khởi động tất cả thiết bị."
                    );

                    TamDung();
                    break;
                }
                // 8. DỪNG TẤT CẢ
                case "8":
                {
                    deviceManager.StopAllDevices();

                    Console.WriteLine(
                        "\nĐã dừng tất cả thiết bị."
                    );

                    TamDung();
                    break;
                }
                // 9. ĐỌC GIÁ TRỊ SENSOR
                case "9":
                {
                    Console.Write("\nNhập Sensor ID: ");

                    string deviceId = Console.ReadLine() ?? "";

                    Device foundDevice =
                        deviceManager.TimThietBi(deviceId);

                    if (foundDevice is Sensor sensorDevice)
                    {
                        double value =
                            sensorDevice.ReadValue();

                        Console.WriteLine(
                            $"Giá trị hiện tại: {value}"
                        );
                    }
                    else
                    {
                        Console.WriteLine(
                            "Không tìm thấy Sensor."
                        );
                    }

                    TamDung();
                    break;
                }
                // 10. ĐẶT TỐC ĐỘ MOTOR
                case "10":
                {
                    Console.Write("\nNhập Motor ID: ");

                    string deviceId = Console.ReadLine() ?? "";

                    Device foundDevice =
                        deviceManager.TimThietBi(deviceId);

                    if (foundDevice is Motor motorDevice)
                    {
                        Console.Write("Nhập tốc độ mới: ");

                        int speed =
                            int.Parse(Console.ReadLine() ?? "0");

                        try
                        {
                            motorDevice.SetSpeed(speed);

                            Console.WriteLine(
                                $"Tốc độ hiện tại: {motorDevice.CurrentSpeed}"
                            );
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(
                                "Lỗi: " + ex.Message
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine(
                            "Không tìm thấy Motor."
                        );
                    }

                    TamDung();
                    break;
                }
                // 11. CONNECT / DISCONNECT PLC
                case "11":
                {
                    Console.Write("\nNhập PLC ID: ");

                    string deviceId = Console.ReadLine() ?? "";

                    Device foundDevice =
                        deviceManager.TimThietBi(deviceId);

                    if (foundDevice is Plc plcDevice)
                    {
                        Console.WriteLine(
                            $"Trạng thái kết nối: {plcDevice.Isconnected}"
                        );

                        Console.WriteLine("1: Connect");
                        Console.WriteLine("2: Disconnect");

                        Console.Write("Chọn: ");

                        string luaChon =
                            Console.ReadLine() ?? "";

                        switch (luaChon)
                        {
                            case "1":
                            {
                                plcDevice.Connect();
                                Console.WriteLine("Connect");
                                break;
                            }
                            case "2":
                            {
                                plcDevice.Disconnect();
                                Console.WriteLine("Disconnect");
                                break;
                            }
                            default:
                            {
                                Console.WriteLine("Lựa chọn không hợp lệ.");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy PLC.");
                    }
                    TamDung();
                    break;
                }
                // 0. THOÁT
                case "0":
                {
                    Console.WriteLine(
                        "\nĐã thoát chương trình."
                    );

                    return;
                }
                // LỰA CHỌN KHÔNG HỢP LỆ
                default:
                {
                    Console.WriteLine(
                        "\nLựa chọn không hợp lệ!"
                    );

                    TamDung();
                    break;
                }
            }
        }
    }

    // HÀM TẠM DỪNG
    static void TamDung()
    {
        Console.WriteLine();
        Console.WriteLine("Nhấn Enter để tiếp tục...");
        Console.ReadLine();
    }
}