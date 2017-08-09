using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TankModel.Implements
{
 public class PlayMusic
    {
        System.Windows.Media.MediaPlayer _mp;
        public PlayMusic()
        {
          
          _mp = new System.Windows.Media.MediaPlayer();
          _mp.Open(new Uri(@"E:\ProjecktC#\Tank\TankModel\music.mp3"));
            //mp.Open(new Uri("c:\pathtomedia\MySound.wav"));
          
        }
        public void Play()
        {
            _mp.Play();
        }
        public void Stop()
        {
            _mp.Stop();
        }
    }
}
