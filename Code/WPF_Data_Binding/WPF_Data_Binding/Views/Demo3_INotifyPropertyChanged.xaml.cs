using System.Windows;
using WPF_Data_Binding.Models;

namespace WPF_Data_Binding.Views;

/// <summary>
/// Demo 3: INotifyPropertyChanged - Cap nhat tu dong
///
/// Su khac biet voi Demo 2:
/// - Demo 2 dung StudentBasic (KHONG co INPC) → thay doi property → UI KHONG cap nhat
/// - Demo 3 dung Student (CO INPC) → thay doi property → UI TU DONG cap nhat
///
/// Quy trinh hoat dong:
/// 1. student.GPA = 3.5 (set value)
/// 2. Trong setter cua GPA: _gpa = value → OnPropertyChanged("GPA")
/// 3. OnPropertyChanged phat event PropertyChanged
/// 4. UI (dang lang nghe event) nhan thong bao: "GPA da thay doi"
/// 5. UI doc lai gia tri GPA va cap nhat hien thi
/// </summary>
public partial class Demo3_INotifyPropertyChanged : Window
{
    // Dung Student (CO INotifyPropertyChanged), KHONG phai StudentBasic
    private Student _student;

    public Demo3_INotifyPropertyChanged()
    {
        InitializeComponent();

        // Tao Student voi INotifyPropertyChanged
        _student = new Student
        {
            Name = "Nguyen Van A",
            Age = 20,
            Class = "CNTT K15",
            GPA = 3.25
        };

        // Dat DataContext
        // Tat ca {Binding} trong XAML se lay du lieu tu _student
        this.DataContext = _student;
    }

    private void IncreaseGPA_Click(object sender, RoutedEventArgs e)
    {
        // Thay doi property trong code
        // Vi Student co INotifyPropertyChanged:
        // → setter cua GPA goi OnPropertyChanged("GPA")
        // → UI tu dong cap nhat hien thi GPA moi
        _student.GPA += 0.5;

        // Gioi han GPA toi da 4.0
        if (_student.GPA > 4.0)
            _student.GPA = 4.0;
    }

    private void DecreaseAge_Click(object sender, RoutedEventArgs e)
    {
        // Tuong tu, thay doi Age → UI tu dong cap nhat
        _student.Age -= 1;

        if (_student.Age < 18)
            _student.Age = 18;
    }

    private void Reset_Click(object sender, RoutedEventArgs e)
    {
        // Thay doi nhieu property cung luc
        // Moi property se goi OnPropertyChanged() rieng
        // → UI cap nhat TU DONG cho tat ca cac field
        _student.Name = "Nguyen Van A";
        _student.Age = 20;
        _student.Class = "CNTT K15";
        _student.GPA = 3.25;
    }
}
