using System.ComponentModel;

namespace WPF_Data_Binding.Models;

/// <summary>
/// Class Student KHÔNG có INotifyPropertyChanged
/// Dùng để demo: khi thay đổi property, UI KHÔNG tự động cập nhật
/// </summary>
public class StudentBasic
{
    // Property đơn giản - auto property
    // Khi thay đổi giá trị, UI sẽ KHÔNG biết để cập nhật
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Class { get; set; } = string.Empty;
    public double GPA { get; set; }
    public string Email { get; set; } = string.Empty;
}

/// <summary>
/// Class Student CÓ INotifyPropertyChanged
/// Khi thay đổi property → phát ra event → UI tự động cập nhật
///
/// Cơ chế hoạt động:
/// 1. UI đăng ký lắng nghe event PropertyChanged
/// 2. Khi set giá trị mới cho property → gọi OnPropertyChanged()
/// 3. OnPropertyChanged() phát event → UI nhận được → UI cập nhật hiển thị
/// </summary>
public class Student : INotifyPropertyChanged
{
    // ========== EVENT ==========
    // Event bắt buộc phải có khi implement INotifyPropertyChanged
    // UI sẽ đăng ký (subscribe) vào event này để lắng nghe thay đổi
    public event PropertyChangedEventHandler? PropertyChanged;

    // Hàm helper để phát (raise) event
    // Khi gọi hàm này, tất cả subscriber (UI) sẽ nhận được thông báo
    protected void OnPropertyChanged(string propertyName)
    {
        // PropertyChanged?.Invoke() = kiểm tra null rồi gọi event
        // - this: object nào đang thay đổi (Student)
        // - propertyName: tên property nào thay đổi (vd: "Name", "Age")
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // ========== PROPERTIES VỚI NOTIFICATION ==========

    // Mỗi property cần 3 phần:
    // 1. Private field (_name) - lưu giá trị thực tế
    // 2. Public property (Name) - getter/setter có logic thông báo
    // 3. OnPropertyChanged() - thông báo UI cập nhật

    private string _name = string.Empty;
    public string Name
    {
        get { return _name; }  // Trả về giá trị từ private field
        set
        {
            if (_name != value)  // Chỉ thông báo khi giá trị THỰC SỰ thay đổi (tránh loop vô hạn)
            {
                _name = value;                    // Gán giá trị mới
                OnPropertyChanged(nameof(Name));  // Thông báo UI: "Name đã thay đổi!"
                // nameof(Name) trả về string "Name" - an toàn hơn viết "Name" trực tiếp
                // vì compiler sẽ kiểm tra lúc biên dịch
            }
        }
    }

    private int _age;
    public int Age
    {
        get { return _age; }
        set
        {
            if (_age != value)
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }
    }

    private string _class = string.Empty;
    public string Class
    {
        get { return _class; }
        set
        {
            if (_class != value)
            {
                _class = value;
                OnPropertyChanged(nameof(Class));
            }
        }
    }

    private double _gpa;
    public double GPA
    {
        get { return _gpa; }
        set
        {
            if (Math.Abs(_gpa - value) > 0.001)  // So sánh double dùng epsilon
            {
                _gpa = value;
                OnPropertyChanged(nameof(GPA));
            }
        }
    }

    private string _email = string.Empty;
    public string Email
    {
        get { return _email; }
        set
        {
            if (_email != value)
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
    }
}
