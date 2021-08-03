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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_lab10.BusinessLayer.Interfaces;
using WPF_lab10.BusinessLayer.Model;
using WPF_lab10.BusinessLayer.Services;

namespace lab10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<GroupViewModel> groups;
        IGroupService groupService;

        public MainWindow()
        {
            
            InitializeComponent();
            groupService = new GroupService("CoursesContext");
            groups = groupService.GetAll();
            cBoxGroup.DataContext = groups;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
