namespace MoPhongDayChuyen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap vao so luong san pham: ");
            int soLuongSanPham = Convert.ToInt32(Console.ReadLine());
            Queue<string> qDayChuyen = new Queue<string>();
            for (int i = 0; i < soLuongSanPham; i++)
            {
                qDayChuyen.Enqueue(Console.ReadLine());
            }
            while (qDayChuyen.Count > 0)
            {
                Console.WriteLine("Dang xu ly: " + qDayChuyen.Dequeue());
            }
        }
    }
}
