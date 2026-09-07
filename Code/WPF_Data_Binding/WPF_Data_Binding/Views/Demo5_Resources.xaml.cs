using System.Windows;
using System.Windows.Media;

namespace WPF_Data_Binding.Views;

/// <summary>
/// Demo 5: Resources - StaticResource vs DynamicResource
///
/// StaticResource:
/// - Load 1 lan khi Window khoi tao (compile time)
/// - Khong doi khi thay doi Resource luc runtime
/// - Nhanh hon → dung cho 90% truong hop
///
/// DynamicResource:
/// - Lookup moi lan su dung (runtime)
/// - Tu dong cap nhat khi Resource thay doi luc runtime
/// - Cham hon → chi dung khi can thay doi dong (theme, da ngon ngu)
///
/// Cach thay doi Resource luc runtime:
/// this.Resources["Key"] = new SolidColorBrush(newColor);
/// → Chi DynamicResource cap nhat, StaticResource giu nguyen
/// </summary>
public partial class Demo5_Resources : Window
{
    public Demo5_Resources()
    {
        InitializeComponent();
    }

    private void ChangeThemeColor_Click(object sender, RoutedEventArgs e)
    {
        // Tao mau ngau nhien
        Random rnd = new Random();
        Color randomColor = Color.FromRgb(
            (byte)rnd.Next(256),
            (byte)rnd.Next(256),
            (byte)rnd.Next(256)
        );

        // Thay doi Resource "ThemeColor" luc runtime
        // Cach lam: gan gia tri moi cho key trong Resources dictionary
        this.Resources["ThemeColor"] = new SolidColorBrush(randomColor);

        // KET QUA:
        // - Button dung StaticResource ThemeColor → KHONG doi mau (van giu mau cu)
        //   Vi StaticResource da load gia tri 1 lan luc khoi tao va khong theo doi thay doi
        //
        // - Button dung DynamicResource ThemeColor → DOI sang mau moi
        //   Vi DynamicResource lien tuc theo doi Resources dictionary
        //   Khi phat hien key "ThemeColor" co gia tri moi → tu dong cap nhat

        MessageBox.Show(
            $"Da doi ThemeColor thanh: #{randomColor.R:X2}{randomColor.G:X2}{randomColor.B:X2}\n\n" +
            "- Button STATIC: giu nguyen mau cu (load 1 lan)\n" +
            "- Button DYNAMIC: doi sang mau moi (cap nhat runtime)\n\n" +
            "→ Dung StaticResource cho 90% truong hop (nhanh hon)\n" +
            "→ Dung DynamicResource khi can doi theme dong",
            "StaticResource vs DynamicResource",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }
}
