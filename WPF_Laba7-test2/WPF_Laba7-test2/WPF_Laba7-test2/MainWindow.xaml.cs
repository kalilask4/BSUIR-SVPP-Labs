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
using System.Collections.ObjectModel;

namespace WPF_Laba7_test2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Person person;
        ObservableCollection<Person> collection = new ObservableCollection<Person>();

        public MainWindow()
        {
            InitializeComponent();
            person = new Person();
            gridPerson.DataContext = person;
            listBox.DataContext = collection;
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            FillData();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            Person personFind = Person.Find(textBoxName.Text);
            if (personFind == null)
                MessageBox.Show("Nothing found.");
            else
                MessageBox.Show(personFind.ToString());
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FillData()
        {
            collection.Clear();
            foreach(var p in Person.getAllPersons())
            {
                collection.Add(p);
            }
        }
    }
}
