namespace Lesson_13_BTVN_CuoiKhoa_OOP.Machine;

public interface IControllable 
    // Interface này định nghĩa các hành động điều khiển mà thiết bị có thể thực hiện.
{
    // Các Implenment IControllable
    bool Start();
    bool Stop();
    void Reset();
}