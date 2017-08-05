using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;

namespace TanlBl
{

     public class AllThread
    {
  
        private string _empty = " ";
        private volatile bool _stop;
        private Frame _frame;
        private object locker1 = new object();
        private bool _GameOver = true;
        MyTank _tank;
        Random _random = new Random();

        public static event Action<bool> Click;

        public AllThread(Frame frame)
        {
            _frame = frame;
            _tank = new MyTank(frame, 29, 23);
            new TanksMoveToFlag(frame);
            new Task(LiveOfMuTank).Start();
            Render();

        }
        private void Stop(ConsoleKeyInfo v)
        {
            Task task;
            SoundPlayer sp=null;
            while (true)
            {

                if (v.Key == ConsoleKey.Escape)
                {
                    _stop = true;
                 //  sp = new SoundPlayer("E:\\3164.wav");
                    Click(_stop);
                 //   sp.Play();

                }
                else if (v.Key == ConsoleKey.Enter)
                {
                  //  sp.Stop();
                   _stop = false;
                   Click(_stop);
                }
                break;
            }
        }

        private void Render()
        {
            while (true)
            {

                if (!_stop)
                {
                    _frame.Render();
                    Console.WriteLine("Ваши жизни  1");
                    if (Cont() || !MyTantOnFrame())
                    {
                        Thread.Sleep(2000);
                        new GameOver();
                        break;
                    }
                }
            }
        }

        private void LiveOfMuTank()
        {
            while (_GameOver)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (!_stop)
                {
                   
                    if (keyInfo.Key == ConsoleKey.Backspace)
                    {

                        Thread.Sleep(300);
                        new Thread(_tank.Shoot).Start();
                        Thread.Sleep(300);
                        //Esc_Clickl(false);
                    }
                    _tank.TankMove((int)keyInfo.Key);
                  
                    //  Esc_Clickl(false);
                }
                Stop(keyInfo);
            }
        }

        private bool Mytank(string tank)
        {
            if (tank.Equals("W"))
            {
                return true;
            }
            if (tank.Equals("Е"))
            {
                return true;
            }
            if (tank.Equals("3"))
            {
                return true;
            }
            if (tank.Equals("М"))
            {
                return true;
            }
            return false;



        }

        private bool MyTantOnFrame()
        {
            for (int i = 0; i < _frame.Wihgt(); i++)
            {
                for (int j = 0; j < _frame.Hight(); j++)
                {
                    if (Mytank(_frame.GetFram()[i][j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Cont()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_frame.GetFram()[22 + i][35 + j] == _empty && _frame.GetFram()[23][36] != _empty)
                    {

                        return false;
                    }
                }
            }
            return true;
        }

  
    }
    class Location
    {
        public int x;
        public int y;
        public Location(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
