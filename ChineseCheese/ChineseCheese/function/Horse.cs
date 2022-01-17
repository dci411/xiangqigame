using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CNchess.function
{
    internal class Horse
    {
        public static bool moverule(Point end, Point start, double a, double b) { 

                        
                        if (!((Math.Abs(a) == 2 && Math.Abs(b) == 1) || (Math.Abs(a) == 1 && Math.Abs(b) == 2))) return false;


            if (Math.Abs(a) == 2){
                            if (Rule.IsPiece(a / Math.Abs(a) + start.X, start.Y) < 32)
                    return false;
            }
                        else if (Math.Abs(b) == 2)
                        {
                            if (Rule.IsPiece(start.X, b / Math.Abs(b) + start.Y) < 32)
                                return false;   
                        }

                        return true;
       }            
    }
}
