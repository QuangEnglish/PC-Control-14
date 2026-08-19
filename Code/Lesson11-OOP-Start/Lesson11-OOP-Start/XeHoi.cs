using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11_OOP_Start
{
    internal class XeHoi
    {
        // Field (trường)

        // nơi lưu trữ dữ liệu thực tế
        private string _hangXe;
        private string _bienSo;
        private string _mauSac;
        private int _tocDo;
        private float _dungTich;
        private int _namSanXuat = 700;


        // Thuộc tính (properties)
        // là cánh cửa giúp bên ngoài đọc hoặc ghi dữ liệu lên Field (trường)
        public string HangXe
        {
            get { return _hangXe; }
            set { _hangXe = value; }
        }

        public string BienSo
        {
            get { return _bienSo; }
            set { _bienSo = value; }
        }

        public string MauSac { get; set; }
        public int TocDo
        {
            get { return _tocDo; }
            set
            {
                if (_tocDo < 100)
                {
                    _tocDo = value;
                }
            }
        }

        public float DungTich { get; set; }

        public int NamSanXuat
        {
            get { return _namSanXuat; }
            set
            {
                if (value >= 1990)
                {
                    _namSanXuat = value;
                }
            }
        }



        // Contructor
        public XeHoi() { }

        public XeHoi(int tocDo, float dungTich)
        {
            TocDo = tocDo;
            DungTich = dungTich;
        }

        public XeHoi(string mauSac, int tocDo, float dungTich)
        {
            MauSac = mauSac;
            TocDo = tocDo;
            DungTich = dungTich;
        }


        // Hành vi (hàm: method)
        public void Chay()
        {
            Console.WriteLine($"Xe màu {MauSac} đang chạy với tốc độ {TocDo} km/h với năm sản xuất là: {NamSanXuat}");
        }

        public double TieuHaoNhienLieu(int tocDo, float dungTich, float quangDuong)
        {
            double result = (tocDo / quangDuong) * dungTich;
            return result;
        }

    }
}
