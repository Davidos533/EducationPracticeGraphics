using System;
using System.Windows;
using System.Windows.Controls;

namespace exercise_12_graphics_task_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CustomDate customDate;
        CustomDate customDateSecond;
        public MainWindow()
        {
            InitializeComponent();
            customDate = new CustomDate();
            customDateSecond = new CustomDate();
            dateInput.Text = customDate.m_dateTime.ToString().Substring(0, 10);
            dateInputSeond.Text = customDate.m_dateTime.ToString().Substring(0, 10);
        }

        private void dateInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProcessDate();
        }
        private void ProcessDate()
        {
            try
            {
                customDate.m_dateTime = DateTime.Parse(dateInput.Text);
                customDateSecond.m_dateTime = DateTime.Parse(dateInputSeond.Text);

                indecsatros.Content = $"The date above three day by now date: {customDate[3].ToString("dd/MM/yy")} \nThe date down five day by now date: {customDate[-5].ToString("dd/MM/yy")}";
                unarOperator.Content = $"Is this day not the last day of month: {(!customDate ? "yes" : "no")}";
                trueFalseOperator.Content = $"Is this date is year start: {(customDate? "yes" : "no")}";

                operatorAmpersant.Content = $"Is dates equals: {(customDate & customDateSecond? "yes" : "no")}";

                string strDate = (string)customDate;

                invocationCastToStr.Content = $"Explicit date from customDate to string: {strDate}";
                invocationCastToDate.Content = $"Explicit date from string to CustomDate: {(CustomDate)strDate}";
            }
            catch
            {
                indecsatros.Content = "waiting input";
                unarOperator.Content = "waiting input";
                trueFalseOperator.Content = "waiting input";
                operatorAmpersant.Content = "waiting input";
                invocationCastToDate.Content = "waiting input";
                invocationCastToStr.Content = "waiting input";
            }
        }
    }
}
