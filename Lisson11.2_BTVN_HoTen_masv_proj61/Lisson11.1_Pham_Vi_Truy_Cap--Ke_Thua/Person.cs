using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lisson11._1_Pham_Vi_Truy_Cap__Ke_Thua
{
    internal class Person
    {
        //Filed
        private int _id;
        private string _name;
        private string _address;

        //Contructor
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        // Constructor 0 tham số
        public Person()
        {
        }

        // Constructor 2 tham số
        public Person(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public virtual void Input()
        {
            Console.Write("Nhap ID: ");
            Id = int.Parse(Console.ReadLine());

            Console.Write("Nhap ten: ");
            Name = Console.ReadLine();

            Console.Write("Nhap dia chi: ");
            Address = Console.ReadLine();
        }

        public virtual void Output()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Ten: {Name}");
            Console.WriteLine($"Dia chi: {Address}");
        }

    }
}
