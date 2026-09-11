namespace WPF_Styles_Templates.Models;

/// <summary>
/// Model san pham - dung cho demo DataTemplate card san pham
/// </summary>
public class Product
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public double Rating { get; set; }
    public int Stock { get; set; }
}
