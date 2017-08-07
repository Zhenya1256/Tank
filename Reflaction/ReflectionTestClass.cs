using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reflaction
{
   // [RoleInfo]
    public class ReflectionTestClass 
    {
        private string _instanceName;

        public ReflectionTestClass(string instanceName)
        {
            _instanceName = instanceName;
        }


        void Print(string val)
        {
            Console.WriteLine(val);
        }

        void Print()
        {
            Console.WriteLine(_instanceName);
        }
    }
   

}
