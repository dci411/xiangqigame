using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CNchess.function
{
    class Elephant
    {
        public static bool moverule(Point end, Point start, double a, double b)
        {
            if ((start.X <= 4 && end.X >= 5) || (end.X <= 4 && start.X >= 5)) return false;


            if (Rule.IsPiece((start.X + end.X) / 2, (start.Y + end.Y) / 2) < 32) return false;


            if (Math.Abs(a) == 2 && Math.Abs(b) == 2) return true;
            return false;

        }
    }
}
