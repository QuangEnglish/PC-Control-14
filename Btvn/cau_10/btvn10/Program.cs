// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("nhập số lượng học sinh");
        int n = int.Parse(Console.ReadLine());
        double[] diem = new double[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"nhập điểm từng học sinh {i + 1}");
            diem[i] = int.Parse(Console.ReadLine());
        }
        int gioi = 0;
        int kha = 0;
        int trungbinh = 0;
        int yeu = 0;
        for (int i = 0; i < n; i++)
        {
            if (diem[i] >= 8)
            {
                gioi++;
            }
            else if (diem[i] >= 6.5)
            {
                kha++;
            }
            else if (diem[i] >= 5)
            {
                trungbinh++;
            }
            else
            {
                yeu++;
            }

        }
        Console.WriteLine("\nKết quả phân loại:");
        Console.WriteLine($"Giỏi: {gioi}");
        Console.WriteLine($"Khá: {kha}");
        Console.WriteLine($"Trung bình: {trungbinh}");
        Console.WriteLine($"Yếu: {yeu}");
    }
}
