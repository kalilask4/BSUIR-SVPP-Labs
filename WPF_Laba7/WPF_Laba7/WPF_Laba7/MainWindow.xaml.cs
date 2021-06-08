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
using WPF_Laba7.Entities;

namespace WPF_Laba7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Coin coin;
        ObservableCollection<Coin> collection = new ObservableCollection<Coin>();

        public MainWindow()
        {
            InitializeComponent();
            coin = new Coin();
            gridCoin.DataContext = coin;
            listBox.DataContext = collection;

        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            FillData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex < 0)
                return;
            Coin.Delete(((Coin)listBox.SelectedItem).CoinId);
            FillData();
        }

        private void FillData()
        {
            collection.Clear();
            foreach (var p in Coin.getAllCoin())
            {
                collection.Add(p);
            }
        }

    }
}
