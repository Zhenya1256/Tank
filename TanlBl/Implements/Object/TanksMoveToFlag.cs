using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TanlBl
{
    class TanksMoveToFlag
    {
        Frame _frame;

        public TanksMoveToFlag(Frame frame)
        {
            _frame = frame;
            new Task(Tanks).Start();

        }
        private void Tanks()
        {
           
            BotTank b2 = new BotTank(_frame, 60, 3, "O");
            Task taask1 = Task.Factory.StartNew(b2.LiveOfPlayVersion1);
            Thread.Sleep(1000);
            BotTank b3 = new BotTank(_frame, 15, 4, "0");
            new Task(b3.LiveOfPlayVersion2).Start();

            Thread.Sleep(1000);
            BotTank b4 = new BotTank(_frame, 45, 4, "H");
            new Task(b4.LiveOfPlayVersion2).Start();
            Thread.Sleep(8000);
            BotTank b5 = new BotTank(_frame, 72, 1, "L");
            new Task(b5.LiveOfPlayVersion2).Start();
            //
            Thread.Sleep(8000);
            BotTank b6 = new BotTank(_frame, 2, 1, "I");
            new Task(b6.LiveOfPlayVersion2).Start();
            Thread.Sleep(8000);
            BotTank b7 = new BotTank(_frame, 1, 1, "Q");
            new Task(b7.LiveOfPlayVersion1).Start();

        }

    }
}
