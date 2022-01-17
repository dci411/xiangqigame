using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CNchess.function
{
     class CannonAndCar
    {
        public static int moverule(Point end, Point start, double a, double b)
        {
            
        int src = Rule.GetArrary(start);
            int des = Rule.GetArrary(end);
            double degree;

            if (!(a == 0 || b == 0))return -1;

            if (a == 0)
            {
                degree = (b / Math.Abs(b));
                for (src += (int)degree; src != des; src += (int)degree)
                {
                    if (Rule.IsPiece(Other.logicAdr[src]) < 32) return 0;
                }
            }
            else if (b == 0)
            {
                degree = 9 * (a / Math.Abs(a));
                for (src += (int)degree; src != des; src += (int)degree)
                {
                    if (Rule.IsPiece(Other.logicAdr[src]) < 32)
                    {
                        return 0;
                    }
                }
            }
            return 1;
        } 
    }
}
