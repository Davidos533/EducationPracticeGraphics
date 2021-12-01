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
        Label outData=new Label { HorizontalAlignment=HorizontalAlignment.Left,VerticalAlignment=VerticalAlignment.Top};
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
            int matSize;
            int degr;

            if (int.TryParse(matrSize.Text, out matSize) && int.TryParse(degree.Text, out degr)&&matSize>0&&degr>0)
            {
                StringBuilder sB = new StringBuilder();

                Matrix matr1 = new Matrix(matSize);
                
                sB.Append(CoutMatr(matr1));

                for (int i = 1; i < degr; i++)
                {
                    matr1 = matr1 * matr1;

                }
                sB.Append("\n");
                sB.Append(CoutMatr(matr1));

                outData.Content = sB.ToString();
            }
            else
            {
                outData.Content = "Incorrect input";
            }
            panel.Width = outData.Width;
            panel.Height = outData.Height;
        }
        static string CoutMatr(Matrix matr)
        {
            StringBuilder outData = new StringBuilder();

            for (int i = 0; i < matr.GetLength; i++)
            {
                outData.Append("\n");
                for (int j = 0; j < matr.GetLength; j++)
                {
                    outData.Append($"\t{matr[i, j]}");
                }
            }

            return outData.ToString();
        }
    }
}
