using System;
namespace xq1
{
    class board
    {
        public board()
        {

        }
        //红方棋子 
        // red map[i,j]>0&&map[i,j]<10
        public const int ju = 1;
        public const int ma = 2;
        public const int xiang = 3;
        public const int shi = 4;
        public const int shuai = 5;
        public const int pao = 6;
        public const int bing = 7;
        //黑方棋子
        //black map[i,j]>10
        public const int Ju = 11;
        public const int Ma = 12;
        public const int Xiang = 13;
        public const int Shi = 14;
        public const int Jiang = 15;
        public const int Pao = 16;
        public const int Zu = 17;

        public int[,] InitializeMap()
        {

            int[,] map = new int[10, 9];
            int i, j;
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    map[i, j] = 0;
                }
            }
            //黑方子力配置
            map[0, 0] = Ju;
            map[0, 1] = Ma;
            map[0, 2] = Xiang;
            map[0, 3] = Shi;
            map[0, 4] = Jiang;
            map[0, 5] = Shi;
            map[0, 6] = Xiang;
            map[0, 7] = Ma;
            map[0, 8] = Ju;
            map[2, 1] = Pao;
            map[2, 7] = Pao;
            map[3, 0] = Zu;
            map[3, 2] = Zu;
            map[3, 4] = Zu;
            map[3, 6] = Zu;
            map[3, 8] = Zu;
            //红方子力配置
            map[6, 0] = bing;
            map[6, 2] = bing;
            map[6, 4] = bing;
            map[6, 6] = bing;
            map[6, 8] = bing;
            map[7, 1] = pao;
            map[7, 7] = pao;
            map[9, 0] = ju;
            map[9, 1] = ma;
            map[9, 2] = xiang;
            map[9, 3] = shi;
            map[9, 4] = shuai;
            map[9, 5] = shi;
            map[9, 6] = xiang;
            map[9, 7] = ma;
            map[9, 8] = ju;

            return map;
        }

        public void displayMap(int[,] map)
        {
            int i, j, k;
            Console.Write(" ");
            for (k = 0; k < 9; k++)
            {
                Console.Write(" " + k);
            }
            Console.Write("\n");
            for (i = 0; i < 10; i++)
            {
                Console.Write(i + " ");
                for (j = 0; j < 9; j++)
                {
                    if (map[i, j] == 0)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        switch (map[i, j])
                        {
                            case ju:
                                Console.Write("車");
                                break;
                            case Ju:
                                Console.Write("车");
                                break;
                            case ma:
                                Console.Write("馬");
                                break;
                            case Ma:
                                Console.Write("马");
                                break;
                            case xiang:
                                Console.Write("相");
                                break;
                            case Xiang:
                                Console.Write("象");
                                break;
                            case shi:
                                Console.Write("仕");
                                break;
                            case Shi:
                                Console.Write("士");
                                break;
                            case shuai:
                                Console.Write("帥");
                                break;
                            case Jiang:
                                Console.Write("將");
                                break;
                            case pao:
                                Console.Write("炮");
                                break;
                            case Pao:
                                Console.Write("砲");
                                break;
                            case bing:
                                Console.Write("兵");
                                break;
                            case Zu:
                                Console.Write("卒");
                                break;
                        }
                    }
                }
                Console.Write("\n");
            }
            Console.Write("\n\n");
        }
    }
}

