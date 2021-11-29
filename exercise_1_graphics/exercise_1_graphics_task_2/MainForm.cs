using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace exercise_1_graphics_task_2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(maskedTextBox1.Text, @"^\d{2}$"))
            {
                int number = int.Parse(maskedTextBox1.Text);

                int firstPart = number / 10;
                int secondPart = number % 10;
                int summ = firstPart + secondPart;

                label2.Text = $"{firstPart} + {secondPart} = {summ}";

                if (summ % 3 == 0)
                {
                    label2.Text += ", multiply to 3";
                }
                else
                {
                    label2.Text += ", not multiply to 3";
                }
            }
            else
            {
                label2.Text = "Incorrect input";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
