using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CNchess.function
{
    internal class Decide
    {
        public static  General general = new General();

        public static Advisor advisor = new Advisor();  

        public static Elephant elephant = new Elephant();

        public static Horse horse = new Horse();

        public static Soldier soldier = new Soldier();
        //Judge whether the chess piece can move
        public static bool CanMove(int num, Point end, Point start, bool tips)
        {
            double a, b;
            a = end.X - start.X;
            b = end.Y - start.Y;
            bool judge = false;
            int item = 0;
            switch (num)
            {
                case 0: //将、帅/General
                case 1:
                    {
                        judge = general.moverule(end, start, a, b);
                        if (judge) return true;
                        else
                        {
                            if (tips)
                            {
                                System.Windows.MessageBox.Show("It is only allowed to walk in the nine palace grid ！");
                                System.Windows.MessageBox.Show("It's only along a straight line");
                            }
                            break; 
                        }

                    }

                case 2: //士/Advisor
                case 3:
                case 4:
                case 5:
                    {

                        judge = advisor.moverule(end, start, a, b);
                        if (judge) return true;
                        else
                        {
                            if (tips)
                            {
                                System.Windows.MessageBox.Show("It is only allowed to walk in the nine palace grid ！");
                                System.Windows.MessageBox.Show("It is only allowed to walk along the slash！");
                            }
                            break;
                        }
                    }

                case 6: //象/Elephant
                case 7:
                case 8:
                case 9:
                    {

                        judge = elephant.moverule(end, start, a, b);
                        if (judge) return true;
                        else
                        {
                            if (tips)
                            {
                                System.Windows.MessageBox.Show("Only the word 田 is allowed！");
                                
                            }
                            break;
                        }

                    }

                case 10: //马/Horse
                case 11:
                case 12:
                case 13:
                    {
                        judge = horse.moverule(end, start, a, b);
                        if (judge) return true;
                        else
                        {
                            if (tips)
                            {
                                System.Windows.MessageBox.Show("Only the word 日 is allowed！");
                                
                            }
                            break;
                        }
                    }

                case 14: //车/Car
                case 15:
                case 16:
                case 17:
                    {
                        item = Car.Item_moverule(end, start, a, b);
                        if (item == 1) return true;
                        else if (item == 0) return false;
                        else
                        {
                            if (tips)
                            {
                                System.Windows.MessageBox.Show("Only straight lines are allowed！");
                            }
                            break;
                        }
                    }
                case 18://炮/cannon
                case 19:
                case 20:
                case 21:
                    {
                        item = Car.Item_moverule(end, start, a, b);
                        if (item == 1) return true;
                        else if (item == 0) return false;
                        else
                        {
                            if (tips)
                            {
                                System.Windows.MessageBox.Show("Only straight lines are allowed！");
                                
                            }
                            break;
                        }
                    }

                case 22: //兵、卒/Soldier
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
                        judge = soldier.moverule(end, start, a, b, num);
                        if (judge) return true;
                        else
                        {
                            if (tips)
                            {
                                System.Windows.MessageBox.Show("Before crossing the river！");
                                System.Windows.MessageBox.Show("you can only move forward. After crossing the river！");
                                System.Windows.MessageBox.Show("not backward！");
                            }
                            break;
                        }
                    }
            }
            return false;
        }
    }
}
