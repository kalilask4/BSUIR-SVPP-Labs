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
using WPF_lab10.BusinessLayer.Model;

namespace lab10.Dialogs
{
    /// <summary>
    /// Interaction logic for EditStudent.xaml
    /// </summary>
    public partial class EditStudent : Window
    {
        StudentViewModel studentViewModel;

        public EditStudent(StudentViewModel studentViewModel)
        {
            InitializeComponent();
            this.studentViewModel = studentViewModel;
            grid.DataContext = studentViewModel;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (dpStudent.SelectedDate != null)
                studentViewModel.DateOfBirth = (DateTime)dpStudent.SelectedDate;
            if (checkBoxDiscount.IsChecked != null)
                studentViewModel.HasDiscont = (bool)checkBoxDiscount.IsChecked;
            MessageBox.Show($"{studentViewModel.FullName}{studentViewModel.DateOfBirth}{studentViewModel.HasDiscont}{studentViewModel.FileName}");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
