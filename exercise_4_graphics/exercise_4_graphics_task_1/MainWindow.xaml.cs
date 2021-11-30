using System.Windows;

namespace exercise_4_graphics_task_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int valueX;
            int valueN;

            if (int.TryParse(inputN.Text, out valueN) && int.TryParse(inputX.Text, out valueX)&&valueN>0)
            {
                answer.Content = $"{foo(valueX, valueN):0.###} ";
            }
            else
            {
                answer.Content = "Incorrect input";
            }
        }
        private double foo(double x, int n, int counter = 1)
        {
            if (counter != n)
            {
                return x / (counter + foo(x, n, counter + 1));
            }
            else
            {
                return counter + x;
            }
        }
    }
}
