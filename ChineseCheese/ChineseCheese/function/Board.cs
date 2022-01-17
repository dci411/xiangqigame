
using System;
using System.Windows;
using System.Windows.Controls;

namespace CNchess
{
     class Board
    {

        public static Point PixelToLogical(Point pixel)
        {
            Point Logical = new Point(10, 9);
            if (pixel.X >= 50 && pixel.X <= 100) Logical.Y = 0;
            if (pixel.X >= 110 && pixel.X <= 160) Logical.Y = 1;
            if (pixel.X >= 170 && pixel.X <= 220) Logical.Y = 2;
            if (pixel.X >= 230 && pixel.X <= 280) Logical.Y = 3;
            if (pixel.X >= 290 && pixel.X <= 340) Logical.Y = 4;
            if (pixel.X >= 350 && pixel.X <= 400) Logical.Y = 5;
            if (pixel.X >= 410 && pixel.X <= 460) Logical.Y = 6;
            if (pixel.X >= 470 && pixel.X <= 520) Logical.Y = 7;
            if (pixel.X >= 530 && pixel.X <= 580) Logical.Y = 8;

            if (pixel.Y >= 21 && pixel.Y <= 71) Logical.X = 0;
            if (pixel.Y >= 77 && pixel.Y <= 127) Logical.X = 1;
            if (pixel.Y >= 133 && pixel.Y <= 183) Logical.X = 2;
            if (pixel.Y >= 189 && pixel.Y <= 239) Logical.X = 3;
            if (pixel.Y >= 245 && pixel.Y <= 295) Logical.X = 4;
            if (pixel.Y >= 310 && pixel.Y <= 360) Logical.X = 5;
            if (pixel.Y >= 367 && pixel.Y <= 417) Logical.X = 6;
            if (pixel.Y >= 424 && pixel.Y <= 474) Logical.X = 7;
            if (pixel.Y >= 481 && pixel.Y <= 531) Logical.X = 8;
            if (pixel.Y >= 538 && pixel.Y <= 588) Logical.X = 9;
            return Logical;
        }

        public static Point MarginToLogical(Thickness margin)
        {
            Point Logical = new Point(10, 9);
            if (margin.Bottom <= 228) Logical.X = 9 - margin.Bottom / 57;
            if (margin.Bottom >= 288) Logical.X = 4 - (margin.Bottom - 288) / 57;
            if (margin.Left <= 476) Logical.Y = margin.Left / 59.5;
            return Logical;
        }

        public static Thickness LogicalToMargin(Point Logical)
        {
            Thickness margin = new Thickness(2);
            margin.Left = 0;
            margin.Top = 0;
            margin.Right = 0;
            margin.Bottom = 0;
            if (Logical.X >= 5 && Logical.X <= 9) margin.Bottom = (9 - Logical.X) * 57;
            if (Logical.X >= 0 && Logical.X <= 4) margin.Bottom = 288 + (4 - Logical.X) * 57;
            if (Logical.Y <= 8) margin.Left = 59.5 * Logical.Y;
            return margin;
        }

    }
}
