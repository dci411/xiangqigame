
using CNchess.function;
using System;
using System.Windows;
using System.Windows.Controls;


namespace CNchess
{
    class Rule
    {
        //Judge whether the mark of a pixel is outside the reasonable point where the chessboard can be placed
        public static bool IsOutside(Point point)
        {
            if ((point.X == 10) || (point.Y == 9)) return true;
            else return false;
        }



        public static void IsMeet(bool turn)
        {

            if (Other.image[0].Margin.Left == Other.image[1].Margin.Left)
            {
                int i = 0;
                bool meet = false;

                Point a = Board.MarginToLogical(Other.image[1].Margin);
                Point b = Board.MarginToLogical(Other.image[0].Margin);

                for (b.X = b.X + 1; b != a; b.X++)
                {
                    if (IsPiece(b) < 32) i++;
                }
                if (i == 0) meet = true;
                if (turn && meet) Event.Over(1);
                else if (!turn && meet) Event.Over(0);
            }
        }

        public static bool IsRed(int num)
        {
            if (((num + 1) % 2) != 0) return false;
            return true;
        }

        public static int IsPiece(Point position)
        {
            int i;
            for (i = 0; i < 32; i++)
            {
                if (Other.image[i].IsEnabled != false)
                    if (position == Board.MarginToLogical(Other.image[i].Margin))
                        return i;
            }
            return 32;
        }

        public static int IsPiece(double pieceX, double pieceY)
        {
            int i;
            for (i = 0; i < 32; i++)
            {
                if ((pieceX == Board.MarginToLogical(Other.image[i].Margin).X)
                    && (pieceY == Board.MarginToLogical(Other.image[i].Margin).Y))
                    return i;
            }
            return 32;
        }
        public virtual bool moverule(Point end, Point start, double a, double b)
        { return false; }

        public virtual bool moverule(Point end, Point start, double a, double b, int num)
        { return false; }
    }
}
