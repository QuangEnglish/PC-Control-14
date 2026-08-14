namespace Project_OOP_BaiTap_T4.Interfaces;

// Interface định nghĩa các hành động làm việc mà nhân viên có thể thực hiện.
// Đây là tính ABSTRACTION (trừu tượng): chỉ khai báo "cái gì cần làm", không khai báo "làm như thế nào".
// Bất kỳ class nào implement interface này đều BẮT BUỘC phải viết code cho 3 method bên dưới.
public interface IWorkable
{
    bool CheckIn();     // Nhân viên vào ca -> trả về true nếu thành công
    bool CheckOut();    // Nhân viên ra ca -> trả về true nếu thành công
    void TakeLeave();   // Nhân viên xin nghỉ phép -> không trả về giá trị
}
