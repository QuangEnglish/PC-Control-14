namespace BAI_2_ep_kieu_du_lieu_va_toan_tu
{
    internal class Program
    {
        string ageStr = "10";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            double luong1ngay = 50000;
            decimal tongluong = (decimal)luong1ngay * 5;
            //ép kiểu ngầm
            int a = int.Parse(Console.ReadLine());
            double b = a; // chỉ có kiểu lớn như double mới chứa được cái bé như int
            //ép kiểu tường minh
            double x = 9.7;
            int y = (int)x;
            Console.WriteLine("gia tri y: " + y);
            //toan tu logic
            if(a != 0 && a !=1) // a khac 0 va a khac 1  phai true thi moi ra true
            {
                Console.WriteLine("dung");
            }
            else
            {
                Console.WriteLine("sai");
                //  || la or  
                //  && la and
                // thu tu uu tien : || cao hon &&
                if (a != 0 && (a != 1 && a = 2)) // them ngoac cho truc quan
            }
        }
    }
}
