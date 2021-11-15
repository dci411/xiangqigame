using System;
namespace xq1
{
    class play
    {
        chess c = new chess();
        int[,] a = null;
        board board = new board();
        decide d = new decide();

        public play()
        {
            a = board.InitializeMap();
            board.displayMap(a);
            GO(a);
        }
        public void GO(int[,] now)
        {
            string X1, Y1, X2, Y2;
            int a1, b1, a2, b2;
            int moveSuccess, moveSuccess1, moveSuccess2;
            int player = 1;//red=1 black=0
            int over = 0;
            bool flag = true;

            while (over == 0)
            {
                if (player == 1)
                {
                    Console.Write("Red Turn");
                }
                else if (player == 0)
                {
                    Console.Write("Black Turn");
                }
                Console.WriteLine("");
                Console.WriteLine("Please enter the position of the piece you want to move");
                Console.Write("X1:");
                X1 = Console.ReadLine();
                a1 = Convert.ToInt32(X1);
                Console.Write("Y1:");
                Y1 = Console.ReadLine();
                b1 = Convert.ToInt32(Y1);
                Console.WriteLine("Please enter the location you want to move to");
                Console.Write("X2:");
                X2 = Console.ReadLine();
                a2 = Convert.ToInt32(X2);
                Console.Write("Y2:");
                Y2 = Console.ReadLine();
                b2 = Convert.ToInt32(Y2);

                moveSuccess1 = c.moveRule(a1, b1, a2, b2, player, now);
                moveSuccess2 = d.Piecemoveflag(a1, b1, a2, b2, player, now);
                moveSuccess = moveSuccess1 + moveSuccess2;

                if (moveSuccess == 2)
                {
                    flag = true;
                    c.MovePiece(a1, b1, a2, b2, now);
                    board.displayMap(now);
                }
                else if (moveSuccess == 1 || moveSuccess == 0)
                {
                    flag = false;
                }
                if (flag == true)
                {
                    if (player == 1)
                    {
                        player--;
                    }
                    else if (player == 0)
                    {
                        player++;
                    }
                    over = d.isOver(now);

                    if (over == -1)
                    {
                        Console.WriteLine("Black win");
                    }
                    else if (over == 1)
                    {
                        Console.WriteLine("Red win");
                    }
                }
                else if (flag == false)
                {
                    Console.Write("Your action is invalid, please re-enter\n\n");
                }
            }
        }
    }
}
