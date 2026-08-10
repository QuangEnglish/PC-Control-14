using System;

namespace BT_cuoi_khoa;

public abstract class Device
{
	private string _deviceId;

	private string _deviceName;

	private string _location;

	private bool _isRunning;

	private DateTime _installDate;

	public string DeviceId
	{
		get
		{
			return _deviceId;
		}
		protected set
		{
			_deviceId = value;
		}
	}

	public string DeviceName
	{
		get
		{
			return _deviceName;
		}
		set
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("Tên thiết bị không được để trống.");
			}
			_deviceName = value;
		}
	}

	public string Location
	{
		get
		{
			return _location;
		}
		set
		{
			_location = value;
		}
	}

	public bool IsRunning
	{
		get
		{
			return _isRunning;
		}
		protected set
		{
			_isRunning = value;
		}
	}

	public DateTime InstallDate
	{
		get
		{
			return _installDate;
		}
		set
		{
			_installDate = value;
		}
	}

	protected Device(string deviceId, string deviceName, string location, bool isRunning, DateTime installDate)
	{
		_deviceId = deviceId;
		_deviceName = deviceName;
		_location = location;
		_isRunning = false;
		_isRunning = isRunning;
		_installDate = DateTime.Now;
		_installDate = installDate;
	}

	public abstract string GetSatus();

	public virtual string GetInfo()
	{
		return $"ID: {DeviceId},Name: {DeviceName},Location: {Location}, IsRunning: {IsRunning},InstallDate: {InstallDate}";
	}

	public virtual bool Start()
	{
		_isRunning = true;
		return true;
	}

	public virtual bool Stop()
	{
		_isRunning = false;
		return true;
	}

	public virtual string Reset()
	{
		Stop();
		return "Device reset";
	}
}
