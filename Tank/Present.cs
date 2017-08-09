using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using TankView.Implements;
using TankModel;
using TankView.Abstract;
using TankModel.Implements.Tanks;
using TankModel.Implements;

namespace Tank
{
    class Present
    {
        IMyEvent view;
        MyTank tank;
        BotTanks bot;
        PlayMusic music;
        GameOver gameOver;
        PostInFacebook post;


        public Present()
        {
            view = new View();
            tank = new MyTank();
            bot = new BotTanks();
            music = new PlayMusic();
            gameOver = new GameOver();
            post = new PostInFacebook();

            Events();
            new Task(view.Render).Start();
            new Task(ThreadBot).Start();
            view.Click();
        }

        private void Events()
        {
            view.Click_left += tank.MoveToLeft;
            view.Click_down += tank.MoveToDown;
            view.Click_right += tank.MoveToRight;
            view.Click_up += tank.MoveToUp;
            view.Click_Shoot += tank.Shoot;
            view.ScriptBot += bot.CreatTanks;

            view.PlayMusic += music.Play;
            view.StopMusic += music.Stop;
            view.GameOver += gameOver.End;
            view.newPlay += View_newPlay;
          
            view.Win += gameOver.Win;
            view.MakeScreen += post.MakeScreen;
            view.Post += post.Post;

            post.messageForUser += view.ShowMessage;
            post.messageForUsertoEnd += view.ShowMessage;
            BotTank.stop += () => view.Stop;

        }

        private void View_newPlay()
        {
            new Present();
        }

        private void ThreadBot()
        {
            view.StartBot();
        }
    }
}
