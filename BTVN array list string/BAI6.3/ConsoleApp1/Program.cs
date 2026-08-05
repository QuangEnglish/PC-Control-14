namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> ThanhPho = new List<string>();

            ThanhPho.Add("Ha Noi");
            ThanhPho.Add("TP. Ho Chi Minh");
            ThanhPho.Add("Hai Phong");
            ThanhPho.Add("Da Nang");
            ThanhPho.Add("Can Tho");

            ThanhPho.Sort();
            foreach (string tp in ThanhPho)
            {
                Console.WriteLine(tp);
            }

            ThanhPho.Remove("Ha Noi");

            ThanhPho.Add("Nha Trang");
            ThanhPho.Add("Hue");
            ThanhPho.Add("Da Lat");
            ThanhPho.Add("Vung Tau");
            ThanhPho.Add("Ha Long");

            foreach (string tp in ThanhPho)
            {
                Console.WriteLine(tp);
            }

            Console.ReadLine();
        }
    }
}
