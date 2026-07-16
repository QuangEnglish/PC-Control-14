namespace Quan_li_danh_sach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>() { "Anh", "Binh", "Cuong", "Dung", "Huy", "Lan" };
            Console.WriteLine($"So luong phan tu: {names.Count}");
            foreach (var i in names)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-------------------------------------");

            names.Insert(2, "Khanh");
            Console.WriteLine("Danh sach sau khi chen: ");
            foreach (var i in names)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-------------------------------------");
            names.Remove("Huy");
            Console.WriteLine("Danh sach sau khi xoa ten Huy: ");
            foreach (var i in names)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-------------------------------------");
            names.Sort();
            Console.WriteLine("Danh sach sau khi Sort: ");
            foreach (var i in names)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-------------------------------------");
            names.Reverse();
            Console.WriteLine("Danh sach sau khi Reverse: ");
            foreach (var i in names)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-------------------------------------");
            bool bCheck = names.Contains("Anh");
            if (bCheck == true)
            {
                Console.WriteLine("Tim thay Anh");
            }
            else
            {
                Console.WriteLine("Khong tim thay Anh");
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Nhap mot ten tu ban phim: ");
            string sName = Console.ReadLine();
            bool bCheckV2 = names.Contains(sName);
            if (bCheckV2) Console.WriteLine("Ten da ton tai.");
            else
            {
                names.Add(sName);
                Console.WriteLine("Da them thanh cong.");
            }
            foreach (var i in names)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-------------------------------------");
        }
    }
}
