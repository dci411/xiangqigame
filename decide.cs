using System;
namespace xq1
{
    class decide
    {
        public Car Juju = new Car();
        public Adviser Shishi = new Adviser();
        public Cannon Paopao = new Cannon();
        public Elephant Xiangxiang = new Elephant();
        public King Jiangshuai = new King();
        public Pawn Zubing = new Pawn();
        public Horse Mama = new Horse();

        public decide()
        {

        }
        public int isOver(int[,] k)
        {
            int i, j;
            int haveShuai = 0, haveJiang = 0;
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    if (k[i, j] == 5)//shuai == 5 in borad
                    {
                        haveShuai = 1;
                    }
                    else if (k[i, j] == 15)//Jiang == 15 inborad
                    {
                        haveJiang = 1;
                    }
                }
            }
            if (haveShuai == 0)
            {
                return -1;
            }
            else if (haveJiang == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int Piecemoveflag(int q, int w, int e, int r, int p, int[,] b)
        {
            int piece = b[q, w];
            switch (piece)
            {
                case 1:
                case 11:
                    return Juju.moveRule(q, w, e, r, p, b);

                case 2:
                case 12:
                    return Mama.moveRule(q, w, e, r, p, b);

                case 3:
                case 13:
                    return Xiangxiang.moveRule(q, w, e, r, p, b);

                case 4:
                case 14:
                    return Shishi.moveRule(q, w, e, r, p, b);

                case 5:
                case 15:
                    return Jiangshuai.moveRule(q, w, e, r, p, b);

                case 6:
                case 16:
                    return Paopao.moveRule(q, w, e, r, p, b);

                case 7:
                case 17:
                    return Zubing.moveRule(q, w, e, r, p, b);


            }
            return 1;
        }
    }
}
