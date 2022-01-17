
using System;
using System.Windows;
using System.Windows.Controls;

namespace CNchess
{
    class Event
    {
        public static bool Move(Image image, Point position)
        {
            if (image == null || Rule.IsOutside(position))     
            {
                return false;
            }
            image.Margin = Board.LogicalToMargin(position);     
            image.Opacity = 1;                                  
            return true;
        }

        public static bool Eat(Image start, Image end)     
        {
            int startNum = Rule.GetImage(start);
            Point startPosition = Board.MarginToLogical(start.Margin);
            Point endPosition = Board.MarginToLogical(end.Margin);

            
            if (startNum <= 17 || startNum >= 22)
            {
                if (Rule.CanMove(startNum, endPosition, startPosition))
                {
                    Move(start, endPosition);     
                    Die(end);                      
                    return true;
                }
            }

            
            if (startNum >= 18 && startNum <= 21)
            {
                int count = 0;                             
                double degree = 0;                             

                int src = Rule.GetArrary(startPosition);  
                int des = Rule.GetArrary(endPosition);
                double a = endPosition.X - startPosition.X;
                double b = endPosition.Y - startPosition.Y;

                
                if (!(a == 0 || b == 0)) return false;

                
                if (a == 0) degree = (b / Math.Abs(b));         
                else if (b == 0) degree = 9 * (a / Math.Abs(a));

                
                for (src += (int)degree; src != des; src += (int)degree)
                {
                    
                    if (Rule.IsPiece(Other.logicAdr[src]) < 32) count++;
                }

                
                if (count == 1)
                {
                    Move(start, endPosition);                 
                    Die(end);                                 
                    return true;
                }
                else return false;
            }
            return false;
        }

        public static void Die(Image image)
        {   
            image.Visibility = (Visibility)2;
            image.IsEnabled = false;
        }

        public static bool Switch(bool turn)
        {
            if (Other.image[0].IsEnabled == false) Over(0);      
            else if (Other.image[1].IsEnabled == false) Over(1); 
            Rule.IsMeet(turn);                                      
            return !turn;
        }

        public static void Over(int diedGeneral)
        {
            string winner = null;
            if (diedGeneral == 0) winner = "Red";
            else if (diedGeneral == 1) winner = "Black";
            System.Windows.MessageBox.Show(winner + " is winner！");
            System.Windows.Application.Current.Shutdown();
        }
    }
}
