using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenDuykhanh_proj61
{
    internal class Student:Person
    {
        private byte _maths;
        private byte _physics;

        public byte Maths { get => _maths; set => _maths = value; }
        public byte Physics { get => _physics; set => _physics = value; }

        public Student()
        {
            _id = 0;
            _name = "";
            _address = "";
            _maths = 0;
            _physics = 0;
        }
        public Student(int id, string name, string address, byte maths, byte physics)
        {
            _id = id;
            _name = name;
            _address = address;
            _maths = maths;
            _physics = physics;
        }

        public void Input()
        {
            Console.WriteLine("Nhap sinh vien: ID -> Name -> Address -> Math -> Physic");
            _id = Convert.ToInt32(Console.ReadLine());
            _name = Console.ReadLine();
            _address = Console.ReadLine();
            _maths = Convert.ToByte(Console.ReadLine());
            _physics = Convert.ToByte(Console.ReadLine());

        }
        public void Output()
        {
            Console.WriteLine($"ID: {_id}");
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Address: {_address}");
            Console.WriteLine($"Math: {_maths}");
            Console.WriteLine($"Physic: {_physics}");
            
        }
        public byte Total()
        {
            return (byte)(_maths + _physics);

        }
    }
}
