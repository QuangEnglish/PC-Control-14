using System.Windows;
using System.Windows.Controls;

namespace Caui_truc_thanh_phan_WPF;

/// <summary>
/// Bai tap 3: Ung dung Quan ly Sinh vien
///
/// GIAI THICH TONG QUAN:
/// - Dung List&lt;SinhVien&gt; de luu danh sach sinh vien trong bo nho
/// - ListBox hien thi danh sach o giao dien
/// - Cac chuc nang: Them, Sua, Xoa, Lam moi
///
/// CAU TRUC LAYOUT:
///   DockPanel
///   ├── Header (Top): Tieu de
///   ├── Footer (Bottom): Thong tin
///   ├── Sidebar (Left): Menu chuc nang
///   └── Content (Center): Grid
///       ├── Cot 0: Form nhap lieu
///       └── Cot 1: Danh sach ListBox
/// </summary>
public partial class Bai3_QuanLySinhVien : Window
{
    // =============================================
    // Danh sach luu tru sinh vien trong bo nho
    // List<SinhVien> la mang dong, co the them/xoa tu do
    // =============================================
    private List<SinhVien> danhSachSV = new List<SinhVien>();

    public Bai3_QuanLySinhVien()
    {
        InitializeComponent();
    }

    // =============================================
    // CHUC NANG 1: THEM sinh vien
    // =============================================
    private void BtnAdd_Click(object sender, RoutedEventArgs e)
    {
        // Buoc 1: Lay du lieu tu form
        string maSV = txtMaSV.Text.Trim();
        string hoTen = txtHoTen.Text.Trim();
        string lop = txtLop.Text.Trim();
        string diemText = txtDiem.Text.Trim();

        // Buoc 2: Validate
        if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(hoTen) ||
            string.IsNullOrEmpty(lop) || string.IsNullOrEmpty(diemText))
        {
            MessageBox.Show("Vui long nhap day du thong tin!", "Loi",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        // Kiem tra diem co phai la so hop le khong
        if (!double.TryParse(diemText, out double diem) || diem < 0 || diem > 10)
        {
            MessageBox.Show("Diem phai la so tu 0 den 10!", "Loi",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        // Kiem tra ma SV da ton tai chua
        if (danhSachSV.Any(sv => sv.MaSV == maSV))
        {
            MessageBox.Show("Ma sinh vien da ton tai!", "Loi",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        // Buoc 3: Tao doi tuong SinhVien moi va them vao danh sach
        SinhVien svMoi = new SinhVien
        {
            MaSV = maSV,
            HoTen = hoTen,
            Lop = lop,
            DiemTB = diem
        };

        danhSachSV.Add(svMoi);

        // Buoc 4: Cap nhat giao dien
        CapNhatDanhSach();
        ClearForm();

        MessageBox.Show("Them sinh vien thanh cong!", "Thanh cong",
            MessageBoxButton.OK, MessageBoxImage.Information);
    }

    // =============================================
    // CHUC NANG 2: SUA thong tin sinh vien
    // =============================================
    private void BtnEdit_Click(object sender, RoutedEventArgs e)
    {
        // Kiem tra da chon sinh vien trong ListBox chua
        if (lstSinhVien.SelectedIndex < 0)
        {
            MessageBox.Show("Vui long chon sinh vien can sua trong danh sach!", "Thong bao",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        // Lay du lieu tu form
        string hoTen = txtHoTen.Text.Trim();
        string lop = txtLop.Text.Trim();
        string diemText = txtDiem.Text.Trim();

        if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(lop) ||
            string.IsNullOrEmpty(diemText))
        {
            MessageBox.Show("Vui long nhap day du thong tin!", "Loi",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (!double.TryParse(diemText, out double diem) || diem < 0 || diem > 10)
        {
            MessageBox.Show("Diem phai la so tu 0 den 10!", "Loi",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        // Cap nhat thong tin sinh vien duoc chon
        int index = lstSinhVien.SelectedIndex;
        danhSachSV[index].HoTen = hoTen;
        danhSachSV[index].Lop = lop;
        danhSachSV[index].DiemTB = diem;

        CapNhatDanhSach();
        MessageBox.Show("Cap nhat thanh cong!", "Thanh cong",
            MessageBoxButton.OK, MessageBoxImage.Information);
    }

    // =============================================
    // CHUC NANG 3: XOA sinh vien
    // =============================================
    private void BtnDelete_Click(object sender, RoutedEventArgs e)
    {
        if (lstSinhVien.SelectedIndex < 0)
        {
            MessageBox.Show("Vui long chon sinh vien can xoa!", "Thong bao",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        // Hoi xac nhan truoc khi xoa
        var result = MessageBox.Show("Ban co chac chan muon xoa sinh vien nay?",
            "Xac nhan xoa", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            int index = lstSinhVien.SelectedIndex;
            danhSachSV.RemoveAt(index); // Xoa khoi List theo vi tri

            CapNhatDanhSach();
            ClearForm();

            MessageBox.Show("Da xoa sinh vien!", "Thanh cong",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    // =============================================
    // CHUC NANG 4: LAM MOI form nhap lieu
    // =============================================
    private void BtnClear_Click(object sender, RoutedEventArgs e)
    {
        ClearForm();
    }

    // =============================================
    // SU KIEN: Khi chon 1 sinh vien trong ListBox
    // => Hien thi thong tin len form de xem/sua
    // =============================================
    private void LstSinhVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (lstSinhVien.SelectedIndex >= 0 && lstSinhVien.SelectedIndex < danhSachSV.Count)
        {
            // Lay sinh vien duoc chon
            SinhVien sv = danhSachSV[lstSinhVien.SelectedIndex];

            // Hien thi thong tin len form
            txtMaSV.Text = sv.MaSV;
            txtHoTen.Text = sv.HoTen;
            txtLop.Text = sv.Lop;
            txtDiem.Text = sv.DiemTB.ToString("F1"); // F1 = 1 chu so thap phan

            // Khoa truong Ma SV khi sua (khong cho doi ma)
            txtMaSV.IsReadOnly = true;
            txtMaSV.Background = new System.Windows.Media.SolidColorBrush(
                System.Windows.Media.Color.FromRgb(240, 240, 240));
        }
    }

    // =============================================
    // HAM PHU TRO: Cap nhat ListBox tu danh sach
    // =============================================
    private void CapNhatDanhSach()
    {
        // Xoa tat ca items cu trong ListBox
        lstSinhVien.Items.Clear();

        // Duyet qua tung sinh vien va them vao ListBox
        foreach (SinhVien sv in danhSachSV)
        {
            // Hien thi thong tin dang: "SV001 | Nguyen Van A | CNTT01 | 8.5"
            string display = $"{sv.MaSV}  |  {sv.HoTen}  |  {sv.Lop}  |  DTB: {sv.DiemTB:F1}";
            lstSinhVien.Items.Add(display);
        }

        // Cap nhat so luong
        lblCount.Content = $"Tong: {danhSachSV.Count} sinh vien";
    }

    // =============================================
    // HAM PHU TRO: Xoa toan bo form nhap lieu
    // =============================================
    private void ClearForm()
    {
        txtMaSV.Text = "";
        txtHoTen.Text = "";
        txtLop.Text = "";
        txtDiem.Text = "";

        // Mo khoa lai truong Ma SV
        txtMaSV.IsReadOnly = false;
        txtMaSV.Background = System.Windows.Media.Brushes.White;

        // Bo chon trong ListBox
        lstSinhVien.SelectedIndex = -1;
    }
}

/// <summary>
/// Class SinhVien - Luu thong tin 1 sinh vien
///
/// GIAI THICH:
/// Day la 1 class don gian (POCO - Plain Old CLR Object)
/// Chi chua cac thuoc tinh (Properties) de luu du lieu.
/// Moi sinh vien co: Ma SV, Ho ten, Lop, Diem TB
/// </summary>
public class SinhVien
{
    public string MaSV { get; set; } = "";
    public string HoTen { get; set; } = "";
    public string Lop { get; set; } = "";
    public double DiemTB { get; set; }
}
