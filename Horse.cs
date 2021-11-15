using System;
namespace xq1
{
    class Horse : chess
    {
        public Horse()
        {

        }
        public override int moveRule(int x1, int y1, int x2, int y2, int p, int[,] b)
        {
            if (System.Math.Abs(x1 - x2) == 1 && y1 - y2 == 2)
            {
                jiox = x1;
                jioy = y1 - 1;
            }
            else if (System.Math.Abs(x1 - x2) == 1 && y1 - y2 == -2)
            {
                jiox = x1;
                jioy = y1 + 1;
            }
            else if (System.Math.Abs(y1 - y2) == 1 && x1 - x2 == 2)
            {
                jioy = y1;
                jiox = x1 - 1;
            }
            else if (System.Math.Abs(y1 - y2) == 1 && x1 - x2 == -2)
            {
                jioy = y1;
                jiox = x1 + 1;
            }
            if (System.Math.Abs(y1 - y2) + System.Math.Abs(x1 - x2) != 3)
            {
                jioy = -1;
                jiox = -1;
                return 0;
            }
            else if (b[jiox, jioy] != 0)
            {
                jioy = -1;
                jiox = -1;
                return 0;
            }

            jioy = -1;
            jiox = -1;
            return 1;
        }
    }
}