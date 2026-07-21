using System;

namespace Palindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap vao chuoi cam kiem tra Palindrome: ");
            string sPalin = Console.ReadLine();
            bool isPalin = CheckPalin(sPalin);
            if (isPalin == true)
            {
                Console.WriteLine("Chuoi la Palindrome");
            }
            else
            {
                Console.WriteLine("Chuoi khong la Palindrome");
            }

        }
        static bool CheckPalin(string sPalin)
        {
            Stack<char> sStack = new Stack<char>();
            Queue<char> sQueue = new Queue<char>();
            foreach (char c in sPalin)
            {
                sStack.Push(c);
                sQueue.Enqueue(c);
            }
            foreach (var c in sPalin)
            {
                if (sStack.Pop() != sQueue.Dequeue())
                {
                    return false;
                }
            }
            return true;

        }
    }
}
