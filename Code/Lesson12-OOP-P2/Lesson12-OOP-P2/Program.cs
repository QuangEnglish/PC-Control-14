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



            Student student = new Student();
            student.Id = 1;
            //student.CCCD = "2432432432";
            student.DisplayV2();
            student.DisplayInfo();

            Student hieuVan = new Student(2, "Hiệu Văn", 25, 7.8, "054353455");
            //hieuVan.Introduce();

            Person person = new Person();
            //person.CCCD = "75435543543";
            //person.Introduce();


        }
    }
}
