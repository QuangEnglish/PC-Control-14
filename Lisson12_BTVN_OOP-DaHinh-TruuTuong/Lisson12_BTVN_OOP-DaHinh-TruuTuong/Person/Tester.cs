using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lisson12_BTVN_OOP_DaHinh_TruuTuong
{
     class Tester : Employee
    {
        public Tester() { }

        public Tester(string id, int age, string name,
                      double salary, string department)
         : base(id, age, name, salary, department)
        {
        }
        public override void Work()
        {
            Console.WriteLine("Tester dang kiem thu pham mem");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Tester");
        }
    }
}
