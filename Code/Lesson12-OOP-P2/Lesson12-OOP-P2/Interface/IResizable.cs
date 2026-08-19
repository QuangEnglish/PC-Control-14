namespace Lesson12_OOP_P2.Interface
{
    // Interface thứ 2: khả năng thay đổi kích thước
    // 1 class có thể implement NHIỀU interface (khác với abstract class chỉ kế thừa 1)
    public interface IResizable
    {
        void Resize(double factor);
    }
}
