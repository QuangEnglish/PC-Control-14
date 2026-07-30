using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_OOP_P2
{
    public class Student : Person
    {
        // 1. Fields (trường)
        private int _id;
        private string _name;
        private int _age;
        private double _gpa;

        // 2. Properties (thuộc tính)
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }
        public double Gpa { 
            get => _gpa;
            set
            {
                if (value >= 0 && value <= 4)
                    _gpa = value;
            }
        }

        // 3. Constructor mặc định
        public Student() : base()
        {
            _id = 0;
            _name = "Unknown";
            _age = 18;
            _gpa = 0;
        }


        // 4. Constructor có tham số
        public Student(int id, string name, int age, double gpa, string cCCD) : base(cCCD)
        {
            _id = id;
            _name = name;
            _age = age;
            _gpa = gpa;
        }

        // 5. Methods (Hành vi)
        public void Study(string subject)
        {
            Console.WriteLine($"{Name} đang học môn {subject}.");
        }

        public void TakeExam(string subject)
        {
            Console.WriteLine($"{Name} đang thi môn {subject}.");
        }

        public void IncreaseGPA(double score)
        {
            Gpa += score;

            if (Gpa > 4)
                Gpa = 4;
        }

        public string GetRank()
        {
            if (Gpa >= 3.6)
                return "Xuất sắc";

            if (Gpa >= 3.2)
                return "Giỏi";

            if (Gpa >= 2.5)
                return "Khá";

            if (Gpa >= 2.0)
                return "Trung bình";

            return "Yếu";
        }

        public void DisplayInfo()
        {
            Console.WriteLine("===== THÔNG TIN SINH VIÊN =====");
            Console.WriteLine($"ID      : {Id}");
            Console.WriteLine($"Tên     : {Name}");
            Console.WriteLine($"Tuổi    : {Age}");
            Console.WriteLine($"GPA     : {Gpa}");
            Console.WriteLine($"Xếp loại: {GetRank()}");
            Console.WriteLine($"Căn cước công dân: {CCCD}");
            Console.WriteLine();
        }

        public void DisplayV2()
        {
            Introduce();
        }
        





    }
}
