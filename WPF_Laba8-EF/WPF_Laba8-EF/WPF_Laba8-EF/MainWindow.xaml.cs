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
using System.Xml.Linq;
using WPF_Laba8_EF.Models;

namespace WPF_Laba8_EF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EntityContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new EntityContext();
            db.Students.Load();
            dGrid.ItemsSource = db.Students.Local.ToBindingList();

        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            EditWindow ew = new EditWindow(student);
            var result = ew.ShowDialog();
            if (result == true)
            {
                db.Students.Add(student);
                db.SaveChanges();
                ew.Close();
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dGrid.SelectedItems.Count > 0)
            {
                for(int i = 0; i < dGrid.SelectedItems.Count; i++)
                {
                    Student student = dGrid.SelectedItems[i] as Student;
                    if(student != null)
                    {
                        db.Students.Remove(student);
                    }
                }
            }
            db.SaveChanges();

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Student student = dGrid.SelectedItem as Student;
            EditWindow ew = new EditWindow(student);
            var result = ew.ShowDialog();
            if (result == true)
            {
                db.SaveChanges();
                ew.Close();

            }
            else
            {
                db.Entry(student).Reload();
                dGrid.DataContext = null;
                dGrid.DataContext = db.Students.Local;
                db.SaveChanges();
                ew.Close();

            }
        }
    }
}
