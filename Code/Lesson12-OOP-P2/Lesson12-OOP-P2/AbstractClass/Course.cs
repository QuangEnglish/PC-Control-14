using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_OOP_P2.AbstractClass
{
    internal abstract class Course
    {

        public void OpenCourse()
        {
            Console.WriteLine("=== MỞ KHÓA HỌC ===");
            Console.WriteLine("Chuẩn bị tài liệu");
            Console.WriteLine("Tạo nhóm Zalo");
            Console.WriteLine("Cấp tài khoản học");
        }

        public abstract void Teach();

        public abstract void BaoVeDoAnDauRa();

        public void FinalExam()
        {
            Console.WriteLine("Tổ chức bài kiểm tra cuối khóa");
        }

    }
}
