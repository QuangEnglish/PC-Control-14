
using OfficeOpenXml;
using System.Text;
namespace ConsoleApp1

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
			try
			{
                string filePaths = @"D:\MAV\PC-Control-14\10NhapMonLapTrinh";
                string fileName = "input.xlsx";
                string fileFullPaths = Path.Combine(filePaths, fileName);

                // input
                List<string[]> lIDHocSinh = new List<string[]>();
                List<double[]> lDiemSo = new List<double[]>();
                // output
                List<double> lTrungBinh = new List<double>();
                List<string> lXepLoai = new List<string>();

                ExcelPackage.License.SetNonCommercialOrganization("Nguyen Duy Khanh");
                using (var package = new ExcelPackage(new FileInfo(fileFullPaths)))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension?.Rows ?? 0;
                    int colCount = worksheet.Dimension?.Columns ?? 0;
                    for (int i = 2; i <= rowCount; i++)
                    {
                        string maHocSinh = worksheet.Cells[i, 1].Text?.Trim()??"";
                        string tenHocSinh = worksheet.Cells[i, 2].Text?.Trim()??"";
                        string[] ID = new string[2] { 
                            string.IsNullOrWhiteSpace(maHocSinh)?"HS000":maHocSinh,
                            string.IsNullOrWhiteSpace(tenHocSinh)?"No Name":tenHocSinh
                        };

                        lIDHocSinh.Add(ID);

                        double[] arrDiem = new double[colCount - 2];
                        // so luong phan tu mang = so luong cot - 2 cot (ma hoc sinh & ten hoc sinh
                        for (int j = 3; j <= colCount; j++)
                        {
                            try { arrDiem[j-3] = double.Parse(worksheet.Cells[i, j].Text);}
                            catch (Exception) { arrDiem[j-3] = 0;}
                        }

                        lDiemSo.Add(arrDiem);
                    }

                    for (int i = 0; i < lIDHocSinh.Count; i++)
                    {
                        double tongDiem = 0, trungBinh = 0;
                        for (int j = 0;j< lDiemSo[0].Length;j++) tongDiem += lDiemSo[i][j];
                        trungBinh = Math.Round(tongDiem / lDiemSo[0].Length,2);
                        
                        string sXepLoai = "";
                        if (trungBinh >= 8) sXepLoai = "Gioi";
                        else if (trungBinh >= 6) sXepLoai = "Kha";
                        else if (trungBinh >= 4) sXepLoai = "TrungBinh";
                        else sXepLoai = "Yeu";

                        switch (trungBinh)
                        {
                            case 10:
                                Console.WriteLine("Hoan hao");
                                break;
                            default:
                                break;
                        }

                        lTrungBinh.Add(trungBinh);
                        lXepLoai.Add(sXepLoai);

                        Console.WriteLine(
                            lIDHocSinh[i][0] + " " +
                            lIDHocSinh[i][1] + " " +
                            lTrungBinh[i] + " " +
                            lXepLoai[i]
                            );
                    }

                    package.Save();
                }

                string fileKetQua = @"D:\MAV\PC-Control-14\10NhapMonLapTrinh\output.xlsx";
                if (File.Exists(fileKetQua)) File.Delete(fileKetQua);
                File.Create(fileKetQua).Dispose(); //Khong co Dispose khong chay duoc
                try
                {
                    using (var package = new ExcelPackage(new FileInfo(fileKetQua)))
                    {
                        var worksheet = package.Workbook.Worksheets.Add("ketQua");
                        worksheet.Cells[1, 1].Value = "Ma Hoc Sinh";
                        worksheet.Cells[1, 2].Value = "Ten Hoc Sinh";
                        worksheet.Cells[1, 3].Value = "Trung Binh Diem";
                        worksheet.Cells[1, 4].Value = "Xep Loai";
                        for (int i = 0; i < lIDHocSinh.Count; i++)
                        {
                            worksheet.Cells[i + 2, 1].Value = lIDHocSinh[i][0];
                            worksheet.Cells[i + 2, 2].Value = lIDHocSinh[i][1];
                            worksheet.Cells[i + 2, 3].Value = lTrungBinh[i];
                            worksheet.Cells[i + 2, 4].Value = lXepLoai[i];
                        }
                        package.Save();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());   
                }
                

            }
			catch (Exception ex)
			{
                Console.WriteLine(ex.ToString());			
			}
        }
    }
}
