using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace exercise_2_graphics_task_1
{
    public partial class MainForm : Form
    {
        // поля класса
        Vector2 inputPoint;

        string programPath;
        public MainForm()
        {
            InitializeComponent();

            // получение пути картинки и инициализация пути к ней для элемента PictureBox
            programPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            pictureBox1.ImageLocation = programPath + "/taskPicture.png";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                // кэшированные переменные координат точек
                float xCoord = float.Parse(textBox1.Text);
                float yCoord = float.Parse(textBox2.Text);

                inputPoint = new Vector2(xCoord, yCoord);

                // определение колизии точки и площади
                switch (CheckToCollidePointToSquare(inputPoint, new Vector2(0, 0), new Vector2(100, 50)))
                {
                    case 1:
                        {
                            label3.Text = "YES";
                        }
                        break;
                    case 0:
                        {
                            label3.Text = "On border";
                        }
                        break;
                    case -1:
                        {
                            label3.Text = "NO";
                        }
                        break;
                }
                label6.Text = String.Empty;
            }
            else
            {
                label6.Text = "Incorrect input";
                label3.Text = String.Empty;
            }
        }
        // метод для обработки входных данных
        private bool ValidateData()
        {
            bool sd = Regex.IsMatch("1", @"^\d+\,?\d+$");
            return Regex.IsMatch(textBox1.Text, @"^\d+(\,\d+)?$")&& Regex.IsMatch(textBox2.Text, @"^\d+(\,\d+)?$");
        }
        // метод для проверки нахождения точки в определённой площади
        private int CheckToCollidePointToSquare(Vector2 checkingPoint, Vector2 squarePosition, Vector2 squareSize)
        {
            Vector2 xSquareBorders = new Vector2((squarePosition.X - (squareSize.X / 2)), (squarePosition.X + (squareSize.X / 2)));
            Vector2 ySquareBorders = new Vector2((squarePosition.Y - (squareSize.Y / 2)), (squarePosition.Y + (squareSize.Y / 2)));

            // если точка лежит в диапозоне x и y площади
            if (
                checkingPoint.X > xSquareBorders.X && checkingPoint.X < xSquareBorders.Y &&
                checkingPoint.Y > ySquareBorders.X && checkingPoint.Y < ySquareBorders.Y)
            {
                return 1;
            }
            else if ((
                (checkingPoint.X == xSquareBorders.X || checkingPoint.X == xSquareBorders.Y) &&
                (checkingPoint.Y > ySquareBorders.X &&checkingPoint.Y <ySquareBorders.Y))||
                (checkingPoint.X > xSquareBorders.X && checkingPoint.X < xSquareBorders.Y) &&
                (checkingPoint.Y == ySquareBorders.X || checkingPoint.Y == ySquareBorders.Y))
            {
                return 0;
            }
            else
            {
                return -1;
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
