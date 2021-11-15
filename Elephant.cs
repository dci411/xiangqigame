using System;
namespace xq1
{
    class Elephant : chess
    {
        public Elephant()
        {

        }
        public override int moveRule(int x1, int y1, int x2, int y2, int p, int[,] b)
        {
            //相（象）过河 

            if (p == red && x2 < 5 || p == black && x2 > 4)
            {
                return 0;
            }
            else if (System.Math.Abs(y1 - y2) == 2 && System.Math.Abs(x1 - x2) == 2)
            {
                jioy = (y1 + y2) / 2;
                jiox = (x1 + x2) / 2;

                if (b[jiox, jioy] != 0)
                {
                    jioy = -1;
                    jiox = -1;
                    return 0;
                }
            }
            else
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