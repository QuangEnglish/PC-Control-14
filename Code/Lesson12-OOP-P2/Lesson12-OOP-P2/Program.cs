using Lesson12_OOP_P2.AbstractClass;

namespace Lesson12_OOP_P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Phạm vi truy cập 
            // public: ở đâu cũng truy cập được
            // private: chỉ bên trong class mới được truy cập
            // protected: là cầu nối giữa cha và con, lớp cha và tất cả lớp con đều truy cập được,
            // bên ngoài nếu (ko phải lớp con) thì không truy cập được

            // internal: phạm vi truy cập trong 1 assembly

            // protected internal
            // private protected 


            // assembly: 

            // 4 tính chất OOP
            // I. Tính đóng gói (Encapsulation)
            // II. Tính kế thừa 
            // III. Tính đa hình (buổi sau)
            // IV. Tính trừu tượng / Interface (buổi sau)
            // Static


            // II v2: Tính kế thừa nâng cao
            // 2 từ khóa virtual và override

            // III. Tính đa hình
            // overriding và overloading 

            // overriding: ghi đè
            // xảy ra giữa lớp cha và lớp con
            // phương thức, hành vi ghi đè là phải cùng tên, cùng tham số(cùng kiểu dư liệu tham số),
            // cùng kiểu trả về
            // quyết định lúc runtime (dựa vào đối tượng thật)

            // overloading: 
            // hàm, hành vi trong cùng 1 class (hoặc kế thừa)
            // cùng tên, nhưng khác tham số (số lượng hoặc kiểu tham số)
            // quyết định trong lúc compile time

            // sealed : không cho phép kế thừa nữa

            // IV: Tính trừu tượng
            // 2 từ khóa abstract và interface
            // abstract class, abstract method : ý nghĩa là ẩn chi tiết cài đặt,
                                                // chỉ cung cấp những gì cần thiết
            //




            Student student = new Student();
            student.Id = 1;
            //student.CCCD = "2432432432";
            //student.DisplayV2();
            //student.DisplayInfo();
            //student.DisplayV3();
            //student.DisplayV3(4, 5);
            //student.DisplayV3(4, 5.6);
            //student.Stop();

            Baby baby = new Baby();
            //baby.Stop();

            Person person = new Student();
            // Person: là kiểu tham chiếu
            // person: tên biến chỉ rằng nó là 1 Person
            // new Student(): giống như việc người này thực ra là sinh viên
            //person.StartProcess();


            Person personV2 = new Teacher();
            //personV2.StartProcess();



            //Student hieuVan = new Student(2, "Hiệu Văn", 25, 7.8, "054353455");
            //hieuVan.Introduce();

            //Person person = new Person();
            //person.CCCD = "75435543543";
            //person.Introduce();


            // Demo lớp trừu tượng
            Course course = new PCCourse();
            course.OpenCourse();
            course.Teach();
            course.FinalExam();

            Course courseVision = new VisionCourse();
            courseVision.OpenCourse();
            courseVision.Teach();
            courseVision.FinalExam();



        }
    }
}
