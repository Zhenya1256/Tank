using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanlBl.Abstract;

namespace TanlBl
{

    class GameOver
    {
        private const string NEWPLAY = "NEW_PLAY";
        private const string GANEOVER = "GAME_OVER";
        private IFrame _frame;

        public GameOver()
        {
            _frame = new Frame();
            _frame.Visible();
            AddElementOnFrame();

        }
        private void AddElementOnFrame()
        {
            _frame.AddElementCenter(8, GANEOVER);
            _frame.AddElementCenter(14, NEWPLAY);

            //frame.Render();
            ChoseLine();


        }
        private void ChoseLine()
        {
           
            _frame.AddLand(14, NEWPLAY.Length);

            while (true)
            {
                ConsoleKeyInfo c = Console.ReadKey();
                if (c.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    new Construction();

                    break;
                }

            }

        }
    }
}
