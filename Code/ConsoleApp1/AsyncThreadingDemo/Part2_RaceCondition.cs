namespace AsyncThreadingDemo;

/// <summary>
/// Phan 2: Race Condition va cach xu ly bang lock, Interlocked
/// Vi du: 2 nguoi rut tien ATM cung luc, flash sale chi con 1 san pham
/// </summary>
static class Part2_RaceCondition
{
    public static void Run()
    {
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║  PHAN 2 - RACE CONDITION & LOCK         ║");
        Console.WriteLine("╚══════════════════════════════════════════╝\n");

        Demo1_RaceCondition();
        Demo2_GiaiPhapLock();
        Demo3_GiaiPhapInterlocked();
        Demo4_ViDuATM();
    }

    // --- Demo 1: Race Condition - Ket qua sai khi khong dong bo ---
    static void Demo1_RaceCondition()
    {
        Console.WriteLine("--- Demo 1: Race Condition (KET QUA SAI!) ---");
        Console.WriteLine("2 thread cung tang bien soLuong 100,000 lan.");
        Console.WriteLine("Ky vong: 200,000. Thuc te: ???\n");

        int soLuong = 0;

        Thread t1 = new Thread(() =>
        {
            for (int i = 0; i < 100_000; i++)
                soLuong++; // KHONG AN TOAN! Doc -> +1 -> Ghi co the bi chen ngang
        });

        Thread t2 = new Thread(() =>
        {
            for (int i = 0; i < 100_000; i++)
                soLuong++;
        });

        t1.Start(); t2.Start();
        t1.Join(); t2.Join();

        Console.WriteLine($"  Ky vong:  200,000");
        Console.WriteLine($"  Thuc te:  {soLuong:N0}");
        Console.WriteLine($"  Bi mat:   {200_000 - soLuong:N0} lan tang!");
        Console.WriteLine("  => Race condition: 2 thread 'dua nhau' doc/ghi cung 1 bien\n");
    }

    // --- Demo 2: Giai phap Lock ---
    static void Demo2_GiaiPhapLock()
    {
        Console.WriteLine("--- Demo 2: Giai phap LOCK ---");
        Console.WriteLine("lock = phong chi co 1 chia khoa, thread nao vao thi khoa cua lai\n");

        int soLuong = 0;
        object _lock = new object();

        Thread t1 = new Thread(() =>
        {
            for (int i = 0; i < 100_000; i++)
            {
                lock (_lock) // Chi 1 thread duoc vao block nay tai 1 thoi diem
                {
                    soLuong++;
                }
            }
        });

        Thread t2 = new Thread(() =>
        {
            for (int i = 0; i < 100_000; i++)
            {
                lock (_lock)
                {
                    soLuong++;
                }
            }
        });

        t1.Start(); t2.Start();
        t1.Join(); t2.Join();

        Console.WriteLine($"  Ket qua voi lock: {soLuong:N0} (DUNG TUYET DOI!)");
        Console.WriteLine("  => lock giong quay giao dich ngan hang: 1 nguoi/lan, cham nhung khong sai\n");
    }

    // --- Demo 3: Giai phap Interlocked (nhanh hon lock) ---
    static void Demo3_GiaiPhapInterlocked()
    {
        Console.WriteLine("--- Demo 3: Giai phap INTERLOCKED (nhanh hon lock) ---");
        Console.WriteLine("Interlocked = phep toan nguyen tu, CPU dam bao khong bi chen ngang\n");

        int soLuong = 0;

        Thread t1 = new Thread(() =>
        {
            for (int i = 0; i < 100_000; i++)
                Interlocked.Increment(ref soLuong); // Atomic: doc+tang+ghi trong 1 buoc
        });

        Thread t2 = new Thread(() =>
        {
            for (int i = 0; i < 100_000; i++)
                Interlocked.Increment(ref soLuong);
        });

        t1.Start(); t2.Start();
        t1.Join(); t2.Join();

        Console.WriteLine($"  Ket qua voi Interlocked: {soLuong:N0} (DUNG TUYET DOI!)");
        Console.WriteLine("  => Interlocked nhanh hon lock vi khong can 'xep hang cho'\n");
    }

    // --- Demo 4: Vi du thuc te - Rut tien ATM ---
    static void Demo4_ViDuATM()
    {
        Console.WriteLine("--- Demo 4: Vi du thuc te - Rut tien ATM ---");

        // TRUONG HOP SAI: Khong dong bo
        Console.WriteLine("\n[Khong lock] 2 nguoi cung rut 700,000 tu tai khoan 1,000,000:");
        int soDu_KhongLock = 1_000_000;

        Thread nguoi1 = new Thread(() =>
        {
            int soTienRut = 700_000;
            if (soDu_KhongLock >= soTienRut) // Ca 2 deu thay "du tien"
            {
                Thread.Sleep(100); // Gia lap do tre xu ly
                soDu_KhongLock -= soTienRut;
                Console.WriteLine($"  Nguoi 1: Rut thanh cong {soTienRut:N0}");
            }
        });

        Thread nguoi2 = new Thread(() =>
        {
            int soTienRut = 700_000;
            if (soDu_KhongLock >= soTienRut) // Ca 2 deu thay "du tien"
            {
                Thread.Sleep(100);
                soDu_KhongLock -= soTienRut;
                Console.WriteLine($"  Nguoi 2: Rut thanh cong {soTienRut:N0}");
            }
        });

        nguoi1.Start(); nguoi2.Start();
        nguoi1.Join(); nguoi2.Join();
        Console.WriteLine($"  So du con lai: {soDu_KhongLock:N0} (AM TIEN! Ngan hang lo!)");

        // TRUONG HOP DUNG: Co lock
        Console.WriteLine("\n[Co lock] 2 nguoi cung rut 700,000 tu tai khoan 1,000,000:");
        int soDu_CoLock = 1_000_000;
        object atmLock = new object();

        Thread nguoi3 = new Thread(() =>
        {
            int soTienRut = 700_000;
            lock (atmLock)
            {
                if (soDu_CoLock >= soTienRut)
                {
                    Thread.Sleep(100);
                    soDu_CoLock -= soTienRut;
                    Console.WriteLine($"  Nguoi 1: Rut thanh cong {soTienRut:N0}");
                }
                else
                {
                    Console.WriteLine($"  Nguoi 1: KHONG DU TIEN! (so du: {soDu_CoLock:N0})");
                }
            }
        });

        Thread nguoi4 = new Thread(() =>
        {
            int soTienRut = 700_000;
            lock (atmLock)
            {
                if (soDu_CoLock >= soTienRut)
                {
                    Thread.Sleep(100);
                    soDu_CoLock -= soTienRut;
                    Console.WriteLine($"  Nguoi 2: Rut thanh cong {soTienRut:N0}");
                }
                else
                {
                    Console.WriteLine($"  Nguoi 2: KHONG DU TIEN! (so du: {soDu_CoLock:N0})");
                }
            }
        });

        nguoi3.Start(); nguoi4.Start();
        nguoi3.Join(); nguoi4.Join();
        Console.WriteLine($"  So du con lai: {soDu_CoLock:N0} (AN TOAN!)\n");
    }
}
