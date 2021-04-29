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

namespace SVPP_Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            Double x, y, z, result;
            Double.TryParse(XValue.Text, out x);
            Double.TryParse(YValue.Text, out y);
            Double.TryParse(ZValue.Text, out z);

            result = (Math.Pow((Math.Abs(Math.Cos(x) - Math.Cos(y))), (1 + (2 * (Math.Pow(Math.Sin(y), 2.0))))) * (1 + z + (Math.Pow(z, 2.0)) / 2 + (Math.Pow(z, 3.0)) / 3 + (Math.Pow(z, 4.0)) / 4));

            tbResult.Text = $"Result  {result}";


        }
    }
}
