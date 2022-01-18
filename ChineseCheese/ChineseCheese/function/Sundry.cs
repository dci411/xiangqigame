
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
                    //Enter coordinate information
                       arrPoints[i * 9 + j].X = i;
                    arrPoints[i * 9 + j].Y = j;
                }

            }
        }

        private static Point[] arrPoints = new Point[90];
        public static Point[] logicAdr
        {//Transfer logicAdr information
            get { return arrPoints; }
        }

        private static Image[] arrImages = new Image[32];
        public static Image[] image
        {
            //Store and pass the image message
            set { arrImages = value; }
            get { return arrImages; }
        }
    }

    public enum Chesstype
    {

        //Set chess piece type information
        //Red is even , black is odd
        B_General,
        R_GENRAl,
        B_Advisor_1,
        R_Advisor_1,
        B_Advisor_2,
        R_Advisor_2,
        B_Elephant_1,
        R_Elephant_1,
        B_Elephant_2,
        R_Elephant_2,
        B_Horse_1,
        R_Horse_1,
        B_Horse_2,
        R_Horse_2,
        B_Chariot_1,
        R_Chariot_1,
        B_Chariot_2,
        R_Chariot_2,
        B_Cannon_1,
        R_Cannon_1,
        B_Cannon_2,
        R_Cannon_2,
        B_Soldier_1,
        R_Soldier_1,
        B_Soldier_2,
        R_Soldier_2,
        B_Soldier_3,
        R_Soldier_3,
        B_Soldier_4,
        R_Soldier_4,
        B_Soldier_5,
        R_Soldier_5,
    }
}
