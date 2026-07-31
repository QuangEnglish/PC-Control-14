using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_OOP_P2.AbstractClass
{
    internal class VisionCourse : Course
    {
        public override void BaoVeDoAnDauRa()
        {
            throw new NotImplementedException();
        }

        public override void Teach()
        {
            Console.WriteLine("Dạy OpenCV");
            Console.WriteLine("Dạy Cognex");
            Console.WriteLine("Dạy HALCON");
        }


    }
}
