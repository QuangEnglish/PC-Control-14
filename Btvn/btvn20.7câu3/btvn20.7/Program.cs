// See https://aka.ms/new-console-template for more information

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Stack<string> undoStack = new Stack<string>();
        undoStack.Push("Bật công tắc");
        undoStack.Push("tắt công tắc");
        undoStack.Push("tăng tốc độ moto");
        Stack<string> redoStack = new Stack<string>();
       
        foreach (var item in undoStack)
        {
            Console.WriteLine(item);
        }
        if (undoStack.Count > 0)
        {
            redoStack.Push(undoStack.Pop());
            Console.WriteLine("Thao tác hiện tại của redo là" + redoStack.Peek());
        }
        Console.WriteLine("trạng thái sau khi undo là" + undoStack.Peek());
    }
}