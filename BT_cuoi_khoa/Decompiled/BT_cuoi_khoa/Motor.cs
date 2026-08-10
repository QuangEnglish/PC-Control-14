using System;

namespace BT_cuoi_khoa;

public class Motor : Device
{
	private double _ratedPower;

	private int _ratedSpeed;

	private int _currentSpeed;

	public double RatedPower
	{
		get
		{
			return _ratedPower;
		}
		set
		{
			_ratedPower = value;
		}
	}

	public int RatedSpeed
	{
		get
		{
			return _ratedSpeed;
		}
		set
		{
			_ratedSpeed = value;
		}
	}

	public int CurrentSpeed
	{
		get
		{
			return _currentSpeed;
		}
		set
		{
			if (value < 0 || (double)value > (double)RatedSpeed * 1.2)
			{
				throw new ArgumentOutOfRangeException("value", $"CurrentSpeed phải nằm trong khoảng [0, {(double)RatedSpeed * 1.2}].");
			}
			_currentSpeed = value;
		}
	}

	public Motor(string deviceId, string deviceName, string location, bool isRunning, DateTime installDate, double ratedPower, int ratedSpeed)
		: base(deviceId, deviceName, location, isRunning, installDate)
	{
		RatedPower = ratedPower;
		RatedSpeed = ratedSpeed;
		CurrentSpeed = 0;
	}

	public override string GetSatus()
	{
		return $"Motor {base.DeviceName}: {CurrentSpeed} / {RatedSpeed} RPM. Trạng thái hoạt động: {base.IsRunning}";
	}

	public override string GetInfo()
	{
		return base.GetInfo() + $" Công suất {RatedPower}, Tốc độ định mức: {RatedSpeed}, Tốc độ hiện tại: {CurrentSpeed}";
	}

	public override bool Start()
	{
		CurrentSpeed = RatedSpeed;
		return base.Start();
	}

	public override bool Stop()
	{
		CurrentSpeed = 0;
		return base.Stop();
	}

	public int SetSpeed(int speed)
	{
		CurrentSpeed = speed;
		return CurrentSpeed;
	}
}
