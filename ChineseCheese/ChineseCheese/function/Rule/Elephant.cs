using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CNchess.function
{
    class Elephant : Rule
    {
        public override bool moverule(Point end, Point start, double a, double b)
        {//Elephant can't cross the river
            if ((start.X <= 4 && end.X >= 5) || (end.X <= 4 && start.X >= 5)) return false;

            //Not blocked
            if (IsPiece((start.X + end.X) / 2, (start.Y + end.Y) / 2) < 32) return false;

            //Ensure that the elephant walks the word "田"
            if (Math.Abs(a) == 2 && Math.Abs(b) == 2) return true;
            return false;

        }
    }
}
