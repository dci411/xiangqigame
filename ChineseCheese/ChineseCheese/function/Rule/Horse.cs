using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CNchess.function
{
    internal class Horse : Rule
    {
        public override bool moverule(Point end, Point start, double a, double b)
        {

            //Make sure to follow the "日" font
            if (!((Math.Abs(a) == 2 && Math.Abs(b) == 1) || (Math.Abs(a) == 1 && Math.Abs(b) == 2))) return false;

            //Not blocked
            if (Math.Abs(a) == 2)
            {
                if (IsPiece(a / Math.Abs(a) + start.X, start.Y) < 32)
                    return false;
            }
            else if (Math.Abs(b) == 2)
            {
                if (IsPiece(start.X, b / Math.Abs(b) + start.Y) < 32)
                    return false;
            }

            return true;
        }
    }
}
