namespace KiemTraCapDauNgoac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap vao chuoi can kiem tra: ");
            string sCheck = Console.ReadLine();
            bool result = checkNgoac(sCheck);
            if (result == true)
            {
                Console.WriteLine("check OK");
            }
            else
            {
                Console.WriteLine("check Fail");
            }
        }
        static bool checkNgoac(string sCheck)
        {
            Stack<char> stackNgoac = new Stack<char>();
            foreach (char i in sCheck)
            {
                if (i == '(') stackNgoac.Push(i);
                else if (i == ')')
                {
                    if (stackNgoac.Count == 0) return false;
                    stackNgoac.Pop();
                }
            }
            if (stackNgoac.Count == 0) return true;
            else return false;
        } 
      
    }
}
