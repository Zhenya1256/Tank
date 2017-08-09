using Facebook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankModel.Implements
{
  public  class PostInFacebook
    {

        private Action action;

        public event Action<string> messageForUser;
        public event Action<string> messageForUsertoEnd;
        Bitmap bmp;

        private string _info;

        public void Post(string info)
        {
            _info = info;
            action = Write;
            IAsyncResult result = action.BeginInvoke(CallBack, null);
            if (messageForUser != null)
            {
                messageForUser("Чекайте...");
            }
            action.EndInvoke(result);
            


        }

        public void Write()
        {
            string Picture_Caption = _info;
            byte[] b = ImageToByte(bmp as Image);
            string access_token = "EAAb2setNENQBAGQAMS0g8wkJZC3RZBZC2MRughMXNPtCrevdR3e7sVGScFXVqOkjkMxHb6p3me1WFJZBSFZBFnVBgpLWjYNOnEi7gZCEquQkeUlb7Nz3PU8Gf3iZB8jJzRiZAc0JzZBXZBptwRf6FeHy33PYsCQ94mZAOLTwDwzh69VtwZDZD";
            var fb = new FacebookClient(access_token);
            dynamic parameters = new ExpandoObject();
            parameters.message = Picture_Caption;
            parameters.source = new FacebookMediaObject
            {
                ContentType = "image/jpeg",
                FileName = Path.GetFileName("filename")
            }.SetValue(b);
            fb.Post("me/photos", parameters);

        }

        public void MakeScreen()
        {
            Graphics g = null;
             bmp = new Bitmap(Console.WindowWidth * 8, Console.WindowHeight * 6);
            g = Graphics.FromImage(bmp as Image);
            g.CopyFromScreen(0, 0, 0, 0, bmp.Size);
            bmp.Save("filename");

        }

        private byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public void CallBack(IAsyncResult result)
        {
            if (messageForUsertoEnd != null)
            {
                messageForUsertoEnd("Пост добавлено успiшно");
            }
        }
    }
}
