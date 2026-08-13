using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BTVN_ThucHanhOOP_CoBan
{
    internal class Person
    {
        //Trường
        private string _id;
        private string _name;
        private int _age;

        //Thuoc tinh
        public string Id
        {
            get { return _id; }
            set { _id = value; }

        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set 
            {
                if (value < 18) _age = 18;
                else _age = value; 
            }
        }

        // Contructor
        public Person() { }
        public Person(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

    }
}
