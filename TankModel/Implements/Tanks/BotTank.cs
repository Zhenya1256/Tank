using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TankModel.Implements.Tanks
{
    public class BotTank
    {
        MyMutex _mutex = new MyMutex();
        Random _random = new Random();
        public static event Func<bool> stop;
        int _x;
        int _y;
        string[][] _frame;
        string _tankUp;
        string _emtyCell;
        int _width;
        int _hight;
     


        public BotTank(int x, int y, string[][] frame, string emtyCell, string sprite, int width, int hight)
        {
            _x = x;
            _y = y;
            _frame = frame;
            _emtyCell = emtyCell;
            _width = width;
            _hight = hight;
            _tankUp = sprite;
            frame[x][y] = sprite;
        }

        public void MoveToHorNextVer()
        {
            MoveToHor();
            MoveVer();
        }

        public void MoveVerNextHor()
        {
            MoveVer();
            MoveToHor();
        }

        private void MoveToHor()
        {

            _mutex.WaitOne();
            int key = 39;
            bool b = false;
            while (_y != 36)
            {
                if (stop != null)
                {
                    b = stop();
                }
                if (!b)
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
            _mutex.Release();



        }

        private void MoveVer()
        {
            _mutex.WaitOne();
            int key = 39;
            bool b = false;
            while (_x != 23)
            {
                if (stop != null)
                {
                    b = stop();
                }
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


            }
            _mutex.Release();


        }

        public void RandomShoot(int xAway, int yAway, ref int key)
        {
            _mutex.WaitOne();
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

            _mutex.Release();

        }

        public bool TankMove(int keyinfo)
        {
            _mutex.WaitOne();
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
                                _mutex.Release();
                                return true;
                            }
                        }
                        if (keyinfo == (int)ConsoleKey.DownArrow)
                        {
                            if ((i + 1) <= _frame.Length - 1 && _frame[i + 1][j] == _emtyCell)
                            {
                                _frame[i + 1][j] = _tankUp;
                                _frame[i][j] = _emtyCell;
                                _mutex.Release();
                                return true;
                            }
                        }
                        if (keyinfo == (int)ConsoleKey.RightArrow)
                        {
                            if (_frame[i][j + 1] == _emtyCell)
                            {
                                _frame[i][j + 1] = _tankUp;
                                _frame[i][j] = _emtyCell;
                                _mutex.Release();
                                return true;
                            }
                        }
                        if (keyinfo == (int)ConsoleKey.LeftArrow)
                        {
                            if ((j + 1) >= 0 && _frame[i][j - 1] == _emtyCell)
                            {
                                _frame[i][j] = _emtyCell;
                                _frame[i][j - 1] = _tankUp;
                                _mutex.Release();
                                return true;
                            }
                        }

                    }

                }

            }
            _mutex.Release();
            return false;


        }

        private void ShootDown(string tank, int x, int y)
        {

            int i = 1;
            //  _frame[x + i][y] = _shootGor;

            while (true)
            {
                if (_frame[x + i][y] != _emtyCell)
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
                _frame[x + i][y] = "|";

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
                if (_frame[x][y - i] != _emtyCell)
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
                _frame[x][y - i] = "-";

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
                if (_frame[x][y + i] != _emtyCell)
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
                _frame[x][y + i] = "-";

                if (tank != _frame[x][y + i - 1])
                {

                    _frame[x][y + i - 1] = _emtyCell;
                }

                i++;
                // frame.Render();
            }




        }

    }
  

}
