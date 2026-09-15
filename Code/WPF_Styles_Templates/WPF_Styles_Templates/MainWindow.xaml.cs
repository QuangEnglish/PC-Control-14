using System.Collections.ObjectModel;
using System.Windows;
using WPF_Styles_Templates.Models;

namespace WPF_Styles_Templates;

/// <summary>
/// MainWindow.xaml.cs - Code-behind chua du lieu mau cho demo
///
/// GIAI THICH TONG QUAN:
/// - File XAML dinh nghia GIAO DIEN (Style, Template, Layout)
/// - File .cs (code-behind) chua LOGIC va DU LIEU
/// - DataTemplate trong XAML se dung {Binding PropertyName} de hien thi du lieu tu day
///
/// ObservableCollection:
/// - Giong nhu List nhung CO thong bao khi thay doi (them/xoa item)
/// - Khi them/xoa item -> UI tu dong cap nhat (khong can lam gi them)
/// - Neu dung List thuong -> them/xoa item ma UI khong biet, khong cap nhat
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // ============================================================
        // TAO DU LIEU MAU CHO DEMO DATATEMPLATE - DANH BA
        // ============================================================
        // Moi Contact object se duoc hien thi theo ContactTemplate
        // {Binding Name}    -> "Nguyen Van A"
        // {Binding Phone}   -> "0123 456 789"
        // {Binding Email}   -> "vana@email.com"
        // {Binding Initial} -> "N" (computed property: chu cai dau)
        var contacts = new ObservableCollection<Contact>
        {
            new Contact
            {
                Name = "Nguyen Van An",
                Phone = "0123 456 789",
                Email = "vanan@email.com"
            },
            new Contact
            {
                Name = "Tran Thi Binh",
                Phone = "0987 654 321",
                Email = "thibinh@email.com"
            },
            new Contact
            {
                Name = "Le Van Cuong",
                Phone = "0912 345 678",
                Email = "vancuong@email.com"
            },
            new Contact
            {
                Name = "Pham Thi Dung",
                Phone = "0909 123 456",
                Email = "thidung@email.com"
            },
            new Contact
            {
                Name = "Hoang Minh Duc",
                Phone = "0938 765 432",
                Email = "minhduc@email.com"
            },
            new Contact
            {
                Name = "Vo Thi Huong",
                Phone = "0971 234 567",
                Email = "thihuong@email.com"
            }
        };

        // Gan du lieu vao ListBox bang ItemsSource
        // ListBox se dung ItemTemplate (ContactTemplate) de hien thi moi item
        ContactListBox.ItemsSource = contacts;


        // ============================================================
        // TAO DU LIEU MAU CHO DEMO DATATEMPLATE - SAN PHAM
        // ============================================================
        // Moi Product object se duoc hien thi theo ProductCard template
        // {Binding Price, StringFormat='{}{0:N0} VND'} -> "25,000,000 VND"
        //   StringFormat giup dinh dang so (them dau phay phan nghin)
        var products = new ObservableCollection<Product>
        {
            new Product
            {
                Name = "Laptop Dell XPS 13",
                Price = 25_000_000,
                Rating = 4.5,
                Stock = 5
            },
            new Product
            {
                Name = "iPhone 15 Pro Max",
                Price = 35_000_000,
                Rating = 4.8,
                Stock = 10
            },
            new Product
            {
                Name = "Samsung Galaxy S24",
                Price = 22_000_000,
                Rating = 4.6,
                Stock = 8
            },
            new Product
            {
                Name = "MacBook Air M3",
                Price = 28_000_000,
                Rating = 4.7,
                Stock = 3
            },
            new Product
            {
                Name = "iPad Pro 12.9 inch",
                Price = 32_000_000,
                Rating = 4.9,
                Stock = 7
            },
            new Product
            {
                Name = "AirPods Pro 2",
                Price = 6_500_000,
                Rating = 4.4,
                Stock = 15
            }
        };

        ProductListBox.ItemsSource = products;
    }
}
