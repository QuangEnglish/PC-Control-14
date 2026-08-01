using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalCase
{
    internal abstract class Employee: Person
    {
        private decimal _salary;
        private string _department;

        public decimal Salary { get => _salary; set => _salary = value; }
        public string Department { get => _department; set => _department = value; }

        public abstract void Work();
        public virtual void ShowInfor()
        {

        }
        public void Input()
        {
            Console.WriteLine("Nhap Id: "); Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap Name: "); Name = Console.ReadLine();
            Console.WriteLine("Nhap Age: "); Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap Salary: "); Salary = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Nhap Department: "); Department = Console.ReadLine();
        }
    }
}
