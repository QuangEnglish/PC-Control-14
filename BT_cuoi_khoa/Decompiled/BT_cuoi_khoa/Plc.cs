using System;

namespace BT_cuoi_khoa;

public class Plc : Device
{
	private string _brand;

	private string _model;

	private string _ipAddress;

	private bool _isconnected;

	public string Brand
	{
		get
		{
			return _brand;
		}
		set
		{
			_brand = value;
		}
	}

	public string Model
	{
		get
		{
			return _model;
		}
		set
		{
			_model = value;
		}
	}

	public string IpAddress
	{
		get
		{
			return _ipAddress;
		}
		set
		{
			if (value.Split('.').Length != 4)
			{
				throw new ArgumentException("IP Address không hợp lệ.");
			}
			_ipAddress = value;
		}
	}

	public bool Isconnected
	{
		get
		{
			return _isconnected;
		}
		set
		{
			_isconnected = value;
		}
	}

	public Plc(string deviceId, string deviceName, string location, bool isRunning, DateTime installDate, string brand, string model, string ipAddress)
		: base(deviceId, deviceName, location, isRunning, installDate)
	{
		Brand = brand;
		Model = model;
		IpAddress = ipAddress;
		Isconnected = false;
	}

	public override string GetSatus()
	{
		return $"PLC: {Brand}-{Model}, Connected: {Isconnected}, Trạng thái hoạt động: {base.IsRunning}";
	}

	public override string GetInfo()
	{
		return base.GetInfo() + IpAddress + Brand + Model;
	}

	public string Connect()
	{
		Isconnected = true;
		return "Đã connect";
	}

	public string Disconnect()
	{
		Isconnected = false;
		base.IsRunning = false;
		return "Đã Disconnect";
	}

	public override bool Start()
	{
		if (Isconnected)
		{
			return base.Start();
		}
		return false;
	}
}
