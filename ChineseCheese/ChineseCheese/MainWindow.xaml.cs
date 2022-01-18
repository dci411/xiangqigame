using CNchess.function;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CNchess
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {


        
       

        Color r = Color.FromRgb(255, 0, 0);//Red
        Color b = Color.FromRgb(0, 0, 0);//Black
        Color w = Color.FromRgb(255, 255, 255);//White

        bool choose = false;
        bool tips = false;  
        bool turn = true; //BLACK is false, RED is true
        Image lastpiece = null;//上次选中的棋子

        public MainWindow()
        {
            InitializeComponent();

            MessageBox.Show("Red chess first");

            //Put all kinds of pieces into an array for centralized lookups
            //Red is even , black is odd
            Other.image[(int)Chesstype.B_General] = black_general;
            Other.image[(int)Chesstype.R_GENRAl] = red_general;
            Other.image[(int)Chesstype.B_Advisor_1] = black_advisor1;
            Other.image[(int)Chesstype.B_Advisor_2] = black_advisor2;
            Other.image[(int)Chesstype.R_Advisor_1] = red_advisor1;
            Other.image[(int)Chesstype.R_Advisor_2] = red_advisor2;
            Other.image[(int)Chesstype.B_Elephant_1] = black_elephant1;
            Other.image[(int)Chesstype.B_Elephant_2] = black_elephant2;
            Other.image[(int)Chesstype.R_Elephant_1] = red_elephant1;
            Other.image[(int)Chesstype.R_Elephant_2] = red_elephant2;
            Other.image[(int)Chesstype.B_Horse_1] = black_horse1;
            Other.image[(int)Chesstype.B_Horse_2] = black_horse2;
            Other.image[(int)Chesstype.R_Horse_1] = red_horse1;
            Other.image[(int)Chesstype.R_Horse_2] = red_horse2;
            Other.image[(int)Chesstype.B_Chariot_1] = black_chariot1;
            Other.image[(int)Chesstype.B_Chariot_2] = black_chariot2;
            Other.image[(int)Chesstype.R_Chariot_1] = red_chariot1;
            Other.image[(int)Chesstype.R_Chariot_2] = red_chariot2;
            Other.image[(int)Chesstype.B_Cannon_1] = black_cannon1;
            Other.image[(int)Chesstype.B_Cannon_2] = black_cannon2;
            Other.image[(int)Chesstype.R_Cannon_1] = red_cannon1;
            Other.image[(int)Chesstype.R_Cannon_2] = red_cannon2;
            Other.image[(int)Chesstype.B_Soldier_1] = black_soldier1;
            Other.image[(int)Chesstype.B_Soldier_2] = black_soldier2;
            Other.image[(int)Chesstype.B_Soldier_3] = black_soldier3;
            Other.image[(int)Chesstype.B_Soldier_4] = black_soldier4;
            Other.image[(int)Chesstype.B_Soldier_5] = black_soldier5;
            Other.image[(int)Chesstype.R_Soldier_1] = red_soldier1;
            Other.image[(int)Chesstype.R_Soldier_2] = red_soldier2;
            Other.image[(int)Chesstype.R_Soldier_3] = red_soldier3;
            Other.image[(int)Chesstype.R_Soldier_4] = red_soldier4;
            Other.image[(int)Chesstype.R_Soldier_5] = red_soldier5;


        }

        //The program executed when a piece is clicked by the mouse(the piece is selected, or attacked)
        private void choosePiece(object sender, MouseButtonEventArgs e)
        {

            Image currentPiece = sender as Image;//Currently selected piece


            bool PieceIsRed = Rule.IsRed(Board.GetImage(currentPiece));//Determines the faction of the currently selected piece

            if (lastpiece != null)//The last selected piece is not empty
            {

                bool lastPieceIsRed = Rule.IsRed(Board.GetImage(lastpiece));//Determines the faction of the last selected piece

                if (turn == PieceIsRed)//The pieces are the same as the faction of the current turn
                {
                    lastpiece.Opacity = 1;// Restore the opacity of the last selected piece
                    lastpiece = currentPiece;// Make the selected piece "previous selected piece"
                                               // This "previous" is for the next choosePiece method
                    currentPiece.Opacity = 0.5;// Restore the opacity of the last selected piece
                    choose = true;// Have pieces are selected
                    return;
                }

                else if ((turn == lastPieceIsRed) && (turn != PieceIsRed))
                //The pieces are the same as the faction from the previous turn, but different from the current one
                //That's the attack
                {

                    if (Event.Eat(lastpiece, currentPiece,tips))
                    {
                        Event.Movesound();//Movesounds
                        turn = Event.ChangeTurn(turn);//Change turn
                        //Change background color
                        if (turn)
                        {
                            boardWindow.color1.Color = r;
                            boardWindow.color1.Offset = 1.0;
                            boardWindow.color2.Color = w;
                            boardWindow.color2.Offset = 0.6;
                        }
                        else if (!turn)
                        {
                            boardWindow.color1.Color = b;
                            boardWindow.color1.Offset = 0.6;
                            boardWindow.color2.Color = w;
                            boardWindow.color2.Offset = 1.0;
                        }
                        lastpiece = null;// make the previous selected piece empty
                        choose = false;// No pieces are selected
                        return;
                    }
                    else return;
                }
            }

            else if (lastpiece == null)// When the previous piece is empty
            {
                
                if (turn == PieceIsRed)// Select your piece
                {
                    currentPiece.Opacity = 0.5;
                    choose = true;
                    lastpiece = currentPiece;
                    return;
                }
                // Check the enemy piece, nothing happens
                else if (turn != PieceIsRed)
                {
                    choose = false;
                    return;
                }
            }

        }

        // The event that executes when the board is clicked (moves the selected piece to the specified position)
        private void movePiece(object sender, MouseButtonEventArgs e)
        {
            if (!choose || lastpiece == null) return;//When no piece is selected or the previous piece is empty, nothing is done
            if (choose && !Rule.IsOutside(Board.PixelToLogical(e.GetPosition(this))))
            //When a piece has been selected before and the mouse does not click on a point other than the intersection of the pieces:
            {  //Get coordinate information
                Point end = Board.PixelToLogical(e.GetPosition(this));
                Point start = Board.MarginToLogical(lastpiece.Margin);

                if (Decide.CanMove(Board.GetImage(lastpiece), end, start,tips))
                {
                    Event.Move(lastpiece, end);//Move
                    Event.Movesound();//Movesounds
                    turn = Event.ChangeTurn(turn);//Change turn
                    //Change background color
                    if (turn)
                    {
                        boardWindow.color1.Color = r;
                        boardWindow.color1.Offset = 1.0;
                        boardWindow.color2.Color = w;
                        boardWindow.color2.Offset = 0.6;
                    }
                    else if (!turn)
                    {
                        boardWindow.color1.Color = b;
                        boardWindow.color1.Offset = 0.6;
                        boardWindow.color2.Color = w;
                        boardWindow.color2.Offset = 1;
                    }

                    choose = false;// No pieces are selected
                }
            }
        }


        private void Tips_Click(object sender, RoutedEventArgs e)
        {
            if (tips)tips = false;
            else tips = true;
        }
    }
}
