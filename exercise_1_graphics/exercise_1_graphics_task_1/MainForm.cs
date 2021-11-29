using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exercise_1_graphics_task_1
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        TextBox[] pointsEnterersTextBoxes;
        Label[] pointsEntererLables;
        myClass.Point[] figurePoints;

        public MainForm()
        {
            InitializeComponent();
        }
        // обработки взаимодействия с трек баром
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
        }

        // обработка события нажатия на кнопку получения полей ввода точек
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            int numberOfTextBoxes = trackBar1.Value*2;
            int numberOfLables =trackBar1.Value* 2 + trackBar1.Value;

            pointsEnterersTextBoxes = new TextBox[numberOfTextBoxes];

            pointsEntererLables= new Label[numberOfLables];

            // обход всех lable элементов и занесение их в panel
            for (int i = 0; i < numberOfLables; i+=3)
            {
                int offset = i * 30;
                pointsEntererLables[i] = new Label { Text = $"Point {i/3+1}",Location=new Point(5,offset+10)};
                pointsEntererLables[i+1] = new Label { Text = $"coord x",Location=new Point(5, offset+ 30)};
                pointsEntererLables[i+2] = new Label{ Text = $"coord y", Location = new Point(5, offset+ 50)};

                // добавление lable в panel
                panel1.Controls.Add(pointsEntererLables[i]);
                panel1.Controls.Add(pointsEntererLables[i+1]);
                panel1.Controls.Add(pointsEntererLables[i+2]);
            }

            for (int i = 0; i < numberOfTextBoxes; i+=2)
            {
                int offset = i * 45;

                pointsEnterersTextBoxes[i] = new TextBox{ Location=new Point(110,offset+30),};
                pointsEnterersTextBoxes[i+1] = new TextBox{ Location = new Point(110, offset + 55)};

                panel1.Controls.Add(pointsEnterersTextBoxes[i]);
                panel1.Controls.Add(pointsEnterersTextBoxes[i+1]);
            }

        }

        // метод для вычисления периметра
        private void button1_Click(object sender, EventArgs e)
        {
            figurePoints = new myClass.Point[pointsEnterersTextBoxes.Length/2];
            float perimetr = 0;
            try
            {
                for (int i = 0; i < pointsEnterersTextBoxes.Length-1; i+=2)
                {
                    figurePoints[i/2]=new myClass.Point(
                        float.Parse(pointsEnterersTextBoxes[i].Text),
                        float.Parse(pointsEnterersTextBoxes[i+1].Text));
                }

                for (int i = 0; i < pointsEnterersTextBoxes.Length/2-1; i++)
                {
                    perimetr+= myClass.Point.GetLengthBetweenPoints(figurePoints[i],figurePoints[i+1]);
                }
                perimetr += myClass.Point.GetLengthBetweenPoints(figurePoints[0], figurePoints[pointsEnterersTextBoxes.Length/2 - 1]);

                label2.Text = $"perimetr: {perimetr}";
                label1.Text = "";
            }
            catch
            {
                label1.Text = "Incorrect values input";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
