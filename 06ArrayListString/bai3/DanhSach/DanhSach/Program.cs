namespace DanhSach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Console.InputEncoding = System.Text.Encoding.UTF8;
            List<string> ThanhPho = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                ThanhPho.Add(Console.ReadLine());
            }
            ThanhPho.Sort();
            Console.WriteLine("Danh sach sau sap xep: ");
            foreach (string tp in ThanhPho)
            {
                Console.WriteLine(tp);
            }
            int idxHanoi = ThanhPho.IndexOf("Ha Noi");
            if (idxHanoi != -1)
            {
                ThanhPho.RemoveAt(idxHanoi);
                Console.WriteLine("Xoa bo thanh pho Ha Noi, them vao 5 thanh pho khac:");
                for (int i = 0; i < 5; i++)
                {
                    ThanhPho.Add(Console.ReadLine());
                }
                Console.WriteLine("Toan bo danh sach luc sau:");
                foreach (string tp in ThanhPho)
                {
                    Console.WriteLine(tp);
                }
            }


        }
    }
}
