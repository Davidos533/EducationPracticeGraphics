using System;
using System.Windows;
using System.Windows.Controls;

namespace exercise_11_graphics_task_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CustomDate customDate;
        public MainWindow()
        {
            InitializeComponent();
            customDate = new CustomDate();
            dateInput.Text = customDate.m_dateTime.ToString().Substring(0, 10);
        }

        private void dateInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                customDate.m_dateTime = DateTime.Parse(dateInput.Text);
                nextDay.Content=$"Next day: {customDate.GetNextDayDate().ToString().Substring(0,10)}";
                previousDay.Content=$"Previous day: {customDate.GetPreviousDayDate().ToString().Substring(0, 10)}";
                thisYearIsLeap.Content=$"This year {(customDate.IsLeap?"is":"not")} leap";
                daysForEndOfMonth.Content = $"Days for end of mont: {customDate.CountDaysToEndOfMonth()}";
            }
            catch
            {
                daysForEndOfMonth.Content = "waiting input";
                thisYearIsLeap.Content = "waiting input";
                nextDay.Content = "waiting input";
                previousDay.Content = "waiting input";
            }
        }
    }
}
