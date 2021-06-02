using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Microsoft.Win32;

namespace SVPP_Lab5

{
    [Serializable]
    public class Shape
    {
        [NonSerialized]
        private SolidColorBrush background;
        [NonSerialized]
        private SolidColorBrush foreground;

        byte[] color_background = new byte[3];
        byte[] color_foreground = new byte[3];

        public int Width { get; set; }
        public SolidColorBrush Background { get => background; set => background = value; }
        public SolidColorBrush Foreground { get => foreground; set => foreground = value; }
        public double X { get; set; }
        public double Y { get; set; }

        public Shape()
        {
        }

        private void PackColor()
        {
            color_background[0] = background.Color.R;
            color_background[1] = background.Color.G;
            color_background[2] = background.Color.B;

            color_foreground[0] = background.Color.R;
            color_foreground[1] = background.Color.G;
            color_foreground[2] = background.Color.B;

        }

        private void UnpackColor()
        {
            background = new SolidColorBrush(Color.FromRgb(color_background[0], color_background[1], color_background[2]));
            foreground = new SolidColorBrush(Color.FromRgb(color_foreground[0], color_foreground[1], color_foreground[2]));
        }


        public void SaveToFile()
        {
            PackColor();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Files (dat)|*.dat|All files|*.*";
            if (saveFileDialog.ShowDialog() != true) return;
            FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }


        public static Shape LoadFromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Files (dat)|*.dat|All files|*.*";
            if (openFileDialog.ShowDialog() != true) return null;
            FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Shape shape = (Shape)bf.Deserialize(fs);
            shape.UnpackColor();
            fs.Close();
            return shape;
        }


        public Shape(int width, SolidColorBrush background, SolidColorBrush foreground, double x, double y)
        {
            Width = width;
            Background = background;
            Foreground = foreground;
            X = x;
            Y = y;
        }


        public Shape(SolidColorBrush background, SolidColorBrush foreground)
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
