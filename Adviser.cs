using System;
namespace xq1
{
    class Adviser : chess
    {
        public Adviser()
        {

        }
        public override int moveRule(int x1, int y1, int x2, int y2, int p, int[,] b)
        {
            if (p == red && (x2 < 7 || y2 < 3 || y2 > 5) || p == black && (x2 > 2 || y2 < 3 || y2 > 5))
            {
                return 0;
            }
            else if (System.Math.Abs(x1 - x2) != 1 || System.Math.Abs(y1 - y2) != 1)
            {
                return 0;
            }

            return 1;
        }
    }
}