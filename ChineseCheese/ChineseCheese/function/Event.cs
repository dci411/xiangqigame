
using CNchess.function;
using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;

namespace CNchess
{
    class Event
    {
        public static SoundPlayer sound = new SoundPlayer();
        public static bool Move(Image image, Point position)
        {
            if (image == null || Rule.IsOutside(position))//Ensure that the image is not null
            {
                return false;
            }
            image.Margin = Board.LogicalToMargin(position);//Move control(Piece)
            image.Opacity = 1;//Transparency recovery
            return true;
        }

        public static bool Eat(Image start, Image end, bool tips)
        {
            int start_Piece_Num = Board.GetImage(start);
            Point start_P = Board.MarginToLogical(start.Margin);
            Point end_P = Board.MarginToLogical(end.Margin);


            if (start_Piece_Num <= 17 || start_Piece_Num >= 22)
            {
                if (Decide.CanMove(start_Piece_Num, end_P, start_P,tips))
                {
                    Move(start, end_P);//Move the attacking piece to the position of the attacked piece
                    Die(end);//Kill the attacked chess piece
                    return true;
                }
                else
                {
                    if (tips)
                    {
                        System.Windows.MessageBox.Show("Don't attack your chess pieces！");
                        
                    }
                    
                }
            }

            //Attack judgment of artillery
            if (start_Piece_Num >= 18 && start_Piece_Num <= 21)
            {
               bool successful= Cannon.Attack(end_P, start_P);
                    

                if (successful)
                {
                   Move(start, end_P);
                    Die(end);
                    return true;
                }
                else return false;
            }
            else
            {
                if (tips)
                {
                    System.Windows.MessageBox.Show("Don't attack your chess pieces！");

                }
                 return false;
            }
            
        }

        public static void Movesound()
        {
            sound.SoundLocation = "Sounds/move.wav";
            sound.Play();
        }
        public static void Clicksound()
        {
            sound.SoundLocation = "Sounds/click.wav";
            sound.Play();
        }
        public static void Die(Image image)
        {//Make the death chess piece uncontrollable and cannot be displayed
            image.Visibility = (Visibility)2;
            image.IsEnabled = false;
        }

        public static bool ChangeTurn(bool turn)
        {
            if (Other.image[0].IsEnabled == false) Over(0);//Black will die, red will win
            else if (Other.image[1].IsEnabled == false) Over(1);//Red will die, black will win
            Rule.IsMeet(turn);//The general is meet?
            return !turn;//Change turn
        }

        public static void Over(int diedGeneral)//Achieve victory conditions
        {
            string winner = null;
            if (diedGeneral == 0) winner = "Red";
            else if (diedGeneral == 1) winner = "Black";
            System.Windows.MessageBox.Show(winner + " is winner！");
            System.Windows.Application.Current.Shutdown();
        }
    }
}
