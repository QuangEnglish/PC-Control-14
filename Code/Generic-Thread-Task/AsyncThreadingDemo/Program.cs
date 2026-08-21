namespace AsyncThreadingDemo;

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║   DA LUONG & BAT DONG BO TRONG C#               ║");
        Console.WriteLine("║   Async / Await / Thread / Task                  ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝\n");

        bool running = true;
        while (running)
        {
            Console.WriteLine("========== MENU ==========");
            Console.WriteLine("  1. Phan 1 - Thread co ban (tao thread, Join)");
            Console.WriteLine("  2. Phan 2 - Race Condition & Lock / Interlocked");
            Console.WriteLine("  3. Phan 3 - Task Parallel Library (TPL)");
            Console.WriteLine("  4. Phan 4 - async / await co ban");
            Console.WriteLine("  5. Phan 5 - Task.WhenAll & Task.WhenAny");
            Console.WriteLine("  6. Phan 6 - CancellationToken (Huy tac vu)");
            Console.WriteLine("  7. Phan 7 - Nang cao (Semaphore, Channel, Parallel)");
            Console.WriteLine("  8. Phan 8 - Loi pho bien can tranh");
            Console.WriteLine("  0. Chay TAT CA cac phan");
            Console.WriteLine("  Q. Thoat");
            Console.WriteLine("==========================");
            Console.Write("Chon phan (1-8, 0, Q): ");

            string? choice = Console.ReadLine()?.Trim().ToUpper();
            Console.WriteLine();

            switch (choice)
            {
                case "1": Part1_ThreadBasic.Run(); break;
                case "2": Part2_RaceCondition.Run(); break;
                case "3": Part3_TaskTPL.Run(); break;
                case "4": await Part4_AsyncAwait.Run(); break;
                case "5": await Part5_TaskWhenAll.Run(); break;
                case "6": await Part6_CancellationToken.Run(); break;
                case "7": await Part7_Advanced.Run(); break;
                case "8": await Part8_CommonMistakes.Run(); break;
                case "0":
                    Part1_ThreadBasic.Run();
                    Part2_RaceCondition.Run();
                    Part3_TaskTPL.Run();
                    await Part4_AsyncAwait.Run();
                    await Part5_TaskWhenAll.Run();
                    await Part6_CancellationToken.Run();
                    await Part7_Advanced.Run();
                    await Part8_CommonMistakes.Run();
                    break;
                case "Q":
                    running = false;
                    Console.WriteLine("Tam biet! Nho:");
                    Console.WriteLine("*** Thread = tu lai xe, Task = di Grab, async/await = goi shipper ***\n");
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
