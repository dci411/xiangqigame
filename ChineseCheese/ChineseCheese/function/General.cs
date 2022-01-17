﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CNchess.function
{
     class General
    {
        public static bool moverule(Point end, Point start, double a, double b)
        {
            if (end.X >= 3 && end.X <= 5) return false;
            if (!(end.Y >= 2 && end.Y < 6)) return false;


            if ((Math.Abs(a) + Math.Abs(b)) == 1.0) return true;

            return false;
        }
        }
}
