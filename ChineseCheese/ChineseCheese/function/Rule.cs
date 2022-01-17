
using CNchess.function;
using System;
using System.Windows;
using System.Windows.Controls;


namespace CNchess
{
    class Rule
    {
      
        public static bool IsOutside(Point point)
        {
            if ((point.X == 10) || (point.Y == 10)) return true;
            else return false;
        }
        
        
        public static int GetArrary(Point point)
        {
            int i;
            for (i = 0; i < 90; i++)
            {
                if (point == Other.logicAdr[i]) return i;
            }
            return 90;
        }
        
        public static int GetImage(Image image)
        {
            int i;
            for (i = 0; i < 32; i++)
            {
                if (Other.image[i] == image) return i;
            }
            return 32;
        }
        

        
        public static bool CanMove(int num, Point end, Point start)
        {
            double a, b;
            a = end.X - start.X; 
            b = end.Y - start.Y; 
            bool judge=false;
            int item=0;
            switch (num)
            {
                case 0: goto case 1;//将、帅
                case 1:
                    {
                        judge = General.moverule(end, start, a, b);
                        if(judge)return true;
                        else break;  

                    }

                case 2: goto case 5;//士
                case 3: goto case 5;
                case 4: goto case 5;
                case 5:
                    {

                        judge = Advisor.moverule(end, start, a, b);
                        if (judge) return true;
                        else break;
                    }

                case 6: goto case 9;//象
                case 7: goto case 9;
                case 8: goto case 9;
                case 9:
                    {

                        judge = Elephant.moverule(end, start, a, b);
                        if (judge) return true;
                        else break;

                    }

                case 10: //马
                case 11: 
                case 12: 
                case 13:
                    {
                        judge = Horse.moverule(end, start, a, b);
                        if (judge) return true;
                        else break;
                    }

                case 14: //车,炮
                case 15: 
                case 16: 
                case 17: 
                case 18: 
                case 19: 
                case 20: 
                case 21:
                    {
                        item = CannonAndCar.moverule(end, start, a, b);
                        if (item==1) return true;
                        else if(item==0) return false;
                        else break;
                    }

                case 22: //兵、卒
                case 23: 
                case 24: 
                case 25: 
                case 26: 
                case 27: 
                case 28: 
                case 29: 
                case 30: 
                case 31:
                    {
                        judge = Soldier.moverule(end, start, a, b, num);
                        if (judge) return true;
                        else break;
                    }
            }
            return false;
        }

        public static void IsMeet(bool turn)
        {
            
            if (Other.image[0].Margin.Left == Other.image[1].Margin.Left)
            {
                int i = 0;
                bool meet = false;
                
                Point a = Board.MarginToLogical(Other.image[1].Margin);
                Point b = Board.MarginToLogical(Other.image[0].Margin);
                
                for (b.X = b.X + 1; b != a; b.X++)
                {
                    if (IsPiece(b) < 32) i++;
                }
                if (i == 0) meet = true;   
                if (turn && meet) Event.Over(1);   
                else if (!turn && meet) Event.Over(0);
            }
        }

        public static bool IsRed(int num)
        {
            if (((num + 1) % 2) != 0) return false;
            return true;
        }

        public static int IsPiece(Point position)
        {
            int i;
            for (i = 0; i < 32; i++)
            {
                if (Other.image[i].IsEnabled != false)
                    if (position == Board.MarginToLogical(Other.image[i].Margin))
                        return i;
            }
            return 32;
        }
       
        public static int IsPiece(double pieceX, double pieceY)
        {
            int i;
            for (i = 0; i < 32; i++)
            {
                if ((pieceX == Board.MarginToLogical(Other.image[i].Margin).X)
                    && (pieceY == Board.MarginToLogical(Other.image[i].Margin).Y))
                    return i;
            }
            return 32;
        }
       
    }
}
