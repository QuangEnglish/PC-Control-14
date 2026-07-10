using System.Text;

namespace Lesson3_Method_Scope
{
    internal class Program
    {
        #region Hàm không trả về giá trị, không có tham số
        static void Display()
        {
            int x = 0;
            int y = 10;
            int z = x + y;
            Console.WriteLine($"giá trị z: {z}");
        }
        #endregion

        #region Hàm không trả về giá trị, có tham số
        static void DisplayV2(int x, int y)
        {
            int z = x + y;
            Console.WriteLine($"giá trị z: {z}");
        }
        #endregion

        #region hàm có trả về giá trị, không tham số
        static float TinhDienTichHCN()
        {
            float chieuDai = 4.5F;
            float chieuRong = 2.5F;
            float dienTich = chieuDai * chieuRong;
            return dienTich;
        }
        #endregion

        #region hàm có trả về giá trị, có tham số
        static float TinhDienTichHCNV2(float chieuDai, float chieuRong)
        {
            //float dienTich = chieuDai * chieuRong;
            //return dienTich;
            return chieuDai * chieuRong;
        }
        #endregion

        // hàm không trả về giá trị, không có tham số

        static void TinhDienTichHinhVuong()
        {
            float x = 2.5F;
            float z = x * x;
            Console.WriteLine($"Giá trị diện tích hình vuông: {z}");
        }

        // hàm trả về có giá trị, có tham số:  người dùng nhập từ bàn phím số điểm, yêu cầu hàm trả ra giá trị học lực 
        // điểm dưới 7 thì trung bình, còn lại là giỏi
        static String XepLoaiHocLuc(int x)
        {

            // câu điều kiện if

            // câu điều kiện if - else

            // Câu điều kiện if - else if - else if - else

            if (x < 7)
            {
                return "Trung Bình";
            }

            if (x < 8)
            {
                return "Khá";
            }

            if (x < 9)
            {
                return "Khá giỏi";
            }
            else
            {
                return "Giỏi";
            }
        }


        // Hàm không trả về giá trị, có tham số đầu vào là 1 số
        // đề bài: kiểm tra số đó có phải là số chẵn hay không, đúng thì hiển thị "Là số chẵn", ngược lại thì hiển thị là "Số lẻ"
        static void KiemTraSo(int x, int y, String z, bool f)
        {
            if (x % 2 == 0)
            {
                Console.WriteLine("Là số chẵn");
            }
            else
            {
                Console.WriteLine("Là số lẻ");
            }
        }

        // Tham trị:
        static void TangGiaTri(int x)
        {
            x += 10; // x = x + 10
            Console.WriteLine($"Giá trị trong hàm của x là: {x}");  // 
        }


        // Tham chiếu:
        // ref
        static void TangGiaTriRef(ref int x)   // tham số x được truyền bằng tham chiếu
        {
            x += 10;
            Console.WriteLine($"Giá trị trong hàm của x là: {x}");
        }

        static void ThayDoiChuoi(string x)
        {
            x = "Hoàng";
            Console.WriteLine($"Giá trị trong hàm của x là: {x}");
        }

        static void ThayDoiChuoiRef(ref string x, ref string y)   
        {
            x = "Hoàng";
            Console.WriteLine($"Giá trị trong hàm của x là: {x}");
        }

        // từ khóa: out
        // out là hàm sẽ gán giá trị cho 2 biến max và min 
        static void TimMaxMin(int x, int y, int z, out int maxValue, out int minValue)
        {
            maxValue = Math.Max(x, Math.Max(y, z));
            minValue = Math.Min(x, Math.Min(y, z));
        }



        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Hàm là 1 khối code được đặt tên

            // hàm không có kiểu trả về, không có tham số
            Display();  // lời gọi hàm Display

            //// hàm không có kiểu trả về, có tham số
            //int x = 0;
            //double y = 10;
            //DisplayV2(x, (int)y);

            //// Hàm có kiểu trả về, không tham số
            //float dienTich = TinhDienTichHCN();
            //Console.WriteLine("Diện tích HCN là: "+dienTich);

            //// Hàm có kiểu trả về, có tham số
            //float chieuDai = 4.5F;
            //float chieuRong = 2.5F;
            //float dienTichV2 = TinhDienTichHCNV2(chieuDai, chieuRong);
            //Console.WriteLine("Diện tích HCN V2 là: " + dienTichV2);

            //decimal price = 19.06666M;

            //TinhDienTichHinhVuong();

            ////int diemHocLuc = 0;  // đã khởi tạo biến nhưng chưa khởi tạo giá trị
            //// Quy tắc: biến cục bộ bắt buộc phải được gán giá trị trước khi đọc
            //Console.WriteLine("Bạn hãy nhập điểm của bạn: ");
            //int diemHocLuc = Convert.ToInt32(Console.ReadLine());

            //String xepLoai = XepLoaiHocLuc(diemHocLuc);
            //Console.WriteLine($"Xếp loại học lực: {xepLoai}");

            //Console.WriteLine("Bạn hãy nhập số của bạn: ");
            ////int nhapSo =  (int)5.5F;
            ////int nhapSo = int.Parse(Console.ReadLine()); 

            ////float nhapSo = float.Parse(Console.ReadLine());
            ////int nhapSoV2 = (int) nhapSo;

            //int nhapSoV2 = (int) float.Parse(Console.ReadLine());
            ////int yV2 = 2;
            ////String zV2 = " ";
            ////bool zV3 = true;
            //KiemTraSo(nhapSoV2, 2, " ", false);

            // Tham trị là hàm nhận 1 bản sao của giá trị, không phải biến gốc
            //int y = 10;   // 
            //TangGiaTri(y); // truyền bản sao của x
            //Console.WriteLine("Giá trị của bienDem là: "+y);  // y = ?    Thanh: 10, Nguyên: 20, Trung: 20

            //// Tham chiếu là hàm không nhận bản sao mà nhận chính biến gốc
            ///
            // Ref
            //int so = 5;
            //TangGiaTriRef(ref so);  // a và x cùng trỏ đến 1 vùng nhớ
            //Console.WriteLine("Giá trị của so là: "+so);   // so = 15;

            string a = "Nguyen";
            ThayDoiChuoi(a);
            Console.WriteLine("Giá trị của a là: "+a);

            string b = "Nguyen";
            ThayDoiChuoiRef(ref b, ref a);
            Console.WriteLine("Giá trị của b là: " + b);

            //  out
            int maxValue, minValue;
            TimMaxMin(10, 20, 30, out maxValue, out minValue);
            Console.WriteLine($"Giá trị maxValue là: {maxValue}");
            Console.WriteLine($"Giá trị minValue là: {minValue}");

            // Bài sau: cấu trúc điều khiển - vòng lăp, phạm vi truy cập của biến

        }
    }
}
