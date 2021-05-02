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

        
        static string replaceX(string str, int num)
        {
            string finalStr = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'x')
                {
                    if (i != 0 && str[i - 1] >= '0' && str[i - 1] <= '9')
                    {
                        finalStr += "*";
                    }

                    /*if (i != 0 && (str[i - 1] == '+' || str[i - 1] == '-' || str[i - 1] == '*' || str[i - 1] == '÷' || str[i - 1] == '^'))
                    {
                        finalStr += '(';
                        finalStr += Convert.ToString(num);
                        finalStr += ')';
                    }
                    else
                    {
                        finalStr += Convert.ToString(num);
                    }*/
                    if (i != 0 && str[i - 1] != '(')
                    {
                        finalStr += '(';
                        finalStr += Convert.ToString(num);
                        finalStr += ')';
                    }
                    else
                    {
                        finalStr += Convert.ToString(num);
                    }
                }
                else
                {
                    finalStr += str[i];
                }
            }
            return finalStr;
        }

        class StackOfOperators
        {
            public char data;
            public int priority;
            public StackOfOperators next;
        }

        class StackOfDouble
        {
            public double data;
            public StackOfDouble next;
        }

        static void AddStack(ref StackOfOperators top, char data)
        {
            StackOfOperators stack = new StackOfOperators();
            stack.data = data;
            if (data == '^')
            {
                stack.priority = 1;
            }
            else if (data == '*' || data == '/')
            {
                stack.priority = 2;
            }
            else if (data == '+' || data == '-')
            {
                stack.priority = 3;
            }
            else
            {
                stack.priority = 4;
            }

            if (top == null)
            {
                stack.next = null;
                top = stack;
            }
            else
            {
                stack.next = top;
                top = stack;
            }
        }

        static void AddStack(ref StackOfDouble top, double data)
        {
            StackOfDouble stack = new StackOfDouble();
            stack.data = data;
            if (top == null)
            {
                stack.next = null;
                top = stack;
            }
            else
            {
                stack.next = top;
                top = stack;
            }
        }


        static string GetMemberOfExpression(ref string str)
        {
            string str2 = "";//Строка в которую мы помещаем следущий член выражения 
            int position = 0;//Сюда поместим позицию последнего символа члена выражения
            for (int i = 0; str[i] != ' '; i++)
            {
                str2 += str[i];
                position = i;
                if (i + 1 == str.Length)//Проверка на конец строки чтобы не выйти за пределы массива
                {
                    break;
                }
            }
            string strBuffer = "";//Сида помещаем исходную строку без str2 и пробела между ними
            for (int i = position + 2; i < str.Length; i++)
            {
                strBuffer += str[i];
            }
            str = strBuffer;
            return str2;
        }

        /// <summary>
        /// Возвращает выражение которое находится до закрывающей скобки. Удобно использывать для того чтобы найти выражение внутри sin, cos, tg, ctg
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string GetExpressionIn(ref string str, bool tg)
        {
            string str2 = "";//Строка в которую мы помещаем следущий член выражения 
            int position = 0;//Сюда поместим позицию последнего символа члена выражения
            int countParanthesis = 0;
            for (int i = 0;; i++)
            {
                if (str[i + 1] == ')' && countParanthesis == 0)
                {
                    break;
                }

                if (str[i] == '(')
                {
                    countParanthesis++;
                }
                else if (str[i] == ')')
                {
                    countParanthesis--;
                }

                str2 += str[i];
                position = i;
            }
            string strBuffer = "";//Сида помещаем исходную строку без str2 и пробела между ними
            for (int i = tg ? (position + 3) : (position + 4); i < str.Length; i++)
            {
                strBuffer += str[i];
            }
            str = strBuffer;
            return str2;
        }

        static int GetPriority(char data)
        {
            int priority;
            if (data == '^')
            {
                priority = 1;
            }
            else if (data == '*' || data == '/')
            {
                priority = 2;
            }
            else if (data == '+' || data == '-')
            {
                priority = 3;
            }
            else
            {
                priority = 4;
            }
            return priority;
        }

        static string ReverseInPolishNotation(string str)
        {
            StackOfOperators top = null;
            string finalExpression = "", buffer;
            while (true)
            {
                if (str == "")
                {
                    break;
                }

                buffer = GetMemberOfExpression(ref str);//Получаем под строку и вычитаем эту подстроку из исходной строки вместе с пробелом
                if (buffer == "(" || buffer == ")" || buffer == "+" || buffer == "-" || buffer == "*" || buffer == "/" || buffer == "^")
                {
                    if (buffer == "(")
                    {
                        AddStack(ref top, '(');
                    }
                    else if (buffer == ")")
                    {
                        while (true)
                        {
                            if (top.data == '(')
                            {
                                if (top.next != null)
                                {
                                    top = top.next;
                                }
                                else
                                {
                                    top = null;
                                }
                                break;
                            }
                            finalExpression += (top.data + " ");
                            top = top.next;
                        }
                    }
                    else
                    {
                        int priority = GetPriority(Convert.ToChar(buffer));//Получаем приоритет текущего оператора чтобы знать какие операторы выталкивать из стека

                        while (true)
                        {
                            if (top == null)
                            {
                                break;
                            }
                            else if (top.data == '(')
                            {
                                //top = top.next;
                                break;
                            }
                            else if (top.priority > priority)
                            {
                                break;
                            }
                            finalExpression += (top.data + " ");
                            top = top.next;
                        }
                        AddStack(ref top, Convert.ToChar(buffer));
                    }
                }
                else
                {
                    double result = 0;
                    if (buffer[0] == 's' || buffer[0] == 'c' || buffer[0] == 't')
                    {
                        if (buffer[0] == 's')
                        {
                            buffer = GetExpressionIn(ref str, false);
                            string strForSinCosTgCtgInPolishNotation = ReverseInPolishNotation(buffer);//Записываем сьда выражение внутри sin, cos, tg или ctg с помощью обратной польской записи
                            result = ReverseOutPolishNotation(strForSinCosTgCtgInPolishNotation);//Получаем ответ из выражение внутри sin, cos, th или ctg которое уже записанно обратной польской записью
                            result = Math.Sin(result/10);
                        }
                        else if (buffer[0] == 'c' && buffer[1] == 'o')
                        {
                            buffer = GetExpressionIn(ref str, false);
                            string strForSinCosTgCtgInPolishNotation = ReverseInPolishNotation(buffer);//Записываем сьда выражение внутри sin, cos, tg или ctg с помощью обратной польской записи
                            result = ReverseOutPolishNotation(strForSinCosTgCtgInPolishNotation);//Получаем ответ из выражение внутри sin, cos, th или ctg которое уже записанно обратной польской записью
                            result = Math.Cos(result/10);
                        }
                        else if (buffer[0] == 't')
                        {
                            buffer = GetExpressionIn(ref str, true);
                            string strForSinCosTgCtgInPolishNotation = ReverseInPolishNotation(buffer);//Записываем сьда выражение внутри sin, cos, tg или ctg с помощью обратной польской записи
                            result = ReverseOutPolishNotation(strForSinCosTgCtgInPolishNotation);//Получаем ответ из выражение внутри sin, cos, th или ctg которое уже записанно обратной польской записью
                            if (result % (Math.PI / 2) == 0)
                            {
                                return "Недопустимое выражение в tg";
                            }
                            result = Math.Tan(result/10);
                        }
                        else if (buffer[0] == 'c' && buffer[1] == 't')
                        {
                            buffer = GetExpressionIn(ref str, false);
                            string strForSinCosTgCtgInPolishNotation = ReverseInPolishNotation(buffer);//Записываем сьда выражение внутри sin, cos, tg или ctg с помощью обратной польской записи
                            result = ReverseOutPolishNotation(strForSinCosTgCtgInPolishNotation);//Получаем ответ из выражение внутри sin, cos, th или ctg которое уже записанно обратной польской записью
                            if (result % Math.PI == 0)
                            {
                                return "Недопустимое выражение в ctg";
                            }
                            result = 1.0 / Math.Tan(result/10);
                        }
                        finalExpression += (Convert.ToString(result) + " ");
                    }
                    else if (buffer[0] == 'p')
                    {
                        finalExpression += (Convert.ToString(Math.PI) + " ");
                    }
                    else if (buffer == "e")
                    {
                        finalExpression += (Convert.ToString(Math.E) + " ");
                    }
                    else
                    {
                        finalExpression += (buffer + " ");
                    }
                }
            }

            while (top != null)
            {
                finalExpression += (top.data + " ");
                top = top.next;
            }
            //Console.WriteLine(finalExpression);
            //Console.WriteLine(str);
            string bf = "";
            for (int i = 0; i < finalExpression.Length - 1; i++)
            {
                bf += finalExpression[i];
            }
            finalExpression = bf;
            return finalExpression;
        }

        static double ReverseOutPolishNotation(string str)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            StackOfDouble top = null;
            string buffer;
            while (str != "")
            {
                buffer = GetMemberOfExpression(ref str);
                if (buffer != "+" && buffer != "-" && buffer != "*" && buffer != "/" && buffer != "^")
                {
                    double data = Convert.ToDouble(buffer);
                    AddStack(ref top, data);
                }
                else
                {
                    if (buffer == "+")
                    {
                        double num1, num2;
                        num1 = top.data;
                        top = top.next;
                        num2 = top.data;
                        top = top.next;
                        AddStack(ref top, num2 + num1);
                    }
                    else if (buffer == "-")
                    {
                        double num1, num2;
                        num1 = top.data;
                        top = top.next;
                        num2 = top.data;
                        top = top.next;
                        AddStack(ref top, num2 - num1);
                    }
                    else if (buffer == "*")
                    {
                        double num1, num2;
                        num1 = top.data;
                        top = top.next;
                        num2 = top.data;
                        top = top.next;
                        AddStack(ref top, num2 * num1);
                    }
                    else if (buffer == "/")
                    {
                        double num1, num2;
                        num1 = top.data;
                        top = top.next;
                        num2 = top.data;
                        top = top.next;
                        AddStack(ref top, num2 / num1);
                    }
                    else if (buffer == "^")
                    {
                        double num1, num2;
                        num1 = top.data;
                        top = top.next;
                        num2 = top.data;
                        top = top.next;
                        AddStack(ref top, Math.Pow(num2, num1));
                    }
                }
            }
            return top.data;
        }

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
            double coefficient;
            if (textBox1.Text == "")
            {
                coefficient = 1;
            }
            else
            {
                coefficient = Convert.ToDouble(textBox1.Text);
            }
            
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

            int countParanthesis = 0;
            for (int i = 0; arr[i] != 0; i++)
            {
                if (arr[i] == '÷')
                {
                    arr[i] = '/';
                }
                if (arr[i] == '(')
                {
                    countParanthesis++;
                }
                else if (arr[i] == ')')
                {
                    countParanthesis--;
                }
            }

            if (countParanthesis > 0)
            {
                for (int i = 0; i < countParanthesis; i++)
                {
                    for (int j = 0;; j++)
                    {
                        if (arr[j] == 0)
                        {
                            arr[j] = ')';
                            break;
                        }
                    }
                }
            }

            string str = "";
            for (int i = 0; arr[i] != 0; i++)
            {
                str += arr[i];
            }
            str = replaceX(str, 1 - 448);
            str = MathExpression.NormExpression(str);
            if (str == "Ты ввёл некорректное выражение!")
            {
                label1.Text = "Некорректное выражение!";
                return;
            }

            Graphics graphics = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Red, 1f);

            Point[] points = new Point[896];
            for (int i = 0; i < points.Length; i++)//Рисуем горизонтальную черту симметрии
            {
                points[i] = new Point(i, 285);
            }
            graphics.DrawLines(pen, points);

            points = new Point[552];
            for (int i = 0; i < points.Length; i++)//Рисуем вертикальную черту симметрии
            {
                points[i] = new Point(448, i);
            }
            graphics.DrawLines(pen, points);

            pen = new Pen(Color.Black, 3f);
            points = new Point[896];

            for (int i = 0; i < points.Length; i++)
            {
                str = "";
                for (int j = 0; arr[j] != 0; j++)
                {
                    str += arr[j];
                }
                str = replaceX(str, i - 448);
                str = MathExpression.NormExpression(str);
                str = ReverseInPolishNotation(str);
                if (str == "Недопустимое выражение в tg")
                {
                    continue;
                }
                else if (str == "Недопустимое выражение в ctg")
                {
                    continue;
                }
                double result = ReverseOutPolishNotation(str);

                points[i] = new Point(i, 285 - (int)(result*coefficient));
                //points[i] = new Point(i, 315 - (int)(Math.Sin((double)i/10)*100));
            }
            graphics.DrawLines(pen, points);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

    }
}
