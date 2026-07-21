namespace UndoRedo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("nhap vao chuoi cac lenh");
            
            Stack<string> sUndo = new Stack<string>();
            Stack<string> sRedo = new Stack<string>();
            while (true)
            {
                string s = Console.ReadLine();
                if (s == "-1") break;
                else sUndo.Push(s);
            }
            Console.WriteLine("Bat dau qua trinh Undo: ");
            while (sUndo.Count > 0)
            { 
                string sThaoTac = sUndo.Pop();
                Console.WriteLine($"Undo: " + sThaoTac);
                sRedo.Push(sThaoTac);
            }
            Console.WriteLine("\nBat dau qua trinh Redo: ");
            while (sRedo.Count > 0)
            {
                Console.WriteLine($"Redo: " + sRedo.Pop());
            }

        }
    }
}
