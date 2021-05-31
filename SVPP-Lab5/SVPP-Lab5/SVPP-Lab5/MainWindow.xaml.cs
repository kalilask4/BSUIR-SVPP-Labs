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

namespace SVPP_Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        Shape shape = new Shape();

        public MainWindow()
        {
            InitializeComponent();
        }



        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowShape windowShape = new WindowShape();
            if (windowShape.ShowDialog() == true)
               //MessageBox.Show("OK"); //to check
               shape = windowShape.NewShape;
             
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            TextBlockCursorPosition.Text = e.GetPosition(Canvas).ToString();
        }
    }
}
