namespace BAI_6._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> ds = new List<string>();

            ds.Add("Anh");
            ds.Add("Binh");
            ds.Add("Cuong");
            ds.Add("Dung");
            ds.Add("Huy");
            ds.Add("Lan");

            Console.WriteLine(ds.Count);

            foreach (string name in ds)
            {
                Console.WriteLine(name);
            }

            ds.Insert(2, "Nam");

            foreach (string name in ds)
            {
                Console.WriteLine(name);
            }

            ds.Remove("Huy");

            foreach (string name in ds)
            {
                Console.WriteLine(name);
            }

            ds.Sort();

            foreach (string name in ds)
            {
                Console.WriteLine(name);
            }

            ds.Reverse();

            foreach (string name in ds)
            {
                Console.WriteLine(name);
            }

            if (ds.Contains("Anh"))
            {
                Console.WriteLine("Tim thay");
            }
            else
            {
                Console.WriteLine("Khong tim thay");
            }

            Console.Write("Nhap vao mot ten: ");
            string tenNhap = Console.ReadLine();

            if (ds.Contains(tenNhap))
            {
                Console.WriteLine("Ten da ton tai");
            }
            else
            {
                ds.Add(tenNhap);
                Console.WriteLine("Da them thanh cong");
            }

            Console.ReadLine();
        }
    }
}
