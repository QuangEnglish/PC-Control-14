using OfficeOpenXml;

namespace file_excel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tư duy đọc excel
            // 
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Đường dẫn file Excel (thay đổi theo máy bạn)
            string path = @"D:\HocC#\New folder\lich_bao_tri.xlsx";  // Đổi đuôi thành .xlsx

            if (!File.Exists(path))
            {
                Console.WriteLine("Không tìm thấy file Excel tại: " + path);
                Console.WriteLine("Hãy tạo file mẫu theo hướng dẫn bên dưới và đặt đúng đường dẫn.");
                Console.ReadKey();
                return;
            }

            try
            {
                // 
                ExcelPackage.License.SetNonCommercialOrganization("Học lập trình C# - Cá nhân");
                using (var package = new ExcelPackage(new FileInfo(path)))
                {
                    // Lấy sheet đầu tiên (hoặc dùng tên: package.Workbook.Worksheets["LichBaoTri"])
                    var worksheet = package.Workbook.Worksheets[0];

                    worksheet.Cells[1, 6].Value = "Tổng tiền";
                    worksheet.Cells[1, 6].Style.Font.Bold = true;

                    // Lấy số dòng và cột có dữ liệu thực tế
                    int rowCount = worksheet.Dimension?.Rows ?? 0;
                    int colCount = worksheet.Dimension?.Columns ?? 0;

                    if (rowCount < 2 || colCount < 3)
                    {
                        Console.WriteLine("File Excel không có dữ liệu hợp lệ (cần ít nhất 3 cột và 2 dòng).");
                        return;
                    }

                    Console.WriteLine($"Tổng số dòng dữ liệu: {rowCount - 1} (bỏ dòng tiêu đề)");
                    Console.WriteLine("Danh sách thiết bị và kiểm tra bảo trì:\n");

                    DateTime today = DateTime.Today;  // Ngày hiện tại (không giờ)

                    // Bắt đầu từ dòng 2 (bỏ tiêu đề dòng 1)
                    for (int row = 2; row <= rowCount; row++)
                    {
                        // Lấy giá trị các ô (cột 1,2,3)
                        string thietBi = worksheet.Cells[row, 1].Text?.Trim() ?? "";
                        string chuKy = worksheet.Cells[row, 2].Text?.Trim() ?? "";
                        string ngayCuoiStr = worksheet.Cells[row, 3].Text?.Trim() ?? "";
                        var donGia = worksheet.Cells[row, 4].Value;
                        var soLuong = worksheet.Cells[row, 5].Value;

                        double donGiaResul = 0;
                        double soLuongResul = 0;

                        if (donGia is double dg) { donGiaResul = dg; }
                        else
                        {
                            double.TryParse(donGia?.ToString(), out donGiaResul);
                        }
                        if (soLuong is double sl) { soLuongResul = sl; }
                        else
                        {
                            double.TryParse(soLuong?.ToString(), out soLuongResul);
                        }

                        double tongTien = donGiaResul * soLuongResul;

                        worksheet.Cells[row, 6].Value = tongTien;
                        worksheet.Cells[row, 6].Style.Numberformat.Format = "#,##0";

                        if (string.IsNullOrWhiteSpace(thietBi) || string.IsNullOrWhiteSpace(ngayCuoiStr))
                            continue; // Bỏ qua dòng trống

                        if (!DateTime.TryParse(ngayCuoiStr, out DateTime ngayCuoi))
                        {
                            Console.WriteLine($"Dòng {row}: Ngày cuối bảo trì không hợp lệ → {ngayCuoiStr}");
                            continue;
                        }

                        // In thông tin
                        Console.WriteLine($"Thiết bị: {thietBi,-30} | Chu kỳ: {chuKy,-15} | Ngày cuối: {ngayCuoi:dd/MM/yyyy}");

                        // Ví dụ so sánh: giả sử chu kỳ là "30 ngày", "3 tháng", "6 tháng", "12 tháng"
                        // Bạn có thể mở rộng logic này
                        TimeSpan thoiGianQua = today - ngayCuoi;
                        bool canBaoTri = false;

                        if (chuKy.Contains("ngày") || chuKy.Contains("day"))
                        {
                            if (int.TryParse(chuKy.Replace("ngày", "").Replace("day", "").Trim(), out int soNgay))
                                canBaoTri = thoiGianQua.TotalDays >= soNgay;
                        }
                        else if (chuKy.Contains("tháng") || chuKy.Contains("month"))
                        {
                            if (int.TryParse(chuKy.Replace("tháng", "").Replace("month", "").Trim(), out int soThang))
                                canBaoTri = ngayCuoi.AddMonths(soThang) <= today;
                        }
                        else if (chuKy.Contains("năm") || chuKy.Contains("year"))
                        {
                            if (int.TryParse(chuKy.Replace("năm", "").Replace("year", "").Trim(), out int soNam))
                                canBaoTri = ngayCuoi.AddYears(soNam) <= today;
                        }

                        if (canBaoTri)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"   → CẦN BẢO TRÌ NGAY! (Quá hạn {thoiGianQua.Days} ngày)");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine($"   → Còn OK (còn {thoiGianQua.Days} ngày nữa tùy chu kỳ)");
                        }
                        Console.WriteLine();
                    }
                    package.Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đọc file Excel: " + ex.Message);
            }

            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}          

        
    

