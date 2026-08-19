using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_OOP_P2
{
    internal class Teacher : Person
    {
        public override void StartProcess()
        {
            base.StartProcess();
            Console.WriteLine("Khởi động quy trình riêng bên Teacher");
        }
    }
}
