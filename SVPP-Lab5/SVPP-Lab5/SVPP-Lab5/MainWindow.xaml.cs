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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace SVPP_Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        Shape shape;


        public MainWindow()
        {
            InitializeComponent();
            CommandBinding commandBindingHelp = new CommandBinding();
            commandBindingHelp.Command = ApplicationCommands.Help;
            commandBindingHelp.Executed += help;
            menuItemHelp.CommandBindings.Add(commandBindingHelp);

            CommandBinding commandBindingSave = new CommandBinding();
            commandBindingSave.Command = ApplicationCommands.Save;
            commandBindingSave.Executed += save;
            commandBindingSave.CanExecute += save_CanExecute;
            menuItemSave.CommandBindings.Add(commandBindingSave);

            CommandBinding commandBindingOpen = new CommandBinding();
            commandBindingOpen.Command = ApplicationCommands.Open;
            commandBindingOpen.Executed += open;
            menuItemOpen.CommandBindings.Add(commandBindingOpen);


            //img_Clear.Source = new BitmapImage(new Uri("Images/Clear.png", UriKind.Relative));


            btnOpen.CommandBindings.Add(commandBindingOpen);
            btnSave.CommandBindings.Add(commandBindingSave);


        }




        private void help(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Help");
        }


        private void open(object sender, ExecutedRoutedEventArgs e)
        {
            shape = Shape.LoadFromFile();
        }


        private void save(object sender, ExecutedRoutedEventArgs e)
        {
            shape.SaveToFile();
        }


        private void save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {  
            e.CanExecute = shape != null;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowShape windowShape = new WindowShape();
            if (windowShape.ShowDialog() == true)
               shape = windowShape.NewShape;
             
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            TextBlockCursorPosition.Text = e.GetPosition(Canvas).ToString();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (shape == null) return;
            Polygon t = new Polygon();
            t.Points = new PointCollection();
            Point point1 = e.GetPosition(Canvas);
            shape.X = point1.X;
            shape.Y = point1.Y;
           
            Point point2 = new Point(shape.X + 30, shape.Y + 30);
            Point point3 = new Point(shape.X + 30, shape.Y + 10);
            Point point4 = new Point(shape.X + 90, shape.Y + 10);
            Point point5 = new Point(shape.X + 90, shape.Y - 10);
            Point point6 = new Point(shape.X + 30, shape.Y - 10);
            Point point7 = new Point(shape.X + 30, shape.Y - 30);
            t.Points.Add(point1);
            t.Points.Add(point2);
            t.Points.Add(point3);
            t.Points.Add(point4);
            t.Points.Add(point5);
            t.Points.Add(point6);
            t.Points.Add(point7);
            t.Fill = shape.Background;
            t.Stroke = shape.Foreground;
            t.StrokeThickness = shape.Width;
            Canvas.Children.Add(t);
                      
        }

        private void btnClearClick(object sender, RoutedEventArgs e)
        {
            Canvas.Children.Clear();
        }

        //private void btnOpen_Click(object sender, RoutedEventArgs e)
        //{
        //    shape = Shape.LoadFromFile();
        //}
    }
}
