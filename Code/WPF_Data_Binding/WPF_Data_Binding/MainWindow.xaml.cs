using System.Windows;
using System.Windows.Input;
using WPF_Data_Binding.Views;

namespace WPF_Data_Binding;

/// <summary>
/// MainWindow: Menu dieu huong den cac Demo
///
/// Cac demo bam sat noi dung bai giang Buoi 3:
/// - Demo 1: ElementName Binding (bind giua cac control)
/// - Demo 2: DataContext (nguon du lieu mac dinh, KHONG co INPC)
/// - Demo 3: INotifyPropertyChanged (UI tu dong cap nhat)
/// - Demo 4: ObservableCollection (danh sach tu dong cap nhat)
/// - Demo 5: Resources (StaticResource vs DynamicResource)
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Demo1_Click(object sender, MouseButtonEventArgs e)
    {
        var demo = new Demo1_ElementNameBinding();
        demo.Show();
    }

    private void Demo2_Click(object sender, MouseButtonEventArgs e)
    {
        var demo = new Demo2_DataContext();
        demo.Show();
    }

    private void Demo3_Click(object sender, MouseButtonEventArgs e)
    {
        var demo = new Demo3_INotifyPropertyChanged();
        demo.Show();
    }

    private void Demo4_Click(object sender, MouseButtonEventArgs e)
    {
        var demo = new Demo4_ObservableCollection();
        demo.Show();
    }

    private void Demo5_Click(object sender, MouseButtonEventArgs e)
    {
        var demo = new Demo5_Resources();
        demo.Show();
    }
}
