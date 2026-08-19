using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_OOP_P2.AbstractClass
{
    internal class PCCourse : Course
    {
        public override void BaoVeDoAnDauRa()
        {
        }

        public override void Teach()
        {
            Console.WriteLine("Dạy C#");
            Console.WriteLine("Dạy WinForms");
            Console.WriteLine("Dạy Camera Vision");
            Console.WriteLine("Điều khiển IO");
        }
    }
}
