namespace AsyncThreadingDemo;

/// <summary>
/// Phan 1: Thread co ban - Tao thread thu cong voi System.Threading
/// Vi du nha hang: Thread = nhan vien phuc vu, Main Thread = quan ly
/// </summary>
static class Part1_ThreadBasic
{
    public static void Run()
    {
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║  PHAN 1 - THREAD CO BAN                 ║");
        Console.WriteLine("╚══════════════════════════════════════════╝\n");

        Demo1_TaoThread();
        Demo2_ThreadVoiThamSo();
        Demo3_JoinThread();
    }

    // --- Demo 1: Tao thread don gian ---
    static void Demo1_TaoThread()
    {
        Console.WriteLine("--- Demo 1: Tao Thread don gian ---");
        Console.WriteLine($"[Main Thread ID={Thread.CurrentThread.ManagedThreadId}] Bat dau chuong trinh");

        // Tao thread moi - giong nhu thue them 1 nhan vien
        Thread t = new Thread(LamViecNang);
        t.Name = "WorkerThread";
        t.Start();

        // Main thread van tiep tuc chay - quan ly khong dung cho
        Console.WriteLine($"[Main Thread ID={Thread.CurrentThread.ManagedThreadId}] Toi van dang chay!");
        Console.WriteLine($"[Main Thread ID={Thread.CurrentThread.ManagedThreadId}] Lam viec khac trong khi cho...");

        t.Join(); // Cho thread kia xong - quan ly chờ nhan vien lam xong
        Console.WriteLine($"[Main Thread ID={Thread.CurrentThread.ManagedThreadId}] Tat ca da xong!\n");
    }

    static void LamViecNang()
    {
        Console.WriteLine($"  [Worker Thread ID={Thread.CurrentThread.ManagedThreadId}] Bat dau lam viec nang...");
        Thread.Sleep(2000); // Gia lap cong viec mat 2 giay
        Console.WriteLine($"  [Worker Thread ID={Thread.CurrentThread.ManagedThreadId}] Xong roi!");
    }

    // --- Demo 2: Thread voi tham so ---
    static void Demo2_ThreadVoiThamSo()
    {
        Console.WriteLine("--- Demo 2: Thread voi tham so ---");

        // Cach 1: Dung lambda de truyen tham so
        Thread t1 = new Thread(() => InThongBao("Xin chao từ Thread 1!", 3));
        t1.Start();

        // Cach 2: Dung ParameterizedThreadStart
        Thread t2 = new Thread(obj =>
        {
            string msg = (string)obj!;
            Console.WriteLine($"  [Thread ID={Thread.CurrentThread.ManagedThreadId}] Nhan duoc: {msg}");
        });
        t2.Start("Du lieu truyen vao thread 2");

        t1.Join();
        t2.Join();
        Console.WriteLine();
    }

    static void InThongBao(string message, int soLan)
    {
        for (int i = 0; i < soLan; i++)
        {
            Console.WriteLine($"  [Thread ID={Thread.CurrentThread.ManagedThreadId}] Lan {i + 1}: {message}");
            //Thread.Sleep(100);
        }
    }

    // --- Demo 3: Join - cho thread hoan thanh ---
    static void Demo3_JoinThread()
    {
        Console.WriteLine("--- Demo 3: Join - Cho thread hoan thanh ---");
        Console.WriteLine("Tao 3 thread chay song song:");

        Thread[] threads = new Thread[3];
        for (int i = 0; i < 3; i++)
        {
            int index = i; // QUAN TRONG: capture bien local, khong dung i truc tiep
            threads[i] = new Thread(() =>
            {
                Console.WriteLine($"  Thread {index} bat dau (ID={Thread.CurrentThread.ManagedThreadId})");
                Thread.Sleep(1000 * (index + 1)); // Thread 0: 1s, Thread 1: 2s, Thread 2: 3s
                Console.WriteLine($"  Thread {index} XONG (mat {index + 1} giay)");
            });
            threads[i].Start();
        }
        
        // 10 batch, mỗi batch là 10 000 thread
        // 5 batch vào 1 , 2 lần là xong
        // 5 batch đầu tiên vào, lỗi batch thứ 4
        // batch thứ 4 ra ngoài chiỉnh sửa, đồng thời 5 batch sau vào
        // batch thứ 3 chết, batch 4 vào,
        // batch thứ 3 vào
        // xong
        

        // Cho TAT CA thread hoan thanh
        foreach (var t in threads)
            t.Join();

        Console.WriteLine("=> Tat ca 3 thread da hoan thanh!\n");
    }
}
