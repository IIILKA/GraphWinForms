using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorWinForms
{
    static class MathExpression
    {
        static char[] operators = { '+', '-', '*', '/', '^' };

        /// <summary>
        /// Возвращает разницу между количеством открыващих и закрывающих скобак
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static private int FindMissedParentheseCount(string str)
        {
            int balanceFactorOfParenthese = 0;//Переменная отвечающая за разнице между открывающимися и закрывающимися скобками
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    balanceFactorOfParenthese++;
                }
                else if (str[i] == ')')
                {
                    balanceFactorOfParenthese--;
                }
            }
            return balanceFactorOfParenthese;
        }

        /// <summary>
        /// Возвращает переданную строку без пробелов
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static private string DeleteAllSpacebars(string str)
        {
            string str2 = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    str2 += str[i];
                }
            }
            return str2;
        }

        /// <summary>
        /// Проверяет выражение на корректность
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static private bool IsCorect(string str)
        {
            //Проверяем выражение на корректность 

            if (!(str[0] == '-' || str[0] == '(' || (str[0] >= '0' && str[0] <= '9') || (str[0] >= 'a' && str[0] < 'z')))
            {
                return false;
            }


            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == '.' && ((str[i - 1] < '0' || str[i - 1] > '9') && (str[i + 1] < '0' || str[i + 1] > '9')))//Если слева и справа от точки находится не число 
                {
                    return false;
                }
                else if ((str[i] == '+' || str[i] == '-' || str[i] == '*' || str[i] == '/' || str[i] == '^') && (str[i - 1] == '+' || str[i - 1] == '-' || str[i - 1] == '*' || str[i - 1] == '/' || str[i - 1] == '^'))
                {                                                                                                                           //Если слева от оператора находится другой оператор
                    return false;
                }
                else if (str[i - 1] == '(' && (str[i] == '+' || str[i] == '*' || str[i] == '/' || str[i] == '^' || str[i] == ')'))//Если справа от открывающей скобки находятся
                {                                                                                      //операторы(кроме минуса) или закрывающая скобка
                    return false;
                }
                else if (str[i] == ')' && (str[i - 1] == '+' || str[i - 1] == '-' || str[i - 1] == '*' || str[i - 1] == '/' || str[i - 1] == '^'))//Если слева от закрывающей скобки находятся операторы
                {
                    return false;
                }
                else if (str[i] == '(' && i != 0 && !(Array.Exists(operators, element => element == str[i - 1]) || str[i - 1] == '(' || str[i - 1] == 's' || str[i - 1] == 'n' || str[i - 1] == 'g'))
                {//Если слева от открывающей скобки находится что-то кроме операторов или открывающей скобки(если скобка не стоит в начаде выражения) (буквы s, n, g сответствуют концу cos, sin, tg, ctg)
                    return false;
                }
                else if (str[i] == ')' && i + 1 != str.Length && !(Array.Exists(operators, element => element == str[i + 1]) || str[i + 1] == ')'))//Если
                {                                   //справа от закрывающей скобки находится что-то кроме операторов, закрывающей скобки или конец строки
                    return false;
                }
            }

            if (FindMissedParentheseCount(str) < 0)
            {
                return false;
            }

            return true;

        }


        /// <summary>
        /// Устонавливает пробелы между операторами, операндами и скобками
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static private string SetSpacebarsBetweenOperatorsOperandsParentheses(string str)
        {
            string str2 = "";//Формируем финальное выражение, так чтобы всё можно было бы удобно запихивать в стек(разделяя числа, опреаторы и скобки пробелом)
            for (int i = 0; i < str.Length; i++)//Если мы встречаем оператор, то ставим слева и справа от его пробел и добавляем в финальную выражение, и по одному пробела справ от открывающей и слева от закрывающей скобки
            {
                if (i == 0 && str[i] == '-' && str[i + 1] == '(')//Если минус в начале строки, значит это не оператор, а отрицательное число
                {
                    str2 += "-1 * ";
                }
                else if (i == 0 && str[i] == '-')
                {
                    str2 += '-';
                }
                else if (str[i] == '-' && str[i - 1] == '(')//Если минкс стоит сразу после открывающей скобки значит это не оператор, а отрицательное число
                {
                    str2 += '-';
                }
                else if ((str[i] >= '0' && str[i] <= '9') || str[i] == '.')//Числа и точки добовляяются без пробелов
                {
                    str2 += str[i];
                }
                else if (Array.Exists(operators, element => element == str[i]))//Добовляем операторов с пробелами
                {
                    str2 += " " + str[i] + " ";
                }
                else if (str[i] == 'c' || str[i] == 's')
                {
                    str2 += str[i];
                    str2 += str[i + 1];
                    str2 += str[i + 2];
                    i += 2;
                }
                else if (str[i] == 't' || str[i] == 'p')
                {
                    str2 += str[i];
                    str2 += str[i + 1];
                    i += 1;
                }
                else if (str[i] == 'e')
                {
                    str2 += str[i];
                }
                else if (str[i] == '(')
                {
                    str2 += "( ";
                }
                else if (str[i] == ')')
                {
                    str2 += " )";
                }
            }
            return str2;
        }

        /// <summary>
        /// Добавляет в строку нехватающие скобки через пробел
        /// </summary>
        /// <param name="str"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        static private string AddMissedParentheses(string str, int count)
        {
            for (int i = 0; i < count; i++)//Если количество открывающих скобок больше чем количество открывающихся, то мы добовляем свои закрывающие скобки
            {                                                //так чтобы их общее количество стало равным количеству открывающих
                str += " )";
            }
            return str;
        }

        /// <summary>
        /// Если количество точек хотя бы в одном числе больше чем 1 то возвращает false
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static private bool IsAllNumbersHasLessThanTwoPoints(string str)
        {
            bool onePoint = false;//Ставим true если встечем точку и false если заканчиваем просматривать число(это нужно чтобы убедиться что в одном числе не боьше одной точки)
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    onePoint = false;
                }
                else if (str[i] == '.' && onePoint == true)
                {
                    return false;
                }
                else if (str[i] == '.')
                {
                    onePoint = true;
                }
            }
            return true;
        }

        //Функция которая проверяет строку на корректность и возыращает строку в которой операторы и операнды разделены пробелом
        /// <summary>
        /// Проверяет на корректность выражение, и если выражение корректно то возвращает это же выражение, но между каждым оператором, операндом и скобкой есть один пробел
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public string NormExpression(string str)
        {
            str = DeleteAllSpacebars(str);

            //Проверяем выражение на корректность 
            if (!IsCorect(str))
            {
                return "Ты ввёл некорректное выражение!";
            }

            str = SetSpacebarsBetweenOperatorsOperandsParentheses(str);

            if (FindMissedParentheseCount(str) > 0)
            {
                str = AddMissedParentheses(str, FindMissedParentheseCount(str));
            }

            if (!IsAllNumbersHasLessThanTwoPoints(str))
            {
                return "Ты ввёл некорректное выражение!";
            }

            return str;
        }

        /// <summary>
        /// Заменяет х в выражении str на num (с учётом того что num может быть отрицательным числом)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        static public string ReplaceX(string str, int num)
        {
            string finalStr = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'x')
                {
                    if (i != 0 && str[i - 1] >= '0' && str[i - 1] <= '9')//Допустим у нас написанно 5x очевидно что это значит 5*x, но программа этого не знает, вот мы указываем это явно
                    {
                        finalStr += "*";
                    }

                    if (i != 0 && num < 0 && str[i] == 'x' && str[i - 1] == '-' && (i == 1 || str[i - 2] == '('))//Если наше число отрицательно, а оператор перед этим число это '-' и при всём это этот минус либо перед скобкой 
                    {                                                                                      //либо в начале выражения, значит мы убираем этот минус и записываем абсолютное значение числа
                        string finalStrBuffer = "";
                        for (int j = 0; j < finalStr.Length - 1; j++)
                        {
                            finalStrBuffer += finalStr[j];
                        }
                        finalStr = finalStrBuffer;
                        finalStr += Convert.ToString(-num);
                    }
                    else if (i != 0 && num < 0 && str[i - 1] == '-')//Если наше число отрицательное, а оператор перед этим числом это '-', значит вместо '-' ставим '+' и подставляем абсолютное значение числа
                    {
                        string finalStrBuffer = "";
                        for (int j = 0; j < finalStr.Length - 1; j++)
                        {
                            finalStrBuffer += finalStr[j];
                        }
                        finalStrBuffer += '+';
                        finalStr = finalStrBuffer;
                        finalStr += Convert.ToString(-num);
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


        /// <summary>
        /// Вычитает член выражения из начала строки и возвращает его
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public string GetMemberOfExpression(ref string str)//Члены выражения разделены пробелом
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
            string strBuffer = "";//Сюда помещаем исходную строку без str2 и пробела между ними
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
        static public string GetExpressionIn(ref string str)
        {
            string str2 = "";//Строка в которую мы помещаем следущий член выражения 
            int position = 0;//Сюда поместим позицию последнего символа члена выражения
            int countParanthesis = 0;
            for (int i = 0; ; i++)
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
            for (int i = (position + 3); i < str.Length; i++)
            {
                strBuffer += str[i];
            }
            str = strBuffer;
            return str2;
        }

    }
}
