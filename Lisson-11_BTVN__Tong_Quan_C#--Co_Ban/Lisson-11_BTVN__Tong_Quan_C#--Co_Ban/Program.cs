using System;
using OfficeOpenXml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lisson_11_BTVN__Tong_Quan_C___Co_Ban
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string inputpath = "D:\\HocC#\\Demo_file\\input.xlsx";
            string outputPath = "D:\\HocC#\\Demo_file\\ouput.xlsx";
            string output2Path = "D:\\HocC#\\Demo_file\\ouput22.xlsx";

            if (!File.Exists(inputpath))
            {
                Console.WriteLine("Không tìm thấy file Excel tại: " + inputpath);
                Console.WriteLine("Hãy tạo file mẫu theo hướng dẫn bên dưới và cài đặt đúng hướng dẫn.");
                Console.ReadKey();
                return;
            }

            ExcelPackage.License.SetNonCommercialOrganization("Automation lab");
            List<string> maHS = new List<string>();
            List<string> tenHS = new List<string>();
            List<double> diemToan = new List<double>();
            List<double> diemVan = new List<double>();
            List<double> diemAnh = new List<double>();

            List<double> diemTB = new List<double>();
            List<string> xepLoai = new List<string>();

            try
            {
                File.Copy(inputpath, outputPath, true);

                using (var packge = new ExcelPackage(new FileInfo(outputPath)))
                {
                    var worksheet = packge.Workbook.Worksheets["HocSinh"];

                    if (worksheet == null)
                    {
                        Console.WriteLine("Không tìm thấy sheet Học Sinh.");
                        return;
                    }

                    worksheet.Cells[1, 6].Value = "Điểm TB";
                    worksheet.Cells[1, 6].Style.Font.Bold = true;
                    worksheet.Cells[1, 7].Value = "Xếp loại";
                    worksheet.Cells[1, 7].Style.Font.Bold = true;

                    // Lấy số dòng và cột có dữ liệu thực tế
                    int rowCount = worksheet.Dimension?.Rows ?? 0;
                    int colCount = worksheet.Dimension?.Columns ?? 0;

                    if (rowCount < 2 || colCount < 3)
                    {
                        Console.WriteLine("File Excel không có dữ liệu hợp lệ (cần ít nhất 3 cột và 2 dòng).");
                        return;
                    }

                    Console.WriteLine($"Tổng số dòng dữ liệu: {rowCount - 1} (bỏ dòng tiêu đề)");
                    //Console.WriteLine("Danh sách Học Sinh:\n");

                    DateTime today = DateTime.Now;  // Ngày hiện tại (không giờ)
                    Console.WriteLine(today);
                    /////////////////////////////////////////////////////////////////////////////////////////////////////
                    ///


                    for (int row = 2; row <= rowCount; row++)
                    {
                        maHS.Add(worksheet.Cells[row, 1].Text);
                        tenHS.Add(worksheet.Cells[row, 2].Text);

                        double diemToanresul = 0;
                        double diemVanresul = 0;
                        double diemAnhresul = 0;

                        try
                        {
                            double.TryParse(worksheet.Cells[row, 3].Text, out diemToanresul);
                            double.TryParse(worksheet.Cells[row, 4].Text, out diemVanresul);
                            double.TryParse(worksheet.Cells[row, 5].Text, out diemAnhresul);

                        }
                        catch
                        {
                            Console.WriteLine($"Dòng {row} có dữ liệu lỗi");
                        }

                        diemToan.Add(diemToanresul);
                        diemVan.Add(diemVanresul);
                        diemAnh.Add(diemAnhresul);
                    }
                        for (int i = 0; i < maHS.Count; i++)
                        {
                            double tB = (diemToan[i] + diemAnh[i] + diemVan[i]) / 3;

                            tB = Math.Round(tB, 2);
                            diemTB.Add(tB);
  
                           // Console.WriteLine($"i = {i}, Excel Row = {i + 2}");
                            worksheet.Cells[i +2, 6].Value = tB;
 

                            string loai;

                            if (diemTB[i] >= 8)
                            {
                                loai = "Giỏi";
                            }
                            else if (diemTB[i] >= 6)
                            {
                                loai = "Khá";
                            }
                            else if (diemTB[i] >= 4)
                            {
                                loai = "Trung Binh";
                            }
                            else
                            {
                                loai = "Yếu";

                            }

                            xepLoai.Add(loai);
                            worksheet.Cells[i +2, 7].Value = loai;
         
                            switch (tB)
                            {
                                case 10:
                                    Console.WriteLine($"{tenHS[i]} Đạt điểm hoàn hảo");
                                    break;
                            }

                           
                        }

                        Console.WriteLine("Danh sách Học Sinh:");

                        int index = 0;

                        while (index < maHS.Count)
                        {
                            Console.WriteLine($"Mã Học Sinh        : {maHS[index]} ");
                            Console.WriteLine($"Tên Học Sinh       : {tenHS[index]} ");

                            Console.WriteLine($"Điểm Trung Bình    : {diemTB[index]}");
                            Console.WriteLine($"Xếp Loại           : {xepLoai[index]}\n");

                            index++;
                        }
                    Console.WriteLine("Lưu file");
                    packge.Save();
                    Console.WriteLine("Lưu Thành công");
                   
                }

                
            }

            catch (Exception ex)
            {
                Console.WriteLine("Lỗi ghi file:");
                Console.WriteLine(ex.Message);
            }



            using (ExcelPackage package = new ExcelPackage(output2Path))
            {
                var ws = package.Workbook.Worksheets.Add("KetQua");

                ws.Cells[1, 1].Value = "Mã HS";
                ws.Cells[1, 2].Value = "Tên";
                ws.Cells[1, 3].Value = "Trung bình";
                ws.Cells[1, 4].Value = "Xếp loại";

                for (int i = 0; i < maHS.Count; i++)
                {
                    ws.Cells[i + 2, 1].Value = maHS[i];
                    ws.Cells[i + 2, 2].Value = tenHS[i];
                    ws.Cells[i + 2, 3].Value = diemTB[i];
                    ws.Cells[i + 2, 4].Value = xepLoai[i];
                }
                Console.WriteLine("file mới 2");
                package.Save();
                Console.WriteLine(" dã ok");
            }

            Console.WriteLine("Đã ghi file output.xlsx thành công.");
        }
            
 
        
    }
}
