using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using WPF_Data_Binding.Models;

namespace WPF_Data_Binding.Views;

/// <summary>
/// Demo 4: ObservableCollection - Danh sach tu dong cap nhat
///
/// ObservableCollection vs List:
/// - List<T>: khi Add/Remove → UI KHONG biet → KHONG cap nhat
/// - ObservableCollection<T>: khi Add/Remove → phat event CollectionChanged → UI cap nhat
///
/// Quy trinh:
/// 1. students.Add(newStudent) → ObservableCollection phat event CollectionChanged
/// 2. ListBox (dang lang nghe) nhan event → them 1 item moi vao giao dien
/// 3. Nguoi dung thay item moi xuat hien MA KHONG can lam gi them
/// </summary>
public partial class Demo4_ObservableCollection : Window
{
    // Dung ObservableCollection THAY VI List
    // Vi ObservableCollection tu dong thong bao UI khi Add/Remove/Clear
    private ObservableCollection<Student> _students;

    public Demo4_ObservableCollection()
    {
        InitializeComponent();

        // Tao ObservableCollection voi du lieu mau
        _students = new ObservableCollection<Student>
        {
            new Student { Name = "Nguyen Van A", Age = 20, GPA = 3.5, Class = "CNTT K15" },
            new Student { Name = "Tran Thi B", Age = 21, GPA = 3.8, Class = "CNTT K15" },
            new Student { Name = "Le Van C", Age = 19, GPA = 3.2, Class = "CNTT K15" }
        };

        // Dat DataContext cho ListBox
        // ItemsSource="{Binding}" trong XAML se lay du lieu tu day
        lstStudents.DataContext = _students;

        // Lang nghe su kien CollectionChanged de cap nhat so luong
        // Moi khi Add/Remove/Clear → cap nhat TextBlock hien thi so luong
        _students.CollectionChanged += Students_CollectionChanged;

        // Cap nhat so luong ban dau
        UpdateCount();
    }

    private void Students_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        // Duoc goi tu dong moi khi collection thay doi
        // e.Action cho biet hanh dong: Add, Remove, Reset (Clear)...
        UpdateCount();
    }

    private void UpdateCount()
    {
        txtCount.Text = _students.Count.ToString();
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        // Lay du lieu tu form
        string name = txtName.Text.Trim();
        string ageText = txtAge.Text.Trim();
        string gpaText = txtGPA.Text.Trim();

        // ========== VALIDATE ==========
        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show("Vui long nhap ho ten!", "Canh bao",
                          MessageBoxButton.OK, MessageBoxImage.Warning);
            txtName.Focus();
            return;
        }

        if (!int.TryParse(ageText, out int age) || age < 18 || age > 100)
        {
            MessageBox.Show("Tuoi khong hop le (18-100)!", "Canh bao",
                          MessageBoxButton.OK, MessageBoxImage.Warning);
            txtAge.Focus();
            return;
        }

        if (!double.TryParse(gpaText, out double gpa) || gpa < 0 || gpa > 4)
        {
            MessageBox.Show("GPA khong hop le (0-4)!", "Canh bao",
                          MessageBoxButton.OK, MessageBoxImage.Warning);
            txtGPA.Focus();
            return;
        }

        // ========== THEM SINH VIEN ==========
        Student newStudent = new Student
        {
            Name = name,
            Age = age,
            GPA = gpa,
            Class = "CNTT K15"
        };

        // DIEM THEN CHOT:
        // students.Add() → ObservableCollection phat event CollectionChanged
        // → ListBox nhan event → tu dong them 1 item moi vao giao dien
        // Neu dung List<T> thi UI SE KHONG cap nhat!
        _students.Add(newStudent);

        // Clear form sau khi them thanh cong
        txtName.Clear();
        txtAge.Clear();
        txtGPA.Clear();
        txtName.Focus();
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        // Lay Student tu Tag cua Button
        // Trong XAML: Tag="{Binding}" → Tag chua reference den Student object
        Button btn = (Button)sender;
        Student? student = btn.Tag as Student;

        if (student != null)
        {
            var result = MessageBox.Show(
                $"Ban co chac muon xoa sinh vien: {student.Name}?",
                "Xac nhan",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // students.Remove() → ObservableCollection phat event
                // → ListBox tu dong xoa item khoi giao dien
                _students.Remove(student);
            }
        }
    }

    private void ClearAll_Click(object sender, RoutedEventArgs e)
    {
        if (_students.Count == 0)
        {
            MessageBox.Show("Danh sach da trong!", "Thong bao");
            return;
        }

        var result = MessageBox.Show(
            $"Ban co chac muon xoa tat ca {_students.Count} sinh vien?",
            "Xac nhan",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            // students.Clear() → ObservableCollection phat event Reset
            // → ListBox tu dong xoa TAT CA items khoi giao dien
            _students.Clear();
        }
    }
}
