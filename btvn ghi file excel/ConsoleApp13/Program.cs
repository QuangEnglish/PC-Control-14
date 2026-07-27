using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System.Text;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ExcelPackage.License.SetNonCommercialPersonal("Thanh Binh");
            string path = @"C:\Users\THIS PC\Downloads\input.xlsx";
            List<string> mahocsinh = new List<string>();
            List<string> tenhocsinh = new List<string>();
            List<double> diemtoan = new List<double>();
            List<double> diemvan = new List<double>();
            List<double> diemanh = new List<double>();
            List<double> diemtrungbinh = new List<double>();
            List<string> xeploai = new List<string>();

            // Đưa số từ excel vào list
            using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
            {
                ExcelWorksheet ws = null;
                ws = package.Workbook.Worksheets[0];
                int row = ws.Dimension.Rows;
                int column = ws.Dimension.Columns;
                for (int i = 2; i <= row; i++)
                {
                    mahocsinh.Add(ws.Cells[i, 1].Text);
                }
                for (int i = 2; i <= row; i++)
                {
                    tenhocsinh.Add(ws.Cells[i, 2].Text);
                }

                for (int i = 2; i <= row; i++)
                {
                    try 
                    {
                    diemtoan.Add(ws.Cells[i, 3].GetCellValue<double>());
                    }
                    catch(FormatException ex) { diemtoan.Add(0); Console.WriteLine(ex.Message); }
                }
                for (int i = 2; i <= row; i++)
                {
                    try 
                    {
                    diemvan.Add(ws.Cells[i, 4].GetCellValue<double>());
                    }
                    catch(FormatException ex) { diemvan.Add(0); Console.WriteLine(ex.Message); }
                }
                for (int i = 2; i <= row; i++)
                {
                    try 
                    {
                    diemanh.Add(ws.Cells[i, 5].GetCellValue<double>());
                    }
                    catch(FormatException ex) { diemanh.Add(0); Console.WriteLine(ex.Message); }
                }
                for (int i = 0; i < row - 1; i++)
                {
                    diemtrungbinh.Add((diemtoan[i] + diemvan[i] + diemanh[i]) / 3);
                    if (diemtrungbinh[i] >= 8) { xeploai.Add("Giỏi"); }
                    else if (diemtrungbinh[i] < 8 && diemtrungbinh[i] >= 6) { xeploai.Add("Khá"); }
                    else if (diemtrungbinh[i] < 6 && diemtrungbinh[i] >= 4) { xeploai.Add("Khá"); }
                    else { xeploai.Add("Yếu"); }
                }
                for (int i = 0; i < mahocsinh.Count; i++)
                {
                    Console.WriteLine($"{mahocsinh[i]} {tenhocsinh[i]} {diemtrungbinh[i]} {xeploai[i]}");
                }
                foreach (double i in diemtoan) { Console.WriteLine(i); }

                // Ghi kết quả vào excel
                var wsketqua = package.Workbook.Worksheets.Add("Ketqua");
                wsketqua = package.Workbook.Worksheets[1];
                wsketqua.Cells[1, 1].Value = "Mã học sinh";
                wsketqua.Cells[1, 2].Value = "Tên học sinh";
                wsketqua.Cells[1, 3].Value = "Điểm trung bình";
                wsketqua.Cells[1, 4].Value = "Xếp loại";
                for (int i = 2, a = 0; i <= row; i++, a++)
                {
                    wsketqua.Cells[i, 1].Value = mahocsinh[a];
                }
                for (int i = 2, a = 0; i <= row; i++, a++)
                {
                    wsketqua.Cells[i, 2].Value = tenhocsinh[a];
                }
                for (int i = 2, a = 0; i <= row; i++, a++)
                {
                    wsketqua.Cells[i, 3].Value = diemtrungbinh[a];
                }
                for (int i = 2, a = 0; i <= row; i++, a++)
                {
                    wsketqua.Cells[i, 4].Value = xeploai[a];
                }
                try { package.Save(); }
                catch (IOException ex) { Console.WriteLine("Không tìm thấy đường dẫn file"+ex.Message); }
                catch (InvalidOperationException ex) { Console.WriteLine("File đang mở, hãy đóng file"+ex.Message); }
                catch (UnauthorizedAccessException ex) { Console.WriteLine("File không có quyền truy cập"+ex.Message); }
            }


        }
    }
}

