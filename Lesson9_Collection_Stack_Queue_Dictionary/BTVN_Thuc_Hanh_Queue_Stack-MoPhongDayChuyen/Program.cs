using System.Collections;

namespace BTVN_Thuc_Hanh_Queue_Stack_MoPhongDayChuyen
{
    internal class Program
    {
        static void TenSanPham(Queue<string> a,string s)
        {

            a.Enqueue(s);
        }
        static void Main(string[] args)
        {
            Queue<string> sanPham = new Queue<string>();

            while (true)
            {
                Console.Write("Nhap tên sảm phầm xong nhập 'exit': ");
                string s = Console.ReadLine();
                if (s == "exit") break;

                TenSanPham(sanPham, s);
            }

            while(sanPham.Count > 0)
            {
                Console.WriteLine(sanPham.Dequeue());
            }
            //Console.WriteLine(sanPham.Dequeue());
            //Console.WriteLine("Hello, World!");
        }
    }
}
