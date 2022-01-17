
using System.Windows;
using System.Windows.Controls;


namespace CNchess
{
    public static class Other
    {
        static Other()
        {
            int i, j;
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    arrPoints[i * 9 + j].X = i;
                    arrPoints[i * 9 + j].Y = j;
                }

            }
        }
        private static Point[] arrPoints = new Point[90];
        public static Point[] logicAdr
        {
            get { return arrPoints; }
        }

        private static Image[] arrImages = new Image[32];
        public static Image[] image
        {
            set { arrImages = value; }
            get { return arrImages; }
        }
    }
}
