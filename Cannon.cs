using System;
namespace xq1
{
    class Cannon : chess
    {
        public Cannon()
        {

        }
        public override int moveRule(int x1, int y1, int x2, int y2, int p, int[,] b)
        {
            if (x1 == x2)
            {
                start = y1;
                end = y2;
                i = x1;
                if (y1 > y2)
                {
                    start = y2;
                    end = y1;
                }
                for (j = start + 1; j < end; j++)
                {
                    if (b[i, j] != 0)
                    {
                        c++;
                    }
                }

            }
            else if (y1 == y2)
            {
                start = x1;
                end = x2;
                j = y1;
                if (x1 > x2)
                {
                    start = x2;
                    end = x1;
                }
                for (i = start + 1; i < end; i++)
                {
                    if (b[i, j] != 0)
                    {
                        c++;
                    }
                }

            }
            else
            {
                c = 0;
                return 0;
            }
            if (c > 1)
            {
                c = 0;
                return 0;
            }
            else if (c == 1)
            {
                if (b[x2, y2] > 10 && p == red || b[x2, y2] > 0 && b[x2, y2] < 10 && p == black)
                {
                    c = 0;
                    return 1;
                }
                else
                {
                    c = 0;
                    return 0;
                }
            }
            else if (c == 0)
            {
                if (b[x2, y2] != 0)
                {
                    c = 0;
                    return 0;
                }
            }
            c = 0;
            return 1;
        }
    }
}
