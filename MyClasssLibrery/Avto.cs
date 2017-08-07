using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasssLibrery
{
    public class Avto : IAvtoAndCar
    {
        public void Print()
        {
            Console.WriteLine("Avto Print");
        }
        [RoleInfo]
        public void Speed()
        {
           // Console.WriteLine("Avto Print");
           throw new NotImplementedException();
        }
    }
}
