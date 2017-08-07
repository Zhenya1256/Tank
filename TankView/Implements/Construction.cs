using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankView.Abstract;

namespace TankView.Implements
{
    class Construction
    {
        IDrow _drow;
        private string _wall = "###############";

        public Construction(IDrow drow)
        {
           
            _drow = drow;
            _drow.Visible();
            _drow.AddElement(29, 23, Sprits.tankUp);
            ElementsOnFrame();
            _drow.Render();
        }

        private void ElementsOnFrame()
        {
            for (int i = 0; i < 19; i++)
            {
                _drow.AddElement(27 + i, 12, 27 + i, 15, _wall);
            }
            Basa();
            Cub();
            Colums();
            Flag();

        }

        private void Colums()
        {
            for (int i = 0; i < 8; i++)
            {
                _drow.AddElement(7, 15 + i, 11, 15 + i, _wall);
                _drow.AddElement(16, 15 + i, 20, 15 + i, _wall);
                //
                _drow.AddElement(55, 15 + i, 59, 15 + i, _wall);
                _drow.AddElement(65, 15 + i, 69, 15 + i, _wall);
                //
                _drow.AddElement(7, 3 + i, 11, 3 + i, _wall);
                _drow.AddElement(16, 3 + i, 20, 3 + i, _wall);
                //
                _drow.AddElement(55, 3 + i, 59, 3 + i, _wall);
                _drow.AddElement(65, 3 + i, 69, 3 + i, _wall);

            }

        }

        private void Cub()
        {
            for (int i = 0; i < 4; i++)
            {
                _drow.AddElement(27 + i, 15, 27 + i, 18, _wall);
                _drow.AddElement(45 - i, 15, 45 - i, 18, _wall);
                _drow.AddElement(27 + i, 7, 27 + i, 10, _wall);
                _drow.AddElement(45 - i, 7, 45 - i, 10, _wall);
            }

        }

        private void Basa()
        {
            _drow.AddElement(32, 21, 32, 24, _wall);
            _drow.AddElement(31, 21, 31, 24, _wall);

            _drow.AddElement(41, 21, 41, 24, _wall);
            _drow.AddElement(42, 21, 42, 24, _wall);

            _drow.AddElement(31, 21, 41, 21, _wall);
            _drow.AddElement(31, 20, 43, 20, _wall);
            //
            _drow.AddElement(30, 20, 30, 15, _wall);

        }

        private void Flag()
        {
            _drow.AddElement(36, 23, "$");
        }
    }
}
