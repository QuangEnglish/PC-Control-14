using System.Text;

namespace BTVN_Bai_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // a) cho phép nhập chuỗi và in ra ký tự
            Console.WriteLine("Nhập vào chuỗi ký tự :");
            string chuoiKyTuA = Console.ReadLine();
 
            foreach (char kyTu in chuoiKyTuA)
            {
                Console.WriteLine(kyTu);
            }

            // b) cho phép nhập chuỗi ký tự có khoảng trắng. in ra bỏ khoảng trắng 
            Console.WriteLine("Nhập vào chuỗi ký tự có khoảng trắng :");
            string chuoiCoKhoangTrang = Console.ReadLine();

            foreach (char kyTuv2 in chuoiCoKhoangTrang)
            {
                char khoangTrang = ' ';
                if (kyTuv2 == khoangTrang) continue;
                Console.WriteLine(kyTuv2);
            }

            // c) nhập chuỗi và hiển thị số lần xuất hiện của mỗi ký tự trong chuỗi
            Console.WriteLine("Nhập vào chuỗi ký tự :");
            string chuoiKyTuC = Console.ReadLine();

            for(int i =0; i < chuoiKyTuC.Length; i++)
            {
                bool daDem = false;

                for(int j = 0; j < i; j++)
                {
                    if (chuoiKyTuC[j] == chuoiKyTuC[i])
                    {
                        daDem = true;
                        break;
                    }
                }

                if (!daDem)
                {
                    int dem = 0;

                    for(int j = i; j < chuoiKyTuC.Length; j++)
                    {
                        if (chuoiKyTuC[i] == chuoiKyTuC[j])
                        {
                            dem++;
                        }
                    
                    }
                    Console.WriteLine($"Ký tự {chuoiKyTuC[i]} xuất hiện : {dem} lần");
                }
            }


            // Console.WriteLine("Hello, World!");
        }
    }
}
