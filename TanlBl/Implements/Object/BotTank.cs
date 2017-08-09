using System;
using System.Threading;
using TanlBl.Abstract;

namespace TanlBl
{
    class BotTank 
    {
        private string _tankUp = "O";
        private string _element = "#";
        private string _shootGor = "|";
        private string _shootVer = "-";
        private string[][] _frame;
        private IFrame frame;
        private int _hight = 0;
        private int _width = 0;
        private string _emtyCell = " ";
        private Random _random = new Random();
        private int _x;
        private int _y;
        private Mutex mutex = new Mutex();

       
        public BotTank(IFrame frame, int x, int y,string name)
        {
            this.frame = frame;
            this._tankUp = name;
            frame.AddElement(x, y, _tankUp);
            _frame = frame.GetFram();
            _hight = frame.Hight();
            _width = frame.Wihgt();
            this._x = y;
            this._y = x;     
           

        }

        object locker1 = new object();

        public object InvokeThread { get; private set; }

        public void LiveOfPlayVersion1()
        {           
                MoveToHor();
                MoveVer();       
        }

        public void LiveOfPlayVersion2()
        {           
                MoveVer();
                MoveToHor();            
        }

        private void MoveToHor()
        {
           
                mutex.WaitOne();
                int key = 39;

                while (_y != 36)
                {
                    if (true)
                    {
                        if (_y < 36)
                        {
                            key = 39;
                            RandomShoot(0, _random.Next(8, 12), ref key);
                            Thread.Sleep(800);
                            if (TankMove(key))
                            {
                                _y++;
                            }
                            RandomShoot(0, _random.Next(8, 12), ref key);
                        }
                        if (_y > 36)
                        {
                            key = 37;
                            RandomShoot(0, -_random.Next(8, 12), ref key);
                            Thread.Sleep(800);
                            if (TankMove(key))
                            {
                                _y--;
                            }
                            RandomShoot(0, _random.Next(4, 8), ref key);

                        }
                    }

                }
                mutex.ReleaseMutex();
            
            

        } 

        private void MoveVer( )
        {
            mutex.WaitOne();
                int key = 39;
                bool b = false;
                while (_x != 23)
                {

                    AllThread.Click += (cl) => b = cl;
                    if (!b)
                    {
                        if (_x <= 24)
                        {
                            key = 40;
                            RandomShoot(_random.Next(8, 12), 0, ref key);
                            Thread.Sleep(1200);
                            if (TankMove(key))
                            {
                                _x++;
                            }
                        }

                    }
                    AllThread.Click -= (cl) => cl = b;

                }
            mutex.ReleaseMutex();
            

        }
     
        public void RandomShoot(int xAway,int yAway,ref int key)
        {
            mutex.WaitOne();
                if (_y + yAway < 75 && _x + xAway < 25 && _x + xAway > 1 && _y + yAway > 1)
                {
                    if (_frame[_x + xAway][_y + yAway] != _emtyCell)
                    {
                        if (key == 38 || key == 40)
                            ShootDown(_tankUp, _x, _y);
                        if (key == 37)
                        {
                            ShootLeft(_tankUp, _x, _y);
                        }
                        if (key == 39)
                        {
                            ShootRigth(_tankUp, _x, _y);
                        }
                        return;
                    }
                    else if (yAway != 2 && yAway > 0)
                    {
                        yAway = 2;
                        RandomShoot(xAway, yAway, ref key);
                    }
                    else if (xAway != 2 && xAway != 0)
                    {
                        xAway = 2;
                        RandomShoot(xAway, yAway, ref key);
                    }
                    else if (yAway != -2 && yAway < 0)
                    {
                        yAway = -2;
                        RandomShoot(xAway, yAway, ref key);
                    }
                }

            mutex.ReleaseMutex();

        }

        public  bool TankMove(int keyinfo )
        {
                mutex.WaitOne();
            for (int i = 1; i < _width - 1; i++)
            {
                for (int j = 1; j < _hight - 1; j++)
                {
                    if (_frame[i][j] == _tankUp)
                    {
                        if (keyinfo == (int)ConsoleKey.UpArrow)
                        {
                            if ((i - 1) >= 0 && _frame[i - 1][j] == _emtyCell)
                            {
                                _frame[i][j] = _emtyCell;
                                _frame[i - 1][j] = _tankUp;
                                return true;
                            }
                        }
                        if (keyinfo == (int)ConsoleKey.DownArrow)
                        {
                            if ((i + 1) <= _frame.Length - 1 && _frame[i + 1][j] == _emtyCell)
                            {
                                _frame[i + 1][j] = _tankUp;
                                _frame[i][j] = _emtyCell;

                                return true;
                            }
                        }
                        if (keyinfo == (int)ConsoleKey.RightArrow)
                        {
                            if (_frame[i][j + 1] == _emtyCell)
                            {
                                _frame[i][j + 1] = _tankUp;
                                _frame[i][j] = _emtyCell;

                                return true;
                            }
                        }
                        if (keyinfo == (int)ConsoleKey.LeftArrow)
                        {
                            if ((j + 1) >= 0 && _frame[i][j - 1] == _emtyCell)
                            {
                                _frame[i][j] = _emtyCell;
                                _frame[i][j - 1] = _tankUp;
                                return true;
                            }
                        }

                    }

                }

            }
                mutex.ReleaseMutex();
                return false;
            

        }

        private void ShootDown(string tank, int x, int y)
        {
            
                int i = 1;
                //  _frame[x + i][y] = _shootGor;

                while (true)
                {
                    if (_frame[x + i][y] !=_emtyCell )
                    {
                        if ((x + i) < 24)
                        {
                            _frame[x + i][y] = _emtyCell;
                        }
                        if (_frame[x + i - 1][y] != _tankUp)
                        {
                            _frame[x + i - 1][y] = _emtyCell;
                        }
                        // frame.Render();
                        break;
                    }
                    Thread.Sleep(100);
                    _frame[x + i][y] = _shootGor;

                    if (tank != _frame[x + i - 1][y])
                    {

                        _frame[x + i - 1][y] = _emtyCell;
                    }

                    i++;
                    //      frame.Render();
                }

            

        }

        private void ShootLeft(string tank, int x, int y)
        {
           
                int i = 1;
                //_frame[x][y-i] = _shootVer;

                while (true)
                {
                    if (_frame[x][y-i] != _emtyCell)
                    {
                        if ((y - i) > 0)
                        {
                            _frame[x][y - i] = _emtyCell;
                        }
                        if (_frame[x][y - i + 1] != _tankUp)
                        {
                            _frame[x][y - i + 1] = _emtyCell;
                        }
                        // frame.Render();
                        break;
                    }
                    Thread.Sleep(100);
                    _frame[x][y - i] = _shootVer;

                    if (tank != _frame[x][y - i + 1])
                    {

                        _frame[x][y - i + 1] = _emtyCell;
                    }

                    i++;
                    // frame.Render();
                }
            




        }

        private void ShootRigth(string tank, int x, int y)
        {
            
                int i = 1;
                //_frame[x][y-i] = _shootVer;

                while (true)
                {
                    if (_frame[x][y+i] !=_emtyCell )
                    {
                        if ((y + i) < 74)
                        {
                            _frame[x][y + i] = _emtyCell;
                        }
                        if (_frame[x][y + i - 1] != _tankUp)
                        {
                            _frame[x][y + i - 1] = _emtyCell;
                        }
                        // frame.Render();
                        break;
                    }
                    Thread.Sleep(100);
                    _frame[x][y + i] = _shootVer;

                    if (tank != _frame[x][y + i - 1])
                    {

                        _frame[x][y + i - 1] = _emtyCell;
                    }

                    i++;
                    // frame.Render();
                }


            

        }

        private void ShootUp(string tank, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
