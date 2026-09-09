using System.Windows;
using WPF_Data_Binding.Models;

namespace WPF_Data_Binding.Views;

/// <summary>
/// Demo 2: DataContext - Nguon du lieu mac dinh
///
/// DataContext la nguon du lieu MAC DINH cho tat ca binding trong control va cac control con.
/// Khi dat: this.DataContext = student;
/// Thi tat ca {Binding PropertyName} trong XAML se tu dong lay gia tri tu student.PropertyName
///
/// VAN DE: Dung StudentBasic (KHONG co INotifyPropertyChanged)
/// → Khi thay doi student.Name trong code, UI KHONG tu dong cap nhat
/// → Chi khi gan DataContext = object MOI thi UI moi cap nhat
/// → Giai phap: dung INotifyPropertyChanged (xem Demo 3)
/// </summary>
public partial class Demo2_DataContext : Window
{
    // Luu reference den student de co the thay doi property sau nay
    private StudentBasic _student;

    public Demo2_DataContext()
    {
        InitializeComponent();

        // Buoc 1: Tao doi tuong Student
        _student = new StudentBasic
        {
            Name = "Nguyen Van A",
            Age = 20,
            Class = "CNTT K15",
            Email = "nguyenvana@email.com",
            GPA = 3.75
        };

        // Buoc 2: Dat DataContext cho Window
        // Tat ca control con (TextBlock, TextBox...) deu co the dung {Binding PropertyName}
        // de lay gia tri tu _student
        this.DataContext = _student;
    }

    private void ChangeName_Click(object sender, RoutedEventArgs e)
    {
        // Thay doi property cua student
        _student.Name = "Tran Van B (da thay doi)";
        _student.Age = 25;

        // UI SE KHONG tu dong cap nhat!
        // Vi StudentBasic KHONG co INotifyPropertyChanged
        // → UI khong biet la Name da thay doi
        // → UI van hien thi "Nguyen Van A"

        MessageBox.Show(
            $"student.Name = \"{_student.Name}\"\n" +
            $"student.Age = {_student.Age}\n\n" +
            "Nhung UI van hien thi gia tri cu!\n" +
            "Vi StudentBasic KHONG co INotifyPropertyChanged.",
            "Ket qua",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }

    private void LoadNewStudent_Click(object sender, RoutedEventArgs e)
    {
        // Tao object Student MOI hoan toan
        StudentBasic newStudent = new StudentBasic
        {
            Name = "Tran Thi B",
            Age = 21,
            Class = "CNTT K14",
            Email = "tranthib@email.com",
            GPA = 3.92
        };

        // Gan DataContext = object moi
        // → WPF doc lai TOAN BO binding tu object moi
        // → UI SE cap nhat (vi day la gan nguon du lieu moi, khong phai thay doi property)
        this.DataContext = newStudent;
        _student = newStudent;

        MessageBox.Show(
            "Da gan DataContext = Student moi.\n" +
            "UI cap nhat vi WPF doc lai toan bo binding tu object moi.\n\n" +
            "Luu y: Day KHONG phai la INotifyPropertyChanged,\n" +
            "ma la WPF tu doc lai khi DataContext thay doi.",
            "Thanh cong",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }
}
