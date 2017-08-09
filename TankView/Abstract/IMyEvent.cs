using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankView.Abstract
{
   public interface IMyEvent
    {
        event Action<string[][], string[], string , string , int , int> Click_left;
        event Action<string[][], string[], string, string, int, int> Click_right;
        event Action<string[][], string[], string, string, int, int> Click_down;
        event Action<string[][], string[], string, string, int, int> Click_up;
        event Action<string[][], string, string, string,string,string, int, int> Click_Shoot;
        event Action<string[][], string ,int, int> ScriptBot;
        event Action PlayMusic;
        event Action StopMusic;
        event Func<string[][], string[], string , int, int,bool> GameOver;
        event Action newPlay;
        event Action Post;
        bool Stop { get; set; }
        void StartBot();
        void Click();
        void Render();
    }
}
