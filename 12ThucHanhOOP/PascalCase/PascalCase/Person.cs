using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalCase
{
    internal class Person
    {
        private int _id;
        private string _name;
        private int _age;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value < 18 ? 18 : value;}


    }
}
