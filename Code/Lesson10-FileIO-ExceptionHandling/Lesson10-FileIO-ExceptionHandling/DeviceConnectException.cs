using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Handling
{
    internal class DeviceConnectException : Exception
    {
        public string PortName { get; }  // tên cổng cơm, cổng kết nối
        public int BaudRate { get; } // tốc độ truyền
        public int RetryCount { get; } // số lần kết nối lại

        public DeviceConnectException() : base("Kết nối thiết bị thất bại.") { }

        public DeviceConnectException(string message) : base(message) { }

        // Constructor 3: message + inner exception (rất quan trọng!)
        public DeviceConnectException(string message, Exception innerException)
            : base(message, innerException) { }

        // Constructor 4: đầy đủ – dùng trong PC Control
        public DeviceConnectException(string portName, int baudRate, int retryCount, string message, Exception inner = null)
            : base(message, inner)
        {
            PortName = portName;
            BaudRate = baudRate;
            RetryCount = retryCount;

            // Lưu thêm vào Data dictionary (tùy chọn)
            Data["Port"] = portName;
            Data["Baud"] = baudRate;
        }

        // Serialization constructor – hỗ trợ remoting / AppDomain (best practice)
        protected DeviceConnectException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            PortName = info.GetString(nameof(PortName));
            BaudRate = info.GetInt32(nameof(BaudRate));
            RetryCount = info.GetInt32(nameof(RetryCount));
        }

        // Override GetObjectData nếu có serialization
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(PortName), PortName);
            info.AddValue(nameof(BaudRate), BaudRate);
            info.AddValue(nameof(RetryCount), RetryCount);
        }
    }
}
