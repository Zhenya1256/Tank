using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TankModel.Implements
{
    class MyMutex
    {

        Mutex _mutex;

        public MyMutex()
        {
            _mutex = new Mutex();
        }

        public void WaitOne()
        {
            _mutex.WaitOne();
        }
        public void Release()
        {
            _mutex.ReleaseMutex();
        }
    }
}
