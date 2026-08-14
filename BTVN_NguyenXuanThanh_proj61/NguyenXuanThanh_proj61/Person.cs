using System;
using System.Collections.Generic;
using System.Text;

namespace NguyenXuanThanh_proj61
{
    internal class Person
    {
        //Trường
        private int _id;
        private string _name;
        private string _address;

        //Thuoc tinh
        public int Id 
        { 
            get { return _id; }
            set { _id = value; }
                
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Address
        {
            get{ return _address; }
            set { _address = value; }
        }
        // Contructor
        public Person() { }
        public Person(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        // Hanh vi (ham: method)
        public void Output()
        {
            Console.WriteLine($"Id la: {Id}");
            Console.WriteLine($"Ten la: {Name}");
            Console.WriteLine($"Dia chi: {Address}");
        }
    }
}
