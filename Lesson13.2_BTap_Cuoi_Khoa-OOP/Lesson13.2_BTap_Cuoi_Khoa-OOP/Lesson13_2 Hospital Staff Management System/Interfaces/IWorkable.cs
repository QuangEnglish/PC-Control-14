namespace Lesson13_2_Hospital_Staff_Management_System;

public interface IWorkable
// Interface này định nghĩa các hành động làm việc mà nhân viên có thể thực hiện.
{
     // Các Implenment IControllable
     
     bool CheckIn();    // - Nhân viên vào ca, trả về `bool`
     bool CheckOut();   // - Nhân viên ra ca, trả về `bool`
     void TakeLeave();  // - Xin nghỉ phép, trả về `void`
}