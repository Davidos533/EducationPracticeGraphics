using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace exercise_6_graphics_task_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        Random randomValue = new Random();

        Label outArrData = new Label();
        Label outMatrixData = new Label();

        int topRangeValue;
        int bottomRangeValue;

        public MainWindow()
        {
            
            InitializeComponent();

            outArrData.HorizontalAlignment = HorizontalAlignment.Left;
            outArrData.VerticalAlignment= VerticalAlignment.Top;

            outMatrixData.HorizontalAlignment = HorizontalAlignment.Right;
            outMatrixData.VerticalAlignment = VerticalAlignment.Top;

            panel.Children.Add(outMatrixData);
            panel.Children.Add(outArrData);
        }
        public void topBorderOnTextChanged(object sender, RoutedEventArgs e)
        {
            ProcessArr();
            ProcessMatr();
        }
        public void bottomBorderOnTextChanged(object sender, RoutedEventArgs e)
        {
            ProcessArr();
            ProcessMatr();
        }
        public void arraySizeOnTextChanged(object sender, RoutedEventArgs e)
        {
            ProcessArr();
        }
        public void onNTextChange(object sender, RoutedEventArgs e)
        {
            ProcessMatr();
        }
        public void onMTextChange(object sender, RoutedEventArgs e)
        {
            ProcessMatr();
        }
        private void ProcessArr()
        {
            int arrSize;
            if (ProcesBorders() && int.TryParse(arraySize.Text, out arrSize)&&arrSize>0)
            {
                int[] arr = GetArray(arrSize);
                StringBuilder sb = new StringBuilder();
                sb.Append(CoutArr(arr));
                sb.Append($"\nNumber of avoid range values in array: {CountNumberOfAvoidRangeArr(arr, topRangeValue, bottomRangeValue)}");

                outArrData.Content = sb.ToString();



                error.Content = String.Empty;
            }
            else
            {
                error.Content = "Incorrect input";
            }
            panel.Height = outMatrixData.Height + outArrData.Height;
        }
        private void ProcessMatr()
        {
            int matrN;
            int matrM;

            if (ProcesBorders() && int.TryParse(matrixM.Text, out matrM)&&int.TryParse(matrixN.Text,out matrN)&&matrM>0&&matrN>0)
            {
                int[,] matrix = GetMatrix(matrN, matrM);
                StringBuilder sb = new StringBuilder();
                sb.Append(CoutMatr(matrix));
                sb.Append($"\nNumber of avoid range values in matrix: {CountNumberOfAvoidRangeMatrix(matrix, topRangeValue, bottomRangeValue)}");

                outMatrixData.Content = sb.ToString();

                error.Content = String.Empty;
            }
            else
            {
                error.Content = "Incorrect input";
            }
            panel.Height = outMatrixData.Height + outArrData.Height;
        }
        private bool ProcesBorders()
        {
            return int.TryParse(topBorder.Text, out topRangeValue) && int.TryParse(bottomBorder.Text, out bottomRangeValue);
        }
        private string CoutArr(int[] arr)
        {
            StringBuilder outData = new StringBuilder();

            for (int i = 0; i < arr.Length; i++)
            {
                outData.Append($" {arr[i]}\n");
            }

            return outData.ToString();
        }
        private string CoutMatr(int[,] matr)
        {
            StringBuilder outData = new StringBuilder();

            for (int i = 0; i < matr.GetLength(0); i++)
            {
                outData.Append("\n");
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    outData.Append($"\t{matr[i, j]}");
                }
            }

            return outData.ToString();
        }
        private int CountNumberOfAvoidRangeArr(int[] arr, int aRange, int bRange)
        {
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < aRange || arr[i] > bRange)
                {
                    ++count;
                }
            }
            return count;
        }
        private int CountNumberOfAvoidRangeMatrix(int[,] matr, int aRange, int bRange)
        {
            int count = 0;

            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    if (matr[i, j] < aRange || matr[i, j] > bRange)
                    {
                        ++count;
                    }
                }
            }

            return count;
        }
        private int[,] GetMatrix(int n, int m)
        {
            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = randomValue.Next(-50, 50);
                }
            }

            return matrix;
        }
        private int[] GetArray(int arraySize)
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
