using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using WPF_Lab9.EFContext;


namespace WPF_Lab9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CoursesContext coursesContext;

        public MainWindow()
        {
            InitializeComponent();
            coursesContext = new CoursesContext();
            coursesContext.groups.Load();
            tempGrid.ItemsSource = coursesContext.groups.Local.ToBindingList();

        }
    }
}
