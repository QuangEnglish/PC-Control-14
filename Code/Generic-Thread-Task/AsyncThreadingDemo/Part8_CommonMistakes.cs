namespace AsyncThreadingDemo;

/// <summary>
/// Phan 8: Nhung loi pho bien can tranh khi dung async/await
/// </summary>
static class Part8_CommonMistakes
{
    public static async Task Run()
    {
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║  PHAN 8 - LOI PHO BIEN CAN TRANH        ║");
        Console.WriteLine("╚══════════════════════════════════════════╝\n");

        Demo1_AsyncVoid();
        await Demo2_ResultVsAwait();
        await Demo3_QuenAwait();
        await Demo4_SharedStateKhongBaoVe();
    }

    // --- Loi 1: async void ---
    static void Demo1_AsyncVoid()
    {
        Console.WriteLine("--- Loi 1: async void (NGUY HIEM!) ---");
        Console.WriteLine(@"
  // SAI - Khong catch duoc exception, khong await duoc
  async void NguHiem()
  {
      await Task.Delay(1000);
      throw new Exception(); // Exception mat tich!
  }

  // DUNG - Luon dung async Task
  async Task AnToan()
  {
      await Task.Delay(1000);
      throw new Exception(); // Co the catch duoc
  }

  => Chi dung async void cho EVENT HANDLER (button click, v.v.)
");
    }

    // --- Loi 2: .Result / .Wait() gay deadlock ---
    static async Task Demo2_ResultVsAwait()
    {
        Console.WriteLine("--- Loi 2: .Result / .Wait() co the gay DEADLOCK ---");
        Console.WriteLine(@"
  // SAI - Co the deadlock trong UI/ASP.NET
  string data = LayDuLieuAsync().Result;  // Block thread!
  LayDuLieuAsync().Wait();                // Block thread!

  // DUNG - Luon dung await
  string data = await LayDuLieuAsync();   // Giai phong thread!
");

        // Demo an toan: so sanh thoi gian
        var sw = System.Diagnostics.Stopwatch.StartNew();

        // Dung cach: await
        await Task.Delay(100);
        Console.WriteLine($"  await Task.Delay(100): {sw.ElapsedMilliseconds}ms (khong block)");

        sw.Restart();
        // Sai cach: .Wait() - block thread
        Task.Delay(100).Wait();
        Console.WriteLine($"  Task.Delay(100).Wait(): {sw.ElapsedMilliseconds}ms (block thread!)");
        Console.WriteLine("  => Ca 2 deu mat ~100ms nhung .Wait() BLOCK thread, cuc ky nguy hiem trong UI\n");
    }

    // --- Loi 3: Quen await ---
    static async Task Demo3_QuenAwait()
    {
        Console.WriteLine("--- Loi 3: Quen await - Fire and forget ---");
        Console.WriteLine(@"
  // SAI - Task chay nen, khong biet loi
  LayDuLieuAsync();  // WARNING: khong await!

  // DUNG - Luon await
  await LayDuLieuAsync();

  // Neu co y fire-and-forget, xu ly exception:
  _ = LayDuLieuAsync().ContinueWith(
      t => Console.WriteLine(t.Exception),
      TaskContinuationOptions.OnlyOnFaulted);
");

        // Demo: Task khong await se chay nen
        Console.WriteLine("  Demo: Tao task nhung KHONG await:");
        Task khongAwait = Task.Run(async () =>
        {
            await Task.Delay(500);
            Console.WriteLine("  [Task nen] Toi chay xong roi nhung khong ai biet!");
        });

        Console.WriteLine("  Main tiep tuc ngay lap tuc, khong cho task...");
        await khongAwait; // Trong demo phai await de thay ket qua
        Console.WriteLine();
    }

    // --- Loi 4: Shared state khong bao ve ---
    static async Task Demo4_SharedStateKhongBaoVe()
    {
        Console.WriteLine("--- Loi 4: Shared state khong bao ve (Race condition voi Task) ---");

        // SAI: nhieu task truy cap cung 1 bien
        int dem_SAI = 0;
        await Task.WhenAll(
            Enumerable.Range(0, 1000).Select(_ => Task.Run(() => dem_SAI++))
        );
        Console.WriteLine($"  [SAI]  dem++ voi 1000 task: {dem_SAI} (ky vong 1000)");

        // DUNG: dung Interlocked
        int dem_DUNG = 0;
        await Task.WhenAll(
            Enumerable.Range(0, 1000).Select(_ => Task.Run(() => Interlocked.Increment(ref dem_DUNG)))
        );
        Console.WriteLine($"  [DUNG] Interlocked.Increment voi 1000 task: {dem_DUNG} (luon dung!)");

        Console.WriteLine("\n  => TOM TAT LOI PHO BIEN:");
        Console.WriteLine("  1. async void  -> Dung async Task");
        Console.WriteLine("  2. .Result/.Wait() -> Dung await");
        Console.WriteLine("  3. Quen await  -> Luon await hoac xu ly exception");
        Console.WriteLine("  4. Shared state -> Dung lock/Interlocked\n");
    }
}
