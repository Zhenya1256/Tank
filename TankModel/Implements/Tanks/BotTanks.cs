using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TankModel.Implements.Tanks
{
   public class BotTanks
    {


        public void CreatTanks(string[][] frame, string emtyCell,int width, int hight)
        {
            BotTank t1 = new BotTank(3, 3, frame, emtyCell, "X", width, hight);
            new Task(t1.MoveToHorNextVer).Start();
            //
             Thread.Sleep(1000);
            BotTank t2 = new BotTank(11, 3, frame, emtyCell, "Y", width, hight);           
            new Task(t2.MoveToHorNextVer).Start();

            Thread.Sleep(1000);
            BotTank t3 = new BotTank(2,61, frame, emtyCell, "O", width, hight);
            new Task(t3.MoveVerNextHor).Start();

            Thread.Sleep(3000);
            BotTank t4 = new BotTank(10, 60, frame, emtyCell, "K", width, hight);
            new Task(t4.MoveToHorNextVer).Start();
            Thread.Sleep(8000);
            BotTank t5 = new BotTank(9, 43, frame, emtyCell, "T", width, hight);
            new Task(t5.MoveVerNextHor).Start();




        }
    }
}
