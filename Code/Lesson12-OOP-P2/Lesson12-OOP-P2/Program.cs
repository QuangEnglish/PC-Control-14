using Lesson12_OOP_P2.AbstractClass;
using Lesson12_OOP_P2.Interface;

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


            // ========================================
            // V. INTERFACE
            // ========================================
            // Interface khác Abstract class:
            // - Abstract class: kế thừa 1 class duy nhất (single inheritance)
            // - Interface: 1 class có thể implement NHIỀU interface
            // - Abstract class: có thể có field, constructor, method có thân hàm
            // - Interface: chỉ có method/property khai báo (không có field, constructor)
            // - Abstract class: dùng khi các class có quan hệ "IS-A" (là một loại)
            // - Interface: dùng khi muốn ép 1 class có khả năng "CAN-DO" (có thể làm)

            Console.WriteLine("\n=== DEMO INTERFACE ===");

            // 1. Tạo đối tượng cụ thể
            Circle circle = new Circle(5.0, "Do");
            Rectangle rectangle = new Rectangle(4.0, 6.0, "Xanh");
            Triangle triangle = new Triangle(3.0, 4.0, 5.0, "Vang");

            circle.Draw();  // hành vi vẽ là của class Circle
            rectangle.Draw(); // hành vi vẽ là của class Rectangle
            
            ((IShape)circle).PrintInfo();     // default implementation phải gọi qua kiểu IShape
            
            ((IShape)rectangle).PrintInfo();

            triangle.Draw();
            ((IShape)triangle).PrintInfo();

            Console.WriteLine();

            // 2. Dùng interface làm kiểu tham chiếu (tính đa hình qua interface)
            // Giống như dùng lớp cha làm kiểu tham chiếu
            Console.WriteLine("--- Da hinh qua Interface ---");
            IShape[] shapes = { triangle };
            foreach (IShape shape in shapes)
            {
                shape.Draw();
                Console.WriteLine($"  Dien tich: {shape.CalculateArea():F2}");
            }

            Console.WriteLine();

            // 3. Kiểm tra interface với 'is' và 'as' alias
            Console.WriteLine("--- Kiem tra Interface ---");
            foreach (IShape shape in shapes)
            {
                if (shape is IResizable resizable)
                {
                    Console.Write($"{shape.GetType().Name} co the resize -> ");
                    resizable.Resize(2.0);
                }
                else
                {
                    Console.WriteLine($"{shape.GetType().Name} KHONG the resize");
                }
            }

            Console.WriteLine();

            // 4. Dùng IColorable
            Console.WriteLine("--- Doi mau qua IColorable ---");
            IColorable[] colorables = { circle, rectangle, triangle };
            foreach (IColorable item in colorables)
            {
                item.SetColor("Tim");
            }
            
            
            // Sự khác nhau giữa Interface và Abstract Class
            // Interface dùng linh hoạt hn, phù hợp với đa hình
            // Abstract Class phù hợp cho việc chia sẻ mã chung
            
            // Interface: khả năng
            // Abstract class: Bản chất 
            
            // 5 nguyên tắc thiết kế SOLID
            
            


        }
    }
}
