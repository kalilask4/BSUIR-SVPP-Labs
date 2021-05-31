using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SVPP_Lab5

{
    class Shape
    {


        public int Widght { get; set; }
        public Brush Background { get; set; }
        public Brush Foreground { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public Shape()
        {
        }

        public Shape(int widght, Brush background, Brush foreground, double x, double y)
        {
            Widght = widght;
            Background = background;
            Foreground = foreground;
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"Widght = {Widght}, Background = {Background}, Foreground = {Foreground}, ({X};{Y})";
        }
    }
}
