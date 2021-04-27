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
            if (arr[position - 1] == '-' || arr[position - 1] == '*' || arr[position - 1] == '÷' || arr[position - 1] == '^')
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
            if (arr[position - 1] == '+' || arr[position - 1] == '*' || arr[position - 1] == '÷' || arr[position - 1] == '^')
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
            if (arr[position - 1] == '+' || arr[position - 1] == '-' || arr[position - 1] == '÷' || arr[position - 1] == '^')
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
            if (arr[position - 1] == '+' || arr[position - 1] == '-' || arr[position - 1] == '*' || arr[position - 1] == '^')
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
            if (arr[position - 1] == '+' || arr[position - 1] == '-' || arr[position - 1] == '*' || arr[position - 1] == '÷')
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
            }
        }
    }
}
