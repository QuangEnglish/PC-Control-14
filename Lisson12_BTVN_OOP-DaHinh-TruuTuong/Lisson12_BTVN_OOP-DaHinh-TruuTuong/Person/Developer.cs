using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lisson12_BTVN_OOP_DaHinh_TruuTuong
{
    class Developer : Employee
    {
        public Developer() { }
        public Developer(string id,int age, string name,
                      double salary, string department)
         : base(id, age, name, salary, department)
        {
        }

        public override void Show()
        {
            Console.WriteLine("Test ." +Name);
        }

        public override void Work()
        {
            Console.WriteLine("Developer dang lap trinh he thong.");
        }

        public override void ShowInfo()
        {
           base.ShowInfo();
            Console.WriteLine("Developer");
        }
    }
}
