using Microsoft.Win32;
using System.Windows;

namespace exercise_9_graphics_task_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog fileDialog;
        TxtReader txtReader;
        
        public MainWindow()
        {
            InitializeComponent();
            fileDialog = new OpenFileDialog();
            txtReader = new TxtReader();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                fileDialog.ShowDialog();
                txtReader.filePath = fileDialog.FileName;
                txtReader.GetAllSpacedContainsLines();
                result.Content = $"Result:\n{txtReader.result}";
            }
            catch
            {
                result.Content = "Incorrect file path of file data";
            }
        }
    }
}
