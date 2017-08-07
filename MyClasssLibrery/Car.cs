using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasssLibrery
{
   public class Car : IAvtoAndCar
    {
        public void Print()
        {
            //throw new NotImplementedException();
           Console.WriteLine("Avto Print");
        }
        [RoleInfo]
        public void Speed()
        {
            throw new NotImplementedException();
          //  Console.WriteLine("Avto Print");
        }
    }
    public class RoleInfo : Attribute
    {
        public string Name { get; set; }
        public RoleInfo() { }
        public RoleInfo(string name)
        {
            Name = name;
        }

    }
}task concelationsouce tking
