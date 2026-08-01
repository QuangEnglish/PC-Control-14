using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalCase
{
    internal class Tester: Employee
    {
        public override void Work()
        {
            Console.WriteLine("Tester dang kiem thu he thong");
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
