using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignmet_Calculator
{
    public partial class Form1 : Form
    {
        double A = 0;
        double B = 0;
        double C = 0;
        double result = 0;
        int operation = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "0") label1.Text = "0";
            else label1.Text = label1.Text + "0";
            if(operation != 0) label2.Text = label2.Text + "0";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label1.Text == "0") label1.Text = "1";
            else label1.Text = label1.Text + "1";
            if (operation != 0) label2.Text = label2.Text + "1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label1.Text == "0") label1.Text = "2";
            else label1.Text = label1.Text + "2";
            if (operation != 0) label2.Text = label2.Text + "2";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label1.Text == "0") label1.Text = "3";
            else label1.Text = label1.Text + "3";
            if (operation != 0) label2.Text = label2.Text + "3";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label1.Text == "0") label1.Text = "4";
            else label1.Text = label1.Text + "4";
            if (operation != 0) label2.Text = label2.Text + "4";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (label1.Text == "0") label1.Text = "5";
            else label1.Text = label1.Text + "5";
            if (operation != 0) label2.Text = label2.Text + "5";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (label1.Text == "0") label1.Text = "6";
            else label1.Text = label1.Text + "6";
            if (operation != 0) label2.Text = label2.Text + "6";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (label1.Text == "0") label1.Text = "7";
            else label1.Text = label1.Text + "7";
            if (operation != 0) label2.Text = label2.Text + "7";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (label1.Text == "0") label1.Text = "8";
            else label1.Text = label1.Text + "8";
            if (operation != 0) label2.Text = label2.Text + "8";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (label1.Text == "0") label1.Text = "9";
            else label1.Text = label1.Text + "9";
            if (operation != 0) label2.Text = label2.Text + "9";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if(operation != 0)
            {
                B = Convert.ToInt32(label1.Text);
                if (operation == 1)
                {
                    result = A + B;
                }
                else if(operation == 2)
                {
                    result = A - B;
                }
                else if (operation == 3)
                {
                    result = A * B;
                }
                else if (operation == 4)
                {
                    result = A / B;
                }
                label3.Text = result.ToString();
                label1.Text = "0";
                label2.Text = "0";
                operation = 0;
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(operation == 0)
            {
                label2.Text = label1.Text + " + ";
                A = Convert.ToInt32(label1.Text);
                operation = 1;
                label1.Text = "0";
            }
            else
            {
                B = Convert.ToInt32(label1.Text);
                if (operation == 1)
                {
                    C = A + B;
                }
                else if (operation == 2)
                {
                    C = A - B;
                }
                else if (operation == 3)
                {
                    C = A * B;
                }
                else if (operation == 4)
                {
                    C = A / B;
                }
                label3.Text = C.ToString();
                label1.Text = "0";
                label2.Text = label2.Text + " + ";
                operation = 1;
                A = C;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (operation == 0)
            {
                label2.Text = label1.Text + " - ";
                A = Convert.ToInt32(label1.Text);
                operation = 2;
                label1.Text = "0";
            }
            else
            {
                B = Convert.ToInt32(label1.Text);
                if (operation == 1)
                {
                    C = A + B;
                }
                else if (operation == 2)
                {
                    C = A - B;
                }
                else if (operation == 3)
                {
                    C = A * B;
                }
                else if (operation == 4)
                {
                    C = A / B;
                }
                label3.Text = C.ToString();
                label1.Text = "0";
                label2.Text = label2.Text + " - ";
                operation = 2;
                A = C;
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (operation == 0)
            {
                label2.Text = label1.Text + " * ";
                A = Convert.ToInt32(label1.Text);
                operation = 3;
                label1.Text = "0";
            }
            else
            {
                B = Convert.ToInt32(label1.Text);
                if (operation == 1)
                {
                    C = A + B;
                }
                else if (operation == 2)
                {
                    C = A - B;
                }
                else if (operation == 3)
                {
                    C = A * B;
                }
                else if (operation == 4)
                {
                    C = A / B;
                }
                label3.Text = C.ToString();
                label1.Text = "0";
                label2.Text = label2.Text + " * ";
                operation = 3;
                A = C;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (operation == 0)
            {
                label2.Text = label1.Text + " / ";
                A = Convert.ToInt32(label1.Text);
                operation = 4;
                label1.Text = "0";
            }
            else
            {
                B = Convert.ToInt32(label1.Text);
                if (operation == 1)
                {
                    C = A + B;
                }
                else if (operation == 2)
                {
                    C = A - B;
                }
                else if (operation == 3)
                {
                    C = A * B;
                }
                else if (operation == 4)
                {
                    C = A / B;
                }
                label3.Text = C.ToString();
                label1.Text = "0";
                label2.Text = label2.Text + " / ";
                operation = 4;
                A = C;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text.Remove(label1.Text.Length - 1);
            if (label1.Text.Length == 0)
                label1.Text = "0";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            A = 0;
            B = 0;
            operation = 0;
            result = 0;
            label1.Text = "0";
            label2.Text = "0";
            label3.Text = "0";
        }
    }
}
