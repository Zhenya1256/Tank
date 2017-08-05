using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanlBl.Abstract
{
    interface IFrame
    {
        void Visible();
        void AddElement(int x, int y, string element);
        void AddElement(int y1, int x1, int y2, int x2, string element);
        void AddElementCenter(int x, string element);
        void DeleteLand(int x, int element);
        void AddLand(int x, int element);
        int GetElement(int x);
        int Hight();
        string[][] GetFram();
        int Wihgt();
        void Render();
    }
}
