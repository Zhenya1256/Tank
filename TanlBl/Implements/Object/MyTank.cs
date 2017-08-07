using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TanlBl.Abstract;

namespace TanlBl
{
    public class MyTank :ITank
    {
        
       
        private string _tankUp = "W";
        private string _tankDown = "М";
        private string _tankLeft = "3";
        private string _tankRihgt = "Е";
        private string _shootGor = "|";
        private string _shootVer = "-";
        private string[][] _frameOfPlay;
        private Frame _frame;
        private int _hight = 0;
        private int _width = 0;
        private string _emtyCell = " ";

        public MyTank(Frame frame)
        {
            this._frame = frame;
            frame.AddElement(30, 23, _tankUp);
            _frameOfPlay = frame.GetFram();
            _hight = frame.Hight();
            _width = frame.Wihgt();

        }

        public MyTank(Frame frame,int x,int y)
        {
            this._frame = frame;
            frame.AddElement(x, y, _tankUp);
            _frameOfPlay = frame.GetFram();
            _hight = frame.Hight();
            _width = frame.Wihgt();

        }

        public bool TankMove(int keyinfo)
        {
                for (int i = 1; i < _width - 1; i++)
                {
                    for (int j = 1; j < _hight - 1; j++)
                    {
                        if (_frameOfPlay[i][j] == _tankUp || _frameOfPlay[i][j] == _tankLeft || _frameOfPlay[i][j] == _tankRihgt || _frameOfPlay[i][j] == _tankDown)
                        {
                            if (keyinfo == (int)ConsoleKey.UpArrow)
                            {
                                if ((i - 1) >= 0 && _frameOfPlay[i - 1][j] == _emtyCell)
                                {
                                    _frameOfPlay[i][j] = _emtyCell;
                                    _frameOfPlay[i - 1][j] = _tankUp;
                                    return true;
                                  
                                }
                            }
                            if (keyinfo == (int)ConsoleKey.DownArrow)
                            {
                                if ((i + 1) <= _frameOfPlay.Length - 1 && _frameOfPlay[i + 1][j] == _emtyCell)
                                {
                                    _frameOfPlay[i][j] = _emtyCell;
                                    _frameOfPlay[i + 1][j] = _tankDown;
                                   
                                      return true;
                                  }
                            }
                            if (keyinfo == (int)ConsoleKey.RightArrow)
                            {
                                if (_frameOfPlay[i][j + 1] == _emtyCell)
                                {
                                   
                                    _frameOfPlay[i][j] = _emtyCell;
                                    _frameOfPlay[i][j + 1] = _tankRihgt;
                                    return true;
                                 }
                            }
                            if (keyinfo == (int)ConsoleKey.LeftArrow)
                            {
                                if ((j + 1) >= 0 && _frameOfPlay[i][j - 1] == _emtyCell)
                                {
                                    _frameOfPlay[i][j] = _emtyCell;
                                    _frameOfPlay[i][j - 1] = _tankLeft;
                                      return true;

                                 }
                            }
                    }

                }

             
            }
            return false;

        }

        public void Shoot()
        {
          
            string tank="W";
            int x = 0;
            int y = 0;

            for (int i = 1; i < _width - 1; i++)
            {
                for (int j = 1; j < _hight - 1; j++)
                {
                    if (_frameOfPlay[i][j] == _tankUp || _frameOfPlay[i][j] == _tankLeft || _frameOfPlay[i][j] == _tankRihgt|| _frameOfPlay[i][j] == _tankDown)
                    {
                        tank = _frameOfPlay[i][j];
                        x = i;
                        y = j;
                    }  
                }
            }

            if (tank.Equals(_tankDown))
            {
                ShootDown(tank, x, y);
            }
            if (tank.Equals(_tankUp))
            {
                ShootUp(tank, x, y);
            }
            if (tank.Equals(_tankRihgt))
            {
               ShootRigth(tank, x, y);
            }
            if (tank.Equals(_tankLeft))
            {
                ShootLeft(tank, x, y);
            }

        }

        public void ShootUp(string tank, int x, int y)
        {

            int i = 1;

            while (true)
            {
                if (_frameOfPlay[x - i][y] != _emtyCell)
                {
                    if ((x - i) > 0)
                    {
                        _frameOfPlay[x - i][y] = _emtyCell;
                    }
                    if (_frameOfPlay[x - i + 1][y] != _tankUp)
                    {
                        _frameOfPlay[x - i + 1][y] = _emtyCell;
                    }
                    //frame.Render();
                    break;
                }
                Thread.Sleep(100);
                _frameOfPlay[x - i][y] = _shootGor;

                if (tank != _frameOfPlay[x - i + 1][y])
                {

                    _frameOfPlay[x - i + 1][y] = _emtyCell;
                }

                i++;
                //frame.Render();
            }


        }

        public void ShootDown(string tank, int x, int y)
        {

            int i = 1;
            //  _frame[x + i][y] = _shootGor;

            while (true)
            {
                if (_frameOfPlay[x + i][y] != _emtyCell)
                {
                    if ((x + i) < 24)
                    {
                        _frameOfPlay[x + i][y] = _emtyCell;
                    }
                    if (_frameOfPlay[x + i - 1][y] != _tankDown)
                    {
                        _frameOfPlay[x + i - 1][y] = _emtyCell;
                    }
                    // frame.Render();
                    break;
                }
                Thread.Sleep(100);
                _frameOfPlay[x + i][y] = _shootGor;

                if (tank != _frameOfPlay[x + i - 1][y])
                {
                    _frameOfPlay[x + i - 1][y] = _emtyCell;
                }

                i++;
                //      frame.Render();
            }



        }

        public void ShootLeft(string tank, int x, int y)
        {

            int i = 1;
            //_frame[x][y-i] = _shootVer;

            while (true)
            {
                if (_frameOfPlay[x][y - i] != _emtyCell)
                {
                    if ((y - i) > 0)
                    {
                        _frameOfPlay[x][y - i] = _emtyCell;
                    }
                    if (_frameOfPlay[x][y - i + 1] != _tankLeft)
                    {
                        _frameOfPlay[x][y - i + 1] = _emtyCell;
                    }
                    // frame.Render();
                    break;
                }
                Thread.Sleep(100);
                _frameOfPlay[x][y - i] = _shootVer;

                if (tank != _frameOfPlay[x][y - i + 1])
                {

                    _frameOfPlay[x][y - i + 1] = _emtyCell;
                }

                i++;
                // frame.Render();
            }




        }

        public void ShootRigth(string tank, int x, int y)
        {

            int i = 1;

            while (true)
            {
                if (_frameOfPlay[x][y + i] != _emtyCell)
                {
                    if ((y + i) < 74)
                    {
                        _frameOfPlay[x][y + i] = _emtyCell;
                    }
                    if (_frameOfPlay[x][y + i - 1] != _tankRihgt)
                    {
                        _frameOfPlay[x][y + i - 1] = _emtyCell;
                    }
                    // frame.Render();
                    break;
                }
                Thread.Sleep(100);
                _frameOfPlay[x][y + i] = _shootVer;

                if (tank != _frameOfPlay[x][y + i - 1])
                {

                    _frameOfPlay[x][y + i - 1] = _emtyCell;
                }

                i++;
                // frame.Render();
            }




        }

    }
}
