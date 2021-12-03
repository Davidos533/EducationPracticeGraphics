using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace exercise_10_graphics_task_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProgramFileDirectoryManager fileManager;

        public MainWindow()
        {
            InitializeComponent();
            fileManager = new ProgramFileDirectoryManager();
            UpdateDirectoryElements();
        }
        // метод для обновления данных текущей дериктории
        private void UpdateDirectoryElements()
        {
            currentDirectory.Content = fileManager.m_currentManagerDirectory;       // установка значения текущей дериктории
            dataPanel.Children.Clear(); // очитска списка элементов панели
            statusCode.Content= DecryptStatusCode(fileManager.ShowAllCurrentDirectoryFD(dataPanel));       // получение новго списка
            UpdateLabelsEventers();     // обновление обработчиков событий
            
        }
        // метод для перехода на директорию выше
        private void buttonGoUpDirectory_Click(object sender, RoutedEventArgs e)
        {
            statusCode.Content=DecryptStatusCode(fileManager.GoBackDirectory());
            UpdateDirectoryElements();
        }
        private void buttonMakeDirectory_Click(object sender, RoutedEventArgs e)
        {
            statusCode.Content=DecryptStatusCode(fileManager.CreateDirectory(textBoxMakeDirectory.Text));
            UpdateDirectoryElements();
        }
        private void buttonMakeFile_Click(object sender, RoutedEventArgs e)
        {
            statusCode.Content = DecryptStatusCode(fileManager.CreateFile(textBoxMakeFileFileName.Text,textBoxMakeFileFileData.Text));
            UpdateDirectoryElements();
        }
        private void buttonConcatanateFiles_Click(object sender, RoutedEventArgs e)
        {
            statusCode.Content = DecryptStatusCode(fileManager.AppendTextToFile(textBoxConcatanateEditableFileName.Text, textBoxConcatanateAppendableFileName.Text));
            UpdateDirectoryElements();
        }
        private void buttonRemoveElemnt_Click(object sender, RoutedEventArgs e)
        {
            statusCode.Content = DecryptStatusCode(fileManager.DeleteFileOrDirectory(currentSelectedElement.Content.ToString().Substring(0, currentSelectedElement.Content.ToString().Length - 1)));
            UpdateDirectoryElements();
        }
        // метод для обновления обработчиков событий
        private void UpdateLabelsEventers()
        {
            for (int i = 0; i < dataPanel.Children.Count; i++)
            {
                dataPanel.Children[i].MouseLeftButtonDown += (sender, e) =>
                    {
                        ResetPanelElementsColors();
                        ((Label)sender).Background = Brushes.Yellow;
                        currentSelectedElement.Content = ((Label)sender).Content.ToString();

                        if (e.ClickCount == 2)
                        {
                            string elementName = currentSelectedElement.Content.ToString().Substring(0, currentSelectedElement.Content.ToString().Length - 1);
                            StringBuilder data = new StringBuilder();
                            if ((fileManager.GoToDirectory(elementName)) == ProgramFileDirectoryManager.StatusCode.SuccessfullyStepped)
                            {
                                ResetPanelElementsColors();
                                UpdateDirectoryElements();
                            }
                            else if (fileManager.ReadFile(elementName, ref data)==ProgramFileDirectoryManager.StatusCode.SuccessfullyRead)
                            {
                                fileData.Content = data.ToString();
                                fileDataPanel.Height = fileData.Height;
                                data.Clear();
                            }
                        }
                    };
            }
        }
        private void ResetPanelElementsColors()
        {
            for (int i = 0; i < dataPanel.Children.Count; i++)
            {
                ((Label)dataPanel.Children[i]).Background = Brushes.LightYellow;
            }
        }
        static string GetStringFormStringArrayRange(string[] array, int startIndex, int stopIndex)
        {
            StringBuilder returnableData = new StringBuilder();

            try
            {
                for (int i = startIndex; i < stopIndex + 1; i++)
                {
                    returnableData.Append($"{array[i]} ");
                }
                return returnableData.ToString();
            }
            catch
            {
                return "";
            }

        }
        static string DecryptStatusCode(ProgramFileDirectoryManager.StatusCode currentSelectedElement)
        {
            switch (currentSelectedElement)
            {
                case ProgramFileDirectoryManager.StatusCode.AlreadyCreated: return "already created";
                case ProgramFileDirectoryManager.StatusCode.DirectoryNotFound: return "directroty not found";
                case ProgramFileDirectoryManager.StatusCode.FileNotFound: return "file not found";
                case ProgramFileDirectoryManager.StatusCode.SomeError: return "some error";
                case ProgramFileDirectoryManager.StatusCode.SuccessfullyAppended: return "successfully appended";
                case ProgramFileDirectoryManager.StatusCode.SuccessfullyCreated: return "successfully created";
                case ProgramFileDirectoryManager.StatusCode.SuccessfullyStepped: return "successfully stepped";
                case ProgramFileDirectoryManager.StatusCode.SuccessfullyGet: return "successfully get";
                case ProgramFileDirectoryManager.StatusCode.SuccessfullyRead: return "successfully read";
                case ProgramFileDirectoryManager.StatusCode.SuccessfullyDelete: return "successfully delete";
                case ProgramFileDirectoryManager.StatusCode.ElementNotFound: return "element not found";
                default: return "unknown code";
            }
        }


    }
}
