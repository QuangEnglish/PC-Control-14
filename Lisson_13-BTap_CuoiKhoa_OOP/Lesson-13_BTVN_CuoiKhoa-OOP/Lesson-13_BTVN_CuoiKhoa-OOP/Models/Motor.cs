namespace Lesson_13_BTVN_CuoiKhoa_OOP.Machine;

public class Motor : Device  // Đại diện cho động cơ, bơm, quạt...
{
    // Filed
        private double _ratedPower;   // double - Công suất định mức (kW)
        private int _ratedSpeed;      //  int - Tốc độ định mức (RPM)
        private int _currentSpeed;    // int - Tốc độ hiện tại (RPM)
        
 // Propertis
        // RatedPower
        public double RatedPower
        {
            get { return _ratedPower; }
            set { _ratedPower = value; }
        }

        // RatedSpeed
        public int RatedSpeed
        {
            get { return _ratedSpeed; }
            set { _ratedSpeed = value; }
        }

        // CurrentSpeed
        public int CurrentSpeed
        {
            get { return _currentSpeed; }
            set
            {
                if (value < 0) // validation không được âm
                {
                    throw new ArgumentException(
                        "CurrentSpeed khong duoc am.");
                }

                if (value > RatedSpeed * 1.2)  // validation không được vượt quá 120% RatedSpeed
                {
                    throw new ArgumentException(
                        "CurrentSpeed khong duoc vuot qua 120% RatedSpeed.");
                }

                _currentSpeed = value;
            }
        }
        
        // Constructor
        public Motor(
            string deviceId,
            string deviceName,
            string location,
            double ratedPower,
            int ratedSpeed)
            : base(deviceId, deviceName, location)
        {
            RatedPower = ratedPower;
            RatedSpeed = ratedSpeed;
            _currentSpeed = 0;
        }
        
  //  Các methods override
  
        // GetStatus
        public override string GetStatus()
        {
            string status;

            if (IsRunning)
            {
                status = "Running";
            }
            else
            {
                status = "Stopped";
            }

            return "Motor " + DeviceName
                   + ": " + CurrentSpeed
                   + "/" + RatedSpeed
                   + " RPM (" + status + ")";
        }

        // GetInfo
        public override string GetInfo() // thêm thông tin công suất, tốc độ
        {
            return base.GetInfo()
                   + ", RatedPower: " + RatedPower + " kW"
                   + ", RatedSpeed: " + RatedSpeed + " RPM"
                   + ", CurrentSpeed: " + CurrentSpeed + " RPM";
        }

        // Start
        public override bool Start()
        {
            bool result = base.Start();

            CurrentSpeed = RatedSpeed;

            return result;
        }

        // Stop
        public override bool Stop()
        {
            bool result = base.Stop();

            CurrentSpeed = 0;

            return result;
        }

        // SetSpeed
        // Đặt tốc độ cho motor, có validation
        public void SetSpeed(int speed)
        {
            CurrentSpeed = speed;  
        }
        

}
