using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankView.Implements
{
  static class Sprits
    {
        public static string tankUp = "W";
        public static string tankDown = "М";
        public static string tankLeft = "3";
        public static string tankRihgt = "Е";
        public static string shootGor = "|";
        public static string shootVer = "-";
        public static string emptyCell = " ";


        public static string [] GetSpritsTank()
        {
            List<string> tank = new List<string>();
            tank.Add(tankUp);
            tank.Add(tankDown);
            tank.Add(tankLeft);
            tank.Add(tankRihgt);
            return tank.ToArray();

        }


    }
}
