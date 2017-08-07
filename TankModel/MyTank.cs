using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TankModel
{
    public class MyTank
    {


        public void MoveToLeft(string[][] frameOfPlay,string [] spritesTank,string tankLeft,string emtyCell,int width,int hight)
        {
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < hight - 1; j++)
                {
                    for (int t = 0; t < spritesTank.Length; t++)
                    {
                        if (spritesTank[t] == frameOfPlay[i][j])
                        {
                            if ((j + 1) >= 0 && frameOfPlay[i][j - 1] == emtyCell)
                            {
                                frameOfPlay[i][j] = emtyCell;
                                frameOfPlay[i][j - 1] = tankLeft;

                            }
                        }
                    }   
                  }
             }    
        }

        public void MoveToUp(string[][] frameOfPlay, string[] spritesTank, string tankUp, string emtyCell, int width, int hight)
        {
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < hight - 1; j++)
                {
                    for (int t = 0; t < spritesTank.Length; t++)
                    {
                        if (spritesTank[t] == frameOfPlay[i][j])
                        {
                            if ((j + 1) >= 0 && frameOfPlay[i][j - 1] == emtyCell)
                            {
                                if ((i - 1) >= 0 && frameOfPlay[i - 1][j] == emtyCell)
                                {
                                    frameOfPlay[i][j] = emtyCell;
                                    frameOfPlay[i - 1][j] = tankUp;
                                }

                            }
                        }
                    }
                }
            }
        }

        public void MoveToDown(string[][] frameOfPlay, string[] spritesTank, string tankDown, string emtyCell, int width, int hight)
        {
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < hight - 1; j++)
                {
                    for (int t = 0; t < spritesTank.Length; t++)
                    {
                        if (spritesTank[t] == frameOfPlay[i][j])
                        {
                            if ((i + 1) <= frameOfPlay.Length - 1 && frameOfPlay[i + 1][j] == emtyCell)
                            {
                                frameOfPlay[i][j] = emtyCell;
                                frameOfPlay[i + 1][j] = tankDown;
                                return;

                            }
                        }
                    }
                }
            }
        }

        public void MoveToRight(string[][] frameOfPlay, string[] spritesTank, string tankRight, string emtyCell, int width, int hight)
        {
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < hight - 1; j++)
                {
                    for (int t = 0; t < spritesTank.Length; t++)
                    {
                        if (spritesTank[t] == frameOfPlay[i][j])
                        {
                            if (frameOfPlay[i][j + 1] == emtyCell)
                            {
                                
                                frameOfPlay[i][j] = emtyCell;
                                frameOfPlay[i][j + 1] = tankRight;
                                return;
                            }

                        }
                    }
                }
            }
        }

        public void Shoot(string[][] frameOfPlay, string tankUp, string tankLeft, string tankDown, string tankRight,string emptyCell, int width, int hight)
        {

            string tank = "W";
            int x = 0;
            int y = 0;

            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < hight - 1; j++)
                {
                   
                        if (frameOfPlay[i][j] == tankUp || frameOfPlay[i][j] == tankLeft || frameOfPlay[i][j] == tankRight || frameOfPlay[i][j] == tankDown)
                        {
                            tank = frameOfPlay[i][j];
                            x = i;
                            y = j;
                        }
                    
                    
                }
            }

            if (tank.Equals(tankDown))
            {
                ShootDown(tank, x, y);
            }
            if (tank.Equals(tankUp))
            {
                ShootUp(tank, x, y);
            }
            if (tank.Equals(tankRight))
            {
                ShootRigth(tank, x, y);
            }
            if (tank.Equals(tankLeft))
            {
                ShootLeft(tank, x, y);
            }

        }

        public void ShootUp((string[][] frameOfPlay,string tank, string emtyCell, int x, int y)
        {

            int i = 1;

            while (true)
            {
                if (frameOfPlay[x - i][y] != emtyCell)
                {
                    if ((x - i) > 0)
                    {
                        frameOfPlay[x - i][y] = emtyCell;
                    }
                    if (frameOfPlay[x - i + 1][y] != tank)
                    {
                        frameOfPlay[x - i + 1][y] = emtyCell;
                    }
                    //frame.Render();
                    break;
                }
                Thread.Sleep(100);
                frameOfPlay[x - i][y] = shootGor;

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
