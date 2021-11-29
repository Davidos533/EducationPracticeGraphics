using System;
using System.Windows.Forms;

namespace exercise_2_graphics_task_2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int[] monthsDays = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

                int day = int.Parse(maskedTextBox2.Text);
                int month = int.Parse(maskedTextBox3.Text);
                int year = int.Parse(maskedTextBox4.Text);

                int days = int.Parse(textBox1.Text);

                // если год не високосный и количество дней больше или равно года
                while (true)
                {
                    if (year % 4 != 0 && days >= Summ(monthsDays))
                    {
                        days -= Summ(monthsDays);
                    }
                    else if (year % 4 == 0 && days >= Summ(monthsDays) + 1)
                    {

                        days -= (Summ(monthsDays) + 1);
                    }
                    else
                    {
                        break;
                    }
                    --year;
                }

                // если дней >= чем минимальная длина месяца при учёти вескосности года
                while ((days >= 28 && year % 4 != 0) || (days >= 29 && year % 4 == 0))
                {
                    ProcessMonth(ref month, ref days, monthsDays, ref day, ref year);

                }

                if (days > 0)
                {
                    day -= days;
                }
                if (day <= 0)
                {
                    if (month == 1)
                    {
                        month = 12;
                    }
                    else
                    {
                        --month;
                    }
                    day = monthsDays[month] + day;
                }

                label4.Text = $"{day+1}.{month}.{year}";
            }
            catch (FormatException)
            {
                label4.Text = "Incorrect input";
            }
        }
        private int Summ(int[] arr)
        {
            int summ = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                summ += arr[i];
            }
            return summ;
        }
        private void ProcessMonth(ref int month,ref int days,int[] monthsDays, ref int day,ref int year)
        {
            switch (month)
            {
                case 1:
                    {
                        if (days >= monthsDays[month])
                        {
                            month = 12;
                            days -= monthsDays[month];
                        }
                        else
                        {
                            day -= days;
                            days = 0;
                        }
                    }
                    break;
                case 2:
                    {
                        if (days >= monthsDays[month])
                        {
                            month = 1;
                            if (year % 4 != 0)
                            {
                                days -= monthsDays[month];
                            }
                            else
                            {
                                days -= monthsDays[month] + 1;
                            }
                        }
                        else
                        {
                            day -= days;
                            days = 0;
                        }
                    }
                    break;
                case 3:
                    {
                        if (days >= monthsDays[month])
                        {
                            month = 2;
                            days -= monthsDays[month];
                        }
                        else
                        {
                            day -= days;
                            days = 0;
                        }
                    }
                    break;
                case 4:
                    {
                        if (days >= monthsDays[month])
                        {
                            month = 3;
                            days -= monthsDays[month];
                        }
                        else
                        {
                            day -= days;
                            days = 0;
                        }
                    }
                    break;
                case 5:
                    {
                        if (days >= monthsDays[month])
                        {
                            month = 4;
                            days -= monthsDays[month];
                        }
                        else
                        {
                            day -= days;
                            days = 0;
                        }
                    }
                    break;
                case 6:
                    {
                        if (days >= monthsDays[month])
                        {
                            month = 5;
                            days -= monthsDays[month];
                        }
                        else
                        {
                            day -= days;
                            days = 0;
                        }
                    }
                    break;
                case 7:
                    {
                        if (days >= monthsDays[month])
                        {
                            month = 6;
                            days -= monthsDays[month];
                        }
                        else
                        {
                            day -= days;
                            days = 0;
                        }
                    }
                    break;
                case 8:
                    {
                        if (days >= monthsDays[month])
                        {
                            month = 7;
                            days -= monthsDays[month];
                        }
                        else
                        {
                            day -= days;
                            days = 0;
                        }
                    }
                    break;
                case 9:
                    {
                        if (days >= monthsDays[month])
                        {
                            month = 8;
                            days -= monthsDays[month];
                        }
                        else
                        {
                            day -= days;
                            days = 0;
                        }
                    }
                    break;
                case 10:
                    {
                        if (days >= monthsDays[month])
                        {
                            month = 9;
                            days -= monthsDays[month];
                        }
                        else
                        {
                            day -= days;
                            days = 0;
                        }
                    }
                    break;
                case 11:
                    {
                        if (days >= monthsDays[month])
                        {
                            month = 10;
                            days -= monthsDays[month];
                        }
                        else
                        {
                            day -= days;
                            days = 0;
                        }
                    }
                    break;
                case 12:
                    {
                        if (days >= monthsDays[month])
                        {
                            month = 11;
                            days -= monthsDays[month];
                        }
                        else
                        {
                            day -= days;
                            days = 0;
                        }
                    }
                    break;
            }
            }
    }
}
