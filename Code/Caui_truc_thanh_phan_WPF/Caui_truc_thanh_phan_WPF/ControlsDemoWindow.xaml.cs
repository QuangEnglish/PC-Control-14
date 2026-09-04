using System.Windows;
using System.Windows.Controls;

namespace Caui_truc_thanh_phan_WPF;

/// <summary>
/// ControlsDemoWindow - Minh hoa 3 Controls co ban:
/// 1. Button: Nut bam - xu ly su kien Click
/// 2. TextBox: O nhap van ban - lay/gan gia tri bang .Text
/// 3. ComboBox: Danh sach tha xuong - chon 1 muc
/// </summary>
public partial class ControlsDemoWindow : Window
{
    public ControlsDemoWindow()
    {
        InitializeComponent();

        // =============================================
        // COMBOBOX: Them items tu Code C# (phuong phap tot hon)
        // Thay vi viet tung ComboBoxItem trong XAML,
        // ta tao 1 List<string> roi gan vao ItemsSource
        // =============================================
        List<string> cities = new List<string>
        {
            "Ha Noi",
            "Ho Chi Minh",
            "Da Nang",
            "Hai Phong",
            "Can Tho",
            "Hue",
            "Nha Trang"
        };

        cboCityDemo.ItemsSource = cities;    // Gan nguon du lieu
        cboCityDemo.SelectedIndex = 0;       // Chon muc dau tien (index = 0)
    }

    // =============================================
    // BUTTON: Xu ly su kien Click
    // =============================================

    /// <summary>
    /// sender: Doi tuong phat ra su kien (chinh la Button)
    /// RoutedEventArgs e: Thong tin ve su kien
    /// </summary>
    private void Save_Click(object sender, RoutedEventArgs e)
    {
        lblButtonResult.Content = "Ban da nhan nut LUU!";
        lblButtonResult.Foreground = new System.Windows.Media.SolidColorBrush(
            System.Windows.Media.Color.FromRgb(40, 167, 69)); // Mau xanh la
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        lblButtonResult.Content = "Ban da nhan nut HUY!";
        lblButtonResult.Foreground = new System.Windows.Media.SolidColorBrush(
            System.Windows.Media.Color.FromRgb(220, 53, 69)); // Mau do
    }

    private void Refresh_Click(object sender, RoutedEventArgs e)
    {
        lblButtonResult.Content = "Ban da nhan nut LAM MOI!";
        lblButtonResult.Foreground = new System.Windows.Media.SolidColorBrush(
            System.Windows.Media.Color.FromRgb(23, 162, 184)); // Mau xanh duong
    }

    private void ShowMessage_Click(object sender, RoutedEventArgs e)
    {
        // MessageBox.Show() hien thi hop thoai thong bao
        // Tham so: noi dung, tieu de, nut bam, icon
        MessageBox.Show(
            "Day la thong bao tu Button!",
            "Thong bao",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }

    /// <summary>
    /// Thay doi noi dung Button khi nhan
    /// btnChangeText.Content: thuoc tinh Content chua text hien thi tren Button
    /// </summary>
    private void ChangeText_Click(object sender, RoutedEventArgs e)
    {
        // Doi noi dung cua chinh nut do
        btnChangeText.Content = "Da nhan roi!";

        // Hien thi ket qua o Label
        lblButtonResult.Content = "Text cua Button da bi thay doi!";
    }

    // =============================================
    // TEXTBOX: Lay va Gan gia tri
    // =============================================

    /// <summary>
    /// LAY gia tri tu TextBox: dung thuoc tinh .Text
    /// txtDemoName.Text => tra ve chuoi nguoi dung da nhap
    /// </summary>
    private void GetName_Click(object sender, RoutedEventArgs e)
    {
        // Lay gia tri tu TextBox
        string name = txtDemoName.Text;

        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show("Vui long nhap ten!", "Canh bao",
                MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        else
        {
            MessageBox.Show("Ten ban la: " + name, "Thong tin",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    /// <summary>
    /// GAN gia tri cho TextBox: gan chuoi vao thuoc tinh .Text
    /// txtDemoName.Text = "..." => hien thi chuoi trong TextBox
    /// </summary>
    private void SetName_Click(object sender, RoutedEventArgs e)
    {
        txtDemoName.Text = "Nguyen Van A";
    }

    // =============================================
    // COMBOBOX: Lay gia tri da chon
    // =============================================

    /// <summary>
    /// Lay gia tri tu ComboBox:
    /// - Neu items la ComboBoxItem (dinh nghia trong XAML):
    ///   => Ep kieu: (ComboBoxItem)cbo.SelectedItem => lay .Content
    /// - Neu items la string (gan tu Code qua ItemsSource):
    ///   => Dung: cbo.SelectedItem?.ToString()
    /// </summary>
    private void ShowComboSelection_Click(object sender, RoutedEventArgs e)
    {
        // Kiem tra co chon muc nao khong
        if (cboLanguage.SelectedItem == null)
        {
            MessageBox.Show("Vui long chon ngon ngu!", "Canh bao");
            return;
        }

        // Lay gia tri tu ComboBox co ComboBoxItem (dinh nghia trong XAML)
        // Phai ep kieu ve ComboBoxItem roi lay Content
        ComboBoxItem selectedItem = (ComboBoxItem)cboLanguage.SelectedItem;
        string language = selectedItem.Content.ToString()!;

        // Lay gia tri tu ComboBox dung ItemsSource (load tu code)
        string? city = cboCityDemo.SelectedItem?.ToString();

        // Lay gia tri tu ComboBox co ComboBoxItem
        string? gender = ((ComboBoxItem)cboGenderDemo.SelectedItem).Content.ToString();

        lblComboResult.Content = $"Ngon ngu: {language} | Thanh pho: {city} | Gioi tinh: {gender}";
        lblComboResult.Foreground = new System.Windows.Media.SolidColorBrush(
            System.Windows.Media.Color.FromRgb(0, 123, 255));
    }
}
