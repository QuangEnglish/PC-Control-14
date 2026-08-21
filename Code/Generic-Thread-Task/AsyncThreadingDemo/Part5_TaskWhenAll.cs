namespace AsyncThreadingDemo;

/// <summary>
/// Phan 5: Task.WhenAll va Task.WhenAny
/// WhenAll = cho tat ca xong (goi 3 API cung luc, cho ca 3)
/// WhenAny = lay thang nhanh nhat (3 CDN server, ai nhanh lay truoc)
/// </summary>
static class Part5_TaskWhenAll
{
    public static async Task Run()
    {
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║  PHAN 5 - TASK.WHENALL & TASK.WHENANY   ║");
        Console.WriteLine("╚══════════════════════════════════════════╝\n");

        await Demo1_WhenAll();
        await Demo2_WhenAllVoiKetQua();
        await Demo3_WhenAny();
    }

    // --- Demo 1: WhenAll co ban ---
    static async Task Demo1_WhenAll()
    {
        Console.WriteLine("--- Demo 1: Task.WhenAll - Cho tat ca hoan thanh ---");
        var sw = System.Diagnostics.Stopwatch.StartNew();

        // 3 task chay SONG SONG, WhenAll cho ca 3 xong
        await Task.WhenAll(
            GiaLapCongViecAsync("Tai anh", 1000),
            GiaLapCongViecAsync("Xu ly data", 1500),
            GiaLapCongViecAsync("Gui email", 800)
        );

        sw.Stop();
        Console.WriteLine($"  => Tong: {sw.ElapsedMilliseconds}ms (chi bang task cham nhat ~1500ms, khong phai 3300ms!)\n");
    }

    // --- Demo 2: WhenAll voi ket qua tra ve ---
    static async Task Demo2_WhenAllVoiKetQua()
    {
        Console.WriteLine("--- Demo 2: WhenAll voi ket qua tra ve ---");
        Console.WriteLine("Gia lap goi 3 API cung luc:\n");

        // Tao 3 task, MOI task tra ve ket qua
        Task<string> taskUser = LayDuLieuAsync("User", 1000);
        Task<string> taskPost = LayDuLieuAsync("Post", 1500);
        Task<string> taskComment = LayDuLieuAsync("Comment", 800);

        // Cho tat ca xong CUNG LUC
        string[] results = await Task.WhenAll(taskUser, taskPost, taskComment);

        Console.WriteLine("  Ket qua:");
        foreach (string r in results)
            Console.WriteLine($"    - {r}");
        Console.WriteLine();
    }

    // --- Demo 3: WhenAny - Lay ket qua tu task nhanh nhat ---
    static async Task Demo3_WhenAny()
    {
        Console.WriteLine("--- Demo 3: Task.WhenAny - Lay ket qua nhanh nhat ---");
        Console.WriteLine("Gia lap 3 CDN server, lay data tu server nhanh nhat:\n");

        Task<string> cdnA = LayTuServerAsync("CDN-A (Tokyo)", 2000);
        Task<string> cdnB = LayTuServerAsync("CDN-B (Singapore)", 800);
        Task<string> cdnC = LayTuServerAsync("CDN-C (US)", 1500);

        // WhenAny tra ve task NHANH NHAT hoan thanh
        Task<string> taskNhanh = await Task.WhenAny(cdnA, cdnB, cdnC);
        string ketQua = await taskNhanh;

        Console.WriteLine($"  => Ket qua tu server nhanh nhat: {ketQua}\n");
    }

    // --- Helper methods ---
    static async Task GiaLapCongViecAsync(string tenViec, int ms)
    {
        Console.WriteLine($"  [{DateTime.Now:ss.fff}] Bat dau: {tenViec}");
        await Task.Delay(ms);
        Console.WriteLine($"  [{DateTime.Now:ss.fff}] Xong:    {tenViec} ({ms}ms)");
    }

    static async Task<string> LayDuLieuAsync(string loai, int ms)
    {
        Console.WriteLine($"  [{DateTime.Now:ss.fff}] Dang lay {loai}...");
        await Task.Delay(ms);
        Console.WriteLine($"  [{DateTime.Now:ss.fff}] Da lay xong {loai}!");
        return $"{loai}: du lieu thanh cong (mat {ms}ms)";
    }

    static async Task<string> LayTuServerAsync(string serverName, int ms)
    {
        await Task.Delay(ms); // Gia lap do tre mang
        return $"{serverName} phan hoi sau {ms}ms";
    }
}
