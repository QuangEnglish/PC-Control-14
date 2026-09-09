using System.Windows;

namespace Demo_WPF;

/// <summary>
/// Code-behind: Xử lý logic cho MainWindow.xaml
/// Mỗi file .xaml sẽ có 1 file .xaml.cs tương ứng (partial class)
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        // Khởi tạo giao diện từ XAML → bắt buộc phải gọi
        InitializeComponent();
    }

    /// <summary>
    /// Sự kiện khi bấm nút "ĐĂNG KÝ"
    /// Tên hàm phải trùng với Click="BtnRegister_Click" trong XAML
    ///
    /// - sender: Đối tượng phát ra sự kiện (nút ĐĂNG KÝ)
    /// - e: Thông tin thêm về sự kiện (RoutedEventArgs)
    /// </summary>
    private void BtnRegister_Click(object sender, RoutedEventArgs e)
    {
        // === BƯỚC 1: Lấy dữ liệu từ các control trên giao diện ===
        // txtUsername.Text       → Lấy text từ TextBox
        // txtPassword.Password   → Lấy mật khẩu từ PasswordBox (không phải .Text)
        // txtEmail.Text          → Lấy email từ TextBox
        string username = txtUsername.Text.Trim();   // Trim() bỏ khoảng trắng đầu/cuối
        string password = txtPassword.Password;
        string email = txtEmail.Text.Trim();

        // rbMale.IsChecked == true → RadioButton "Nam" đang được chọn?
        string gender = rbMale.IsChecked == true ? "Nam" : "Nữ";

        // chkAgree.IsChecked == true → CheckBox có được tích không?
        bool isAgreed = chkAgree.IsChecked == true;

        // === BƯỚC 2: Kiểm tra dữ liệu (Validation) ===
        // string.IsNullOrWhiteSpace(): Kiểm tra chuỗi rỗng hoặc toàn khoảng trắng
        if (string.IsNullOrWhiteSpace(username))
        {
            // MessageBox.Show(): Hiển thị hộp thoại thông báo
            // Tham số: (nội dung, tiêu đề, nút bấm, icon)
            MessageBox.Show("Vui lòng nhập tên đăng nhập!",
                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtUsername.Focus(); // Đặt con trỏ vào ô tên đăng nhập
            return;              // Dừng hàm, không chạy tiếp
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Vui lòng nhập mật khẩu!",
                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtPassword.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            MessageBox.Show("Vui lòng nhập email!",
                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtEmail.Focus();
            return;
        }

        if (!isAgreed)
        {
            MessageBox.Show("Bạn cần đồng ý với điều khoản sử dụng!",
                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        // === BƯỚC 3: Hiển thị kết quả ===
        // Dùng string interpolation ($"...{biến}...") để ghép chuỗi
        string message = $"Đăng ký thành công!\n\n" +
                         $"Tên đăng nhập: {username}\n" +
                         $"Email: {email}\n" +
                         $"Giới tính: {gender}";

        MessageBox.Show(message, "Thành công",
            MessageBoxButton.OK, MessageBoxImage.Information);
    }

    /// <summary>
    /// Sự kiện khi bấm nút "HỦY"
    /// Xóa trắng tất cả các ô nhập liệu, đưa về trạng thái ban đầu
    /// </summary>
    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        // Xóa nội dung các TextBox và PasswordBox
        txtUsername.Text = string.Empty;      // hoặc = ""
        txtPassword.Password = string.Empty;
        txtEmail.Text = string.Empty;

        // Reset RadioButton về mặc định (chọn Nam)
        rbMale.IsChecked = true;

        // Bỏ tích CheckBox
        chkAgree.IsChecked = false;

        // Đặt con trỏ về ô đầu tiên
        txtUsername.Focus();
    }
}
