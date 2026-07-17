namespace Chuoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Bài 2 - câu a
            Console.WriteLine("Cau a: Nhap vao mot chuoi: ");
            string chuoi = Console.ReadLine();
            foreach (char kyTu in chuoi)
            {
                Console.WriteLine(kyTu);
            }
            Console.WriteLine("Da hien thi ky tu tren tung dong");

            // Bài 2 - câu b
            Console.WriteLine("\nCau b: Nhap chuoi gom ky tu va khoang trang: ");
            string chuoiV2 = Console.ReadLine();
            foreach (char kyTu in chuoiV2)
            {
                if(kyTu != ' ') Console.WriteLine(kyTu);
            }
            Console.WriteLine("Da bo khoang trang va hien thi ky tu tren tung dong");

            // Bài 2 - câu c
            Console.WriteLine("\nCau c: Nhap chuoi gom ky tu va khoang trang: ");
            string chuoiV3 = Console.ReadLine();
            foreach (char kyTu in chuoiV3)
            {
                if (kyTu != ' ') Console.WriteLine(kyTu);
            }
            Console.WriteLine("Da hien thi ky tu tren tung dong");
        }
    }
}
