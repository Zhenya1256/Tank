using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankModel.Implements
{
    public class GameOver
    {
        public bool End(string[][] frameOfPlay, string[] spritesTank, string flag, int width, int hight)
        {
            bool isFlag=false;
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < hight - 1; j++)
                {
                    
                    if (flag == frameOfPlay[i][j])
                    {
                        isFlag = true;
                            //return false;
                    }
                    

                }
            }
            
            if (isFlag)
            {
                for (int i = 1; i < width - 1; i++)
                {
                    for (int j = 1; j < hight - 1; j++)
                    {
                        for (int t = 0; t < spritesTank.Length; t++)
                        {
                            if (spritesTank[t] == frameOfPlay[i][j])
                            {
                                return false;

                            }
                        }

                    }
                }
            }
        
                    return true;
        }
    }
}
