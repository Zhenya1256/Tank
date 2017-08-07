using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankView.Abstract
{
    interface IMyEvent
    {
        event Action<string[][], string[], string , string , int , int> Click_left;
        event Action<string[][], string[], string, string, int, int> Click_right;
        event Action<string[][], string[], string, string, int, int> Click_down;
        event Action<string[][], string[], string, string, int, int> Click_up;
    }
}
