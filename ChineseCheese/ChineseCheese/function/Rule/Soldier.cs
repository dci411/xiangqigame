using System;
using System.Windows;

namespace CNchess.function
{
    class Soldier : Rule
    {
        public override bool moverule(Point end, Point start, double a, double b, int num)
        {//Soldiers can only walk forward one step before crossing the river
            if ((IsRed(num) && start.X >= 5) || (!IsRed(num) && start.X <= 4))
            {
                if (IsRed(num))
                    if (a == -1 && b == 0) return true;
                if (!IsRed(num))
                    if (a == 1 && b == 0) return true;
            }
            //Soldiers can move left and right after crossing the river
            if ((IsRed(num) && start.X <= 4) || (!IsRed(num) && start.X >= 5))
            {
                if ((Math.Abs(a) + Math.Abs(b)) == 1.0)
                {
                    if (IsRed(num))
                        if (a == -1 || Math.Abs(b) == 1) return true;
                    if (!IsRed(num))
                        if (a == 1 || Math.Abs(b) == 1) return true;
                }
            }
            return false;
        }
    }
}
