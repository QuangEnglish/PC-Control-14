namespace AsyncThreadingDemo;

/// <summary>
/// Phan 6: CancellationToken - Huy tac vu dang chay
/// Giong nhu bam nut "Huy don" khi dat Grab ma cho lau qua
/// </summary>
static class Part6_CancellationToken
{
    public static async Task Run()
    {
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║  PHAN 6 - CANCELLATION TOKEN            ║");
        Console.WriteLine("╚══════════════════════════════════════════╝\n");

        await Demo1_HuySau3Giay();
        await Demo2_HuyBangTay();
        await Demo3_TimeoutChoAPI();
    }

    // --- Demo 1: Tu dong huy sau 3 giay ---
    static async Task Demo1_HuySau3Giay()
    {
        Console.WriteLine("--- Demo 1: Tu dong huy sau 3 giay ---");

        using var cts = new CancellationTokenSource();
        cts.CancelAfter(TimeSpan.FromSeconds(3)); // Tu dong huy sau 3s

        try
        {
            await CongViecDaiHoiAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("  => TAC VU DA BI HUY sau 3 giay!\n");
        }
    }

    static async Task CongViecDaiHoiAsync(CancellationToken token)
    {
        for (int i = 1; i <= 10; i++)
        {
            // Kiem tra co bi yeu cau huy khong
            token.ThrowIfCancellationRequested();

            Console.WriteLine($"  Dang xu ly buoc {i}/10...");
            await Task.Delay(1000, token); // Delay cung ho tro token
        }
        Console.WriteLine("  Hoan thanh tat ca 10 buoc!");
    }

    // --- Demo 2: Huy bang tay (nguoi dung bam phim) ---
    static async Task Demo2_HuyBangTay()
    {
        Console.WriteLine("--- Demo 2: Huy bang tay ---");
        Console.WriteLine("  Nhan phim bat ky de huy cong viec...\n");

        using var cts = new CancellationTokenSource();

        // Task chay cong viec
        Task congViec = Task.Run(async () =>
        {
            int dem = 0;
            while (!cts.Token.IsCancellationRequested)
            {
                dem++;
                Console.WriteLine($"  Dang lam viec... (lan {dem})");
                try
                {
                    await Task.Delay(500, cts.Token);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
            Console.WriteLine($"  Cong viec dung lai sau {dem} lan!");
        });

        // Cho 3 giay roi tu dong huy (thay vi doi bam phim trong demo)
        await Task.Delay(3000);
        cts.Cancel(); // Gui tin hieu huy

        await congViec;
        Console.WriteLine("  => Da huy thanh cong!\n");
    }

    // --- Demo 3: Timeout cho API call ---
    static async Task Demo3_TimeoutChoAPI()
    {
        Console.WriteLine("--- Demo 3: Timeout cho API call ---");

        // Gia lap API cham (mat 5 giay), nhung ta chi cho toi da 2 giay
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));

        try
        {
            Console.WriteLine("  Goi API (timeout 2 giay)...");
            string result = await GiaLapAPIChamAsync(cts.Token);
            Console.WriteLine($"  Ket qua: {result}");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("  => API TIMEOUT! Qua 2 giay khong co phan hoi.");
            Console.WriteLine("  => Thuc te: hien thong bao loi cho nguoi dung hoac thu lai\n");
        }
    }

    static async Task<string> GiaLapAPIChamAsync(CancellationToken token)
    {
        await Task.Delay(5000, token); // Gia lap API mat 5 giay
        return "Du lieu tu API";
    }
}
