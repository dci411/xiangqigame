using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChineseCheese
{
    public class Piece
    {
        //public string name;
        public bool isChoosen = false;
        public bool isLive = true;
        public bool isHuman = true;
        public Point position;
        public Image image = null;



        //public Piece(Point position, bool isHuman)
        //{
        //    this.position = position;
        //    this.isHuman = isHuman;
        //}


        public void guuuu()
        {
            image.Opacity = 0.8;
        }
    }
}
