using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace exercise_3_graphics_task_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Label lable;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            panel.Children.Clear();

            StringBuilder sB = new StringBuilder();

            double startValue=0;
            double stopValue=0;
            double stepValue=0;

            lable = new Label();
            lable.HorizontalAlignment = HorizontalAlignment.Left;
            lable.VerticalAlignment = VerticalAlignment.Top;

            if (double.TryParse(textBox1.Text, out startValue) && double.TryParse(textBox2.Text, out stopValue) && double.TryParse(textBox3.Text, out stepValue))
            {

                for (double i = startValue; i < stopValue; i += stepValue)
                {
                    sB.Append($"\nvalue\tx = {i:0.##}\n\ty = {CalculateFuncValue(i):0.##}");
                }

                lable.Content = sB.ToString();

            }
            else
            {
                lable.Content = "Incorrect input";        
            }
            panel.Children.Add(lable);
        }
        private double CalculateFuncValue(double x)
        {
            if (x + 2 <= 1)
            {
                return x * x;
            }
            else if ((x + 2) < 10)
            {
                return 1 / (x + 2);
            }
            else
            {
                return x + 2;
            }
        }
    }
}
