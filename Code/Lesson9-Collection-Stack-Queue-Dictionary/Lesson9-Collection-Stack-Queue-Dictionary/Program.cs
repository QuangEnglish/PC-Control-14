using System.Text;

namespace Lesson9_Collection_Stack_Queue_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Stack và Queue

            // Stack  : Ngăn xếp
            // tuân theo nguyên tắc: LIFO, last in first out, vào sau ra trước
            // Push: thêm mới, ghi nhận 1 trạng thái mới
            // Peek: xem trạng thái hiện tại
            // Pop: Xóa, loại bỏ trạng thái hiện tại


            Stack<string> undoStack = new Stack<string>();
            undoStack.Push("Bước 1");
            undoStack.Push("Bước 2");
            undoStack.Push("Bước 3");

            foreach (var item in undoStack)
            {
                Console.WriteLine("Phần tử: "+item);
            }

            string[] arr = undoStack.ToArray();
            Console.WriteLine("Thao tác hiện tại: "+undoStack.Peek());

            // nhấn 1 nút hoàn tác
            if (undoStack.Count > 0)
            {
                string lastAction = undoStack.Pop();  // Hoàn tác thao tác gì
                Console.WriteLine("Hoàn tác thao tác: "+lastAction);  // 
            }

            Console.WriteLine("Trạng thái robot sau khi Undo: "+undoStack.Peek());  // Bước 2

            // Collection Queue: Hàng đợi
            // Queue: sinh ra để tạo 1 trật tự trong đống hỗn loạn
            // Nguyên tắc: FIFO - vào trước thì ra trước
            // Enqueue:  đưa người xếp hàng mua vé vào cuối hàng
            // Dequeue: lấy vé ở đầu hàng ra để xem phim


            Queue<string> imageQueue = new Queue<string>();
            imageQueue.Enqueue("Bước 1"); 
            imageQueue.Enqueue("Bước 2");
            imageQueue.Enqueue("Bước 3"); 

            foreach (var item in imageQueue)
            {
                Console.WriteLine("Phần tử: " + item);
            }

            while (imageQueue.Count > 0)
            {
                string image = imageQueue.Dequeue();
                Console.WriteLine("Đang xử lý: "+image);  // -> bước 3 -> bước 2 -> bước 1 
            }

            // Kết luận:
            // Nguyên lý:
            // Truy cập: 
            // Stack truy cập phần tử cuối cùng đc thêm
            // Queue có thể truy cập phần tử đầu tiên
            // List truy cập mọi vị trí

            // Collection Dictionary
            // lưu dữ liệu theo cặp Key -value
            // key: là dùng để tra cứu 
            // value: dữ liệu tương ứng 
            // quy tắc: key là phải duy nhất
            // chạy theo cơ chế hash table
            // để tìm kiếm nhanh

            // graph là bản đồ
            // dictionary là cấu trúc dữ liệu động dùng để lưu Graph sao cho tra cứu nhanh

            Dictionary<string, string> deviceStatus = new Dictionary<string, string>();
            deviceStatus.Add("PLC01", "Connected");
            deviceStatus.Add("PLC02", "Connected");
            deviceStatus.Add("PLC03", "DisConnected");
            deviceStatus.Add("PLC04", "STOP");

            foreach (var item in deviceStatus)
            {
                Console.WriteLine("Key: "+item.Key + " Value: " + item.Value);
            }

            if (deviceStatus.ContainsKey("PLC03"))
            {
                Console.WriteLine(deviceStatus["PLC03"]);
            }


            // nếu muốn tìm kiếm 1 chuỗi trong 1 danh sách toàn string thì 

            Dictionary<string, bool> deviceStatusV2 = new Dictionary<string, bool>();
            deviceStatusV2.Add("PLC01", true);
            deviceStatusV2.Add("PLC02", true);
            deviceStatusV2.Add("PLC03", true);
            deviceStatusV2.Add("PLC04", true);

            // chuỗi  "dfdsdsfs(dsfds)fdsf(dfvfdsg)(" có hay ko cụm "()"




        }
    }
}
