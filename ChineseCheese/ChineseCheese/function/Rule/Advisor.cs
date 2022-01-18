using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CNchess.function
{
    class Advisor : Rule
    {
        public override bool moverule(Point end, Point start, double a, double b)
        {//The guarantor will be in the ninth house
            if (end.X > 3 && end.X < 7) return false;
            if (!(end.Y >2 && end.Y < 6)) return false;

            //Guarantors walk diagonally one grid at a time
            if (Math.Abs(a) == 1 && Math.Abs(b) == 1) return true;
            return false;
        }
    }
}
