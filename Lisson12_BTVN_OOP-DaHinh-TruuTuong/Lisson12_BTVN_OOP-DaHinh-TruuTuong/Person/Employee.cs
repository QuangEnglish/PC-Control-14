using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lisson12_BTVN_OOP_DaHinh_TruuTuong
{
    abstract class Employee : Person
    {
        private double _salary;
        private string _department;
        //private string department;
        
        public double Salary
        {
            get => _salary;
            set => _salary = value;
        }
            
        public string Department { get => _department; set => _department = value; }

        public Employee() { }
        public Employee(string id, int age, string name, double salary, string department)
            : base (id, age, name)
        {
            Salary = salary;
            Department = department;
        }

        //protected Employee(string id, string name, int age, double salary, string department)
        //{
        //    Id = id;
        //    Name = name;
        //    Age = age;
        //    Salary = salary;
        //    this.department = department;
        //}

     

        public abstract void Work();

        public virtual void ShowInfo()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Salary: " + Salary);
            Console.WriteLine("Department: " + Department);
            
        }
    }
}
