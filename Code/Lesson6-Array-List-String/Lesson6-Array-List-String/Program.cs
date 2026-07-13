namespace Lesson6_Array_List_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Mảng - Array
            // Là 1 cấu trúc dữ liệu
            // lưu nhiều giá trị
            // có cùng kiểu dữ liệu
            // được đặt tại 1 biến duy nhất

            // đặc điểm:
            // mảng có kích thước cố định
            // mảng là reference type
            // index bắt đầu từ đâu: 0

            // Khởi tạo mảng
            //int[] arrNumber = new int[5];  // mảng này đang khai báo 5 vùng nhớ
            //arrNumber[0] = 1;
            //arrNumber[2] = 5;
            //arrNumber[3] = 9;
            ////arrNumber[5] = 10;  // sai

            //int[] arrNumberV2 = new int[5] { 1, 0, 5, 9, 6 };
            //int[] arrNumberV3 = { 1, 0, 5, 9, 6 };

            //for (int i = 0; i < arrNumber.Length; i++)
            //{
            //    Console.WriteLine("Phần tử lần lượt là: " + arrNumber[i]);
            //}

            //int a, b, c, d;
            //int[] arr = new int [5];

            //// Tạo 1 mảng gồm 5 số nguyên
            //// Yêu cầu viết hàm trả về giá trị và có tham số,
            //// tìm ra số lớn nhất trong mảng
            //// 

            //// Mảng 2 chiều
            //int[,] numbers =
            //{
            //    { 1, 0, 2 },
            //    { 3, 4, 5 },
            //    { 5, 6, 7  }
            //};

            //Console.WriteLine(numbers[0,0]);
            //Console.WriteLine(numbers[1,1]);  // 
            //Console.WriteLine(numbers[1,2]);  // số thứ tự hàng, số thứ tự cột

            //for (int i = 0; i < numbers.GetLength(0); i++)
            //{
            //    for (int j = 0; j < numbers.GetLength(1); j++)
            //    {
            //        Console.Write(numbers[i, j]+"\t");
            //    }
            //    Console.WriteLine();
            //}

            // List

            // kích thước linh hoạt, là tập dữ liệu động
            // có index giống Array
            // 
            List<int> numberList = new List<int>();  // List rỗng, chưa có phần tử nào
            numberList.Add(1);
            numberList.Add(-8);
            numberList.Add(100);
            numberList.Add(39040);

            // tạo list từ 1 mảng có sẵn
            string[] authors = { "Ân", "Khánh", "Thanh", "Phi" };
            List<string> authorListV2 = new List<string>(authors);
            //
            // số phần tử trong list
            Console.WriteLine("Số lượng phần tử trong list: "+authorListV2.Count);
            // tìm kiếm trong list
            bool checkAn = authorListV2.Contains("Ân");
            if (checkAn)
            {
                Console.WriteLine("Có xuất hiện ÂN");
            }
            else
            {
                Console.WriteLine("Không xuất hiện");
            }
            // sắp xếp 
            authorListV2.Sort();  // Ân, Khánh, Phi, Thanh

            // đảo ngược 
            authorListV2.Reverse();  // Thanh, Phi, Khánh, Ân

            foreach (string author in authorListV2)
            {
                Console.WriteLine("Phan tu: "+author);
            }
            // xóa dữ liệu
            authorListV2.Remove("Thanh");

            Console.WriteLine("Sau khi xoa");
            foreach (string author in authorListV2)
            {
                Console.WriteLine("Phan tu: " + author);
            }

            // 


        }
    }
}
