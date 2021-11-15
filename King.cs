using System;
namespace xq1
{
    class King : chess
    {
        public King()
        {

        }
        public override int moveRule(int x1, int y1, int x2, int y2, int p, int[,] b)
        {
            //飞将
            if ((p == red && b[x2, y2] == 15 && x2 < 3 || p == black && b[x2, y2] == 5 && x2 > 7) && y1 == y2)
            {
                start = x1;
                end = x2;
                j = y1;
                if (x1 < x2)
                {
                    start = x2;
                    end = x1;
                }
                for (i = start + 1; i < end; i++)
                {
                    if (b[i, j] != 0)
                    {
                        return 0;
                    }
                }
                return 1;
            }
            if (p == red && (x2 < 7 || y2 < 3 || y2 > 5) || p == black && (x2 > 2 || y2 < 3 || y2 > 5))
            {
                return 0;
            }
            else if (System.Math.Abs(x1 - x2) + System.Math.Abs(y1 - y2) != 1)
            {
                return 0;
            }

            return 1;
        }
    }
}