using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanlBl.Abstract
{
    interface ITank
    {
       bool TankMove(int keyinfo);
       void ShootRigth(string tank, int x, int y);
       void ShootUp(string tank, int x, int y);
       void ShootLeft(string tank, int x, int y);
       void ShootDown(string tank, int x, int y);
    }
}
