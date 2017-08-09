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
        private string _gameOver;

        public bool Stop
        {
            get;
            set;
        }

        public event Action<string[][], string[], string, string, int, int> Click_left;
        public event Action<string[][], string[], string, string, int, int> Click_down;
        public event Action<string[][], string[], string, string, int, int> Click_up;
        public event Action<string[][], string[], string, string, int, int> Click_right;
        public event Action<string[][], string, string, string, string, string, int, int> Click_Shoot;
        public event Action< string[][], string, int, int> ScriptBot;
        public event Action PlayMusic;
        public event Action StopMusic;
        public event Func<string[][], string[], string, int, int, bool> GameOver;
        public event Action newPlay;
        public event Action<string> Post;
        public event Func<string[][], string[], string, string,string, int, int,bool> Win;
        public event Action MakeScreen;

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
            Stop = false;
            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey();
                if (!Stop)
                {
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

                    if (info.Key == ConsoleKey.Spacebar)
                    {

                        new Task(Shoot).Start();

                    }
                }

                if (info.Key == ConsoleKey.Escape)
                {
                    Stop = true;
                    PlayMusic();
                }
                if (info.Key == ConsoleKey.Enter)
                {
                    Stop = false;
                   StopMusic();
                }


            }


         }

        public void Shoot()
        {
            if (Click_Shoot != null)
            {
                Click_Shoot(_panel, Sprits.tankUp, Sprits.tankLeft, Sprits.tankDown, Sprits.tankRihgt, Sprits.emptyCell, _width, _hight);
            }
        }

        public void  StartBot()
        {
            if (ScriptBot != null)
            {
                
                ScriptBot( _panel, " ", _width, _hight);
               
            }
        }

        public void Render()
        {
            bool gameover = true;
            while (gameover)
            {
                if (!Stop)
                {
                  

                    if (!GameOver(_panel, Sprits.GetSpritsTank(),"$", _width, _hight))
                    {
                        Thread.Sleep(20);
                        _draw.Render();
                    }
                      else
                    {
                        if (MakeScreen != null)
                        {
                            MakeScreen();
                        }
                        _gameOver = "You lose in the play";
                        gameover = false;
                        PushFaceBook();

                    }
                    if (Win(_panel, Sprits.GetSpritsTank(), Sprits.emptyCell, "#","$", _width, _hight))
                    {
                        if (MakeScreen != null)
                        {
                            MakeScreen();
                        }
                        _gameOver = "You win in the play";
                        gameover = false;
                        PushFaceBook();
                    }

                }
            }
        }

        public void PushFaceBook()
        {
            Console.Clear();
            Console.WriteLine(_gameOver);
            Console.WriteLine("Бажаете занести результаты на стинку Facebook (Enter)");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Enter)
            {
                Post(_gameOver);
            }

            Thread.Sleep(2000);
            Console.WriteLine("Бажаете Продовжити (Enter)");
            info = Console.ReadKey();
            
            if (info.Key == ConsoleKey.Enter)
            {
                newPlay.Invoke();

            }
            Thread.Sleep(2000);
           


        }

        public void ShowMessage(string info)
        {
            Console.WriteLine(info);
        }

    }
}
