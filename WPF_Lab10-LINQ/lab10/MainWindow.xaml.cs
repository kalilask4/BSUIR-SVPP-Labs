using lab10.Dialogs;
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
            groupService = new GroupService("db10");
            groups = groupService.GetAll();
            cBoxGroup.DataContext = groups;
           
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            var studentViewModel = new StudentViewModel();
            studentViewModel.DateOfBirth = new DateTime(1990, 01, 01);
            var dialog = new EditStudent(studentViewModel);
            var result = dialog.ShowDialog();
            if (result == true)
            {
                var group = (GroupViewModel)cBoxGroup.SelectedItem;
                group.Students.Add(studentViewModel);
                groupService.AddStudentToGroup(group.GroupId, studentViewModel);
                dialog.Close();

            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GroupViewModel groupViewModel = new GroupViewModel();
            groupViewModel.Commence = new DateTime(1990, 01, 01);
            EditGroup dialog = new EditGroup(groupViewModel);
            var result = dialog.ShowDialog();
            if (result == true)
                groupService.CreateGroup(groupViewModel);
            groups = groupService.GetAll();
            cBoxGroup.DataContext = groups;
            cBoxGroup.SelectedIndex = 0;
        }
    }
}
