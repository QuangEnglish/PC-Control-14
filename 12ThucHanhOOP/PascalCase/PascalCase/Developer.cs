using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalCase
{
    internal class Developer:Employee
    {
        public override void Work()
        {
            Console.WriteLine("Developer dang lap trinh he thong");
        }
        public override void ShowInfor()
        {
            Console.WriteLine(
                $"Id: {Id}," +
                $" Name: {Name}," +
                $" Age: {Age}," +
                $" Salary: {Salary}," +
                $" Department: {Department}");
        }
    }
}
