using System.Threading.Channels;

namespace AsyncThreadingDemo;

/// <summary>
/// Phan 7: Kien thuc nang cao
/// - SemaphoreSlim: Gioi han so task dong thoi (quay ban hang chi co 5 o phuc vu)
/// - Channel: Producer/Consumer (nha may san xuat -> kho hang -> nguoi mua)
/// - Parallel.ForEachAsync: Xu ly song song hien dai
/// </summary>
static class Part7_Advanced
{
    public static async Task Run()
    {
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║  PHAN 7 - KIEN THUC NANG CAO            ║");
        Console.WriteLine("╚══════════════════════════════════════════╝\n");

        await Demo1_SemaphoreSlim();
        await Demo2_Channel();
        await Demo3_ParallelForEach();
    }

    // --- Demo 1: SemaphoreSlim - Gioi han so luong dong thoi ---
    static async Task Demo1_SemaphoreSlim()
    {
        Console.WriteLine("--- Demo 1: SemaphoreSlim - Gioi han dong thoi ---");
        Console.WriteLine("Tai 10 file nhung toi da 3 file cung luc (tranh qua tai server)\n");

        // Cho phep toi da 3 tac vu dong thoi - giong quay ban hang chi co 3 o
        var semaphore = new SemaphoreSlim(initialCount: 3, maxCount: 3);
        var sw = System.Diagnostics.Stopwatch.StartNew();

        var tasks = Enumerable.Range(1, 10).Select(async fileId =>
        {
            await semaphore.WaitAsync(); // Cho "ve" trong
            try
            {
                Console.WriteLine($"  [{sw.ElapsedMilliseconds,5}ms] Bat dau tai file {fileId}...");
                await Task.Delay(1000); // Gia lap tai file mat 1 giay
                Console.WriteLine($"  [{sw.ElapsedMilliseconds,5}ms] Xong file {fileId}");
            }
            finally
            {
                semaphore.Release(); // Tra "ve" lai cho nguoi khac
            }
        });

        await Task.WhenAll(tasks);
        Console.WriteLine($"  => Tong thoi gian: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine("  => Neu khong gioi han: ~1000ms. Co gioi han 3: ~4000ms (an toan hon)\n");
    }

    // --- Demo 2: Channel - Producer/Consumer ---
    static async Task Demo2_Channel()
    {
        Console.WriteLine("--- Demo 2: Channel<T> - Producer/Consumer ---");
        Console.WriteLine("Nha may SAN XUAT banh -> Channel (bang chuyen) -> DONG GOI\n");

        // Tao channel voi suc chua 5 (bang chuyen chi chua 5 banh)
        var channel = Channel.CreateBounded<string>(capacity: 5);

        // Producer - Nha may san xuat banh
        var producer = Task.Run(async () =>
        {
            string[] loaiBanh = { "Banh mi", "Banh bao", "Banh cuon", "Banh xeo", "Banh trang",
                                  "Banh gio", "Banh da", "Banh canh" };

            foreach (string banh in loaiBanh)
            {
                await channel.Writer.WriteAsync(banh);
                Console.WriteLine($"  [SAN XUAT] Da lam: {banh}");
                await Task.Delay(300); // San xuat mat 300ms
            }
            channel.Writer.Complete(); // Bao "het hang de san xuat"
            Console.WriteLine("  [SAN XUAT] === DA LAM HET ===");
        });

        // Consumer - Dong goi (cham hon san xuat)
        var consumer = Task.Run(async () =>
        {
            await foreach (string banh in channel.Reader.ReadAllAsync())
            {
                Console.WriteLine($"  [DONG GOI] Dang goi: {banh}...");
                await Task.Delay(600); // Dong goi mat 600ms (cham hon san xuat)
                Console.WriteLine($"  [DONG GOI] Xong: {banh}");
            }
            Console.WriteLine("  [DONG GOI] === DA GOI HET ===");
        });

        await Task.WhenAll(producer, consumer);
        Console.WriteLine();
    }

    // --- Demo 3: Parallel.ForEachAsync ---
    static async Task Demo3_ParallelForEach()
    {
        Console.WriteLine("--- Demo 3: Parallel.ForEachAsync (.NET 6+) ---");
        Console.WriteLine("Xu ly 15 don hang song song, toi da 4 don cung luc\n");

        var donHangs = Enumerable.Range(1, 15).ToList();
        var sw = System.Diagnostics.Stopwatch.StartNew();

        await Parallel.ForEachAsync(donHangs,
            new ParallelOptions { MaxDegreeOfParallelism = 4 },
            async (donHang, token) =>
            {
                Console.WriteLine($"  [{sw.ElapsedMilliseconds,5}ms] Xu ly don hang #{donHang}...");
                await Task.Delay(500); // Gia lap xu ly
                Console.WriteLine($"  [{sw.ElapsedMilliseconds,5}ms] Xong don hang #{donHang}");
            });

        Console.WriteLine($"  => Tong thoi gian: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine("  => 15 don x 500ms = 7500ms tuan tu, nhung song song 4 chi mat ~2000ms!\n");
    }
}
