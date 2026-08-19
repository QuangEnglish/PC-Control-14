namespace Lesson12_OOP_P2.Interface
{
    // Interface thứ 3: khả năng tô màu
    public interface IColorable
    {
        string Color { get; set; }  // Interface có thể có property
        void SetColor(string color);
        
    }
}
