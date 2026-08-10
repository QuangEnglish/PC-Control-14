using System;

namespace BT_cuoi_khoa;

public class Sensor : Device
{
	private string _sensorType;

	private double _currentValue;

	private string _unit;

	private double _minValue;

	private double _maxValue;

	public string SensorType
	{
		get
		{
			return _sensorType;
		}
		set
		{
			_sensorType = value ?? throw new ArgumentNullException("value");
		}
	}

	public double CurrentValue
	{
		get
		{
			return _currentValue;
		}
		set
		{
			if (value < MinValue || value > MaxValue)
			{
				throw new ArgumentOutOfRangeException("value", $"Giá trị phải nằm trong khoảng [{MinValue}, {MaxValue}].");
			}
			_currentValue = value;
		}
	}

	public string Unit
	{
		get
		{
			return _unit;
		}
		set
		{
			_unit = value ?? throw new ArgumentNullException("value");
		}
	}

	public double MinValue
	{
		get
		{
			return _minValue;
		}
		set
		{
			_minValue = value;
		}
	}

	public double MaxValue
	{
		get
		{
			return _maxValue;
		}
		set
		{
			_maxValue = value;
		}
	}

	public Sensor(string deviceId, string deviceName, string location, bool isRunning, DateTime installDate, string sensorType, string unit, double minValue, double maxValue)
		: base(deviceId, deviceName, location, isRunning, installDate)
	{
		SensorType = sensorType;
		Unit = unit;
		MinValue = minValue;
		MaxValue = maxValue;
		CurrentValue = 0.0;
	}

	public override string GetSatus()
	{
		return $"SensorType: {SensorType}: {CurrentValue} {Unit}. Trạng thái hoạt động: {base.IsRunning}, Cảnh báo: {IsAlarm()}";
	}

	public override string GetInfo()
	{
		return base.GetInfo() + $" SensorType: {SensorType},Unit: {Unit},MinValue: {MinValue},MaxValue: {MaxValue},CurrentValue: {CurrentValue}";
	}

	public double ReadValue()
	{
		Random random = new Random();
		CurrentValue = MinValue + random.NextDouble() * (MaxValue - MinValue);
		return CurrentValue;
	}

	public bool IsAlarm()
	{
		return CurrentValue > MaxValue * 0.8;
	}
}
