using System.Windows;

namespace WPF_Data_Binding.Views;

/// <summary>
/// Demo 1: ElementName Binding
///
/// ElementName Binding cho phep bind gia tri giua cac control TRONG CUNG 1 WINDOW.
/// Khong can code-behind, moi thu deu lam trong XAML.
///
/// Cach hoat dong:
/// - Control nguon (Source): control cung cap gia tri (vd: Slider)
/// - Control dich (Target): control nhan gia tri (vd: TextBlock)
/// - ElementName: ten cua control nguon (x:Name)
/// - Path: thuoc tinh cua control nguon muon lay
///
/// Cu phap: {Binding ElementName=TenControl, Path=ThuocTinh}
/// </summary>
public partial class Demo1_ElementNameBinding : Window
{
    public Demo1_ElementNameBinding()
    {
        InitializeComponent();

        // Luu y: Demo nay KHONG CAN code-behind
        // Tat ca logic deu nam trong XAML voi ElementName Binding
        // Day la uu diem cua Data Binding: giam code C#
    }
}
