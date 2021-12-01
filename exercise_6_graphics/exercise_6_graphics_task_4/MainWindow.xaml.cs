using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace exercise_6_graphics_task_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Label outData = new Label { HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top };
        Random randomValue = new Random();
        public MainWindow()
        {
            InitializeComponent();
            panel.Children.Add(outData);
        }

        private void TextBox_TextChangedDegree(object sender, TextChangedEventArgs e)
        {
            ProcessMatr();
        }
        private void TextBox_TextChangedSize(object sender, TextChangedEventArgs e)
        {
            ProcessMatr();
        }
        private void ProcessMatr()
        {
            int arrSize;

            if (int.TryParse(arraySize.Text, out arrSize)&&arrSize>0)
            {
                StringBuilder sB = new StringBuilder();

                int[][] steppedArray = GetSteppedArray(arrSize);

                int[] evenNumbers = FindEvenNumbers(steppedArray);

                sB.Append(CoutSteppedArray(steppedArray));
                sB.Append("\n\tEven stepped array row elements:");
                sB.Append(CoutArr(evenNumbers));

                outData.Content = sB.ToString();
            }
            else
            {
                outData.Content = "Incorrect input";
            }
            panel.Width = outData.Width;
            panel.Height = outData.Height;
        }
        private string CoutArr(int[] arr)
        {
            StringBuilder outData = new StringBuilder();

            for (int i = 0; i < arr.Length; i++)
            {
                outData.Append($" {arr[i]}");
            }

            return outData.ToString();
        }
        private string CoutSteppedArray(int[][] steppedArray)
        {
            StringBuilder outData = new StringBuilder();

            for (int i = 0; i < steppedArray.GetLength(0); i++)
            {
                for (int j = 0; j < steppedArray.GetLength(0); j++)
                {
                    outData.Append($"\t{steppedArray[i][j]}");
                }
                outData.Append("\n");
            }
            return outData.ToString();

        }
        private int[] FindEvenNumbers(int[][] steppedArray)
        {
            int[] evenNumbers = new int[steppedArray.GetLength(0)];

            for (int i = 0; i < steppedArray.GetLength(0); i++)
            {
                for (int j = 0; j < steppedArray.GetLength(0); j++)
                {
                    if (steppedArray[i][j] % 2 == 0)
                    {
                        evenNumbers[i] = steppedArray[i][j];
                    }
                }
            }

            return evenNumbers;

        }
        // получение ступенчатого массива по заданному размеру заполненного случайными числами
        private int[][] GetSteppedArray(int arraySize)
        {
            int[][] arr = new int[arraySize][];     // инициализация массвиа

            // инициализация строк ступенчатого массива
            for (int i = 0; i < arraySize; i++)
            {
                arr[i] = new int[arraySize];
                // заполнение строки ступенчатого массива случайными значениями
                for (int j = 0; j < arraySize; j++)
                {
                    arr[i][j] = randomValue.Next(-50, 50);
                }
            }
            return arr;
        }
    }
}
