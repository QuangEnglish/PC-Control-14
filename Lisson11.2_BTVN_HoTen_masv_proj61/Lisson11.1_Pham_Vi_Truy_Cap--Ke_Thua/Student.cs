using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lisson11._1_Pham_Vi_Truy_Cap__Ke_Thua
{
    internal class Student : Person
    {
        public byte Maths { get; set; }
        public byte Physics { get; set; }

        // Constructor 0 tham số
        public Student()
        {
        }

        // Constructor 4 tham số
        public Student(string name, string address, byte maths, byte physics)
            : base(name, address)
        {
            Maths = maths;
            Physics = physics;
        }

        public override void Input()
        {
            base.Input();

            Console.Write("Nhap diem Toan: ");
            Maths = byte.Parse(Console.ReadLine());

            Console.Write("Nhap diem Ly: ");
            Physics = byte.Parse(Console.ReadLine());
        }

        public override void Output()
        {
            base.Output();
            Console.WriteLine($"Toan: {Maths}");
            Console.WriteLine($"Ly: {Physics}");
            Console.WriteLine($"Tong diem: {Total()}");
            Console.WriteLine("----------------------------");
        }

        public int Total()
        {
            return Maths + Physics;
        }
    }
}
