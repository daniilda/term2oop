using System;//your ife is a fucking joke
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class XandOes
    {

        private static int player1count;
        internal int Player1count
        {
            set { player1count = value; }
            get { return player1count; }
        }

        private static int player2count;
        internal int Player2count
        {
            set { player2count = value; }
            get { return player2count; }
        }

        private static string player1Name;
        internal string Player1Name
        {
            set { player1Name = value; }
            get { return player1Name; }
        }

        private static string player2Name;
        internal string Player2Name
        {
            set { player2Name = value; }
            get { return player2Name; }
        }

        static byte gamemode = 1;
        internal void setGM(byte set)

        {
            gamemode = set;
        }

        internal byte getGM()

        {
            return gamemode;
        }

        static bool turn = false;
        internal void setTurn()
        {
            if (turn)
            {
                turn = false;
            } else
            {
                turn = true;
            }

        }
        internal bool getTurn()
        {
            return turn;
        }

        static byte[,] boardData;
        internal void init_boardData(int a, int b)
        {
            boardData = new byte[a, b];
            for (int i = 0; i < boardData.GetUpperBound(1) + 1; i++)
            {
                for (int j = 0; j < boardData.GetUpperBound(0) + 1; j++)
                {
                    boardData[j, i] = 0; 
                }
            }
        }
        internal void set_boardData(double x, double y)
        {
            int a = Convert.ToInt32(x);
            int b = Convert.ToInt32(y);
            if (!turn)
                boardData[a, b] = 1;
            else
                boardData[a, b] = 2;
        }
        internal byte[,] get_boardData()
        {
            return boardData;
        }
        internal bool checkWin(double x, double y, out int x1, out int y1, out int x2, out int y2)
        {
            int a = Convert.ToInt32(x);
            int b = Convert.ToInt32(y);
            int startx = 0;
            int starty= 0;
            int endx=0;
            int endy=0;
            bool borders(int e, int r)
            {
                if (e <= 9 && r <= 9 && e >= 0 && r >= 0)
                    return true;
                else
                    return false;
            }
            bool checkzero(int q, int w)
            {

                if (boardData[a, b] == boardData[q, w])
                    return true;
                else return false;


            }
            bool check1(int q, int w)   // /
            {
                int maximcount = 0;
                int counter = 0;
                bool dir = false;

                while (checkzero(q,w) && counter < 5 && maximcount < 2)
                {
                    if (!dir)
                    {
                        q += 1;
                        w -= 1;
                        if(!borders(q,w))
                        {
                            maximcount++;
                            dir = !dir;
                            q -= 1;
                            w += 1;
                            counter = 0;
                            startx = q;
                            starty = w;
                        } else if (!checkzero(q,w))
                        {
                            maximcount++;
                            dir = !dir;
                            q -= 1;
                            w += 1;
                            counter = 0;
                            startx = q;
                            starty = w;
                        }
                        
                    }
                    else
                    {
                        q -= 1;
                        w += 1;
                        if (!borders(q, w))
                        {
                            maximcount++;
                            dir = !dir;
                            q += 1;
                            w -= 1;
                            counter = 0;
                            startx = q;
                            starty = w;
                        } else if (!checkzero(q,w))
                        {
                            maximcount++;
                            dir = !dir;
                            q += 1;
                            w -= 1;
                            counter = 0;
                            startx = q;
                            starty = w;
                        }
                    }
                    if (checkzero(q, w))
                        counter++;
                }
                if (counter == 5)
                {
                    endx = q;
                    endy = w;
                    return true;
                }
                else
                    return false;
            }
        
            
            bool check2(int q, int w) // \
            {
                int maximcount = 0;
                int counter = 0;
                bool dir = false;

                while (checkzero(q, w) && counter < 5 && maximcount < 2)
                {
                    if (!dir)
                    {
                        q -= 1;
                        w -= 1;
                        if (!borders(q, w))
                        {
                            maximcount++;
                            dir = !dir;
                            q += 1;
                            w += 1;
                            counter = 0;
                            startx = q;
                            starty = w;
                        }
                        else if (!checkzero(q, w))
                        {
                            maximcount++;
                            dir = !dir;
                            q += 1;
                            w += 1;
                            counter = 0;
                            startx = q;
                            starty = w;
                        }

                    }
                    else
                    {
                        q += 1;
                        w += 1;
                        if (!borders(q, w))
                        {
                            maximcount++;
                            dir = !dir;
                            q -= 1;
                            w -= 1;
                            counter = 0;
                            startx = q;
                            starty = w;
                        }
                        else if (!checkzero(q, w))
                        {
                            maximcount++;
                            dir = !dir;
                            q -= 1;
                            w -= 1;
                            counter = 0;
                            startx = q;
                            starty = w;
                        }
                    }
                    if (checkzero(q, w))
                        counter++;
                }
                if (counter == 5)
                {
                    endx = q;
                    endy = w;
                    return true;
                }
                else
                    return false;

            }
            bool check3(int q, int w) // |
            {
                int maximcount = 0;
                int counter = 0;
                bool dir = false;

                while (checkzero(q, w) && counter < 5 && maximcount < 2)
                {
                    if (!dir)
                    {
                        q += 0;
                        w -= 1;
                        if (!borders(q, w))
                        {
                            maximcount++;
                            dir = !dir;
                            q -= 0;
                            w += 1;
                            counter = 0;
                            startx = q;
                            starty = w;
                        }
                        else if (!checkzero(q, w))
                        {
                            maximcount++;
                            dir = !dir;
                            q -= 0;
                            w += 1;
                            counter = 0;
                            startx = q;
                            starty = w;
                        }

                    }
                    else
                    {
                        q -= 0;
                        w += 1;
                        if (!borders(q, w))
                        {
                            maximcount++;
                            dir = !dir;
                            q += 0;
                            w -= 1;
                            counter = 0;
                            startx = q;
                            starty = w;
                        }
                        else if (!checkzero(q, w))
                        {
                            maximcount++;
                            dir = !dir;
                            q += 0;
                            w -= 1;
                            counter = 0;
                            startx = q;
                            starty = w;
                        }
                    }
                    if (checkzero(q, w))
                        counter++;
                }
                if (counter == 5)
                {
                    endx = q;
                    endy = w;
                    return true;
                }
                else
                    return false;
            }
            bool check4(int q, int w) 
            {
                int maximcount = 0;
                int counter = 0;
                bool dir = false;

                while (checkzero(q, w) && counter < 5 && maximcount < 2)
                {
                    if (!dir)
                    {
                        q += 1;
                        w -= 0;
                        if (!borders(q, w))
                        {
                            maximcount++;
                            dir = !dir;
                            q -= 1;
                            w += 0;
                            counter = 0;
                            startx = q;
                            starty = w;
                        }
                        else if (!checkzero(q, w))
                        {
                            maximcount++;
                            dir = !dir;
                            q -= 1;
                            w += 0;
                            counter = 0;
                            startx = q;
                            starty = w;
                        }

                    }
                    else
                    {
                        q -= 1;
                        w += 0;
                        if (!borders(q, w))
                        {
                            maximcount++;
                            dir = !dir;
                            q += 1;
                            w -= 0;
                            counter = 0;
                            startx = q;
                            starty = w;
                        }
                        else if (!checkzero(q, w))
                        {
                            maximcount++;
                            dir = !dir;
                            q += 1;
                            w -= 0;
                            counter = 0;
                            startx = q;
                            starty = w;
                        }
                    }
                    if (checkzero(q, w))
                        counter++;
                }
                if (counter == 5)
                {
                    endx = q;
                    endy = w;
                    return true;
                }
                else
                    return false;
            }
        if (check1(a,b) || check2(a,b) || check3(a,b) || check4(a,b))
            {
                y1 = starty;
                x1 = startx;
                y2 = endy;
                x2 = endx;
                return true;
            } else
            {
                y1 = starty;
                x1 = startx;
                y2 = endy;
                x2 = endx;
                return false;
            }
        }

        internal bool checkPos (double cellX, double cellY)
        {
            int a = Convert.ToInt32(cellX);
            int b = Convert.ToInt32(cellY);
            if (boardData[a, b] > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
