namespace WPF_Styles_Templates.Models;

/// <summary>
/// Model danh ba dien thoai - dung cho demo DataTemplate
/// </summary>
public class Contact
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Computed property: lay chu cai dau cua ten lam avatar
    public string Initial => Name?.Length > 0 ? Name.Substring(0, 1).ToUpper() : "?";
}
