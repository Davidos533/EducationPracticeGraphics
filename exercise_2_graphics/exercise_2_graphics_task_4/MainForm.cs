using System;
using System.Text;
using System.Windows.Forms;

namespace exercise_2_graphics_task_4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StringBuilder outData=new StringBuilder();

            for (int i = 1; i < 7; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    outData.Append(String.Concat(" ",j));
                }
                outData.Append("\n");
            }

            label1.Text = outData.ToString();
        }
    }
}
