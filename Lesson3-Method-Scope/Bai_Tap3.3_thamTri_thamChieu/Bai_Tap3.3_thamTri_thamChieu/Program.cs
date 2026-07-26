using System.Numerics;

namespace Bai_Tap3._3_thamTri_thamChieu
{
    internal class Program
    {
        static void ThayDoiChuoi(string x)
        {
            x += " Hoang";
            Console.WriteLine("Gia tri cua x la :" + x);
        }

        static void ThayDoiChuoiref(ref string x)
        {
            x += " Hoang";
            Console.WriteLine("Gia tri cua x la :" + x);
        }

        static void MaxMin(int x, int y, int z, out int maxVlue, out int minValue )
        {
            maxVlue = Math.Max(x, (Math.Max(y, z)));
            minValue = Math.Min(x, (Math.Min(y, z)));
        }
        static void Main(string[] args)
        {
            string a = "Nguyen";
            ThayDoiChuoi(a);

            Console.WriteLine("Gia tri cua a la: " + a);
            ThayDoiChuoiref(ref a);

            Console.WriteLine("Gia tri cua ref a la: "+a);

            //int x = 100;
            //int y = 150;
            //int z = 10;

            MaxMin(100, 150, 10, out int maxValue, out int minValue);
            Console.WriteLine("Gia tri cua maxValue la: " + maxValue);
            Console.WriteLine("Gia tri cua minValue la: " + minValue);

        }
    }
}
