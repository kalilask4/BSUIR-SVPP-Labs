using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SVPP_Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ColorDialog StrokeColorDialog, BackgroundColorDialog;


        public MainWindow()
        {
            InitializeComponent();
        }


        private void BtnStrokeColor_Click(object sender, RoutedEventArgs e)
        {
            StrokeColorDialog = new ColorDialog();
            StrokeColorDialog.FullOpen = true;
            StrokeColorDialog.ShowDialog();

            var Line = StrokeColorDialog.Color;
            Color mediaColor = Color.FromRgb(Line.R, Line.G, Line.B);
            BtnStrokeColor.Background = new SolidColorBrush(mediaColor);
        }

        private void BtnBackgroundColor_Click(object sender, RoutedEventArgs e)
        {
            BackgroundColorDialog = new ColorDialog();
            BackgroundColorDialog.FullOpen = true;
            BackgroundColorDialog.ShowDialog();

            var Line = BackgroundColorDialog.Color;
            Color mediaColor = Color.FromRgb(Line.R, Line.G, Line.B);
            BtnBackgroundColor.Background = new SolidColorBrush(mediaColor);
        }

 

    }
}
