using OfficeOpenXml;

namespace bai_tap_excel_ket_thuc_khoa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ExcelPackage.License.SetNonCommercialOrganization("bt C#");

            string inputPath = @"D:\input.xlsx";
            string outputPath = @"D:\output.xlsx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Khong tim thay file o D:\\input.xlsx");
                Console.ReadKey();
                return;
            }

            List<string> dsMaHS = new List<string>();
            List<string> dsTenHS = new List<string>();
            List<double> dsDiemToan = new List<double>();
            List<double> dsDiemVan = new List<double>();
            List<double> dsDiemAnh = new List<double>();

            List<double> dsDiemTB = new List<double>();
            List<string> dsXepLoai = new List<string>();

            try
            {
                using (var package = new ExcelPackage(new FileInfo(inputPath)))
                {
                    var worksheet = package.Workbook.Worksheets["HocSinh"];

                    int rowCount = worksheet.Dimension.Rows;

                    int row = 2;
                    while (row <= rowCount)
                    {
                        string maHS = worksheet.Cells[row, 1].Value?.ToString();
                        string tenHS = worksheet.Cells[row, 2].Value?.ToString();

                        if (string.IsNullOrEmpty(maHS))
                        {
                            row++;
                            continue;
                        }

                        double toan = 0;
                        double van = 0;
                        double anh = 0;

                        try { toan = Convert.ToDouble(worksheet.Cells[row, 3].Value); }
                        catch { toan = 0; }

                        try
                        {
                            van = Convert.ToDouble(worksheet.Cells[row, 4].Value);
                        }
                        catch { van = 0; }

                        try { anh = Convert.ToDouble(worksheet.Cells[row, 5].Value); } catch { anh = 0; }

                        dsMaHS.Add(maHS);
                        dsTenHS.Add(tenHS);
                        dsDiemToan.Add(toan);
                        dsDiemVan.Add(van);
                        dsDiemAnh.Add(anh);

                        row++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi doc file: " + ex.Message);
            }

            for (int i = 0; i < dsMaHS.Count; i++)
            {
                double diemTB_temp = (dsDiemToan[i] + dsDiemVan[i] + dsDiemAnh[i]) / 3;
                diemTB_temp = Math.Round(diemTB_temp, 2);
                dsDiemTB.Add(diemTB_temp);

                string xl = "";
                if (diemTB_temp >= 8.0)
                {
                    xl = "Giỏi";
                }
                else if (diemTB_temp >= 6.0) { xl = "Khá"; }
                else if (diemTB_temp >= 4.0)
                {
                    xl = "Trung bình";
                }
                else
                {
                    xl = "Yếu";
                }
                dsXepLoai.Add(xl);

                int dtbTron = (int)diemTB_temp;
                switch (dtbTron)
                {
                    case 10:
                        Console.WriteLine("Học sinh " + dsTenHS[i] + " có điểm tuyệt đối");
                        break;
                }
            }

            int index = 0;
            while (index < dsMaHS.Count)
            {
                Console.WriteLine(dsMaHS[index] + " - " + dsTenHS[index] + " - DTB: " + dsDiemTB[index] + " - Loai: " + dsXepLoai[index]);
                index++;
            }

            try
            {
                FileInfo fileOut = new FileInfo(outputPath);

                using (var packageOut = new ExcelPackage(fileOut))
                {
                    var sheetOut = packageOut.Workbook.Worksheets["KetQua"];
                    if (sheetOut == null)
                    {
                        sheetOut = packageOut.Workbook.Worksheets.Add("KetQua");
                    }

                    sheetOut.Cells[1, 1].Value = "Mã học sinh";
                    sheetOut.Cells[1, 2].Value = "Tên học sinh";
                    sheetOut.Cells[1, 3].Value = "Trung bình điểm";
                    sheetOut.Cells[1, 4].Value = "Xếp loại";

                    for (int i = 0; i < dsMaHS.Count; i++)
                    {
                        sheetOut.Cells[i + 2, 1].Value = dsMaHS[i];
                        sheetOut.Cells[i + 2, 2].Value = dsTenHS[i];
                        sheetOut.Cells[i + 2, 3].Value = dsDiemTB[i];
                        sheetOut.Cells[i + 2, 4].Value = dsXepLoai[i];
                    }

                    packageOut.Save();
                }

                Console.WriteLine("\nGhi file output.xlsx thanh cong!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi ghi file: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
