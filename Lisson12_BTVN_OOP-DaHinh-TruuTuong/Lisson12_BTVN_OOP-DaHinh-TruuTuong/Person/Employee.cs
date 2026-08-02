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
        private string _departmen;
        //private string department;

        public Employee() { }
        public Employee(string id, int age, string name, double salary, string departmen)
            : base (id, age, name)
        {
            _salary = salary;
            _departmen = departmen;
        }

        //protected Employee(string id, string name, int age, double salary, string department)
        //{
        //    Id = id;
        //    Name = name;
        //    Age = age;
        //    Salary = salary;
        //    this.department = department;
        //}

        public double Salary
        {
            get => _salary;
            set => _salary = value;
        }
            
        public string Departmen { get => _departmen; set => _departmen = value; }

        public abstract void Work();

        public virtual void ShowInfo()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Salary: " + Salary);
            Console.WriteLine("Department: " + Departmen);
            
        }
    }
}
