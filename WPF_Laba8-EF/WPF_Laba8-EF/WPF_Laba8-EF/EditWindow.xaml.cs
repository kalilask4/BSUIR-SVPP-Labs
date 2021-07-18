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
using WPF_Laba8_EF.Models;


namespace WPF_Laba8_EF
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {

        Student student;
        
        public EditWindow(Student student)
        {

            InitializeComponent();
            this.student = student;
            grid.DataContext = student;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
