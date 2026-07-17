using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Buoi_7__13._07._2026_
{
    internal class Program
    {
        //int TimSoLonNhat(int[] arrNumberV3)
        //{
        //    int maxValue = arrNumberV3[0];   
        //    int minValue = arrNumberV3[0];
        //    for (int i = 0; i < arrNumberV3.Length; i++)
        //    {
        //        if (arrNumberV3[i] > maxValue) = maxValue = arrNumberV3[i] ;
        //    }
        //    return maxValue;
        //}
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // Mảng - Array
            // Là 1 cấu trúc dữ liệu
            // Lưu nhiều giá trị
            // có cùng kiểu dữ liệu
            // được đặt tại 1 biến duy nhất

            //đặc điểm"
            // màn có kích thước cố định
            // mảng là kiểu reference type (kiểu tham chiếu)
            // index bắt đầu từ đâu: 0

            // khởi tạo mảng
            //int[] arrNumber = new int[5];
            //arrNumber[0] = 1;
            //arrNumber[2] = 5;
            //arrNumber[3] = 9;

            //// Đề bài: Tạo 1 mảng gồm 5 số nguyên
            //// Yêu cầu: viết hàm trả về giá trị và có tham số
            //// tìm ra số lớn nhất trong mảng
            //int[] arrNumberV2 = { 1, 5, 4, 16, 10 };
            //int soLonNhat = TimSoLonNhat(arrNumberV2);
            //Console.WriteLine("Số lớn nhât trong mảng là: " + soLonNhat);

            //Mảng 2 chiều
            int[,] numbers =
            {
                { 1, 0, 2} ,
                { 3, 4, 5},
                { 5, 6, 7},
            };
            Console.WriteLine(numbers[1,2]);

            for (int i=0; i < NumberStyles.GetLength(0); i++)
            {
                for (int j =0; numbers.GetLength(1); j++)
                {
                    Console.Write(numbers[,]                
                }
            }

            //list 
            //kích thước linh hoạt
            
           

        }
    }
}