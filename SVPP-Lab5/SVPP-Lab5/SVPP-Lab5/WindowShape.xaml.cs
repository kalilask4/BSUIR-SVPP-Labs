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
using System.Windows.Shapes;

namespace SVPP_Lab5
{
    /// <summary>
    /// Interaction logic for WindowShape.xaml
    /// </summary>
    public partial class WindowShape : Window
    {

        List<string> colors = new List<string> { "Red", "Green", "Blue" };

        public WindowShape()
        {
            InitializeComponent();
            comboBoxFore.ItemsSource = colors;
            comboBoxBack.ItemsSource = colors;

   


        }
    }
}
