﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using TankView.Implements;
using TankModel;

namespace Tank
{
    class Program
    {
     
        static void Main(string[] args)
        {
            //MoveComponent d = new MoveComponent();
            Pressent pr = new Pressent();
            Console.ReadKey();
        }
    



        public static void Music()
        {
            while(true)
            Beethoven();
               
            
        }
        private static void Beethoven()
        {
            Console.Beep(659, 120);
            Thread.Sleep(130);
            Console.Beep(622, 120);
            Thread.Sleep(130);

            Console.Beep(659, 120);
            Thread.Sleep(130);
            Console.Beep(622, 120);
            Thread.Sleep(130);
            Console.Beep(659, 120);
            Thread.Sleep(130);
            Console.Beep(494, 120);
            Thread.Sleep(130);
            Console.Beep(587, 120);
            Thread.Sleep(130);
            Console.Beep(523, 120);
            Thread.Sleep(130);

            Console.Beep(440, 120);
            Thread.Sleep(150);
            Console.Beep(262, 120);
            Thread.Sleep(130);
            Console.Beep(330, 120);
            Thread.Sleep(130);
            Console.Beep(440, 120);
            Thread.Sleep(130);

            Console.Beep(494, 120);
            Thread.Sleep(150);
            Console.Beep(330, 120);
            Thread.Sleep(130);
            Console.Beep(415, 120);
            Thread.Sleep(130);
            Console.Beep(494, 120);
            Thread.Sleep(130);

            Console.Beep(523, 120);
            Thread.Sleep(150);
            Console.Beep(330, 120);
            Thread.Sleep(130);
            Console.Beep(659, 120);
            Thread.Sleep(130);
            Console.Beep(622, 120);
            Thread.Sleep(130);

            Console.Beep(659, 120);
            Thread.Sleep(130);
            Console.Beep(622, 120);
            Thread.Sleep(130);
            Console.Beep(659, 120);
            Thread.Sleep(130);
            Console.Beep(494, 120);
            Thread.Sleep(130);
            Console.Beep(587, 120);
            Thread.Sleep(130);
            Console.Beep(523, 120);
            Thread.Sleep(130);

            Console.Beep(440, 120);
            Thread.Sleep(150);
            Console.Beep(262, 120);
            Thread.Sleep(130);
            Console.Beep(330, 120);
            Thread.Sleep(130);
            Console.Beep(440, 120);
            Thread.Sleep(130);

            Console.Beep(494, 120);
            Thread.Sleep(150);
            Console.Beep(330, 120);
            Thread.Sleep(130);
            Console.Beep(523, 120);
            Thread.Sleep(130);
            Console.Beep(494, 120);
            Thread.Sleep(150);
            Console.Beep(440, 120);
        }
    }
    class Pressent
    {
        View d;
        MyTank tank;
        public Pressent()
        {
            d = new View();
            tank = new MyTank();
            d.Click_left += tank.MoveToLeft;
            d.Click_down += tank.MoveToDown;
            d.Click_right += tank.MoveToRight;
            d.Click_up += tank.MoveToUp;
            d.Click();
        }
    }
}
