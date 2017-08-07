using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TankView.Abstract;

namespace TankView.Implements
{
    class Drow : IDrow
    {
        private const  int HIGHT = 75;
        private const int WIDTH = 25;

        private const string WALL = "#";
        private const string EMPTECELL = " ";
        private const string LEFT = "<";
        private const string RIGHT = ">";

        private string[][] _frame;


        public void Visible()
        {

            Console.ForegroundColor = ConsoleColor.White;

            _frame = new string[WIDTH][];
            for (int i = 0; i < WIDTH; i++)
            {
                _frame[i] = new string[HIGHT];
            }

            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HIGHT; j++)
                {
                    if (i == 0 || i == WIDTH - 1)
                    {
                        _frame[i][j] = WALL;
                    }
                    else
                    {
                        if (j == 0 || j == HIGHT - 1)
                        {
                            _frame[i][j] = WALL;
                        }
                        else
                        {
                            _frame[i][j] = EMPTECELL;
                        }

                    }

                }
            }
        }

        public void AddElement(int y, int x, string element)
        {
            if (Audit(x, y))
            {
                _frame[x][y] = element;
            }
        }

        public void AddElement(int y1, int x1, int y2, int x2, string element)
        {
            if (Audit(x1, y1) && Audit(x2, y2))
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
        }

        public void AddElementCenter(int x, string element)
        {

            char[] ch = element.ToCharArray();

            int center = HIGHT / 2 - ch.Length / 2;

            for (int i = 0; i < ch.Length; i++)
            {
                _frame[x][center] = ch[i].ToString();
                center++;
            }

        }

        public void AddLand(int x, int elementLight)
        {

            int center = HIGHT / 2 - elementLight / 2;

            _frame[x][center - 1] = LEFT;
            _frame[x][center + elementLight] = RIGHT;
        }

        public void DeleteLand(int x, int elementLight)
        {

            int center = HIGHT / 2 - elementLight / 2;

            _frame[x][center] = " ";
            _frame[x][center + elementLight - 1] = " ";

        }

        public int GetElement(int x)
        {
            int sum = -1;

            for (int i = 0; i < HIGHT - 4; i++)
            {
                if (_frame[x][i] != " ")
                {
                    sum++;
                }
            }

            return sum;

        }

        public int Hight()
        {
            return HIGHT;
        }

        public int Wihgt()
        {
            return WIDTH;
        }

        private bool Audit(int x, int y)
        {
            if (x < 0 || x > WIDTH - 1)
                return false;
            if (y < 0 || y > HIGHT - 1)
                return false;
            return true;

        }

        public string[][] GetFram()
        {
            return _frame;
        }

        public void Render()
        {
            Thread.Sleep(10);
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HIGHT; j++)
                {

                    Console.Write(_frame[i][j]);
                }
                Console.WriteLine();
            }

        }

    
    }
}
