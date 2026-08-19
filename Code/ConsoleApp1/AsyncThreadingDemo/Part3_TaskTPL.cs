namespace AsyncThreadingDemo;

/// <summary>
/// Phan 3: Task Parallel Library (TPL) - Hien dai hon Thread
/// Thread = tu lai xe, Task = di Grab (tien, toi uu, it bug)
/// </summary>
static class Part3_TaskTPL
{
    public static void Run()
    {
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║  PHAN 3 - TASK PARALLEL LIBRARY (TPL)   ║");
        Console.WriteLine("╚══════════════════════════════════════════╝\n");

        Demo1_TaskCoBan();
        Demo2_TaskCoGiaTri();
        Demo3_SoSanhThreadVsTask();
    }

    // --- Demo 1: Task don gian ---
    static void Demo1_TaskCoBan()
    {
        Console.WriteLine("--- Demo 1: Task don gian ---");
        Console.WriteLine("Task.Run() = giao viec cho Thread Pool, khong can tu quan ly thread\n");

        // Tao task - giao viec cho doi dau bep co san (Thread Pool)
        Task task = Task.Run(() =>
        {
            Console.WriteLine($"  Task dang chay tren Thread Pool (Thread ID={Thread.CurrentThread.ManagedThreadId})");
            Thread.Sleep(1500);
            Console.WriteLine($"  Task da hoan thanh!");
        });

        Console.WriteLine($"  Main thread (ID={Thread.CurrentThread.ManagedThreadId}) van lam viec khac...");
        task.Wait(); // Cho task xong (tuong tu Join)
        Console.WriteLine();
    }

    // --- Demo 2: Task co gia tri tra ve ---
    static void Demo2_TaskCoGiaTri()
    {
        Console.WriteLine("--- Demo 2: Task<T> - Co gia tri tra ve ---");

        // Task<int> = cong viec se tra ve 1 so nguyen
        Task<int> taskTinh = Task.Run(() =>
        {
            Console.WriteLine("  Dang tinh tong 1 -> 100...");
            int tong = 0;
            for (int i = 1; i <= 100; i++)
                tong += i;
            Thread.Sleep(1000); // Gia lap xu ly
            return tong;
        });

        Task<string> taskChuoi = Task.Run(() =>
        {
            Thread.Sleep(800);
            return "Ket qua tu Task<string>!";
        });

        // .Result se cho task hoan thanh roi lay gia tri
        Console.WriteLine($"  Tong 1->100 = {taskTinh.Result}");
        Console.WriteLine($"  Chuoi: {taskChuoi.Result}\n");
    }

    // --- Demo 3: So sanh Thread vs Task ---
    static void Demo3_SoSanhThreadVsTask()
    {
        Console.WriteLine("--- Demo 3: So sanh Thread vs Task ---");
        int soLuongCongViec = 20;

        // Cach 1: Dung Thread thu cong (cu, nang ne)
        var sw = System.Diagnostics.Stopwatch.StartNew();
        Thread[] threads = new Thread[soLuongCongViec];
        for (int i = 0; i < soLuongCongViec; i++)
        {
            int idx = i;
            threads[i] = new Thread(() => Thread.Sleep(100));
            threads[i].Start();
        }
        foreach (var t in threads) t.Join();
        sw.Stop();
        Console.WriteLine($"  Thread thu cong ({soLuongCongViec} threads): {sw.ElapsedMilliseconds}ms");

        // Cach 2: Dung Task (hien dai, Thread Pool)
        sw.Restart();
        Task[] tasks = new Task[soLuongCongViec];
        for (int i = 0; i < soLuongCongViec; i++)
        {
            tasks[i] = Task.Run(() => Thread.Sleep(100));
        }
        Task.WaitAll(tasks);
        sw.Stop();
        Console.WriteLine($"  Task + Thread Pool ({soLuongCongViec} tasks):  {sw.ElapsedMilliseconds}ms");

        Console.WriteLine("  => Task tai su dung thread tu Pool, khong ton kem tao moi!\n");
    }
}
