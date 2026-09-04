using System.Windows;
using System.Windows.Media;

namespace Caui_truc_thanh_phan_WPF;

/// <summary>
/// Bai tap 1: May tinh BMI (Body Mass Index)
///
/// GIAI THICH LOGIC:
/// 1. Lay gia tri tu 2 TextBox (txtHeight, txtWeight)
/// 2. Kiem tra du lieu hop le (khong rong, la so, > 0)
/// 3. Tinh BMI = can_nang / (chieu_cao_met ^ 2)
/// 4. Phan loai BMI va hien thi ket qua
///
/// CONG THUC BMI:
///   BMI = weight(kg) / height(m)^2
///   Vi du: 70kg, 170cm => BMI = 70 / (1.7 * 1.7) = 24.22
/// </summary>
public partial class Bai1_BMI : Window
{
    public Bai1_BMI()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Xu ly su kien khi nguoi dung nhan nut "TINH BMI"
    /// </summary>
    private void Calculate_Click(object sender, RoutedEventArgs e)
    {
        // ---- BUOC 1: Lay gia tri tu TextBox ----
        string heightText = txtHeight.Text;
        string weightText = txtWeight.Text;

        // ---- BUOC 2: Kiem tra rong ----
        if (string.IsNullOrWhiteSpace(heightText) || string.IsNullOrWhiteSpace(weightText))
        {
            MessageBox.Show("Vui long nhap day du chieu cao va can nang!",
                "Thong bao", MessageBoxButton.OK, MessageBoxImage.Warning);
            return; // Thoat khoi ham, khong tinh nua
        }

        // ---- BUOC 3: Chuyen doi tu chuoi sang so ----
        // TryParse: thu chuyen chuoi thanh so
        //   - Thanh cong: tra ve true, gia tri luu vao bien height/weight
        //   - That bai: tra ve false (vd: nhap "abc")
        if (!double.TryParse(heightText, out double heightCm) ||
            !double.TryParse(weightText, out double weight))
        {
            MessageBox.Show("Vui long nhap so hop le!",
                "Loi", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        // ---- BUOC 4: Kiem tra gia tri hop ly ----
        if (heightCm <= 0 || weight <= 0)
        {
            MessageBox.Show("Chieu cao va can nang phai lon hon 0!",
                "Loi", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        // ---- BUOC 5: Tinh BMI ----
        // Doi cm sang met: 170cm => 1.70m
        double heightM = heightCm / 100.0;

        // Cong thuc BMI = can_nang / (chieu_cao ^ 2)
        double bmi = weight / (heightM * heightM);

        // ---- BUOC 6: Phan loai BMI ----
        string category;
        Color color;

        if (bmi < 18.5)
        {
            category = "Gay (Underweight)";
            color = Color.FromRgb(23, 162, 184);   // Xanh duong nhat
        }
        else if (bmi < 25)
        {
            category = "Binh thuong (Normal)";
            color = Color.FromRgb(40, 167, 69);    // Xanh la
        }
        else if (bmi < 30)
        {
            category = "Thua can (Overweight)";
            color = Color.FromRgb(255, 193, 7);    // Vang
        }
        else
        {
            category = "Beo phi (Obese)";
            color = Color.FromRgb(220, 53, 69);    // Do
        }

        // ---- BUOC 7: Hien thi ket qua ----
        // bmi:F2 => format so voi 2 chu so thap phan (vd: 24.22)
        lblBMIValue.Content = $"BMI: {bmi:F2}";
        lblBMIValue.Foreground = new SolidColorBrush(color);

        lblBMICategory.Content = category;
        lblBMICategory.Foreground = new SolidColorBrush(color);
    }
}
