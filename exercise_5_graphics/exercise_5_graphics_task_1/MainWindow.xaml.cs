using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace exercise_5_graphics_task_1
{
    public partial class MainWindow : Window
    {
        Label outData;

        public MainWindow()
        {
            InitializeComponent();
            outData = new Label();

            outData.HorizontalAlignment = HorizontalAlignment.Left;
            outData.VerticalAlignment = VerticalAlignment.Top;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double startValue;
            double stopValue;
            double stepValue;

            StringBuilder outStr = new StringBuilder();
            panel.Children.Clear();
            if (double.TryParse(startValueTextBox.Text, out startValue) && double.TryParse(stopValueTextBox.Text, out stopValue) && double.TryParse(stepValueTextBox.Text, out stepValue))
            {
                double buf;
                for (double i = startValue; i < stopValue; i += stepValue)
                {
                    try
                    {
                        buf = Func(i);
                        outStr.Append($"\nx={i:0.###}, y={buf:0.###}");
                    }
                    catch
                    {
                        outStr.Append($"\nno roots");
                    }
                }

                outData.Content = outStr.ToString();
            }
            else
            {
                outData.Content = "Incorrect input";    
            }

            panel.Children.Add(outData);

        }
        static double Func(double x)
        {
            if (x - 2 <= 0)
            {
                throw new Exception();
            }
            else
            {
                return Math.Log(x - 2);
            }
        }
    }
}
