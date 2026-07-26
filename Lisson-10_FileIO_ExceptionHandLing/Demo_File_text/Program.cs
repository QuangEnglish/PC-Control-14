

namespace Demo_File_text
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string path = "D:\\HocC#\\Demo_file\\demo_file.txt";     // File demo
            string logPath = "app_log.txt";    // File log minh họa Append

            // Xóa file cũ nếu tồn tại để demo sạch sẽ
            if (File.Exists(path)) File.Delete(path);
            if (File.Exists(logPath)) File.Delete(logPath);

            Console.WriteLine("=== 1. File.WriteAllText(path, content) ===");
            // Ghi đè toàn bộ file (nếu file cũ có → mất hết)
            File.WriteAllText(path, "Nội dung ban đầu.\nDòng 2.\nDòng 3.");
            Console.WriteLine("Sau WriteAllText:");
            Console.WriteLine(File.ReadAllText(path));
            Console.WriteLine("---\n");

            // Gọi lại → nội dung cũ bị đè hết
            File.WriteAllText(path, "NỘI DUNG MỚI - ĐÃ BỊ GHI ĐÈ!");
            Console.WriteLine("Sau WriteAllText lần 2 (ghi đè):");
            Console.WriteLine(File.ReadAllText(path));
            Console.WriteLine("---\n");

            Console.WriteLine("=== 2. File.WriteAllLines(path, string[] lines) ===");
            //Ghi đè bằng mảng dòng
            string[] lines = new string[]
            {
             "Tên: Nguyễn Quang",
             "Tuổi: 28",
             "Nơi ở: Hà Nội",
             "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy")
            };
            File.WriteAllLines(path, lines);
            Console.WriteLine("Sau WriteAllLines:");
            Console.WriteLine(File.ReadAllText(path));
            Console.WriteLine("---\n");

            Console.WriteLine("=== 3. File.AppendAllText(path, text) ===");
            // Nối thêm vào cuối file (không xóa nội dung cũ)
            File.AppendAllText(path, "\n--- Log bổ sung ---\n");
            File.AppendAllText(path, "Thêm dòng này lúc: " + DateTime.Now.ToString("HH:mm:ss") + "\n");
            Console.WriteLine("Sau AppendAllText:");
            Console.WriteLine(File.ReadAllText(path));
            Console.WriteLine("---\n");

            Console.WriteLine("=== 4. File.AppendAllLines(path, string[] lines) ===");
            //Nối nhiều dòng một lúc
            string[] logEntries = new string[]
            {
"[INFO] 2026-01-23 19:45:12 - User login thành công",
"[ERROR] 2026-01-23 19:46:05 - Không tìm thấy sản phẩm ID=123",
"[DEBUG] 2026-01-23 19:47:30 - Query database hoàn tất"
            };
            File.AppendAllLines(path, logEntries);
            Console.WriteLine("Sau AppendAllLines:");
            Console.WriteLine(File.ReadAllText(path));
            Console.WriteLine("---\n");

            //Minh họa thực tế: Append log nhiều lần(như hệ thống thật)
            Console.WriteLine("=== Minh họa Append log liên tục (như production) ===");
            for (int i = 1; i <= 3; i++)
            {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string entry = $"[{timestamp}] Request #{i} - Trạng thái: OK";
                File.AppendAllText(logPath, entry + Environment.NewLine);
                Console.WriteLine("Đã append: " + entry);
            }
            Console.WriteLine("\nNội dung file log cuối cùng:");
            Console.WriteLine(File.ReadAllText(logPath));
        }
    }
}
