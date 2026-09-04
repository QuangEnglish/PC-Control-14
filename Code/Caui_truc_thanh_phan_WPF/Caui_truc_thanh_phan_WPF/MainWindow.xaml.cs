using System.Windows;

namespace Caui_truc_thanh_phan_WPF;

/// <summary>
/// MainWindow - Trang dieu huong chinh
/// Minh hoa: DockPanel layout voi Header/Footer/Sidebar/Content
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        // InitializeComponent() la bat buoc!
        // No doc file XAML va tao cac control tuong ung
        InitializeComponent();
    }

    // =============================================
    // XU LY SU KIEN CLICK - Mo cac cua so demo
    // =============================================

    private void OpenLayoutDemo_Click(object sender, RoutedEventArgs e)
    {
        // Tao mot instance cua LayoutDemoWindow va hien thi
        var window = new LayoutDemoWindow();
        window.Show(); // Show() = hien thi khong chan (non-modal)
    }

    private void OpenControlsDemo_Click(object sender, RoutedEventArgs e)
    {
        var window = new ControlsDemoWindow();
        window.Show();
    }

    private void OpenBai1_Click(object sender, RoutedEventArgs e)
    {
        var window = new Bai1_BMI();
        window.Show();
    }

    private void OpenBai2_Click(object sender, RoutedEventArgs e)
    {
        var window = new Bai2_DangKy();
        window.Show();
    }

    private void OpenBai3_Click(object sender, RoutedEventArgs e)
    {
        var window = new Bai3_QuanLySinhVien();
        window.Show();
    }
}
