using System;

namespace Lesson12_OOP_P2.Interface
{
    // Interface: là 1 hợp đồng (contract) mà class phải tuân theo
    // Interface chỉ khai báo "CÁI GÌ" cần làm, không quan tâm "LÀM NHƯ THẾ NÀO"
    // Tất cả method trong interface đều là public abstract (mặc định)
    // Interface KHÔNG có constructor, KHÔNG có field
    // Đặt tên interface thường bắt đầu bằng chữ "I"
    public interface IShape
    {
        // Khai báo method - không có thân hàm (body)
        public double CalculateArea();
        double CalculatePerimeter();
        int Draw();  // vẽ hình

        // C# 8.0+: Interface có thể có default implementation
        void PrintInfo()
        {
            Console.WriteLine($"Dien tich: {CalculateArea():F2}");
            Console.WriteLine($"Chu vi: {CalculatePerimeter():F2}");
        }
    }
}
