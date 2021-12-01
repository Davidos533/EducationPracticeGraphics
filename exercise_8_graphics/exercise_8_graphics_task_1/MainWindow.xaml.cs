using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;


namespace exercise_8_graphics_task_1
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

        private void userInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double summ;
                string outVal = GetSumm(userInput.Text, out summ).Replace(" ", " + ");
                outVal = outVal.Substring(0, outVal.Length - 3);
                outData.Content=$"Result: {outVal} = {summ}";
            }
            catch
            {
                outData.Content = "Error";
            }
        }
        private string GetSumm(string data,out double summ)
        {
            StringBuilder summValues= new StringBuilder();

            summ = 0;
            foreach (var number in Regex.Matches(data, @"-?\d+((,\d+[eE][+-]?\d+)|(,\d+))?"))
            {
                // если число экспоненциальное
                if (Regex.IsMatch(number.ToString(), @"-?\d+,\d+[eE][+-]?\d+"))
                {
                    // замена маленькой e на большую E
                    string val = number.ToString().Replace('e', 'E');
                    // если в числе остутствует + или - замена пустоты на +
                    if (val[val.IndexOf('E') + 1] != '+' && val[val.IndexOf('E') + 1] != '-')
                    {
                        val = val.Insert(val.IndexOf('E') + 1, "+");
                    }
                    summ += (double)decimal.Parse(val, System.Globalization.NumberStyles.Float);
                    summValues.Append($"{val} ");
                }
                else
                {
                    summ += double.Parse(number.ToString());
                    summValues.Append($"{number.ToString()} ");
                }
            }

            return summValues.ToString();

        }
    }
}
