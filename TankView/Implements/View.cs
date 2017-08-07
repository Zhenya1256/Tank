using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TankView.Abstract;

namespace TankView.Implements
{
  public  class View : IMyEvent
    {
        private IDrow _draw;
        private string[][] _panel;
        private int _width;
        private int _hight;
       
        

        public event Action<string[][], string[], string, string, int, int> Click_left;
        public event Action<string[][], string[], string, string, int, int> Click_down;
        public event Action<string[][], string[], string, string, int, int> Click_up;
        public event Action<string[][], string[], string, string, int, int> Click_right;

        public View()
        {
            _draw = new Drow();
            Construction cons = new Construction(_draw);         
            _panel = _draw.GetFram();
            _width = _draw.Wihgt();
            _hight = _draw.Hight();

        }


        public void Click()
        {

            while (true)
            {
                Thread.Sleep(400);
                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.LeftArrow)
                {
                    if (Click_left != null)
                    {
                         Click_left(_panel, Sprits.GetSpritsTank(), Sprits.tankLeft, Sprits.emptyCell, _width, _hight);
                    }
                }
                if (info.Key == ConsoleKey.DownArrow)
                {
                    if (Click_down != null)
                    {
                        Click_down(_panel, Sprits.GetSpritsTank(), Sprits.tankDown, Sprits.emptyCell, _width, _hight);
                    }
                }
                if (info.Key == ConsoleKey.UpArrow)
                {
                    if (Click_up != null)
                    {
                        Click_up(_panel, Sprits.GetSpritsTank(), Sprits.tankUp, Sprits.emptyCell, _width, _hight);
                    }
                }
                if (info.Key == ConsoleKey.RightArrow)
                {
                    if (Click_right != null)
                    {
                        Click_right(_panel, Sprits.GetSpritsTank(), Sprits.tankRihgt, Sprits.emptyCell, _width, _hight);
                    }
                }
                _draw.Render();

            }


         }

    }
}
