using System;
namespace xq1
{
    class Pawn : chess
    {
        public Pawn()
        {

        }
        public override int moveRule(int x1, int y1, int x2, int y2, int p, int[,] b)
        {
            //过河前左右移动
            if (p == red && x2 >= 5 && System.Math.Abs(y1 - y2) == 1 || p == black && x2 <= 4 && System.Math.Abs(y1 - y2) == 1)
            {
                return 0;
            }
            //不是在纵横方向上走一格
            else if (System.Math.Abs(y1 - y2) + System.Math.Abs(x1 - x2) != 1)
            {
                return 0;
            }
            //往后走
            else if (p == red && (x1 - x2) == -1 || p == black && (x1 - x2) == 1)
            {
                return 0;
            }
            return 1;
        }
    }
}