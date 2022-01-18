using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CNchess.function
{
     class General : Rule
    {
        public override bool moverule(Point end, Point start, double a, double b)
        {//Ensure that Shuai will be in the ninth house
            if (end.X >= 3 && end.X < 7) return false;
            if (!(end.Y > 2 && end.Y < 6)) return false;

            //Keep handsome and walk one grid at a time
            if ((Math.Abs(a) + Math.Abs(b)) == 1.0) return true;

            return false;
        }
        }
}
