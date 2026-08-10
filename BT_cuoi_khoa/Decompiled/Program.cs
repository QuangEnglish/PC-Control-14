using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using BT_cuoi_khoa;

[CompilerGenerated]
internal class Program
{
	static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8;
		Console.InputEncoding = Encoding.UTF8;
		DeviceManager deviceManager = new DeviceManager();
		Sensor device = new Sensor("S01", "Temperature Sensor", "Factory A", isRunning: false, DateTime.Now, "Temperature", "°C", 0.0, 100.0);
		Motor device2 = new Motor("M01", "Motor 1", "Factory A", isRunning: false, DateTime.Now, 5000.0, 1500);
		Plc device3 = new Plc("P01", "PLC 1", "Factory B", isRunning: false, DateTime.Now, "Siemens", "S7-1200", "192.168.1.10");
		deviceManager.ThemThietBi(device);
		deviceManager.ThemThietBi(device2);
		deviceManager.ThemThietBi(device3);
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
			case "2":
				Console.WriteLine("\n===== TRẠNG THÁI THIẾT BỊ =====");
				deviceManager.PrintAllStatus();
				TamDung();
				break;
			case "3":
			{
				Console.WriteLine("\n===== THÊM THIẾT BỊ =====");
				Console.WriteLine("1. Sensor");
				Console.WriteLine("2. Motor");
				Console.WriteLine("3. PLC");
				Console.Write("Chọn loại thiết bị: ");
				string text4 = Console.ReadLine();
				Console.Write("Device ID: ");
				string deviceId7 = Console.ReadLine() ?? "";
				Console.Write("Device Name: ");
				string deviceName = Console.ReadLine() ?? "";
				Console.Write("Location: ");
				string location = Console.ReadLine() ?? "";
				switch (text4)
				{
				case "1":
				{
					Console.Write("Sensor Type: ");
					string sensorType = Console.ReadLine() ?? "";
					Console.Write("Unit: ");
					string unit = Console.ReadLine() ?? "";
					Console.Write("Min Value: ");
					double minValue = double.Parse(Console.ReadLine() ?? "0");
					Console.Write("Max Value: ");
					double maxValue = double.Parse(Console.ReadLine() ?? "100");
					Sensor device11 = new Sensor(deviceId7, deviceName, location, isRunning: false, DateTime.Now, sensorType, unit, minValue, maxValue);
					deviceManager.ThemThietBi(device11);
					Console.WriteLine("Đã thêm Sensor.");
					break;
				}
				case "2":
				{
					Console.Write("Rated Power: ");
					double ratedPower = double.Parse(Console.ReadLine() ?? "0");
					Console.Write("Rated Speed: ");
					int ratedSpeed = int.Parse(Console.ReadLine() ?? "0");
					Motor device12 = new Motor(deviceId7, deviceName, location, isRunning: false, DateTime.Now, ratedPower, ratedSpeed);
					deviceManager.ThemThietBi(device12);
					Console.WriteLine("Đã thêm Motor.");
					break;
				}
				case "3":
				{
					Console.Write("Brand: ");
					string brand = Console.ReadLine() ?? "";
					Console.Write("Model: ");
					string model = Console.ReadLine() ?? "";
					Console.Write("IP Address: ");
					string ipAddress = Console.ReadLine() ?? "";
					Plc device10 = new Plc(deviceId7, deviceName, location, isRunning: false, DateTime.Now, brand, model, ipAddress);
					deviceManager.ThemThietBi(device10);
					Console.WriteLine("Đã thêm PLC.");
					break;
				}
				default:
					Console.WriteLine("Loại thiết bị không hợp lệ.");
					break;
				}
				TamDung();
				break;
			}
			case "4":
			{
				Console.Write("\nNhập Device ID: ");
				string deviceId5 = Console.ReadLine() ?? "";
				Device device8 = deviceManager.TimThietBi(deviceId5);
				if (device8 != null)
				{
					Console.WriteLine("\n===== THIẾT BỊ TÌM THẤY =====");
					Console.WriteLine(device8.GetInfo());
				}
				else
				{
					Console.WriteLine("Không tìm thấy thiết bị.");
				}
				TamDung();
				break;
			}
			case "5":
			{
				Console.Write("\nNhập Device ID: ");
				string deviceId2 = Console.ReadLine() ?? "";
				Device device5 = deviceManager.TimThietBi(deviceId2);
				if (device5 != null)
				{
					device5.Start();
					Console.WriteLine("Đã khởi động thiết bị.");
				}
				else
				{
					Console.WriteLine("Không tìm thấy thiết bị.");
				}
				TamDung();
				break;
			}
			case "6":
			{
				Console.Write("\nNhập Device ID: ");
				string deviceId4 = Console.ReadLine() ?? "";
				Device device7 = deviceManager.TimThietBi(deviceId4);
				if (device7 != null)
				{
					device7.Stop();
					Console.WriteLine("Đã dừng thiết bị.");
				}
				else
				{
					Console.WriteLine("Không tìm thấy thiết bị.");
				}
				break;
			}
			case "7":
				deviceManager.StartAllDevices();
				Console.WriteLine("\nĐã khởi động tất cả thiết bị.");
				TamDung();
				break;
			case "8":
				deviceManager.StopAllDevices();
				Console.WriteLine("\nĐã dừng tất cả thiết bị.");
				TamDung();
				break;
			case "9":
			{
				Console.Write("\nNhập Sensor ID: ");
				string deviceId6 = Console.ReadLine() ?? "";
				Device device9 = deviceManager.TimThietBi(deviceId6);
				if (device9 is Sensor sensor)
				{
					double value = sensor.ReadValue();
					Console.WriteLine($"Giá trị hiện tại: {value}");
				}
				else
				{
					Console.WriteLine("Không tìm thấy Sensor.");
				}
				TamDung();
				break;
			}
			case "10":
			{
				Console.Write("\nNhập Motor ID: ");
				string deviceId3 = Console.ReadLine() ?? "";
				Device device6 = deviceManager.TimThietBi(deviceId3);
				if (device6 is Motor motor)
				{
					Console.Write("Nhập tốc độ mới: ");
					int speed = int.Parse(Console.ReadLine() ?? "0");
					try
					{
						motor.SetSpeed(speed);
						Console.WriteLine($"Tốc độ hiện tại: {motor.CurrentSpeed}");
					}
					catch (ArgumentOutOfRangeException ex)
					{
						Console.WriteLine("Lỗi: " + ex.Message);
					}
				}
				else
				{
					Console.WriteLine("Không tìm thấy Motor.");
				}
				TamDung();
				break;
			}
			case "11":
			{
				Console.Write("\nNhập PLC ID: ");
				string deviceId = Console.ReadLine() ?? "";
				Device device4 = deviceManager.TimThietBi(deviceId);
				if (device4 is Plc plc)
				{
					Console.WriteLine($"Trạng thái kết nối: {plc.Isconnected}");
					Console.WriteLine("1: Connect ");
					Console.WriteLine("2: Disonnect ");
					string text = Console.ReadLine() ?? "";
					string text2 = text;
					string text3 = text2;
					if (!(text3 == "1"))
					{
						if (text3 == "2")
						{
							plc.Disconnect();
							Console.WriteLine("Disconnect");
						}
					}
					else
					{
						plc.Connect();
						Console.WriteLine("Connected");
					}
				}
				else
				{
					Console.WriteLine("Không tìm thấy PLC.");
				}
				TamDung();
				break;
			}
			case "0":
				Console.WriteLine("\nĐã thoát chương trình.");
				return;
			default:
				Console.WriteLine("\nLựa chọn không hợp lệ!");
				TamDung();
				break;
			}
		}
		static void TamDung()
		{
			Console.WriteLine();
			Console.WriteLine("Nhấn Enter để tiếp tục...");
			Console.ReadLine();
		}
	}
}
