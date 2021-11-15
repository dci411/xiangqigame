using System;
namespace xq1
{
    class chess
    {

        public int red = 1;
        public int black = 0;
        public int piece = 0;
        public int i, j;
        public int start, end;
        public int jiox = -1, jioy = -1;
        public int c = 0;


        public void MovePiece(int x1, int y1, int x2, int y2, int[,] b)
        {
            b[x2, y2] = b[x1, y1];
            b[x1, y1] = 0;
        }
        public virtual int moveRule(int x1, int y1, int x2, int y2, int p, int[,] b)
        {   // can not choose null
            if (b[x1, y1] == 0)
            {
                return 0;
            }// can not choose other side piece
            if (b[x1, y1] > 0 && b[x1, y1] < 10 && p == black || b[x1, y1] > 10 && p == red)
            {
                return 0;
            }
            //turn
            if (b[x2, y2] > 0 && b[x2, y2] < 10 && p == red || b[x2, y2] > 10 && p == black)
            {
                return 0;
            }
            return 1;

        }

    }
}