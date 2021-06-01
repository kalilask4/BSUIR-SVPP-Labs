using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SVPP_Lab5

{
    public class Shape
    {
        public int Width { get; set; }
        public Brush Background { get; set; }
        public Brush Foreground { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public Shape()
        {
        }

 

        public Shape(int width, Brush background, Brush foreground, double x, double y)
        {
            Width = width;
            Background = background;
            Foreground = foreground;
            X = x;
            Y = y;
        }

        public Shape(Brush background, Brush foreground)
        {
            Background = background;
            Foreground = foreground;
        }

        public override string ToString()
        {
            return $"Widght = {Width}, Background = {Background}, Foreground = {Foreground}, ({X};{Y})";
        }
    }
}
