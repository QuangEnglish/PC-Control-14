namespace Lesson11_OOP_Start
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // OOP là 1 cách để tổ chức code xung quan đối tượng 
            // dễ quản lý code

            // Đối tượng- Object
            // Thuộc tính 
            // Hành Vi 

            // Class và Object
            // Class (Lớp) là 1 bản thiết kế hoặc khuôn mẫu, gồm thuộc tính và hành vi
            // Object (Đối tượng) là 1 thực thể cụ thể được sản xuất từ cái bản vẽ Class 
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            XeHoi xeHoiCuaAn = new XeHoi();
            xeHoiCuaAn.TocDo = 100000000;
            xeHoiCuaAn.MauSac = "Xanh";
            xeHoiCuaAn.NamSanXuat = 2000;
            xeHoiCuaAn.Chay();

            XeHoi xeHoiCuaAnCap3 = new XeHoi(20, 30);
            xeHoiCuaAnCap3.MauSac = "Xanh";
            xeHoiCuaAnCap3.Chay();

            // 4 tính chất OOP


        }
    }
}
