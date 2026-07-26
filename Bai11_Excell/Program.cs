using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;


namespace Bai11_Excell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

           

            string path = @"C:\PC 14\input.xlsx";  // Đường dẫn file Excel đầu vào
            if (!File.Exists(path))
                {
                Console.WriteLine("Không tìm thấy file Excel đầu vào tại: " + path);
                Console.WriteLine("Hãy tạo file mẫu theo hướng dẫn bên dưới và đặt đúng đường dẫn.");
                Console.ReadKey();
                return;

            }
            //Khai báo list để lưu dữ liệu từ file Excel
            List<string> maHSList = new List<string>();
            List<string> tenHSList = new List<string>();
            List<double> diemToanList = new List<double>();
            List<double> diemVanList = new List<double>();
            List<double> diemAnhList = new List<double>();
            List<double> trungBinhList = new List<double>();
            List<string> xepLoaiList = new List<string>();

            try
            {
                ExcelPackage.License.SetNonCommercialPersonal("Tinh diem trung binh"); // Thiết lập giấy phép cho EPPlus
                using (var package = new ExcelPackage(new FileInfo(path)))
                {
                    var worksheet = package.Workbook.Worksheets["HocSinh"];
                    if (worksheet == null)
                    {
                        Console.WriteLine("Không tìm thấy sheet 'HocSinh' trong file Excel.");
                        return;
                    }

                    int rowCount = worksheet.Dimension?.Rows ?? 0;
                    int colCount = worksheet.Dimension?.Columns ?? 0;
                    if (rowCount < 2 && colCount <5)
                    {
                        Console.WriteLine("File Excel không có dữ liệu hợp lệ (cần ít nhất 1 học sinh).");
                        return;
                    }

                    

                    for (int row = 2; row <= rowCount; row++)
                    {
                        string maHS = worksheet.Cells[row, 1].Text?.Trim() ?? "";
                        string tenHS = worksheet.Cells[row, 2].Text?.Trim() ?? "";

                        double diemToan = 0, diemVan = 0, diemAnh = 0;

                        try
                        {
                            diemToan = double.Parse(worksheet.Cells[row, 3].Text?.Trim() ?? "0");
                        }
                        catch { diemToan = 0; }

                        try
                        {
                            diemVan = double.Parse(worksheet.Cells[row, 4].Text?.Trim() ?? "0");
                        }
                        catch { diemVan = 0; }

                        try
                        {
                            diemAnh = double.Parse(worksheet.Cells[row, 5].Text?.Trim() ?? "0");
                        }
                        catch { diemAnh = 0; }

                        maHSList.Add(maHS);
                        tenHSList.Add(tenHS);
                        diemToanList.Add(diemToan);
                        diemVanList.Add(diemVan);
                        diemAnhList.Add(diemAnh);
                    }

                    // Tính toán và hiển thị kết quả
                    Console.WriteLine("Danh sách học sinh và kết quả:\n");
                   
                    int i = 0;
                    while (true)
                    {
                        double trungBinh = (diemToanList[i] + diemVanList[i] + diemAnhList[i]) / 3;
                        string xepLoai = "";

                        switch (trungBinh)
                        {
                            case 10:
                                xepLoai = "Hoàn hảo";
                                break;
                            default:
                                if (trungBinh >= 8 && trungBinh < 10)
                                {
                                    xepLoai = "Giỏi";
                                }
                                else if (trungBinh >= 6 && trungBinh < 8)
                                {
                                    xepLoai = "Khá";
                                }
                                else if (trungBinh >= 4 && trungBinh < 6)
                                {
                                    xepLoai = "Trung bình";
                                }
                                else
                                {
                                    xepLoai = "Yếu";
                                }
                                break;



                        }
                        trungBinhList.Add(trungBinh);
                        xepLoaiList.Add(xepLoai);



                        Console.WriteLine($"Học sinh  {tenHSList[i].ToString()}, Trung bình điểm: {Math.Round(trungBinh,2)} , Xếp Loại :  {xepLoai}");
                        i++;
                        if (i >= maHSList.Count)
                        {
                            break;
                        }
                    }

                    


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi mở file Excel: " + ex.Message);
            }
            //ghi file Excel đầu ra
       //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial; 
            try
            {
               
              
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("KetQua");

                    // Ghi header
                    worksheet.Cells[1, 1].Value = "Mã học sinh";
                    worksheet.Cells[1, 2].Value = "Tên học sinh";
                    worksheet.Cells[1, 3].Value = "Trung bình điểm";
                    worksheet.Cells[1, 4].Value = "Xếp loại";

                    // Ghi dữ liệu
                    for (int i = 0; i < maHSList.Count; i++)
                    {
                        worksheet.Cells[i + 2, 1].Value = maHSList[i];
                        worksheet.Cells[i + 2, 2].Value = tenHSList[i];
                        worksheet.Cells[i + 2, 3].Value = Math.Round(trungBinhList[i], 2);
                        worksheet.Cells[i + 2, 4].Value = xepLoaiList[i];
                    }

                    // Lưu file Excel đầu ra
                    string outputPath = @"C:\PC 14\Output.xlsx";
                    //Kiem tra foder co ton tai khong, neu khong thi tao foder
                    if (Directory.Exists(Path.GetDirectoryName(outputPath)) == false)
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    }
                    if (File.Exists(outputPath))
                    {
                        File.Delete(outputPath);
                    }
                    package.SaveAs(new FileInfo(outputPath));
                    Console.WriteLine($"\nKết quả đã được ghi vào file Excel: {outputPath}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi ghi file Excel: " + ex.Message);
            }

            //

            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
    
