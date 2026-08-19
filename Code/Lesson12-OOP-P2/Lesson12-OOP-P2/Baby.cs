using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_OOP_P2
{
    internal class Baby : Student
    {
        public void Stop()
        {
            base.Stop();
            Console.WriteLine("Cháu muốn lấy");
        }
    }
}
