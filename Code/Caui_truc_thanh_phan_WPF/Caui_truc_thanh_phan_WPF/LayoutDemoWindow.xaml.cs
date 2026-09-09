using System.Windows;

namespace Caui_truc_thanh_phan_WPF;

/// <summary>
/// LayoutDemoWindow - Minh hoa 3 loai Layout Controls:
/// 1. Grid: Chia o luoi (Row/Column) - dung cho form phuc tap
/// 2. StackPanel: Xep chong (doc/ngang) - dung cho menu, form don gian
/// 3. DockPanel: Dan vao 4 canh - dung cho layout app co header/sidebar
/// </summary>
public partial class LayoutDemoWindow : Window
{
    public LayoutDemoWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Xu ly su kien click nut "Dang nhap" trong Grid demo
    ///
    /// Giai thich:
    /// - txtLoginUser.Text: Lay noi dung nguoi dung nhap trong TextBox
    /// - txtLoginPass.Password: Lay mat khau tu PasswordBox (dung .Password, KHONG phai .Text)
    /// - MessageBox.Show(): Hien thi hop thoai thong bao
    /// </summary>
    private void LoginDemo_Click(object sender, RoutedEventArgs e)
    {
        string username = txtLoginUser.Text;
        string password = txtLoginPass.Password;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Vui long nhap day du thong tin!", "Thong bao",
                MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        else
        {
            MessageBox.Show($"Dang nhap voi user: {username}", "Thanh cong",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
