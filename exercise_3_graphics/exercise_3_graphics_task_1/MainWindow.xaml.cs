using System.Windows;

namespace exercise_3_graphics_task_1
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
            int number;
            
            if (int.TryParse(textBox1.Text, out number))
            {
                lable1.Content = "Result: "+func(number);
            }
            else
            {
                lable1.Content = "Incorrect input";
            }
        }
        static int func(int number)
        {
            if (number % 5 == 0)
            {
                return number / 5;
            }
            else
            {
                return number + 1;
            }
        }
    }
}
