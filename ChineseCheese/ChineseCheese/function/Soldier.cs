using System;
using System.Windows;

namespace CNchess.function
{
     class Soldier
    {
        public static bool moverule(Point end, Point start, double a, double b,int num)
        {
            if ((Rule.IsRed(num) && start.X >= 5) || (!Rule.IsRed(num) && start.X <= 4))
            {
                if (Rule.IsRed(num))
                    if (a == -1 && b == 0) return true;
                if (!Rule.IsRed(num))
                    if (a == 1 && b == 0) return true;
            }

            if ((Rule.IsRed(num) && start.X <= 4) || (!Rule.IsRed(num) && start.X >= 5))
            {
                if ((Math.Abs(a) + Math.Abs(b)) == 1.0)
                {
                    if (Rule.IsRed(num))
                        if (a == -1 || Math.Abs(b) == 1) return true;
                    if (!Rule.IsRed(num))
                        if (a == 1 || Math.Abs(b) == 1) return true;
                }
            }
            return false;
        }
    }
}
