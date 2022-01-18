using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CNchess.function
{
    class Car : Rule
    {
        public static int Item_moverule(Point end, Point start, double a, double b)
        {

            int src = Board.GetArrary(start);
            int des = Board.GetArrary(end);
            double degree;
            //Keep straight
            if (!(a == 0 || b == 0)) return -1;
            //Make sure there are no other pieces on the line
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
    }
}
