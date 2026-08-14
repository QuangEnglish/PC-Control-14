using System.Xml;

namespace NguyenXuanThanh_proj61
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Person thanh = new Person();
            thanh.Id = 1;
            thanh.Name = "Nguyen Xuan Thanh";
            thanh.Address = "15 Van Don";
            
            thanh.Output();

        }
    }
}
