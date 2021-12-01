using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace exercise_6_graphics_task_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random randomValue = new Random();
        Label outData=new Label {HorizontalAlignment=HorizontalAlignment.Left,VerticalAlignment=VerticalAlignment.Top };
        public MainWindow()
        {
            InitializeComponent();
            panel.Children.Add(outData);
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int arraySize;
            if (int.TryParse(input.Text, out arraySize)&&arraySize>0)
            {
                StringBuilder sB = new StringBuilder();

                int[] arr = GetArray(arraySize);

                sB.Append(CoutArr(arr));
                sB.Append($"\n\tLast minimum number: {GetNumberOfTheLastMinimumElemet(arr)}");

                outData.Content = sB.ToString();
            }
            else
            {
                outData.Content = "Incorrect input";
            }
            panel.Width = outData.Width;
            panel.Height= outData.Height;
        }
        static int GetNumberOfTheLastMinimumElemet(int[] arr)
        {
            int bufIndex = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < bufIndex)
                {
                    bufIndex = arr[i];
                }
            }
            return bufIndex;
        }
        static string CoutArr(int[] arr)
        {
            StringBuilder outData = new StringBuilder();

            for (int i = 0; i < arr.Length; i++)
            {
                outData.Append($" {arr[i]}");
            }

            return outData.ToString();
        }
        static int[] GetArray(int arraySize)
        {
            int[] arr = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                arr[i] = randomValue.Next(-50, 50);
            }
            return arr;
        }
    }
}
