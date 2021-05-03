using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorWinForms
{
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

    class Calculator
    {
        static private void AddStack(ref StackOfOperators top, char data)
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

        static private void AddStack(ref StackOfDouble top, double data)
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

        static private int GetPriority(char data)
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




        static public string ReverseInPolishNotation(string str)
        {
            StackOfOperators top = null;
            string finalExpression = "", buffer;
            while (true)
            {
                if (str == "")
                {
                    break;
                }

                buffer = MathExpression.GetMemberOfExpression(ref str);//Получаем под строку и вычитаем эту подстроку из исходной строки вместе с пробелом
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
                            buffer = MathExpression.GetExpressionIn(ref str);
                            string strForSinCosTgCtgInPolishNotation = ReverseInPolishNotation(buffer);//Записываем сьда выражение внутри sin, cos, tg или ctg с помощью обратной польской записи
                            result = ReverseOutPolishNotation(strForSinCosTgCtgInPolishNotation);//Получаем ответ из выражение внутри sin, cos, th или ctg которое уже записанно обратной польской записью
                            result = Math.Sin(result / 10);
                        }
                        else if (buffer[0] == 'c' && buffer[1] == 'o')
                        {
                            buffer = MathExpression.GetExpressionIn(ref str);
                            string strForSinCosTgCtgInPolishNotation = ReverseInPolishNotation(buffer);//Записываем сьда выражение внутри sin, cos, tg или ctg с помощью обратной польской записи
                            result = ReverseOutPolishNotation(strForSinCosTgCtgInPolishNotation);//Получаем ответ из выражение внутри sin, cos, th или ctg которое уже записанно обратной польской записью
                            result = Math.Cos(result / 10);
                        }
                        else if (buffer[0] == 't')
                        {
                            buffer = MathExpression.GetExpressionIn(ref str);
                            string strForSinCosTgCtgInPolishNotation = ReverseInPolishNotation(buffer);//Записываем сьда выражение внутри sin, cos, tg или ctg с помощью обратной польской записи
                            result = ReverseOutPolishNotation(strForSinCosTgCtgInPolishNotation);//Получаем ответ из выражение внутри sin, cos, th или ctg которое уже записанно обратной польской записью
                            if ((int)(result % (3.1415926535897931 / 2)) == 0)
                            {
                                return "Недопустимое выражение в tg";
                            }
                            result = Math.Tan(result / 10);
                        }
                        else if (buffer[0] == 'c' && buffer[1] == 't')
                        {
                            buffer = MathExpression.GetExpressionIn(ref str);
                            string strForSinCosTgCtgInPolishNotation = ReverseInPolishNotation(buffer);//Записываем сьда выражение внутри sin, cos, tg или ctg с помощью обратной польской записи
                            result = ReverseOutPolishNotation(strForSinCosTgCtgInPolishNotation);//Получаем ответ из выражение внутри sin, cos, th или ctg которое уже записанно обратной польской записью
                            if (result % Math.PI == 0)
                            {
                                return "Недопустимое выражение в ctg";
                            }
                            result = 1.0 / Math.Tan(result / 10);
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

        static public double ReverseOutPolishNotation(string str)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            StackOfDouble top = null;
            string buffer;
            while (str != "")
            {
                buffer = MathExpression.GetMemberOfExpression(ref str);
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
    }
}
