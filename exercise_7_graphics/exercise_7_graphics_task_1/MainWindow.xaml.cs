using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace exercise_7_graphics_task_1
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

        private void inputString_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProcessStrings();
        }
        private void ProcessStrings()
        {
            if (inputString.Text != String.Empty && editableString.Text != String.Empty && newString.Text != String.Empty)
            {
                StringBuilder inputSb= new StringBuilder(inputString.Text);

                resultOut.Content=inputSb.Replace(editableString.Text,newString.Text).ToString();
            }
            else
            {
                resultOut.Content = "Please input all values";
            }
        }
    }
}
