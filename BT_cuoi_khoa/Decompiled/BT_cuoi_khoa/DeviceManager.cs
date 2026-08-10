using System;
using System.Collections.Generic;
using System.Linq;

namespace BT_cuoi_khoa;

public class DeviceManager
{
	private List<Device> thietBi = new List<Device>();

	public void ThemThietBi(Device device)
	{
		thietBi.Add(device);
	}

	public void XoaThietBi(string deviceId)
	{
		Device device = thietBi.FirstOrDefault((Device d) => d.DeviceId == deviceId);
		if (device != null)
		{
			thietBi.Remove(device);
		}
	}

	public Device TimThietBi(string deviceId)
	{
		Device device = thietBi.FirstOrDefault((Device d) => d.DeviceId == deviceId);
		if (device != null)
		{
			return device;
		}
		return null;
	}

	public List<Device> GetAllDevices()
	{
		return thietBi;
	}

	public List<T> GetDevicesByType<T>() where T : Device
	{
		return thietBi.OfType<T>().ToList();
	}

	public void StartAllDevices()
	{
		foreach (Device item in thietBi)
		{
			item.Start();
		}
	}

	public void StopAllDevices()
	{
		foreach (Device item in thietBi)
		{
			item.Stop();
		}
	}

	public void PrintAllStatus()
	{
		foreach (Device item in thietBi)
		{
			Console.WriteLine(item.GetSatus());
		}
	}
}
