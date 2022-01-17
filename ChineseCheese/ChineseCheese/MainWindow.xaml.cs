using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace CNchess
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public const int B_General = 0;
        public const int R_GENRAL = 1;
        public const int B_Advisor_1 = 2;
        public const int R_Advisor_1 = 3;
        public const int B_Advisor_2 = 4;
        public const int R_Advisor_2 = 5;
        public const int B_Elephant_1 = 6;
        public const int R_Elephant_1 = 7;
        public const int B_Elephant_2 = 8;
        public const int R_Elephant_2 = 9;
        public const int B_Horse_1 = 10;
        public const int R_Horse_1 = 11;
        public const int B_Horse_2 = 12;
        public const int R_Horse_2 = 13;
        public const int B_Chariot_1 = 14;
        public const int R_Chariot_1 = 15;
        public const int B_Chariot_2 = 16;
        public const int R_Chariot_2 = 17;
        public const int B_Cannon_1 = 18;
        public const int R_Cannon_1 = 19;
        public const int B_Cannon_2 = 20;
        public const int R_Cannon_2 = 21;
        public const int B_Soldier_1 = 22;
        public const int R_Soldier_1 = 23;
        public const int B_Soldier_2 = 24;
        public const int R_Soldier_2 = 25;
        public const int B_Soldier_3 = 26;
        public const int R_Soldier_3 = 27;
        public const int B_Soldier_4 = 28;
        public const int R_Soldier_4 = 29;
        public const int B_Soldier_5 = 30;
        public const int R_Soldier_5 = 31;

        public const bool BLACK = false;
        public const bool RED = true;

        bool choose = false;
        bool turn = RED;
        Image lastpiece = null;//上次选中的棋子

        public MainWindow()
        {
            InitializeComponent();

            MessageBox.Show("Red chess first");

            
            Other.image[B_General] = black_general;
            Other.image[R_GENRAL] = red_general;
            Other.image[B_Advisor_1] = black_advisor1;
            Other.image[B_Advisor_2] = black_advisor2;
            Other.image[R_Advisor_1] = red_advisor1;
            Other.image[R_Advisor_2] = red_advisor2;
            Other.image[B_Elephant_1] = black_elephant1;
            Other.image[B_Elephant_2] = black_elephant2;
            Other.image[R_Elephant_1] = red_elephant1;
            Other.image[R_Elephant_2] = red_elephant2;
            Other.image[B_Horse_1] = black_horse1;
            Other.image[B_Horse_2] = black_horse2;
            Other.image[R_Horse_1] = red_horse1;
            Other.image[R_Horse_2] = red_horse2;
            Other.image[B_Chariot_1] = black_chariot1;
            Other.image[B_Chariot_2] = black_chariot2;
            Other.image[R_Chariot_1] = red_chariot1;
            Other.image[R_Chariot_2] = red_chariot2;
            Other.image[B_Cannon_1] = black_cannon1;
            Other.image[B_Cannon_2] = black_cannon2;
            Other.image[R_Cannon_1] = red_cannon1;
            Other.image[R_Cannon_2] = red_cannon2;
            Other.image[B_Soldier_1] = black_soldier1;
            Other.image[B_Soldier_2] = black_soldier2;
            Other.image[B_Soldier_3] = black_soldier3;
            Other.image[B_Soldier_4] = black_soldier4;
            Other.image[B_Soldier_5] = black_soldier5;
            Other.image[R_Soldier_1] = red_soldier1;
            Other.image[R_Soldier_2] = red_soldier2;
            Other.image[R_Soldier_3] = red_soldier3;
            Other.image[R_Soldier_4] = red_soldier4;
            Other.image[R_Soldier_5] = red_soldier5;
            

        }

        
        private void choosePiece(object sender, MouseButtonEventArgs e)
        {
            
            Image currentPiece = sender as Image;//当前选中棋子

           
            bool PieceIsRed = Rule.IsRed(Rule.GetImage(currentPiece));

            if (lastpiece != null)
            {
                
                bool lastPieceIsRed = Rule.IsRed(Rule.GetImage(lastpiece));

                if (turn == PieceIsRed)  
                {
                    lastpiece.Opacity = 1;      
                    lastpiece = currentPiece;    
                    currentPiece.Opacity = 0.5;  
                    choose = true;
                    return;
                }
               
                else if ((turn == lastPieceIsRed) && (turn != PieceIsRed))
                {
                    
                    if (Event.Eat(lastpiece, currentPiece))
                    {
                        turn = Event.Switch(turn);    
                       
                        lastpiece = null;               
                        choose = false;                
                        return;
                    }
                    else  return;
                }
            }
       
            else if (lastpiece == null)
            {
                
                if (turn == PieceIsRed)
                {
                    currentPiece.Opacity = 0.5;      
                    choose = true;                 
                    lastpiece = currentPiece;        
                    return;
                }
                else if (turn != PieceIsRed)
                {
                    choose = false;
                    return;
                }
            }

        }

       
        private void movePiece(object sender, MouseButtonEventArgs e)
        {
            if (!choose || lastpiece == null) return;      
            if (choose && !Rule.IsOutside(Board.PixelToLogical(e.GetPosition(this))))
            {
              
                Point end = Board.PixelToLogical(e.GetPosition(this));
                Point start = Board.MarginToLogical(lastpiece.Margin);
              
                if (Rule.CanMove(Rule.GetImage(lastpiece), end, start))
                {
                    Event.Move(lastpiece, end);    
                    turn = Event.Switch(turn);             


                    choose = false;                        
                }
            }
        }
    }
}
