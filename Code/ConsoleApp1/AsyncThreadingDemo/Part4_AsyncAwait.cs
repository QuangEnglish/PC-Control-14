namespace AsyncThreadingDemo;

/// <summary>
/// Phan 4: async/await - Trai tim cua lap trinh hien dai C#
/// await = "dat viec xong roi di lam viec khac, khi co ket qua thi quay lai"
/// Giong goi shipper: dat do an -> lam viec khac -> shipper toi thi nhan
/// </summary>
static class Part4_AsyncAwait
{
    public static async Task Run()
    {
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║  PHAN 4 - ASYNC / AWAIT CO BAN          ║");
        Console.WriteLine("╚══════════════════════════════════════════╝\n");

        await Demo1_AsyncCoBan();
        await Demo2_SoSanhSyncVsAsync();
        await Demo3_AsyncVoiHttpClient();
    }

    // --- Demo 1: async/await co ban ---
    static async Task Demo1_AsyncCoBan()
    {
        Console.WriteLine("--- Demo 1: async/await co ban ---");
        Console.WriteLine("await = giai phong thread, khong block!\n");

        Console.WriteLine($"  [{DateTime.Now:ss.fff}] Truoc await - Thread ID={Thread.CurrentThread.ManagedThreadId}");

        // await Task.Delay KHONG block thread (khac voi Thread.Sleep)
        await Task.Delay(2000); // Cho 2 giay nhung KHONG chiem thread

        Console.WriteLine($"  [{DateTime.Now:ss.fff}] Sau await  - Thread ID={Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine("  => Thread co the thay doi sau await (Thread Pool gan thread khac)\n");
    }

    // --- Demo 2: So sanh Sync vs Async ---
    static async Task Demo2_SoSanhSyncVsAsync()
    {
        Console.WriteLine("--- Demo 2: So sanh Dong bo vs Bat dong bo ---");

        // Dong bo (Sync) - nau an xong mon 1 moi nau mon 2
        Console.WriteLine("\n  [DONG BO] Nau 3 mon an tuan tu:");
        var sw = System.Diagnostics.Stopwatch.StartNew();

        NauMonAnSync("Pho", 1000);
        NauMonAnSync("Bun cha", 1500);
        NauMonAnSync("Com rang", 800);

        sw.Stop();
        Console.WriteLine($"  => Tong thoi gian DONG BO: {sw.ElapsedMilliseconds}ms\n");

        // Bat dong bo (Async) - 3 bep nau cung luc
        Console.WriteLine("  [BAT DONG BO] Nau 3 mon an song song:");
        sw.Restart();

        Task t1 = NauMonAnAsync("Pho", 1000);
        Task t2 = NauMonAnAsync("Bun cha", 1500);
        Task t3 = NauMonAnAsync("Com rang", 800);
        await Task.WhenAll(t1, t2, t3); // Cho tat ca xong

        sw.Stop();
        Console.WriteLine($"  => Tong thoi gian BAT DONG BO: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine("  => Nhanh hon nhieu vi 3 mon nau cung luc!\n");
    }

    static void NauMonAnSync(string tenMon, int thoiGianMs)
    {
        Console.WriteLine($"    Bat dau nau: {tenMon}");
        Thread.Sleep(thoiGianMs); // Block thread
        Console.WriteLine($"    Xong: {tenMon} ({thoiGianMs}ms)");
    }

    static async Task NauMonAnAsync(string tenMon, int thoiGianMs)
    {
        Console.WriteLine($"    Bat dau nau: {tenMon}");
        await Task.Delay(thoiGianMs); // KHONG block thread
        Console.WriteLine($"    Xong: {tenMon} ({thoiGianMs}ms)");
    }

    // --- Demo 3: Async voi HttpClient (goi API that) ---
    static async Task Demo3_AsyncVoiHttpClient()
    {
        Console.WriteLine("--- Demo 3: Goi API bat dong bo voi HttpClient ---");

        using HttpClient client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(10);

        try
        {
            Console.WriteLine($"  [{DateTime.Now:ss.fff}] Bat dau goi API...");

            // await = gui request roi giai phong thread, khi co response moi tiep tuc
            string data = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/1");

            Console.WriteLine($"  [{DateTime.Now:ss.fff}] Da nhan du lieu!");
            Console.WriteLine($"  Du lieu (100 ky tu dau): {data[..Math.Min(100, data.Length)]}...");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"  Loi ket noi: {ex.Message}");
            Console.WriteLine("  (Can ket noi internet de chay demo nay)");
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("  Request bi timeout!");
        }
        Console.WriteLine();
    }
}
