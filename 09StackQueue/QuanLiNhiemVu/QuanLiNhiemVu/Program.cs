namespace QuanLiNhiemVu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> qTask = new Queue<string>();
            string s = "";
            Console.WriteLine("Nhap vao nhiem vu can xu li");
            while (true)
            {
                s = Console.ReadLine();
                if (s == "-1") break;
                else
                {
                    qTask.Enqueue(s);
                    string sV2 = qTask.Dequeue();
                    Console.WriteLine("Dang xu li " + sV2);
                }
            }
            

        }
    }
}
