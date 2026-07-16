namespace Chuoi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("nhap vao mot chuoi: ");
                string sChuoi = Console.ReadLine();
                Console.WriteLine("lua chon yeu cau a, b, c: ");
                string cYeuCau = Console.ReadLine();

                switch (cYeuCau)
                {
                    case "a":
                        yeuCauA(sChuoi);
                        break;
                    case "b":
                        yeuCauB(sChuoi);
                        Console.WriteLine();
                        break;
                    case "c":
                        yeuCauC(sChuoi);
                        break;
                    default: Console.WriteLine("Yeu cau a, b hoac c");
                        break;

                }
            }
            
        }
        public static void yeuCauA(string sChuoi)
        {
            foreach (var i in sChuoi)
            {
                Console.WriteLine(i);
            }
        }
        public static void yeuCauB(string sChuoi)
        {
            bool isNewLine = false, isFirstChar = true;
            for (int i = 0; i < sChuoi.Length; i++)
            {
                if (sChuoi[i] != ' ')
                {
                    if (isNewLine == true&&isFirstChar == false)Console.WriteLine();
                    Console.Write(sChuoi[i]);
                    isFirstChar = false;
                    isNewLine = false;
                }
                else isNewLine = true;
            }
        }
        public static void yeuCauC(string sChuoi)
        {
            List<char> charList = new List<char>();
            List<int> countList = new List<int>();
            foreach (var i in sChuoi)
            {
                int index = charList.IndexOf(i);
                if (index == -1)
                {
                    charList.Add(i);
                    countList.Add(1);
                }
                else
                {
                    countList[index]++;
                }

            }
            for (int i = 0; i < charList.Count; i++)
            {
                Console.WriteLine($"ky tu {charList[i]} xuat hien: {countList[i]} lan");
            }
        }

    }
}
