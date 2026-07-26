namespace Bai_Tap3._2_Ham
{
    internal class Program
    {
        #region Tim so chan (cach 1)
        static void TimSoChan(int so)
        {
            if ((so & 1) ==0)
            {
                Console.WriteLine( "La so Chan ");
            }
            else 
            {
                Console.WriteLine("La so Le ");
            }
        }
        #endregion
        #region Tim so chan (cach 2)
        static void TimSoChan1(int so)
        {
            if ((so % 2) == 0)
            {
                Console.WriteLine("La so Chan ");
            }
            else
            {
                Console.WriteLine("La so Le ");
            }
        }
        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap so :");
            int sov1 = Convert.ToInt32(Console.ReadLine());

            TimSoChan(sov1);
            TimSoChan1(sov1);
            //Console.WriteLine("Hello, World!");
        }
    }
}
