using System;
using System.Windows;

namespace exercise_4_graphics_task_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int binaryValue;
        int summ;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void TextBox_OnInput(object sender ,RoutedEventArgs e)
        {
            answer.Content = String.Empty;

            summ = 0;

            if (int.TryParse(binaryInput.Text, out binaryValue)&&ChekValToBinary(binaryInput.Text))
            {
                foo(binaryValue, ref summ);
            }
            else
            {
                answer.Content = "Incorrect input";
            }
        }
        private void foo(int binaryNumber, ref int summ, int iter = 0)
        {
            if (binaryNumber / 10 != 0 || binaryNumber == 1)
            {
                summ += binaryNumber % 10 * (int)Math.Pow(2, iter);
                foo(binaryNumber / 10, ref summ, iter + 1);
            }
            if (iter == 0)
            {
                answer.Content = summ.ToString();
            }
        }
        private bool ChekValToBinary(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if ((value[i] != '0') && (value[i] != '1'))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
