using System;
using System.Windows;

namespace exercise_9_graphics_task_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileOperator fileOperator;
        public MainWindow()
        {
            InitializeComponent();
            fileOperator = new FileOperator();
        }

        private void getResult_Click(object sender, RoutedEventArgs e)
        {
            double[] arr;
            double maxVal;
            if (fileName.Text != String.Empty && ConvertStrToArr(inputData.Text, out arr)&&double.TryParse(maxValue.Text,out maxVal))
            {
                fileOperator.m_fileName = $"{fileName.Text}.bin";
                fileOperator.MakeFileWith(arr);
                fileOperator.ReadFile(maxVal);

                result.Content = fileOperator.outData;
            }
            else
            {
                result.Content = "Incorrect input";
            }
        }
        private bool ConvertStrToArr(string input, out double[] arr)
        {
            try
            {
                string[] vals = input.Split(' ');
                arr = new double[vals.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = double.Parse(vals[i]);
                }
                return true;

            }
            catch
            {
                arr = new double[0];
                return false;
            }
        }

    }
}
