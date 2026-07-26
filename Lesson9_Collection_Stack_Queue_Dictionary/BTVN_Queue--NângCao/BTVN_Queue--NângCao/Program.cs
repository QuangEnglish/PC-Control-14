namespace BTVN_Queue__NângCao
{
    


    class BenhNhan
    {
        public string Ten;
        public int UuTien;
    }

    class EmergencyQueue
    {
        
        // Quy ước mức ưu tiên
        private const int CAO = 1;
        private const int TRUNG_BINH = 2;
        private const int THAP = 3;

        private Queue<BenhNhan> high = new Queue<BenhNhan>();
        private Queue<BenhNhan> medium = new Queue<BenhNhan>();
        private Queue<BenhNhan> low = new Queue<BenhNhan>();

        // Thêm bệnh nhân
        public void Enqueue(BenhNhan bn)
        {
            
            if (bn.UuTien == CAO)
            {
                high.Enqueue(bn);
            }
            else if (bn.UuTien == TRUNG_BINH)
            {
                medium.Enqueue(bn);
            }
            else if (bn.UuTien == THAP)
            {
                low.Enqueue(bn);
            }
            else
            {
                Console.WriteLine("Mức ưu tiên không hợp lệ!");
            }
        }

        // Gọi bệnh nhân tiếp theo
        public BenhNhan Dequeue()
        {
            if (high.Count > 0)
                return high.Dequeue();

            if (medium.Count > 0)
                return medium.Dequeue();

            if (low.Count > 0)
                return low.Dequeue();

            return null;
        }
    }

    class Program
    {
        static void Main()
        {
            EmergencyQueue queue = new EmergencyQueue();

            while (true)
            {
                Console.Write("\nNhập tên bệnh nhân (exit để kết thúc): ");
                string ten = Console.ReadLine();

                if (ten.ToLower() == "exit")
                    break;

                Console.WriteLine("Chọn mức ưu tiên:");
                Console.WriteLine("1. Cao");
                Console.WriteLine("2. Trung bình");
                Console.WriteLine("3. Thấp");
                Console.Write("Nhập lựa chọn: ");

                int uuTien = int.Parse(Console.ReadLine());

                BenhNhan bn = new BenhNhan();
                bn.Ten = ten;
                bn.UuTien = uuTien;

                queue.Enqueue(bn);
            }

            Console.WriteLine("\n===== DANH SÁCH GỌI KHÁM =====");

            BenhNhan benhNhan;

            while ((benhNhan = queue.Dequeue()) != null)
            {
                Console.WriteLine($"{benhNhan.Ten} - Ưu tiên {benhNhan.UuTien}");
            }
        }
    }
}
