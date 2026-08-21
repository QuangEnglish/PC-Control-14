namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║   BUOI 2 - GENERIC TYPES TRONG C#       ║");
        Console.WriteLine("║   Giao an day du voi vi du minh hoa     ║");
        Console.WriteLine("╚══════════════════════════════════════════╝\n");

        bool running = true;
        while (running)
        {
            Console.WriteLine("========== MENU ==========");
            Console.WriteLine("  2. Phan 2 - Van de truoc khi co Generic (Duplicate Code)");
            Console.WriteLine("  3. Phan 3 - Giai phap cu: dung Object (Boxing/Unboxing)");
            Console.WriteLine("  4. Phan 4 - Generic la gi? Box<T> (Hop than ky)");
            Console.WriteLine("  5. Phan 5 - Generic Method (Swap, FindFirst, ConvertAll)");
            Console.WriteLine("  6. Phan 6 - Generic Constraints (where T : ...)");
            Console.WriteLine("  7. Phan 7 - Generic trong .NET (List, Dictionary, LINQ)");
            Console.WriteLine("  8. Phan 8 - Bai tap thuc hanh (GiftBox, FindMax, Repository)");
            Console.WriteLine("  0. Chay TAT CA cac phan");
            Console.WriteLine("  Q. Thoat");
            Console.WriteLine("==========================");
            Console.Write("Chon phan (2-8, 0, Q): ");

            string? choice = Console.ReadLine()?.Trim().ToUpper();
            Console.WriteLine();

            switch (choice)
            {
                case "2": Part2_Demo.Run(); break;
                case "3": Part3_Demo.Run(); break;
                case "4": Part4_Demo.Run(); break;
                case "5": Part5_Demo.Run(); break;
                case "6": Part6_Demo.Run(); break;
                case "7": Part7_Demo.Run(); break;
                case "8": Part8_Demo.Run(); break;
                case "0":
                    Part2_Demo.Run();
                    Part3_Demo.Run();
                    Part4_Demo.Run();
                    Part5_Demo.Run();
                    Part6_Demo.Run();
                    Part7_Demo.Run();
                    Part8_Demo.Run();
                    break;
                case "Q":
                    running = false;
                    Console.WriteLine("Tam biet! Nho cau than chu:");
                    Console.WriteLine("*** Generic giong cai KHUON BANH - chi 1 khuon nhung lam duoc moi loai banh! ***\n");
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le! Vui long chon lai.\n");
                    break;
            }

            if (running && choice != null && choice != "Q")
            {
                Console.WriteLine("Nhan Enter de tiep tuc...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
