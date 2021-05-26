using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorWinForms
{
    public partial class Form1 : Form
    {

        char[] arr = new char[256];
        int position = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            arr[position] = '0';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arr[position] = '1';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            arr[position] = '2';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            arr[position] = '3';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            arr[position] = '4';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            arr[position] = '5';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            arr[position] = '6';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            arr[position] = '7';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            arr[position] = '8';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            arr[position] = '9';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            arr[position] = '.';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonExsponent_Click(object sender, EventArgs e)
        {
            arr[position] = 'e';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonLeftParanthesis_Click(object sender, EventArgs e)
        {
            arr[position] = '(';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonRightParanthesis_Click(object sender, EventArgs e)
        {
            arr[position] = ')';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonPI_Click(object sender, EventArgs e)
        {
            arr[position] = 'p';
            position++;
            arr[position] = 'i';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (position != 0 && (arr[position - 1] == '-' || arr[position - 1] == '*' || arr[position - 1] == '÷' || arr[position - 1] == '^'))
            {
                position--;
                arr[position] = '+';
            }
            else
            {
                arr[position] = '+';
            }
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (position != 0 && (arr[position - 1] == '+' || arr[position - 1] == '*' || arr[position - 1] == '÷' || arr[position - 1] == '^'))
            {
                position--;
                arr[position] = '-';
            }
            else
            {
                arr[position] = '-';
            }
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (position != 0 && (arr[position - 1] == '+' || arr[position - 1] == '-' || arr[position - 1] == '÷' || arr[position - 1] == '^'))
            {
                position--;
                arr[position] = '*';
            }
            else
            {
                arr[position] = '*';
            }
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonDivision_Click(object sender, EventArgs e)
        {
            if (position != 0 && (arr[position - 1] == '+' || arr[position - 1] == '-' || arr[position - 1] == '*' || arr[position - 1] == '^'))
            {
                position--;
                arr[position] = '÷';
            }
            else
            {
                arr[position] = '÷';
            }
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonPow_Click(object sender, EventArgs e)
        {
            if (position != 0 && (arr[position - 1] == '+' || arr[position - 1] == '-' || arr[position - 1] == '*' || arr[position - 1] == '÷'))
            {
                position--;
                arr[position] = '^';
            }
            else
            {
                arr[position] = '^';
            }
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (position > 0)
            {
                position--;
            }
            else
            {
                position = 0;
            }
            arr[position] = (char)0;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonCleanAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; arr[i] != 0; i++)
            {
                arr[i] = (char)0;
            }
            position = 0;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            arr[position] = 'x';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonSin_Click(object sender, EventArgs e)
        {
            arr[position] = 's';
            position++;
            arr[position] = 'i';
            position++;
            arr[position] = 'n';
            position++;
            arr[position] = '(';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonCos_Click(object sender, EventArgs e)
        {
            arr[position] = 'c';
            position++;
            arr[position] = 'o';
            position++;
            arr[position] = 's';
            position++;
            arr[position] = '(';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonTg_Click(object sender, EventArgs e)
        {
            arr[position] = 't';
            position++;
            arr[position] = 'g';
            position++;
            arr[position] = '(';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonCtg_Click(object sender, EventArgs e)
        {
            arr[position] = 'c';
            position++;
            arr[position] = 't';
            position++;
            arr[position] = 'g';
            position++;
            arr[position] = '(';
            position++;
            string str = "y=";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            label1.Text = str;
        }

        private void buttonEqualSign_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                double coefficient;//Коофицент растяжения
                if (textBoxCoefficient.Text == "")
                {
                    coefficient = 1;
                }
                else

                {
                    coefficient = Convert.ToDouble(textBoxCoefficient.Text);
                }

                double Xmin, Xmax;//Область определеня
                if (textBoxXmin.Text == "")
                {
                    Xmin = 0;
                }
                else
                {
                    Xmin = Convert.ToDouble(textBoxXmin.Text);
                }

                if (textBoxXmax.Text == "")
                {
                    Xmax = 900;
                }
                else
                {
                    Xmax = Convert.ToDouble(textBoxXmax.Text);
                }
                double coefficientX = Math.Abs(Xmax - Xmin) / 900.0;//Ширина pictureBox = 900, расчитываем шаг по значения (1 пиксель = coefficientX)

                if (Xmax <= Xmin)
                {
                    return;
                }

                //Проверяем есть ли Х в выражении
                bool haveX = false;
                for (int i = 0; arr[i] != 0; i++)
                {
                    if (arr[i] == 'x')
                    {
                        haveX = true;
                        break;
                    }
                }
                if (haveX == false)
                {
                    for (int i = 0; arr[i] != 0; i++)
                    {
                        arr[i] = (char)0;
                    }
                    position = 0;
                    label1.Text = "Ошибка! Отсутствует x";
                    return;
                }

                //Заменяем ÷ на /
                for (int i = 0; arr[i] != 0; i++)
                {
                    if (arr[i] == '÷')
                    {
                        arr[i] = '/';
                    }
                }


                //Проверяем выражение на корректность
                string str = "";
                for (int i = 0; arr[i] != 0; i++)
                {
                    str += arr[i];
                }
                str = MathExpression.ReplaceX(str, 1 - 450);
                str = MathExpression.NormExpression(str);
                if (str == "Ты ввёл некорректное выражение!")
                {
                    label1.Text = "Некорректное выражение!";
                    return;
                }
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////

                Graphics graphics = pictureBox1.CreateGraphics();
                Pen pen = new Pen(Color.Black, 3f);
                Point[] points = new Point[900];

                //Формируем массив точек и рисуем граффик по ним
                double x = Xmin;//Начинаем осчёт с крайнего левого значения
                for (int i = 0; i < points.Length; i++)
                {
                    //Копируем символы из массива в строку
                    str = "";
                    for (int j = 0; arr[j] != 0; j++)
                    {
                        str += arr[j];
                    }


                    str = MathExpression.ReplaceX(str, x);
                    str = MathExpression.NormExpression(str);
                    str = Calculator.ReverseInPolishNotation(str);
                    if (str == "Недопустимое выражение в tg")
                    {
                        continue;
                    }
                    else if (str == "Недопустимое выражение в ctg")
                    {
                        continue;
                    }
                    double result = Calculator.ReverseOutPolishNotation(str);

                    points[i] = new Point(i, 275 - (int)(result * coefficient));//275 - это центральная ось(y = 0), coefficient указывает на то как сильно бы толжны растянуть  
                    x += coefficientX;//Делаем шаг                                                                                                               //граффик вдоль оси Oy
                }

                try
                {
                    DrawDivisionPriceX(textBoxDivisionPriceX.Text.Length == 0 ? 1 : Convert.ToDouble(textBoxDivisionPriceX.Text),
                        textBoxDivisionPriceY.Text.Length == 0 ? Math.Round((275 / coefficient / 5), 2) : Convert.ToDouble(textBoxDivisionPriceY.Text),
                        coefficient, Xmin, Xmax, pictureBox1);//Оисем рисочки цены деления и ось Oy если она есть на области определения

                    DrawHorizontLine(pictureBox1);
                    graphics.DrawLines(pen, points);//Рисуем граффик
                }
                catch
                {

                }
            }
            catch
            {

            }
        }

        static void DrawHorizontLine(PictureBox pictureBox)
        {
            Graphics graphics = pictureBox.CreateGraphics();
            Pen pen = new Pen(Color.Red, 1f);

            Point[] points = new Point[900];
            for (int i = 0; i < points.Length; i++)//Рисуем горизонтальную черту симметрии
            {
                points[i] = new Point(i, 275);
            }
            graphics.DrawLines(pen, points);
        }

        static void DrawVerticalLine(int x, PictureBox pictureBox)
        {
            Graphics graphics = pictureBox.CreateGraphics();
            Pen pen = new Pen(Color.Red, 1f);

            Point[] points = new Point[550];
            for (int i = 0; i < points.Length; i++)//Рисуем вертикальную черту симметрии
            {
                points[i] = new Point(x, i);
            }
            graphics.DrawLines(pen, points);
        }

        static void DrawDivisionPriceX(double divisionPriceX, double divsionPriceY, double coefficient, double Xmin, double Xmax, PictureBox pictureBox)
        {
            Graphics graphics = pictureBox.CreateGraphics();
            Pen pen = new Pen(Color.Red, 3f);
            float single = 10f;
            Font font = new Font("Unispace", single);
            SolidBrush drawBrush = new SolidBrush(Color.Black);


            if (Xmin <= 0 && Xmax >= 0)//Ось Oy есть
            {
                int nToMax = (int)(Xmax / divisionPriceX);//Количество рисочек от нуля до крайнего правого значаения
                Point[] points = new Point[11];
                double coefficientX = Math.Abs(Xmax - Xmin) / 900.0;//Шаг 
                double x = Xmin;//Начинаем с крайнего левого значениия, потому что мы не знаем на каком пикселе находится ноль
                int n = 1;
                int iOfZero = 0;//Индекс пикселя на которой находится х = 0
                for (int i = 0; i < 900; i++)//Ищем индекс пикселя где x = 0 и рисуем там ось Oy
                {
                    if (((x - coefficientX) < 0 && (x + coefficientX) > 0) || x == 0)
                    {
                        //DrawVerticalLine(i, pictureBox);
                        iOfZero = i;
                        break;
                    }
                    x += coefficientX;
                }

                DrawDivisionPriceY(divsionPriceY, coefficient, Xmin, Xmax, pictureBox);

                for (int i = iOfZero; i < 900; i++)//Рисуем рисочки справа от оси Oy
                {
                    if (((x - coefficientX) < (0 + n * divisionPriceX) && (x + coefficientX) > (0 + n * divisionPriceX)) || (x == (0 + n * divisionPriceX)))
                    {
                        if (n == nToMax + 1)
                        {
                            break;
                        }
                        for (int j = 0, h = 270; j < 11; j++, h++)
                        {
                            points[j] = new Point(i, h);
                        }
                        graphics.DrawLines(pen, points);
                        graphics.DrawString(Convert.ToString(Math.Round((0 + n * divisionPriceX), 2)), font, drawBrush, points[10].X - 20, points[10].Y + 10);//Число под рисочкой
                        n++;
                    }
                    x += coefficientX;
                }
                //graphics.DrawLines(pen, points);


                int nToMin = (int)(-Xmin / divisionPriceX);//Количество рисочек от нуля до крайнего левого значаения
                points = new Point[11];
                x = 0;
                n = 1;
                for (int i = iOfZero; i > -1; i--)//Рисуем рисочки слева от оси Oy
                {
                    if (((x - coefficientX) < (0 - n * divisionPriceX) && (x + coefficientX) > (0 - n * divisionPriceX)) || (x == (0 - n * divisionPriceX)))
                    {
                        if (n == nToMin + 1)
                        {
                            break;
                        }
                        for (int j = 0, h = 270; j < 11; j++, h++)
                        {
                            points[j] = new Point(i, h);
                        }
                        graphics.DrawLines(pen, points);
                        graphics.DrawString(Convert.ToString(Math.Round((0 - n * divisionPriceX), 2)), font, drawBrush, points[10].X - 20, points[10].Y + 10);//Число под рисочкой
                        n++;
                    }
                    x -= coefficientX;
                }
                //graphics.DrawLines(pen, points);
            }
            else if (Xmin < 0 && Xmax < 0)//Область определения слева от оси Oy
            {
                int N = (int)(Math.Abs(Xmax - Xmin) / divisionPriceX) + Math.Abs((int)(Xmax / divisionPriceX));//Количество рисочек на области определения + от нуля до неё
                Point[] points = new Point[11];
                double coefficientX = Math.Abs(Xmax - Xmin) / 900.0;//Шаг 

                double x = Xmin;
                int n = N;
                for (int i = 0; i < 900; i++)//Рисуем рисочки справа от оси Oy
                {
                    if (((x - coefficientX) < (0 - n * divisionPriceX) && (x + coefficientX) > (0 - n * divisionPriceX)) || (x == (0 - n * divisionPriceX)))
                    {
                        if (n == Math.Abs((int)(Xmax / divisionPriceX)))
                        {
                            break;
                        }
                        for (int j = 0, h = 270; j < 11; j++, h++)
                        {
                            points[j] = new Point(i, h);
                        }
                        graphics.DrawLines(pen, points);
                        graphics.DrawString(Convert.ToString(Math.Round((0 - n * divisionPriceX), 2)), font, drawBrush, points[10].X - 20, points[10].Y + 10);//Число под рисочкой
                        n--;
                    }
                    x += coefficientX;
                }
            }
            else if (Xmin > 0 && Xmax > 0)//Область определени справа от оси Oy
            {
                int N = (int)(Math.Abs(Xmax - Xmin) / divisionPriceX) + Math.Abs((int)(Xmin / divisionPriceX));//Количество рисочек на области определения + от нуля до неё
                Point[] points = new Point[11];
                double coefficientX = Math.Abs(Xmax - Xmin) / 900.0;//Шаг 

                double x = Xmin;
                int n = Math.Abs((int)(Xmin / divisionPriceX)) + 1;
                for (int i = 0; i < 900; i++)//Рисуем рисочки справа от оси Oy
                {
                    if (((x - coefficientX) < (0 + n * divisionPriceX) && (x + coefficientX) > (0 + n * divisionPriceX)) || (x == (0 + n * divisionPriceX)))
                    {
                        if (n == N + 1)
                        {
                            break;
                        }
                        for (int j = 0, h = 270; j < 11; j++, h++)
                        {
                            points[j] = new Point(i, h);
                        }
                        graphics.DrawLines(pen, points);
                        graphics.DrawString(Convert.ToString(Math.Round((0 + n * divisionPriceX), 2)), font, drawBrush, points[10].X - 20, points[10].Y + 10);//Число под рисочкой
                        n++;
                    }
                    x += coefficientX;
                }
            }
        }

        static void DrawDivisionPriceY(double divisionPrice, double coefficient, double Xmin, double Xmax, PictureBox pictureBox)
        {
            Graphics graphics = pictureBox.CreateGraphics();
            Pen pen = new Pen(Color.Red, 3f);
            float single = 10f;
            Font font = new Font("Unispace", single);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            if (Xmin <= 0 && Xmax >= 0)//Ось Oy есть
            {
                Point[] points = new Point[11];
                double coefficientX = Math.Abs(Xmax - Xmin) / 900.0;//Шаг 
                double x = Xmin;//Начинаем с крайнего левого значениия, потому что мы не знаем на каком пикселе находится ноль
                int iOfZeroX = 0;//Индекс пикселя на которой находится х = 0
                for (int i = 0; i < 900; i++)//Ищем индекс пикселя где x = 0 и рисуем там ось Oy
                {
                    if (((x - coefficientX) < 0 && (x + coefficientX) > 0) || x == 0)
                    {
                        DrawVerticalLine(i, pictureBox);
                        iOfZeroX = i;
                        break;
                    }
                    x += coefficientX;
                }

                int nToMax = (int)((275 / coefficient) / divisionPrice);//Количество рисочек от нуля до крайнего правого значаения
                double coefficientY = (275.0 / coefficient) / 275.0;//Шаг
                double y = 0;
                int n = 1;

                for (int i = 275; i > 0; i--)//Рисуем рисочки выше нуля
                {
                    if (((y - coefficientY) < (0 + n * divisionPrice) && (y + coefficientY) > (0 + n * divisionPrice)) || y == (0 + n * divisionPrice))
                    {
                        if (n == nToMax + 1)
                        {
                            break;
                        }
                        for (int j = 0, xOf = iOfZeroX - 6; j < 11; j++, xOf++)
                        {
                            points[j] = new Point(xOf, i);
                        }
                        graphics.DrawLines(pen, points);
                        graphics.DrawString(Convert.ToString(Math.Round((0 + n * divisionPrice), 2)), font, drawBrush, points[10].X + 20, points[10].Y);//Число справа от рисочкой
                        n++;
                    }
                    y += coefficientY;
                }

                y = 0;
                n = 1;
                for (int i = 275; i < 550; i++)//Рисуем рисочки ниже нуля
                {
                    if (((y - coefficientY) < (0 - n * divisionPrice) && (y + coefficientY) > (0 - n * divisionPrice)) || y == (0 - n * divisionPrice))
                    {
                        if (n == nToMax + 1)
                        {
                            break;
                        }
                        for (int j = 0, xOf = iOfZeroX - 6; j < 11; j++, xOf++)
                        {
                            points[j] = new Point(xOf, i);
                        }
                        graphics.DrawLines(pen, points);
                        graphics.DrawString(Convert.ToString(Math.Round((0 - n * divisionPrice), 2)), font, drawBrush, points[10].X + 20, points[10].Y);//Число справа от рисочкой
                        n++;
                    }
                    y -= coefficientY;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
    }
}
