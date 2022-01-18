using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CNchess.function
{
    class Cannon:Rule
    {
        public static int Item_moverule(Point end, Point start, double a, double b)
        {

            int src = Board.GetArrary(start);
            int des = Board.GetArrary(end);
            double degree;
            //Keep straight
            if (!(a == 0 || b == 0)) return -1;

            if (a == 0)
            {
                degree = (b / Math.Abs(b));
                for (src += (int)degree; src != des; src += (int)degree)
                {
                    if (IsPiece(Other.logicAdr[src]) < 32) return 0;
                }
            }
            else if (b == 0)
            {
                degree = 9 * (a / Math.Abs(a));
                for (src += (int)degree; src != des; src += (int)degree)
                {
                    if (IsPiece(Other.logicAdr[src]) < 32)
                    {
                        return 0;
                    }
                }
            }
            return 1;
        }
        public static bool Attack(Point end, Point start)
        {
            int count = 0;
            double degree = 0;

            int src = Board.GetArrary(start);
            int des = Board.GetArrary(end);
            double a = end.X - start.X;
            double b = end.Y - start.Y;

            //Keep straight
            if (!(a == 0 || b == 0)) return false;

            //Sets the value of the loop variable (horizontal search or vertical search)
            if (a == 0) degree = (b / Math.Abs(b));//Horizontal search
            else if (b == 0) degree = 9 * (a / Math.Abs(a));//Vertical search

            //Traverse the position between the gun and the attacked chess piece
            for (src += (int)degree; src != des; src += (int)degree)
            {

                if (IsPiece(Other.logicAdr[src]) < 32) count++;
            }//You can attack when there is only one piece
            if (count == 1)
            {
                return true;
            }
            else return false;
        }
    }
}
