using Exception_Handling;

namespace Lesson10_FileIO_ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // I. Kiến thức về xử lý ngoại lệ 
            // Vd: sự cố y2k
            // 1970 - 1981
            // 1999 - 2000  99 -> 00
            // mong muốn: 2000
            // thực tế: 1999
            // int view = 2 tỷ, 5 tỷ 

            // Exception có 2 loại
            // Loại 1: Do lỗi hệ thống SystemException
            // Loại 2: Lỗi ứng dụng ApplicationException 

            // void Display(int chieuDai)
            // Display(400000000000000)
            // 

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                // Code có thể gây ra ngoại lệ
                int a = 10;
                int b = 0;
                //int result = a / b;
                //Console.WriteLine(result);

                // Cách 2:
                PhepChia(a, b);


                //
                //FileStream fs = new FileStream(@"C:\fdfdsfdsfds", FileMode.Open, FileAccess.Read);

                //fs.Close();
            }
            catch (DivideByZeroException ex)  // cảnh sát giao thông
            {
                // là nơi xử lý ngoại lệ
                Console.WriteLine("Lỗi không chia hết cho 0 trong DivideByZeroException: " + ex.Message);
            }
            catch (FileNotFoundException ex)  // cảnh sát hình sự
            {
                Console.WriteLine("Lỗi File không tồn tại " + ex.Message);
            }
            catch (DeviceConnectException ex)  // cảnh sát tự tạo theo phong cách của mình
            {
                Console.WriteLine("Lỗi tại Custom Exception " + ex.Message);
            }
            catch (Exception ex)  // tóa án tối cao 
            {
                Console.WriteLine("Lỗi hệ thống trong Exception: " + ex.Message);
            }
            finally
            {
                // thường dùng để đóng file, đóng kết nối, dọn dẹp 
                Console.WriteLine("Kiểu gì cũng có thông báo này");
            }
            Console.WriteLine("Code phía dưới vẫn chạy");

            // II. Throw Exception
            // Throw: Dùng để chủ động ném ngoại lệ khi phát hiện lỗi 
            // Cú pháp: throw new Exception("message lỗi")
            // throw luôn đi kèm với try catch
            // throw là còi báo cháy  || return là kết thúc ca làm việc

            // III. Custom Exception
            // 

            // StackTrace trong exception C#

        }

        private static int PhepChia(int a, int b)
        {
            if (b == 0)
            {
                throw new DeviceConnectException();
            }
            return a / b;
        }
    }
}
