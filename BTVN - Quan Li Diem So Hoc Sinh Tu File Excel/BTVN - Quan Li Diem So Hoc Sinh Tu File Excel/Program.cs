using OfficeOpenXml;

namespace BTVN___Quan_Li_Diem_So_Hoc_Sinh_Tu_File_Excel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Lấy file input.xlsx
            string path = @"D:\Hoc_C#\PC-Control-14\BTVN - Quan Li Diem So Hoc Sinh Tu File Excel\BTVN - Quan Li Diem So Hoc Sinh Tu File Excel\input.xlsx";
            if (!File.Exists(path))
            {
                Console.WriteLine("Không tìm thấy file Excel tại: " + path);
                Console.WriteLine("Hãy tạo file mẫu theo hướng dẫn bên dưới và đặt đúng đường dẫn.");
                Console.ReadKey();
                return;
            }
            using (var package = new ExcelPackage(new FileInfo(path))) 
            {
                var worksheet = package.Workbook.Worksheets[0]; // lôi ra sheet excel đầu tiên
                worksheet.Cells[1, 6].Value = "Tổng tiền";
                worksheet.Cells[1, 6].Style.Font.Bold = true;

            }

            try
            {
                using (var package = new ExcelPackage(new FileInfo(path)))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // lôi ra sheet excel đầu tiên
                    worksheet.Cells[1, 6].Value = "Tổng tiền";
                    worksheet.Cells[1, 6].Style.Font.Bold = true;

                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Lỗi File không tồn tại " + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Lỗi Input/Output: " + ex.Message);
            }
            finally
            {
                // thường dùng để đóng file, đóng kết nối, dọn dẹp 
                Console.WriteLine("Đã đóng file, đóng kết nối, dọn dẹp");
            }
        }


        }
    }
}
