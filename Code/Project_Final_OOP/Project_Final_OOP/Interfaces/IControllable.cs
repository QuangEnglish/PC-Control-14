namespace Project_Final_OOP.Interfaces;

// Interface IControllable - Định nghĩa các hành động điều khiển thiết bị
// Interface giống như một "hợp đồng": bất kỳ class nào implement nó
// đều PHẢI cài đặt đầy đủ các method bên trong
public interface IControllable
{
    // Khởi động thiết bị - trả về true nếu thành công
    bool Start();

    // Dừng thiết bị - trả về true nếu thành công
    bool Stop();

    // Reset thiết bị - không trả về giá trị
    void Reset();
}
