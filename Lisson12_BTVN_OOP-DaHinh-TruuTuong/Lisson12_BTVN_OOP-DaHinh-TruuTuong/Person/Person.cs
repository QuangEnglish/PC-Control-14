using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lisson12_BTVN_OOP_DaHinh_TruuTuong
{
    internal class Person
    {
        // Filed
        private string _id;
        private int _age;
        private string _name;


        // Contructor
        public Person() { }

        public Person(string id, int age, string name)
        {
            _id = id;
            _age = age;
            _name = name;
        }


        // Propertis
        public string Id
        {
            get { return _id; }
            set { _id = value; }

        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 18) { _age = 18; }
                else { _age = value; }
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name =value; }
        }

        public virtual void Show()
        {
            Console.WriteLine(Name);
        }
    }
}
