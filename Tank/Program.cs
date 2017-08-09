using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using TankView.Implements;
using TankModel;
using TankView.Abstract;
using TankModel.Implements.Tanks;
using TankModel.Implements;

namespace Tank
{
    class Program
    {
     
        static void Main(string[] args)
        {
            Present pr = new Present();
            Console.ReadKey();
        }
    
    }
    
}
