using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TanlBl.Abstract;

namespace TanlBl
{


    public   class Frame : IFrame
    {
        private int _hight = 75;
        private int _width = 25;
        private string[][] _frame;
        private string _wall = "#";
        private string _emtyCell = " ";
        private string _left = "<";
        private string _right = ">";

        public void Visible()
        {

            Console.ForegroundColor = ConsoleColor.White;

            _frame = new string[_width][];
            for (int i = 0; i < _width; i++)
            {
                _frame[i] = new string[_hight];
            }

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _hight; j++)
                {
                    if (i == 0 || i == _width - 1)
                    {
                        _frame[i][j] = _wall;
                    }
                    else
                    {
                        if (j == 0 || j == _hight - 1)
                        {
                            _frame[i][j] = _wall;
                        }
                        else
                        {
                            _frame[i][j] = _emtyCell;
                        }

                    }

                }
            }
            Render();
        }

        public void AddElement(int y, int x, string element)
        {
            if (Audit(x, y))
            {
                _frame[x][y] = element;
               // Render();
             
            }
        }

        public void AddElement(int y1, int x1, int y2, int x2, string element)
        {
           if(Audit(x1, y1) && Audit(x2, y2))
           {
                char[] ch = element.ToCharArray();
                int i = 0;

                while (x1 < x2 || y1 < y2)
                {
                    _frame[x1][y1] = ch[i].ToString();
                    if (x1 < x2)
                    {
                        x1++;
                    }
                    if (y1 < y2)
                    {
                        y1++;
                    }
                    i++;
                }
              
           }
        //    Render();

        }
 

        public void AddElementCenter(int x,string element)
        {
           
            char[] ch = element.ToCharArray();

            int center = _hight / 2- ch.Length/2;
       
            for (int i=0;i<ch.Length;i++)
            {
                _frame[x][center] = ch[i].ToString();
                 center++;
            }
          
            //Render();

        }

        public void AddLand(int x, int elementLight)
        {
           
            int center = _hight / 2 - elementLight/2;

            _frame[x][center - 1] = _left;
            _frame[x][center + elementLight] = _right;
            Render();
        }

        public void DeleteLand(int x, int elementLight)
        {
         
            int center = _hight / 2 -  elementLight/2;

            _frame[x][center] = " ";
            _frame[x][center + elementLight-1] = " ";
            Render();

        }

        public int GetElement(int x)
        {
            int sum = -1;

            for(int i = 0; i < _hight - 4; i++)
            {
                if(_frame[x][i] != " ")
                {
                    sum++;
                }
            }

            return sum;  

        }
       
        public int Hight()
        {
            return _hight;
        }

        public int Wihgt()
        {
            return _width;
        }

        private bool Audit(int x, int y)
        {
            if (x < 0 || x > _width - 1)
                return false;
            if (y < 0 || y > _hight - 1)
                return false;
            return true;

        }


        public  void Render()
        {
                Thread.Sleep(10);
                Console.SetCursorPosition(0, 0);
           
                for (int i = 0; i < _width; i++)
                {
                    for (int j = 0; j < _hight; j++)
                    {

                        Console.Write(_frame[i][j]);
                    }
                    Console.WriteLine();
                }

        }

        public string[][] GetFram()
        {
            return _frame;
        }

      
    }
}
