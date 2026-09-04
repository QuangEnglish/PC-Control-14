using System.Windows;
using System.Windows.Controls;

namespace Caui_truc_thanh_phan_WPF;

/// <summary>
/// Bai tap 2: Form Dang ky voi Validation
///
/// GIAI THICH LOGIC VALIDATION:
/// Validation = kiem tra du lieu truoc khi xu ly.
/// Muc dich: Dam bao nguoi dung nhap dung, du thong tin.
///
/// Cac buoc:
/// 1. Lay gia tri tu tat ca cac control
/// 2. Kiem tra tung dieu kien (rong, email, mat khau, checkbox)
/// 3. Neu loi => hien thong bao va RETURN (dung lai)
/// 4. Neu OK => xu ly dang ky
/// </summary>
public partial class Bai2_DangKy : Window
{
    public Bai2_DangKy()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Xu ly khi nhan nut "DANG KY"
    /// Thuc hien validate tung buoc truoc khi chap nhan
    /// </summary>
    private void Register_Click(object sender, RoutedEventArgs e)
    {
        // ---- BUOC 1: Lay gia tri tu cac control ----

        string name = txtName.Text.Trim();           // .Trim() xoa khoang trang 2 dau
        string email = txtEmail.Text.Trim();
        string phone = txtPhone.Text.Trim();
        string password = txtPassword.Password;       // PasswordBox dung .Password (KHONG phai .Text)

        // Lay gia tri tu ComboBox (items dinh nghia trong XAML)
        string gender = ((ComboBoxItem)cboGender.SelectedItem).Content.ToString()!;

        // Lay trang thai CheckBox (.IsChecked tra ve bool? nen dung == true)
        bool agreed = chkAgree.IsChecked == true;

        // ---- BUOC 2: VALIDATE - Kiem tra du lieu ----

        // Validate 1: Kiem tra cac truong bat buoc
        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show("Vui long nhap ho ten!", "Loi",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            txtName.Focus(); // Dat con tro vao TextBox bi loi
            return;          // RETURN = dung lai, khong chay tiep
        }

        if (string.IsNullOrEmpty(email))
        {
            MessageBox.Show("Vui long nhap email!", "Loi",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            txtEmail.Focus();
            return;
        }

        if (string.IsNullOrEmpty(phone))
        {
            MessageBox.Show("Vui long nhap so dien thoai!", "Loi",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            txtPhone.Focus();
            return;
        }

        if (string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Vui long nhap mat khau!", "Loi",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            txtPassword.Focus();
            return;
        }

        // Validate 2: Kiem tra email co chua "@"
        if (!email.Contains("@") || !email.Contains("."))
        {
            MessageBox.Show("Email khong hop le! (phai co @ va .)", "Loi",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            txtEmail.Focus();
            return;
        }

        // Validate 3: Mat khau toi thieu 6 ky tu
        if (password.Length < 6)
        {
            MessageBox.Show("Mat khau phai co it nhat 6 ky tu!", "Loi",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            txtPassword.Focus();
            return;
        }

        // Validate 4: Phai dong y dieu khoan
        if (!agreed)
        {
            MessageBox.Show("Ban phai dong y voi dieu khoan su dung!", "Loi",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        // ---- BUOC 3: TAT CA HOP LE => Hien thi ket qua ----
        string message = $"Dang ky thanh cong!\n\n" +
                         $"Ho ten: {name}\n" +
                         $"Email: {email}\n" +
                         $"SDT: {phone}\n" +
                         $"Gioi tinh: {gender}\n" +
                         $"Mat khau: {"".PadLeft(password.Length, '*')}"; // An mat khau bang ***

        MessageBox.Show(message, "Thanh cong",
            MessageBoxButton.OK, MessageBoxImage.Information);
    }

    /// <summary>
    /// Xu ly khi nhan nut "HUY"
    /// Xoa toan bo du lieu da nhap trong form
    /// </summary>
    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        // Xoa tat ca TextBox
        txtName.Text = "";
        txtEmail.Text = "";
        txtPhone.Text = "";
        txtPassword.Password = "";

        // Reset ComboBox ve muc dau tien
        cboGender.SelectedIndex = 0;

        // Bo tick CheckBox
        chkAgree.IsChecked = false;
    }
}
