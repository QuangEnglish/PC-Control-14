using System;
using System.Collections.Generic;

namespace BaiTapOOP
{
    public interface IDieuKhien
    {
        void BatDau();
        void DungLai();
    }

    public interface IGiamSat
    {
        void HienThiTrangThai();
    }

    public interface IBaoTri
    {
        void BaoTri();
    }

    public class TinhKeThua_CamBien
    {
        public bool DangHoatDong { get; set; }
        protected string MaCamBien { get; set; }

        public TinhKeThua_CamBien(string ma)
        {
            MaCamBien = ma;
            DangHoatDong = false;
        }

        public virtual void DocDuLieu()
        {
            Console.WriteLine("Dang doc du lieu cam bien");
        }
    }

    public class TinhKeThua_CamBienNhietDo : TinhKeThua_CamBien
    {
        public double NhietDo { get; set; }

        public TinhKeThua_CamBienNhietDo(string ma, double nhietDo) : base(ma)
        {
            NhietDo = nhietDo;
            DangHoatDong = true;
        }

        public override void DocDuLieu()
        {
            Console.WriteLine("Nhiet do hien tai: " + NhietDo);
        }
    }

    public class TinhKeThua_CamBienApSuat : TinhKeThua_CamBien
    {
        public double ApSuat { get; set; }

        public TinhKeThua_CamBienApSuat(string ma, double apSuat) : base(ma)
        {
            ApSuat = apSuat;
            DangHoatDong = true;
        }

        public override void DocDuLieu()
        {
            Console.WriteLine("Ap suat hien tai: " + ApSuat);
        }
    }

    public class TinhDaHinh_DungCoBan
    {
        public virtual void DungLai()
        {
            Console.WriteLine("Dung hoat dong binh thuong.");
        }
    }

    public class TinhDaHinh_DungKhanCap : TinhDaHinh_DungCoBan
    {
        public sealed override void DungLai()
        {
            Console.WriteLine("DUNG KHAN CAP HE THONG!");
        }
    }

    public abstract class TinhTruongTuong_MayMoc
    {
        public abstract void BatDau();
        public abstract void DungLai();
    }

    public class TinhTruongTuong_Roto : TinhTruongTuong_MayMoc, IBaoTri
    {
        public override void BatDau()
        {
            Console.WriteLine("Robot dang khoi dong...");
        }

        public override void DungLai()
        {
            Console.WriteLine("Robot dang dung lai...");
        }

        public void BaoTri()
        {
            Console.WriteLine("Dang tien hanh bao tri robot.");
        }
    }

    public class TinhDongGoi_DongCo : IDieuKhien, IGiamSat
    {
        private bool dangChay;
        private double nhietDo;
        private double apSuat;

        public bool DangChay
        {
            get { return dangChay; }
            set { dangChay = value; }
        }

        public double NhietDo
        {
            get { return nhietDo; }
            set { nhietDo = value; }
        }

        public double ApSuat
        {
            get { return apSuat; }
            set { apSuat = value; }
        }

        public TinhDongGoi_DongCo(double nhietDo, double apSuat)
        {
            this.nhietDo = nhietDo;
            this.apSuat = apSuat;
            this.dangChay = false;
        }

        public void BatDau()
        {
            this.dangChay = true;
            Console.WriteLine("Dong co bat dau chay.");
        }

        public void DungLai()
        {
            this.dangChay = false;
            Console.WriteLine("Dong co da dung.");
        }

        public void HienThiTrangThai()
        {
            Console.WriteLine("Trang thai Dong Co - Nhiet do: " + this.nhietDo + ", Ap suat: " + this.apSuat);
        }
    }

    public class QuanLyThietBi
    {
        private List<IGiamSat> danhSachGiamSat = new List<IGiamSat>();
        private List<IDieuKhien> danhSachDieuKhien = new List<IDieuKhien>();

        public void ThemThietBiGiamSat(IGiamSat thietBi)
        {
            danhSachGiamSat.Add(thietBi);
        }

        public void ThemThietBiDieuKhien(IDieuKhien thietBi)
        {
            danhSachDieuKhien.Add(thietBi);
        }

        public void HienThiTatCaTrangThai()
        {
            foreach (var thietBi in danhSachGiamSat)
            {
                thietBi.HienThiTrangThai();
            }
        }

        public void KiemTraThietBiDangChay()
        {
            Console.WriteLine("Danh sach thiet bi dang chay:");
            foreach (var thietBi in danhSachDieuKhien)
            {
                if (thietBi is TinhDongGoi_DongCo)
                {
                    TinhDongGoi_DongCo dongCo = (TinhDongGoi_DongCo)thietBi;
                    if (dongCo.DangChay)
                    {
                        Console.WriteLine("- Dong co dang trong trang thai hoat dong!");
                    }
                }
            }
        }
    }

    class btOOP
    {
        static void Main(string[] args)
        {
            TinhKeThua_CamBienNhietDo cbNhietDo = new TinhKeThua_CamBienNhietDo("CB01", 36.5);
            TinhKeThua_CamBienApSuat cbApSuat = new TinhKeThua_CamBienApSuat("CB02", 101.3);

            cbNhietDo.DocDuLieu();
            cbApSuat.DocDuLieu();

            TinhDaHinh_DungCoBan dungThuong = new TinhDaHinh_DungCoBan();
            TinhDaHinh_DungKhanCap dungKhanCap = new TinhDaHinh_DungKhanCap();

            dungThuong.DungLai();
            dungKhanCap.DungLai();

            TinhTruongTuong_Roto robot = new TinhTruongTuong_Roto();
            robot.BatDau();
            robot.BaoTri();
            robot.DungLai();

            TinhDongGoi_DongCo dongCo = new TinhDongGoi_DongCo(45.0, 2.5);
            dongCo.BatDau();

            QuanLyThietBi quanLy = new QuanLyThietBi();
            quanLy.ThemThietBiGiamSat(dongCo);
            quanLy.ThemThietBiDieuKhien(dongCo);

            quanLy.HienThiTatCaTrangThai();
            quanLy.KiemTraThietBiDangChay();

            Console.ReadLine();
        }
    }
}