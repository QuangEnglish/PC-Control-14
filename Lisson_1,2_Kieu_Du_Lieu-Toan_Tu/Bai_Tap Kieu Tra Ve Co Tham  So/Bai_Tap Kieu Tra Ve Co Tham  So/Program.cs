using System.ComponentModel.DataAnnotations;

namespace Bai_Tap_Kieu_Tra_Ve_Co_Tham__So
{
    internal class Program
    {
        static int SoNguyen(int arrNumber)
        {
            int[] arrNumberv1 = new int[arrNumber];
            int max = 0;
            for (int i = 0; i < arrNumberv1.Length; i++)
            {
                Console.WriteLine($"Nhap gia tri phan tu so {i}:");
                arrNumberv1[i] = Convert.ToInt32(Console.ReadLine());
            
                if(max < arrNumberv1[i])
                {
                    max = arrNumberv1[i];
                }
                
            }
            return max;
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Nhap so phan tu mang :");
            int arrNumber1 = Convert.ToInt32(Console.ReadLine());
            int kqua = SoNguyen(arrNumber1);
            Console.WriteLine("So lon nhat trong mang la :"+kqua);


            // Bài LIST

            List<int> numberList = new List<int>(); // list rỗng chưa có phần tử nào

            numberList.Add(1);
            numberList.Add(-8);
            numberList.Add(900);
            numberList.Add(3669656);

            // tạo 1 list từ 1 mảng có sẵn 
            string[] authors = { "Ân", "Khánh", "Thanh", "Phi" };
            List<string> authorListV2 = new List<string>(authors);

            // số phần tử trong list
            Console.WriteLine("Số phần tử trong List :" + authorListV2);

            // tìm kiếm trong list
            bool checkAn = authorListV2.Contains("Ân");
            if (checkAn)
            {
                Console.WriteLine("Có trong list");
            }
            else
            {
                Console.WriteLine("Không có trong list");
            }

            // sắp xếp 
            authorListV2.Sort();

            // đảo ngược
            authorListV2.Reverse();
            foreach (string author in authorListV2)
            {
                Console.WriteLine("Phần tử đảo:" + author);
            }

            // xóa dữ liệu
            authorListV2.Remove("Thanh");
            Console.WriteLine("Phần tử sau khi xóa:");
            foreach (string author in authorListV2)
            {

                Console.WriteLine("Phần tử sau khi xóa:" + author);
            }


                //Console.WriteLine("Hello, World!");
            }
    }
}
