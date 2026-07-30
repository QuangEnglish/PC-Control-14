using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_OOP_P2
{
    public class Person
    {
        protected string CCCD {  get; set; }

        public Person() { }

        public Person(string cCCD)
        {
            CCCD = cCCD;
        }

        protected void Introduce()
        {
            Console.WriteLine($"Xin chào, CCCD là: {CCCD}");
        }
    }
}
