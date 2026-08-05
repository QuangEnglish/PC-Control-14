using System;

namespace SensorApp
{
    class Sensor
    {
        public bool IsActive { get; set; }
        protected string SensorId { get; set; }

        public Sensor(string id)
        {
            SensorId = id;
            IsActive = false;
        }

        public virtual void ReadData()
        {
            Console.WriteLine("Dang doc du lieu cam bien");
        }
    }

    class TemperatureSensor : Sensor
    {
        public double Temperature { get; set; }

        public TemperatureSensor(string id, double temp) : base(id)
        {
            Temperature = temp;
            IsActive = true;
        }

        public override void ReadData()
        {
            Console.WriteLine("Cam bien nhiet do (" + SensorId + "): " + Temperature + " do C");
        }
    }

    class PressureSensor : Sensor
    {
        public double Pressure { get; set; }

        public PressureSensor(string id, double press) : base(id)
        {
            Pressure = press;
            IsActive = true;
        }

        public override void ReadData()
        {
            Console.WriteLine("Cam bien ap suat (" + SensorId + "): " + Pressure + " bar");
        }
    }

    class bttinhkethua
    {
        static void Main(string[] args)
        {
            TemperatureSensor tempSensor = new TemperatureSensor("ts1", 25.5);
            PressureSensor pressSensor = new PressureSensor("ps1", 1.013);

            tempSensor.ReadData();
            pressSensor.ReadData();

            Console.ReadLine();
        }
    }
}