using System.Text;

namespace Lesson8_VariableScope_String_Collection
{
    internal class Program
    {
        static int count = 200;   // biến tĩnh -> biến này chỉ thuộc về class Program, ko thuộc về hàm nào
        const int countV2 = 1000;  // hằng số
        int number = 100;  // biến thành viên (field)

        // biến tĩnh có thể thay đổi giá trị, khởi tạo khi chương trình chạy
        // hằng số không thể thay đổi giá trị, khởi tạo ngay khi biên dịch 

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //
            String name = "PLC01";
            char[] names = { 'P', 'L', 'C', '0', '1'};
            string nameStrings = new string(names);
            Console.WriteLine("Chuỗi 1: "+name);
            Console.WriteLine("Chuỗi 2: "+ nameStrings);

            // Nối chuỗi
            string msg = name + nameStrings;
            // 
            string data = "PLC01, CAM02, SENSOR03";
            string[] devices = data.Split(",");

            // duyệt mảng
            //foreach (string x in devices)
            //{
            //    Console.WriteLine("Thiết bị x: "+x.Trim());
            //}
            // "pc14"
            // "pc14"
            // cách so sánh 2 string
            // Contains: so sánh 1 chuỗi có chứa chuỗi con hay không, phân biệt chữ hoa chữ thường

            // devices là 1 mảng string
            // devices   có những phần tử lần lượt là "PLC01", " CAM02", " SENSOR3"

            //if (devices.Contains("PLC01"))
            //{
            //    Console.WriteLine("Có xuất hiện");
            //}
            //else
            //{
            //    Console.WriteLine("Không xuất hiện");
            //}
            ///////    string data = "PLC01, CAM02, SENSOR03";
            ///

            //if (data.Contains("CAM02"))
            //{
            //    Console.WriteLine("Có xuất hiện");
            //}
            //else
            //{
            //    Console.WriteLine("Không xuất hiện");
            //}

            // hàm StartsWith() kiểm tra phần đầu của chuỗi

            //if (data.EndsWith(" SENSOR03"))
            //{
            //    Console.WriteLine("Có xuất hiện");
            //}
            //else
            //{
            //    Console.WriteLine("Không xuất hiện");
            //}

            // Phạm vi truy cập của biến
            // 1. Biến trong block
            {
                int age = 22;
                Console.WriteLine(age);
            }
            //Console.WriteLine(age);  lỗi

            // 2. Biến trong if
            int score = 8;

            if (score >= 5)
            {
                string result = "Đậu";
                Console.WriteLine(result);
            }
            // Console.WriteLine(result);   lỗi

            // 3. Biến trong for
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine(i);
            }
            //Console.WriteLine(i);  lỗi

            // 4. Biến trong while

            // 5. Biến trong hàm (method)
            PrintName();
            //Console.WriteLine(nameV2);  lỗi

            PrintNameV2();
            // 6. Hai hàm có thể dùng cùng 1 tên biến nhưng bản chất là 2 biến khác nhau

            //Console.WriteLine("Giá trị của biến count là: "+count);

            // 7 biến thành viên
            int count = 500;
            Console.WriteLine(count);   // ... 500
            Console.WriteLine(Program.count);  // ... 200

            // 8 phạm vụ của switch
            int day = 2;

            // 9 phạm vi block trong và block ngoài
            //string nameV2 = "vvvv"; // tên ông
            switch (day)
            {
                case 1:
                    {
                        string nameV2 = "Monday";  // tên cháu A 
                        Console.WriteLine(nameV2);
                        break;
                    }

                case 2:
                    {
                        string nameV2 = "Tuesday"; // tên cháu A 
                        Console.WriteLine(nameV2);
                        break;
                    }
            }

            // Collection (List, Stack, Queue, Dictionary, Linked List)
            // là các cấu trúc dữ liệu động

            // Collection ra đời để xử lý các dữ liệu động
            // Collection và Array 

            // 1. kích thước phần tử
            // 

            // Collection đời cũ là Array List
            //ArrayList list = new ArrayList();
            //list.Add(1);
            //list.Add("Hieu Van");
            //list.Add(true);

            //List<NhanVien> numbers = new List<NhanVien>();
            int numberV3 = int.Parse(Console.ReadLine());
            Console.WriteLine("Giá trị: "+numberV3);

            
        }

        static void PrintName()
        {
            int count = 200;
            string nameV2 = "PC14";
            Console.WriteLine(nameV2);
            Console.WriteLine(count);  // 100
        }

        static void PrintNameV2()
        {
            int count = 200;
            string nameV2 = "PC14";
            Console.WriteLine(nameV2);
            Console.WriteLine(count);  // 100
        }

        void DisplayNumber()
        {
            Console.WriteLine(number);
        }

    }
}
