using System;
using System.Windows;
using System.Windows.Controls;

namespace exercise_7_graphics_task_2
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
            if (inputString.Text != String.Empty)
            {
                string[] words = inputString.Text.Split(' ');

                int longestWordId = 0;

                for (int i = 0; i < words.Length; i++)
                {
                    if (words[longestWordId].Length < words[i].Length)
                    {
                        longestWordId = i;
                    }
                }
                outData.Content = words[longestWordId];
            }
            else
            {
                outData.Content = "Enter something";
            }
        }
    }
}
