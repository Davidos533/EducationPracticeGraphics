using System;
using System.Drawing;
using System.Windows.Forms;

namespace exercise_2_graphics_task_3
{
    public partial class MainForm : Form
    {
        private Label lableWhile;
        private Label lableDoWhile;
        private Label lableFor;
        public MainForm()
        {
            InitializeComponent();
        }

        // метод обработки нажатия кнопки
        private void button1_Click(object sender, EventArgs e)
        {
            // очистка панели с кнопками
            panel1.Controls.Clear();

            int X,Y;
            int A,B;

            // првоерка числе на соответствие
            if (int.TryParse(textBox1.Text, out A) && int.TryParse(textBox2.Text, out B)&&
                int.TryParse(maskedTextBox1.Text, out X)&& int.TryParse(maskedTextBox2.Text, out Y) && A<B)
            {
                lableWhile = new Label {Location=new Point(10,10), AutoSize = true };
                lableDoWhile = new Label { Location = new Point(200, 10), AutoSize = true };
                lableFor = new Label { Location = new Point(400, 10), AutoSize =true};

                int iter = 0;
                iter = A;

                while (iter < B)
                {
                    if (iter % 10 == X || iter % 10 == Y)
                    {
                        //lableWhile.Text=(String.Concat(lableWhile.Text, iter,"\n"));
                        lableWhile.Text+=$"{iter}\n";
                    }
                    ++iter;
                }
                
                iter = A;
                do
                {
                    if (iter % 10 == X || iter % 10 == Y)
                    {
                        //lableDoWhile.Text = (String.Concat(lableWhile.Text, iter, "\n"));
                        lableDoWhile.Text += $"{iter}\n";
                    }
                    ++iter;
                }
                while (iter < B);
                
                for (iter = A; iter < B; iter++)
                {
                    if (iter % 10 == X || iter % 10 == Y)
                    {
                        //lableFor.Text = (String.Concat(lableWhile.Text, iter, "\n"));
                        lableFor.Text += $"{iter}\n";
                    }
                }

                panel1.Controls.Add(lableWhile);
                panel1.Controls.Add(lableDoWhile);
                panel1.Controls.Add(lableFor);

                //label6.Text = String.Empty;
            }
            else
            {
                label6.Text = "Incorrect input";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
