using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenDuykhanh_proj61
{
    internal class Person
    {
        protected int _id;
        protected string _name;
        protected string _address;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }

        public Person()
        {
            _id = 0;
            _name = "";
            _address = "";
        }

        public Person(int id, string name)
        {
            _id = id;
            _name = name;
            _address = "";
        }
        public void Input()
        {

        }

        public void Output()
        {

        }
    }
}
